using CommunityToolkit.Mvvm.ComponentModel;

namespace ClothRentingStore.UI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _appTitle = "Cloth Renting Store Management";

    [ObservableProperty]
    private string _subtitle = "Native Desktop Application - .NET 9 & WPF-UI Fluent Design";
}
