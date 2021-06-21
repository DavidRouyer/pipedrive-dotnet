using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's LeadLabels API.
    /// </summary>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/LeadLabels">Lead Label API documentation</a> for more information.
    public class LeadLabelClient : ApiClient, ILeadLabelsClient
    {
        public LeadLabelClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<LeadLabel>> GetAll()
            => ApiConnection.GetAll<LeadLabel>(ApiUrls.LeadLabels());

        public Task<LeadLabel> Create(NewLeadLabel leadLabel)
        {
            Ensure.ArgumentNotNull(leadLabel.Name, nameof(leadLabel.Name));
            Ensure.ArgumentNotNull(leadLabel.Color, nameof(leadLabel.Color));

            return ApiConnection.Post<LeadLabel>(ApiUrls.LeadLabels(), leadLabel);
        }

        public Task Delete(Guid id)
            => ApiConnection.Delete(ApiUrls.LeadLabel(id));
    }
}
