using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Caliburn_AdvancedDemo.Entities;

namespace Caliburn_AdvancedDemo.Services
{
    public interface IFeedService
    {
        Task<IEnumerable<News>> GetNews();
    }
}
