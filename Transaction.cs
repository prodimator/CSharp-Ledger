// A Hello World! program in C#.
using System;
using System.Collections;
using System.Collections.Generic;
namespace AltSource
{
    public class Transaction
    {
        private string type;
        private float amount;

        public Transaction(string type, float amount)
        {
            this.type = type;
            this.amount = amount;
        }

        // Getter for type
        public string getType(){
            return this.type;
        }

        // Getter for amount
        public float getAmount(){
            return this.amount;
        }
    }
}