using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using WebSiteNews.Core.Models;
using Exception = System.Exception;

namespace WebSiteNews.BL;

public class ImageService
{
    public async Task<Result<Image>> CreateImage(IFormFile titleImage, string path)
    {
        try
        {
            var fileName = Path.GetFileName(titleImage.FileName);
            var filePath = Path.Combine(path, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await titleImage.CopyToAsync(stream);
            }

            var image = Image.Create(filePath);

            return image;
        }
        catch (Exception ex)
        {
            return Result.Failure<Image>(ex.Message);
        }
    } 
}