#pragma checksum "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "418ddda4b8e581123348eabbdfaf56a19c48724b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_vt_historico), @"mvc.1.0.view", @"/Views/vt/historico.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/vt/historico.cshtml", typeof(AspNetCore.Views_vt_historico))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"418ddda4b8e581123348eabbdfaf56a19c48724b", @"/Views/vt/historico.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dbfc5f91b30706872d88ad7a7fe2ce93e5d6979", @"/Views/_ViewImports.cshtml")]
    public class Views_vt_historico : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DXM.VTX.Motor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/moment.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Chart.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Chart.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/chart.util.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
  
    ViewData["Title"] = "historico";

    string i_m = Model.filtro_Ini.Month.ToString();
    string i_d = Model.filtro_Ini.Day.ToString();
    string i_h = Model.filtro_Ini.Hour.ToString();
    string i_min = Model.filtro_Ini.Minute.ToString();
    if (i_m.Length < 2) { i_m = "0" + i_m; }
    if (i_d.Length < 2) { i_d = "0" + i_d; }
    if (i_h.Length < 2) { i_h = "0" + i_h; }
    if (i_min.Length < 2) { i_min = "0" + i_min; }
    string dataIni = string.Format("{0}-{1}-{2}T{3}:{4}", Model.filtro_Ini.Year, i_m, i_d, i_h, i_min);

    string f_m = Model.filtro_fim.Month.ToString();
    string f_d = Model.filtro_fim.Day.ToString();
    string f_h = Model.filtro_fim.Hour.ToString();
    string f_min = Model.filtro_fim.Minute.ToString();
    if (f_m.Length < 2) { f_m = "0" + f_m; }
    if (f_d.Length < 2) { f_d = "0" + f_d; }
    if (f_h.Length < 2) { f_h = "0" + f_h; }
    if (f_min.Length < 2) { f_min = "0" + f_min; }

    string dataFim = string.Format("{0}-{1}-{2}T{3}:{4}", Model.filtro_fim.Year, f_m, f_d, f_h, f_min);


#line default
#line hidden
            BeginContext(1089, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1091, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f66bec9f2784204b509634d534deec1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1129, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1131, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c198ae1b647417e893f4596146d2eeb", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1172, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1174, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58c7c6ff3ff245a9adf68d1b1ab1976b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1211, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1213, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4dd0fbe81b054421a540f7229bbdfa5a", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1255, 104, true);
            WriteLiteral("\r\n\r\n\r\n<div class=\"card-title mt-5 mb-5\">\r\n    <div class=\"row\">\r\n        <div class=\"col text-left\"><h2>");
            EndContext();
            BeginContext(1360, 10, false);
#line 36 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                                  Write(Model.nome);

