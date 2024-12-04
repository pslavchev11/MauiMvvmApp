using MAUI.ViewModels;

namespace MAUI.Components;

public partial class DisplayLogs : ContentView
{
	public DisplayLogs()
	{
		InitializeComponent();
		BindingContext = new LogEntityViewModel();
	}
}