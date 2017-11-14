USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GuildCarsDbReset')
		DROP PROCEDURE GuildCarsDbReset
GO

CREATE PROCEDURE GuildCarsDbReset AS
BEGIN
	
	DELETE FROM Sale;
	DELETE FROM PurchaseMethod;
	DELETE FROM Customer;
	DELETE FROM AddressCity;
	DELETE FROM AddressState;
	DELETE FROM VehiclePrice;
	DELETE FROM Vehicle;
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM BodyStyle;
	DELETE FROM Transmission;
	DELETE FROM Color;
	DELETE FROM Interior;
	DELETE FROM Specials;
	DELETE FROM AspNetUsers WHERE id = '00000000-0000-0000-0000-000000000000';

	DBCC CHECKIDENT (Sale, RESEED, 1)
	DBCC CHECKIDENT (PurchaseMethod, RESEED, 1)
	DBCC CHECKIDENT (Customer, RESEED, 1)
	DBCC CHECKIDENT (AddressCity, RESEED, 1)
	DBCC CHECKIDENT (VehiclePrice, RESEED, 1)
	DBCC CHECKIDENT (Vehicle, RESEED, 1)
	DBCC CHECKIDENT (Model, RESEED, 1)
	DBCC CHECKIDENT (Make, RESEED, 1)
	DBCC CHECKIDENT (BodyStyle, RESEED, 1)
	DBCC CHECKIDENT (Transmission, RESEED, 1)
	DBCC CHECKIDENT (Color, RESEED, 1)
	DBCC CHECKIDENT (Interior, RESEED, 1)
	DBCC CHECKIDENT (Specials, RESEED, 0)

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	VALUES ('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test');
	
	SET IDENTITY_INSERT Interior ON;
	INSERT INTO Interior (InteriorId, InteriorType)
	VALUES (1, 'Beige / Leather'),
	(2, 'Black / Grey Cloth'),
	(3, 'Grey / White Racer')
	SET IDENTITY_INSERT Interior OFF;

	SET IDENTITY_INSERT Color ON;
	INSERT INTO Color (ColorId, ColorName)
	VALUES (1, 'Black'),
	(2, 'Red'),
	(3, 'Sand'),
	(4, 'Silver')
	SET IDENTITY_INSERT Color OFF;

	SET IDENTITY_INSERT Transmission ON;
	INSERT INTO Transmission (TransmissionId, TransmissionType)
	VALUES (1, 'Automatic'),
	(2, 'Manual')
	SET IDENTITY_INSERT Transmission OFF;

	SET IDENTITY_INSERT BodyStyle ON;
	INSERT INTO BodyStyle (BodyStyleId, BodyStyleName)
	VALUES (1, 'Coupe'),
	(2, 'Hatchback'),
	(3, 'Sedan'),
	(4, 'SUV'),
	(5, 'Truck')
	SET IDENTITY_INSERT BodyStyle OFF

	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make (MakeId, MakeName, Id)
	VALUES (1, 'Chevrolet', '00000000-0000-0000-0000-000000000000'),
	(2, 'Ford', '00000000-0000-0000-0000-000000000000'),
	(3, 'Volvo', '00000000-0000-0000-0000-000000000000')
	SET IDENTITY_INSERT Make OFF;

	SET IDENTITY_INSERT Model ON;
	INSERT INTO Model (ModelId, MakeId, ModelName, Id)
	VALUES (1, 1, 'Cruze', '00000000-0000-0000-0000-000000000000'),
	(2, 2, 'F-150', '00000000-0000-0000-0000-000000000000'),
	(3, 3, 'C-30', '00000000-0000-0000-0000-000000000000')
	SET IDENTITY_INSERT Model OFF;

	SET IDENTITY_INSERT Vehicle ON;
	INSERT INTO Vehicle (VehicleId, ModelId, BodyStyleId, TransmissionId, ColorId, InteriorId, ModelYear, Mileage, VIN, New, Featured, Sold, ImageFilePath, VehicleDescription)
	VALUES(1, 1, 3, 1, 3, 1, 2011, '34588', 'a1b2c3d4e5f6g7h8i9j10', 0, 0, 1, 'inventory-1.png', 'A reliable 4-door sedan with a comfortable interior.'),
	(2, 2, 5, 1, 1, 2, 2017, '853', 'a1b2c3d4e5f6g7h8i9j10', 1, 1, 0, 'inventory-2.png', 'The best selling truck in all of these here united states.'),
	(3, 3, 2, 2, 4, 3, 2012, '45781', 'a1b2c3d4e5f6g7h8i9j10', 0, 1, 0, 'inventory-3.jpg', 'The definition of a hot hatch.')
	SET IDENTITY_INSERT Vehicle OFF;
	
	SET IDENTITY_INSERT AddressCity ON;
	INSERT INTO AddressCity (CityId, CityName)
	VALUES (1, 'Akron')
	SET IDENTITY_INSERT AddressCity OFF;
	
	INSERT INTO AddressState (StateName, StateId)
	VALUES ('ALABAMA', 'AL'),
