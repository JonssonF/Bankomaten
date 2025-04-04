using System;

namespace Lektion_SUT24_241031_Anas
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }


        public BankAccount(int accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }


        public void Deposit(decimal amount)
        {
            Balance += amount;

            Console.WriteLine($"Deposited {amount:C} to account " + 
                $"{AccountNumber}. New balance is {Balance:C}");
        }

        public virtual void Withdrawal(decimal amount)
        {
            if(amount > Balance) 
            {
                Console.WriteLine("Not found.");
                return;
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew {amount:C} from Account {AccountNumber}. New Balance : {Balance:C}");
            }
        }
    }
}
