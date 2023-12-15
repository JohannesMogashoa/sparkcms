using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Spark.Library.Extensions;
using SparkCMS.Application.Database;
using SparkCMS.Application.Models;
using SparkCMS.Pages.Shared;

namespace SparkCMS.Pages;

public partial class Dashboard
{
    [CascadingParameter] public MainLayout? Layout { get; set; }
    [Inject] IDbContextFactory<DatabaseContext> Factory { get; set; } = default!;
    [Inject] NavigationManager NavManager { get; set; } = default!;
    private User? user => Layout.User;
    private CreateSparkModel sparkModelForm { get; set; } = new();
    private List<Spaark>? Sparks { get; set; }

    private bool isEditMode { get; set; } = false;

    public class CreateSparkModel
    {
        public int? Id { get; set; }
        [Required] public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        public string? Tags { get; set; }
    }

    protected override async Task OnInitializedAsync()
    {
        await using var db = await Factory.CreateDbContextAsync();
        Sparks = db.Sparks.ToList();
    }

    private async Task HandleFormSubmit()
    {
        await using var db = await Factory.CreateDbContextAsync();

        if (!isEditMode)
        {
            var currentUser = await db.Users.FindAsync(user.Id);

            var spark = new Spaark
            {
                Title = sparkModelForm.Name,
                Description = sparkModelForm.Description,
                User = currentUser,
                Tags = sparkModelForm.Tags
            };
            db.Sparks.Save(spark);
        }
        else
        {
            var dbSpark = await db.Sparks.FindAsync(sparkModelForm.Id);
            dbSpark.Title = sparkModelForm.Name;
            dbSpark.Description = sparkModelForm.Description;
            dbSpark.Tags = sparkModelForm.Tags;

            db.Sparks.Save(dbSpark);
        }
        StateHasChanged();
        NavManager.NavigateTo(NavManager.Uri, true);
    }

    private async Task EditSpark(Spaark spark)
    {
        isEditMode = true;

        sparkModelForm.Name = spark.Title;
        sparkModelForm.Id = spark.Id;
        sparkModelForm.Description = spark.Description;
        sparkModelForm.Tags = spark.Tags;

        StateHasChanged();
    }

    private void CancelUpdate()
    {
        isEditMode = false;
        sparkModelForm = new CreateSparkModel();
        StateHasChanged();
    }
}