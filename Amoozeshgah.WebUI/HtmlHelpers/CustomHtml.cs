using Amoozeshgah.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Amoozeshgah.WebUI.HtmlHelpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString BreadCrumb(this HtmlHelper helper, string lastName)
        {
            string bread = @"<div class='btn-group btn-breadcrumb btn-extended-breadcrumb'>
                                    <a href = '#' class='btn btn-default'><i class='glyphicon glyphicon-home'></i></a>
                                <a href ='#' class='btn btn-default'>ناحیه کاربری</a>
                                <a href ='#' class='btn btn-default'>" + lastName + @"</a>
                            </div>
                           ";
            return MvcHtmlString.Create(bread);
        }
        public static MvcHtmlString LobiPanelWithDataTable(this HtmlHelper helper, Dto dto, string[] ths)
        {
            var lpdt = $@"<div class='col-md-12'><div class='panel panel-default lobiPanel' id='{dto.LobiPanelDataId}' data-inner-id='{dto.LobiPanelDataId}'>
                                    <div class='panel-heading'>
                                    <div class='panel-title'>
                                        {dto.PageTitle}
                                    </div>
                                </div>
                                <div class='panel-body'>
                                    <table class='table datatable display table-responsive table-hover table-striped' style='width:100% !important;' id='departmentsTable'>
                                        <thead>
                                            <tr>";
            string th = "";
            foreach (var item in ths)
            {
                th += $"<th>{item}</th>";
            }
            lpdt += th;
            lpdt += @"<th data-orderable='false'></th>
                                                        </tr>
                                                    </thead>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
            ";
            return MvcHtmlString.Create(lpdt);
        }

        public static MvcHtmlString JalaliDatetimePicker(this HtmlHelper helper,string tagName) {
            var lpdt = $@"<input type='text' id='{tagName}' class='form-control' name='{tagName}'>";
            return MvcHtmlString.Create(lpdt);

        }


        public static string StringNameFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            StringBuilder StringName = new StringBuilder();
            return helper.DisplayNameFor(expression).ToString();
        }
    }
}