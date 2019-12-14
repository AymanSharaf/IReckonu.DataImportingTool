using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Abstractions
{
    public interface IGet
    {
        Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class; 
    }
}
