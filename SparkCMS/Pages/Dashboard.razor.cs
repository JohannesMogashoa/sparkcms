using Microsoft.AspNetCore.Components;
using SparkCMS.Application.Models;
using SparkCMS.Pages.Shared;

namespace SparkCMS.Pages;

public partial class Dashboard
{
    [CascadingParameter] public MainLayout? Layout { get; set; }
    private User? user => Layout.User;
}