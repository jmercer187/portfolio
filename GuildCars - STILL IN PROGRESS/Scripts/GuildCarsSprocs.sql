USE GuildCars
GO

-- DISPLAYS

-- Display All Vehicles -> then use LINQ to sort results instead of writing discrete SQL searches???
-- Show make / model / body style / interior / sale price / msrp / transmission / mileage / color / VIN / description

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayAllVehicles')
		DROP PROCEDURE DisplayAllVehicles
GO

CREATE PROCEDURE DisplayAllVehicles AS
BEGIN
	SELECT v.VehicleId, v.ModelYear, mk.MakeName, md.ModelName, b.BodyStyleName, c.ColorName, i.InteriorType, t.TransmissionType, v.Mileage, v.VehicleDescription, v.New, v.Sold, v.Featured, v.ImageFilePath, v.VIN, vp.MSRP, vp.SalePrice
	FROM Vehicle v
		INNER JOIN BodyStyle b ON v.BodyStyleId = b.BodyStyleId
		INNER JOIN Color c ON v.ColorId = c.ColorId
		INNER JOIN Interior i on v.InteriorId = i.InteriorId
		INNER JOIN Transmission t on v.TransmissionId = t.TransmissionId
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON md.MakeId = mk.MakeId
		INNER JOIN VehiclePrice vp on vp.VehicleId = v.VehicleId
END
GO

-- Featured Vehicles
-- show image / year / make / model / sale price
-- select where vehicles are featured

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayFeaturedVehicles')
		DROP PROCEDURE DisplayFeaturedVehicles
GO

CREATE PROCEDURE DisplayFeaturedVehicles AS
BEGIN
	SELECT v.ModelYear, v.ImageFilePath, mk.MakeName, md.ModelName, v.VehicleId,
		CASE WHEN vp.SalePrice IS NULL THEN vp.MSRP ELSE vp.SalePrice END AS Price
	FROM Vehicle v
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON md.MakeId = mk.MakeId
		INNER JOIN VehiclePrice vp ON v.VehicleId = vp.VehiclePriceId
	WHERE v.Featured = 1
	ORDER BY Price DESC
END
GO

-- Vehicle Details (for specific vehicle)
-- Show make / model / body style / interior / sale price / msrp / transmission / mileage / color / VIN / description
-- select by input vehicle ID

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayVehicleById')
		DROP PROCEDURE DisplayVehicleById
GO

CREATE PROCEDURE DisplayVehicleById (
	@VehicleId int
)
AS
BEGIN
	SELECT v.VehicleId, v.ModelYear, mk.MakeName, md.ModelName, b.BodyStyleName, c.ColorName, i.InteriorType, t.TransmissionType, v.Mileage, v.VehicleDescription, v.New, v.Sold, v.Featured, v.ImageFilePath, v.VIN, vp.MSRP, vp.SalePrice
	FROM Vehicle v
		INNER JOIN BodyStyle b ON v.BodyStyleId = b.BodyStyleId
		INNER JOIN Color c ON v.ColorId = c.ColorId
		INNER JOIN Interior i on v.InteriorId = i.InteriorId
		INNER JOIN Transmission t on v.TransmissionId = t.TransmissionId
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON md.MakeId = mk.MakeId
		INNER JOIN VehiclePrice vp on vp.VehicleId = v.VehicleId
	WHERE v.VehicleId = @VehicleId
END
GO

-- Shows all NEW vehicles

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayNewVehicles')
		DROP PROCEDURE DisplayNewVehicles
GO

