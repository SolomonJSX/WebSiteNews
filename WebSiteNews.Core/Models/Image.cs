using CSharpFunctionalExtensions;

namespace WebSiteNews.Core.Models;

public class Image
{
    public Image(string fileName)
    {
        FileName = fileName;
    }
    
    public Guid NewsId { get; set; }
    public string FileName { get; set; } = string.Empty;

    public static Result<Image> Create(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return Result.Failure<Image>($"{nameof(fileName)} cannot be null or empty");
        }
        
        var image = new Image(fileName);
        return Result.Success(image);
    }
}