namespace Bankomaten        //Fredrik Jonsson SUT_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void menuOption()
            {
                Console.WriteLine("Please choose one of the following options.");
                Console.WriteLine("1. Show balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Exit");
            }

            string[,] userName = new string[5, 3] { { "0", "John", "1231" }, { "1", "Jane", "1232" }, { "2", "Jenny", "1233" }, { "3", "James", "1234" }, { "4", "Joel", "1235" } };
            int[] userPin = { 1231, 1232, 1233, 1234, 1235 };


            bool bankEngine = true;
            while (bankEngine)
            {
                Console.WriteLine("Welcome to the bank:\n\n" +
                    "Please enter your ID and pincode.\n\n");
                Console.Write("Enter ID:");
                int verifyUser = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Hi, {userName[verifyUser, 1]}, please enter your pincode:");
                int verifyPin = Convert.ToInt32(Console.ReadLine());
                int loginAttempt = 0;
                bool loginSuccess = false;

                while (loginSuccess == false || loginAttempt <= 3)
                {
                    if (verifyPin == userPin[verifyUser])
                    {
                        Console.WriteLine("Pincode accepted.");
                        Thread.Sleep(2500);
                        Console.Clear();
                        loginSuccess = true;
                        while (loginSuccess == true)
                        {
                            menuOption();
                            string menuChoice = Console.ReadLine();
                        }
                    }
                    else if (loginAttempt == 3)
                    {
                        Console.WriteLine("Access denied.");
                        Thread.Sleep(2500);
                        bankEngine = false;
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        loginAttempt++;
                        Console.Clear();
                        Console.Write("Wrong pincode, try again: ");
                        verifyPin = Convert.ToInt32(Console.ReadLine());
                    }

                }
                


            }
        }

        


    }
}
