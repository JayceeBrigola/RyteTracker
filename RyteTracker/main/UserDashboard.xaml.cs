using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace RyteTracker.main
{
    /// <summary>
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Window
    {
        public UserDashboard(string selectedProfileImageSource, string name)
        {
            InitializeComponent();
     
            // Set the selected profile image
            dashboardProfile_img.Source = new BitmapImage(new Uri(selectedProfileImageSource, UriKind.RelativeOrAbsolute));

            // Set the name
            nameDashboard_txtblock.Text = name;
        }

        private void logout_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void goals_button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Goals();
        }

        private void exercises_button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new Exercises();
        }

        private void calorieCounter_button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new CalorieCounter();
        }

        private void sleepTracker_button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new SleepTracker();
        }

        private void userInformation_button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UserInformation();

        }

    }
}

