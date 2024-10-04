using System;

namespace Lektion_SUT24_241031_Anas
{
    public partial class PartialEmployee
    {

        // Tog bort one i namnet ovan men låter det va kvar i filen.

        private string _firstName;
        private string _lastName;
        private double _salary;
        private string _gender;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

    }
}
