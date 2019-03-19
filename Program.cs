using System;
using System.Collections;
using System.Collections.Generic;

namespace AltSource
{
    class LedgerActions
    {
        // Current active ledger
        string currentLedgerID = "";
        List<Ledger> allLedgers = new List<Ledger>();

        // Run option based on user input in the menu
        void parseChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    this.createAccount();
                    break;
                case "2":
                    this.login();
                    break;
                case "3":
                    this.recordDeposit();
                    break;
                case "4":
                    this.recordWithdrawal();
                    break;
                case "5":
                    this.checkBalance();
                    break;
                case "6":
                    this.seeTransactionHistory();
                    break;
                case "7":
                    this.logout();
                    break;
                default:
                    Console.WriteLine("Please select a correct option!");
                    break;
            }
        }

        // If option is 1, create a new account
        void createAccount()
        {
            Console.Write("Please enter a unique ID for a new account: ");
            string id = Console.ReadLine();
            Ledger ledger = new Ledger(id);
            this.currentLedgerID = ledger.getIdentifier();
            this.allLedgers.Add(ledger);
        }

        // If option is 2, login to a user determined by the user
        void login()
        {
            Console.Write("Enter identifier for ledger you with to use: ");
            string id = Console.ReadLine();
            for (int i = 0; i < this.allLedgers.Count; i++)
            {
                if (id == this.allLedgers[i].getIdentifier())
                {
                    Console.WriteLine("Found ledger!");
                    this.currentLedgerID = this.allLedgers[i].getIdentifier();
                }
            }
            Console.WriteLine("Ledger not found");
        }

        // If option is 3, make a deposit to the current active ledger
        void recordDeposit()
        {
            if (this.currentLedgerID != "")
            {
                Console.Write("Enter an amount you wish to deposit: ");
                string depositAmount = Console.ReadLine();
                this.allLedgers.Find(x => x.getIdentifier() == this.currentLedgerID).depositAmount(depositAmount);

            }
            else
            {
                Console.WriteLine("No ledger selected.");
            }
        }

        // If option is 4, make a withdrawal from the current active ledger
        void recordWithdrawal()
        {
            if (this.currentLedgerID != "")
            {
                Console.Write("Enter an amount you wish to withdrawal: ");
                string withdrawalAmount = Console.ReadLine();
                this.allLedgers.Find(x => x.getIdentifier() == this.currentLedgerID).withDrawalAmount(withdrawalAmount);
            }
            else
            {
                Console.WriteLine("No ledger selected.");
            }
        }

        // If the option is 5, check the balance of the current active ledger
        void checkBalance()
        {
            if (this.currentLedgerID != "")
            {
                float temp = this.allLedgers.Find(x => x.getIdentifier() == this.currentLedgerID).getBalance();
                Console.WriteLine("Balance: " + temp);

            }
            else
            {
                Console.WriteLine("No ledger selected.");
            }
        }

        // If option is 6, see the transaction history of the current active ledger
        void seeTransactionHistory()
        {
            if (this.currentLedgerID != "")
            {
                this.allLedgers.Find(x => x.getIdentifier() == this.currentLedgerID).seeTransactionHistory();
            }
            else
            {
                Console.WriteLine("No ledger selected.");
            }
        }

        // If option is 7, quit application
        void logout()
        {
            Console.WriteLine("Logging out!");
            System.Environment.Exit(1);
        }

        static void Main()
        {
            LedgerActions ledgerActions = new LedgerActions();
            while (true)
            {
                // Display the active ledger at top of menu if there is one
                if (ledgerActions.currentLedgerID != "")
                {
                    Console.WriteLine("Current ledger: " + ledgerActions.currentLedgerID);
                }
                Console.WriteLine("1. Create a new account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Record a deposit");
                Console.WriteLine("4. Record a withdrawal");
                Console.WriteLine("5. Check balance");
                Console.WriteLine("6. See transaction history");
                Console.WriteLine("7. Log out");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                ledgerActions.parseChoice(choice);
                Console.WriteLine("\n");
            }
        }
    }
}