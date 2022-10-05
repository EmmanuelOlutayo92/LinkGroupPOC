using LinkGroup.ScrewAFix.Services.Interfaces;
using LinkGroup.ScrewAFix.Services.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkGroup.ScrewAFix.Services.Requests
{
    public class ServiceRequestHandlerAsync : IRequestHandler<ServiceRequestAsync, IServiceResponse>
    {
        public async Task<IServiceResponse> Handle(ServiceRequestAsync request, CancellationToken cancellationToken)
        {
            IServiceResponse serviceResponse = new ServiceResponse();
            await Task.WhenAll((IEnumerable<Task>)serviceResponse);
            return serviceResponse;
        }
    }
}
