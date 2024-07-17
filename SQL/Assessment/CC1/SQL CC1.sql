create database Assessmentdatabase

use Assessmentdatabase

--1.  Write a query to display your birthday( day of week)
SELECT DATENAME(WEEKDAY, '2001-06-12') AS DayOfWeek


--2.  Write a query to display your age in days
SELECT DATEDIFF(DAY, '2001-06-12', GETDATE()) AS AgeInDays

--3.  Write a query to display all employees information those who joined before 5 years in the current month

-- Create EMP Table
create table EMP (
    EMPNO INT PRIMARY KEY,
    ENAME VARCHAR(20),
    JOB VARCHAR(20),
    MGR_ID INT,
    HIREDATE DATE,
    SAL DECIMAL(7, 2),
    COMM DECIMAL(7, 2),
    DEPTNO INT,
    FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO)
);

-- Insert data into EMP
insert into EMP values
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);
 
 select * from EMP;
 
-- Create DEPT Table
create table DEPT (
    DEPTNO INT PRIMARY KEY,
    DNAME VARCHAR(20),
    LOC VARCHAR(20)
);
 
-- Insert data into DEPT
insert into DEPT values
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');
 
select * from DEPT;

ALTER table EMP
ALTER column HIREDATE DATE;
 
update EMP
SET HIREDATE = '2020-09-17'
WHERE empno = 7788; 
 
 
--3.  Write a query to display all employees information those who joined before 5 years in the current month
SELECT * FROM EMP
WHERE HIREDATE < DATEADD(YEAR, -5, GETDATE())

--4.  Create table Employee with empno, ename, sal, doj columns and perform the following operations in a single transaction

 BEGIN TRANSACTION;

 -- Create the Employee table
CREATE TABLE Employee (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    sal DECIMAL(10, 2),
    doj DATE
);

    --a. First insert 3 rows 
	INSERT INTO Employee (empno, ename, sal, doj)
VALUES 
(1234, 'Ranju', 5000, '2018-01-15'),
(2234, 'Madhu', 9000, '2019-04-01'),
(3678, 'Sudha', 8000, '2014-09-15');
 
  select * from Employee;

  
  --b. Update the second row sal with 15% increment
  UPDATE Employee
SET sal = sal * 1.15
WHERE empno = 2234;
 
 select * from Employee;

BEGIN TRANSACTION;

 --c. Delete first row.

 DELETE from Employee
WHERE empno = 1234;
 
select * from Employee;

rollback

--5. Create a user defined function calculate Bonus for all employees of a  given job using 	following conditions
CREATE OR ALTER FUNCTION CalculateBonus (@DEPTNO INT, @sal FLOAT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @bonus FLOAT;
 
    IF @DEPTNO = 10
        SET @bonus = @sal * 0.15;
    ELSE IF @DEPTNO = 20
        SET @bonus = @sal * 0.20;
    ELSE
        SET @bonus = @sal * 0.05;
 
    RETURN @bonus;
END;

----a. For Deptno 10 employees (15% of sal as bonus):
SELECT ename, sal, dbo.CalculateBonus(DEPTNO, SAL) AS bonus
FROM EMP
WHERE DEPTNO = 10;



---b. For Deptno 20 employees (20% of sal as bonus):
SELECT ename, sal, dbo.CalculateBonus(DEPTNO, SAL) AS bonus
FROM EMP
WHERE DEPTNO = 20;


---c. For other department employees (5% of sal as bonus):
SELECT ename, sal, dbo.CalculateBonus(DEPTNO, SAL) AS bonus
FROM EMP
WHERE DEPTNO NOT IN (10, 20);




