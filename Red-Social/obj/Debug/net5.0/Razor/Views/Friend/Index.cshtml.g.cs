#pragma checksum "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a8a585b2ebdf1c8f621e944e503ce946d43836a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Friend_Index), @"mvc.1.0.view", @"/Views/Friend/Index.cshtml")]
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
#line 1 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\_ViewImports.cshtml"
using Red_Social;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\_ViewImports.cshtml"
using Red_Social.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
using Red_Social.Core.Application.ViewModels.Friends;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
using Red_Social.Core.Application.ViewModels.Post;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a8a585b2ebdf1c8f621e944e503ce946d43836a", @"/Views/Friend/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ac8a54b40e47a0742dfba3be387be4b62e71a4a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Friend_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SaveFriendViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("for", new global::Microsoft.AspNetCore.Html.HtmlString("recipient-name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-form-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("recipient-name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Friend", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Comment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
  
    //Model.UserId = ViewBag.UserId;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


    <div class=""row"">
        <div class=""col-3"">
            <div class=""h2 text-muted"">Lista de Amigos</div>


            <button type=""button"" class=""btn btn-primary btn-lg mt-5 mb-4 morado-claro"" data-toggle=""modal"" data-target=""#exampleModal"" data-whatever="""">Añadir Amigos </button>

            <div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
                <div class=""modal-dialog"" role=""document"">
                    <div class=""modal-content"">
                        <div class=""modal-header"">
                            <h5 class=""modal-title"" id=""exampleModalLabel"">Agregar Amigo</h5>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                <span aria-hidden=""true"">&times;</span>
                            </button>
                        </div>
                        <div class=""modal-body"">

                       ");
            WriteLiteral("     ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a8a585b2ebdf1c8f621e944e503ce946d43836a9792", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 31 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                           Write(Html.ValidationSummary(false, "",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                                <div class=\"form-group\">\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a8a585b2ebdf1c8f621e944e503ce946d43836a10523", async() => {
                    WriteLiteral("Ingresa el Nombre de Usuario:");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 34 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Username);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3a8a585b2ebdf1c8f621e944e503ce946d43836a12335", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 35 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Username);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a8a585b2ebdf1c8f621e944e503ce946d43836a14290", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 36 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Username);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                                </div>\r\n\r\n");
                WriteLiteral("                                <div class=\"text-center\">\r\n                                    <button type=\"submit\" class=\"btn  btn-success \">Agregar </button>\r\n\r\n");
                WriteLiteral("                                    <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Close</button>\r\n\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"modal-footer\">\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n\r\n");
#nullable restore
#line 58 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
             foreach (FriendViewModel item in ViewBag.FriendList)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"people-nearby\">\r\n\r\n                    <div class=\"nearby-user\">\r\n                        <div class=\"row\">\r\n                            <div class=\"col-2\">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 2956, "\"", 2980, 1);
#nullable restore
#line 66 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
WriteAttributeValue("", 2962, item.PhotoProfile, 2962, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"user\" class=\"profile-photo-lg\">\r\n                            </div>\r\n                            <div class=\"col-md-7 col-sm-7\">\r\n                                <h5><a href=\"#\" class=\"profile-link\">");
#nullable restore
#line 69 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                                                                Write(item.FriendName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 69 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                                                                                 Write(item.FriendLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </a></h5>\r\n                                <p>Username: ");
#nullable restore
#line 70 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                                        Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-md-3 col-sm-3\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a8a585b2ebdf1c8f621e944e503ce946d43836a20613", async() => {
                WriteLiteral("Delete ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n                </div>\r\n");
#nullable restore
#line 80 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n\r\n            <section class=\"col-7 mt-4\" style=\"background-color: #eee;\">\r\n            <div class=\"h2 text-primary text-center\">Posts de mis amigos</div>\r\n        <!--Listado de Post-->\r\n");
#nullable restore
#line 90 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
         foreach (PostViewModel item in ViewBag.Posts)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""container my-5 py-2"">
                    <div class=""col-md-12 col-lg-10 col-xl-12"">
                        <div class=""card shadow-lg p-3 mb-5 bg-white rounded border border-secondary"">
                            <div class=""card-body"">


                                <div class=""d-flex justify-content-between"">


                                    <div class=""d-flex flex-start align-items-center"">
                                        <img class=""rounded-circle shadow-1-strong me-3""");
            BeginWriteAttribute("src", "\r\n                                         src=\"", 4495, "\"", 4569, 1);
#nullable restore
#line 104 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
WriteAttributeValue("", 4543, item.User.ProfilePhotoUrl, 4543, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" alt=""avatar"" width=""60""
                                         height=""60"" />
                                        <div class=""ml-3"">
                                            <h5 class=""fw-bold text-primary mb-1"">
                                                ");
#nullable restore
#line 108 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                                           Write(item.User.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </h5>\r\n                                            <p class=\"text-muted small mb-0\">\r\n                                                Shared publicly - ");
#nullable restore
#line 111 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                                                             Write(item.Created);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </p>
                                        </div>
                                    </div>



                                </div>


                                <p class=""mt-3 mb-4 pb-2"">
                                    ");
#nullable restore
#line 122 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                               Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n\r\n                                <div class=\"d-flex text-center\">\r\n                                    <img class=\"card-img-right flex-auto d-none d-md-block mt-1 mb-4 pb-2 \"");
            BeginWriteAttribute("src", " src=\"", 5590, "\"", 5610, 1);
#nullable restore
#line 126 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
WriteAttributeValue("", 5596, item.ImageUrl, 5596, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 900px; height: 490px;\" data-holder-rendered=\"true\">\r\n\r\n                                </div>\r\n\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a8a585b2ebdf1c8f621e944e503ce946d43836a27543", async() => {
                WriteLiteral("Comentar Y Ver Comentarios");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 131 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"
                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 137 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Mini Proyecto Red Social\Red-Social\Red-Social\Views\Friend\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </section>\r\n\r\n\r\n\r\n\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SaveFriendViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
