using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace RyteTracker
{
    /// <summary>
    /// Interaction logic for SleepTracker.xaml
    /// </summary>
    public partial class SleepTracker : UserControl
    {
        public ObservableCollection<SleepRecord> SleepRecordsList { get; set; } = new ObservableCollection<SleepRecord>();

        public SleepTracker()
        {
            InitializeComponent();
            sleepRecordDataGrid.ItemsSource = SleepRecordsList;
        }

        private void addRecord_button_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to input sleep record details
            DateTime date = DateTime.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the date (MM/dd/yyyy):", "Add Record", ""));
            DateTime sleepTime = DateTime.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the time of sleep (HH:mm):", "Add Record", ""));
            DateTime wakeUpTime = DateTime.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the wake-up time (HH:mm):", "Add Record", ""));

            // Check if wake-up time is earlier than sleep time (e.g., sleeping across midnight)
            if (wakeUpTime < sleepTime)
            {
                wakeUpTime = wakeUpTime.AddDays(1); // Add a day to wake-up time
            }

            // Calculate sleep duration
            TimeSpan duration = wakeUpTime - sleepTime;

            // Add the sleep record to the list
            SleepRecordsList.Add(new SleepRecord(date, sleepTime, wakeUpTime, duration));

            // Save the list of sleep records to a file
            SaveSleepRecordsToFile();
        }


        private void SaveSleepRecordsToFile()
        {
            // Get the path where the file will be saved
            string filePath = "sleep_records.txt";

            // Write the sleep records to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var record in SleepRecordsList)
                {
                    writer.WriteLine($"{record.Date.ToShortDateString()},{record.SleepTime.ToShortTimeString()},{record.WakeUpTime.ToShortTimeString()},{record.Duration.TotalHours}");
                }
            }
        }
    }

    public class SleepRecord
    {
        public DateTime Date { get; }
        public DateTime SleepTime { get; }
        public DateTime WakeUpTime { get; }
        public TimeSpan Duration { get; }

        public SleepRecord(DateTime date, DateTime sleepTime, DateTime wakeUpTime, TimeSpan duration)
        {
            Date = date;
            SleepTime = sleepTime;
            WakeUpTime = wakeUpTime;
            Duration = duration;
        }
    }
}

