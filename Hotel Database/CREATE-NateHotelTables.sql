Use master;

GO

if exists (select * from sysdatabases where name='NateHotel')
		drop database NateHotel
go

CREATE DATABASE NateHotel;

Go

USE NateHotel;

GO

CREATE TABLE CustomerAddress (
	addressID INT IDENTITY(1,1) PRIMARY KEY,
	email NVARCHAR(30) NULL,
	street1 NVARCHAR(30) NOT NULL,
	street2 VARCHAR(30) NULL,
	city VARCHAR (30) NOT NULL,
	cuState VARCHAR (15) NOT NULL,
	zip int NOT NULL,
	country VARCHAR(30) NOT NULL
);

CREATE TABLE Customer (
	customerID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	addressID INT FOREIGN KEY REFERENCES CustomerAddress(addressID)
);

CREATE TABLE DateRange (
	dateRangeID INT IDENTITY(1,1) PRIMARY KEY,
	dateRange VARCHAR(30) NOT NULL,
	dateRangePrice DECIMAL NOT NULL, 
);

CREATE TABLE RoomType (
	typeID INT IDENTITY(1,1) PRIMARY KEY,
	typeOf VARCHAR(15) NOT NULL,
	occupancy INT NOT NULL,
	basePrice DECIMAL NOT NULL,
);

CREATE TABLE Room (
	roomID INT IDENTITY(1,1) PRIMARY KEY,
	number INT NOT NULL,
	roomFloor INT NOT NULL,
	typeID INT FOREIGN KEY REFERENCES RoomType(typeID)
);

CREATE TABLE DateAndRoom (
	specificDate DateTime2 NOT NULL,
	dateRangeID INT NOT NULL,
	roomID INT NOT NULL,
	CONSTRAINT PK_DateRange
		PRIMARY KEY (dateRangeID, roomID, specificDate),
	CONSTRAINT FK_Room_DateAndType
		FOREIGN KEY (roomID)
		REFERENCES Room(RoomID),
	CONSTRAINT FK_DateRange_DateAndType
		FOREIGN KEY (dateRangeID)
		REFERENCES DateRange(dateRangeID)
);

CREATE TABLE Amenity (
	amenityID INT IDENTITY(1,1) PRIMARY KEY,
	amenityType VARCHAR(30) NOT NULL,
	amenityCost DECIMAL NOT NULL
);

CREATE TABLE RoomAmenity (
	roomID INT NOT NULL,
	amenityID INT NOT NULL,
	CONSTRAINT PK_RoomAmenity
		PRIMARY KEY (roomID, amenityID),
	CONSTRAINT FK_Amenity_RoomAmenity
		FOREIGN KEY (amenityID)
		REFERENCES Amenity(amenityID),
	CONSTRAINT FK_Room_RoomAmenity
		FOREIGN KEY (roomID)
		REFERENCES Room(roomID)
);

CREATE TABLE GuestRoom (
	guestRoomID INT IDENTITY(1,1) PRIMARY KEY,
	roomID INT FOREIGN KEY REFERENCES Room(roomID),
	customerID INT FOREIGN KEY REFERENCES Customer(customerID)
);

CREATE TABLE AddOn (
	addOnID INT IDENTITY(1,1) PRIMARY KEY,
	addOn VARCHAR(30) NOT NULL,
	addOnRate Decimal NULL,
);

CREATE TABLE GuestRoomAddOn (
	guestRoomID INT NOT NULL,
	addOnID INT NOT NULL,
	CONSTRAINT PK_GuestRoom
		PRIMARY KEY (guestRoomID, addOnID),
	CONSTRAINT FK_AddOn_GuestRoomAddOn
		FOREIGN KEY (addOnID)
		REFERENCES AddOn(addOnID),
	CONSTRAINT FK_GuestRoom_GuestRoomAddOn
		FOREIGN KEY (guestRoomID)
		REFERENCES GuestRoom(guestRoomID)
);

CREATE TABLE Promotion (
	promotionID INT IDENTITY(1,1) PRIMARY KEY,
	promoType VARCHAR(30) NOT NULL,
	promoValue DECIMAL NOT NULL,
	validDateRange VARCHAR(30) NOT NULL
);

CREATE TABLE RoomReservation (
	roomReservationID INT IDENTITY(1,1) PRIMARY KEY,
	Tax DECIMAL(5,2) NULL,
	Total DECIMAL(5,2) NOT NULL,
	guestRoomID INT FOREIGN KEY REFERENCES GuestRoom(guestRoomID),
	promotionID INT FOREIGN KEY REFERENCES Promotion(promotionID)
);

CREATE TABLE GuestList (
	guestListID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	roomReservationID INT FOREIGN KEY REFERENCES RoomReservation(roomReservationID)
);

CREATE TABLE FinalBill (
	finalBillID INT IDENTITY(1,1) PRIMARY KEY,
	Notes NVARCHAR(150) NULL,
	total DECIMAL(5,2) NOT NULL,
);

CREATE TABLE ReservationBill(
	roomReservationID INT NOT NULL,
	finalBillID INT NOT NULL,
	CONSTRAINT PK_ReservationBill
		PRIMARY KEY (roomReservationID, finalBillID),
	CONSTRAINT FK_FinalBill_ReservationBill
		FOREIGN KEY (finalBillID)
		REFERENCES FinalBill(finalBillID),
	CONSTRAINT FK_RoomReservation_ReservationBill
		FOREIGN KEY (roomReservationID)
		REFERENCES RoomReservation(roomReservationID)
);

