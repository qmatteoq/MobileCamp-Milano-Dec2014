using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MVVMLightDesignData.Entities;

namespace MVVMLightDesignData.Services
{
    public class FakeFeedService : IFeedService
    {
        public IEnumerable<News> GetNews()
        {
            List<News> list = new List<News>
            {
                new News
                {
                    Title = "Test 1",
                    Summary = "Summary 1"
                },
                new News
                {
                    Title = "Test 2",
                    Summary = "Summary 2"
                },
                new News
                {
                    Title = "Test 3",
                    Summary = "Summary 3"
                }
            };

            return list;
        }
    }
}
