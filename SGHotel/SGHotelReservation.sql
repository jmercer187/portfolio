USE Master;
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE NAME='SGHotel')
		DROP DATABASE SGHotel
go

CREATE DATABASE SGHotel
GO

USE SGHotel;
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='RoomType')
	DROP TABLE RoomType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='HotelRoom')
	DROP TABLE HotelRoom
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='RoomAmenities')
	DROP TABLE RoomAmenities
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='RoomAmenitiesHotelRoom')
	DROP TABLE RoomAmenitiesHotelRoom
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Promotion')
	DROP TABLE Promotion
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='HotelRoomPrice')
	DROP TABLE HotelRoomPrice
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Customer')
	DROP TABLE Customer
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='CustomerBill')
	DROP TABLE CustomerBill
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ReservationTable')
	DROP TABLE ReservationTable
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Guest')
	DROP TABLE Guest
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ReservationGuest')
	DROP TABLE ReservationGuest
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='RoomService')
	DROP TABLE RoomService
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ReservationService')
	DROP TABLE ReservationService
GO

CREATE TABLE RoomType (
	RoomTypeID int PRIMARY KEY IDENTITY(1,1),
	RoomType nvarchar(30) NOT NULL,
	MaxOccupancy tinyint NOT NULL,
)
GO

CREATE TABLE HotelRoom (
	RoomID int PRIMARY KEY IDENTITY(1,1),
	RoomTypeID int NOT NULL FOREIGN KEY REFERENCES RoomType(RoomTypeID),
	RoomNumber smallint NOT NULL,
	RoomFloor smallint NOT NULL,
)
GO

CREATE TABLE RoomAmenities (
	AmenityID int PRIMARY KEY IDENTITY(1,1),
	Amenity nvarchar(50) NOT NULL,
	AmenityDescription nvarchar(255) NULL,
	AmenityCost decimal(19,2) NOT NULL
)
GO

CREATE TABLE RoomAmenitiesHotelRoom (
	RoomAmenitiesHotelRoomID int PRIMARY KEY IDENTITY(1,1),
	RoomID int NOT NULL FOREIGN KEY REFERENCES HotelRoom(RoomID),
	AmenityID int NOT NULL FOREIGN KEY REFERENCES RoomAmenities(AmenityID)
)
GO

CREATE TABLE Promotion (
	PromotionID int PRIMARY KEY IDENTITY(1,1),
	TypeOfPromotion nvarchar(50) NOT NULL,
	FromDate smalldatetime NOT NULL,
	ToDate smalldatetime NULL,
)
GO

CREATE TABLE HotelRoomPrice (
	HotelRoomPriceID int PRIMARY KEY IDENTITY(1,1),
	PromotionID int NULL FOREIGN KEY REFERENCES Promotion(PromotionID),
	RoomID int NOT NULL FOREIGN KEY REFERENCES HotelRoom(RoomID),
	Price decimal(19,2) NOT NULL,
	FromDate smalldatetime NOT NULL,
	ToDate smalldatetime NULL,
)
GO

CREATE TABLE Customer (
	CustomerID int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	Phone nvarchar(15) NULL,
	Email nvarchar(30) NULL,
)
GO

CREATE TABLE CustomerBill (
	CustomerBillID int PRIMARY KEY IDENTITY(1,1),
	CustomerID int NOT NULL FOREIGN KEY REFERENCES Customer(CustomerID),
	RoomCharges decimal(19,2) NULL,
	RoomServiceCharges decimal(19,2) NULL,
	TotalCharge decimal(19,2) NULL,
	PriceOverride decimal(19,2) NULL,
)
GO

CREATE TABLE ReservationTable (
	ReservationID int PRIMARY KEY IDENTITY(1,1),
	CustomerBillID int NOT NULL FOREIGN KEY REFERENCES CustomerBill(CustomerBillID),
	HotelRoomPriceID int NOT NULL FOREIGN KEY REFERENCES HotelRoomPrice(HotelRoomPriceID),
	FromDate smalldatetime NOT NULL,
	ToDate smalldatetime NOT NULL,
)
GO

