using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RyteTracker.main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserProfile userProfile = new UserProfile();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void signup_button_Click(object sender, RoutedEventArgs e)
        {
            // Parse height
            if (double.TryParse(height_txtbox.Text, out double height))
            {
                userProfile.Height = height;
            }
            else
            {
                MessageBox.Show("Invalid height value. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Exit the method early if parsing fails
            }

            // Parse weight
            if (double.TryParse(weight_txtbox.Text, out double weight))
            {
                userProfile.Weight = weight;
            }
            else
            {
                MessageBox.Show("Invalid weight value. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Exit the method early if parsing fails
            }

            // Parse age
            if (int.TryParse(age_txtbox.Text, out int age))
            {
                userProfile.Age = age;
            }
            else
            {
                MessageBox.Show("Invalid age value. Please enter a valid integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Exit the method early if parsing fails
            }

            // Parse BMI
            if (double.TryParse(bmi_txtbox.Text, out double bmi))
            {
                userProfile.BMI = bmi;
            }
            else
            {
                MessageBox.Show("Invalid BMI value. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Exit the method early if parsing fails
            }

            // Assign name directly since it's a string
            userProfile.Name = name_txtbox.Text;

            // Save user profile
            UserDataHandler.SaveUserProfile(userProfile);

            MessageBoxResult result = MessageBox.Show("Profile successfully created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                string selectedProfileImageSource;
                if (userProfile.Gender == Gender.Male)
                {
                    selectedProfileImageSource = "/images/Male Profile.png";
                }
                else
                {
                    selectedProfileImageSource = "/images/Female Profile.png";
                }

                // Open new window and pass selected profile image and name
                UserDashboard userDashboard = new UserDashboard(selectedProfileImageSource, name: name_txtbox.Text);
                userDashboard.Show();
                this.Close();
            }
        }

        private void maleProfile_img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            male_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#424874"));
            female_border.Background = Brushes.Transparent;

            userProfile.Gender = Gender.Male;
        }

        private void femaleProfile_img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            female_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#424874"));
            male_border.Background = Brushes.Transparent;

            userProfile.Gender = Gender.Female;
        }

        [STAThread]
        public static void Main()
        {
            // Create and run your application
            var app = new Application();
            app.Run(new MainWindow());
        }
    }
}