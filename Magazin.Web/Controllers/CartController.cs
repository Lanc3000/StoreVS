using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin.Domain.Entities;
using Magazin.Domain.Abstract;
using Magazin.Web.Models;

namespace Magazin.Web.Controllers
{
    public class CartController : Controller
    {

        private IMagazinRepository repository;
        public CartController(IMagazinRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(Cart cart, string returnUrl) {
            return View(new CartIndexViewModel {
                cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int goodsId, string returnUrl)
        {
            Goods goods = repository.Goods
                .FirstOrDefault(g => g.GoodsId == goodsId);

            if (goods != null)
            {
                cart.AddItem(goods, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int goodsId, string returnUrl)
        {
            Goods goods = repository.Goods
                .FirstOrDefault(g => g.GoodsId == goodsId);

            if (goods != null)
            {
                cart.RemoveLine(goods);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}