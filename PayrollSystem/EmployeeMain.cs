using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    class EmployeeMain:DataBase
    {
        internal static string employeeName, employeePassword;
        static EmployeeMain()
        {
            employeeName = "ilangoAspire";
            employeePassword = "ilango@123";
        }
        public void EmployeeLogin()
        {
            Console.WriteLine("Enter the User name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();
            if (userName.Equals(employeeName) && password.Equals(employeePassword)||userName.Equals(UserName))
            {
                Console.WriteLine("You have login as Employee ");
                EmployeeControl();
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        }
        public void EmployeeControl()
        {
            
            try
            {
                using (SqlConnection myConnection = new SqlConnection(sqlConnection))
                {
                    myConnection.Open();
                    DataBase employeeDatacollection = new DataBase();
                    LoginManagement manage = new LoginManagement();
                    Console.WriteLine("*********************Welcome to employee page*************************");
                    Console.WriteLine("Enter your choice\n1.View Details\n2.Main");
                    int option = int.Parse(Console.ReadLine());
                    do
                    {
                        switch (option)
                        {
                            case 1:
                                employeeDatacollection.DisplayEmployee(myConnection);
                                break;
                            case 2:
                                manage.Management();
                                break;
                        }
                        Console.WriteLine("*********************Welcome to employee page*************************");
                        Console.WriteLine("Enter your choice\n1.View Details\n2.Main");
                        option = int.Parse(Console.ReadLine());
                    } while (option != 3);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                FileLogger.Writing(e.Message);
               
            }
        
        }

    }
}

