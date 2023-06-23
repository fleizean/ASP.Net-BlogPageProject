#pragma checksum "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94bae16fcc84fe9aec1e6e206bce25a6b5078f8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Experience_Index), @"mvc.1.0.view", @"/Views/Experience/Index.cshtml")]
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
#line 1 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/_ViewImports.cshtml"
using Blog_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/_ViewImports.cshtml"
using Blog_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94bae16fcc84fe9aec1e6e206bce25a6b5078f8e", @"/Views/Experience/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c420944616fabb710940f5ec29d08fc7cae2d98", @"/Views/_ViewImports.cshtml")]
    public class Views_Experience_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Experience>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-xxl flex-grow-1 container-p-y"">
    <div class=""row"">
        <div class=""card"">
            <div class=""table-responsive text-nowrap"">
                <table class=""table table-hover"">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Meslek</th>
                            <th>İşyeri</th>
                            <th>Tarih</th>
                            <th>Açıklama</th>
                            <th>Sil</th>
                            <th>Güncelle</th>
                        </tr>
                    </thead>
                    <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 25 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td><strong></strong>");
#nullable restore
#line 28 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                                                Write(item.ExperienceID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 29 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                               Write(item.JobTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 30 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                               Write(item.WorkPlace);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 31 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                               Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 32 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                                 if (item.Description.Length > 10)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 34 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                                   Write(item.Description.Substring(0, 10));

#line default
#line hidden
#nullable disable
            WriteLiteral("...</td>\n");
#nullable restore
#line 35 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 38 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 39 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td><a");
            BeginWriteAttribute("href", " href=\"", 1605, "\"", 1659, 2);
            WriteAttributeValue("", 1612, "/Experience/DeleteExperience/", 1612, 29, true);
#nullable restore
#line 40 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
WriteAttributeValue("", 1641, item.ExperienceID, 1641, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-danger\" onclick=\"return confirm(\'Gerçekten silmek istiyor musunuz?\')\"><span class=\"tf-icons bx bx-error-alt\"></span>&nbsp; Sil</a></td>\n                                <td><a");
            BeginWriteAttribute("href", " href=\"", 1858, "\"", 1910, 2);
            WriteAttributeValue("", 1865, "/Experience/EditExperience/", 1865, 27, true);
#nullable restore
#line 41 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
WriteAttributeValue("", 1892, item.ExperienceID, 1892, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-success\"><span class=\"tf-icons bx bx-pencil\"></span>&nbsp; Güncelle</a></td>\n\n                            </tr>\n");
#nullable restore
#line 44 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Experience/Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>

            </div>
        </div>
    </div>
    <br />
    <div style=""text-align: left;"">
        <a href=""/Experience/AddExperience/"" class=""btn btn-outline-info"">
            <span class=""tf-icons bx bx-clipboard""></span>&nbsp; Deneyim Ekle
        </a>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Experience>> Html { get; private set; }
    }
}
#pragma warning restore 1591