CREATE PROCEDURE DisplayNewVehicles AS
BEGIN
	SELECT v.VehicleId, v.ModelYear, mk.MakeName, md.ModelName, b.BodyStyleName, c.ColorName, i.InteriorType, t.TransmissionType, v.Mileage, v.VehicleDescription, v.New, v.Sold, v.Featured, v.ImageFilePath, v.VIN, vp.MSRP, vp.SalePrice
	FROM Vehicle v
		INNER JOIN BodyStyle b ON v.BodyStyleId = b.BodyStyleId
		INNER JOIN Color c ON v.ColorId = c.ColorId
		INNER JOIN Interior i on v.InteriorId = i.InteriorId
		INNER JOIN Transmission t on v.TransmissionId = t.TransmissionId
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON md.MakeId = mk.MakeId
		INNER JOIN VehiclePrice vp on vp.VehicleId = v.VehicleId
	WHERE v.New = 1 AND v.Sold = 0
END
GO

-- Shows all USED vehicles

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayUsedVehicles')
		DROP PROCEDURE DisplayUsedVehicles
GO

CREATE PROCEDURE DisplayUsedVehicles AS
BEGIN
	SELECT v.VehicleId, v.ModelYear, mk.MakeName, md.ModelName, b.BodyStyleName, c.ColorName, i.InteriorType, t.TransmissionType, v.Mileage, v.VehicleDescription, v.New, v.Sold, v.Featured, v.ImageFilePath, v.VIN, vp.MSRP, vp.SalePrice
	FROM Vehicle v
		INNER JOIN BodyStyle b ON v.BodyStyleId = b.BodyStyleId
		INNER JOIN Color c ON v.ColorId = c.ColorId
		INNER JOIN Interior i on v.InteriorId = i.InteriorId
		INNER JOIN Transmission t on v.TransmissionId = t.TransmissionId
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON md.MakeId = mk.MakeId
		INNER JOIN VehiclePrice vp on vp.VehicleId = v.VehicleId
	WHERE v.New = 0 AND v.Sold = 0
END
GO

-- All Specials in System
-- Show title and description

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplaySpecials')
		DROP PROCEDURE DisplaySpecials
GO

CREATE PROCEDURE DisplaySpecials AS
BEGIN
	SELECT * FROM Specials
END
GO

---- All Users in System
---- Lastname, Firstname, Email, Role

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'DisplayUsers')
--		DROP PROCEDURE DisplayUsers
--GO

--CREATE PROCEDURE DisplayUsers AS
--BEGIN
--	SELECT users.UserName, users.Email, ur.RoleId
--	FROM AspNetUsers users
--		INNER JOIN AspNetUserRoles ur ON users.Id = ur.UserId
--END
--GO

---- All Makes in System
---- show all Make / Date Added (to system) / User (who added make)

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'DisplayMakes')
--		DROP PROCEDURE DisplayMakes
--GO

--CREATE PROCEDURE DisplayMakes AS
--BEGIN
--	SELECT m.MakeId, m.MakeName, users.UserName, m.DateAdded
--	FROM Make m
--		INNER JOIN AspNetUsers users ON m.Id = users.Id
--END

---- All Models in System
---- show all Make / Model / Date Added (to system) / User (who added model)

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'DisplayModels')
--		DROP PROCEDURE DisplayModels
--GO

--CREATE PROCEDURE DisplayModels AS
--BEGIN
--	SELECT mk.MakeName, m.ModelName, users.UserName, m.DateAdded
--	FROM model m
--		INNER JOIN AspNetUsers users ON m.Id = users.Id
--		INNER JOIN Make mk on mk.MakeId = m.MakeId
--END

---- All purchase types (for selection on screen where user inputs a new sale)

--IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'DisplayPurchaseTypes')
--		DROP PROCEDURE DisplayPurchaseTypes
--GO

--CREATE PROCEDURE DisplayPurchaseTypes AS
--BEGIN
--	SELECT * FROM PurchaseMethod
--END

---- All states (for selection on screen where user inputs a new sale)

--IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'DisplayStates')
--		DROP PROCEDURE DisplayStates
--GO

--CREATE PROCEDURE DisplayStates AS
--BEGIN
--	SELECT StateId FROM AddressState
--END

-- INSERTS / EDITS

-- Add Sale in tandem with Add Customer

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'SaleInsert')
--		DROP PROCEDURE SaleInsert
--GO