CREATE TABLE Guest (
	GuestID int PRIMARY KEY IDENTITY(1,1),
	GuestAge int NOT NULL,
	FirstName nvarchar(30) NULL,
	LastName nvarchar(30) NULL,
)
GO

CREATE TABLE ReservationGuest (
	ReservationGuestID int PRIMARY KEY IDENTITY(1,1),
	ReservationID int NOT NULL FOREIGN KEY REFERENCES ReservationTable(ReservationID),
	GuestID int NOT NULL FOREIGN KEY REFERENCES Guest(GuestID),
)
GO

CREATE TABLE RoomService (
	RoomServiceID int PRIMARY KEY IDENTITY(1,1),
	RoomServiceType nvarchar(50) NOT NULL,
	RoomServicePrice decimal(19,2) NOT NULL,
	FromDate smalldatetime NOT NULL,
	ToDate smalldatetime NULL,
)
GO

CREATE TABLE ReservationService (
	ReservationServiceID int PRIMARY KEY IDENTITY(1,1),
	ReservationID int NOT NULL FOREIGN KEY REFERENCES ReservationTable(ReservationID),
	RoomServiceID int NOT NULL FOREIGN KEY REFERENCES RoomService(RoomServiceID),
)
GO


USE SGHotel;
GO


INSERT INTO RoomType (RoomType, MaxOccupancy)
VALUES ('Single Queen', 2),
('Single King', 2),
('Double Queen', 4),
('King Suite', 4),
('Double Queen Suite', 6)

INSERT INTO HotelRoom (RoomTypeID, RoomNumber, RoomFloor)
VALUES (1, 100, 1),
(1, 102, 1),
(2, 200, 2),
(2, 201, 2),
(3, 103, 1),
(3, 203, 2),
(4, 300, 3),
(4, 105, 1),
(5, 301, 3),
(5, 302, 3)

INSERT INTO RoomAmenities (Amenity, AmenityDescription, AmenityCost)
VALUES ('Hot Tub', NULL, 37.00),
('Big Screen TV', NULL, 20.00),
('Video Game System', 'it has all the games, goes perfect with a big screen tv', 14.95)

INSERT INTO RoomAmenitiesHotelRoom (RoomID, AmenityID)
VALUES (7, 1),
(10, 1),
(5, 2),
(5, 3),
(2, 2)

INSERT INTO Promotion (TypeOfPromotion, FromDate, ToDate)
VALUES ('2016 Off Season - Rate Reduction', 2016-09-01, 2017-04-10),
('2016 New Years - Rate Increase', 2016-12-27, 2017-01-03),
('2017 Off Season - Rate Reduction', 2017-09-01, 2018-04-10)


INSERT INTO HotelRoomPrice (PromotionID, RoomID, Price, FromDate, ToDate)
VALUES (NULL, 1, 80.00, 2017-01-01, NULL),
(NULL, 2, 80.00, 2017-01-01, NULL),
(NULL, 3, 90.00, 2017-01-01, NULL),
(NULL, 4, 90.00, 2017-01-01, NULL),
(NULL, 5, 100.00, 2017-01-01, NULL),
(NULL, 6, 100.00, 2017-01-01, NULL),
(NULL, 7, 110.00, 2017-01-01, NULL),
(NULL, 8, 110.00, 2017-01-01, NULL),
(NULL, 9, 120.00, 2017-01-01, NULL),
(NULL, 10, 120.00, 2017-01-01, NULL),
(NULL, 1, 74.99, 2015-01-01, 2016-12-31),
(NULL, 2, 74.99, 2015-01-01, 2016-12-31),
(NULL, 3, 85.99, 2015-01-01, 2016-12-31),
(NULL, 4, 85.99, 2015-01-01, 2016-12-31),
(NULL, 5, 89.99, 2015-01-01, 2016-12-31),
(NULL, 6, 89.99, 2015-01-01, 2016-12-31),
(NULL, 7, 99.99, 2015-01-01, 2016-12-31),
(NULL, 8, 99.99, 2015-01-01, 2016-12-31),
(NULL, 9, 114.99, 2015-01-01, 2016-12-31),
(NULL, 10, 114.99, 2015-01-01, 2016-12-31),
(3, 1, 75.00, 2017-01-01, NULL),
(3, 2, 75.00, 2017-01-01, NULL),
(3, 3, 85.00, 2017-01-01, NULL),
(3, 4, 85.00, 2017-01-01, NULL),
(3, 5, 90.00, 2017-01-01, NULL),
(3, 6, 90.00, 2017-01-01, NULL),
(3, 7, 100.00, 2017-01-01, NULL),
(3, 8, 100.00, 2017-01-01, NULL),
(3, 9, 110.00, 2017-01-01, NULL),
(3, 10, 110.00, 2017-01-01, NULL)

