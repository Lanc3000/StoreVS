using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Domain.Entities;
using Magazin.Domain.Abstract;

namespace Magazin.Domain.Concrete
{
    public class EFDbMagazinRepository: IMagazinRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Goods> Goods {
            get { return context.Goods; }
        }

        public void SaveGoods(Goods goods) {
            if (goods.GoodsId == 0)
                context.Goods.Add(goods);
            else {
                Goods dbEntry = context.Goods.Find(goods.GoodsId);
                if (dbEntry != null) {
                    dbEntry.Name = goods.Name;
                    dbEntry.Description = goods.Description;
                    dbEntry.Price = goods.Price;
                    dbEntry.Category = goods.Category;
                    dbEntry.Size = goods.Size;
                    dbEntry.ImageData = goods.ImageData;
                    dbEntry.ImageMimeTipe = goods.ImageMimeTipe;
                }
            }
            context.SaveChanges();
        }

        public Goods DeleteGoods(int goodsId)
        {
            Goods dbEntry = context.Goods.Find(goodsId);
            if (dbEntry != null)
            {
                context.Goods.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
