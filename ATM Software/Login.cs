
using System;

namespace Program
{
    class Login
    {
        // variable for login attempt counter iteration
        private static int i = 3;
        public static int adminCheck = 0;
        public static int customerCheck = 0;
        private static string LoginAgent()
        {
            // ask user for login and handle if null
            Console.WriteLine("Enter login");
            var login = Console.ReadLine();
            Console.Clear();
            if(login != null)
            {
                return login;
            }
            return "";
        }

        private static string PINAgent()
        {
            // ask user for PIN and handle if null
            Console.WriteLine("Enter PIN");
            var PIN = Console.ReadLine();
            Console.Clear();
            if( PIN != null )
            {
                return PIN;
            }
            return "";
        }

        private static string FetchValidCustomerLogin()
        {
            // fetch valid login from file
            string contents = File.ReadAllText(@"C:\Users\will.leece\Desktop\ATM Software\Customer Login\ValidCustomerLogin.txt");
            
            // decryption operation here

            return contents;
        }

        private static string FetchValidCustomerPIN()
        {
            // fetch valid PIN from file
            string contents = File.ReadAllText(@"C:\Users\will.leece\Desktop\ATM Software\Customer Login\ValidCustomerPIN.txt");

            // decryption operation here

            return contents;
        }

        private static string FetchValidAdminLogin()
        {
            // fetch valid login from file
            string contents = File.ReadAllText(@"C:\Users\will.leece\Desktop\ATM Software\Admin Login\ValidAdminLogin.txt");

            // decryption operation here

            return contents;
        }

        private static string FetchValidAdminPIN()
        {
            // fetch valid PIN from file
            string contents = File.ReadAllText(@"C:\Users\will.leece\Desktop\ATM Software\Admin Login\ValidAdminPIN.txt");

            // decryption operation here

            return contents;
        }

        public static void LoginCheck()
        {
            // execute user input methods
            string login = LoginAgent();
            string PIN = PINAgent();

            // execute valid info fetch methods
            string validCustomerLogin = FetchValidCustomerLogin();
            string validCustomerPIN = FetchValidCustomerPIN();
            string validAdminLogin = FetchValidAdminLogin();
            string validAdminPIN = FetchValidAdminPIN();

            // compare the information and iterate through login attempts if incorrect, exit application if attempts < 0
            if (login == validCustomerLogin && PIN == validCustomerPIN)
            {
                CustomerMenu.DisplayMenu();
                int customerCheck = 1;
            }
            else if (login == validAdminLogin && PIN == validAdminPIN)
            {
                AdminMenu.DisplayMenu();
                int adminCheck = 1;
            }
            else if (i > 0)
            {
                Console.WriteLine($"Invalid credentials, you have {i} attempts remaining");
                i--;
                LoginCheck();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}