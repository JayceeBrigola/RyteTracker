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
using RyteTracker.main;

namespace RyteTracker
{
    /// <summary>
    /// Interaction logic for CalorieCounter.xaml
    /// </summary>
    public partial class CalorieCounter : UserControl
    {
        public ObservableCollection<FoodItem> ItemsList { get; set; } = new ObservableCollection<FoodItem>();

        public CalorieCounter()
        {
            InitializeComponent();
            itemsDataGrid.ItemsSource = ItemsList;
        }

        private void addItems_button_Click(object sender, RoutedEventArgs e)
        {
            // Prompt user to input food and calories
            string food = Microsoft.VisualBasic.Interaction.InputBox("Enter the food:", "Add Item", "");
            if (string.IsNullOrWhiteSpace(food))
                return;

            int calories;
            if (!int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Enter the calories:", "Add Item", ""), out calories))
            {
                MessageBox.Show("Invalid calories. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new FoodItem instance based on user input
            FoodItem newItem = GetFoodItem(food, calories);
            if (newItem != null)
            {
                // Add the newly created food item to the list
                ItemsList.Add(newItem);

                // Calculate and display the total calories
                int totalCalories = ItemsList.Sum(item => item.Calories);
                totalCaloriesTextBlock.Text = $"Total Calories: {totalCalories}";

                // Save the list of food and calories to a file
                SaveItemsToFile();
            }
        }

        private FoodItem GetFoodItem(string food, int calories)
        {
            // Prompt user to select food type
            MessageBoxResult result = MessageBox.Show("Is it a fruit?", "Food Type", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    return new Fruit(food, calories);
                case MessageBoxResult.No:
                    return new Vegetable(food, calories);
                default:
                    return null;
            }
        }

        private void SaveItemsToFile()
        {
            // Get the path where the file will be saved
            string filePath = "calories.txt";

            // Write the items to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in ItemsList)
                {
                    writer.WriteLine($"{item.GetFoodType()},{item.Name},{item.Calories}");
                }
            }
        }
    }

    public abstract class FoodItem
    {
        public string Name { get; set; }
        public int Calories { get; set; }

        protected FoodItem(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public abstract string GetFoodType();
    }

    public class Fruit : FoodItem
    {
        public Fruit(string name, int calories) : base(name, calories) { }

        public override string GetFoodType()
        {
            return "Fruit";
        }
    }

    public class Vegetable : FoodItem
    {
        public Vegetable(string name, int calories) : base(name, calories) { }

        public override string GetFoodType()
        {
            return "Vegetable";
        }
    }
}

