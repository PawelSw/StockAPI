using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.DataAccess.CQRS.Querries.ProducersQuerry
{
    public class GetProducersQuerry : QuerryBase<List<Producer>>
    {
        public override Task<List<Producer>> Execute(StockApiStorageContext context)
        {
            return context.Producers.ToListAsync();

        }
    }
}
