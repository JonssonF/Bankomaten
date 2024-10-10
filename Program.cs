using System.Globalization;

namespace Bankomaten        //Fredrik Jonsson SUT_24
{
    internal class Program
    {

        static void Main(string[] args)
        {                       
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

            decimal[][] accountsValue =
            {
                new decimal[]{15000.00m, 25000.00m},
                new decimal[]{20000.00m, 5000.00m, 10000.00m},
                new decimal[]{10000.00m, 1500.00m},
                new decimal[]{15000.00m, 10000.00m, 500.00m},
                new decimal[]{16000.00m,}
            };

            bool bankEngine = true;  //Boolean to restart the program if the user logs out.
            while (bankEngine == true)
            {
                int userID;
                Console.Clear();
                Console.WriteLine("Welcome to Barneys Brilliant Bank:\n\n" +
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
                else if (userID < 0)
                {
                    Console.WriteLine("Please write a number between 1-5....Sir.");
                    Console.ReadKey();
                }
                else
                {
                    int verifyPin;
                    int loginAttempt = 1;
                    bool loginSuccess = false;
                    bool loginTry = true;

                    while (loginTry == true && loginAttempt < 3); // Do-While that runs for as long as login attempts is below 3.
                    {
                        loginAttempt++; // Counts the number of tries to login.                        
                        Console.Write($"Hi, {userName[userID, 1]}, please enter your pincode:"); // Greets the user by their name.
                        if (!int.TryParse(Console.ReadLine(), out verifyPin) || verifyPin != userPin[userID])
                        {
                            Console.Write("Incorrect input!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.Write($"Have you forget your pincode {userName[userID, 1]}?");
                            verifyPin = Convert.ToInt32(Console.ReadLine());
                        }
                        else if (verifyPin == userPin[userID]) //Compares the pin input with the array at the selected index (userID).
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
                    }
                    //while (loginTry == true && loginAttempt < 3); // Do-While that runs for as long as login attempts is below 3.

                    while (loginSuccess == true)
                    {
                        Console.Clear();
                        MenuOption();   // Writes out the menu for the user after successfull login.
                        Console.Write("\nOption:");
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
                                Transfer(userID, userAccounts, accountsValue);
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
        static void MenuOption() // Displays the menu after successfull login.
        {
            Console.WriteLine("Please choose one of the following options.");
            Console.WriteLine("1. Show balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Logout");
        }
        static void ShowBalance(int userID, string[][] userAccounts, decimal[][] accountsValue) //Method with a for loop to display accounts to the user.
        {
            for (int i = 0; i < userAccounts[userID].Length; i++)
            {
                string userAccount = userAccounts[userID][i];
                decimal accountValue = accountsValue[userID][i];
                Console.WriteLine($"{i + 1}.{userAccount}:{accountValue}$");
            }
        }
        static void Deposit(int userID, string[][] userAccounts, decimal[][] accountsValue) //Method for depositing money $$.
        {
            try
            {
                Console.WriteLine("\nWich account would you like to deposit it to?");
                for (int i = 0; i < userAccounts[userID].Length; i++)
                {
                    string userAccount = userAccounts[userID][i];
                    decimal accountValue = accountsValue[userID][i];
                    Console.WriteLine($"{i + 1}.{userAccount}: {accountValue}$");
                }
                Console.Write("\nAccountnumber: ");
                int accIndex = int.Parse(Console.ReadLine());
                Console.Write("How much would you like to deposit: ");
                decimal deposit = Decimal.Parse(Console.ReadLine());
                if (accIndex > userAccounts[userID].Length)
                {
                    Console.WriteLine("The account you choose doesn't exist.");
                    Console.ReadKey();
                    return;
                }
                else if (deposit <= 0)
                {
                    Console.WriteLine("You didn't select a valid option.");
                }
                else
                {
                    accIndex = accIndex - 1;
                    accountsValue[userID][accIndex] += deposit;
                    Console.WriteLine($"Deposit was successfull, you do now have {accountsValue[userID][accIndex]}$ on your {userAccounts[userID][accIndex]} account.. ");
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
            return;
        }
        static void Withdraw(int userID, string[][] userAccounts, decimal[][] accountsValue, int[] userPin) //Method to withdrawing money $$.
        {
            try
            {
                Console.WriteLine("\nWich account would you like to withdraw from?");
                for (int i = 0; i < userAccounts[userID].Length; i++)
                {
                    string userAccount = userAccounts[userID][i];
                    decimal accountValue = accountsValue[userID][i];
                    Console.WriteLine($"{i + 1}.{userAccount}: {accountValue}");
                }
                Console.Write("\nAccountnumber: ");
                int accIndex = int.Parse(Console.ReadLine());
                accIndex = accIndex - 1;
                Console.Write($"How much would you like to withdraw from your {userAccounts[userID][accIndex]} account:");
                decimal withdraw = Decimal.Parse(Console.ReadLine());
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
                    if (verifyPin == userPin[userID])
                    {
                        accountsValue[userID][accIndex] -= withdraw;
                        Console.WriteLine($"Withdrawal was successfull, you do now have {accountsValue[userID][accIndex]}$ on your {userAccounts[userID][accIndex]} account.");
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, withdrawal unsuccessfull.");
                        return;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
            return;
        }
        
        static void Transfer(int userID, string[][] userAccounts, decimal[][] accountsValue) //Method for transfering money between the accounts of the user.
        {
            try
            {
                Console.WriteLine("\nSelect wich account you would like to transfer money from:");
                for (int i = 0; i < userAccounts[userID].Length; i++)
                {
                    string userAccount = userAccounts[userID][i];
                    decimal accountValue = accountsValue[userID][i];
                    Console.WriteLine($"{i + 1}.{userAccount}: {accountValue}$");
                }
                Console.Write("\nAccountnumber:");
                int fromAccount = int.Parse(Console.ReadLine());
                fromAccount = fromAccount - 1;

                Console.WriteLine("Wich account would you like to transfer money to:");
                for (int i = 0; i < userAccounts[userID].Length; i++)
                {
                    string userAccount = userAccounts[userID][i];
                    decimal accountValue = accountsValue[userID][i];
                    Console.WriteLine($"{i + 1}.{userAccount}: {accountValue}$");
                }
                Console.Write("\nAccountnumber:");
                int toAccount = int.Parse(Console.ReadLine());
                toAccount = toAccount - 1;
                if (fromAccount == toAccount)
                {
                    Console.WriteLine("You can't transfer to the same account.");                   
                    return;
                }
                else if(toAccount > userAccounts[userID].Length || fromAccount > userAccounts[userID].Length)
                {
                    Console.WriteLine("The account you choose doesn't exist.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("How much money would you like to transfer:");
                    decimal movingMoney = Decimal.Parse(Console.ReadLine());
                    if(movingMoney > accountsValue[userID][fromAccount] || movingMoney > accountsValue[userID][toAccount])
                    {
                        Console.WriteLine("There were insufficient funds.");
                        Console.ReadKey();
                        return;
                    }
                    else if (movingMoney < 0)
                    {
                        Console.WriteLine("You can't move a negative amount.");
                    }
                    else
                    {
                        accountsValue[userID][fromAccount] -= movingMoney;
                        accountsValue[userID][toAccount]+= movingMoney;
                        Console.WriteLine("Your transfer is complete.\n" +
                            "Your current balance for affected accounts are now:\n" +
                            $"1.{userAccounts[userID][fromAccount]}.{accountsValue[userID][fromAccount]}$\n" +
                            $"2.{userAccounts[userID][toAccount]}.{accountsValue[userID][toAccount]}$ ");                        
                        return;                      
                    }
                }                
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
            return;
        }
        
    }
}

