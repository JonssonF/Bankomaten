using System;

namespace Lektion_SUT24_241031_Anas
{
    public partial class PartialEmployee
    {
        public void DisplayEmployeeData()
        {
            Console.WriteLine("Employee Details : ");
            Console.WriteLine("First Name : {0}", _firstName);
            Console.WriteLine("Last Name : {0}", _lastName);
            Console.WriteLine("Salary : {0}", _salary);
        }

    }
}
