using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinkGroup.ScrewAFix.Services.Interfaces
{
    public interface IHttpRequestHandler
    {
        public Task<IServiceResponse> RestAPiCallPost(IServiceRequestDetails request, string endpoint);
    }
}
