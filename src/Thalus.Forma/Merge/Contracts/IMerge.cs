using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thalus.Forma.Merge.Contracts
{
    interface IMerge <TType>
    {
        void Merge(TType target, params TType[] additionals);
    }
}
