#pragma checksum "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4f4225295a0ae21af99a2774637381b12449062"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_AboutList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/AboutList/Default.cshtml")]
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
#line 1 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4f4225295a0ae21af99a2774637381b12449062", @"/Views/Shared/Components/AboutList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c420944616fabb710940f5ec29d08fc7cae2d98", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_AboutList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<About>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
             foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1 class=\"mb-0\">\n                ");
#nullable restore
#line 7 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <span class=\"text-primary\">");
#nullable restore
#line 8 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
                                      Write(item.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            </h1>\n            <div class=\"subheading mb-5\">\n                ");
#nullable restore
#line 11 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
           Write(item.ShortAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(" · ");
#nullable restore
#line 11 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
                                Write(item.LongAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(" · ");
#nullable restore
#line 11 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
                                                     Write(item.Telephone.Replace("+90", "").Trim().Insert(0, "(+90) ").Insert(11, " ").Insert(14, " "));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ·\n                <a");
            BeginWriteAttribute("href", " href=\"", 461, "\"", 486, 2);
            WriteAttributeValue("", 468, "mailto:", 468, 7, true);
#nullable restore
#line 12 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
WriteAttributeValue("", 475, item.Email, 475, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 12 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
                                        Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n            </div>\n            <p class=\"lead mb-5\">");
#nullable restore
#line 14 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
                            Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 15 "/Users/fleizean/Desktop/Self-Project/Asp.Net/BlogWeb_Project/Blog_Project/Blog_Project/Views/Shared/Components/AboutList/Default.cshtml"
                }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<About>> Html { get; private set; }
    }
}
#pragma warning restore 1591
