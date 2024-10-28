using System.ComponentModel.DataAnnotations;
using WebSiteNews.Core.Models;

namespace WebSiteNews.API.Contracts;

public record NewsRequest(
    [Required][MaxLength(News.MAX_TITLE_LENGTH)] string Title,
    [Required] string TextData,
    IFormFile TitleImage
    );