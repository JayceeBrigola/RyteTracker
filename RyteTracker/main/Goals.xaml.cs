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
    /// Interaction logic for Goals.xaml
    /// </summary>
    public partial class Goals : UserControl
    {
        public ObservableCollection<string> GoalsList { get; set; } = new ObservableCollection<string>();

        public Goals()
        {
            InitializeComponent();
            goalsDataGrid.ItemsSource = GoalsList;
        }

        private void addGoal_button_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to add goal
            string newGoal = Microsoft.VisualBasic.Interaction.InputBox("Enter your new goal:", "Add Goal", "");

            // Add the new goal to the list
            if (!string.IsNullOrWhiteSpace(newGoal))
            {
                GoalsList.Add(newGoal);
                SaveGoalsToFile();
            }
        }

        private void SaveGoalsToFile()
        {
            // Get the path where the file will be saved
            string filePath = "Goals.txt";

            // Write the goals to the file
            File.WriteAllLines(filePath, GoalsList);
        }
    }
}
