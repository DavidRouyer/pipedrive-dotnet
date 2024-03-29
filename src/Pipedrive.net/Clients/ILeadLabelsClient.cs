﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Lead Label API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/LeadLabels">Lead Label API documentation</a> for more information.
    public interface ILeadLabelsClient
    {
        Task<IReadOnlyList<LeadLabel>> GetAll();
    }
}
