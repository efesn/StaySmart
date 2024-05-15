CREATE DATABASE Reservation_Management_System;
USE Reservation_Management_System;


CREATE TABLE User_Table (
	User_ID INT IDENTITY(1,1) NOT NULL,
	User_Name VARCHAR(50) NOT NULL,
	User_Password VARCHAR(150) NOT NULL,
	UserRole VARCHAR(20) NOT NULL,
	Email VARCHAR(100) NULL,
    OTP VARCHAR(6) NULL,
	CONSTRAINT User_Table_User_ID_PK PRIMARY KEY (User_ID)
);


INSERT INTO User_Table (User_Name, User_Password, UserRole) VALUES ('efesn', '1234', 'Admin');
INSERT INTO User_Table (User_Name, User_Password, UserRole) VALUES ('user1', '4321', 'User');


CREATE TABLE Add_Place (
    placeId INT IDENTITY(1,1) PRIMARY KEY, 
	placeName VARCHAR(50) NOT NULL,
    placeAddress VARCHAR(250) NOT NULL,
	placeContact VARCHAR(20) NOT NULL
);

CREATE TABLE New_Reservation (
    newReservationId INT IDENTITY(1,1) PRIMARY KEY,
    customerName VARCHAR(100) NOT NULL,
    customerEmail VARCHAR(100) NOT NULL,
    gender VARCHAR(50) NOT NULL,
    placeId INT NOT NULL, 
    customerContact VARCHAR(20) NOT NULL,
    checkin DATETIME NOT NULL,  
    checkout DATETIME,          
    otp VARCHAR(6) NULL,
    User_ID INT NOT NULL, 
    CONSTRAINT FK_New_Reservation_User FOREIGN KEY (User_ID) REFERENCES User_Table(User_ID),
    CONSTRAINT FK_New_Reservation_Place FOREIGN KEY (placeId) REFERENCES Add_Place(placeId)
);


