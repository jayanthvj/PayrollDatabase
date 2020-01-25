using System;
using System.Configuration;
namespace PayrollSystem
{
    class LoginManagement
    {
        public void Management()
        {
            start:
            try
             {
                
                Admin management = new Admin();
                EmployeeMain emp = new EmployeeMain();
                Console.WriteLine("*********************Welcome to Login*************************");
                Console.WriteLine("Enter your choice\n1.Admin\n2.Employee\n3.Exit");
                int option = int.Parse(Console.ReadLine());
                do
                {
                    switch (option)
                    {
                        case 1:
                            management.AdminLogin();

                            break;
                        case 2:
                          emp.EmployeeLogin();
                            break;
                        case 3:
                            Management();
                            break;
                    }
                    Console.WriteLine("*********************Welcome to Login*************************");
                    Console.WriteLine("Enter your choice\n1.Admin\n2.Employee\n3.Main");
                    option = int.Parse(Console.ReadLine());
                } while (option != 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                FileLogger.Writing(e.Message);
                goto start;
            }
        }
       

        class Program
        {
            static void Main(string[] args)
            {
                LoginManagement user = new LoginManagement();
                user.Management();
            }
        }
    }
}

