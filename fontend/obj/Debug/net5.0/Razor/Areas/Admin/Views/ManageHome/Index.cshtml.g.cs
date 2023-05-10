#pragma checksum "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc1e00cae6f26d6e14bbde7ee9d9c45f1a9e25f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ManageHome_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/ManageHome/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc1e00cae6f26d6e14bbde7ee9d9c45f1a9e25f1", @"/Areas/Admin/Views/ManageHome/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_ManageHome_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main class=""app-content"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""app-title"">
                <ul class=""app-breadcrumb breadcrumb"">
                    <li class=""breadcrumb-item""><a href=""#""><b>Bảng điều khiển</b></a></li>
                </ul>
                <div id=""clock""></div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <!--Left-->
        <div class=""col-md-12 col-lg-6"">
            <div class=""row"">
                <!-- col-6 -->
                <div class=""col-md-6"">
                    <div class=""widget-small primary coloured-icon"">
                        <i class='icon bx bxs-user-account fa-3x'></i>
                        <div class=""info"">
                            <h4>Tổng khách hàng</h4>
                            <p><b>");
#nullable restore
#line 28 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
                             Write(ViewBag.SlCustomer);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" khách hàng</b></p>
                            <p class=""info-tong"">Tổng số khách hàng được quản lý.</p>
                        </div>
                    </div>
                </div>
                <!-- col-6 -->
                <div class=""col-md-6"">
                    <div class=""widget-small info coloured-icon"">
                        <i class='icon bx bxs-data fa-3x'></i>
                        <div class=""info"">
                            <h4>Tổng sản phẩm</h4>
                            <p><b>");
#nullable restore
#line 39 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
                             Write(ViewBag.SlProduct);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" sản phẩm</b></p>
                            <p class=""info-tong"">Tổng số sản phẩm được quản lý.</p>
                        </div>
                    </div>
                </div>
                <!-- col-6 -->
                <div class=""col-md-6"">
                    <div class=""widget-small warning coloured-icon"">
                        <i class='icon bx bxs-shopping-bags fa-3x'></i>
                        <div class=""info"">
                            <h4>Tổng đơn hàng</h4>
                            <p><b></b></p>
                            <p class=""info-tong"">Tổng số hóa đơn bán hàng trong tháng.</p>
                        </div>
                    </div>
                </div>
                <!-- col-6 -->
                <div class=""col-md-6"">
                    <div class=""widget-small danger coloured-icon"">
                        <i class='icon bx bxs-error-alt fa-3x'></i>
                        <div class=""info"">
                            <h4>Sắp hết hàng</h4>
");
            WriteLiteral(@"                            <p><b></b></p>
                            <p class=""info-tong"">Số sản phẩm cảnh báo hết cần nhập thêm.</p>
                        </div>
                    </div>
                </div>
                <!-- col-12 -->
                <div class=""col-md-12"">
                    <div class=""tile"">
                        <h3 class=""tile-title"">Khách hàng mới</h3>
                        <div>
                            <table class=""table table-hover"">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Tên khách hàng</th>
                                        <th>Email</th>
                                        <th>Số điện thoại</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 81 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
                                     foreach (var item in ViewBag.customers)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 84 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
                                           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 85 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 86 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
                                           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td><span class=\"tag tag-success\">");
#nullable restore
#line 87 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
                                                                         Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                        </tr>\r\n");
#nullable restore
#line 89 "D:\years3_2\api\Project_TTCM\fontend\Areas\Admin\Views\ManageHome\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
                
                <!-- / col-12 -->
                <!-- col-12 -->
                <div class=""col-md-12"">
                    <div class=""tile"">
                        <h3 class=""tile-title"">Tình trạng đơn hàng</h3>
                        <div>
                            <table class=""table table-bordered"">
                                <thead>
                                    <tr>
                                        <th>ID đơn hàng</th>
                                        <th>Tên khách hàng</th>
                                        <th>Tổng tiền</th>
                                        <th>Trạng thái</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                    ");
            WriteLiteral(@"                    <td></td>
                                        <td></td>
                                        <td>
                                        </td>
                                        <td><span class=""badge bg-info""></span></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                        </td>
                                        <td><span class=""badge bg-warning""></span></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                        </td>
                                        <td><span class=""badge bg-success""></span></td>
                         ");
            WriteLiteral(@"           </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                        </td>  
                                        <td><span class=""badge bg-danger""></span></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- / div trống-->
                    </div>
                </div>
                
                <!-- / col-12 -->
            </div>
        </div>
        <!--END left-->
        <!--Right-->
        <div class=""col-md-12 col-lg-6"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""tile"">
                        <h3 class=""tile-title"">Dữ liệu 6 tháng đầu vào</h3>
                        <div class=""embed-responsive embed-r");
            WriteLiteral(@"esponsive-16by9"">
                            <canvas class=""embed-responsive-item"" id=""lineChartDemo""></canvas>
                        </div>
                    </div>
                </div>
                <div class=""col-md-12"">
                    <div class=""tile"">
                        <h3 class=""tile-title"">Thống kê 6 tháng doanh thu</h3>
                        <div class=""embed-responsive embed-responsive-16by9"">
                            <canvas class=""embed-responsive-item"" id=""barChartDemo""></canvas>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <!--END right-->
    </div>


    <div class=""text-center"" style=""font-size: 13px"">
        <p>
            <b>
                Copyright
                <script type=""text/javascript"">
                    document.write(new Date().getFullYear());
                </script> Phần mềm quản lý bán hàng | Dev By Long
            </b>
        </p>
   ");
            WriteLiteral(" </div>\r\n</main>\r\n\r\n");
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
