create database Normalization

use Normalization

--1NF
    CREATE TABLE ClientRental (
    ClientNo VARCHAR(10),
    cName VARCHAR(50),
    propertyNo VARCHAR(10),
    pAddress VARCHAR(100),
    rentStart DATE,
    rentFinish DATE,
    rent DECIMAL(10, 2),
    ownerNo VARCHAR(10),
    oName VARCHAR(50),
    PRIMARY KEY (ClientNo, propertyNo, rentStart, rentFinish)
);

INSERT INTO ClientRental VALUES
('CR76', 'Tony Shaw', 'PG4', '6 Lawrence St, Glasgow', '2000-07-01', '2001-08-31', 350, 'CO40', 'Tina Murphy'),
('CR76', 'Tony Shaw', 'PG4', '6 Lawrence St, Glasgow', '1999-09-01', '2000-01-10', 350, 'CO40', 'Tina Murphy'),
('C093', 'Aline Stewart', 'PG16', '5 Novar Dr, Glasgow', '2002-09-01', '2002-11-01', 450, 'CR76', 'John Kay'),
('C093', 'Tony Shaw', 'PG16', '5 Novar Dr, Glasgow', '2002-11-01', '2003-08-01', 450, 'CR76', 'John Kay'),
('C093', 'Tony Shaw', 'PG4', '6 Lawrence St, Glasgow', '2000-10-10', '2001-12-01', 370, 'CR76', 'John Kay');
select * from ClientRental

--1NF: Combines client, property, and rental information into a single table with atomic values and a composite primary key.
 
--2NF and 3NF
 
CREATE TABLE Client (
    ClientNo VARCHAR(10) PRIMARY KEY,
    cName VARCHAR(50)
);


INSERT INTO Client VALUES
('CR76', 'Tony Shaw'),
('C093', 'Aline Stewart');


select * from Client



CREATE TABLE Property (
    propertyNo VARCHAR(10) PRIMARY KEY,
    pAddress VARCHAR(100),
    ownerNo VARCHAR(10)
);


INSERT INTO Property VALUES
('PG4', '6 Lawrence St, Glasgow', 'CO40'),
('PG16', '5 Novar Dr, Glasgow', 'CR76');


select * from Property

CREATE TABLE Owner (
    ownerNo VARCHAR(10) PRIMARY KEY,
    oName VARCHAR(50)
);


INSERT INTO Owner VALUES
('CO40', 'Tina Murphy'),
('CR76', 'John Kay');


select * from Owner

CREATE TABLE Rental (
    ClientNo VARCHAR(10),
    propertyNo VARCHAR(10),
    rentStart DATE,
    rentFinish DATE,
    rent DECIMAL(10, 2),
    PRIMARY KEY (ClientNo, propertyNo, rentStart, rentFinish),
    FOREIGN KEY (ClientNo) REFERENCES Client(ClientNo),
    FOREIGN KEY (propertyNo) REFERENCES Property(propertyNo)
);


INSERT INTO Rental VALUES
('CR76', 'PG4', '2000-07-01', '2001-08-31', 350.00),
('CR76', 'PG4', '1999-09-01', '2000-01-10', 350.00),
('C093', 'PG16', '2002-09-01', '2002-11-01', 450.00),
('C093', 'PG16', '2002-11-01', '2003-08-01', 450.00),
('C093', 'PG4', '2000-10-10', '2001-12-01', 370.00);


select * from Rental

--2NF: Decomposes the data into separate Client, Property, Owner, and Rental tables to remove partial dependencies. Each table focuses on a specific entity and its attributes.