INSERT INTO Customer (FirstName, LastName, Phone, Email)
VALUES ('Pedro', 'Pascal', '2223334444', NULL),
('Peter', 'Dinklage', '4445556666', 'thehand@targindustries.co.uk'),
('Lena', 'Headey', NULL, 'evilqueen@ironthrone.gov'),
('Maisie', 'Williams', NULL, NULL),
('Emilia', 'Clarke', '9998887777', NULL),
('Kit', 'Harrington', NULL, 'king@thenorth.org'),
('Gwendoline', 'Christie', NULL, NULL),
('Charles', 'Dance', '4445556677', 'thehand@ironthrone.gov')

INSERT INTO CustomerBill (CustomerID, PriceOverride, RoomCharges, RoomServiceCharges, TotalCharge)
VALUES (1, NULL, 200, 52, 252),
(2, NULL, 180, NULL, 180),
(3, -265, 240, 25, 265),
(4, NULL, 370, 15, 395),
(5, NULL, 400, NULL, 400),
(6, NULL, 170, 0, 170),
(3, -330, 280, 50, 330),
(7, NULL, 540, 30, 570),
(8, NULL, 320, 10, 330),
(1, NULL, 360, NULL, 360)

INSERT INTO ReservationTable (CustomerBillID, HotelRoomPriceID, FromDate, ToDate)
VALUES (1, 3, '2017-08-03 16:00:00', '2017-08-07 10:00:00'),
(2, 8, '2017-08-03 16:00:00', '2017-08-07 10:00:00'),
(3, 7, '2017-08-10 16:00:00', '2017-08-12 10:00:00'),
(4, 2, '2017-08-14 16:00:00', '2017-08-16 10:00:00'),
(5, 9, '2017-08-14 16:00:00', '2017-08-16 10:00:00'),
(6, 2, '2017-08-16 16:00:00', '2017-08-20 10:00:00'),
(7, 7, '2017-08-25 16:00:00', '2017-08-28 10:00:00'),
(8, 5, '2017-08-29 16:00:00', '2017-08-31 10:00:00'),
(9, 25,'2017-09-02 16:00:00', '2017-09-05 10:00:00'),
(10, 23, '2017-09-08 16:00:00', '2017-09-12 10:00:00')

INSERT INTO Guest (GuestAge, FirstName, LastName)
VALUES (18, NULL, NULL),
(19, NULL, NULL),
(54, 'Jerome', 'Flynn'),
(47, 'Nickolaj','Coster-Waldau')

INSERT INTO ReservationGuest (ReservationID, GuestID)
VALUES (1,1),
(1,2),
(2,3),
(8,4),
(10,1),
(10,2)


INSERT INTO RoomService (RoomServiceType, RoomServicePrice, FromDate, ToDate)
VALUES ('Bottle of Arbor Gold', 34.95, 2015-01-01, 2016-12-31),
('Lamprey Pie', 11.95, 2015-01-01, 2016-12-31),
('Bottle of Arbor Gold', 42.97, 2017-01-01, NULL),
('Lamprey Pie', 13.60, 2017-01-01, NULL)

INSERT INTO ReservationService (ReservationID, RoomServiceID)
VALUES (2, 3),
(2, 4),
(2, 3),
(2, 4),
(2, 3),
(2, 4),
(2, 3),
(2, 4)