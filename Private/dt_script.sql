-- =============================================
-- Create data [MiBoDB]
-- =============================================
USE [MiBoDB]
GO

-- =============================================
-- Create table [MParameters]
-- =============================================
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


-- =============================================
-- Create table [CompanyInfos]
-- =============================================
INSERT INTO [CompanyInfos] VALUES ('01', N'Hotline', N'19001081', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [CompanyInfos] VALUES ('02', N'Địa chỉ', N'Address company', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [CompanyInfos] VALUES ('03', N'Email', N'info@domain.vn', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [CompanyInfos] VALUES ('04', N'Giới thiệu', N'Nội dung giới thiệu', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Units]
-- =============================================
INSERT INTO [Units] VALUES ('01', N'Cái', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Units] VALUES ('02', N'Chiếc', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Units] VALUES ('03', N'Bộ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Categories]
-- =============================================
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
INSERT INTO [Ages] VALUES ('01', N'12 Tháng', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('02', N'12 - 24 Tháng', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('03', N'2 - 5 Tuổi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('04', N'5 - 7 Tuổi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Genders]
-- =============================================
INSERT INTO [Genders] VALUES ('01', N'Nam', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Genders] VALUES ('02', N'Nữ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Brands]
-- =============================================
INSERT INTO [Brands] VALUES ('01', N'Apple', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('02', N'Disney Shop', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('03', N'Crayola', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('04', N'Mega Bloks', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Prices]
-- =============================================
INSERT INTO [Prices] VALUES ('01', N'< 1tr', '01', 0, 1000000, N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Prices] VALUES ('02', N'1tr - 2tr', '02', 1000000, 2000000, N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Prices] VALUES ('03', N'2tr - 5tr', '02', 2000000, 5000000, N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Prices] VALUES ('04', N'> 5tr', '03', 5000000, 0, N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Countries]
-- =============================================
INSERT INTO [Countries] VALUES ('01', N'Hoa Kỳ',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('02', N'Nhật Bản', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('03', N'Việt Nam', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Cities]
-- =============================================
INSERT INTO [Cities] VALUES ('01', N'TP.HCM',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Cities] VALUES ('02', N'Hà Nội', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Cities] VALUES ('03', N'Cần Thơ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

-- =============================================
-- Create table [Districts]
-- =============================================
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
INSERT INTO [Items] VALUES ('01', 'Item 01', 'item 01', '01', '01', '01', '01', '01', '01', '02', 120000, 100000, 0, 'Item Notes 01', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('02', 'Item 02', 'item 02', '01', '01', '01', '01', '01', '01', '02', 80000, 50000, 5, 'Item Notes 02', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('03', 'Item 03', 'item 03', '01', '02', '01', '01', '02', '02', '02', 30000, 20000, 4, 'Item Notes 03', 3, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('04', 'Item 04', 'item 04', '01', '01', '02', '01', '02', '01', '02', 15000, 10000, 0, 'Item Notes 04', 4, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('05', 'Item 05', 'item 05', '02', '02', '01', '01', '01', '01', '01', 320000, 250000, 0, 'Item Notes 05', 5, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('06', 'Item 06', 'item 06', '02', '01', '02', '01', '01', '02', '01', 150000, 100000, 0, 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Offers]
-- =============================================
INSERT INTO [Offers] VALUES ('01', '01', '2013-01-27', '2013-03-27', '01', 10, '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Offers] VALUES ('02', '02', '2013-01-27', '2013-03-27', '02', 0, '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [OfferItems]
-- =============================================
INSERT INTO [OfferItems] VALUES ('02', 1, '06', 1, '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Deliveries]
-- =============================================

-- =============================================
-- Create table [Suppliers]
-- =============================================

-- =============================================
-- Create table [Banners]
-- =============================================
INSERT INTO [Banners] VALUES ('01', 'Banner 01', '01.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('02', 'Banner 02', '02.jpg', '', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('03', 'Banner 03', '03.jpg', '', 3, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('04', 'Banner 04', '04.jpg', '', 4, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Accepts]
-- =============================================

-- =============================================
-- Create table [AcceptDetails]
-- =============================================

-- =============================================
-- Create table [AcceptIOs]
-- =============================================

-- =============================================
-- Create table [AcceptDetailIOs]
-- =============================================

-- =============================================
-- Create table [Stocks]
-- =============================================

-- =============================================
-- Create table [Users]
-- =============================================

-- Insert (username: admin@mibo.vn, password: system)
INSERT INTO [Users] VALUES (NEWID(), 'admin@mibo.vn',  '54b53072540eeeb8f8e9343e71f28176', 'Administrator', 'Address', '01', '0919057114', '0919057114', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
-- Insert (username: guest@mibo.vn, password: mibovn)
INSERT INTO [Users] VALUES (NEWID(), 'guest@mibo.vn',  '24e755327f99081601eb60b0b8b771ce', 'Guest', '', '01', '', '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Groups]
-- =============================================
INSERT INTO [Groups] VALUES ('administrators', 'Quản trị', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Groups] VALUES ('users', 'Người dùng', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [UserGroups]
-- =============================================
DECLARE @UserCd UNIQUEIDENTIFIER
SELECT @UserCd=[UserCd] FROM [Users] WHERE Email='admin@mibo.vn'
INSERT INTO [UserGroups] VALUES (@UserCd, 'administrators', 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Roles]
-- =============================================

-- =============================================
-- Create table [GroupRoles]
-- =============================================

-- =============================================
-- Create table [Newsletter]
-- =============================================