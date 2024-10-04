using System;

namespace Lektion_SUT24_241031_Anas
{
    public sealed class SavingAccount : BankAccount
    {

        public decimal InterestRate { get; set; }

        public SavingAccount(int accountNumber, decimal initialBalance, decimal interestRate) 
            : base (accountNumber, initialBalance)
        {
            InterestRate = interestRate;
        }

        public void ApplyIntereset()
        {
            decimal interest = Balance * InterestRate;

            Deposit(interest);
            Console.WriteLine($"Interest of {interest:C} applied at rate {InterestRate:P}. New Balance : {Balance:C}");
        }

        //Overriding the Withdraw method.

        public override void Withdrawal(decimal amount)
        {
            if(amount > Balance)
            {
                Console.WriteLine("Withdraw denied.");
                return;
            }
            base.Withdrawal(amount);
        }
    }
}
