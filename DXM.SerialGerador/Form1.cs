using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXM.SerialGerador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            date.MinDate = DateTime.Now;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (cbxPeramanente.Checked)
            {
                txtSerial.Text = crypt.Encriptar(txtChave.Text, txtVetor.Text, "indeterminado");
            }
            else
            {
                txtSerial.Text = crypt.Encriptar(txtChave.Text, txtVetor.Text,date.Value.ToShortDateString());
                
            }
        }
    }
}
