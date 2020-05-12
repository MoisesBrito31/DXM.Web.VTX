#pragma checksum "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ca5c0c3defbda3617f302f7f1b45fdc2931864a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Config_mapIO), @"mvc.1.0.view", @"/Views/Config/mapIO.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Config/mapIO.cshtml", typeof(AspNetCore.Views_Config_mapIO))]
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
#line 1 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\_ViewImports.cshtml"
using DXM.Web.Interface;

#line default
#line hidden
#line 2 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\_ViewImports.cshtml"
using DXM.Web.Interface.Models;

#line default
#line hidden
#line 2 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
using DXM.Protocolo;

#line default
#line hidden
#line 3 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ca5c0c3defbda3617f302f7f1b45fdc2931864a", @"/Views/Config/mapIO.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dbfc5f91b30706872d88ad7a7fe2ce93e5d6979", @"/Views/_ViewImports.cshtml")]
    public class Views_Config_mapIO : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DXM.Protocolo.Mapa>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
  
    ViewData["Title"] = "mapIO";

#line default
#line hidden
            BeginContext(119, 1110, true);
            WriteLiteral(@"   

<style>
    input {
        max-width: 100px;
        max-height:30px;
        min-width:60px;
    }
    label{
        margin-right:5px;
    }
</style>

<div class=""card-title mt-5 mb-5"">
    <div class=""row mb-5"">
        <div class=""col text-left"">
            <h2>Configuração do Mapa I/O</h2>
        </div>
        <div class=""col text-right btn-group"">
            <button type=""button"" class=""btn btn-primary"" onclick=""document.location.href='/config/index'"">Rede</button>
            <button type=""button"" class=""btn btn-primary "" onclick=""document.location.href='/config/turno'"">Turno</button>
            <button type=""button"" class=""btn btn-primary disabled"" onclick=""document.location.href='/config/mapIo'"">Mapa I/O</button>
            <button type=""button"" class=""btn btn-primary"" onclick=""document.location.href='/config/DxmConfig'"">Programar</button>
            <button type=""button"" class=""btn btn-primary  "" onclick=""document.location.href='/config/reset'"">Destravar</button>");
            WriteLiteral("\n        </div>\r\n    </div>\r\n    <hr>\r\n</div>\r\n\r\n\r\n\r\n\r\n<div class=\"container-fluid\">\r\n");
            EndContext();
#line 41 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
     for (int x = 0; x < Model.linhas.Count; x++)
    {

#line default
#line hidden
            BeginContext(1287, 193, true);
            WriteLiteral("    <div class=\"p-2 m-auto\" style=\"max-width:1000px\">\r\n        <table class=\"table\">\r\n                <thead>\r\n                    <tr class=\"bg-dark text-light\">\r\n                        <td> ");
            EndContext();
            BeginContext(1481, 25, false);
#line 47 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                        Write(Model.linhas[x].nomeLinha);

#line default
#line hidden
            EndContext();
            BeginContext(1506, 476, true);
            WriteLiteral(@"</td>
                        <td>Node:</td>
                        <td>Input:</td>
                        <td>ciclo(ms):</td>
                        <td>dword:</td>
                        <td>Usar:</td>
                    </tr>

                </thead>
                <tbody>
                    <tr>
                        <td>
                            <label>Contador de Entrada:</label>
                        </td>
                        <td>
");
            EndContext();
#line 62 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                              
                                int reg1node = Model.linhas[x].regList[0].reg / 16;
                                int reg1In = Model.linhas[x].regList[0].reg % 16;
                            

#line default
#line hidden
            BeginContext(2213, 34, true);
            WriteLiteral("                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2247, "\"", 2265, 2);
#line 66 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 2252, x, 2252, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 2254, "conEntNode", 2255, 11, true);
            EndWriteAttribute();
            BeginContext(2266, 52, true);
            WriteLiteral(" type=\"number\" class=\"form-control\" min=\"1\" max=\"48\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 2318, "", 2334, 1);
#line 66 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 2325, reg1node, 2325, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2334, 100, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2434, "\"", 2451, 2);
#line 69 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 2439, x, 2439, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 2441, "conEntReg", 2442, 10, true);
            EndWriteAttribute();
            BeginContext(2452, 51, true);
            WriteLiteral(" type=\"number\" class=\"form-control\" min=\"1\" max=\"9\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 2503, "", 2517, 1);
#line 69 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 2510, reg1In, 2510, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2517, 100, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2617, "\"", 2636, 2);
#line 72 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 2622, x, 2622, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 2624, "conEntCiclo", 2625, 12, true);
            EndWriteAttribute();
            BeginContext(2637, 35, true);
            WriteLiteral(" type=\"number\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2672, "\"", 2713, 1);
#line 72 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 2680, Model.linhas[x].regList[0].ciclo, 2680, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2714, 66, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 75 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                             if (Model.linhas[x].regList[0].dword)
                            {

#line default
#line hidden
            BeginContext(2879, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2917, "\"", 2933, 2);
#line 77 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 2922, x, 2922, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 2924, "conEntDw", 2925, 9, true);
            EndWriteAttribute();
            BeginContext(2934, 48, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" checked />\r\n");
            EndContext();
#line 78 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(3078, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3116, "\"", 3132, 2);
#line 81 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 3121, x, 3121, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 3123, "conEntDw", 3124, 9, true);
            EndWriteAttribute();
            BeginContext(3133, 40, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" />\r\n");
            EndContext();
#line 82 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }

#line default
#line hidden
            BeginContext(3204, 63, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 86 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                             if (Model.linhas[x].regList[0].ativo)
                            {

#line default
#line hidden
            BeginContext(3366, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3404, "\"", 3420, 2);
#line 88 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 3409, x, 3409, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 3411, "conEntOn", 3412, 9, true);
            EndWriteAttribute();
            BeginContext(3421, 48, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" checked />\r\n");
            EndContext();
#line 89 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(3565, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3603, "\"", 3619, 2);
#line 92 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 3608, x, 3608, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 3610, "conEntOn", 3611, 9, true);
            EndWriteAttribute();
            BeginContext(3620, 40, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" />\r\n");
            EndContext();
#line 93 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }

#line default
#line hidden
            BeginContext(3691, 240, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            <label>Contador de Saída:</label>\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 102 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                              
                                int reg2node = Model.linhas[x].regList[1].reg / 16;
                                int reg2In = Model.linhas[x].regList[1].reg % 16;
                            

#line default
#line hidden
            BeginContext(4162, 34, true);
            WriteLiteral("                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4196, "\"", 4214, 2);
#line 106 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 4201, x, 4201, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 4203, "conSaiNode", 4204, 11, true);
            EndWriteAttribute();
            BeginContext(4215, 52, true);
            WriteLiteral(" type=\"number\" class=\"form-control\" min=\"1\" max=\"48\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 4267, "", 4283, 1);
#line 106 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 4274, reg2node, 4274, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4283, 100, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4383, "\"", 4400, 2);
#line 109 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 4388, x, 4388, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 4390, "conSaiReg", 4391, 10, true);
            EndWriteAttribute();
            BeginContext(4401, 51, true);
            WriteLiteral(" type=\"number\" class=\"form-control\" min=\"1\" max=\"9\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 4452, "", 4466, 1);
#line 109 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 4459, reg2In, 4459, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4466, 100, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4566, "\"", 4585, 2);
#line 112 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 4571, x, 4571, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 4573, "conSaiCiclo", 4574, 12, true);
            EndWriteAttribute();
            BeginContext(4586, 35, true);
            WriteLiteral(" type=\"number\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 4621, "\"", 4662, 1);
#line 112 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 4629, Model.linhas[x].regList[1].ciclo, 4629, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4663, 66, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 115 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                             if (Model.linhas[x].regList[1].dword)
                            {

#line default
#line hidden
            BeginContext(4828, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4866, "\"", 4882, 2);
#line 117 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 4871, x, 4871, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 4873, "conSaiDw", 4874, 9, true);
            EndWriteAttribute();
            BeginContext(4883, 48, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" checked />\r\n");
            EndContext();
#line 118 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(5027, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 5065, "\"", 5081, 2);
#line 121 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 5070, x, 5070, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 5072, "conSaiDw", 5073, 9, true);
            EndWriteAttribute();
            BeginContext(5082, 40, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" />\r\n");
            EndContext();
#line 122 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }

#line default
#line hidden
            BeginContext(5153, 61, true);
            WriteLiteral("                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 125 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                             if (Model.linhas[x].regList[1].ativo)
                            {

#line default
#line hidden
            BeginContext(5313, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 5351, "\"", 5367, 2);
#line 127 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 5356, x, 5356, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 5358, "conSaiOn", 5359, 9, true);
            EndWriteAttribute();
            BeginContext(5368, 48, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" checked />\r\n");
            EndContext();
#line 128 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(5512, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 5550, "\"", 5566, 2);
#line 131 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 5555, x, 5555, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 5557, "conSaiOn", 5558, 9, true);
            EndWriteAttribute();
            BeginContext(5567, 40, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" />\r\n");
            EndContext();
#line 132 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }

#line default
#line hidden
            BeginContext(5638, 235, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            <label>Máquina Parada:</label>\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 140 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                              
                                int reg3node = Model.linhas[x].regList[2].reg / 16;
                                int reg3In = Model.linhas[x].regList[2].reg % 16;
                            

#line default
#line hidden
            BeginContext(6104, 34, true);
            WriteLiteral("                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 6138, "\"", 6153, 2);
#line 144 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 6143, x, 6143, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 6145, "stsNode", 6146, 8, true);
            EndWriteAttribute();
            BeginContext(6154, 52, true);
            WriteLiteral(" type=\"number\" class=\"form-control\" min=\"1\" max=\"48\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 6206, "", 6222, 1);
#line 144 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 6213, reg3node, 6213, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6222, 100, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 6322, "\"", 6336, 2);
#line 147 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 6327, x, 6327, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 6329, "stsReg", 6330, 7, true);
            EndWriteAttribute();
            BeginContext(6337, 51, true);
            WriteLiteral(" type=\"number\" class=\"form-control\" min=\"1\" max=\"9\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 6388, "", 6402, 1);
#line 147 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 6395, reg3In, 6395, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6402, 100, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                            <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 6502, "\"", 6518, 2);
#line 150 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 6507, x, 6507, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 6509, "stsCiclo", 6510, 9, true);
            EndWriteAttribute();
            BeginContext(6519, 35, true);
            WriteLiteral(" type=\"number\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 6554, "\"", 6595, 1);
#line 150 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 6562, Model.linhas[x].regList[2].ciclo, 6562, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6596, 127, true);
            WriteLiteral(" />\r\n                        </td>\r\n                        <td>\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 155 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                             if (Model.linhas[x].regList[2].ativo)
                            {

#line default
#line hidden
            BeginContext(6822, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 6860, "\"", 6873, 2);
#line 157 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 6865, x, 6865, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 6867, "stsOn", 6868, 6, true);
            EndWriteAttribute();
            BeginContext(6874, 48, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" checked />\r\n");
            EndContext();
#line 158 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(7018, 38, true);
            WriteLiteral("                                <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 7056, "\"", 7069, 2);
#line 161 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
WriteAttributeValue("", 7061, x, 7061, 2, false);

#line default
#line hidden
            WriteAttributeValue(" ", 7063, "stsOn", 7064, 6, true);
            EndWriteAttribute();
            BeginContext(7070, 40, true);
            WriteLiteral(" type=\"checkbox\" class=\"form-check\" />\r\n");
            EndContext();
#line 162 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
                            }

#line default
#line hidden
            BeginContext(7141, 118, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n    </div>\r\n");
            EndContext();
#line 168 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
    }

#line default
#line hidden
            BeginContext(7266, 265, true);
            WriteLiteral(@"    <div class=""p-2 m-auto"">
        <div class=""m-auto"" style=""max-width:100px"">
            <button type=""button"" class=""btn btn-block btn-success"" onclick=""enviar()"" >Salvar</button>
        </div>
    </div>
</div>

<script type=""text/javascript"">
   
");
            EndContext();
#line 178 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
         


          string json = JsonConvert.SerializeObject(Model);
          string temp = "";
          /*
          for (int x=0; x < json.Length; x++)
          {
              if (json.Substring(x, 1).Contains('"')) {temp = string.Format("{0}{1}",temp,'*'); }
              else { temp = string.Format("{0}{1}",temp,json.Substring(x, 1)); }
          }
          json = temp;
          */
         
          

#line default
#line hidden
            BeginContext(7966, 21, true);
            WriteLiteral("\r\n        var data = ");
            EndContext();
            BeginContext(7988, 14, false);
#line 194 "C:\Users\User\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\Config\mapIO.cshtml"
              Write(Html.Raw(json));

#line default
#line hidden
            EndContext();
            BeginContext(8002, 2399, true);
            WriteLiteral(@"      

    function enviar() {

        for (var x = 0; x < data.qndLinhas; x++) {
            data.linhas[x].regList[0].reg =(document.getElementById(`${x} conEntReg`).value*1) + document.getElementById(`${x} conEntNode`).value * 16           
            data.linhas[x].regList[0].ciclo = document.getElementById(`${x} conEntCiclo`).value           
            if (document.getElementById(`${x} conEntDw`).checked) { data.linhas[x].regList[0].dword = true }
            else { data.linhas[x].regList[0].dword = false }
            if (document.getElementById(`${x} conEntOn`).checked) { data.linhas[x].regList[0].ativo = true }
            else { data.linhas[x].regList[0].ativo = false }

             data.linhas[x].regList[1].reg =(document.getElementById(`${x} conSaiReg`).value*1) + document.getElementById(`${x} conSaiNode`).value * 16
            data.linhas[x].regList[1].ciclo = document.getElementById(`${x} conSaiCiclo`).value
            if (document.getElementById(`${x} conSaiDw`).checked) { ");
            WriteLiteral(@"data.linhas[0].regList[1].dword = true }
            else { data.linhas[x].regList[1].dword = false }
            if (document.getElementById(`${x} conSaiOn`).checked) { data.linhas[x].regList[1].ativo = true }
            else { data.linhas[x].regList[1].ativo = false }
            
             data.linhas[x].regList[2].reg =(document.getElementById(`${x} stsReg`).value*1) + document.getElementById(`${x} stsNode`).value * 16
            data.linhas[x].regList[2].ciclo = document.getElementById(`${x} stsCiclo`).value
            if (document.getElementById(`${x} stsOn`).checked) { data.linhas[x].regList[2].ativo = true }
            else { data.linhas[x].regList[2].ativo = false }

        }

        //alert(JSON.stringify(data));

          var xhp = new XMLHttpRequest()
        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var re = this.responseText
                //alert(re);
                if (re == ""ok"") {
   ");
            WriteLiteral(@"                 toastr.success(""Sucesso"",""Dados Armazenados"")
                }
                else {
                    toastr.error(""erro"",""Falha ao gravar em disco"")                   
                }
            }
        }
        xhp.open(""POST"", ""/Config/setXml?json=""+JSON.stringify(data));
        xhp.send();
    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DXM.Protocolo.Mapa> Html { get; private set; }
    }
}
#pragma warning restore 1591
