-- =============================================
-- Create database [MiBoDB]
-- =============================================

USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'MiBoDB'
)
BEGIN
ALTER DATABASE [MiBoDB] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE [MiBoDB]
END
GO

CREATE DATABASE [MiBoDB]
GO

USE [MiBoDB]
GO

-- =============================================
-- Create table [MParameters]
-- =============================================
IF OBJECT_ID('[MParameters]', 'U') IS NOT NULL
    DROP TABLE [MParameters]
GO

CREATE TABLE [MParameters]
(
    [ParamCd] VARCHAR(255),
    [ParamName] NVARCHAR(255),
    [ParamValue] NVARCHAR(255),
    [ParamType] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([ParamCd])
)
GO

-- =============================================
-- Create table [MCodes]
-- =============================================
IF OBJECT_ID('[MCodes]', 'U') IS NOT NULL
  DROP TABLE [MCodes]
GO

CREATE TABLE [MCodes]
(
    [CodeGroupCd] VARCHAR(255),
    [CodeCd] VARCHAR(255),
    [CodeName] NVARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([CodeGroupCd], [CodeCd])
)
GO

-- =============================================
-- Create table [MNumbers]
-- =============================================
IF OBJECT_ID('[MNumbers]', 'U') IS NOT NULL
  DROP TABLE [MNumbers]
GO

CREATE TABLE [MNumbers]                    
(
    [Code] VARCHAR(255),
    [Year] VARCHAR(255),
    [Month] VARCHAR(255),
    [SlipNo] DECIMAL,
    [Digits] DECIMAL,
    [Notes] NVARCHAR(MAX),
    PRIMARY KEY ([Code], [Year], [Month], [SlipNo])
)
GO

-- =============================================
-- Create table [StorageFiles]
-- =============================================
IF OBJECT_ID('[StorageFiles]', 'U') IS NOT NULL
    DROP TABLE [StorageFiles]
GO

CREATE TABLE [StorageFiles]
(
    [FileId] VARCHAR(255),
	[FileNo] DECIMAL,
	[FileName] VARCHAR(255),
	[FileGroup] VARCHAR(255),
	[SortKey] DECIMAL,
	[ActiveFlag] BIT,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([FileId], [FileNo])
)
GO

-- =============================================
-- Create table [Units]
-- =============================================
IF OBJECT_ID('[Units]', 'U') IS NOT NULL
  DROP TABLE [Units]
GO

CREATE TABLE [Units]
(
    [UnitCd] VARCHAR(255),
    [UnitName] NVARCHAR(255),
	[UnitSearchName] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([UnitCd])
)
GO

-- =============================================
-- Create table [Categories]
-- =============================================
IF OBJECT_ID('[Categories]', 'U') IS NOT NULL
  DROP TABLE [Categories]
GO

CREATE TABLE [Categories]
(
    [CategoryCd] VARCHAR(255),
    [CategoryName] NVARCHAR(255),
	[CategorySearchName] VARCHAR(255),
	[CategoryDiv] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([CategoryCd])
)
GO

-- =============================================
-- Create table [Ages]
-- =============================================
IF OBJECT_ID('[Ages]', 'U') IS NOT NULL
  DROP TABLE [Ages]
GO

CREATE TABLE [Ages]
(
    [AgeCd] VARCHAR(255),
    [AgeName] NVARCHAR(255),
	[AgeSearchName] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([AgeCd])
)
GO

-- =============================================
-- Create table [Genders]
-- =============================================
IF OBJECT_ID('[Genders]', 'U') IS NOT NULL
    DROP TABLE [Genders]
GO

CREATE TABLE [Genders]
(
    [GenderCd] VARCHAR(255),
    [GenderName] NVARCHAR(255),
    [GenderSearchName] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([GenderCd])
)
GO

-- =============================================
-- Create table [Brands]
-- =============================================
IF OBJECT_ID('[Brands]', 'U') IS NOT NULL
    DROP TABLE [Brands]
GO

CREATE TABLE [Brands]
(
    [BrandCd] VARCHAR(255),
    [BrandName] NVARCHAR(255),
    [BrandSearchName] VARCHAR(255),
    [FileId] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([BrandCd])
)
GO

-- =============================================
-- Create table [Prices]
-- =============================================
IF OBJECT_ID('[Prices]', 'U') IS NOT NULL
    DROP TABLE [Prices]
GO

CREATE TABLE [Prices]
(
    [PriceCd] VARCHAR(255),
    [PriceName] NVARCHAR(255),
    [PriceDiv] VARCHAR(255),
    [PriceStart] DECIMAL,
    [PriceEnd] DECIMAL,
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([PriceCd])
)
GO

-- =============================================
-- Create table [Countries]
-- =============================================
IF OBJECT_ID('[Countries]', 'U') IS NOT NULL
    DROP TABLE [Countries]
