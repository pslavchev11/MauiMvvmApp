using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MAUI.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand NavigateToUsersCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync("//UsersPage");
        });

        public ICommand NavigateToLogsCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync("//LogsPage");
        });
    }
}
