using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DataLayer.Model;
using DataLayer.Services;
using Microsoft.Maui.Controls;

namespace MAUI.ViewModels
{
    public class LogEntityViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<LogEntity> _logEntities;
        public ObservableCollection<LogEntity> LogEntities
        {
            get { return _logEntities; }
            set { _logEntities = value; OnPropertyChanged(); }
        }

        private ObservableCollection<LogEntity> _filteredLogs;
        public ObservableCollection<LogEntity> FilteredLogs
        {
            get { return _filteredLogs; }
            set { _filteredLogs = value; OnPropertyChanged(); }
        }

        private LogEntity _selectionEntity;
        public LogEntity SelectionEntity
        {
            get { return _selectionEntity; }
            set
            {
                if (value != _selectionEntity)
                {
                    _selectionEntity = value;
                    OnPropertyChanged();
                    ListLogDetails(SelectionEntity);
                }
            }
        }

        private List<string> _messageTypes;
        public List<string> MessageTypes
        {
            get { return _messageTypes; }
            set { _messageTypes = value; OnPropertyChanged(); }
        }

        private string _selectedMessageType;
        public string SelectedMessageType
        {
            get { return _selectedMessageType; }
            set
            {
                if (value != _selectedMessageType)
                {
                    _selectedMessageType = value;
                    OnPropertyChanged();
                    ApplyFilters();
                }
            }
        }

        public ICommand SortLogsCommand { get; }

        public LogEntityViewModel()
        {
            // Load logs
            var logs = DataService.findAllLogs();
            LogEntities = new ObservableCollection<LogEntity>(logs);

            // Initialize filtered logs with all logs
            FilteredLogs = new ObservableCollection<LogEntity>(LogEntities);

            // Populate message types for the filter
            MessageTypes = LogEntities.Select(l => l.MessageType).Distinct().ToList();
            MessageTypes.Insert(0, "All"); // Add "All" option to show all logs
            SelectedMessageType = "All";  // Default filter

            // Initialize sorting command
            SortLogsCommand = new Command(SortLogs);
        }

        private void ApplyFilters()
        {
            if (SelectedMessageType == "All")
            {
                // No filter applied
                FilteredLogs = new ObservableCollection<LogEntity>(LogEntities);
            }
            else
            {
                // Filter logs by selected message type
                FilteredLogs = new ObservableCollection<LogEntity>(
                    LogEntities.Where(log => log.MessageType == SelectedMessageType));
            }
        }

        private void SortLogs()
        {
            // Sort logs by date descending
            FilteredLogs = new ObservableCollection<LogEntity>(
                FilteredLogs.OrderByDescending(log => log.Time));
        }

        private static void ListLogDetails(object obj)
        {
            var selectedLog = obj as LogEntity;
            if (selectedLog != null && Application.Current?.MainPage != null)
            {
                Application.Current.MainPage.DisplayAlert("Details",
                    $"Id: {selectedLog.Id}\nDate: [{selectedLog.Time:yyyy-MM-dd HH:mm:ss}]\nEvent Type: {selectedLog.MessageType}\nMessage: {selectedLog.Message}",
                    "Close");
            }
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
