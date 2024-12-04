using MAUI.ViewModels;

namespace MAUI.Views;

public partial class LogPage : ContentPage
{
	public LogPage()
	{
		InitializeComponent();
		BindingContext = new LogEntityViewModel();
	}
}