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

-- Display all Unsold Vehicles

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayUnsoldVehicles')
		DROP PROCEDURE DisplayUnsoldVehicles
GO

CREATE PROCEDURE DisplayUnsoldVehicles AS
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
	WHERE v.Sold = 0
END
GO

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

-- Display All Makes

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayMakes')
		DROP PROCEDURE DisplayMakes
GO

CREATE PROCEDURE DisplayMakes AS
BEGIN
	SELECT m.MakeId, m.MakeName, users.UserName, m.DateAdded
	FROM Make m
		INNER JOIN AspNetUsers users ON m.Id = users.Id
END
GO

-- get make by ID (pretty much just for testing?)
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetMakeById')
		DROP PROCEDURE GetMakeById
GO

CREATE PROCEDURE GetMakeById (
	@MakeId int
	) AS
BEGIN
	SELECT MakeName, Id, DateAdded
	FROM Make
	WHERE MakeId = @MakeId
END
GO

-- Add make

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InsertMake')
      DROP PROCEDURE InsertMake
GO

CREATE PROCEDURE InsertMake (
	@MakeId int output,
	@MakeName nvarchar(64),
	@Id nvarchar(128)
) AS
BEGIN
	
	INSERT INTO Make(MakeName, Id)
	VALUES  (@MakeName, @Id)

	SET
	@MakeId = SCOPE_IDENTITY();
END
GO

--update make

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateMake')
      DROP PROCEDURE UpdateMake
	  GO

CREATE PROCEDURE UpdateMake (
	@MakeId int,
	@MakeName nvarchar(64),
	@Id nvarchar(128)
) AS
BEGIN
	UPDATE Make SET
	MakeName = @MakeName,
	Id = @Id
	WHERE MakeId = @MakeId
END
GO

---- All Models in System
---- show all Make / Model / Date Added (to system) / User (who added model)

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayModels')
		DROP PROCEDURE DisplayModels
GO

CREATE PROCEDURE DisplayModels AS
BEGIN
	SELECT mk.MakeName, m.ModelName, users.UserName, m.DateAdded, m.ModelId
	FROM model m
		INNER JOIN AspNetUsers users ON m.Id = users.Id
		INNER JOIN Make mk on mk.MakeId = m.MakeId
END
GO

-- get model by ID (pretty much just for testing?)
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetModelById')
		DROP PROCEDURE GetModelById
GO

CREATE PROCEDURE GetModelById (
	@ModelId int
	) AS
BEGIN
	SELECT ModelName, Id, DateAdded
	FROM Model
	WHERE ModelId = @ModelId
END
GO

-- Add model

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InsertModel')
      DROP PROCEDURE InsertModel
GO

CREATE PROCEDURE InsertModel (
	@ModelId int output,
	@ModelName nvarchar(64),
	@Id nvarchar(128)
) AS
BEGIN
	
	INSERT INTO Model(ModelName, Id)
	VALUES  (@ModelName, @Id)

	SET
	@ModelId = SCOPE_IDENTITY();
END
GO

--update model

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateModel')
      DROP PROCEDURE UpdateModel
	  GO

CREATE PROCEDURE UpdateModel (
	@ModelId int,
	@ModelName nvarchar(64),
	@Id nvarchar(128)
) AS
BEGIN
	UPDATE Model SET
	ModelName = @ModelName,
	Id = @Id
	WHERE ModelId = @ModelId
END
GO

-- Display All Colors

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayColors')
		DROP PROCEDURE DisplayColors
GO

CREATE PROCEDURE DisplayColors AS
BEGIN
	SELECT ColorId, ColorName
	FROM Color
END
GO

-- get color by ID (pretty much just for testing?)
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetColorById')
		DROP PROCEDURE GetColorById
GO

CREATE PROCEDURE GetColorById (
	@ColorId int
	) AS
BEGIN
	SELECT ColorName
	FROM Color
	WHERE ColorId = @ColorId
END
GO

-- Add color

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InsertColor')
      DROP PROCEDURE InsertColor
GO

CREATE PROCEDURE InsertColor (
	@ColorId int output,
	@ColorName nvarchar(64)
) AS
BEGIN
	
	INSERT INTO Color(ColorName)
	VALUES  (@ColorName)

	SET
	@ColorId = SCOPE_IDENTITY();
END
GO

--update color

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateColor')
      DROP PROCEDURE UpdateColor
	  GO

CREATE PROCEDURE UpdateColor (
	@ColorId int,
	@ColorName nvarchar(64)
) AS
BEGIN
	UPDATE Color SET
	ColorName = @ColorName
	WHERE ColorId = @ColorId
END
GO


