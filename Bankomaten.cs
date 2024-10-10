namespace Bankomaten        //Fredrik Jonsson SUT_24
{
    internal class Program
    {        
        /*------------------------------------------------------------------------------------------*/
        // Different variables declared so that it can be reached from the whole program.
        static int userID;                  //Stores the users bank ID.
        static int verifyPin;               //To verify the userinput with the pin stored in the userPin Array.
        static int loginAttempt = 0;        //Counter to limit the attempts to log in.
        static bool loginSuccess = false;
        static bool loginTry = true;
        static bool bankEngine = true;      //Boolean to restart the program if the user logs out.
        /*------------------------------------------------------------------------------------------*/              
        static string[,] userName = new string[5, 3] { { "0", "John", "1231" }, { "1", "Jane", "1232" }, { "2", "Jenny", "1233" }, { "3", "James", "1234" }, { "4", "Joel", "1235" } }; // Array for ID, Name, and Pincode.
        static int[] userPin = { 1231, 1232, 1233, 1234, 1235 }; // Variable to compare the PIN in the string array above.

        static string[][] userAccounts =
        {
                new string[]{"Payroll", "Savings"},
                new string[]{"Payroll", "Savings", "Holiday"},
                new string[]{"Payroll", "Savings"},
                new string[]{"Payroll", "Savings", "Buffer"},
                new string[]{"Savings"}
        }; // Jagged Array for naming the users accounts.

        static decimal[][] accountsValue =
        {
                new decimal[]{15000.00m, 25000.00m},
                new decimal[]{20000.00m, 5000.00m, 10000.00m},
                new decimal[]{10000.00m, 1500.00m},
                new decimal[]{15000.00m, 10000.00m, 500.00m},
                new decimal[]{16000.00m}
        };  // Jagged Array for currency on the users accounts.
        /*------------------------------------------------------------------------------------------*/
        static void Main(string[] args)
        {             
            while (bankEngine == true) 
            {
                BankID();
                while (bankEngine == false)
                {
                    VerifyPin();
                    UserMenu();
                }
            } // Start of program.
        }
        static void BankID()
        {
            bool boolID = true;
            while (boolID)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Barneys Brilliant Bank:\n\n" + "Please enter your registered ID\n\n");
                Console.Write("Enter ID:");
                while (!int.TryParse(Console.ReadLine(), out userID) || userID < 0)
                {
                    Console.Write("Incorrect input!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Welcome to Barneys Brilliant Bank:\n\n" + "Please enter your registered ID\n\n");
                    Console.Write("Enter ID:");
                }
                if (userID >= 5)
                {
                    Console.WriteLine("We don't have so many accounts at the moment.\n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                }
                else
                {
                    bankEngine = false; boolID = false;
                    Console.Clear();
                }
            }
        } // Method to match the ID with the stored user.
        static void VerifyPin()
        {
            do          // Do-While loop that runs until the user enters the correct pincode.
            {
                verifyPin = -1; // To reset the variable when logging in to another user.
                Console.Clear();                
                Console.Write($"Hi {userName[userID, 1]}, welcome!\n\nPlease enter your 4-digit pincode. \nPincode:");              
                    while (!int.TryParse(Console.ReadLine(), out verifyPin) || verifyPin < 0 || verifyPin != userPin[userID])
                    {
                        Console.WriteLine("\n**INCORRECT INPUT**");                        
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    }
                    loginAttempt++;
                    if (verifyPin == userPin[userID])
                    {
                        Console.WriteLine("\n**PINCODE ACCEPTED**");
                        Thread.Sleep(1500);
                        Console.Clear();
                        loginTry = false;
                        loginSuccess = true;
                    }
                    else if (loginAttempt == 3)
                    {
                        Console.WriteLine("You have reached your limit of attempts.\n" + "\n**ACCESS DENIED**");
                        Thread.Sleep(2500);
                        Environment.Exit(0);                        
                    }                                                   
            } while (loginTry == true && loginAttempt < 3);
        } //Method to verify the pincode with the stored one in the array.
        static void MenuOption() // Displays the menu after successfull login.
        {
            Console.WriteLine("Please choose one of the following options.");
            Console.WriteLine("1. Show balance.");
            Console.WriteLine("2. Deposit.");
            Console.WriteLine("3. Withdraw.");
            Console.WriteLine("4. Transfer.");
            Console.WriteLine("5. Logout.");
            Console.WriteLine("6. Close.");
        }
        static void UserMenu()
        {
            while (loginSuccess == true)
            {
                Console.Clear();
                MenuOption();
                Console.Write("\nOption:");
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"__--::{userName[userID, 1]}'s Account::--__\n");
                        ShowBalance(userID, userAccounts, accountsValue, userName);
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
                            loginTry = false;
                            bankEngine = true;
                        }
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("::-------------------------------------::");
                        Console.WriteLine("\nThanks for using Barneys Brilliant Bank!\n");
                        Console.WriteLine("::-------------------------------------::");
                        Thread.Sleep(1500);
                        Gift();
                        Environment.Exit(0);                               
                        break;
                    default:
                        Console.WriteLine("Unvalid option, try again.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }    // Switch menu for the different methods.
            }
        } // Method with switch menu.
        static void ShowBalance(int userID, string[][] userAccounts, decimal[][] accountsValue, string[,] userName) // Displays the accounts for the user.
        {
            
            for (int i = 0; i < userAccounts[userID].Length; i++)
            {
                string userAccount = userAccounts[userID][i];
                decimal accountValue = accountsValue[userID][i];
                Console.WriteLine($"{i + 1}.{userAccount}: {accountValue} $");
            }
        }
        static void Deposit(int userID, string[][] userAccounts, decimal[][] accountsValue) // Method for depositing money.
        {
            try
            {
                Console.WriteLine("Wich account would you like to deposit to:");
                ShowBalance(userID, userAccounts, accountsValue, userName);                
                Console.Write("\nAccountnumber:");
                int accIndex = int.Parse(Console.ReadLine());
                Console.Write("\nHow much would you like to deposit:");
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
                    Console.WriteLine($"\nDeposit was successfull, you do now have {accountsValue[userID][accIndex]} $ on your {userAccounts[userID][accIndex]} account.. ");
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
            return;
        }
        static void Withdraw(int userID, string[][] userAccounts, decimal[][] accountsValue, int[] userPin) // Method for withdrawing money.
        {
            try
            {
                Console.WriteLine("Wich account would you like to withdraw from:\n");
                ShowBalance(userID, userAccounts, accountsValue, userName);
                Console.Write("\nAccountnumber: ");
                int accIndex = int.Parse(Console.ReadLine());
                accIndex = accIndex - 1;
                Console.Write($"\nHow much would you like to withdraw from your {userAccounts[userID][accIndex]} account:");
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
                    Console.Write("\nPlease verify your withdrawal with your pincode.\n" +
                        "Pincode: ");
                    int verifyPin = Convert.ToInt32(Console.ReadLine());
                    if (verifyPin == userPin[userID])
                    {
                        accountsValue[userID][accIndex] -= withdraw;
                        Console.WriteLine($"\nWithdrawal was successfull, you do now have {accountsValue[userID][accIndex]} $ on your {userAccounts[userID][accIndex]} account. ");
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
        static void Transfer(int userID, string[][] userAccounts, decimal[][] accountsValue) // Method for transfering money between the users account.
        {
            try
            {
                Console.WriteLine("Select wich account you would like to transfer money from:\n");
                ShowBalance(userID, userAccounts, accountsValue, userName);
                Console.Write("\nAccountnumber: ");
                int fromAccount = int.Parse(Console.ReadLine());
                fromAccount = fromAccount - 1;
                Console.WriteLine("Wich account would you like to transfer money to:");
                ShowBalance(userID, userAccounts, accountsValue, userName);
                Console.Write("\nAccountnumber: ");
                int toAccount = int.Parse(Console.ReadLine());
                toAccount = toAccount - 1;
                if (fromAccount == toAccount)
                {
                    Console.WriteLine("You can't transfer to the same account.");
                    return;
                }
                else if (toAccount > userAccounts[userID].Length || fromAccount > userAccounts[userID].Length)
                {
                    Console.WriteLine("The account you choose doesn't exist.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.Write("How much money would you like to transfer: ");
                    decimal movingMoney = Decimal.Parse(Console.ReadLine());
                    if (movingMoney > accountsValue[userID][fromAccount])
                    {
                        Console.WriteLine("There were insufficient funds.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        accountsValue[userID][fromAccount] -= movingMoney;
                        accountsValue[userID][toAccount] += movingMoney;
                        Console.Clear();
                        Console.WriteLine("Your transfer is complete.\n" +
                            "Your current balance for affected accounts are now:\n" +
                            $"1.{userAccounts[userID][fromAccount]}.{accountsValue[userID][fromAccount]} $\n" +
                            $"2.{userAccounts[userID][toAccount]}.{accountsValue[userID][toAccount]} $ ");
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
        static void Gift()
        {
            string free = "\nTake a complimentary 45 Magnum!";
            foreach (var letter in free)
            {
                Console.Write(letter);
                Thread.Sleep(50);
            }
            Thread.Sleep(1250);
            Console.Clear();           
        }
    }
}