('ALASKA', 'AK'),
('ARIZONA',	'AZ'),
('ARKANSAS', 'AR'),
('CALIFORNIA', 'CA'),
('COLORADO', 'CO'),
('CONNECTICUT', 'CT'),
('DELAWARE', 'DE'),
('FLORIDA',	'FL'),
('GEORGIA',	'GA'),
('HAWAII', 'HI'),
('IDAHO', 'ID'),
('ILLINOIS', 'IL'),
('INDIANA',	'IN'),
('IOWA', 'IA'),
('KANSAS', 'KS'),
('KENTUCKY', 'KY'),
('LOUISIANA', 'LA'),
('MAINE', 'ME'),
('MARYLAND', 'MD'),
('MASSACHUSETTS', 'MA'),
('MICHIGAN', 'MI'),
('MINNESOTA', 'MN'),
('MISSISSIPPI',	'MS'),
('MISSOURI', 'MO'),
('MONTANA',	'MT'),
('NEBRASKA', 'NE'),
('NEVADA', 'NV'),
('NEW HAMPSHIRE', 'NH'),
('NEW JERSEY', 'NJ'),
('NEW MEXICO', 'NM'),
('NEW YORK', 'NY'),
('NORTH CAROLINA', 'NC'),
('NORTH DAKOTA', 'ND'),
('OHIO', 'OH'),
('OKLAHOMA', 'OK'),
('OREGON', 'OR'),
('PENNSYLVANIA', 'PA'),
('RHODE ISLAND', 'RI'),
('SOUTH CAROLINA', 'SC'),
('SOUTH DAKOTA', 'SD'),
('TENNESSEE', 'TN'),
('TEXAS', 'TX'),
('UTAH', 'UT'),
('VERMONT',	'VT'),
('VIRGINIA', 'VA'),
('WASHINGTON', 'WA'),
('WEST VIRGINIA', 'WV'),
('WISCONSIN', 'WI'),
('WYOMING', 'WY')

	SET IDENTITY_INSERT Customer ON;
	INSERT INTO Customer (CustomerId, CityId, StateId, StreetAddress1, StreetAddress2, Zip, CustomerName)
	VALUES (1, 1, 'OH', '214 N Portage Path', 'Apt 205', '44303', 'Jake Mercer')
	SET IDENTITY_INSERT Customer OFF;
	
	SET IDENTITY_INSERT PurchaseMethod ON;
	INSERT INTO PurchaseMethod (PurchaseMethodId, PurchaseType)
	VALUES (1, 'Cash'),
	(2, 'Bank Finance'),
	(3, 'Dealer Finance')
	SET IDENTITY_INSERT PurchaseMethod OFF;

	SET IDENTITY_INSERT VehiclePrice ON;
	INSERT INTO VehiclePrice(VehiclePriceId, VehicleId, MSRP, SalePrice, FromDate, ToDate)
	VALUES(1, 1, 11000, 10995, '07/12/2016', NULL),
	(2, 2, 18000, 17000, '2017-01-01 00:00:00', NULL),
	(3, 3, 14000, 13500, '2017-02-24 00:00:00', NULL)
	SET IDENTITY_INSERT VehiclePrice OFF;

	INSERT INTO Sale (CustomerId, VehiclePriceId, UserId, PriceOverride, PurchasePrice, PurchaseMethodId)
	VALUES (1, 1, '00000000-0000-0000-0000-000000000000', '0', 11000.00, 2)

	
	INSERT INTO Specials (SpecialTitle, SpecialDescription)
	VALUES ('BIG OL SPECIAL 1', 'DOOT DOOTY DOOT DOOT THIS IS THE DOOM SONG DOOM DOOM DOOMIDY DOOM DOOM DOOM. buy a car plz.'),
	('THE ONE ABOUT AMERICA', 'our greatest president, savoryhams lincols, once said that we must not be enemies but customers. let us all remember to buy a car this gettysburg memorial holiday.')

END