using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class WebhookDeal : AbstractDeal<long?, long?, long?>, IEntityWithCustomFields
    {
        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }

        public DealUpdate ToUpdate()
        {
            return new DealUpdate
            {
                Title = Title,
                Value = Value,
                Currency = Currency,
                UserId = UserId,
                PersonId = PersonId,
                OrgId = OrgId,
                StageId = StageId,
                Status = Status,
                Probability = Probability,
                LostReason = LostReason,
                AddTime = AddTime,
                VisibleTo = VisibleTo,
                CustomFields = CustomFields
            };
        }
    }
}
