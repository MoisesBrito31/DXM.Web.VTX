#pragma checksum "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d92e3a5ebb55afd6d3fd154a7caa5670a8f93937"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_oee_Index), @"mvc.1.0.view", @"/Views/oee/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/oee/Index.cshtml", typeof(AspNetCore.Views_oee_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d92e3a5ebb55afd6d3fd154a7caa5670a8f93937", @"/Views/oee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dbfc5f91b30706872d88ad7a7fe2ce93e5d6979", @"/Views/_ViewImports.cshtml")]
    public class Views_oee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DXM.OEE.OEE>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(21, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
  
    ViewData["Title"] = "OEE";

#line default
#line hidden
            BeginContext(62, 221, true);
            WriteLiteral("\r\n<div class=\"card-title mt-5 mb-5\">\r\n    <div class=\"row\">\r\n    <div class=\"col text-left\"> \r\n        <h2>Fábrica Visão Geral</h2>  \r\n    </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n<hr>\r\n<div class=\"container-fluid row m-auto\">\r\n");
            EndContext();
#line 19 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
     for (int x = 0; x < Model.Linhas.Count; x++)
    {

#line default
#line hidden
            BeginContext(341, 139, true);
            WriteLiteral("        <div class=\"col-auto\">\r\n            <div class=\"bg-light text-center border rounded mb-5\" style=\"min-width:250px; max-width:300px;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 480, "\"", 528, 3);
            WriteAttributeValue("", 490, "document.location.href=\'/oee/linha/", 490, 35, true);
#line 22 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
WriteAttributeValue("", 525, x, 525, 2, false);

#line default
#line hidden
            WriteAttributeValue("", 527, "\'", 527, 1, true);
            EndWriteAttribute();
            BeginContext(529, 22, true);
            WriteLiteral(">\r\n                <h3");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 551, "\"", 560, 2);
            WriteAttributeValue("", 556, "l", 556, 1, true);
#line 23 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
WriteAttributeValue(" ", 557, x, 558, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(561, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(563, 20, false);
#line 23 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
                         Write(Model.Linhas[x].nome);

#line default
#line hidden
            EndContext();
            BeginContext(583, 27, true);
            WriteLiteral("</h3>\r\n                <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 610, "\"", 617, 1);
#line 24 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
WriteAttributeValue("", 615, x, 615, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(618, 27, true);
            WriteLiteral("></div>\r\n                <p");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 645, "\"", 654, 2);
            WriteAttributeValue("", 650, "p", 650, 1, true);
#line 25 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
WriteAttributeValue(" ", 651, x, 652, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(655, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(657, 22, false);
#line 25 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
                        Write(Model.Linhas[x].Estado);

#line default
#line hidden
            EndContext();
            BeginContext(679, 42, true);
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 28 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(728, 1432, true);
            WriteLiteral(@"



</div>



<script>
    var data;
    var gage = []

    function linhaAltera() {
        var valor = document.getElementById(""linhas"").value
        var xhp = new XMLHttpRequest()
        
        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var re = this.responseText
                document.location.reload()
            }
        }
        xhp.open(""Get"", ""/oee/setLinhas?valor="" + valor);
        xhp.send();
    }

    function emula(valor) {
        
        if (valor == 0) {
            valor=1
        }
        else {
            valor=0
        }       

        var xhp = new XMLHttpRequest()
        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var re = this.responseText
               document.location.reload()
            }
        }
        xhp.open(""Get"", ""/oee/emula?valor=""+valor);
        xhp.send();
    ");
            WriteLiteral(@"}



    var sectors = [{
        color: ""#c00002"",
        lo: 0,
        hi: 20,
    }, {
        color: ""#febf00"",
        lo: 21,
        hi: 40,
    }, {
        color: ""#fdf500"",
        lo: 41,
        hi: 60,
    }, {
        color: ""#92d14f"",
        lo: 61,
        hi: 80,
    }, {
        color: ""#00af50"",
        lo: 81,
        hi: 100,
        }];

    var linhas = ");
            EndContext();
            BeginContext(2161, 16, false);
#line 99 "E:\pendrive moises\Progras criados por mim\DXM100 estudos\DXM.Web.Interface\DXM.Web.Interface\Views\oee\Index.cshtml"
            Write(Model.quantidade);

#line default
#line hidden
            EndContext();
            BeginContext(2177, 1328, true);
            WriteLiteral(@"



    for(var x = 0; x < linhas; x++) {
        var a = new JustGage({
            id: (x).toString(),
            value: 0,
            min: 0,
            max: 100,
            title: ""OEE"",
            symbol: '%',
            pointer: true,
            customSectors: sectors,
            relativeGaugeSize: true
        })
        gage.push(a)

    }





    setInterval(function () {
        getlinhas();
    }, 1000)

    function getlinhas() {
        var xhp = new XMLHttpRequest()
        xhp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                var re = this.responseText
                data = JSON.parse(re);
                if (data[0].estado == ""DXM OffLine"") {
                    document.location.href = ""/oee/offline"";
                }
                else {
                    for (x = 0; x < data.length; x++) {
                        document.getElementById(`l ${x}`).innerHTML = data[x].nome
 ");
            WriteLiteral(@"                       document.getElementById(`p ${x}`).innerHTML = data[x].estado
                        gage[x].refresh(data[x].oee)
                    }
                }

            }
        }
        xhp.open(""Get"", ""/oee/conjunto_linhas"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DXM.OEE.OEE> Html { get; private set; }
    }
}
#pragma warning restore 1591
