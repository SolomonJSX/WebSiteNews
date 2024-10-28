using CSharpFunctionalExtensions;

namespace WebSiteNews.Core.Models;

public class News
{
    public const int MAX_TITLE_LENGTH = 100;
    
    private readonly List<Image> _news;
    
    private News(Guid id, string title, string textData, DateTime createdDate, Image? titleImage)
    {
        Id = id;
        Title = title;
        TextData = textData;
        CreatedDate = createdDate;
        TitleImage = titleImage;
    }
    
    public Guid Id { get;}
    public string Title { get; } = string.Empty;
    public string TextData { get; } = string.Empty;
    public DateTime CreatedDate { get; }
    public int Views { get; private set; } = 0;
    public Image? TitleImage { get; }

    public IReadOnlyCollection<Image> Images => _news;

    public void AddImages(List<Image> images) => _news.AddRange(images); 
    
    public void CountView() => Views++;
    
    public static Result<News> Create(Guid id, string title, string textData,
        Image? titleImage)
    {
        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            return Result.Failure<News>($"{nameof(title)} cannot be null or empty");
        }
        
        if (string.IsNullOrEmpty(textData) || textData.Length > MAX_TITLE_LENGTH)
        {
            return Result.Failure<News>($"{nameof(title)} cannot be null or empty");
        }

        var news = new News(id, title, textData, DateTime.Now, titleImage);
        
        return Result.Success(news);
    }
}