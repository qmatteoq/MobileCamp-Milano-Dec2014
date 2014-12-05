using System.Collections.Generic;
using Prism_DesignData.Entities;

namespace Prism_DesignData.Services
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
