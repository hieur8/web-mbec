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

INSERT INTO [MParameters] VALUES ('01', N'Giảm giá cho thành viên', N'10', 'Number', N'Nhập số phần trăm sẻ giảm giá', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('02', N'Email (info)', N'info@domain.vn', 'String', N'Nhập mật khẩu đăng nhập email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('03', N'Mật khẩu (info)', N'pass', 'Password', N'Nhập mật khẩu đăng nhập email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('04', N'Email (sale)', N'sale@domain.vn', 'String', N'Nhập mật khẩu đăng nhập email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('05', N'Mật khẩu (sale)', N'pass', 'Password', N'Nhập mật khẩu đăng nhập email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('06', N'Yahoo', N'yahoo', 'String', N'Nhập tên đăng nhập yahoo', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('07', N'Skype', N'skype', 'String', N'Nhập tên đăng nhập skype', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [MCodes] VALUES ('sys-delete-flag', 'False', N'Hiện', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-delete-flag', 'True', N'Ẩn', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-item-div', '01', N'Thông thường', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-item-div', '02', N'Mới', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-category-div', '01', N'Đồ chơi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-category-div', '02', N'Phụ kiện', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-price-div', '01', N'Nhỏ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-price-div', '02', N'Giữa', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-price-div', '03', N'Lớn', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-payment-methods', '01', N'Thanh toán tiền mặt khi nhận hàng.', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-payment-methods', '02', N'Thẻ ATM đăng ký Internet Banking (Miễn phí thanh toán).', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-payment-methods', '03', N'Thanh toán bằng thẻ quốc tế Visa, Master.', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-payment-methods', '04', N'Chuyển khoản ngân hàng (Quý khách tự thanh toán chi phí chuyển khoản).', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-slip-status', '01', N'Chờ xác nhận', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-slip-status', '02', N'Xác nhận', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-slip-status', '03', N'Chờ thanh toán', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-slip-status', '04', N'Hoàn thành', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-slip-status', '05', N'Đã hủy', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-slip-status', '06', N'Đổi trả', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-correction-div', '01', N'Thêm', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-correction-div', '02', N'Sửa', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-correction-div', '03', N'Xóa', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-offer-div', '01', N'Giảm giá', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-offer-div', '02', N'Tặng sản phẩm', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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
-- Create table [CompanyInfos]
-- =============================================
IF OBJECT_ID('[CompanyInfos]', 'U') IS NOT NULL
  DROP TABLE [CompanyInfos]
GO

CREATE TABLE [CompanyInfos]
(
    [InfoCd] VARCHAR(255),
    [InfoName] NVARCHAR(255),
    [InfoValue] NVARCHAR(MAX),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([InfoCd])
)
GO

INSERT INTO [CompanyInfos] VALUES ('01', N'Hotline', N'19001081', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [CompanyInfos] VALUES ('02', N'Địa chỉ', N'Address company', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [CompanyInfos] VALUES ('03', N'Email', N'info@domain.vn', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [CompanyInfos] VALUES ('04', N'Giới thiệu', N'Nội dung giới thiệu', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [Units] VALUES ('01', N'Cái', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Units] VALUES ('02', N'Chiếc', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Units] VALUES ('03', N'Bộ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [Categories] VALUES ('01', N'Đồ chơi bằng gỗ', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('02', N'Âm nhạc & Nhạc cụ', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('03', N'Xếp hình & Láp ghép', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('04', N'Giáo dục & Học tập', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('05', N'Phụ kiện bằng gỗ', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('06', N'Phụ kiện âm nhạc', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [Ages] VALUES ('01', N'12 Tháng', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('02', N'12 - 24 Tháng', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('03', N'2 - 5 Tuổi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('04', N'5 - 7 Tuổi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [Genders] VALUES ('01', N'Nam', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Genders] VALUES ('02', N'Nữ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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
	[Image] VARCHAR(255),
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

INSERT INTO [Brands] VALUES ('01', N'Apple', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('02', N'Disney Shop', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('03', N'Crayola', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('04', N'Mega Bloks', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [Prices] VALUES ('01', N'< 1tr', '01', 0, 1000000, N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Prices] VALUES ('02', N'1tr - 2tr', '02', 1000000, 2000000, N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Prices] VALUES ('03', N'2tr - 5tr', '02', 2000000, 5000000, N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Prices] VALUES ('04', N'> 5tr', '03', 5000000, 0, N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [Countries] VALUES ('01', N'Hoa Kỳ',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('02', N'Nhật Bản', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('03', N'Việt Nam', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [Cities] VALUES ('01', N'TP.HCM',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Cities] VALUES ('02', N'Hà Nội', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Cities] VALUES ('03', N'Cần Thơ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

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

INSERT INTO [Districts] VALUES ('01', N'Quận 1', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('02', N'Quận 2', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('03', N'Quận 3', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('04', N'Quận 4', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('05', N'Quận 5', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('06', N'Quận 6', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('07', N'Quận 7', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('08', N'Quận 8', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('09', N'Quận 9', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('10', N'Quận 10', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('11', N'Quận 11', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('12', N'Quận 12', '01',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('13', N'Quận Ba Đình', '02',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('14', N'Quận Hoàn Kiếm', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('15', N'Quận Tây Hồ', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('16', N'Quận Long Biên', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('17', N'Quận Cầu Giấy', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('18', N'Quận Đống Đa', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('19', N'Quận Hai Bà Trưng', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('20', N'Quận Hoàng Mai', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('21', N'Quận Ninh Kiều', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('22', N'Quận Bình Thủy', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('23', N'Quận Cái Răng', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('24', N'Quận Ô Môn', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Districts] VALUES ('25', N'Quận Thốt Nốt', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

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

INSERT INTO [Helps] VALUES ('01', N'Hướng dẫn đặt hàng',  N'Nội dung hướng dẫn đặt hàng', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Helps] VALUES ('02', N'Phương thức thanh toán', N'Nội dung phương thức thanh toán', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Helps] VALUES ('03', N'Phương thức vận chuyển', N'Nội dung phương thức vận chuyển', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Helps] VALUES ('04', N'Chính sách đổi trả', N'Nội dung chính sách đổi trả', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Helps] VALUES ('05', N'Chính sách bảo mật', N'Nội dung chính sách bảo mật', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Helps] VALUES ('06', N'Điều khoản sử dụng', N'Nội dung điều khoản sử dụng', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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

INSERT INTO [FAQs] VALUES ('01', N'Nội dung câu hỏi',  N'Nội dung trả lời', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [FAQs] VALUES ('02', N'Nội dung câu hỏi',  N'Nội dung trả lời', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [FAQs] VALUES ('03', N'Nội dung câu hỏi',  N'Nội dung trả lời', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [FAQs] VALUES ('04', N'Nội dung câu hỏi',  N'Nội dung trả lời', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [FAQs] VALUES ('05', N'Nội dung câu hỏi',  N'Nội dung trả lời', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [FAQs] VALUES ('06', N'Nội dung câu hỏi',  N'Nội dung trả lời', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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
    [CategoryCd] VARCHAR(255),
    [AgeCd] VARCHAR(255),
    [GenderCd] VARCHAR(255),
	[BrandCd] VARCHAR(255),
    [CountryCd] VARCHAR(255),
	[UnitCd] VARCHAR(255),
    [ItemDiv] VARCHAR(255),
	[Viewer] DECIMAL,
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

INSERT INTO [Items] VALUES ('01', 'Item 01', '01', '01', '01', '01', '01', '01', '02', 0, 'Item Notes 01', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('02', 'Item 02', '01', '01', '01', '01', '01', '01', '02', 5, 'Item Notes 02', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('03', 'Item 03', '01', '02', '01', '01', '02', '02', '02', 4, 'Item Notes 03', 3, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('04', 'Item 04', '01', '01', '02', '01', '02', '01', '02', 0, 'Item Notes 04', 4, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('05', 'Item 05', '02', '02', '01', '01', '01', '01', '01', 0, 'Item Notes 05', 5, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('06', 'Item 06', '02', '01', '02', '01', '01', '02', '01', 0, 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)

-- =============================================
-- Create table [Packs]
-- =============================================
IF OBJECT_ID('[Packs]', 'U') IS NOT NULL
    DROP TABLE [Packs]
GO

CREATE TABLE [Packs]
(
    [ItemCd] VARCHAR(255),
	[UnitCd] VARCHAR(255),
    [SalesPrice] DECIMAL,
    [BuyingPrice] DECIMAL,
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([ItemCd],[UnitCd]),
	FOREIGN KEY ([ItemCd]) REFERENCES [Items]([ItemCd]),
	FOREIGN KEY ([UnitCd]) REFERENCES [Units]([UnitCd])
)
GO

INSERT INTO [Packs] VALUES ('01', '01', 120000, 100000, '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Packs] VALUES ('02', '01', 80000, 50000, '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Packs] VALUES ('03', '02', 30000, 20000, '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Packs] VALUES ('04', '01', 15000, 10000, '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Packs] VALUES ('05', '01', 320000, 250000, '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Packs] VALUES ('06', '02', 150000, 100000, '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Packs] VALUES ('01', '02', 1200000, 1000000, '', 2, 'init', GETDATE(), 'init', GETDATE(), 0)

-- =============================================
-- Create table [ItemImages]
-- =============================================
IF OBJECT_ID('[ItemImages]', 'U') IS NOT NULL
    DROP TABLE [ItemImages]
GO

CREATE TABLE [ItemImages]
(
    [ItemCd] VARCHAR(255),
    [Image] VARCHAR(255),
    [Notes] NVARCHAR(MAX),
    [SortKey] DECIMAL,
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([ItemCd],[Image]),
    FOREIGN KEY ([ItemCd]) REFERENCES [Items]([ItemCd])
)
GO

INSERT INTO [ItemImages] VALUES ('01', '01.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [ItemImages] VALUES ('01', '02.jpg', '', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [ItemImages] VALUES ('02', '01.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [ItemImages] VALUES ('03', '01.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [ItemImages] VALUES ('04', '01.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [ItemImages] VALUES ('05', '01.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [ItemImages] VALUES ('06', '01.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)

-- =============================================
-- Create table [Offers]
-- =============================================
IF OBJECT_ID('[Offers]', 'U') IS NOT NULL
    DROP TABLE [Offers]
GO

CREATE TABLE [Offers]
(
    [OfferCd] VARCHAR(255),
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

INSERT INTO [Offers] VALUES ('01', '01', '2013-01-27', '2013-03-27', '01', 10, '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Offers] VALUES ('02', '02', '2013-01-27', '2013-03-27', '02', 0, '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

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

INSERT INTO [OfferItems] VALUES ('02', 1, '06', 1, '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

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
    [SupplierName] VARCHAR(255),
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
    [Image] VARCHAR(255),
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

INSERT INTO [Banners] VALUES ('01', 'Banner 01', '01.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('02', 'Banner 02', '02.jpg', '', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('03', 'Banner 03', '03.jpg', '', 3, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('04', 'Banner 04', '04.jpg', '', 4, 'init', GETDATE(), 'init', GETDATE(), 0)

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
    PRIMARY KEY ([AcceptSlipNo])
)

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
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY (UserCd),
	FOREIGN KEY ([CityCd]) REFERENCES [Cities]([CityCd]),
    UNIQUE ([Email])
)

-- Insert (username: admin@mibo.vn, password: admin)
INSERT INTO [Users] VALUES (NEWID(), 'admin@mibo.vn',  '21232f297a57a5a743894a0e4a801fc3', 'Administrator', 'Address', '01', '0919057114', '0919057114', 'init', GETDATE(), 'init', GETDATE(), 0)
-- Insert (username: guest@mibo.vn, password: guest)
INSERT INTO [Users] VALUES (NEWID(), 'guest@mibo.vn',  '084e0343a0486ff05530df6c705c8bb4', 'Guest', '', '01', '', '', 'init', GETDATE(), 'init', GETDATE(), 0)

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

-- =============================================
-- Create table [UserLikes]
-- =============================================
IF OBJECT_ID('[UserLikes]', 'U') IS NOT NULL
    DROP TABLE [UserLikes]
GO

CREATE TABLE [UserLikes]
(
    [UserCd] UNIQUEIDENTIFIER,
    [ItemCd] VARCHAR(255),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([UserCd],[ItemCd]),
    FOREIGN KEY ([UserCd]) REFERENCES [Users]([UserCd]),
    FOREIGN KEY ([ItemCd]) REFERENCES [Items]([ItemCd])
)

-- =============================================
-- Create table [UserComments]
-- =============================================
IF OBJECT_ID('[UserComments]', 'U') IS NOT NULL
    DROP TABLE [UserComments]
GO
CREATE TABLE [UserComments]
(
    [UserCd] UNIQUEIDENTIFIER,
    [ItemCd] VARCHAR(255),
    [CommentCd] VARCHAR(255),
    [Contents] NVARCHAR(MAX),
    [CreateUser] VARCHAR(255),
    [CreateDate] DATETIME,
    [UpdateUser] VARCHAR(255),
    [UpdateDate] DATETIME,
    [DeleteFlag] BIT,
    PRIMARY KEY ([UserCd],[ItemCd],[CommentCd]),
    FOREIGN KEY ([ItemCd]) REFERENCES [Items]([ItemCd])
)

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