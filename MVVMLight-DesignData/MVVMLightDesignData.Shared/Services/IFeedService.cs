using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MVVMLightDesignData.Entities;

namespace MVVMLightDesignData.Services
{
    public interface IFeedService
    {
        IEnumerable<News> GetNews();
    }
}
