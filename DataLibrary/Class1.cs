using System;

namespace PayrollSystem
{
    public class Data
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public int EmployeeId { get; set; }
        public string EmailID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Mobilenumber { get; set; }
        public string DepartmentName { get; set; }
        public double Salary { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Data() { }
        public Data(string Name, int EmployeeId, string Designation, string EmailID, DateTime DateOfBirth, long Mobilenumber, string DepartmentName, double Salary,string UserName,string Password)
        {
            this.Name = Name;
            this.EmployeeId = EmployeeId;
            this.EmailID = EmailID;
            this.Designation = Designation;
            this.DateOfBirth = DateOfBirth;
            this.Mobilenumber = Mobilenumber;
            this.DepartmentName = DepartmentName;
            this.Salary = Salary;
            this.UserName = UserName;
            this.Password = Password;
        }
        public override string ToString()
        {
            return "Employee Name:" + Name + "Employee ID :" + EmployeeId + " Employee Email :" + EmailID + "Employee Designation :" + Designation + " Employee DOB :" + DateOfBirth + "Employee Mobile Number :" + Mobilenumber + "Employee Salary :" + Salary+ "Employee UserName :" +UserName+ "Login Password:" +Password;
        }
    }
  

}
