using System;
using PreezieInterview.Api.Models.DbModels;

namespace PreezieInterview.Api.Repositories
{
    public abstract class ServiceBase<T> where T : DbModel
    {
        public ServiceBase(IServiceProvider provider)
        {
            ApiContext = (ApiContext)provider.GetService(typeof(ApiContext));
        }

        protected ApiContext ApiContext { get; private set; }
    }
}
