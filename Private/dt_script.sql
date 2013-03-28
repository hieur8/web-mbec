-- =============================================
-- Create data [MiBoDB]
-- =============================================
USE [MiBoDB]
GO

-- =============================================
-- Create table [MParameters]
-- =============================================
INSERT INTO [MParameters] VALUES ('001', N'Giảm giá cho thành viên', N'10', 'Number', N'Nhập số phần trăm sẻ giảm giá', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('002', N'Hotline', N'0976.585.888', 'String', N'Nhập số điện thoại hổ trợ.', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('003', N'Địa chỉ', N'Address company', 'String', N'Nhập địa chỉ công ty', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('004', N'Yahoo', N'yahoo', 'String', N'Nhập tên đăng nhập yahoo', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('005', N'Skype', N'skype', 'String', N'Nhập tên đăng nhập skype', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('006', N'Email (info)', N'info@mibo.vn', 'String', N'Nhập địa chỉ email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('007', N'Mật khẩu (info)', N'pass', 'Password', N'Nhập mật khẩu đăng nhập email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('008', N'Email (sale)', N'sale@mibo.vn', 'String', N'Nhập địa chỉ email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('009', N'Mật khẩu (sale)', N'pass', 'Password', N'Nhập mật khẩu đăng nhập email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('010', N'Email (support)', N'support@mibo.vn', 'String', N'Nhập địa chỉ email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('011', N'Mật khẩu (support)', N'Abc12345', 'Password', N'Nhập mật khẩu đăng nhập email', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MParameters] VALUES ('012', N'Mail server', N'mail.mibo.vn', 'String', N'Nhập địa chỉ mail server', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

GO

-- =============================================
-- Create table [MCodes]
-- =============================================
INSERT INTO [MCodes] VALUES ('sys-delete-flag', 'False', N'Hiện', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-delete-flag', 'True', N'Ẩn', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-item-div', '01', N'Thông thường', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-item-div', '02', N'Mới', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-category-div', '01', N'Đồ chơi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-category-div', '02', N'Dụng cụ học tập', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-category-div', '03', N'Sách', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-price-div', '01', N'Nhỏ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-price-div', '02', N'Giữa', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-price-div', '03', N'Lớn', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [MCodes] VALUES ('sys-payment-methods', '01', N'Tiền mặt', N'Thanh toán tiền mặt khi nhận hàng.', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-payment-methods', '02', N'Thẻ ATM', N'Thẻ ATM đăng ký Internet Banking (Miễn phí thanh toán).', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-payment-methods', '03', N'Visa, Master.', N'Thanh toán bằng thẻ quốc tế Visa, Master.', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-payment-methods', '04', N'Chuyển khoản', N'Chuyển khoản ngân hàng (Quý khách tự thanh toán chi phí chuyển khoản).', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

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
-- Create table [Units]
-- =============================================
INSERT INTO [Units] VALUES ('01', N'Cái', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Units] VALUES ('02', N'Chiếc', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Units] VALUES ('03', N'Bộ', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Categories]
-- =============================================
INSERT INTO [Categories] VALUES ('01', N'Đồ chơi cát', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('02', N'Đồ chơi nước', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('03', N'Đồ chơi giáo dục', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('04', N'Đồ chơi cho trẻ sơ sinh', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('05', N'Bút & viết', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('06', N'Vở', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('07', N'Cặp sách', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('08', N'Sách giáo khoa', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('09', N'Sách thiếu nhi', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('10', N'Truyện thiếu nhi', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Ages]
-- =============================================
INSERT INTO [Ages] VALUES ('01', N'0 – 24 tháng', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('02', N'2 – 4 tuổi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('03', N'4 – 6 tuổi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('04', N'6 – 8 tuổi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('05', N'8 – 12 tuổi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('06', N'12+', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Genders]
-- =============================================
INSERT INTO [Genders] VALUES ('01', N'Bé trai', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Genders] VALUES ('02', N'Bé gái', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Genders] VALUES ('03', N'Bé trai, bé gái', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Brands]
-- =============================================
INSERT INTO [Brands] VALUES ('01', N'Lego', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('02', N'Tomy', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('03', N'Gowi', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('04', N'Little Tikes', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('05', N'Teifoc', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('06', N'Fischer Tip', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('07', N'Fischer Technik', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('08', N'Eitech', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('09', N'Ravenburger', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('10', N'Magic Nuudles', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('11', N'Huna Robo', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('12', N'PhanThi', '', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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
INSERT INTO [Countries] VALUES ('01', N'Đức',  N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('02', N'Áo', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('03', N'Đan Mạch', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('04', N'Thái Lan', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('05', N'Việt Nam', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('06', N'Hàn Quốc', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('07', N'Singapore', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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
INSERT INTO [Items] VALUES ('01', 'Item 01', 'item 01', '01', '01', '01', '01', '01', '01', '02', 120000, 100000, 0, 'Youtube 01', 'Material 01', 'Summary notes 01', 'Item Notes 01', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('02', 'Item 02', 'item 02', '01', '01', '01', '02', '01', '01', '02', 80000, 50000, 5, 'Youtube 02', 'Material 02', 'Summary notes 02', 'Item Notes 02', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('03', 'Item 03', 'item 03', '01', '02', '01', '01', '02', '02', '02', 30000, 20000, 4, 'Youtube 03', 'Material 03', 'Summary notes 03', 'Item Notes 03', 3, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('04', 'Item 04', 'item 04', '01', '01', '02', '04', '02', '01', '02', 15000, 10000, 0, 'Youtube 04', 'Material 04', 'Summary notes 04', 'Item Notes 04', 4, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('05', 'Item 05', 'item 05', '02', '02', '01', '03', '01', '01', '01', 320000, 250000, 0, 'Youtube 05', 'Material 05', 'Summary notes 05', 'Item Notes 05', 5, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('06', 'Item 06', 'item 06', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'Youtube 06', 'Material 06', 'Summary notes 06', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Offers]
-- =============================================
INSERT INTO [Offers] VALUES ('01', '01', '2013-03-27', '2013-05-27', '01', 10, '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Offers] VALUES ('02', '02', '2013-03-27', '2013-05-27', '02', 0, '', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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
INSERT INTO [Banners] VALUES ('01', 'Banner 01', 'S1.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('02', 'Banner 02', 'S2.jpg', '', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('03', 'Banner 03', 'S3.jpg', '', 3, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('04', 'Banner 04', 'S4.jpg', '', 4, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('05', 'Banner 05', 'S5.jpg', '', 5, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('06', 'Banner 06', 'S6.jpg', '', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('07', 'Banner 07', 'S7.jpg', '', 7, 'init', GETDATE(), 'init', GETDATE(), 0)
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