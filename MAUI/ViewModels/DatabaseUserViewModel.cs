using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DataLayer.Model;
using DataLayer.Services;
using Welcome.Others; // Make sure this namespace is included for the UserRolesEnum

namespace MAUI.ViewModels
{
    public class DatabaseUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<DatabaseUser> _users;
        public ObservableCollection<DatabaseUser> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged(); }
        }

        private ObservableCollection<DatabaseUser> _filteredUsers;
        public ObservableCollection<DatabaseUser> FilteredUsers
        {
            get { return _filteredUsers; }
            set { _filteredUsers = value; OnPropertyChanged(); }
        }

        private UserRolesEnum _selectedRole;
        public UserRolesEnum SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                if (_selectedRole != value)
                {
                    _selectedRole = value;
                    OnPropertyChanged();
                    ApplyFilters();
                }
            }
        }

        public List<UserRolesEnum> Roles { get; private set; }

        public DatabaseUserViewModel()
        {
            // Fetch users from the data layer
            var users = DataService.findAllUsers();
            Users = new ObservableCollection<DatabaseUser>(users);

            // Initially, show all users
            FilteredUsers = new ObservableCollection<DatabaseUser>(Users);

            // Define roles using the enum
            Roles = Enum.GetValues(typeof(UserRolesEnum)).Cast<UserRolesEnum>().ToList();
            SelectedRole = UserRolesEnum.ALL; // Default role to show all users
        }

        private void ApplyFilters()
        {
            IEnumerable<DatabaseUser> filtered;

            // Filter based on the selected role
            if (SelectedRole == UserRolesEnum.ALL)
            {
                filtered = Users;
            }
            else
            {
                filtered = Users.Where(user => user.Role == SelectedRole);
            }

            // Update the filtered users collection
            FilteredUsers = new ObservableCollection<DatabaseUser>(filtered);
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
