using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using SparkCMS.Application.Database;
using SparkCMS.Application.Models;
using SparkCMS.Extensions;

namespace SparkCMS.Pages.Sparks;

public partial class Content
{
    [Inject] private NavigationManager NavManager { get; set; } = default!;
    [Inject] private IDbContextFactory<DatabaseContext> Factory { get; set; } = default!;
    private int? SparkId { get; set; }
    public Spaark Spark { get; set; }
    private ContentCreateModel contentModelForm { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        SparkId = int.Parse(NavManager.QueryString("sparkId"));
        await using var db = await Factory.CreateDbContextAsync();
        Spark = await db.Sparks.Where(x => x.Id.Equals(SparkId))
            .Include(x => x.SparkContents)
            .FirstOrDefaultAsync();
    }

    private void HandleFormSubmit()
    {
    }

    private class ContentCreateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Content { get; set; }
    }
}