namespace Bankomaten        //Fredrik Jonsson SUT_24
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            void MenuOption() // Displays the menu after successfull login.
            {
                Console.WriteLine("Please choose one of the following options.");
                Console.WriteLine("1. Show balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Logout");
            }
            // Array for ID, Name, and Pincode.
            string[,] userName = new string[5, 3] { { "0", "John", "1231" }, { "1", "Jane", "1232" }, { "2", "Jenny", "1233" }, { "3", "James", "1234" }, { "4", "Joel", "1235" } };
            int[] userPin = { 1231, 1232, 1233, 1234, 1235 }; // Variable to compare the PIN in the string array above.

            string[][] userAccounts =
            {
                new string[]{"Payroll", "Savings"},
                new string[]{"Payroll", "Savings", "Holiday"},
                new string[]{"Payroll", "Savings"},
                new string[]{"Payroll", "Savings", "Buffer"},
                new string[]{"Savings"}
            };

            double[][] accountsValue =
            {
                new double[]{15000.00, 25000.00},
                new double[]{20000.00, 5000.00, 10000.00},
                new double[]{10000.00, 1500.00},
                new double[]{15000.00, 10000.00, 500.00},
                new double[]{16000.00}
            };


            bool bankEngine = true;  //Boolean to restart the program if the user logs out.
            while (bankEngine == true)
            {
                int userID;
                Console.Clear();
                Console.WriteLine("Welcome to BIG Bossy Bank:\n\n" +
                    "Please enter your ID and pincode.\n\n");
                Console.Write("Enter ID:");
                if (!int.TryParse(Console.ReadLine(), out userID))
                {
                    Console.Write("Incorrect input!");
                    Thread.Sleep(1000);
                }
                else if (userID >= 5)
                {
                    Console.WriteLine("We don't have so many accounts at the moment.\n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write($"Hi, {userName[userID, 1]}, please enter your pincode:");
                    int verifyPin = Convert.ToInt32(Console.ReadLine());
                    int loginAttempt = 0;
                    bool loginSuccess = false;
                    bool loginTry = true;
                    do
                    {
                        loginAttempt++;
                        if (verifyPin == userPin[userID])
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
                    } while (loginTry == true && loginAttempt < 3);

                    while (loginSuccess == true)
                    {
                        Console.Clear();
                        MenuOption();
                        string menuChoice = Console.ReadLine();
                        switch (menuChoice)
                        {
                            case "1":
                                Console.Clear();
                                ShowBalance(userID, userAccounts, accountsValue);
                                Console.Write("\nPress enter to go to the options menu.");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case "2":
                                Console.Clear();
                                Deposit(userID, userAccounts, accountsValue);
                                Console.WriteLine("\nPress enter to go to the options menu.");
                                Console.ReadKey();
                                break;

                            case "3":
                                Console.Clear();
                                Withdraw(userID, userAccounts, accountsValue, userPin);
                                Console.WriteLine("\nPress enter to go to the options menu.");
                                Console.ReadKey();
                                break;

                            case "4":
                                Console.Clear();

                                Console.WriteLine("\nPress enter to go to the options menu.");
                                Console.ReadKey();
                                break;

                            case "5":
                                Console.Clear();
                                Console.WriteLine($"Have a nice day {userName[userID, 1]}!");
                                loginSuccess = false;
                                if (loginSuccess == false)
                                {
                                    Console.WriteLine("Press enter to return to the main menu.");
                                    Console.ReadLine();
                                    loginAttempt = 0;
                                    verifyPin = 0;
                                    loginTry = false;
                                }
                                break;
                            default:
                                Console.WriteLine("Unvalid option, try again.");
                                Thread.Sleep(1500);
                                Console.Clear();
                                break;
                        }
                    }
                }
            }
        }
        static void ShowBalance(int userID, string[][] userAccounts, double[][] accountsValue)
        {
            for (int i = 0; i < userAccounts[userID].Length; i++)
            {
                string userAccount = userAccounts[userID][i];
                double accountValue = accountsValue[userID][i];

                Console.WriteLine($"{i + 1}.{userAccount}: {accountValue}");
            }
        }

        static void Deposit(int userID, string[][] userAccounts, double[][] accountsValue)
        {
            
            Console.WriteLine("How much would you like to deposit:");
            double deposit = Double.Parse(Console.ReadLine());
            Console.WriteLine("\nWich account would you like to deposit it to?");
            for (int i = 0; i < userAccounts[userID].Length; i++)
            {
                string userAccount = userAccounts[userID][i];
                double accountValue = accountsValue[userID][i];

                Console.WriteLine($"{i + 1}.{userAccount}: {accountValue}");
            }

            int accIndex = int.Parse(Console.ReadLine());

            if (accIndex > userAccounts[userID].Length)
            {
                Console.WriteLine("The account you choose doesn't exist.");
                Console.ReadKey();
                return;
            }
            //else if (Felhantering)
            //{

            //}
            else
            {
                accIndex = accIndex - 1;
                accountsValue[userID][accIndex] += deposit;
                Console.WriteLine($"Deposit was successfull, you do now have {accountsValue[userID][accIndex]} on your {userAccounts[userID][accIndex]} account.. ");
            }
            return;
        }
        static void Withdraw(int userID, string[][] userAccounts, double[][] accountsValue, int[] userPin)
        {
            Console.WriteLine("\nWich account would you like to withdraw from?");
            for (int i = 0; i < userAccounts[userID].Length; i++)
            {
                string userAccount = userAccounts[userID][i];
                double accountValue = accountsValue[userID][i];

                Console.WriteLine($"{i + 1}.{userAccount}: {accountValue}");
            }

            int accIndex = int.Parse(Console.ReadLine());
            accIndex = accIndex - 1;

            Console.WriteLine("How much would you like to withdraw:");
            double withdraw = Double.Parse(Console.ReadLine());
            if (accIndex > userAccounts[userID].Length)
            {
                Console.WriteLine("The account you choose doesn't exist.");
                Console.ReadKey();
                return;
            }
            else if (withdraw > accountsValue[userID][accIndex] || 0 > withdraw) 
            {
                Console.WriteLine("We can't handle your request.");
                return;
            }
            else
            {
                Console.Write("Please verify your withdrawal with your pincode.\n" +
                    "Pincode:");
                int verifyPin = Convert.ToInt32(Console.ReadLine());
                if(verifyPin == userPin[userID])
                {
                accountsValue[userID][accIndex] -= withdraw;
                Console.WriteLine($"Withdrawal was successfull, you do now have {accountsValue[userID][accIndex]} on your {userAccounts[userID][accIndex]} account. ");

                }
                else
                {
                    Console.WriteLine("Wrong input, withdrawal unsuccessfull.");
                    return;
                }
            }
            return;
        }
    }
}
