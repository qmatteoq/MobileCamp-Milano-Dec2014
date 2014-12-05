using System.Collections.Generic;
using System.Threading.Tasks;
using Prism_AdvancedDemo.Entities;

namespace Prism_AdvancedDemo.Services
{
    public class FakeFeedService : IFeedService
    {
        public async Task<IEnumerable<News>> GetNews()
        {
            List<News> news = new List<News>
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
                }
            };

            return await Task.FromResult(news);
        }
    }
}
