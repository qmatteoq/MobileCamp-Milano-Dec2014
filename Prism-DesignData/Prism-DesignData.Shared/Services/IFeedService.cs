using System.Collections.Generic;
using Prism_DesignData.Entities;

namespace Prism_DesignData.Services
{
    public interface IFeedService
    {
        IEnumerable<News> GetNews();
    }
}