INSERT INTO CustomerAddress (email, street1, city, cuState, zip, country)
VALUES ('jim_bob@jimbob.com', '33 Kentucky Ave', 'Louisville', 'KY', '40202', 'USA'),
       ('tim_bob@timbob.com', '77 Coral Way', 'Louisville', 'KY', '40210', 'USA'),
	   ('sam_bob@sambob.com', '23 Jordan Court', 'Louisville', 'KY', '40110', 'USA'),
	   ('jane_bob@janebob.com', '89 Broken Tree Way', 'Louisville', 'KY', '40222', 'USA'),
	   ('janice_bob@janicebob.com', '67 Morning Brook Court', 'Columbus', 'OH', '47674', 'USA');

INSERT INTO Customer (FirstName, LastName, addressID)
VALUES ('Jim', 'Bob', '1'),
	   ('Tim', 'Bob', '2'),
	   ('Sam', 'Bob', '3'),
	   ('Jane', 'Bob', '4'),
	   ('Janice', 'Bob', '5');

INSERT INTO DateRange (dateRange, dateRangePrice)
VALUES('Weekend', '50'),
	  ('Weekday', '10'),
	  ('Holiday', '100');
	  
INSERT INTO RoomType (typeOf, occupancy, basePrice)
Values ('Single', '2', '50'),
	   ('Double', '4', '90'),
	   ('King', '4', '140'),
	   ('King Suite', '6', '200');

INSERT INTO Amenity (amenityType, amenityCost)
VALUES ('TV', '0'),
	   ('Refrigerator', '10'),
	   ('Gaming System', '10'),
	   ('Jacuzzi', '20'),
	   ('Massage Chair', '50');

INSERT INTO Room (number, roomFloor, typeID)
VALUES ('101', '1', '2'),
	   ('102', '1', '2'),
	   ('103', '1', '2'),  
	   ('305', '3', '3'),
	   ('306', '3', '3'),
	   ('307', '3', '4'),
	   ('405', '4', '1');

INSERT INTO AddOn (addOn, addOnRate)
VALUES ('Scented Oils', '10'),
	   ('Room Service', '15'),
	   ('Movie', '5');

INSERT INTO RoomAmenity (roomID, amenityID)
VALUES ('1', '1'),
	   ('2', '1'),
	   ('3', '1'),
	   ('3', '2'),
	   ('3', '3'),
	   ('4', '1'),
	   ('4', '2'),
	   ('4', '3'),
	   ('4', '4'),
	   ('5', '1'),
	   ('5', '2'),
	   ('5', '3'),
	   ('5', '4'),
	   ('6', '1'),
	   ('6', '2'),
	   ('6', '3'),
	   ('6', '4'),
	   ('6', '5'),
	   ('7', '1');

INSERT INTO Promotion (promoType, promoValue, validDateRange)
VALUES ('Conference', '.90', '10/3/17-10/5/17'),
	   ('Manager Discretion', '50', 'Current Bill'),
	   ('VIP', '.50', '5/15/2010-5/16/2010'); 

INSERT INTO GuestRoom(customerID, roomID)
VALUES ('1', '1'),
	   ('2', '2'),
	   ('3', '3'),
	   ('4', '7'),
	   ('5', '4');	

INSERT INTO GuestRoomAddOn (guestRoomID, addOnID)
VALUES ('1','2'),
	   ('4', '3');

INSERT INTO DateAndRoom (specificDate, dateRangeID, roomID)
VALUES ('5/15/2010', '1', '1'),
	   ('5/15/2010', '1', '2'),
	   ('5/15/2010', '1', '3'),
	   ('5/16/2010', '1', '1'),
	   ('5/16/2010', '1', '2'),
	   ('5/16/2010', '1', '3'),
	   ('10/15/2011', '2', '1'),
	   ('10/15/2011', '2', '2'),
	   ('10/15/2011', '2', '3'),
	   ('10/27/2017', '3', '7');

INSERT INTO RoomReservation(guestRoomID, promotionID, Tax, Total)
VALUES ('1', '3', '9.30', '82.15'),
	   ('1', '3', '9.30', '82.15'),
	   ('2', '3', '8.40', '74.20'),
	   ('2', '3', '8.40', '74.20'),
	   ('3', '3', '9.00', '79.50'),
	   ('3', '3', '9.00', '79.50'),
	   ('1', null, '6.90', '121.90'),
	   ('2', null, '6.00', '106.00'),
	   ('3', null, '6.60', '116.60'),
	   ('4', null, '9.30', '164.30')


INSERT INTO GuestList (FirstName, LastName, Age, roomReservationID)
VALUES ('Courtney', 'Bob', '32', '1'),
	   ('Stephanie', 'Bob', '34', '4'),
	   ('Jennifer', 'Bob', '33', '3')

INSERT INTO FinalBill (Notes, total)
VALUES ('Two Night VIP Stay', '164.30'),
	   ('Two Night VIP Stay', '148.40'),
	   ('Two Night VIP Stay', '155.00'),
	   (null, '121.90'),
	   (null, '106.00'),
	   (null, '116.60'),
	   (null, '164.30')

INSERT INTO ReservationBill (finalBillID, roomReservationID)
VALUES ('1', '1'),
	   ('1', '2'),
	   ('2', '3'),
	   ('2', '4'),
	   ('3', '5'),
	   ('3', '6'),
	   ('4', '7'),
	   ('5', '8'),
	   ('6', '9'),
	   ('7', '10')
	   

 
