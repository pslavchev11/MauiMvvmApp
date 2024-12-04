using MAUI.ViewModels;

namespace MAUI.Views;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
		BindingContext = new DatabaseUserViewModel();
	}
}