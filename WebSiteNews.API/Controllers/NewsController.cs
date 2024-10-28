using Microsoft.AspNetCore.Mvc;
using WebSiteNews.API.Contracts;
using WebSiteNews.BL;
using WebSiteNews.Core.Models;

namespace WebSiteNews.API.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController(NewsService newsService, ImageService imageService) : ControllerBase
{
    private readonly string _staticFilePath = "/images";
    
    [HttpPost]
    public async Task<ActionResult> CreateNews(NewsRequest request)
    {
        var imageResult = await imageService.CreateImage(request.TitleImage, _staticFilePath);

        if (imageResult.IsFailure)
        {
            return BadRequest(imageResult.Error);
        }

        var news = News.Create(Guid.NewGuid(), request.Title, request.TextData, imageResult.Value);

        if (news.IsFailure)
        {
            return BadRequest(news.Error);
        }
        
        return Ok(news);
    }
}

