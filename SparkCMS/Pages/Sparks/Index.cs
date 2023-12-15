using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using SparkCMS.Application.Database;
using SparkCMS.Application.Models;
using SparkCMS.Pages.Shared;

namespace SparkCMS.Pages.Sparks;

public partial class Index
{
    [Parameter] public int Id { get; set; }
    [CascadingParameter] public MainLayout? Layout { get; set; }
    [Inject] private IDbContextFactory<DatabaseContext> Factory { get; set; } = default!;

    private Spaark spark { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await using var db = await Factory.CreateDbContextAsync();
        spark = await db.Sparks.Where(x => x.Id.Equals(Id))
            .Include(x => x.SparkContents)
            .FirstOrDefaultAsync();
    }
}