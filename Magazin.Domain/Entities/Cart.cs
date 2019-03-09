using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Magazin.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Goods goods, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Goods.GoodsId == goods.GoodsId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Goods = goods,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Goods goods)
        {
            lineCollection.RemoveAll(l => l.Goods.GoodsId == goods.GoodsId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Goods.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Goods Goods { get; set; }
        public int Quantity { get; set; }
    }
}