-- Display All BodyStyles

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayBodyStyles')
		DROP PROCEDURE DisplayBodyStyles
GO

CREATE PROCEDURE DisplayBodyStyles AS
BEGIN
	SELECT BodyStyleId, BodyStyleName
	FROM BodyStyle
END
GO

-- get bodystyle by ID (pretty much just for testing?)
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetBodyStyleById')
		DROP PROCEDURE GetBodyStyleById
GO

CREATE PROCEDURE GetBodyStyleById (
	@BodyStyleId int
	) AS
BEGIN
	SELECT BodyStyleName
	FROM BodyStyle
	WHERE BodyStyleId = @BodyStyleId
END
GO

-- Add bodystyle

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InsertBodyStyle')
      DROP PROCEDURE InsertBodyStyle
GO

CREATE PROCEDURE InsertBodyStyle (
	@BodyStyleId int output,
	@BodyStyleName nvarchar(64)
) AS
BEGIN
	
	INSERT INTO BodyStyle(BodyStyleName)
	VALUES  (@BodyStyleName)

	SET
	@BodyStyleId = SCOPE_IDENTITY();
END
GO

--update bodystyle

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateBodyStyle')
      DROP PROCEDURE UpdateBodyStyle
	  GO

CREATE PROCEDURE UpdateBodyStyle (
	@BodyStyleId int,
	@BodyStyleName nvarchar(64)
) AS
BEGIN
	UPDATE BodyStyle SET
	BodyStyleName = @BodyStyleName
	WHERE BodyStyleId = @BodyStyleId
END
GO

-- Display All Interior Types

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayInteriors')
		DROP PROCEDURE DisplayInteriors
GO

CREATE PROCEDURE DisplayInteriors AS
BEGIN
	SELECT InteriorId, InteriorType
	FROM Interior
END
GO

-- get interior type by ID (pretty much just for testing?)
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetInteriorById')
		DROP PROCEDURE GetInteriorById
GO

CREATE PROCEDURE GetInteriorById (
	@InteriorId int
	) AS
BEGIN
	SELECT InteriorType
	FROM Interior
	WHERE InteriorId = @InteriorId
END
GO

-- Add interior type

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InsertInterior')
      DROP PROCEDURE InsertInterior
GO

CREATE PROCEDURE InsertInterior (
	@InteriorId int output,
	@InteriorType nvarchar(64)
) AS
BEGIN
	
	INSERT INTO Interior(InteriorType)
	VALUES  (@InteriorType)

	SET
	@InteriorId = SCOPE_IDENTITY();
END
GO

--update interior type

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateInterior')
      DROP PROCEDURE UpdateInterior
	  GO

CREATE PROCEDURE UpdateInterior (
	@InteriorId int,
	@InteriorType nvarchar(64)
) AS
BEGIN
	UPDATE Interior SET
	InteriorType = @InteriorType
	WHERE InteriorId = @InteriorId
END
GO

-- Display All Transmission Types

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayTransmissions')
		DROP PROCEDURE DisplayTransmissions
GO

CREATE PROCEDURE DisplayTransmissions AS
BEGIN
	SELECT TransmissionId, TransmissionType
	FROM Transmission
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

-- get special by ID (pretty much just for testing?)
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetSpecialById')
		DROP PROCEDURE GetSpecialById
GO

CREATE PROCEDURE GetSpecialById (
	@SpecialId int
	) AS
BEGIN
	SELECT SpecialTitle, SpecialDescription
	FROM Specials
	WHERE SpecialId = @SpecialId
END
GO

-- Add Special

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InsertSpecial')
      DROP PROCEDURE InsertSpecial
GO

CREATE PROCEDURE InsertSpecial (
	@SpecialId int output,
	@SpecialTitle nvarchar(64),
	@SpecialDescription  nvarchar(512)
) AS
BEGIN
	
	INSERT INTO Specials( SpecialTitle, SpecialDescription)
	VALUES  (@SpecialTitle, @SpecialDescription)

	SET
	@SpecialId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateSpecial')
      DROP PROCEDURE UpdateSpecial
GO

CREATE PROCEDURE UpdateSpecial (
	@SpecialId int,
	@SpecialTitle nvarchar(64),
	@SpecialDescription  nvarchar(512)
) AS
BEGIN
	UPDATE Specials SET
	SpecialTitle = @SpecialTitle,
	SpecialDescription = @SpecialDescription
	WHERE SpecialId = @SpecialId
END
GO

-- Delete Special

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteSpecial')
      DROP PROCEDURE DeleteSpecial
GO

CREATE PROCEDURE DeleteSpecial (
	@SpecialId int
) AS
BEGIN
	DELETE FROM Specials
	WHERE SpecialId = @SpecialId
END
GO

