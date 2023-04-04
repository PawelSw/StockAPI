using StockAPI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.DataAccess.CQRS.Commands.SuppliersCommand
{
    public class UpdateSupplierCommand : CommandBase<Supplier, Supplier>
    {
        public override async Task<Supplier> Execute(StockApiStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Suppliers.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