--CREATE PROCEDURE SaleInsert (
--	@SaleId int output,
--	@CustomerId int output,
--	@CustomerName nvarchar(128),
--	@Phone char(12),
--	@Email nvarchar(128),
--	@Street1 nvarchar(128),
--	@Street2 nvarchar(128),
--	@Zip char(10),
--	@CityId int output,
--	@CityName nvarchar(64),
--	@StateId char(2),
--	@PurchasePrice decimal (13,2),
--	@PurchaseType nvarchar(15),
--	@PurchaseMethodId int output,
--	@UserName nvarchar(256),
--	@VehicleId int,
--	@VehiclePriceId int output

--) AS
--BEGIN
--	IF NOT EXISTS (SELECT TOP 1 1 FROM AddressCity WHERE CityName = @CityName)
--	BEGIN
--		INSERT INTO AddressCity (CityName)
--		VALUES (@CityName)
--		SET @CityId = SCOPE_IDENTITY()
--	END
--	ELSE
--	BEGIN
--		SELECT @CityId = CityId FROM AddressCity WHERE CityName = @CityName
--	END
	
--	INSERT INTO Customer (CityId, StateId, StreetAddress1, StreetAddress2, Zip, CustomerName, Phone, Email)
--	VALUES (@CityId, @StateId, @Street1, @Street2, @Zip, @CustomerName, @Phone, @Email)
--	SET @CustomerId = SCOPE_IDENTITY()

--	SELECT @PurchaseMethodId = PurchaseMethodID 
--	FROM PurchaseMethod 
--	WHERE PurchaseType = @PurchaseType
	
--	SELECT v
--	FROM Vehicle v 
--		INNER JOIN VehiclePrice vp ON v.VehicleId = vp.VehicleId

--	INSERT INTO Sale(CustomerId, VehiclePriceId, UserId, PriceOverride, PurchaseMethodId, PurchaseDate)
--	VALUES ()
	
	

-- Add Vehicle (admin only)

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleInsert')
	DROP PROCEDURE VehicleInsert
GO

CREATE PROCEDURE VehicleInsert (
	@VehicleId int output,
	@BodyStyleName nvarchar(64),
	@ColorName nvarchar(64),
	@Featured bit,
	@ImageFilepath nvarchar(64),
	@InteriorType nvarchar(64),
	-- @MakeName nvarchar(64), don't actually need this?
	@Mileage varchar(7),
	@ModelName nvarchar(64),
	@ModelYear char(4),
	@New bit,
	@Sold bit,
	@TransmissionType nvarchar(24),
	@VehicleDescription nvarchar(512),
	@VIN varchar(24),
	@MSRP decimal(13,2),
	@SalePrice decimal(13,2)

) AS
BEGIN
	DECLARE
	@BodyStyleId int,
	@ColorId int,
	@InteriorId int,
	@ModelId int,
	@TransmissionId int
	
	BEGIN
		SELECT @BodyStyleId = BodyStyleId FROM BodyStyle WHERE BodyStyleName = @BodyStyleName
	END
	BEGIN
		SELECT @ColorId = ColorId FROM Color WHERE ColorName = @ColorName
	END
	BEGIN
		SELECT @InteriorId = InteriorId FROM Interior WHERE InteriorType = @InteriorType
	END
	BEGIN
		SELECT @ModelId = ModelId FROM Model WHERE ModelName = @ModelName
	END
	BEGIN
		SELECT @TransmissionId = TransmissionId FROM Transmission WHERE TransmissionType = @TransmissionType
	END

	INSERT INTO Vehicle (ModelId, BodyStyleId, TransmissionId, ColorId, InteriorId, ModelYear, Mileage, VIN, New, Featured, Sold, ImageFilePath, VehicleDescription)
	VALUES (@ModelId, @BodyStyleId, @TransmissionId, @ColorId, @InteriorId, @ModelYear, @Mileage,@VIN, @New, @Featured, @Sold, @ImageFilepath, @VehicleDescription)

	SET @VehicleId = SCOPE_IDENTITY();

	INSERT INTO VehiclePrice (VehicleId, MSRP, SalePrice)
	VALUES (@VehicleId, @MSRP, @SalePrice)

