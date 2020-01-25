use EmployeesServerDB
CREATE TABLE EmployeeServer
(
Name VARCHAR(15) Not Null ,
Desigination VARCHAR(20) NOT NULL,
EmployeeId int identity (100,1) primary key ,
departmentId int not null,
EmailId VARCHAR(30),
DateOfBirth VARCHAR(20) Not Null,
MobileNumber bigint not null,
Salary NUMERIC Not Null,
UserName VARCHAR(20),
UserPassword VARCHAR(20),
Roll VARCHAR(20),
)

insert into employeeserver(Name,Desigination,EmailId,DateOfBirth,MobileNumber,departmentId,Salary,UserName,userPassword,Roll)Values('jai','java','jai@gmail.com','14/11/1999',9025485632,1,451245,'jai14','jai123','admin')
select * from EmployeeServer

--CREATE TABLE Department
--(
--departmentId INT IDENTITY(1,1) PRIMARY KEY,
--departmentName VARCHAR(16) NOT NULL)
--SELECT * FROM Department
--INSERT INTO Department(departmentName)VALUES('manager')
--INSERT INTO Department(departmentName)VALUES('manager1')
--INSERT INTO Department(departmentName)VALUES('manager2')




Select *From EmployeeServer ,Department where EmployeeServer.departmentId=Department.departmentId 



create procedure Insert_employee
@Name VARCHAR(15) ,
@Desigination VARCHAR(20) ,
@departmentId int ,
@Email VARCHAR(30),
@DOB VARCHAR(20),
@MobileNumber bigint ,
@Salary NUMERIC ,
@UserName VARCHAR(20),
@UserPassword VARCHAR(20),
@Roll VARCHAR(20)
 as 
 begin 
 insert into  EmployeeServer(Name,Desigination,departmentId,EmailId,DateOfBirth,MobileNumber,Salary,UserName,Userpassword,Roll) VALUES (@Name, @Desigination,@departmentId,@Email,@DOB,@MobileNumber, @Salary,@UserName,@UserPassword,@Roll)
 end
 

 drop procedure Insert_employee
 create procedure Select_employee
 @Name VARCHAR(15)
 as
 begin
 Select * from EmployeeServer where @Name=Name
 end

 select * from EmployeeServer
 DROP TABLE Department
drop table EmployeeServer

--FOREIGN KEY(departmentId) REFERENCES Department(departmentId),--DepartmentName VARCHAR(8) Not Null,