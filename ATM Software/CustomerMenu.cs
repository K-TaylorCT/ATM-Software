
using System;

namespace Program
{
    class CustomerMenu
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("1----Withdraw Cash");
            Console.WriteLine("2----Cash Transfer");
            Console.WriteLine("3----Deposit Cash");
            Console.WriteLine("4----Display Balance");
            Console.WriteLine("5----Exit");
            Console.WriteLine("\nPlease select one of the above options:");
        }

        private static void WithdrawCash()
        {
            Console.WriteLine("a) Fast Cash");
            Console.WriteLine("b) Normal Cash");
            Console.WriteLine("\nPlease select a mode of withdrawal");
        }

        public static void FastCash()
        {
            Console.WriteLine("1----500");
            Console.WriteLine("2----1000");
            Console.WriteLine("3----2000");
            Console.WriteLine("4----5000");
            Console.WriteLine("5----10000");
            Console.WriteLine("6----15000");
            Console.WriteLine("7----20000");
            Console.WriteLine("\nSelect one of the denominations of money:");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    choice = "500";
                    break;

                case "2":
                    choice = "1000";
                    break;

                case "3":
                    choice = "2000";
                    break;

                case "4":
                    choice = "5000";
                    break;

                case "5":
                    choice = "10000";
                    break;

                case "6":
                    choice = "15000";
                    break;

                case "7":
                    choice = "20000";
                    break;

                default:
                    Console.WriteLine("Please choose an amount");
                    break;
            }

            Console.WriteLine($"Are you sure you want to withdraw {choice} (Y/N)?");
            var withdrawConfirmation = Convert.ToChar(Console.ReadLine());

            if(withdrawConfirmation == 'Y') // && account has available balance)
            Console.WriteLine("Cash successfully Withdrawn!");
            else
            {
                CustomerMenu.FastCash();
            }    

            Console.WriteLine("Do you wish to print a receipt (Y/N)?");
            // output account number ie "Account #12" here
            Console.WriteLine(DateTime.Now);
            // output account balance here ie "154500"
        }

        public static void NormalCash()
        {
            Console.WriteLine("Enter the withdrawal amount");
            var withdrawalAmount = Console.ReadLine();

            // if withdrawal amount <= available balance then output "Cash Successfully Withdrawn!"

            // output "Do you wish to print a receipt (Y/N)?"
            // output account number ie "Account #12"
            Console.WriteLine(DateTime.Now);

            // output {withdrawalAmount}
            // output remaining balance
        }
    }
}