GO

CREATE TABLE [Countries]
(
    [CountryCd] VARCHAR(255),
    [CountryName] NVARCHAR(255),
	[CountrySearchName] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([CountryCd])
)
GO

-- =============================================
-- Create table [Cities]
-- =============================================
IF OBJECT_ID('[Cities]', 'U') IS NOT NULL
    DROP TABLE [Cities]
GO

CREATE TABLE [Cities]
(
    [CityCd] VARCHAR(255),
    [CityName] NVARCHAR(255),
	[CitySeachName] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([CityCd])
)
GO

-- =============================================
-- Create table [Districts]
-- =============================================
IF OBJECT_ID('[Districts]', 'U') IS NOT NULL
    DROP TABLE [Districts]
GO

CREATE TABLE [Districts]
(
    [DistrictCd] VARCHAR(255),
    [DistrictName] NVARCHAR(255),
    [DistrictSearchName] VARCHAR(255),
    [CityCd] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([DistrictCd]),
    FOREIGN KEY ([CityCd]) REFERENCES [Cities]([CityCd])
)
GO

-- =============================================
-- Create table [Helps]
-- =============================================
IF OBJECT_ID('[Helps]', 'U') IS NOT NULL
    DROP TABLE [Helps]
GO

CREATE TABLE [Helps]
(
    [HelpCd] VARCHAR(255),
    [Title] NVARCHAR(255),
    [Contents] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([HelpCd])
)
GO

-- =============================================
-- Create table [FAQs]
-- =============================================
IF OBJECT_ID('[FAQs]', 'U') IS NOT NULL
    DROP TABLE [FAQs]
GO

CREATE TABLE [FAQs]
(
    [FAQCd] VARCHAR(255),
    [Question] NVARCHAR(2000),
    [Answer] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([FAQCd])
)
GO

-- =============================================
-- Create table [Items]
-- =============================================
IF OBJECT_ID('[Items]', 'U') IS NOT NULL
    DROP TABLE [Items]
GO

CREATE TABLE [Items]
(
    [ItemCd] VARCHAR(255),
    [ItemName] NVARCHAR(255),
	[ItemSearchName] VARCHAR(255),	
    [CategoryCd] VARCHAR(255),
    [AgeCd] VARCHAR(255),
    [GenderCd] VARCHAR(255),
	[BrandCd] VARCHAR(255),
    [CountryCd] VARCHAR(255),
	[UnitCd] VARCHAR(255),
    [ItemDiv] VARCHAR(255),
	[SalesPrice] DECIMAL,
    [BuyingPrice] DECIMAL,
	[Viewer] DECIMAL,
	[FileId] VARCHAR(255),
	[LinkVideo] VARCHAR(255),
	[Material] NVARCHAR(255),
	[SummaryNotes] NVARCHAR(4000),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([ItemCd]),
    FOREIGN KEY ([CategoryCd]) REFERENCES [Categories]([CategoryCd]),
    FOREIGN KEY ([AgeCd]) REFERENCES [Ages]([AgeCd]),
    FOREIGN KEY ([GenderCd]) REFERENCES [Genders]([GenderCd]),
	FOREIGN KEY ([BrandCd]) REFERENCES [Brands]([BrandCd]),
    FOREIGN KEY ([CountryCd]) REFERENCES [Countries]([CountryCd]),
	FOREIGN KEY ([UnitCd]) REFERENCES [Units]([UnitCd])
)
GO

-- =============================================
-- Create table [Offers]
-- =============================================
IF OBJECT_ID('[Offers]', 'U') IS NOT NULL
    DROP TABLE [Offers]
GO

CREATE TABLE [Offers]
(
    [OfferCd] VARCHAR(255),
	[OfferGroupCd] VARCHAR(255),
    [ItemCd] VARCHAR(255),
    [StartDate] DATETIME,
    [EndDate] DATETIME,
    [OfferDiv] VARCHAR(255),
    [Percent] DECIMAL,
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([OfferCd]),
    FOREIGN KEY ([ItemCd]) REFERENCES [Items]([ItemCd])
)
GO

-- =============================================
-- Create table [OfferItems]
-- =============================================
IF OBJECT_ID('[OfferItems]', 'U') IS NOT NULL
    DROP TABLE [OfferItems]
GO

CREATE TABLE [OfferItems]
(
    [OfferCd] VARCHAR(255),
    [DetailNo] DECIMAL,
    [OfferItemCd] VARCHAR(255),
    [OfferItemQtty] DECIMAL,
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([OfferCd],[DetailNo]),
    FOREIGN KEY ([OfferCd]) REFERENCES [Offers]([OfferCd]),
    FOREIGN KEY ([OfferItemCd]) REFERENCES [Items]([ItemCd])
)
GO

