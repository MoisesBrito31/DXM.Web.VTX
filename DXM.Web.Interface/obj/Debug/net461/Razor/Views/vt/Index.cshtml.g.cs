#pragma checksum "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0c4190fb67bb94a1f11bc1301b2472e9120e424"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_vt_Index), @"mvc.1.0.view", @"/Views/vt/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/vt/Index.cshtml", typeof(AspNetCore.Views_vt_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0c4190fb67bb94a1f11bc1301b2472e9120e424", @"/Views/vt/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dbfc5f91b30706872d88ad7a7fe2ce93e5d6979", @"/Views/_ViewImports.cshtml")]
    public class Views_vt_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DXM.VTX.VTX>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(62, 298, true);
            WriteLiteral(@"
<style>
    p {
        max-width: 200px;
    }
</style>

<div class=""card-title mt-5 mb-5"">
    <div class=""row"">
        <div class=""col text-left"">
            <h2>Fábrica Visão Geral</h2>
        </div>


    </div>
</div>



<hr>
<div class=""container-fluid row m-auto"">
");
            EndContext();
#line 26 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
     for (int x = 0; x < Model.motores.Count; x++)
    {

#line default
#line hidden
            BeginContext(419, 48, true);
            WriteLiteral("        <div class=\"col-auto\">\r\n            <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 467, "\"", 476, 2);
            WriteAttributeValue("", 472, "b", 472, 1, true);
#line 29 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue(" ", 473, x, 474, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(477, 95, true);
            WriteLiteral(" class=\"bg-light text-center border rounded mb-5 p-2\" style=\"min-width:250px; max-width:300px;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 572, "\"", 623, 3);
            WriteAttributeValue("", 582, "document.location.href=\'/vt/historico/", 582, 38, true);
#line 29 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue("", 620, x, 620, 2, false);

#line default
#line hidden
            WriteAttributeValue("", 622, "\'", 622, 1, true);
            EndWriteAttribute();
            BeginContext(624, 22, true);
            WriteLiteral(">\r\n                <h3");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 646, "\"", 655, 2);
            WriteAttributeValue("", 651, "l", 651, 1, true);
#line 30 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue(" ", 652, x, 653, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(656, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(658, 21, false);
#line 30 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
                         Write(Model.motores[x].nome);

#line default
#line hidden
            EndContext();
            BeginContext(679, 40, true);
            WriteLiteral("</h3>\r\n                <img class=\"mb-2\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 719, "\"", 732, 2);
#line 31 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue("", 724, x, 724, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 726, "image", 727, 6, true);
            EndWriteAttribute();
            BeginContext(733, 81, true);
            WriteLiteral(" src=\"/images/motorPreto.png\" width=\"150\" height=\"150\" />\r\n                <h4><p");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 814, "\"", 823, 2);
            WriteAttributeValue("", 819, "p", 819, 1, true);
#line 32 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue(" ", 820, x, 821, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(824, 60, true);
            WriteLiteral(" class=\"p-2 rounded border border-dark text-center m-auto\"> ");
            EndContext();
            BeginContext(885, 23, false);
#line 32 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
                                                                                       Write(Model.motores[x].Estado);

#line default
#line hidden
            EndContext();
            BeginContext(908, 171, true);
            WriteLiteral("</p>    </h4>\r\n                <div class=\"form-inline p-2 m-auto\">\r\n                    <label>Eixo X:</label>\r\n                    <input type=\"text\" readonly=\"readonly\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1079, "\"", 1089, 2);
#line 35 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue("", 1084, x, 1084, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1086, "vx", 1087, 3, true);
            EndWriteAttribute();
            BeginContext(1090, 61, true);
            WriteLiteral(" class=\"form-control text-right ml-3\" style=\"max-width:150px\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1151, "\"", 1193, 2);
#line 35 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue("", 1159, Model.motores[x].V_Rms_Vel_X, 1159, 29, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1188, "mm/s", 1189, 5, true);
            EndWriteAttribute();
            BeginContext(1194, 185, true);
            WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-inline p-2 m-auto\">\r\n                    <label>Eixo Z:</label>\r\n                    <input type=\"text\" readonly=\"readonly\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1379, "\"", 1389, 2);
#line 39 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue("", 1384, x, 1384, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1386, "vz", 1387, 3, true);
            EndWriteAttribute();
            BeginContext(1390, 61, true);
            WriteLiteral(" class=\"form-control text-right ml-3\" style=\"max-width:150px\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1451, "\"", 1493, 2);
#line 39 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue("", 1459, Model.motores[x].V_Rms_Vel_Z, 1459, 29, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1488, "mm/s", 1489, 5, true);
            EndWriteAttribute();
            BeginContext(1494, 187, true);
            WriteLiteral(" />\r\n                </div>\r\n                <div class=\"form-inline p-2 m-auto\">\r\n                    <label>Temp:    </label>\r\n                    <input type=\"text\" readonly=\"readonly\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1681, "\"", 1693, 2);
#line 43 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue("", 1686, x, 1686, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1688, "temp", 1689, 5, true);
            EndWriteAttribute();
            BeginContext(1694, 61, true);
            WriteLiteral(" class=\"form-control text-right ml-3\" style=\"max-width:150px\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1755, "\"", 1795, 2);
#line 43 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
WriteAttributeValue("", 1763, Model.motores[x].Temperatura, 1763, 29, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1792, "°C", 1793, 3, true);
            EndWriteAttribute();
            BeginContext(1796, 65, true);
            WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 47 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1868, 2211, true);
            WriteLiteral(@"



</div>

<script type=""text/javascript"">
    setInterval(function () {
        getmotores()
    }, 1000)

    function getmotores() {
        var xhp = new XMLHttpRequest()
        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var re = this.responseText
                data = JSON.parse(re);
                if (data.dxm == ""DXM OffLine"") {
                    document.location.href = ""/vt/offline"";
                }
                else {                    
                    for (x = 0; x < data.motores.length; x++) {
                         document.getElementById(`p ${x}`).innerHTML = data.motores[x].estado
                        switch (data.motores[x].estado) {
                            case ""OK"":
                                document.getElementById(`${x} image`).src = ""/images/motorOk.png""
                                break;
                             case ""Falha"":
                      ");
            WriteLiteral(@"          document.getElementById(`${x} image`).src = ""/images/motorFalha.png""
                                break;
                            case ""Alerta"":
                                document.getElementById(`${x} image`).src = ""/images/motorAlerta.png""
                                break;
                             case ""Aprendendo"":
                                document.getElementById(`${x} image`).src = ""/images/motorLearn.png""
                                break;
                             case ""OffLine"":
                                document.getElementById(`${x} image`).src = ""/images/motorOffLine.png""
                                break;
                            
                        }
                        document.getElementById(`${x} vx`).value = data.motores[x].vx + "" mm/s""
                        document.getElementById(`${x} vz`).value = data.motores[x].vz + "" mm/s""
                        document.getElementById(`${x} temp`).value = data.motores[x].");
            WriteLiteral("temp+\" °C\"\r\n                    }\r\n                }\r\n\r\n            }\r\n        }\r\n        xhp.open(\"Get\", \"/vt/getDados\");\r\n        xhp.send();\r\n    }\r\n</script>\r\n");
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
