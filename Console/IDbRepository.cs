using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova3
{
    internal interface IDbRepository<T>
    {
        List<T> Fetch();
        

    }
}
