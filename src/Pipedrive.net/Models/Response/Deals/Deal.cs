using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Converters;
using Pipedrive.CustomFields;
using Pipedrive.Internal;
using Pipedrive.Models.Response.Deals;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class Deal : AbstractDeal<UserCustomField, PersonCustomField, OrganizationCustomField>, IEntityWithCustomFields
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
                UserId = UserId?.Value,
                PersonId = PersonId?.Value,
                OrgId = OrgId?.Value,
                StageId = StageId,
                Status = Status,
                Probability = Probability,
                LostReason = LostReason,
                VisibleTo = VisibleTo,
                AddTime = AddTime,
                CloseTime = CloseTime,
                LostTime = LostTime,
                FirstWonTime = FirstWonTime,
                WonTime = WonTime,
                ExpectedCloseDate = ExpectedCloseDate,
                CustomFields = CustomFields
            };
        }
        
        [JsonProperty("stay_in_pipeline_stages")]
        public DealStayInPipelineStage StayInPipelineStages { get; set; }

        [JsonProperty("age")]
        public DealAge Age { get; set; }
    }
}
