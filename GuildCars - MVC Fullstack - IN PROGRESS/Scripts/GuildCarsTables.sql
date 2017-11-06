USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Sale')
	DROP TABLE Sale
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseMethod')
	DROP TABLE PurchaseMethod
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Customer')
	DROP TABLE Customer
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='AddressCity')
	DROP TABLE AddressCity
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='AddressState')
	DROP TABLE AddressState
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='VehiclePrice')
	DROP TABLE VehiclePrice
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
	DROP TABLE Vehicle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
	DROP TABLE Model
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
	DROP TABLE BodyStyle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
	DROP TABLE Transmission
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Color')
	DROP TABLE Color
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Interior')
	DROP TABLE Interior
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO

CREATE TABLE Make (
	MakeId int IDENTITY(1,1) not null PRIMARY KEY,
	MakeName nvarchar(64) not null,
	Id nvarchar(128) not null FOREIGN KEY REFERENCES AspNetUsers(Id),
	DateAdded DateTime2 not null DEFAULT(getdate())
)

CREATE TABLE Model (
	ModelId int IDENTITY(1,1) not null PRIMARY KEY,
	MakeId int not null FOREIGN KEY REFERENCES Make(MakeId),
	ModelName nvarchar(64) not null,
	Id nvarchar(128) not null FOREIGN KEY REFERENCES AspNetUsers(Id),
	DateAdded DateTime2 not null DEFAULT(getdate())
)

CREATE TABLE BodyStyle (
	BodyStyleId int IDENTITY(1,1) not null PRIMARY KEY,
	BodyStyleName nvarchar(64) not null
)

CREATE TABLE Transmission (
	TransmissionId int IDENTITY(1,1) not null PRIMARY KEY,
	TransmissionType nvarchar(24) not null
)

CREATE TABLE Color (
	ColorId int IDENTITY(1,1) not null PRIMARY KEY,
	ColorName nvarchar(64) not null
)

CREATE TABLE Interior (
	InteriorId int IDENTITY(1,1) not null PRIMARY KEY,
	InteriorType nvarchar(64) not null
)

CREATE TABLE Vehicle (
	VehicleId int IDENTITY(1,1) not null PRIMARY KEY,
	ModelId int not null FOREIGN KEY REFERENCES Model(ModelId),
	BodyStyleId int not null FOREIGN KEY REFERENCES BodyStyle(BodyStyleId),
	TransmissionId int not null FOREIGN KEY REFERENCES Transmission(TransmissionId),
	ColorId int not null FOREIGN KEY REFERENCES Color(ColorId),
	InteriorId int not null FOREIGN KEY REFERENCES Interior(InteriorId),
	ModelYear varchar (6) not null,
	Mileage varchar (7) not null,
	VIN varchar (24) not null,
	New bit not null,
	Featured bit not null,
	Sold bit not null,
	ImageFilePath nvarchar (64)not null,
	VehicleDescription nvarchar (512) not null,
)

CREATE TABLE VehiclePrice (
	VehiclePriceId int IDENTITY(1,1) not null PRIMARY KEY,
	VehicleId int not null FOREIGN KEY REFERENCES Vehicle(VehicleId),
	MSRP decimal (13,2) not null,
	SalePrice decimal (13,2) null,
	FromDate DateTime2 not null DEFAULT(getdate()),
	ToDate DateTime2 null,
)

CREATE TABLE AddressCity (
	CityId int IDENTITY(1,1) not null PRIMARY KEY,
	CityName nvarchar (64) not null
)

CREATE TABLE AddressState (
	StateId char(2) not null PRIMARY KEY,
	StateName varchar(15) not null
)

CREATE TABLE Customer (
	CustomerId int IDENTITY(1,1) not null PRIMARY KEY,
	CityId int not null FOREIGN KEY REFERENCES AddressCity(CityId),
	StateId char(2) not null FOREIGN KEY REFERENCES AddressState(StateId),
	StreetAddress1 nvarchar(128) not null,
	StreetAddress2 nvarchar(128) null,
	Zip char(10) not null,
	CustomerName nvarchar(128) not null,
	Phone char(12) null,
	Email nvarchar(128) null
)

CREATE TABLE PurchaseMethod (
	PurchaseMethodId int IDENTITY (1,1) not null PRIMARY KEY,
	PurchaseType nvarchar(15) not null
)

CREATE TABLE Sale(
	SaleId int IDENTITY(1,1) not null PRIMARY KEY,
	CustomerId int not null FOREIGN KEY REFERENCES Customer(CustomerId),
	VehiclePriceId int not null FOREIGN KEY REFERENCES VehiclePrice(VehiclePriceId),
	UserId nvarchar(128) not null FOREIGN KEY REFERENCES AspNetUsers(Id),
	PriceOverride decimal (13,2) null,
	PurchasePrice decimal (13,2) not null,
	PurchaseMethodId int not null FOREIGN KEY REFERENCES PurchaseMethod(PurchaseMethodId),
	PurchaseDate DateTime2 not null DEFAULT(getdate())
)

CREATE TABLE Specials(
	SpecialId int IDENTITY(1,1) not null PRIMARY KEY,
	SpecialTitle nvarchar(64) not null,
	SpecialDescription nvarchar(512) not null
)


