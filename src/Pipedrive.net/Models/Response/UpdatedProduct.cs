using System.Collections.Generic;

namespace Pipedrive.Models.Response
{
    public class UpdatedProduct : AbstractProduct
    {
        public Dictionary<string, ProductPrice> Prices { get; set; }
    }
}
