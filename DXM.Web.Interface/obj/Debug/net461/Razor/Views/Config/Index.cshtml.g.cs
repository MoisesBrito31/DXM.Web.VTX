#pragma checksum "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38ba231631f590fcf174d141e0f8937bfe548d46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Config_Index), @"mvc.1.0.view", @"/Views/Config/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Config/Index.cshtml", typeof(AspNetCore.Views_Config_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\_ViewImports.cshtml"
using DXM.Web.Interface;

#line default
#line hidden
#line 2 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\_ViewImports.cshtml"
using DXM.Web.Interface.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38ba231631f590fcf174d141e0f8937bfe548d46", @"/Views/Config/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dbfc5f91b30706872d88ad7a7fe2ce93e5d6979", @"/Views/_ViewImports.cshtml")]
    public class Views_Config_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DXM.VTX.VTX>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int log = Model.tickLog / 60;

#line default
#line hidden
            BeginContext(97, 1508, true);
            WriteLiteral(@"
<style>
    input {
        max-width: 220px;
    }

    select {
        max-width: 220px;
    }
</style>

<div class=""card-title mt-5 mb-5"">
    <div class=""row mb-5"">
        <div class=""col text-left"">
            <h2>Configuração do DXM</h2>
        </div>
        <div class=""col text-right  btn-group"">
            <button type=""button"" class=""btn btn-primary disabled"" onclick=""#"">Rede</button>
            <button type=""button"" class=""btn btn-primary "" onclick=""document.location.href='/config/turno'"">Turno</button>
            <button type=""button"" class=""btn btn-primary"" onclick=""document.location.href='/config/mapIO'"">Mapa I/O</button>
            <button type=""button"" class=""btn btn-primary"" onclick=""document.location.href='/config/DxmConfig'"">Programar</button>
            <button type=""button"" class=""btn btn-primary"" onclick=""document.location.href='/config/reset'"">Destravar</button>
            <!--
            <button type=""button"" class=""btn btn-primary"" onclick=""document.");
            WriteLiteral(@"location.href='/config/download?arquivo=sb'"">script Download</button>
            <button type=""button"" class=""btn btn-primary"" onclick=""document.location.href='/config/download?arquivo=xml'"">XML Download</button>
                -->
        </div>
    </div>
    <hr>
</div>




<div class=""container-fluid"">

    <div class=""mb-4 mt-4"">
        <label>DXM Endereço:</label>
        <div class=""form-inline"">
            <input type=""text"" id=""endress"" name=""endress""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1605, "\"", 1631, 1);
#line 45 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
WriteAttributeValue("", 1613, Model.DXM_Endress, 1613, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1632, 198, true);
            WriteLiteral(" class=\"mr-3 form-control\" />\r\n            <button id=\"splint\" class=\"btn btn-primary\" type=\"button\" onclick=\"altIp()\">\r\n                Salvar\r\n            </button>\r\n        </div>\r\n    </div>\r\n\r\n");
            EndContext();
#line 52 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
     if (true)
    {


#line default
#line hidden
            BeginContext(1855, 211, true);
            WriteLiteral("        <div class=\"mb-4  mt-4\">\r\n            <label for=\"linhas\">Motores:</label>\r\n            <div class=\"form-inline\">\r\n                <input type=\"number\" class=\"mr-3 form-control\" name=\"linhas\" id=\"linhas\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2066, "\"", 2091, 1);
#line 58 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
WriteAttributeValue("", 2074, Model.quantidade, 2074, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2092, 159, true);
            WriteLiteral(" />\r\n                <button id=\"splint2\" class=\"btn btn-primary \" onclick=\"linhaAltera()\" type=\"button\">Alterar</button>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
            BeginContext(2253, 231, true);
            WriteLiteral("        <div class=\"mb-4  mt-4\">\r\n            <label for=\"tickLog\">intervalo entre logs(min)</label>\r\n            <div class=\"form-inline\">\r\n                <input type=\"number\" class=\"mr-3 form-control\" name=\"tickLog\" id=\"tickLog\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2484, "\"", 2496, 1);
#line 66 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
WriteAttributeValue("", 2492, log, 2492, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2497, 161, true);
            WriteLiteral(" />\r\n                <button class=\"btn btn-primary \" onclick=\"tickAltera()\" type=\"button\">Alterar</button>\r\n            </div>\r\n        </div>\r\n        <hr />\r\n");
            EndContext();
#line 71 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
        int z = 0;
        if(Model.DXM_Status!="DXM OffLine") { 
        for (int x = 0; x < Model.quantidade; x++)
        {
            z = x + 1;

#line default
#line hidden
            BeginContext(2813, 125, true);
            WriteLiteral("            <div class=\"mb-4 mt-4 form-row\">\r\n                <div class=\"col-auto mt-3\">\r\n                    <p>Nome linha ");
            EndContext();
            BeginContext(2939, 1, false);
#line 78 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
                             Write(z);

#line default
#line hidden
            EndContext();
            BeginContext(2940, 47, true);
            WriteLiteral(" : </p>\r\n                    <input type=\"text\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2987, "\"", 2996, 2);
            WriteAttributeValue("", 2992, "l", 2992, 1, true);
#line 79 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
WriteAttributeValue(" ", 2993, x, 2994, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 2997, "\"", 3008, 2);
            WriteAttributeValue("", 3004, "l", 3004, 1, true);
#line 79 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
WriteAttributeValue(" ", 3005, x, 3006, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 3009, "\"", 3039, 1);
#line 79 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
WriteAttributeValue("", 3017, Model.motores[x].nome, 3017, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3040, 654, true);
            WriteLiteral(@" class=""mr-3 form-control"" />
                </div>
                <div class=""col-auto mt-3"">
                    <p>Alerta de Temperatura:</p>
                    <input />
                </div>
                <div class=""col-auto mt-3"">
                    <p>Alerta Vibração Eixo X:</p>
                  <input />

                </div>
                <div class=""col-auto mt-3"">
                    <p>Alerta Vibração Eixo Z:</p>
                    <input />
                </div>
                <div class=""col-auto mt-3"">
                    <p>ação:</p>
                    <button class=""btn btn-primary"" type=""button""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3694, "\"", 3715, 3);
            WriteAttributeValue("", 3704, "altnome(", 3704, 8, true);
#line 96 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
WriteAttributeValue("", 3712, x, 3712, 2, false);

#line default
#line hidden
            WriteAttributeValue("", 3714, ")", 3714, 1, true);
            EndWriteAttribute();
            BeginContext(3716, 83, true);
            WriteLiteral(">Salvar </button>\r\n                    <button class=\"btn btn-danger\" type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3799, "\"", 3817, 3);
            WriteAttributeValue("", 3809, "zera(", 3809, 5, true);
#line 97 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
WriteAttributeValue("", 3814, x, 3814, 2, false);

#line default
#line hidden
            WriteAttributeValue("", 3816, ")", 3816, 1, true);
            EndWriteAttribute();
            BeginContext(3818, 84, true);
            WriteLiteral(">Aprender</button>\r\n                </div>\r\n            </div>\r\n            <hr />\r\n");
            EndContext();
#line 101 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\Index.cshtml"
        }
            }

    }

#line default
#line hidden
            BeginContext(3937, 4099, true);
            WriteLiteral(@"
</div>



<script>
    var input_h_p_pro = []
</script>



<script>
   
    var editT_p_prog = false



    function altnome(valor) {

        var nome = document.getElementById(`l ${valor}`).value;
        var form = document.getElementById(`${valor} forma`).value;
        var vel = document.getElementById(`${valor} velo_esp`).value;
        var xhp = new XMLHttpRequest()

        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var re = this.responseText
                if (re == ""ok"") {                    
                    toastr.success(""dados armazenados"", ""Sucesso"")
                }
                else {
                    toastr.error(re, ""erro"")
                }
            }
        }
        xhp.open(""Get"", `/Config/setLinhaNome?id=${valor}&valor=${nome}&t_p_p=${input_h_p_pro[valor]}&forma=${form}&vel_esp=${vel}`);
        xhp.send();
    }

    function velAlt(id) {
        document");
            WriteLiteral(@".getElementById(`${id} velo_esp`).value = """"
    }

    function altIp() {
        document.getElementById(""splint"").innerHTML = ""<span class=\""spinner-border spinner-border-sm mr-1\""></span>Alterando..."";

        var ip = document.getElementById(""endress"").value;

        var xhp = new XMLHttpRequest()

        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var re = this.responseText
                setTimeout(document.location.reload(), 10000)
            }
        }
        xhp.open(""Get"", `/Config/setIp?ip=${ip}`);
        xhp.send();
    }

    

    function linhaAltera() {
        document.getElementById(""splint2"").innerHTML = ""<span class=\""spinner-border spinner-border-sm mr-1\""></span>Alterando..."";
        var valor = document.getElementById(""linhas"").value
        var xhp = new XMLHttpRequest()

        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === ");
            WriteLiteral(@"200) {
                var re = this.responseText
                setTimeout(document.location.reload(), 2000)
            }
        }
        xhp.open(""Get"", ""/Config/setLinhas?valor="" + valor);
        xhp.send();
    }

    function tickAltera() {
        var valor = document.getElementById(""tickLog"").value
        var xhp = new XMLHttpRequest()

        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var re = this.responseText
                setTimeout(document.location.reload(), 2000)
            }
        }
        valor = valor * 60
        xhp.open(""Get"", ""/Config/setTickLog?valor="" + valor);
        xhp.send();
    }

    function agendadoChange(id, x) {
        var valor = document.getElementById(id).value
        var temp = """"
        var temph = """"
        var tempm = """"
        if (valor.indexOf("":"") > 0) {

            if (valor.length > 7) {
                temph = `${valor.substr(1, 1)}${val");
            WriteLiteral(@"or.substr(5, 1)}`
                tempm = valor.substr(6, 2)
            }
            else {
                temph = valor.substr(0, 2)
                tempm = valor.substr(6, 2)
            }
            temp = `${temph}${tempm}`
            valor = """"
        }

        if (valor != """") {
            for (var x = valor.length; x < 4; x++) {
                temp = `0${temp}`
            }

            temp = temp + valor



            if (temp.length > 4) {
                temp = temp.substring(temp.length - 4, 5)
            }

            temph = temp.substr(0, 2)
            tempm = temp.substr(2, 2)
        }

        temp = `${temph} : ${tempm}`

        if (temp.length < 7) { temp = """" }
        document.getElementById(id).value = temp
        input_h_p_pro[x] = parseInt(temph) * 60 + parseInt(tempm)
        //alert(input_h_p_pro[x])
    }
    function t_p_progBtnF(id) {
        editT_p_prog = true;
        document.getElementById(id).value = """"
    }

</script");
            WriteLiteral(">\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DXM.VTX.VTX> Html { get; private set; }
    }
}
#pragma warning restore 1591
