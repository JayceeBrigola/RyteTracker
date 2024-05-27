using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyteTracker.main
{
    // encapuslation and abstraction of data 
    public class UserProfile
    {
        private string gender; // backing field for the Gender property

        public Gender Gender
        {
            get
            {
                return (Gender)Enum.Parse(typeof(Gender), gender);
            }
            set
            {
                gender = value.ToString();
            }
        }

        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public double BMI { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}
