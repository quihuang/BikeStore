#pragma checksum "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b89634d225f77b31405a05ef6549c81e1ea23de9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BikeStore.App.Web.Pages.GestionProductos.Pages_GestionProductos_Productos), @"mvc.1.0.razor-page", @"/Pages/GestionProductos/Productos.cshtml")]
namespace BikeStore.App.Web.Pages.GestionProductos
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
#line 1 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\_ViewImports.cshtml"
using BikeStore.App.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b89634d225f77b31405a05ef6549c81e1ea23de9", @"/Pages/GestionProductos/Productos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"831a57b8d38db9a3bd7946360ef7e2e802db498d", @"/Pages/_ViewImports.cshtml")]
    public class Pages_GestionProductos_Productos : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formEditar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Gestion Productos";
    ViewData["script"] = "Productos.js"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"containerRol\" hidden>");
#nullable restore
#line 9 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
                         Write(Model.rolValidateSession);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<div class=""container-fluid px-4"">

    <div class=""tittleModules"">
        <h1>
            Gestion de Productos
        </h1>
    </div>

    <div class=""containerBottons"">
        <button type=""button"" id=""btn-delete"" class=""btn btn-primary btn-crud"" hidden>
            Eliminar
        </button>
        <button type=""button"" id=""btn-update"" class=""btn btn-primary btn-crud"" data-toggle=""modal"" data-target=""#ModalActualizar"" onclick=""editar('Productos');"" hidden>
            Editar
        </button>
        <button type=""button"" id=""btn-create"" class=""btn btn-primary "" data-toggle=""modal"" data-target=""#ModalCrear"" onclick=""crear('Productos');"">
            Crear
        </button>
    </div>

    <!-- ModalCrear -->
    <div class=""modal fade"" id=""ModalCrear"" tabindex=""-1"" role=""dialog"" aria-labelledby=""ModalCrearLabel""
        aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-hea");
            WriteLiteral(@"der"">
                    <h5 class=""modal-title"" id=""titleModal"">Registrar Producto</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""row"">
                        <div class=""col"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b89634d225f77b31405a05ef6549c81e1ea23de96414", async() => {
                WriteLiteral(@"
                                <div class=""form-group"">
                                    <label for=""nombre"">Nombre</label>
                                    <input type=""text"" name=""nombre"" id=""nombre"" class=""form-control"" onkeypress=""return Solo_Texto(event);"" placeholder=""Ingrese el nombre del producto nuevo"" aria-describedby=""invalid-feedback""
                                        minlength=""3"" maxlength=""200"" required>
                                    <div class=""invalid-feedback"">
                                        Ingrese el nombre del producto.
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label for=""descripcion"">Descripcion</label>
                                    <input type=""text"" name=""descripcion"" id=""descripcion"" class=""form-control"" onkeypress=""return Solo_Texto(event);"" placeholder=""Ingrese la descripcion del producto nuevo"" aria-descr");
                WriteLiteral(@"ibedby=""invalid-feedback"" minlength=""3""  maxlength=""600"" required>
                                    <div class=""invalid-feedback"">
                                        Ingrese la descripción del producto.
                                    </div>
                                </div>
                                <div class=""modal-footer"">
                                    <button type=""reset"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
                                    <button type=""submit"" id=""btn-create-modal"" class=""btn btn-primary"">Crear</button>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- ModalActualizar -->
    <div class=""modal fade"" id=""ModalActualizar"" tabindex=""-1"" aria-labelledby=""ModalActualizarLabel""
        aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""titleModal"">Actualizar Producto</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""row"">
                        <div class=""col"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b89634d225f77b31405a05ef6549c81e1ea23de910955", async() => {
                WriteLiteral("\r\n                                ");
#nullable restore
#line 89 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
                           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                <input type=""number"" name=""idUpdate"" id=""idUpdate"" class=""form-control"" readonly hidden>
                                <div class=""form-group"">
                                    <label for=""nombreUpdate"">Nombre</label>
                                    <input type=""text"" name=""nombreUpdate"" id=""nombreUpdate"" class=""form-control"" onkeypress=""return Solo_TextoYnumeros(event);"" placeholder=""Ingrese el nombre del producto nuevo"" aria-describedby=""invalid-feedback""
                                        minlength=""3"" maxlength=""200"" required>
                                    <div class=""invalid-feedback"">
                                        Ingrese el Nombre del producto.
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label for=""descripcionUpdate"">Descripcion</label>
                                    <input type=""text"" name=""de");
                WriteLiteral(@"scripcionUpdate"" id=""descripcionUpdate"" class=""form-control"" onkeypress=""return Solo_TextoYnumeros(event);"" placeholder=""Ingrese la descripcion del producto nuevo"" aria-describedby=""invalid-feedback"" minlength=""3""  maxlength=""600"" required>
                                    <div class=""invalid-feedback"">
                                        Ingrese la descripción del producto.
                                    </div>
                                </div>
                                <div class=""modal-footer"">
                                    <button type=""reset"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>
                                    <button type=""button"" id=""btn-update-modal"" class=""btn btn-primary"">Actualizar</button>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <!-- Tabla general -->
    <div class=""card mb-4"">
        <div class=""card-header"">
            <i class=""fas fa-table me-1""></i>
            Prodcutos
        </div>
        <div class=""card-body"">
            <table id=""datatablesSimple"">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Descripcion</th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Descripcion</th>
                    </tr>
                </tfoot>
");
            WriteLiteral("                <tbody>\r\n");
#nullable restore
#line 142 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
                     foreach(var item in Model.listadoProducto){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("onclick", " onclick=\"", 7391, "\"", 7478, 7);
            WriteAttributeValue("", 7401, "seleccionarRegistroTabla(this,\'", 7401, 31, true);
#nullable restore
#line 143 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
WriteAttributeValue("", 7432, item.Id, 7432, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7440, "\',\'", 7440, 3, true);
#nullable restore
#line 143 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
WriteAttributeValue("", 7443, item.Nombre, 7443, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7455, "\',\'", 7455, 3, true);
#nullable restore
#line 143 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
WriteAttributeValue("", 7458, item.Descripcion, 7458, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7475, "\');", 7475, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <td>");
#nullable restore
#line 144 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 145 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
                       Write(item.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 146 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
                       Write(item.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 148 "D:\1. Universidad de Caldas\BikeStore\BikeStore.App\BikeStore.App.Web\Pages\GestionProductos\Productos.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BikeStore.App.Web.Pages.ProductosModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BikeStore.App.Web.Pages.ProductosModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BikeStore.App.Web.Pages.ProductosModel>)PageContext?.ViewData;
        public BikeStore.App.Web.Pages.ProductosModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