END

GO

-- Edit Vehicle (admin only)

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleUpdate')
	DROP PROCEDURE VehicleUpdate
GO

CREATE PROCEDURE VehicleUpdate (
	@VehicleId int,
	@BodyStyleName nvarchar(64),
	@ColorName nvarchar(64),
	@Featured bit,
	@ImageFilepath nvarchar(64),
	@InteriorType nvarchar(64),
	-- @MakeName nvarchar(64), don't actually need this?
	@Mileage varchar(7),
	@ModelName nvarchar(64),
	@ModelYear char(4),
	@New bit,
	@Sold bit,
	@TransmissionType nvarchar(24),
	@VehicleDescription nvarchar(512),
	@VIN varchar(24),
	@MSRP decimal(13,2),
	@SalePrice decimal(13,2)

) AS
BEGIN
	DECLARE
	@BodyStyleId int,
	@ColorId int,
	@InteriorId int,
	@ModelId int,
	@TransmissionId int
	
	BEGIN
		SELECT @BodyStyleId = BodyStyleId FROM BodyStyle WHERE BodyStyleName = @BodyStyleName
	END
	BEGIN
		SELECT @ColorId = ColorId FROM Color WHERE ColorName = @ColorName
	END
	BEGIN
		SELECT @InteriorId = InteriorId FROM Interior WHERE InteriorType = @InteriorType
	END
	BEGIN
		SELECT @ModelId = ModelId FROM Model WHERE ModelName = @ModelName
	END
	BEGIN
		SELECT @TransmissionId = TransmissionId FROM Transmission WHERE TransmissionType = @TransmissionType
	END

	UPDATE Vehicle SET
	ModelId = @ModelId,
	BodyStyleId = @BodyStyleId,
	TransmissionId = @TransmissionId,
	ColorId = @ColorId,
	InteriorId = @InteriorId,
	ModelYear = @ModelYear, 
	Mileage = @Mileage, 
	VIN = @VIN,
	New = @New,
	Featured = @Featured, 
	Sold = @Sold, 
	ImageFilePath = @ImageFilepath, 
	VehicleDescription = @VehicleDescription
	
	-- create if statement - if both MSRP and SalePrice are the same, then keep
	-- if either is different, create new VehiclePrice, set previous VehiclePrice ToDate to end at new VP's FromDate
	
	INSERT VehiclePrice SET
	VehicleId, 
	MSRP, 
	SalePrice
	VALUES (@VehicleId, @MSRP, @SalePrice)

END

GO

-- Add/Edit User
-- Firstname / Lastname / email / Role / password / confirm password

-- Add Model (Admin Only) -> incorporates dropdown list of Makes



-- Add Make (Admin Only)

-- Insert New Special (Admin only)


-- DELETES

-- Delete existing vehicle



-- Delete existing Special (Admin only)


-- SEARCHES

-- Search New Vehicles - returns top 20 sorted by MSRP
-- can search New Vehicles by @make or @model (put in dropdown) / parameters -> price min or price max or year min / year max

-- Search Used Vehicles
-- can search Used Vehicles by @make or @model (put in dropdown) / parameters -> price min or price max or year min / year max

-- Inventory Report: Show New Vehicles
-- Show Year, Make, Model, Count of, Total Sotck Value for all New Vehicles

-- Inventory Report: Show Used Vehicles
-- Show Year, Make, Model, Count of, Total Sotck Value for all Used Vehicles

-- Sales Report: All Sales for Time Period
-- Show All Users, Sum their respective Total Sales, Sum their respective Total Vehicles Sold, for time period @FromDate to @ToDate (either can be null)

-- Sales Report: Specific User (selected from drop-down) for Time Period
-- Show @User, Sum their respective Total Sales, Sum their respective Total Vehicles Sold, for time period @FromDate to @ToDate (either can be null)