-- Get All States

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayStates')
		DROP PROCEDURE DisplayStates
GO

CREATE PROCEDURE DisplayStates AS
BEGIN
	SELECT StateName, StateId
	FROM AddressState
END
GO

-- All purchase types (for selection on screen where user inputs a new sale)

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DisplayPurchaseTypes')
		DROP PROCEDURE DisplayPurchaseTypes
GO

CREATE PROCEDURE DisplayPurchaseTypes AS
BEGIN
	SELECT PurchaseMethodId, PurchaseType
	FROM PurchaseMethod
END


-- Add Sale in tandem with Add Customer

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'SaleInsert')
--		DROP PROCEDURE SaleInsert
--GO

--CREATE PROCEDURE SaleInsert (
--	@CustomerName nvarchar(128),
--	@Phone char(12),
--	@Email nvarchar(128),
--	@Street1 nvarchar(128),
--	@Street2 nvarchar(128),
--	@Zip char(10),
--	@CityName nvarchar(64),
--	@StateId char(2),
--	@PurchasePrice decimal (13,2),
--	@PurchaseType nvarchar(15),
--	@UserName nvarchar(256),
--	@VehicleId int,
--	@VehiclePriceId int output

--) AS
--BEGIN
--	DECLARE
--	@CityId int,
--	@CustomerId int,
--	@PurchaseMethodId int

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
	
--	SELECT vp.VehiclePriceId
--	FROM VehiclePrice vp
--		INNER JOIN Vehicle v ON v.VehicleId = vp.VehicleId
--	SET @VehiclePriceId = vp.VehiclePriceId
		
--	BEGIN
--		UPDATE Vehicle SET
--			Sold = 1
--		WHERE VehicleID = @VehicleId
--	END

--	INSERT INTO Sale(CustomerId, VehiclePriceId, UserId, PriceOverride, PurchaseMethodId, PurchaseDate)
--	VALUES (@CustomerId, )




-- All Users in System
-- Lastname, Firstname, Email, Role

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






-- INSERTS / EDITS


	
	



-- Edit Vehicle (admin only)

--IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'VehicleUpdate')
--	DROP PROCEDURE VehicleUpdate
--GO

--CREATE PROCEDURE VehicleUpdate (
--	@VehicleId int,
--	@BodyStyleName nvarchar(64),
--	@ColorName nvarchar(64),
--	@Featured bit,
--	@ImageFilepath nvarchar(64),
--	@InteriorType nvarchar(64),
--	-- @MakeName nvarchar(64), don't actually need this?
--	@Mileage varchar(7),
--	@ModelName nvarchar(64),
--	@ModelYear char(4),
--	@New bit,
--	@Sold bit,
--	@TransmissionType nvarchar(24),
--	@VehicleDescription nvarchar(512),
--	@VIN varchar(24),
--	@MSRP decimal(13,2),
--	@SalePrice decimal(13,2)

--) AS
--BEGIN
--	DECLARE
--	@BodyStyleId int,
--	@ColorId int,
--	@InteriorId int,
--	@ModelId int,
--	@TransmissionId int
	
--	BEGIN
--		SELECT @BodyStyleId = BodyStyleId FROM BodyStyle WHERE BodyStyleName = @BodyStyleName
--	END
--	BEGIN
--		SELECT @ColorId = ColorId FROM Color WHERE ColorName = @ColorName
--	END
--	BEGIN
--		SELECT @InteriorId = InteriorId FROM Interior WHERE InteriorType = @InteriorType
--	END
--	BEGIN
--		SELECT @ModelId = ModelId FROM Model WHERE ModelName = @ModelName
--	END
--	BEGIN
--		SELECT @TransmissionId = TransmissionId FROM Transmission WHERE TransmissionType = @TransmissionType
--	END

--	UPDATE Vehicle SET
--	ModelId = @ModelId,
--	BodyStyleId = @BodyStyleId,
--	TransmissionId = @TransmissionId,
--	ColorId = @ColorId,
--	InteriorId = @InteriorId,
--	ModelYear = @ModelYear, 
--	Mileage = @Mileage, 
--	VIN = @VIN,
--	New = @New,
--	Featured = @Featured, 
--	Sold = @Sold, 
--	ImageFilePath = @ImageFilepath, 
--	VehicleDescription = @VehicleDescription
	
	-- create if statement - if both MSRP and SalePrice are the same, then keep
	-- if either is different, create new VehiclePrice, set previous VehiclePrice ToDate to end at new VP's FromDate
	
--	INSERT VehiclePrice SET
--	VehicleId, 
--	MSRP, 
--	SalePrice
--	VALUES (@VehicleId, @MSRP, @SalePrice)

--END

--GO

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




