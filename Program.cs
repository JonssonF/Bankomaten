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
                Console.WriteLine("5. Logout");
            }

            string[,] userName = new string[5, 3] { { "0", "John", "1231" }, { "1", "Jane", "1232" }, { "2", "Jenny", "1233" }, { "3", "James", "1234" }, { "4", "Joel", "1235" } };
            int[] userPin = { 1231, 1232, 1233, 1234, 1235 };


            bool bankEngine = true;
            while (bankEngine == true)
            {
                Console.WriteLine("Welcome to the bank:\n\n" +
                    "Please enter your ID and pincode.\n\n");
                Console.Write("Enter ID:");
                int verifyUser = Convert.ToInt32(Console.ReadLine());
                if (verifyUser >= 5)
                {
                    Console.WriteLine("We don't have so many accounts at the moment.");
                }
                else
                {
                    Console.Write($"Hi, {userName[verifyUser, 1]}, please enter your pincode:");
                    int verifyPin = Convert.ToInt32(Console.ReadLine());
                    int loginAttempt = 0;
                    bool loginSuccess = false;
                    bool loginTry;
                    while (loginTry = true && loginAttempt < 3)
                    {
                        loginAttempt++;
                        if (verifyPin == userPin[verifyUser])
                        {
                            Console.WriteLine("Pincode accepted.");
                            Thread.Sleep(1500);
                            Console.Clear();
                            loginTry = false;
                            loginSuccess = true;
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
                            Console.Clear();
                            Console.Write("Wrong pincode, try again: ");
                            verifyPin = Convert.ToInt32(Console.ReadLine());
                        }
                        while (loginSuccess == true)
                        {
                            menuOption();
                            string menuChoice = Console.ReadLine();
                            switch (menuChoice)
                            {
                                case "1":

                                    break;
                                case "2":

                                    break;
                                case "3":

                                    break;
                                case "4":

                                    break;

                                case "5":
                                    Console.Clear();
                                    Console.WriteLine($"Have a nice day {userName[verifyUser, 1]}!");
                                    loginSuccess = false;
                                    break;

                                default:
                                    Console.WriteLine("Unvalid option, try again.");
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                    break;
                            }
                            if (loginSuccess == false)
                            {
                                Console.WriteLine("Press enter to return to the main menu.");
                                Console.ReadLine();
                                loginAttempt = 0;
                                verifyPin = 0;
                                loginTry = false;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
