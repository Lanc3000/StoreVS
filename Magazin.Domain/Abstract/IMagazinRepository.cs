using System;
using System.Collections.Generic;
using Magazin.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Domain.Abstract
{
    public interface IMagazinRepository
    {
        IEnumerable<Goods> Goods { get; }
    }
}
