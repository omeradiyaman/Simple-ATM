using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAtm
{
    internal class Atm
    {
        string card_num;
        int pin;
        string name;
        string surname;
        double balance;
        public string CardNum
        {
            get
            {
                return card_num;
            }

            set
            {
                if (value.All(p => char.IsDigit(p)) && value.Length == 16)
                {
                    card_num = value;
                }
                else
                {
                    Console.WriteLine("Please enter your card Number Correctly!!!");
                }
            }
        }
        public int Pin
        {
            get
            {
                return pin;
            }
            set
            {
                string control = Convert.ToString(value);
                if (control.Length != 4)
                {
                    Console.WriteLine("Please enter your pin with 4 characters!!!");
                }
                else
                {
                    foreach (var item in control)
                    {
                        if (!(item >= '0' && item <= '9'))
                        {
                            Console.WriteLine("Please enter your pin correctly!!!");
                        }
                        else
                        {
                            value = int.Parse(control);
                            pin = value;
                        }
                    }
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.All(a => char.IsLetter(a) || char.IsWhiteSpace(a)))
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Please enter your name Correctly !!!");
                }
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (value.All(b => char.IsLetter(b) || char.IsWhiteSpace(b)))
                {
                    surname = value;
                }
                else
                {
                    Console.WriteLine("Please enter your Surname Correctly !!!");
                }
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                if (value > 0)
                    balance = value;
                else 
                    balance = 0;
            }
        }

        public Atm(string card_num, int pin, string name, string surname, double balance)
        {
            this.CardNum = card_num;
            this.Pin = pin;
            this.Name = name;
            this.Surname = surname;
            this.Balance = balance;
        }
        public void Withdraw(int amount)
        {
            while (!(balance > amount && amount % 10 == 0))
            {
                Console.WriteLine("Please enter valid amount of money!!!");
                amount = Convert.ToInt32(Console.ReadLine());
            }
            balance -= amount;
            BalanceEnquiry();
        }
        public void Deposit(int deposit)
        {
            while (deposit % 10 != 0)
            {
                Console.WriteLine("Please enter valid amount of money(multiples of 10)");
                deposit = Convert.ToInt32(Console.ReadLine());
            }
            balance += deposit;
        }
        public void MoneyTransfer(int amount, Atm atm)
        {
            while (balance < amount)
            {
                Console.WriteLine("Please enter valid amount of money to transfer!!!");
                amount = Convert.ToInt32(Console.ReadLine());
            }
            balance -= amount;
            atm.balance += amount;
            BalanceEnquiry();
        }
        public void BalanceEnquiry()
        {
            Console.WriteLine("Balance :" + balance);
        }
    }
}
