#pragma checksum "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\licenca\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af3ddd5a47d00078dd9ad3f0ea925a21a88ddc5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_licenca_Index), @"mvc.1.0.view", @"/Views/licenca/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/licenca/Index.cshtml", typeof(AspNetCore.Views_licenca_Index))]
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
#line 1 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\_ViewImports.cshtml"
using DXM.Web.Interface;

#line default
#line hidden
#line 2 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\_ViewImports.cshtml"
using DXM.Web.Interface.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af3ddd5a47d00078dd9ad3f0ea925a21a88ddc5d", @"/Views/licenca/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dbfc5f91b30706872d88ad7a7fe2ce93e5d6979", @"/Views/_ViewImports.cshtml")]
    public class Views_licenca_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/licenca/registrar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo e-service rio.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\licenca\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(43, 272, true);
            WriteLiteral(@"

<div class=""card-title mt-5 mb-5"">
    <div class=""row mb-5"">
        <div class=""col text-left"">
            <h2>Registre sua Cópia de Software</h2>
        </div>
    </div>
</div>
<hr>

<div class="" m-auto "" style=""max-width:500px; min-height:180px"">
    ");
            EndContext();
            BeginContext(315, 891, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7030c105f2b249699edf798b60cdb3f4", async() => {
                BeginContext(363, 119, true);
                WriteLiteral("\r\n        <div class=\"form-group mt-5\">\r\n            <label for=\"user\">Proprietário do Registro:</label>\r\n           \r\n");
                EndContext();
#line 21 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\licenca\Index.cshtml"
             if (ViewBag.user == "indefinido")
            {

#line default
#line hidden
                BeginContext(545, 106, true);
                WriteLiteral("                <input type=\"text\" name=\"user\" id=\"user\" class=\"form-control mb-2\" onkeyup=\"valida()\" />\r\n");
                EndContext();
#line 24 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\licenca\Index.cshtml"
            }
            else
            {


#line default
#line hidden
                BeginContext(701, 101, true);
                WriteLiteral("                <input type=\"text\" name=\"user\" id=\"user\" class=\"form-control mb-2\" onkeyup=\"valida()\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 802, "\"", 823, 1);
#line 28 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\licenca\Index.cshtml"
WriteAttributeValue("", 810, ViewBag.user, 810, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(824, 5, true);
                WriteLiteral(" />\r\n");
                EndContext();
#line 29 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\licenca\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(844, 355, true);
                WriteLiteral(@"
        </div>
        <div class=""form-group mt-5"">
            <label for=""serial"">Número de registro:</label>
            <input type=""text"" name=""serial"" id=""serial"" class=""form-control mb-2"" onkeyup=""valida()""/>
        </div>
        <button class=""btn btn-success"" type=""submit"" id=""btnReg"" style=""visibility:hidden"">registrar</button>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1206, 236, true);
            WriteLiteral("\r\n</div>\r\n\r\n<hr />\r\n<div class=\"card-title text-center mb-4 mt-4\"><h3></h3></div>\r\n<div>\r\n    <div class=\"row\">\r\n        <div class=\"col text-right mt-auto mb-auto\">\r\n            <a href=\"http://www.e-servicerio.com.br\" target=\"_blank\">");
            EndContext();
            BeginContext(1442, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "63c404f53e7d4fb6b22963893da7fb3a", async() => {
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
            BeginContext(1487, 407, true);
            WriteLiteral(@"</a>
        </div>
        <div class=""col"">
            <p><strong>Contatos:</strong></p>
            <p><a href=""http://www.e-servicerio.com.br"" target=""_blank"">www.e-servicerio.com.br</a></p>
            <p>comercial@e-servicerio.com.br</p>
            <p> Tels.: (21) 3435-0514 / 2179-9388 / 2179-9386 / 96888-2187</p>
        </div>
    </div>
</div>

<script>
    var cespecial = /(\!|\#|");
            EndContext();
            BeginContext(1895, 677, true);
            WriteLiteral(@"@|\$|\%|\¨|\&|\*| \_ | \-| \+|\=|\<|\>|\:|\;|\,|\.|\?)/
        
    var cminus = /[a-z]/

    function valida() {
        var s = document.getElementById(""serial"").value
        var nome = document.getElementById(""user"").value
        //alert(""S: ""+s+""NOME: ""+nome)
        if (!cespecial.test(s) && !cminus.test(s) && nome.length > 0 && s.length === 32) {
            //alert(s.length=32 + "" "" + nome.length>0)
            document.getElementById(""btnReg"").setAttribute(""style"", ""visibility:visible"")
        }
        else {
            document.getElementById(""btnReg"").setAttribute(""style"", ""visibility:hidden"")
        }
       
        
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
