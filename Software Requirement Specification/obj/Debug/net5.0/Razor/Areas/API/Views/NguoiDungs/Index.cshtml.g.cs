#pragma checksum "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c805c91e9da9eaaeb709bc1c5ebed1c2c2d0fc71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_API_Views_NguoiDungs_Index), @"mvc.1.0.view", @"/Areas/API/Views/NguoiDungs/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c805c91e9da9eaaeb709bc1c5ebed1c2c2d0fc71", @"/Areas/API/Views/NguoiDungs/Index.cshtml")]
    #nullable restore
    public class Areas_API_Views_NguoiDungs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Software_Requirement_Specification.Models.NguoiDung>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.VaiTro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.VaiTro.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 985, "\"", 1008, 1);
#nullable restore
#line 40 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
WriteAttributeValue("", 1000, item.Id, 1000, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1061, "\"", 1084, 1);
#nullable restore
#line 41 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
WriteAttributeValue("", 1076, item.Id, 1076, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1139, "\"", 1162, 1);
#nullable restore
#line 42 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
WriteAttributeValue("", 1154, item.Id, 1154, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\BAO PHUC- PC\OneDrive\Desktop\New folder\Software Requirement Specification\Software Requirement Specification\Areas\API\Views\NguoiDungs\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Software_Requirement_Specification.Models.NguoiDung>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591