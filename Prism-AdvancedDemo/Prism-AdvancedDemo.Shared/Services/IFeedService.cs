using System.Collections.Generic;
using System.Threading.Tasks;
using Prism_AdvancedDemo.Entities;

namespace Prism_AdvancedDemo.Services
{
    public interface IFeedService
    {
        Task<IEnumerable<News>> GetNews();
    }
}
