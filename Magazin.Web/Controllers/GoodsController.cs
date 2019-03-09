using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin.Domain.Abstract;
using Magazin.Domain.Entities;
using Magazin.Web.Models;

namespace Magazin.Web.Controllers
{
    public class GoodsController : Controller
    {
        private IMagazinRepository repository;
        public int pageSize = 4;
        // GET: Goods
        public GoodsController(IMagazinRepository repository) {
            this.repository = repository;
        }

        public ViewResult List(string category, int page = 1) {
            GoodsListViewModel model = new GoodsListViewModel
            {
                Goods = repository.Goods
                .Where(p => category == null || p.Category == category)
                .OrderBy(goods => goods.GoodsId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                    repository.Goods.Count() :
                    repository.Goods.Where(goods => goods.Category == category).Count()
                },
                CurrentCategory = category,
                
            };
            return View(model);
        }
    }
}