-- =============================================
-- Create table [Deliveries]
-- =============================================
IF OBJECT_ID('[Deliveries]', 'U') IS NOT NULL
    DROP TABLE [Deliveries]
GO

CREATE TABLE [Deliveries]
(
    [CustomerCd] VARCHAR(255),
    [DeliveryCd] VARCHAR(255),
    [DeliveryName] VARCHAR(255),
    [Address] VARCHAR(255),
    [Phone] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([CustomerCd],[DeliveryCd])
)
GO

-- =============================================
-- Create table [Suppliers]
-- =============================================
IF OBJECT_ID('[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [Suppliers]
GO

CREATE TABLE [Suppliers]
(
    [SupplierCd] VARCHAR(255),
    [SupplierName] NVARCHAR(255),
	[SupplierSearchName] VARCHAR(255),
    [Address] VARCHAR(255),
    [Phone] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([SupplierCd])
)
GO

-- =============================================
-- Create table [Banners]
-- =============================================
IF OBJECT_ID('[Banners]', 'U') IS NOT NULL
    DROP TABLE [Banners]
GO

CREATE TABLE [Banners]
(
    [BannerCd] VARCHAR(255),
    [BannerName] VARCHAR(255),
	[BannerSearchName] VARCHAR(255),
    [FileId] VARCHAR(255),
	[OfferGroupCd] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([BannerCd])
)
GO

-- =============================================
-- Create table [Accepts]
-- =============================================
IF OBJECT_ID('[Accepts]', 'U') IS NOT NULL
    DROP TABLE [Accepts]
GO

CREATE TABLE [Accepts]
(
    [AcceptSlipNo] VARCHAR(255),
    [SlipStatus] VARCHAR(255),
    [AcceptDate] DATETIME,
    [DeliveryDate] DATETIME,
    [WishDeliveryDate] DATETIME,
    [ClientCd] VARCHAR(255),
    [ClientName] NVARCHAR(255),
    [ClientAddress] NVARCHAR(255),
    [ClientTel] VARCHAR(255),
    [ClientCityCd] VARCHAR(255),
    [DeliveryCd] VARCHAR(255),
    [DeliveryName] NVARCHAR(255),
    [DeliveryAddress] NVARCHAR(255),
    [DeliveryTel] VARCHAR(255),
    [DeliveryCityCd] VARCHAR(255),
    [PaymentMethods] VARCHAR(255),
    [ViewId] VARCHAR(255),
    [GiftCd] VARCHAR(255),
    [UseGiftCd] VARCHAR(255),
    [TotalAmt] DECIMAL,
    [GenId] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([AcceptSlipNo])
)
GO

-- =============================================
-- Create table [AcceptDetails]
-- =============================================
IF OBJECT_ID('[AcceptDetails]', 'U') IS NOT NULL
    DROP TABLE [AcceptDetails]
GO

CREATE TABLE [AcceptDetails]
(
    [AcceptSlipNo] VARCHAR(255),
    [DetailNo] DECIMAL,
    [ItemCd] VARCHAR(255),
    [ItemName] NVARCHAR(255),
    [UnitCd] VARCHAR(255),
    [DetailQtty] DECIMAL,
    [DetailPrice] DECIMAL,
    [DetailAmt] DECIMAL,
    [Discount] DECIMAL,
    [DetailNotes] NVARCHAR(255),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([AcceptSlipNo],[DetailNo]),
    FOREIGN KEY ([AcceptSlipNo]) REFERENCES [Accepts]([AcceptSlipNo])
)
GO

-- =============================================
-- Create table [AcceptIOs]
-- =============================================
IF OBJECT_ID('[AcceptIOs]', 'U') IS NOT NULL
    DROP TABLE [AcceptIOs]
GO

CREATE TABLE [AcceptIOs]
(
    [AcceptSlipNo] VARCHAR(255),
    [SlipHistoryNo] DECIMAL,
    [correctionDiv] VARCHAR(255),
    [SlipStatus] VARCHAR(255),
    [AcceptDate] DATETIME,
    [DeliveryDate] DATETIME,
    [WishDeliveryDate] DATETIME,
    [ClientCd] VARCHAR(255),
    [ClientName] NVARCHAR(255),
    [ClientAddress] NVARCHAR(255),
    [ClientTel] VARCHAR(255),
    [DeliveryCd] VARCHAR(255),
    [DeliveryName] NVARCHAR(255),
    [DeliveryAddress] NVARCHAR(255),
    [DeliveryTel] VARCHAR(255),
    [PaymentMethods] VARCHAR(255),
	[ViewId] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([AcceptSlipNo],[SlipHistoryNo])
)
GO

-- =============================================
-- Create table [AcceptDetailIOs]
-- =============================================
IF OBJECT_ID('[AcceptDetailIOs]', 'U') IS NOT NULL
    DROP TABLE [AcceptDetailIOs]
GO
CREATE TABLE [AcceptDetailIOs]
(
    [AcceptSlipNo] VARCHAR(255),
    [SlipHistoryNo] DECIMAL,
    [DetailNo] DECIMAL,
    [ItemCd] VARCHAR(255),
    [ItemName] NVARCHAR(255),
    [UnitCd] VARCHAR(255),
    [DetailQtty] DECIMAL,
    [DetailPrice] DECIMAL,
    [DetailAmt] DECIMAL,
	[Discount] DECIMAL,
    [DetailNotes] NVARCHAR(255),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([AcceptSlipNo],[SlipHistoryNo],[DetailNo]),
    FOREIGN KEY ([AcceptSlipNo],[SlipHistoryNo]) REFERENCES [AcceptIOs]([AcceptSlipNo],[SlipHistoryNo])
)
GO

-- =============================================
-- Create table [Stocks]
-- =============================================
IF OBJECT_ID('[Stocks]', 'U') IS NOT NULL
    DROP TABLE [Stocks]
GO

CREATE TABLE [Stocks]
(
    [SlipNo] VARCHAR(255),
    [DetailNo] DECIMAL,
    [ItemCd] VARCHAR(255),
    [StockQtty] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([SlipNo],[DetailNo])
)
GO

-- =============================================
-- Create table [Users]
-- =============================================
IF OBJECT_ID('[Users]', 'U') IS NOT NULL
    DROP TABLE [Users]
GO

CREATE TABLE [Users]
(
    [UserCd] UNIQUEIDENTIFIER,
    [Email] VARCHAR(255),
    [Password] VARCHAR(255),
	[FullName] NVARCHAR(255),
    [Address] NVARCHAR(255),
	[CityCd] VARCHAR(255),
    [Phone1] VARCHAR(255),
    [Phone2] VARCHAR(255),
	[HasNewsletter] BIT,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY (UserCd),
	FOREIGN KEY ([CityCd]) REFERENCES [Cities]([CityCd]),
    UNIQUE ([Email])
)
GO

-- =============================================
-- Create table [Groups]
-- =============================================
IF OBJECT_ID('[Groups]', 'U') IS NOT NULL
    DROP TABLE [Groups]
GO

CREATE TABLE [Groups]
(
    [GroupCd] VARCHAR(255),
    [GroupName] NVARCHAR(255),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([GroupCd])
)
GO

-- =============================================
-- Create table [Roles]
-- =============================================
IF OBJECT_ID('[Roles]', 'U') IS NOT NULL
    DROP TABLE [Roles]
GO

CREATE TABLE [Roles]
(
    [RoleCd] VARCHAR(255),
    [RoleName] NVARCHAR(255),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([RoleCd])
)
GO

-- =============================================
-- Create table [GroupRoles]
-- =============================================
IF OBJECT_ID('[GroupRoles]', 'U') IS NOT NULL
    DROP TABLE [GroupRoles]
GO

CREATE TABLE [GroupRoles]
(
    [GroupCd] VARCHAR(255),
    [RoleCd] VARCHAR(255),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([GroupCd],[RoleCd]),
    FOREIGN KEY ([GroupCd]) REFERENCES [Groups]([GroupCd]),
    FOREIGN KEY ([RoleCd]) REFERENCES [Roles]([RoleCd])
)
GO

-- =============================================
-- Create table [UserGroups]
-- =============================================
IF OBJECT_ID('[UserGroups]', 'U') IS NOT NULL
    DROP TABLE [UserGroups]
GO

CREATE TABLE [UserGroups]
(
    [UserCd] UNIQUEIDENTIFIER,
    [GroupCd] VARCHAR(255),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([UserCd],[GroupCd]),
    FOREIGN KEY ([UserCd]) REFERENCES [Users]([UserCd]),
    FOREIGN KEY ([GroupCd]) REFERENCES [Groups]([GroupCd])
)
GO

-- =============================================
-- Create table [Newsletter]
-- =============================================
IF OBJECT_ID('[Newsletter]', 'U') IS NOT NULL
    DROP TABLE [Newsletter]
GO

CREATE TABLE [Newsletter]
(
    [Email] VARCHAR(255),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([Email])
)
GO
-- =============================================
-- Create table [GiftCard]
-- =============================================
IF OBJECT_ID('[GiftCard]', 'U') IS NOT NULL
    DROP TABLE [GiftCard]
GO

CREATE TABLE [GiftCard]
(
    [GiftCd] VARCHAR(255),
	[GiftStatus] VARCHAR(255),
    [Price] DECIMAL,
    [StartDate] DATETIME,
    [EndDate] DATETIME,
    [Notes] NVARCHAR(MAX),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([GiftCd])
)
GO