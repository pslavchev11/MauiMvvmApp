using MAUI.ViewModels;

namespace MAUI.Components;

public partial class DisplayUsers : ContentView
{
	public DisplayUsers()
	{
		InitializeComponent();
		BindingContext = new DatabaseUserViewModel();
	}
}