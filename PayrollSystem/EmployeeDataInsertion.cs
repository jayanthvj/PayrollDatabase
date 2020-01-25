using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PayrollSystem
{
    public class EmployeeDataInsertion : RegistrationValidation
    {
        static List<Data> employeeinformation = new List<Data>();
        public string sqlConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public bool AddEmployee(Data employee)
        {
            if (employeeinformation.Contains(employee))
                throw new MyException("This Data is Present Already");
            employeeinformation.Add(employee);
            return true;
        }
        public void AddEmployees(SqlConnection myconnection)
        {
            //SqlCommand insertCommand;
            string query = "Insert_employee";
            SqlCommand insertCommand = new SqlCommand(query, myconnection);
            insertCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();
            int sqlRows = 0;
            Console.WriteLine("How much rows you to insert?");
            int size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
               
                ////insertCommand = new SqlCommand("insert into Department(departmentName)values(@departmentname)", myconnection);
                ////Console.WriteLine("Enter a EmployeeID ");
                ////departmentId = int.Parse(Console.ReadLine());
                ////insertCommand.Parameters.Add(new SqlParameter("@departmentId", departmentId));
                ////Console.WriteLine("Enter a Employee name");
                ////EmployeeName = ValidName();
                //insertCommand.Parameters.Add(new SqlParameter("@departmentname", EmployeeName));
                //insertCommand = new SqlCommand("insert into EmployeeServer(Name,Desigination,departmentId,EmailId,DateOfBirth,MobileNumber,Salary,UserName,Userpassword) VALUES (@Name, @Desigination,@departmentId,@Email,@DOB,@MobileNumber, @Salary,@UserName,@UserPassword)", myconnection);
                Console.WriteLine("Enter a Employee name");
                EmployeeName = ValidName();
                insertCommand.Parameters.Add(new SqlParameter("@Name", EmployeeName));
                Console.WriteLine("Enter the Employee Desigination");
                Designation = Console.ReadLine();
                insertCommand.Parameters.Add(new SqlParameter("@Desigination", Designation));
                Console.WriteLine("Enter a DepartmentID ");
                employeeId = int.Parse(Console.ReadLine());
                insertCommand.Parameters.Add(new SqlParameter("@departmentId", employeeId));
                Console.WriteLine("Enter the Employee Email ID");
                Email = ValidateMail();
                insertCommand.Parameters.Add(new SqlParameter("@Email", Email));
                DateOfBirth = ValidateDateOfBirth();
                insertCommand.Parameters.Add(new SqlParameter("@DOB", DateOfBirth));
                MobileNumber = ValidateMobileNumber();
                insertCommand.Parameters.Add(new SqlParameter("@MobileNumber", MobileNumber));
                Console.WriteLine("Enter a salary ");
                int employeeSalary = int.Parse(Console.ReadLine());
                insertCommand.Parameters.Add(new SqlParameter("@Salary", employeeSalary));
                UserName = GenereteUserName();
                insertCommand.Parameters.Add(new SqlParameter("@UserName", UserName));
                Password = GeneratePassword();
                insertCommand.Parameters.Add(new SqlParameter("@UserPassword", Password));
                Roll = Console.ReadLine();
                insertCommand.Parameters.Add(new SqlParameter("@Roll", Roll));
                adapter.InsertCommand = insertCommand;
                sqlRows = adapter.InsertCommand.ExecuteNonQuery();
            }
            if (sqlRows >= 1)
            {
                Console.WriteLine("Details are added");
            }
            else
            {
                Console.WriteLine("Details are not added");
            }

            //EmployeeName = ValidName();
            //Console.WriteLine("Enter an Employee ID");
            //int Id = int.Parse(Console.ReadLine());
            //Email = ValidateMail();
            //Console.WriteLine("Enter an Employee Designation");
            //String Designation = Console.ReadLine();
            //DateOfBirth = ValidateDateOfBirth();
            //MobileNumber = ValidateMobileNumber();
            //Console.WriteLine("Enter an Employee Department Name");
            //string EmployeeName = Console.ReadLine();
            //Console.WriteLine("Enter an Employee Salary");
            //Double Salary = double.Parse(Console.ReadLine());
            //UserName = GenereteUserName();
            //Password = GeneratePassword();
            //Data employee = new Data(EmployeeName, Id, Email, Designation, DateOfBirth, MobileNumber, EmployeeName, Salary,UserName,Password);
            //bool status = AddEmployee(employee);
            //if (status)
            //{
            //    Console.WriteLine("Details Added Successfully");

            //}
        }

        public void DisplayEmployee(SqlConnection myconnection)
        {
            string sql = "Select_Employee";
            SqlCommand insertCommand = new SqlCommand(sql, myconnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            insertCommand.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("Enter the User User Name you want to See");
            UserName = Console.ReadLine();
            insertCommand.Parameters.Add(new SqlParameter("@Name", UserName));
            sqlDataAdapter.SelectCommand = insertCommand;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "EmployeeServer");
            foreach (DataRow row in dataSet.Tables["EmployeeServer"].Rows)
            {
                Console.WriteLine("EmployeeName:" + row["Name"] + "\n"+"Employee Desigination:"+row["Desigination"] +"\n" + "ID:" + row["employeeId"]  +"\n" + "EmailID:" + row["EmailId"] + "\n" + "Employee DateOfBirth:" + row["DateOfBirth"] + "\n" + "MobileNumber:" + row["MobileNumber"] + "\n" + "DepartmentID:" + row["DepartmentId"] + "\n" + "Salary:" + row["Salary"] + "\n" + "UserName:" + row["UserName"] + "\n" + "User Password:" + row["UserPassword"]);
                Console.WriteLine();
            }
            insertCommand.Dispose();
            
        }
        public void AdminControl()
        {
            
            try
            {
                EmployeeDataInsertion employeeCollection = new EmployeeDataInsertion();
                LoginManagement manage = new LoginManagement();
                DataBase data = new DataBase();
                Console.WriteLine("*********************Welcome to Admin Page*************************");
                Console.WriteLine("Enter your choice\n1.DataBase\n2.Main");
                int select = int.Parse(Console.ReadLine());
                do
                {
                    switch (select)
                    {
                        case 1:
                            data.GetConnection();
                            break;
                        
                        case 2:
                            manage.Management();
                            break;

                    }
                    Console.WriteLine("*********************Thank you*************************");
                    Console.WriteLine("");
                    Console.WriteLine("Enter your choice\n1.DataBase\n2.Main");
                    select = int.Parse(Console.ReadLine());
                } while (select != 3);
            }
            catch (FormatException)
            {
                Console.WriteLine("error");
                //FileLogger.Writing(e.Message);

            }
        }
    }
}
