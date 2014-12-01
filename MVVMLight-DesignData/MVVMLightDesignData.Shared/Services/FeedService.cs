using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using MVVMLightDesignData.Entities;

namespace MVVMLightDesignData.Services
{
    public class FeedService : IFeedService
    {
        public IEnumerable<News> GetNews()
        {
            List<News> list = new List<News>
            {
                new News
                {
                    Title = "Title 1",
                    Summary = "Summary 1"
                },
                new News
                {
                    Title = "Title 2",
                    Summary = "Summary 2"
                },
                new News
                {
                    Title = "Title 3",
                    Summary = "Summary 3"
                }
            };

            return list;
        }
    }
}
