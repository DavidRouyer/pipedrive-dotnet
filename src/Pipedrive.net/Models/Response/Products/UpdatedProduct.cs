using System.Collections.Generic;

namespace Pipedrive
{
    public class UpdatedProduct : AbstractProduct
    {
        public List<ProductPrice> Prices { get; set; }
    }
}
