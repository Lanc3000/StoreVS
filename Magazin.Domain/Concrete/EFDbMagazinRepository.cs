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
    }
}
