use Assignmentdatabase

--1.Write a T-SQL Program to find the factorial of a given number

DECLARE @Number INT = 8;
DECLARE @Factorial INT = 1;
DECLARE @Counter INT = 1;
 
WHILE @Counter <= @Number
BEGIN
    SET @Factorial = @Factorial * @Counter;
    SET @Counter = @Counter + 1;
END
 
PRINT 'Factorial of ' + CAST(@Number AS VARCHAR(10)) + ' is: ' + CAST(@Factorial AS VARCHAR(20));
 

 --2.Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number.
 
CREATE OR ALTER PROC GenerateMultiplicationTable 
@number INT
AS
BEGIN
    DECLARE @multiplier INT = 1;
    DECLARE @result INT;
 
    WHILE @multiplier <= 10
    BEGIN
        SET @result = @number * @multiplier;
        PRINT CONCAT(@number, ' * ', @multiplier, ' = ', @result);
        SET @multiplier = @multiplier + 1;
    END
END;

EXEC GenerateMultiplicationTable @number = 2;



---3.Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
 
CREATE TABLE Holiday (
    holiday_date DATE PRIMARY KEY,
    holiday_name VARCHAR(100)
)
 
 
INSERT INTO Holiday (holiday_date, holiday_name)
VALUES 
    ('2024-08-15', 'Independence Day'),
    ('2024-01-26', 'Republic Holiday'),
    ('2024-12-25', 'Christmas'),
    ('2025-01-01', 'New Year')


select * from Holiday
 
 
CREATE OR ALTER TRIGGER RestrictDataManipulationOnHolidays
ON Emp
INSTEAD OF INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @IsHoliday BIT;
    DECLARE @HolidayName VARCHAR(100);
 
    -- Check if today is a holiday
    SELECT TOP 1 @HolidayName = holiday_name
    FROM Holiday
    WHERE holiday_date = CONVERT(DATE, GETDATE());
 
    IF @HolidayName IS NOT NULL
    BEGIN
        -- Raise an error if today is a holiday
        RAISERROR('Due to %s, you cannot manipulate data.', 16, 1, @HolidayName);
    END
    ELSE
    BEGIN
        -- If it's not a holiday, allow the operation
        PRINT 'Data manipulation is allowed on non-holiday dates.';

       INSERT INTO Emp (empno, ename, sal) VALUES (1558, 'Ranju', 3000);
 
         --UPDATE Emp SET ename = 'Smith' WHERE ename = 'John';
 
         --DELETE FROM Emp WHERE empno = 1552;
    END
END;