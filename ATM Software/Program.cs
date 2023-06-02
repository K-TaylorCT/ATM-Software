
using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // execute login method
            Login.LoginCheck();

            // if adminCheck = 1, execute AdminMenu methods
            if (Login.adminCheck == 1)
            {
                AdminMenu.Caller();
            }
            
            // if customerCheck = 1, execute CustomerMenu methods
            if (Login.customerCheck == 1)
            {
                //CustomerMenu.Caller();
            }
        }
    }
}