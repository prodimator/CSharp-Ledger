// A Hello World! program in C#.
using System;
using System.Collections;
using System.Collections.Generic;
namespace AltSource
{
    public class Ledger
    {
        private string identifier;
        private float balance;
        List<Transaction> transactionHistory;

        public Ledger(string id)
        {
            identifier = id;
            balance = 0;
            transactionHistory = new List<Transaction>();
        }

        // Getter for identifier
        public string getIdentifier(){
            return this.identifier;
        }
        // Setter for identifier
        public void setIdentifier(string id){
            this.identifier = id;
        }
        // Getter for balance
        public float getBalance(){
            return this.balance;
        }

        // Function for depositing amount to ledger's balance
        public void depositAmount(string amount)
        {
            try{
                this.balance = this.balance + float.Parse(amount);
                Transaction deposit = new Transaction("Deposit", float.Parse(amount));
                this.transactionHistory.Add(deposit);
                Console.WriteLine("Depositing " + amount);
            }
            catch{
                Console.WriteLine("Please enter a number");
            }
        }

        // Function for withdrawing amount from ledger's balance
        public void withDrawalAmount(string amount)
        {
            try{
                this.balance = this.balance - float.Parse(amount);
                Transaction withdrawal = new Transaction("Withdrawal", float.Parse(amount));
                this.transactionHistory.Add(withdrawal);
                Console.WriteLine("Withdrawing  " + amount);
            }
            catch{
                Console.WriteLine("Please enter a number");
            }
        }

        // Function for parsing the transaction history of a ledger
        public void seeTransactionHistory()
        {
            if (this.transactionHistory.Count != 0){
                foreach (var item in this.transactionHistory)
                {
                    Console.WriteLine("- " + item.getType() + " " + item.getAmount() + " -"); // Replace this with your version of printing
                }
            }
            else{
                Console.WriteLine("No transaction history.");
            }
        }
    }
}