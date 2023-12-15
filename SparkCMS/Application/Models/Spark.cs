using Spark.Library.Database;

namespace SparkCMS.Application.Models;

public class Spaark : BaseModel
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public User User { get; set; }
    public List<SparkContent>? SparkContents { get; set; }
    public string? Tags { get; set; }
}