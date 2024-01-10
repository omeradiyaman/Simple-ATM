using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAtm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Atm> list = new List<Atm>();
            Atm person1 = new Atm("1627384950712345", 5123, "Isabella", "Rodriguez", 5000);
            Atm person2 = new Atm("7391856028475123", 5267, "Alexander", "Schmidt", 5000);
            Atm person3 = new Atm("6210947385623098", 1514, "Emily", "Chen", 5000);
            Atm person4 = new Atm("3047856912357806", 8549, "Sebastian", "Dubois", 5000);
            Atm person5 = new Atm("8903174562094731", 3121, "Sophia", "Martinez", 5000);
            Atm person6 = new Atm("4859271036482910", 7898, "Liam", "Nakamura", 5000);
            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            list.Add(person4);
            list.Add(person5);
            list.Add(person6);

            Console.WriteLine("----------------WELCOME TO ATM----------------");
            Console.WriteLine("Please enter your debit card");
            string debit_card_num = "";
            Atm current_user;
            Atm recipient_user;
            string debit_card_num2 = "";
            while (true)
            {
                try
                {
                    debit_card_num = Console.ReadLine();
                    current_user = list.FirstOrDefault(a => a.CardNum == debit_card_num);
                    if (current_user != null)
                    {
                        break;
                    }
                    else { Console.WriteLine("Card not Recognized. Please try again!!!"); ; }
                }
                catch
                {
                    Console.WriteLine("Card not Recognized. Please try again!!!");
                }
            }
            Console.WriteLine("Please Enter Your Password");
            int user_pw = 0;
            int attempt_limit = 3;

            while (true)
            {
                try
                {
                    user_pw = Convert.ToInt32(Console.ReadLine());
                    if (current_user.Pin != user_pw)
                    {
                        Console.WriteLine("Please enter your password correctly!!!");
                        Console.WriteLine("Attempt Limit :" + --attempt_limit);
                        if (attempt_limit == 0)
                        {
                            Console.WriteLine("Your card blocked!!!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                    }
                    else { break; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR :" + ex.Message);
                }
            }
            Console.WriteLine("Welcome " + current_user.Name + " " + current_user.Surname + " :)");
            do
            {
                Console.WriteLine("Please Choose From One of the Following Options...");
                Console.WriteLine("1 - Deposit");
                Console.WriteLine("2 - Withdraw");
                Console.WriteLine("3 - Show Balance");
                Console.WriteLine("4 - Money Transfer");
                Console.WriteLine("5 - Exit");
                char choice = char.Parse(Console.ReadLine());
                switch (choice)
                {
                    case '1':
                        Console.WriteLine("How Much $$ would you like to deposit");
                        int deposit = int.Parse(Console.ReadLine());
                        current_user.Deposit(deposit);
                        Console.WriteLine("Thank you for your deposit. Your transaction is complete.");
                        Console.WriteLine("Your new balance is :" + current_user.Balance);
                        break;
                    case '2':
                        Console.WriteLine("How Much $$ would you like to withdraw");
                        int withdraw = int.Parse(Console.ReadLine());
                        current_user.Withdraw(withdraw);
                        Console.WriteLine("You have successfully withdrawn " + withdraw + "&. Thank you for using our ATM");
                        Console.WriteLine("Your new balance is :" + current_user.Balance);
                        break;
                    case '3':
                        Console.WriteLine("Balance :" + current_user.Balance);
                        break;
                    case '4':
                        Console.WriteLine("Please enter the recipient's card number to proceed with the transfer.");
                        debit_card_num2 = Console.ReadLine();
                        recipient_user = list.FirstOrDefault(a => a.CardNum == debit_card_num2);
                        Console.WriteLine("How much $$ would you like to transfer");
                        int amount = int.Parse(Console.ReadLine());
                        current_user.MoneyTransfer(amount, recipient_user);
                        Console.WriteLine("Your transffer completed successfully! Thank you for using our ATM.");
                        Console.WriteLine("Your new balance is :" + current_user.Balance);
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Please select an option between 0 - 5 !!!");
                        break;
                }
                Console.WriteLine("Would you like to perform another transaction?");
                Console.Write("0 - EXIT" + "                  " + "1 - MENU");
                int choice2 = int.Parse(Console.ReadLine());
                if (choice2 == 1)
                {
                    Console.Clear();
                }
                else if (choice2 == 0)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("ERROR!!!");
                }
            } while (true);
        }
    }
}
