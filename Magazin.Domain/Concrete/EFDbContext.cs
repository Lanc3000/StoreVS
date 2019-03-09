using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Domain.Entities;
using System.Data.Entity;

namespace Magazin.Domain.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<Goods> Goods { get; set; }
    }
}
