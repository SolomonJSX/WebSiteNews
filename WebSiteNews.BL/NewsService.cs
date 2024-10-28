using WebSiteNews.Core.Models;

namespace WebSiteNews.BL;

public class NewsService
{
    public async Task CountViews(News news)
    {
        news.CountView();
    }
}