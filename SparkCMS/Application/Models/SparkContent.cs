using Spark.Library.Database;

namespace SparkCMS.Application.Models;

public class SparkContent : BaseModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Content { get; set; }
}