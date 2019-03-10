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
    [Authorize]
    public class AdminController : Controller
    {
        IMagazinRepository repository;
        // GET: Admin
        public AdminController(IMagazinRepository repository) {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Goods);
        }

        public ViewResult Edit(int goodsId)
        {
            Goods goods = repository.Goods
                .FirstOrDefault(g => g.GoodsId == goodsId);
            return View(goods);
        }

        [HttpPost]
        public ActionResult Edit(Goods goods, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    goods.ImageMimeTipe = image.ContentType;
                    goods.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(goods.ImageData, 0, image.ContentLength);
                }
                repository.SaveGoods(goods);
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", goods.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(goods);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Goods());
        }

        [HttpPost]
        public ActionResult Delete(int goodsId)
        {
            Goods deletedGoods = repository.DeleteGoods(goodsId);
            if (deletedGoods != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" был удален",
                    deletedGoods.Name);
            }
            return RedirectToAction("Index");
        }
        
    }
}

    
