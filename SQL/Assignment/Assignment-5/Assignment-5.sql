use Assignmentdatabase

--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition
 
   --a) HRA as 10% of Salary
   --b) DA as 20% of Salary
   --c) PF as 8% of Salary
   --d) IT as 5% of Salary
   --e) Deductions as sum of PF and IT
   --f) Gross Salary as sum of Salary, HRA, DA
   --g) Net Salary as Gross Salary - Deductions
 
--Print the payslip neatly with all details
 

CREATE OR ALTER PROCEDURE GeneratePayslip
    @empId INT
AS
BEGIN
    DECLARE @Salary FLOAT
    DECLARE @HRA FLOAT
    DECLARE @DA FLOAT
    DECLARE @PF FLOAT
    DECLARE @IT FLOAT
    DECLARE @Deductions FLOAT
    DECLARE @GrossSalary FLOAT
    DECLARE @NetSalary FLOAT
 
    -- Fetch Salary from the employee table
    SELECT @Salary = sal
    FROM EMP
    WHERE empno = @empId
 
    -- Calculate HRA, DA, PF, IT
    SET @HRA = @Salary * 0.10
    SET @DA = @Salary * 0.20
    SET @PF = @Salary * 0.08
    SET @IT = @Salary * 0.05
 
    -- Calculate deductions and gross salary
    SET @Deductions = @PF + @IT
    SET @GrossSalary = @Salary + @HRA + @DA
 
    -- Calculate net salary
    SET @NetSalary = @GrossSalary - @Deductions
 
    -- Print payslip details
    PRINT 'Employee Payslip for Employee ID: ' + CAST(@empId AS VARCHAR(10))
    PRINT 'Basic Salary: ' + CAST(@Salary AS VARCHAR(20))
    PRINT 'HRA: ' + CAST(@HRA AS VARCHAR(20))
    PRINT 'DA: ' + CAST(@DA AS VARCHAR(20))
    PRINT 'PF: ' + CAST(@PF AS VARCHAR(20))
    PRINT 'IT: ' + CAST(@IT AS VARCHAR(20))
    PRINT 'Total Deductions: ' + CAST(@Deductions AS VARCHAR(20))
    PRINT 'Gross Salary: ' + CAST(@GrossSalary AS VARCHAR(20))
    PRINT 'Net Salary: ' + CAST(@NetSalary AS VARCHAR(20))
END
 
-- Execute the procedure
EXEC GeneratePayslip @empId = 7369
 
-- Select all data from tblEMP for verification
SELECT * FROM tblEMP
 
 
 