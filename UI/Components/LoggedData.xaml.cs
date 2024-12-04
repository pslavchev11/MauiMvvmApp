using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer.Database;
using DataLayer.Model;
using SQLitePCL;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for LoggedData.xaml
    /// </summary>
    public partial class LoggedData : UserControl
    {
        public LoggedData()
        {
            InitializeComponent();
            using (var context = new DatabaseContext())
            {
                var records = context.Logs.ToList();
                logs.DataContext = records;
            }
        }

        private void logs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (logs.SelectedItem != null)
            {
                LogEntity selectedLog = (LogEntity)logs.SelectedItem;

                string logString = $"Time: {selectedLog.Time} " +
                                   $"Message Type: {selectedLog.MessageType} " +
                                   $"Message: {selectedLog.Message}";

                hidden.Text = logString;
                hidden.Visibility = Visibility.Visible;
            }
        }
    }
}
