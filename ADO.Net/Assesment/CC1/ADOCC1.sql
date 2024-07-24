create database EmployeemanagementDB

use EmployeemanagementDB
--1. Create a database called Employeemanagement
--2. Create a table in the database called Employee_Details (Empno int Primary Key,

CREATE TABLE Employee_Details (
    EmpNo INT PRIMARY KEY,  
    EmpName VARCHAR(50) NOT NULL,  
    EmpSal NUMERIC(10, 2) CHECK (EmpSal >= 25000),  
    EmpType CHAR(1) CHECK (EmpType IN ('F', 'P'))  
);


 
CREATE PROCEDURE AddEmployee
    @EmpName VARCHAR(50),
    @EmpSal NUMERIC(10, 2),
    @EmpType CHAR(1)
AS
BEGIN
    -- Declare a variable to hold the new EmpNo
    DECLARE @NewEmpNo INT;
 
    SELECT @NewEmpNo = COALESCE(MAX(EmpNo), 0) + 1 FROM Employee_Details;
 
    INSERT INTO Employee_Details (EmpNo, EmpName, EmpSal, EmpType)
    VALUES (@NewEmpNo, @EmpName, @EmpSal, @EmpType);
 
    SELECT @NewEmpNo AS NewEmpNo;
END;

EXEC AddEmployee @EmpName = 'Manu', @EmpSal = 40000, @EmpType = 'F';
EXEC AddEmployee @EmpName = 'Tanu', @EmpSal = 29000, @EmpType = 'P';

select * from  Employee_Details 


