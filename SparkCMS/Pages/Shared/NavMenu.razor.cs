using Microsoft.AspNetCore.Components;
using SparkCMS.Application.Models;

namespace SparkCMS.Pages.Shared;

public partial class NavMenu
{
    [CascadingParameter] public MainLayout? Layout { get; set; }
    private User? user => Layout?.User;
}