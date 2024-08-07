use RailwayReservationsDB


CREATE TABLE Trains (
    tno INT,               
    tname NVARCHAR(100) NOT NULL,      
    [From] NVARCHAR(100) NOT NULL,    
    Dest NVARCHAR(100) NOT NULL,      
    Price DECIMAL(10, 2) NOT NULL,    
    class_of_travel NVARCHAR(10) NOT NULL, 
    train_status NVARCHAR(10) NOT NULL, 
    seats_available INT NOT NULL   
	PRIMARY KEY(tno,class_of_travel) 
);




CREATE TABLE Bookings (
    booking_iD INT PRIMARY KEY IDENTITY,  
    user_iD INT NOT NULL,                
    tno INT NOT NULL,                   
    class_of_travel NVARCHAR(10) NOT NULL, 
    no_of_seats INT NOT NULL,            
    booking_date DATETIME DEFAULT GETDATE(), 
    FOREIGN KEY (Tno) REFERENCES Trains(Tno)
);



CREATE TABLE Cancellations (
    cancellation_id INT PRIMARY KEY IDENTITY, 
    booking_id INT NOT NULL,                  
    no_of_seats_cancelled INT NOT NULL,         
    cancellation_date DATETIME DEFAULT GETDATE(), 
    FOREIGN KEY (booking_id) REFERENCES Bookings(booking_id)
);

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL, -- Ensure this can hold hashed passwords
    Email NVARCHAR(100),
    FullName NVARCHAR(100)
);



select * from Bookings

CREATE TABLE Admins (
    AdminId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL, -- Store hashed passwords
    FullName NVARCHAR(100) NOT NULL
);


select * from Cancellations
select * from Trains
select * from Admins
select * from Bookings
select * from Users


INSERT INTO Trains(tno, tname, [from], dest, price, class_of_travel, train_status, seats_available)
VALUES 
(1221, 'VandeBharath', 'Chennai', 'Bangalore', 2345.00, '1AC', 'inactive', 120),
(14543, 'Rajdhani Exp', 'Chennai', 'Delhi', 3500.00, '1AC', 'active', 24),
(14543, 'Rajdhani Exp', 'Hyderabad', 'Delhi', 3000.00, '2AC', 'active', 54)

