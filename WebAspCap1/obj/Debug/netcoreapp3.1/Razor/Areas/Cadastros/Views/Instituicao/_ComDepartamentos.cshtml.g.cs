#pragma checksum "C:\Users\diogo\source\repos\WebAspCap1\WebAspCap1\Areas\Cadastros\Views\Instituicao\_ComDepartamentos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2770a54b82c345d894ef1911974c917c5ba5420"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Cadastros_Views_Instituicao__ComDepartamentos), @"mvc.1.0.view", @"/Areas/Cadastros/Views/Instituicao/_ComDepartamentos.cshtml")]
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
#line 1 "C:\Users\diogo\source\repos\WebAspCap1\WebAspCap1\Areas\Cadastros\Views\_ViewImports.cshtml"
using WebAspCap1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\diogo\source\repos\WebAspCap1\WebAspCap1\Areas\Cadastros\Views\_ViewImports.cshtml"
using WebAspCap1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2770a54b82c345d894ef1911974c917c5ba5420", @"/Areas/Cadastros/Views/Instituicao/_ComDepartamentos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd04d13337c7144dd6298f3dd4d0584b36a69041", @"/Areas/Cadastros/Views/_ViewImports.cshtml")]
    public class Areas_Cadastros_Views_Instituicao__ComDepartamentos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Modelo.Cadastros.Departamento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""panel	panel-primary"">
    <div class=""card-header	text-white	bg-warning	text-center"">
        Relação	de DEPARTAMENTOS registrados para a instituição
    </div>
    <div class=""panel-body"">
        <table class=""table	table-striped table-hover"">
            <thead>
                <tr>
                    <th>
                        ");
#nullable restore
#line 12 "C:\Users\diogo\source\repos\WebAspCap1\WebAspCap1\Areas\Cadastros\Views\Instituicao\_ComDepartamentos.cshtml"
                   Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 17 "C:\Users\diogo\source\repos\WebAspCap1\WebAspCap1\Areas\Cadastros\Views\Instituicao\_ComDepartamentos.cshtml"
                 foreach (var item in Model)
                 {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 21 "C:\Users\diogo\source\repos\WebAspCap1\WebAspCap1\Areas\Cadastros\Views\Instituicao\_ComDepartamentos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 24 "C:\Users\diogo\source\repos\WebAspCap1\WebAspCap1\Areas\Cadastros\Views\Instituicao\_ComDepartamentos.cshtml"
                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"panel-footer panel-info\">\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Modelo.Cadastros.Departamento>> Html { get; private set; }
    }
}
#pragma warning restore 1591
