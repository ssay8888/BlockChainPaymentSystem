#pragma checksum "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "340bb292914909f94564ba3dbf835ed8ea6fc1ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ResponsePaymentModels_Delete), @"mvc.1.0.view", @"/Views/ResponsePaymentModels/Delete.cshtml")]
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
#line 1 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\_ViewImports.cshtml"
using BlockChainPaymentSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\_ViewImports.cshtml"
using BlockChainPaymentSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"340bb292914909f94564ba3dbf835ed8ea6fc1ee", @"/Views/ResponsePaymentModels/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23c884acc694ecb6c056545714f35a684dfd7c65", @"/Views/_ViewImports.cshtml")]
    public class Views_ResponsePaymentModels_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlockChainPaymentSystem.Models.JsonModels.ResponsePaymentModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>ResponsePaymentModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.payment_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.payment_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.payment_status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.payment_status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.pay_address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.pay_address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.price_amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.price_amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.price_currency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.price_currency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.pay_amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.pay_amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.pay_currency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.pay_currency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.actually_paid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.actually_paid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.order_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.order_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.order_description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.order_description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.payin_extra_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.payin_extra_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 81 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ipn_callback_url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 84 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ipn_callback_url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 87 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.created_at));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 90 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.created_at));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 93 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.updated_at));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 96 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.updated_at));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 99 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.purchase_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 102 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.purchase_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 105 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.outcome_amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 108 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.outcome_amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 111 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.outcome_currency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 114 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
       Write(Html.DisplayFor(model => model.outcome_currency));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "340bb292914909f94564ba3dbf835ed8ea6fc1ee16492", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "340bb292914909f94564ba3dbf835ed8ea6fc1ee16759", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 119 "D:\BlockChainPaymentSystem\BlockChainPaymentSystem\Views\ResponsePaymentModels\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "340bb292914909f94564ba3dbf835ed8ea6fc1ee18560", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlockChainPaymentSystem.Models.JsonModels.ResponsePaymentModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
