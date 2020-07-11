using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class Product : AbstractProduct, IEntityWithCustomFields
    {
        public List<ProductPrice> Prices { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }

        public ProductUpdate ToUpdate()
        {
            return new ProductUpdate
            {
                Name = Name,
                Code = Code,
                Unit = Unit,
                Tax = Tax,
                ActiveFlag = ActiveFlag,
                VisibleTo = VisibleTo,
                OwnerId = Owner.Id,
                Prices = Prices.Select(x => new NewProductPrice
                {
                    Price = x.Price ?? 0M,
                    Currency = x.Currency,
                    Cost = x.Cost,
                    OverheadCost = x.OverheadCost
                }).ToList(),
                CustomFields = CustomFields
            };
        }
    }
}