#line default
#line hidden
            EndContext();
            BeginContext(1370, 475, true);
            WriteLiteral(@" - Histórico</h2></div>

        <div class=""col text-right"">
            <div class=""btn-group"">
                <button type=""button"" class=""btn btn-primary"" onclick=""window.location.href='/vt/index'"">Fábrica</button>
               
                <button type=""button"" class=""btn btn-primary disabled"">Histórico</button>
                <!--<button type=""button"" class=""btn btn-danger"">Zerar</button>-->
            </div>
        </div>
    </div>

</div>
");
            EndContext();
            BeginContext(1845, 594, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52adab9ef65e4179b6863521d166ef2b", async() => {
                BeginContext(1904, 176, true);
                WriteLiteral("\r\n    <div class=\"m-auto mt-5 form-inline form-group\">\r\n        <label>data inicial:</label>\r\n        <input type=\"datetime-local\" class=\"form-control mr-3\" name=\"ini\" id=\"ini\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2080, "\"", 2096, 1);
#line 52 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
WriteAttributeValue("", 2088, dataIni, 2088, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2097, 123, true);
                WriteLiteral(" />\r\n        <label>data final:</label>\r\n        <input type=\"datetime-local\" class=\"form-control mr-3\" name=\"fim\" id=\"fim\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2220, "\"", 2236, 1);
#line 54 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
WriteAttributeValue("", 2228, dataFim, 2228, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2237, 195, true);
                WriteLiteral(" />\r\n        <button type=\"submit\" class=\"btn btn-primary mr-3\">Aplicar</button>\r\n        <button type=\"button\" class=\"btn btn-primary\" onclick=\"gerarRelatorio()\">Relatório</button>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1873, "/vt/historicoFiltro/", 1873, 20, true);
#line 49 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
AddHtmlAttributeValue("", 1893, Model.id, 1893, 9, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2439, 48, true);
            WriteLiteral("\r\n<hr>\r\n<div class=\"container-fluid m-auto\">\r\n\r\n");
            EndContext();
#line 62 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
     if (ViewBag.registrado)
    {

#line default
#line hidden
            BeginContext(2524, 108, true);
            WriteLiteral("        <div class=\"m-auto\" style=\"width:80%;\">\r\n            <canvas id=\"canvas\"></canvas>\r\n        </div>\r\n");
            EndContext();
#line 67 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
    }

#line default
#line hidden
            BeginContext(2639, 527, true);
            WriteLiteral(@"    <hr />
    <div>
        <table class=""table"">
            <thead class=""thead-dark"">
                <tr class=""text-center m-auto"">
                    <th>Hora</th>
                    <th>Eixo X</th>
                    <th>Alerta Eixo X</th>
                    <th>Eixo Z</th>
                    <th>Alerta Eixo Z</th>
                    <th>Temperatura</th>
                    <th>Alerta Temp</th>
                    <th>Estado</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 84 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                 for (int x = 0; x < Model.histFiltro.Count; x++)
                {

#line default
#line hidden
            BeginContext(3252, 91, true);
            WriteLiteral("                <tr class=\"text-center m-auto\">\r\n                    <th class=\"text-left\">");
            EndContext();
            BeginContext(3344, 35, false);
#line 87 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                                     Write(Model.histFiltro[x].time.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(3379, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(3411, 58, false);
#line 88 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                   Write(string.Format("{0} mm/s", Model.histFiltro[x].V_Rms_Vel_X));

#line default
#line hidden
            EndContext();
            BeginContext(3469, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(3501, 64, false);
#line 89 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                   Write(string.Format("{0} mm/s", Model.histFiltro[x].alert_v_Rms_Vel_X));

#line default
#line hidden
            EndContext();
            BeginContext(3565, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(3597, 58, false);
#line 90 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                   Write(string.Format("{0} mm/s", Model.histFiltro[x].V_Rms_Vel_Z));

#line default
#line hidden
            EndContext();
            BeginContext(3655, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(3687, 64, false);
#line 91 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                   Write(string.Format("{0} mm/s", Model.histFiltro[x].alert_v_Rms_Vel_Z));

#line default
#line hidden
            EndContext();
            BeginContext(3751, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(3783, 56, false);
#line 92 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                   Write(string.Format("{0} °C", Model.histFiltro[x].temperatura));

#line default
#line hidden
            EndContext();
            BeginContext(3839, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(3871, 56, false);
#line 93 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                   Write(string.Format("{0} °C", Model.histFiltro[x].alert_tempe));

#line default
#line hidden
            EndContext();
            BeginContext(3927, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(3959, 48, false);
#line 94 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                   Write(string.Format("{0}", Model.histFiltro[x].Estado));

#line default
#line hidden
            EndContext();
            BeginContext(4007, 30, true);
            WriteLiteral("</th>\r\n                </tr>\r\n");
            EndContext();
#line 96 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                }

#line default
#line hidden
            BeginContext(4056, 287, true);
            WriteLiteral(@"                <tr class=""text-center m-auto""><th>--</th><th>--</th><th>--</th><th>--</th><th>--</th><th>--</th><th>--</th><th>--</th></tr>
            </tbody>
        </table>
    </div>
</div>

<script>
		var config = {
			type: 'line',
			data: {
                labels: [");
            EndContext();
            BeginContext(4344, 34, false);
#line 107 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                    Write(Html.Raw(Model.get_log_time(true)));

#line default
#line hidden
            EndContext();
            BeginContext(4378, 169, true);
            WriteLiteral("],\r\n\t\t\t\tdatasets: [{\r\n                    label: \'Eixo X (mm/s)\',\r\n\t\t\t\t\tbackgroundColor: window.chartColors.red,\r\n\t\t\t\t\tborderColor: window.chartColors.red,\r\n\t\t\t\t\tdata: [");
            EndContext();
            BeginContext(4548, 22, false);
#line 112 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                      Write(Model.get_log_vx(true));

#line default
#line hidden
            EndContext();
            BeginContext(4570, 203, true);
            WriteLiteral("],\r\n\t\t\t\t\tfill: false,\r\n\t\t\t\t}, {\r\n                    label: \'Alerta X (mm/s)\',\r\n\t\t\t\t\tfill: false,\r\n\t\t\t\t\tbackgroundColor: window.chartColors.blue,\r\n\t\t\t\t\tborderColor: window.chartColors.blue,\r\n\t\t\t\t\tdata: [");
            EndContext();
            BeginContext(4774, 24, false);
#line 119 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                      Write(Model.get_log_a_vx(true));

#line default
#line hidden
            EndContext();
            BeginContext(4798, 265, true);
            WriteLiteral(@"],
                 },{
                    label: 'Eixo Z (mm/s)',
                     fill: false,
                     backgroundColor: window.chartColors.yellow,
                     borderColor: window.chartColors.yellow,
                        data: [");
            EndContext();
            BeginContext(5064, 22, false);
#line 125 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                          Write(Model.get_log_vz(true));

#line default
#line hidden
            EndContext();
            BeginContext(5086, 270, true);
            WriteLiteral(@"],
                      },{
                    label: 'Alerta Z (mm/s)',
                     fill: false,
                     backgroundColor: window.chartColors.green,
                     borderColor: window.chartColors.green,
                        data: [");
            EndContext();
            BeginContext(5357, 24, false);
#line 131 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                          Write(Model.get_log_a_vz(true));

#line default
#line hidden
            EndContext();
            BeginContext(5381, 257, true);
            WriteLiteral(@"],
                      },{
                    label: 'Temperatura(C)',
                     fill: false,
                     backgroundColor: ""rgb(128,255,128)"",
                     borderColor: ""rgb(128,255,128)"",
                        data: [");
            EndContext();
            BeginContext(5639, 24, false);
#line 137 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                          Write(Model.get_log_temp(true));

#line default
#line hidden
            EndContext();
            BeginContext(5663, 269, true);
            WriteLiteral(@"],
                      },{
                      label: 'Alerta Temp(C)',
                     fill: false,
                     backgroundColor: window.chartColors.grey,
                     borderColor: window.chartColors.grey,
                        data: [");
            EndContext();
            BeginContext(5933, 26, false);
#line 143 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                          Write(Model.get_log_a_temp(true));

#line default
#line hidden
            EndContext();
            BeginContext(5959, 1034, true);
            WriteLiteral(@"]                     
                 }]
			},
			options: {
				responsive: true,
				title: {
					display: true,
					text: 'Linha do Tempo'
				},
				tooltips: {
					mode: 'index',
					intersect: false,
				},
				hover: {
					mode: 'nearest',
					intersect: true
				},
				scales: {
					xAxes: [{
						display: true,
						scaleLabel: {
							display: true,
							labelString: 'Data'
						}
					}],
					yAxes: [{
						display: true,
						scaleLabel: {
							display: true,
							labelString: 'Valor'
						}
					}]
				}
			}
		};

		window.onload = function() {
			var ctx = document.getElementById('canvas').getContext('2d');
			window.myLine = new Chart(ctx, config);
		};



        var colorNames = Object.keys(window.chartColors);
    function gerarRelatorio() {
        var ini = document.getElementById(""ini"").value
        var fim = document.getElementById(""fim"").value
        var xhp = new XMLHttpRequest()
        var endres = ""/vt/relator");
            WriteLiteral("io?id=\" + ");
            EndContext();
            BeginContext(6994, 8, false);
#line 191 "C:\Users\Moises Brito\Documents\GitHub\DXM.Web.VTX\DXM.Web.Interface\Views\vt\historico.cshtml"
                                      Write(Model.id);

#line default
#line hidden
            EndContext();
            BeginContext(7002, 92, true);
            WriteLiteral(" + \"&ini=\" + ini + \"&fim=\" +fim\r\n        document.location.href=endres\r\n    }\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DXM.VTX.Motor> Html { get; private set; }
    }
}
#pragma warning restore 1591
