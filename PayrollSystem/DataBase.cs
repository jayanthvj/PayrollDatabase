using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PayrollSystem
{
    public class DataBase:EmployeeDataInsertion
    {
        public void GetConnection()
        {
            //DataBase emp = new DataBase();
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                if (myConnection != null && myConnection.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Connection is not present");
                }
                else
                    Console.WriteLine("Connection Established");
                int choice = Convert.ToInt32(Console.ReadLine());
                if(choice==1)
                {
                   AddEmployees(myConnection);
                }
                else if (choice ==2)
                {
                    DisplayEmployee(myConnection);
                }
              

            }
        }
    }
}
