using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin.Domain.Abstract;

namespace Magazin.Web.Controllers
{
    public class NavController : Controller
    {
        private IMagazinRepository repository;

        public NavController(IMagazinRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Goods
                .Select(goods => goods.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
        public PartialViewResult MenuHorizontal(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Goods
                .Select(goods => goods.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}