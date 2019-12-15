using Autofac.Features.Indexed;
using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.SqlServer.Database;
using IReckonu.DataImportingTool.Data.SqlServer.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.SqlServer.Services
{
    public class GetService : IGet
    {
        private readonly IReckonuDatabaseContext _databaseContext;

        public GetService(IReckonuDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T: class
        {
           return await _databaseContext.Set<T>().AsNoTracking().Include(_databaseContext.GetIncludePaths(typeof(T))).SingleOrDefaultAsync(predicate);
        }
    }
}
