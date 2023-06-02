
using System;
using Newtonsoft.Json;

namespace Program
{
    // create AdminAccount class for adminAccount object creation
    public class AdminAccount
    {
        public string accountPermissions { get; set; }
        public string login { get; set; }
        public string PIN { get; set; }
    }

    // create CustomerAccount class for customerAccount object creation
    public class CustomerAccount
    {
        public string accountPermissions { get; set; }
        public string login { get; set; }
        public string PIN { get; set; }
        public string holdersName { get; set; }
        public string accountType { get; set; }
        public int balance { get; set; }
        public string status { get; set; }
    }
    class AdminMenu
    {
        internal static void DisplayMenu()
        {
            Console.WriteLine("1----Create New Account");
            Console.WriteLine("2----Delete Existing Account");
            Console.WriteLine("3----Update Account Information");
            Console.WriteLine("4----Search for Account");
            Console.WriteLine("5----View Reports");
            Console.WriteLine("6----Exit");

            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                CreateNewAccount();
            }
            else if (choice == "2")
            {
                Console.Clear();
                DeleteExistingAccount();
            }
            else if (choice == "3")
            {
                Console.Clear();
                UpdateAccountInformation();
            }
            else if (choice == "4")
            {
                Console.Clear();
                SearchForAccount();
            }
            else if (choice == "5")
            {
                Console.Clear();
                ViewReports();
            }
            else if (choice == "6")
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                DisplayMenu();
            }
        }

        private static void CreateNewAccount()
        {
            // prompt user for type of account
            Console.WriteLine("Account permissions type (Admin/Customer):");
            var permissions = Console.ReadLine();

            // prompt user to enter account information based on admin permissions
            if (permissions == "Admin" ||  permissions == "admin")
            {
                var accountPermissions = "accountPermisssions: admin";

                Console.WriteLine("Login:");
                var login = "login: " + Console.ReadLine();

                Console.WriteLine("PIN:");
                var PIN = Console.ReadLine();

                // check against misinput, if so then restart method
                if (login == "")
                {
                    Console.WriteLine("Login cannot be empty");
                    CreateNewAccount();
                }
                else if (PIN == "" || PIN.Length != 5)
                {
                    Console.WriteLine("PIN must be 5 numbers");
                }

                // assign value to PIN after comparison checks
                PIN = "PIN: " + PIN;

                // confirmation message to go through with account creation
                Console.WriteLine($"Are you sure you want to create admin account {login} (Y/N)?");
                var confirmation = Console.ReadLine();

                if ((confirmation == "Y") || (confirmation == "y"))
                {
                    // fetch latest accountNumber from file and add 1
                    string rawAccountNumber = File.ReadAllText(@"C:\Users\will.leece\Desktop\ATM Software\accountNumber.txt");
                    int accountNumber = Convert.ToInt32(rawAccountNumber);
                    accountNumber++;
                    string revertedAccountNumber = Convert.ToString(accountNumber);

                    // create textWriter to append all data to file named after the accountNumber assigned to the account
                    TextWriter textWriter = new StreamWriter($@"C:\Users\will.leece\Desktop\ATM Software\adminAccounts\{revertedAccountNumber}.txt", true);

                    // add data to file
                    textWriter.WriteLine(accountPermissions);
                    textWriter.WriteLine(login);
                    textWriter.WriteLine(PIN);

                    textWriter.Close();

                    // confirmation message
                    Console.Clear();
                    Console.WriteLine($"Account Successfully Created - the account number assigned is: {revertedAccountNumber}");

                    // overwrite accountNumber with latest value
                    File.WriteAllText(@"C:\Users\will.leece\Desktop\ATM Software\accountNumber.txt", $"{revertedAccountNumber}");

                    // send user back to menu
                    DisplayMenu();
                }
                else if ((confirmation == "N") || (confirmation == "n"))
                {
                    Console.Clear();
                    DisplayMenu();
                }
            }
            else if (permissions == "Customer" || permissions == "customer")
            {
                var accountPermissions = "accountPermisssions: customer";

                Console.WriteLine("Login:");
                var login = "login: " + Console.ReadLine();

                Console.WriteLine("PIN:");
                var PIN = Console.ReadLine();

                Console.WriteLine("Holders Name:");
                var holdersName = "holdersName: " + Console.ReadLine();

                Console.WriteLine("Type (Savings, Current):");
                var accountType =  "accountType: " + Console.ReadLine();

                Console.WriteLine("Starting Balance:");
                var balance = Console.ReadLine();

                Console.WriteLine("Status:");
                var status = "status: " + Console.ReadLine();

                // check against misinput, if so then restart method
                if (login == "")
                {
                    Console.WriteLine("Login cannot be empty");
                    CreateNewAccount();
                }
                else if (PIN == "" || PIN.Length != 5)
                {
                    Console.WriteLine("PIN must be 5 numbers");
                }
                else if (holdersName == "")
                {
                    Console.WriteLine("Holders name cannot be empty");
                }
                else if ((accountType == "") && (accountType != "Savings") && (accountType != "savings") && (accountType != "Current") && (accountType != "current"))
                {
                    Console.WriteLine("Must be a valid account type");
                    CreateNewAccount();
                }
                else if (balance == "" || Convert.ToInt32(balance) < 0)
                {
                    Console.WriteLine("Balance must be at least zero");
                    CreateNewAccount();
                }
                else if ((status == "") && (status != "Active") && (status != "active") && (status != "Inactive") && (status != "inactive"))
                {
                    Console.WriteLine("Must be a valid status type");
                    CreateNewAccount();
                }

                // assign values to PIN and balance after comparison checks
                PIN = "PIN: " + PIN;
                balance = "balance: " + balance;
            
                // fetch latest accountNumber from file and add 1
                string rawAccountNumber = File.ReadAllText(@"C:\Users\will.leece\Desktop\ATM Software\accountNumber.txt");
                int accountNumber = Convert.ToInt32(rawAccountNumber);
                accountNumber++;
                string revertedAccountNumber = Convert.ToString(accountNumber);

                // create JSON object from user data
                AdminAccount adminAccount = new AdminAccount();

                adminAccount.accountPermissions = accountPermissions;
                adminAccount.login = login;
                adminAccount.PIN = PIN;

                string output = JsonConvert.SerializeObject(adminAccount);

                File.WriteAllText($@"C:\Users\will.leece\Desktop\ATM Software\adminAccounts\{revertedAccountNumber}.json", output);

                //// create textWriter to append all data to file named after the accountNumber assigned to the account
                //TextWriter textWriter = new StreamWriter($@"C:\Users\will.leece\Desktop\ATM Software\customerAccounts\{revertedAccountNumber}.txt", true);

                //// add data to file
                //textWriter.WriteLine(accountPermissions);
                //textWriter.WriteLine(login);
                //textWriter.WriteLine(PIN);
                //textWriter.WriteLine(holdersName);
                //textWriter.WriteLine(accountType);
                //textWriter.WriteLine(balance);
                //textWriter.WriteLine(status);

                //textWriter.Close();

                // confirmation message
                Console.Clear();
                Console.WriteLine($"Account successfully created - the account number assigned is: {revertedAccountNumber}");

                // overwrite accountNumber with latest value
                File.WriteAllText(@"C:\Users\will.leece\Desktop\ATM Software\accountNumber.txt", $"{revertedAccountNumber}");

                // send user back to menu
                DisplayMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not a valid permission type");
                DisplayMenu();
            }
        }

        private static void DeleteExistingAccount()
        {
            Console.WriteLine("Enter the account number to which you want to delete:");
            var deleteAccountNumber = Console.ReadLine();

            // fetch account holdersName from specified file or go back to menu if account does not exist
            if (File.Exists(@$"C:\Users\will.leece\Desktop\ATM Software\customerAccounts\{deleteAccountNumber}.txt"))
            {
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Account not found");
                DisplayMenu();
            }

            var accountInfo = File.ReadAllLines(@$"C:\Users\will.leece\Desktop\ATM Software\customerAccounts\{deleteAccountNumber}.txt");
            var rawHoldersName = accountInfo[3];
            var holdersName = rawHoldersName.Remove(0, 13);

            // delete account file on user confirmation
            Console.WriteLine($"You wish to delete the account held by {holdersName}; If this information is correct please re-enter the account number");
            if (Console.ReadLine() == deleteAccountNumber)
            {
                File.Delete(@$"C:\Users\will.leece\Desktop\ATM Software\customerAccounts\{deleteAccountNumber}.txt");
            }

            if (File.Exists(@$"C:\Users\will.leece\Desktop\ATM Software\customerAccounts\{deleteAccountNumber}.txt"))
            {
                Console.WriteLine("Error");
            }
            else
            {
                // confirmation message
                Console.Clear();
                Console.WriteLine("Account deleted successfully");

                // send user back to menu
                DisplayMenu();
            }
        }

        private static void UpdateAccountInformation()
        {
            Console.WriteLine("Enter the account number");
            var accountNumber = Console.ReadLine();

            // check if account exists and redirect to menu if not
            if (File.Exists(@$"C:\Users\will.leece\Desktop\ATM Software\customerAccounts\{accountNumber}.txt"))
            {

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Account not found");
                DisplayMenu();
            }
        }

        private static void SearchForAccount()
        {
            Console.WriteLine("SEARCH MENU:");

            Console.WriteLine("\nAccount ID:");
            var accountID = Console.ReadLine();

            Console.WriteLine("User ID:");
            var userID = Console.ReadLine();

            Console.WriteLine("Holders Name:");
            var holdersName = Console.ReadLine();

            Console.WriteLine("Type (Savings, Current)");
            var type = Console.ReadLine();

            Console.WriteLine("Balance:");
            var balance = Console.ReadLine();

            Console.WriteLine("Status:");
            var status = Console.ReadLine();

            
        }

        private static void ViewReports()
        {

        }

        public static void Caller()
        {
            DisplayMenu();
        }
    }
}