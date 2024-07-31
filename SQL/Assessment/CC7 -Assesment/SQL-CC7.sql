use Assessmentdatabase

-- Create books table
CREATE TABLE books (
    id INT PRIMARY KEY,
    title VARCHAR(50),
    author VARCHAR(50),
    isbn VARCHAR(20) UNIQUE,
    published_date DATETIME
)
 
 -- Insert data into books table
INSERT INTO books (id, title, author, isbn, published_date) VALUES
    (1, 'My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
    (2, 'My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
    (3, 'My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');

select * from books

--  Write a query to fetch the details of the books written by author whose name ends with er.
select * from books
WHERE author LIKE '%er';

-- Create reviews table
CREATE TABLE reviews (
    id INT PRIMARY KEY,
    book_id INT,
    reviewer_name VARCHAR(50),
    content VARCHAR(255),
    rating INT,
    published_date DATETIME,
    FOREIGN KEY (book_id) REFERENCES books(id)
)

-- Insert data into reviews table
INSERT INTO reviews (id, book_id, reviewer_name, content, rating, published_date) VALUES
    (1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11.1'),
    (2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12.6'),
    (3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

select * from reviews

--Display the Title ,Author and ReviewerName for all the books from the above table 
select books.title, 
       books.author, 
       reviews.reviewer_name
from books
JOIN reviews ON 
books.id = reviews.book_id;

--Display the  reviewer name who reviewed more than one book.t
select reviewer_name
from reviews
GROUP BY reviewer_name
having COUNT(DISTINCT book_id) > 1;

CREATE TABLE Customer (
    id INT PRIMARY KEY,
    name VARCHAR(50),
    address VARCHAR(100),
    age INT,
    salary FLOAT
)
 
INSERT INTO Customer (id, name, address, age, salary)
VALUES 
    (1, 'RAMESH', 'AHMEDABAD',  32, 2000.00),
    (2, 'KHILAN', 'DELHI', 25, 1500.00),
    (3, 'KAUSHIK', 'KOTA', 23, 2000.00),
	(4,'CHAITALI','MUMBAI',25,6500.00),
	(5,'HARDIK','BHOPAL',27,8500.00),
	(6,'KOMAL','MP',22,4500),
	(7,'MUFFY','INDORE',24,10000)
 
select * from Customer

--Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address
SELECT name
FROM Customer
WHERE address LIKE '%o%'

CREATE TABLE ORDERS (
    ORDERID INT PRIMARY KEY,
    ORDER_DATE DATETIME,
    CUSTOMER_ID INT,
    AMOUNT FLOAT,
   )
 
INSERT INTO ORDERS (Orderid, Order_date, Customer_id, Amount) 
VALUES (102, '2009-10-08 00:00:00', 3, 3000),
       (100, '2009-10-08 00:00:00', 3, 1500),
       (101, '2008-05-20 00:00:00',2, 1560),
	   (103, '2008-05-20 00:00:00',4, 2060)

select * from ORDERS

--Write a query to display the   Date,Total no of customer  placed order on same Date
SELECT order_date, COUNT(DISTINCT customer_id) AS TotalCustomers
FROM ORDERS
GROUP BY order_date


CREATE TABLE Employee_new(
    id INT PRIMARY KEY,
    name VARCHAR(50),
    address VARCHAR(100),
    age INT,
    salary FLOAT
)

 
INSERT INTO Employee_new(id, name, address, age, salary)
VALUES 
    (1, 'RAMESH', 'AHMEDABAD',  32, 2000.00),
    (2, 'KHILAN', 'DELHI', 25, 1500.00),
    (3, 'KAUSHIK', 'KOTA', 23, 2000.00),
	(4,'CHAITALI','MUMBAI',25,6500.00),
	(5,'HARDIK','BHOPAL',27,8500.00),
	(6,'KOMAL','MP',22,NULL),
	(7,'MUFFY','INDORE',24,NULL)

select * from Employee_new

--Display the Names of the Employee in lower case, whose salary is null 
SELECT LOWER(name) AS LowercaseName
FROM Employee_new
WHERE salary IS NULL

CREATE TABLE Students (
    reg INT PRIMARY KEY,
    name VARCHAR(100),
    age INT,
    qualification VARCHAR(100),
    mobile_no VARCHAR(15),
    mail_id VARCHAR(100),
    location VARCHAR(255),
    gender CHAR(1)
)
 
 INSERT INTO Students (reg, name,  age, qualification, mobile_no, mail_id, location, gender)
VALUES 
    (2, 'SAI', 22, 'BE', '9952836777', 'SAI@GMAIL.COM', 'CHENNAI', 'M'),
    (3, 'KUMAR', 20, 'BSC', '7890125648', 'KUMAR@GMAIL.COM', 'MADURAI', 'M'),
    (4, 'SELVI',  22, 'B  TECH', '8904567342', 'SELVI@GMAIL.COM', 'SELAM', 'F'),
    (5, 'NISHA',  25, 'ME', '7834672310', 'NISHA@GMAIL.COM', 'THENI', 'F'),
    (6, 'SAISARAN',  21, 'BA', '7890345678', 'SARAN@GMAIL.COM', 'MADURAI', 'F'),
    (7, 'TOM',  23, 'BCA', '8901234675', 'TOM@GMAIL.COM', 'PUNE', 'M')

select * from Students

--Write a sql server query to display the Gender,Total no of male and female from the above relation    .
select gender, COUNT(*) AS TotalEmployees
from Students
GROUP BY gender