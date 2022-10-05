using LinkGroup.ScrewAFix.Services.Interfaces;
using LinkGroup.ScrewAFix.Services.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGroup.ScrewAFix.Services.Requests
{
    public class ServiceRequestAsync : IRequest<ServiceResponse>
    {
        public CustomerRequest CustomerRequest { get; set; }
    }
}
