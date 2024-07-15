use Assignmentdatabase

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
 
-- 1. List all employees whose name begins with 'A'. 
select * from EMP where ENAME LIKE 'A%';
 
-- 2. Select all those employees who don't have a manager.
select * from EMP where MGR_ID IS NULL;
 
-- 3. List employee name, number and salary for those employees who earn in the range 1200 to 1400.
select ENAME, EMPNO, SAL from EMP where SAL BETWEEN 1200 AND 1400;
 
-- 4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise. 
-- Before the rise
select * from EMP where DEPTNO = 20;
 
-- Apply the pay rise
update EMP set SAL = SAL * 1.10 where DEPTNO = 20;
 
-- After the rise
select * from EMP where DEPTNO = 20;
 
-- 5. Find the number of CLERKS employed. Give it a descriptive heading.
select COUNT(*) AS NumberOfClerks from EMP where JOB = 'CLERK';
 
-- 6. Find the average salary for each job type and the number of people employed in each job.
select JOB, AVG(SAL) AS AverageSalary, COUNT(*) AS NumberOfEmployees 
from EMP 
GROUP BY JOB;
 
-- 7. List the employees with the lowest and highest salary.
-- Employee with the lowest salary
select * from EMP where SAL = (select MIN(SAL) from EMP);
 
-- Employee with the highest salary
select * from EMP where SAL = (select MAX(SAL) from EMP);
 
-- 8. List full details of departments that don't have any employees.
select * from DEPT 
where DEPTNO NOT IN (select DISTINCT DEPTNO from EMP);
 
-- 9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name. 
select ENAME, SAL from EMP 
where JOB = 'ANALYST' AND SAL > 1200 AND DEPTNO = 20 
ORDER BY ENAME ASC;
 
-- 10. For each department, list its name and number together with the total salary paid to employees in that department.
select D.DEPTNO, D.DNAME, SUM(E.SAL) AS TotalSalary
from DEPT D
LEFT JOIN EMP E ON D.DEPTNO = E.DEPTNO
GROUP BY D.DEPTNO, D.DNAME;
 
-- 11. Find out salary of both MILLER and SMITH.
select ENAME, SAL from EMP where ENAME IN ('MILLER', 'SMITH');
 
-- 12. Find out the names of the employees whose name begin with ‘A’ or ‘M’.
select ENAME from EMP where ENAME LIKE 'A%' OR ENAME LIKE 'M%';
 
-- 13. Compute yearly salary of SMITH.
select ENAME, SAL * 12 AS YearlySalary from EMP where ENAME = 'SMITH';
 
-- 14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850.
SELECT ENAME, SAL FROM EMP WHERE SAL NOT BETWEEN 1500 AND 2850;
 
-- 15. Find all managers who have more than 2 employees reporting to them
select MGR_ID, COUNT(*) AS NumberOfEmployees
from EMP where MGR_ID IS NOT NULL
GROUP BY MGR_ID
HAVING COUNT(*) > 2;
