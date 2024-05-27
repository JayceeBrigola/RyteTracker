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
    /// Interaction logic for Exercises.xaml
    /// </summary>
    public partial class Exercises : UserControl
    {
        public ObservableCollection<string> GoalsList { get; set; } = new ObservableCollection<string>();

        public Exercises()
        {
            InitializeComponent();
            exercisesDataGrid.ItemsSource = GoalsList;
        }

        private void addExercise_button_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to add goal
            string newExercise = Microsoft.VisualBasic.Interaction.InputBox("Enter your desired Exercise:", "Add Exercise", "");

            // Add the new goal to the list
            if (!string.IsNullOrWhiteSpace(newExercise))
            {
                GoalsList.Add(newExercise);
                SaveExerciseToFile();
            }
        }

        private void SaveExerciseToFile()
        {
            // Get the path where the file will be saved
            string filePath = "Exercises.txt";

            // Write the goals to the file
            File.WriteAllLines(filePath, GoalsList);
        }
    }
}
