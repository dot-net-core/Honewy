using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honey.Web.Models.Layout;
using Microsoft.AspNetCore.Mvc;

namespace Honey.Web.Controllers
{
    public class LayoutController : Controller
    {
        public PartialViewResult Header()
        {
            var headerModel = new HeaderViewModel();
            return PartialView("~/Views/Layout/_Header.cshtml", headerModel);
        }

        public PartialViewResult AppLogo()
        {
            return PartialView("~/Views/Layout/_AppLogo.cshtml");
        }
        public PartialViewResult HeaderMenu()
        {
            var headerMenuModel = new HeaderMenuViewModel();
            return PartialView("~/Views/Shared/_LeftMenu.cshtml", headerMenuModel);
        }
        public PartialViewResult Footer()
        {
            var footerModel = new FooterViewModel();
            return PartialView("~/Views/Layout/_Footer.cshtml", footerModel);
        }
    }
}