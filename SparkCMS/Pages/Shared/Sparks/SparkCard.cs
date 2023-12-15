using Microsoft.AspNetCore.Components;
using SparkCMS.Application.Models;

namespace SparkCMS.Pages.Shared.Sparks;

public partial class SparkCard
{
    [Parameter] public Spaark Spark { get; set; }
    [Parameter] public EventCallback<Spaark> ModifySpark { get; set; }
}