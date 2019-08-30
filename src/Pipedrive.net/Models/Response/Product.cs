using System.Collections.Generic;
using System.Linq;
using Pipedrive.Models.Request;

namespace Pipedrive.Models.Response
{
    public class Product : AbstractProduct
    {
        public List<ProductPrice> Prices { get; set; }

        public ProductUpdate ToUpdate()
        {
            return new ProductUpdate
            {
                Name = Name,
                Code = Code,
                Unit = Unit,
                Tax = Tax,
                Active = Active,
                VisibleTo = VisibleTo,
                OwnerId = Owner.Id,
                Prices = Prices.Select(x => new NewProductPrice
                {
                    CurrencyCode = x.CurrencyCode,
                    DirectCost = x.DirectCost,
                    Price = x.Price ?? 0M,
                    UnitCost = x.UnitCost
                }).ToList()
            };
        }
    }

}
