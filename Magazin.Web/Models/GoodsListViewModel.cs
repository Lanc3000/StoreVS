using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Magazin.Domain.Entities;

namespace Magazin.Web.Models
{
    public class GoodsListViewModel
    {
        public IEnumerable<Goods> Goods { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentProducer { get; set; }
        public decimal CurrentPrice { get; set; }
        public SelectList Category { get; set; }
        public SelectList Producer { get; set; }
        
    }
}