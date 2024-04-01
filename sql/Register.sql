USE [Ecomerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ecomerce_Register]
	([Id] [INT] IDENTITY(1,1) NOT NULL,
	[FullName] [VARCHAR](50) NULL,
	[Gender] [VARCHAR](20) NULL,
	[DateOfBirth] [VARCHAR](10) NULL,
	[RegistrationOfIndividuals] [VARCHAR](11) NULL,
	[Telephone] [VARCHAR](11) NULL,
	[ZipCode] [VARCHAR](8) NULL,
	[Address] [VARCHAR](50) NULL,
	[Number] [VARCHAR](10) NULL,
	[Neighborhood] [VARCHAR](30) NULL,
	[City] [VARCHAR](40) NULL,
	[State] [VARCHAR](2) NULL,
	[Email] [VARCHAR](50) NULL,
	[Password] [VARCHAR](20) NULL,
	[ConfirmedEmail] [BIT] NULL,
	[Status] [BIT] NULL,
	[DateInsert] [DATETIME] NULL,
	[DateUpdate] [DATETIME] NULL,
	CONSTRAINT [PK_Ecomerce_Register] PRIMARY KEY CLUSTERED
	([Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	GO
	
USE [Ecomerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_Ecomerce_Register_Delete]
		(@Id INT)
AS
BEGIN
	DELETE FROM [dbo].[Ecomerce_Register]
		WHERE
			Id = @Id;
	SET NOCOUNT ON;
END
GO
	
USE [Ecomerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[USP_Ecomerce_Register_GetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
		FROM Ecomerce_Register
			ORDER BY
				Id ASC
	END
GO
	
USE [Ecomerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_Ecomerce_Register_GetById]
		(@Id INT)
AS
BEGIN
	SELECT TOP 1 * FROM [dbo].[Ecomerce_Register]
		WHERE
			Id = @Id;
	SET NOCOUNT ON;
END
GO
	
USE [Ecomerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_Ecomerce_Register_Post]
	(@Id INT,
	@FullName VARCHAR(50),
	@Gender VARCHAR(20),
	@DateOfBirth VARCHAR(10),
	@RegistrationOfIndividuals VARCHAR(11),
	@Telephone VARCHAR(11),
	@ZipCode VARCHAR(8),
	@Address VARCHAR(50),
	@Number VARCHAR(10),
	@Neighborhood VARCHAR(30),
	@City VARCHAR(40),
	@State VARCHAR(2),
	@Email VARCHAR(50),
	@Password VARCHAR(20),
	@ConfirmedEmail BIT,
	@Status BIT,
	@DateInsert DATETIME,
	@DateUpdate DATETIME)
	
AS
BEGIN
	INSERT INTO [dbo].[Ecomerce_Register]
	(Id,
	FullName,
	Gender,
	DateOfBirth,
	RegistrationOfIndividuals,
	Telephone,
	ZipCode,
	Address,
	Number,
	Neighborhood,
	City,
	State,
	Email,
	Password,
	ConfirmedEmail,
	Status,
	DateInsert,
	DateUpdate)
	
VALUES
	(@Id,
	@FullName,
	@Gender,
	@DateOfBirth,
	@RegistrationOfIndividuals,
	@Telephone,
	@ZipCode,
	@Address,
	@Number,
	@Neighborhood,
	@City,
	@State,
	@Email,
	@Password,
	@ConfirmedEmail,
	@Status,
	@DateInsert,
	@DateUpdate)
	
	SET NOCOUNT ON;
END
GO
	
USE [Ecomerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_Ecomerce_Register_Put]
	(@Id INT,
	@FullName VARCHAR(50),
	@Gender VARCHAR(20),
	@DateOfBirth VARCHAR(10),
	@RegistrationOfIndividuals VARCHAR(11),
	@Telephone VARCHAR(11),
	@ZipCode VARCHAR(8),
	@Address VARCHAR(50),
	@Number VARCHAR(10),
	@Neighborhood VARCHAR(30),
	@City VARCHAR(40),
	@State VARCHAR(2),
	@Email VARCHAR(50),
	@Password VARCHAR(20),
	@ConfirmedEmail BIT,
	@Status BIT,
	@DateInsert DATETIME,
	@DateUpdate DATETIME)
	
AS
BEGIN
	UPDATE [dbo].[Ecomerce_Register]
	 SET FullName = @FullName,
		Gender = @Gender,
		DateOfBirth = @DateOfBirth,
		RegistrationOfIndividuals = @RegistrationOfIndividuals,
		Telephone = @Telephone,
		ZipCode = @ZipCode,
		Address = @Address,
		Number = @Number,
		Neighborhood = @Neighborhood,
		City = @City,
		State = @State,
		Email = @Email,
		Password = @Password,
		ConfirmedEmail = @ConfirmedEmail,
		Status = @Status,
		DateInsert = @DateInsert,
		DateUpdate = @DateUpdate
		
	WHERE
				Id = @Id;
				
	SET NOCOUNT ON;
END
GO
	