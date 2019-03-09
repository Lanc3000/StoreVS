using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Magazin.Domain.Entities;

namespace Magazin.Web.Models
{
    public class GoodsListViewModel
    {
        public IEnumerable<Goods> Goods { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        
    }
}