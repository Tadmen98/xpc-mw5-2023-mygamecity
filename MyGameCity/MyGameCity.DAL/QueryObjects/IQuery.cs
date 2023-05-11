using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameCity.DAL.QueryObjects
{
    public interface IQuery<TModel, TFilter>
    {
        Task<IList<TModel>> Execute(TFilter filter);
    }
}
