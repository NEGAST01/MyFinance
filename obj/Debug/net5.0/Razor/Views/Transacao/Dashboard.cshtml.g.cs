#pragma checksum "E:\Visual Studio\Atividades\MyFinance\Views\Transacao\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f39f90d2e52197dc571db9bb47ca9ea9d71a22e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transacao_Dashboard), @"mvc.1.0.view", @"/Views/Transacao/Dashboard.cshtml")]
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
#nullable restore
#line 1 "E:\Visual Studio\Atividades\MyFinance\Views\_ViewImports.cshtml"
using MyFinance;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Visual Studio\Atividades\MyFinance\Views\_ViewImports.cshtml"
using MyFinance.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f39f90d2e52197dc571db9bb47ca9ea9d71a22e8", @"/Views/Transacao/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d05dd6abef5a8ff60f9a555c67ee727241a6c480", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Transacao_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<h3>Meu Dashboard</h3>
<br /><br />
<script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.min.js""></script>

<div id=""canvas-holder"" style=""width:60%"">
    <canvas id=""chart-area""></canvas>
</div>

<script>
    var randomScalingFactor = function () {
        return Math.round(Math.random() * 100);
    };

    var config = {
        type: 'pie',
        data: {
            datasets: [{
                data: [");
#nullable restore
#line 18 "E:\Visual Studio\Atividades\MyFinance\Views\Transacao\Dashboard.cshtml"
                  Write(Html.Raw(ViewBag.Valores));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                backgroundColor: [");
#nullable restore
#line 19 "E:\Visual Studio\Atividades\MyFinance\Views\Transacao\Dashboard.cshtml"
                             Write(Html.Raw(ViewBag.Cores));

#line default
#line hidden
#nullable disable
            WriteLiteral("],\r\n                label: \'Dataset 1\'\r\n            }],\r\n            labels: [");
#nullable restore
#line 22 "E:\Visual Studio\Atividades\MyFinance\Views\Transacao\Dashboard.cshtml"
                Write(Html.Raw(ViewBag.Labels));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
        },
        options: {
            responsive: true
        }
    };

    window.onload = function () {
        var ctx = document.getElementById('chart-area').getContext('2d');
        window.myPie = new Chart(ctx, config);
    };

</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
