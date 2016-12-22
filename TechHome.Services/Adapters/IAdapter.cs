using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHome.Services.Adapters
{
    public interface IAdapter<F, T>
    {
        T Adapt(F from);
    }
}
