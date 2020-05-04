using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Configuration.Install;
using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using DXM.Store;

namespace DXM.Controller
{
    public partial class Form1 : Form
    {
        private bool inicio = true;
        private string status="";
        private int statusIndex = 0;
        private string nome="";
        private Store.Store banco = new Store.Store();
        private string portaService = "";
        private bool startup = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            portaService = banco.servicePorta;
            startup = banco.serviceStartUp;
            SetStartup(startup);
            txtPorta.Text = portaService;
            check.Checked = startup;
            servicosScan();
            var menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem("Web Interface", webinterface));
            menu.MenuItems.Add(new MenuItem("Iniciar Servidor", iniServico));
            menu.MenuItems.Add(new MenuItem("Parar Servidor",stopServico));
            menu.MenuItems.Add(new MenuItem("Configurar",config));
            menu.MenuItems.Add(new MenuItem("Sair", fecharJanela));
            notifyIcon1.ContextMenu = menu;
            this.Visible = false;
        }

        private void fecharJanela(object sender, EventArgs e)
        {
            this.Close();
        }

        private void config(object sender, EventArgs e)
        {
            this.Show();
        }

        private void stopServico(object sender, EventArgs e)
        {
            ServiceController[] services = ServiceController.GetServices();

            try
            {

                for (int x = 0; x < services.Length; x++)
                {
                    if (services[x].ServiceName == "DXM_Web")
                    {
                        services[x].Stop();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iniServico(object sender, EventArgs e)
        {
            ServiceController[] services = ServiceController.GetServices();
            try
            {

                for (int x = 0; x < services.Length; x++)
                {
                    if (services[x].ServiceName == "DXM_Web")
                    {
                        services[x].Start();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void webinterface(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"http:\\localhost:5000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            servicosScan();
            

        }


        private void button4_Click(object sender, EventArgs e)
        {
            string file = AppContext.BaseDirectory + @"service\DXM.Web.Interface.exe";
            try
            {
                if (File.Exists(file)) {
                    Install("DXM_Web", file);
                }
                else
                {
                    MessageBox.Show("Executável do serviço não localizado indique o caminho", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    openFileDialog1.ShowDialog();
                    file = openFileDialog1.FileName;
                    MessageBox.Show(file);
                    if (File.Exists(file))
                    {
                        Install("DXM_Web", file);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel localizar o arquivo de serviço entre em contato com o Fornecedor", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                    
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
               
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Process.Start(@"C:\Windows\system32\sc.exe","stop DXM_Web");
            //Process.Start(@"C:\Windows\system32\sc.exe","delete DXM_Web");
        }

      
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Process.Start(@"http:\\localhost:5000");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try { 
            Process.Start(@"http:\\localhost:5000");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }







        public virtual void Install(string serviceName, string arquivo)
        {
            //Logger.Info("Installing service '{0}'", serviceName);

            var installer = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            };

            var serviceInstaller = new ServiceInstaller();


            String[] cmdline = { @"/assemblypath=" + arquivo };

            var context = new InstallContext("service_install.log", cmdline);
            serviceInstaller.Context = context;
            serviceInstaller.DisplayName = serviceName;
            serviceInstaller.ServiceName = serviceName;
            serviceInstaller.Description = "DXM server application";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            serviceInstaller.Parent = installer;

            serviceInstaller.Install(new ListDictionary());

            //Logger.Info("Service Has installed successfully.");
        }
        
        private void servicosScan()
        {
            try
            {
                ServiceController[] services = ServiceController.GetServices();


                bool achou = false;
                for (int x = 0; x < services.Length; x++)
                {
                    if (services[x].ServiceName == "DXM_Web")
                    {
                        nome = services[x].ServiceName.ToString();
                        status = services[x].Status.ToString();
                        achou = true;
                    }
                }
                if (!achou)
                {
                    status= "Processo Inexistente";
                }
            }
            catch { }
        }
        public static void SetStartup(bool OnOff)
        {
            try
            {
                //Nome a ser exibido no registro ou quando Der MSCONFIG - Pode Alterar
                string appName = "SAT Manager - 4Way Systems";

                //Diretorio da chave do Registro NAO ALTERAR
                string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

                //Abre o registro
                RegistryKey startupKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                //Valida se vai incluir o iniciar com o Windows ou remover
                if (OnOff)//Iniciar
                {
                    if (startupKey.GetValue(appName) == null)
                    {
                        // Add startup reg key
                        startupKey.SetValue(appName, @"""" + Application.ExecutablePath.ToString() + @"""");
                        startupKey.Close();
                    }
                }
                else//Nao iniciar mais
                {
                    // remove startup
                    startupKey = Registry.LocalMachine.OpenSubKey(runKey, true);
                    startupKey.DeleteValue(appName, false);
                    startupKey.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string getip()
        {
            string nome = Dns.GetHostName();
            string ret = "";

            IPAddress[] ip = Dns.GetHostAddresses(nome);

            for(int x = 0; x < ip.Length; x++)
            {
                if (!ip[x].ToString().Contains("%"))
                {
                    return ip[x].ToString();
                }
            }
            ret = "Nulo";
            return ret;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (inicio)
            {
                if (status.Contains("Running"))
                {
                    this.Visible = false;
                    inicio = false;
                    try
                    {
                        Process.Start(@"http:\\localhost:5000");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            try
            {
                servicosScan();
                if (status.Contains("Running"))
                {
                    
                    notifyIcon1.Icon = Properties.Resources.notifiOk;
                    notifyIcon1.BalloonTipText = "Serviço funcionando Normalmente";
                    if(statusIndex != 0){
                        notifyIcon1.ShowBalloonTip(5000, "Info DMX", "O Servidor Esta funcinando Normalmente", ToolTipIcon.Info);
                        this.Visible = false;

                        try
                        {
                            Process.Start(@"http:\\localhost:5000");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        inicio = false;
                    }
                    notifyIcon1.ContextMenu.MenuItems[0].Enabled = true;
                    notifyIcon1.ContextMenu.MenuItems[1].Enabled = false;
                    notifyIcon1.ContextMenu.MenuItems[2].Enabled = true;
                    statusIndex = 0;
                   
                }
                if (status.Contains("Stop"))
                {
                    notifyIcon1.Icon = Properties.Resources.notifiEspera;
                    notifyIcon1.BalloonTipText = "Serviço Parado";
                    if (statusIndex != 1) { notifyIcon1.ShowBalloonTip(5000, "Info DXM", "O Servidor Está Parado", ToolTipIcon.Info); }
                    notifyIcon1.ContextMenu.MenuItems[0].Enabled = true;
                    notifyIcon1.ContextMenu.MenuItems[1].Enabled = true;
                    notifyIcon1.ContextMenu.MenuItems[2].Enabled = false;
                    statusIndex = 1;
                }
                if (status.Contains("Start"))
                {
                    notifyIcon1.Icon = Properties.Resources.notifiEspera;
                    notifyIcon1.BalloonTipText = "Serviço Inicializando";
                    if (statusIndex != 2) { notifyIcon1.ShowBalloonTip(5000, "Info DXM", "O Servidor foi Iniciado", ToolTipIcon.Info); }
                    statusIndex = 2;
                }
                if (status.Contains("Inexistente"))
                {
                    notifyIcon1.Icon = Properties.Resources.notifiFalha;
                    notifyIcon1.BalloonTipText = "Serviço Em Falha Grave";
                    if (statusIndex != 3) {
                       
                        notifyIcon1.ShowBalloonTip(5000, "Falha DXM", "O Servidor Não Está Disponível", ToolTipIcon.Error);
                    }
                    notifyIcon1.ContextMenu.MenuItems[0].Enabled = false;
                    notifyIcon1.ContextMenu.MenuItems[1].Enabled = false;
                    notifyIcon1.ContextMenu.MenuItems[2].Enabled = false;
                    statusIndex = 3;
                }

                lblIp.Text = getip();
                lblEstado.Text = status;
            }
            catch(Exception ex) {
                string men = ex.Message;

            }
           
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup(check.Checked);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\system32\sc.exe","stop DXM_Web");
            Process.Start(@"C:\Windows\system32\sc.exe","delete DXM_Web");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceController[] services = ServiceController.GetServices();
            try
            {

                for (int x = 0; x < services.Length; x++)
                {
                    if (services[x].ServiceName == "DXM_Web")
                    {
                        services[x].Start();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
