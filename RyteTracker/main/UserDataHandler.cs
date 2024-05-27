using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RyteTracker.main
{
    class UserDataHandler
    {
        private const string FilePath = "userdata.txt";

        public static void SaveUserProfile(UserProfile userProfile)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine($"{userProfile.Gender}, {userProfile.Name},{userProfile.Height},{userProfile.Weight},{userProfile.Age},{userProfile.BMI}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while saving user data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to read user profile data from file
        public static UserProfile ReadUserProfile()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 6)
                            {
                                Gender gender;
                                if (Enum.TryParse(parts[0].Trim(), out gender))
                                {
                                    string name = parts[1].Trim();
                                    double height, weight, bmi;
                                    int age;
                                    if (double.TryParse(parts[2].Trim(), out height) &&
                                        double.TryParse(parts[3].Trim(), out weight) &&
                                        int.TryParse(parts[4].Trim(), out age) &&
                                        double.TryParse(parts[5].Trim(), out bmi))
                                    {
                                        return new UserProfile
                                        {
                                            Gender = gender,
                                            Name = name,
                                            Height = height,
                                            Weight = weight,
                                            Age = age,
                                            BMI = bmi
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User data file does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while reading user data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }
    }
}
