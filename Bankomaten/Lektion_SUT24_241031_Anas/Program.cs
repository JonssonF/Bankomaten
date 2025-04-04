using System;

namespace Lektion_SUT24_241031_Anas
{
    struct Book
    {
        public int Id;
        public string Title;
        public string Author;
        public string Subject;

        public void DisplayData()
        {
            Console.WriteLine("Title : {0}", Title);
            Console.WriteLine("Author : {0}", Author);
            Console.WriteLine("Subject : {0}", Subject);          
        }

    }

    interface IStudent // Kan ärva ifrån interface.
    {

    }
    struct Student : IStudent /*: Book */   // Kan inte ärva ifrån struct, är i grund och botten en sealed.
    {
        private int _id;
        private string _name;

        public int ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public Student(int i, string n)
        {
            _id = i;
            _name = n;
        }

        public void PrintDetails()
        {
            Console.WriteLine("ID = {0} Name = {1}", _id, _name);
        }

        /*~Student*/ // En struct kan inte använda sig utav en destruktor, för att rensa minnet då det redan finns, men klasser kan.

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*---------------------------::S T R U C T  C L A S S::---------------------------*/

            //Struct använder mindre minne, är lämpligt för små program. 


            Book book1;
            Book book2;
            Book book3;


            //Book 1
            book1.Id = 1;
            book1.Title = "C# Programming";
            book1.Author = "John Doe";
            book1.Subject = "Programming";
            book1.DisplayData();



            /*---------------------------::P A R T I A L  C L A S S::---------------------------*/
            // Varje designpattern använder en egen typ av klass.

            //Partial class. Ett sätt att använda en instans till flera klasser, viktigt att lägga till Partial och att namnet är detsamma. Bra i grupp och när arbetet är stort.
            /*
            Employee emp = new Employee();
            emp.FirstName = "John";
            emp.LastName = "Doe";
            emp.DisplayFullName();

            PartialEmployee partialEmployee = new PartialEmployee();
            partialEmployee.FirstName = "Freddy";
            partialEmployee.LastName = "FourFingers";
            partialEmployee.Salary = 10000;
            partialEmployee.DisplayEmployeeData();
            */

            /*---------------------------::S E A L E D  C L A S S::---------------------------*/

            // Sealed class är alltid sist i hiearkin, Abstract är alltid först, kan inte implimenteras men måste ärvas, Sealed är slutet.


            /*Utility u = new Utility(); // Man kan skapa en instans direkt ifrån sealed klass, men kan inte ärvas ifrån.
            u.PrintMessage("Hello World !!!!");*/

            /* C c = new C();
             c.GetInfo();*/


            // Create a saving account object.

            /*SavingAccount savingAccount = new SavingAccount(12345, 1000m, 0.05m);

            savingAccount.Deposit(200m);
            savingAccount.Withdrawal(50m);
            savingAccount.ApplyIntereset();*/




            Console.ReadKey();
        }
    }
    public sealed class Utility
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class A /*: Utility*/   // Går inte ärva ifrån sealed class.
    {
        public virtual void GetInfo()
        {
            Console.WriteLine("Base Class A Method !!!!!!!");
        }
        public virtual void Test()
        {
            Console.WriteLine("Base Class A Test Method");
        }
    }

    public class B : A 
    { 
        public /*sealed*/ override void GetInfo() // Sealed method går inte att overrida. Kan inte ärva ifrån.
        {
            Console.WriteLine("Derived Class B Method !!!!!!!");
        }
        public override void Test()
        {
            Console.WriteLine("Derived Class B Method Test !!!!!!!");
        }
    }

    public class C : B
    {
        public override void GetInfo()
        {
            Console.WriteLine("Derived Class C Method !!!!!!!");
        }
        public override void Test()
        {
            Console.WriteLine("Derived Class C Method Test !!!!!!!");
        }
    }
}
