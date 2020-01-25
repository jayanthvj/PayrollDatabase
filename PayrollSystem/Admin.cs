using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    
        public class Admin:DataBase
        {
       
        internal static string adminName,  adminPassword;
            static Admin()
            {
                adminName = "JayanthAspire";
                adminPassword = "Jayanth@123";
            }
       
        public void AdminLogin()
            {
                Admin home = new Admin();
           
            Console.WriteLine("Enter the User name");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter the password");
                string password = Console.ReadLine();
                if (userName.Equals(adminName) && password.Equals(adminPassword))
                {
                    Console.WriteLine("You have login as Admin ");
                    home.AdminControl();
                }
                else
                {
                    Console.WriteLine("Login failed");
                }
            }
           
        }
    }
