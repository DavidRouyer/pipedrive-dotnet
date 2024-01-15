﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Models.Response.Leads;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Lead API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Leads">Lead API documentation</a> for more information.
    public interface ILeadsClient
    {
        Task<IReadOnlyList<Lead>> GetAll(LeadFilters filters);

        Task<Lead> Get(Guid id);

        Task<Lead> Create(NewLead newLead);
    }
}
