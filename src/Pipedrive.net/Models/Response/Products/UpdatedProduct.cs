using System.Collections.Generic;

namespace Pipedrive
{
    public class UpdatedProduct : AbstractProduct
    {
        public Dictionary<string, ProductPrice> Prices { get; set; }
    }
}
