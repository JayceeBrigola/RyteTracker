using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for UserInformation.xaml
    /// </summary>
    public partial class UserInformation : UserControl
    {
        public UserInformation()
        {
            InitializeComponent();
            LoadUserData();
        }

        // Method to load user data into textboxes
        private void LoadUserData()
        {
            UserProfile userProfile = UserDataHandler.ReadUserProfile();
            if (userProfile != null)
            {
                nameUI_txtbox.Text = userProfile.Name;
                heightUI_txtbox.Text = userProfile.Height.ToString();
                weightUI_txtbox.Text = userProfile.Weight.ToString();
                ageUI_txtbox.Text = userProfile.Age.ToString();
                bmiUI_txtbox.Text = userProfile.BMI.ToString();
                genderUI_txtbox.Text = userProfile.Gender.ToString();
            }
        }
    }
}
