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

INSERT INTO [MCodes] VALUES ('sys-gift-status', '01', N'Chưa kích hoạt', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-gift-status', '02', N'Kích hoạt', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [MCodes] VALUES ('sys-gift-status', '03', N'Đã dùng', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

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
-- Create table [StorageFiles]
-- =============================================
INSERT INTO [StorageFiles] VALUES ('b01', 1, 'S1.jpg', 'banners', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('b02', 1, 'S2.jpg', 'banners', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('b03', 1, 'S3.jpg', 'banners', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('b04', 1, 'S4.jpg', 'banners', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('b05', 1, 'S5.jpg', 'banners', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('b06', 1, 'S6.jpg', 'banners', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('b07', 1, 'S7.jpg', 'banners', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)

INSERT INTO [StorageFiles] VALUES ('i01', 1, 'bcfcb87bda1ed406f9d9949fb53deb5d.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i01', 2, 'cae3a1d95cec0de91ec13db789d746c8.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i02', 1, 'ce42a95453428b3e253af21b42101b74.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i03', 1, 'cae3a1d95cec0de91ec13db789d746c8.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i04', 1, 'f67e094e7a618049a0cd331c2b87b120.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i05', 1, 'ce42a95453428b3e253af21b42101b74.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i06', 1, 'bcfcb87bda1ed406f9d9949fb53deb5d.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i07', 1, 'd06320f2cb56d5f4a538e134c0d30c13.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i08', 1, 'f67e094e7a618049a0cd331c2b87b120.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i09', 1, 'bcfcb87bda1ed406f9d9949fb53deb5d.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i10', 1, 'd06320f2cb56d5f4a538e134c0d30c13.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i11', 1, 'ce42a95453428b3e253af21b42101b74.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i12', 1, 'cae3a1d95cec0de91ec13db789d746c8.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i13', 1, 'bcfcb87bda1ed406f9d9949fb53deb5d.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i14', 1, 'f69c953491bc05bb456fcf9596985129.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i15', 1, 'bcfcb87bda1ed406f9d9949fb53deb5d.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i16', 1, 'cae3a1d95cec0de91ec13db789d746c8.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i17', 1, 'bcfcb87bda1ed406f9d9949fb53deb5d.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i18', 1, 'ce42a95453428b3e253af21b42101b74.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i19', 1, 'cae3a1d95cec0de91ec13db789d746c8.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [StorageFiles] VALUES ('i20', 1, 'd06320f2cb56d5f4a538e134c0d30c13.jpg', 'items', 0, 1, 'init', GETDATE(), 'init', GETDATE(), 0)

GO

-- =============================================
-- Create table [Units]
-- =============================================
INSERT INTO [Units] VALUES ('01', N'Cái', 'cai', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Units] VALUES ('02', N'Chiếc', 'chiec', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Units] VALUES ('03', N'Bộ', 'bo', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Categories]
-- =============================================
INSERT INTO [Categories] VALUES ('01', N'Đồ chơi cát', 'do choi cat', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('02', N'Đồ chơi nước', 'do choi nuoc', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('03', N'Đồ chơi giáo dục', 'do choi giao duc', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('04', N'Đồ chơi cho trẻ sơ sinh', 'do choi cho tre so sinh', '01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('05', N'Bút & viết', 'but & viet', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('06', N'Vở', 'vo', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('07', N'Cặp sách', 'cap sach', '02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('08', N'Sách giáo khoa', 'sach giao khoa', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('09', N'Sách thiếu nhi', 'sach thieu nhi', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Categories] VALUES ('10', N'Truyện thiếu nhi', 'truyen thieu nhi', '03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Ages]
-- =============================================
INSERT INTO [Ages] VALUES ('01', N'0 – 24 tháng', '0 - 24 thang', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('02', N'2 – 4 tuổi', '2 - 4 tuoi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('03', N'4 – 6 tuổi', '4 - 6 tuoi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('04', N'6 – 8 tuổi', '6 - 8 tuoi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('05', N'8 – 12 tuổi', '8 - 12 tuoi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Ages] VALUES ('06', N'12+', '12+', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Genders]
-- =============================================
INSERT INTO [Genders] VALUES ('01', N'Bé trai', 'be trai', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Genders] VALUES ('02', N'Bé gái', 'be gai', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Genders] VALUES ('03', N'Bé trai, bé gái', 'be trai, be gai', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Brands]
-- =============================================
INSERT INTO [Brands] VALUES ('01', N'Lego', 'lego', 'brand01', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('02', N'Tomy', 'tomy', 'brand02', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('03', N'Gowi', 'gowi', 'brand03', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('04', N'Little Tikes', 'little tikes', 'brand04', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('05', N'Teifoc', 'teifoc', 'brand05', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('06', N'Fischer Tip', 'fischer tip', 'brand06', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('07', N'Fischer Technik', 'fischer technik', 'brand07', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('08', N'Eitech', 'eitech', 'brand08', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('09', N'Ravenburger', 'ravenburger', 'brand09', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('10', N'Magic Nuudles', 'magic nuudles', 'brand10', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('11', N'Huna Robo', 'huna robo', 'brand11', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Brands] VALUES ('12', N'PhanThi', 'phanthi', 'brand12', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
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
INSERT INTO [Countries] VALUES ('01', N'Đức', 'duc', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('02', N'Áo', 'ao', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('03', N'Đan Mạch', 'dan mach', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('04', N'Thái Lan', 'thai lan', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('05', N'Việt Nam', 'viet nam', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('06', N'Hàn Quốc', 'han quoc', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Countries] VALUES ('07', N'Singapore', 'singapore', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
GO

-- =============================================
-- Create table [Cities]
-- =============================================
INSERT INTO [Cities] VALUES ('01', N'TP.HCM', 'tp.hcm', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Cities] VALUES ('02', N'Hà Nội', 'ha noi', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Cities] VALUES ('03', N'Cần Thơ', 'can tho', N'Notes', 0, 'init', GETDATE(), 'init', GETDATE(), 0)

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
INSERT INTO [Items] VALUES ('01', 'Item 01', 'item 01', '01', '01', '01', '01', '01', '01', '02', 120000, 100000, 0, 'i01', '', 'Material 01', 'Summary notes 01', 'Item Notes 01', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('02', 'Item 02', 'item 02', '01', '01', '01', '02', '01', '01', '02', 80000, 50000, 0, 'i02', '', 'Material 02', 'Summary notes 02', 'Item Notes 02', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('03', 'Item 03', 'item 03', '01', '02', '01', '01', '02', '02', '02', 30000, 20000, 0, 'i03', '', 'Material 03', 'Summary notes 03', 'Item Notes 03', 3, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('04', 'Item 04', 'item 04', '01', '01', '02', '04', '02', '01', '02', 15000, 10000, 0, 'i04', '', 'Material 04', 'Summary notes 04', 'Item Notes 04', 4, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('05', 'Item 05', 'item 05', '02', '02', '01', '03', '01', '01', '01', 320000, 250000, 0, 'i05', '', 'Material 05', 'Summary notes 05', 'Item Notes 05', 5, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('06', 'Item 06', 'item 06', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i06', '', 'Material 06', 'Summary notes 06', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('07', 'Item 07', 'item 07', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i07', '', 'Material 06', 'Summary notes 07', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('08', 'Item 08', 'item 08', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i08', '', 'Material 06', 'Summary notes 08', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('09', 'Item 09', 'item 09', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i09', '', 'Material 06', 'Summary notes 09', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('10', 'Item 10', 'item 10', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i10', '', 'Material 06', 'Summary notes 10', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('11', 'Item 11', 'item 11', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i11', '', 'Material 06', 'Summary notes 11', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('12', 'Item 12', 'item 12', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i12', '', 'Material 06', 'Summary notes 12', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('13', 'Item 13', 'item 13', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i13', '', 'Material 06', 'Summary notes 13', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('14', 'Item 14', 'item 14', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i14', '', 'Material 06', 'Summary notes 14', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('15', 'Item 15', 'item 15', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i15', '', 'Material 06', 'Summary notes 15', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('16', 'Item 16', 'item 16', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i16', '', 'Material 06', 'Summary notes 16', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('17', 'Item 17', 'item 17', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i17', '', 'Material 06', 'Summary notes 17', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('18', 'Item 18', 'item 18', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i18', '', 'Material 06', 'Summary notes 18', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('19', 'Item 19', 'item 19', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i19', '', 'Material 06', 'Summary notes 19', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('20', 'Item 20', 'item 20', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i20', '', 'Material 06', 'Summary notes 20', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Items] VALUES ('21', 'Item 21', 'item 21', '02', '01', '02', '05', '01', '02', '01', 150000, 100000, 0, 'i21', '', 'Material 06', 'Summary notes 21', 'Item Notes 06', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
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
INSERT INTO [Banners] VALUES ('01', 'Banner 01', 'banner 01', 'S1.jpg', '', 1, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('02', 'Banner 02', 'banner 02', 'S2.jpg', '', 2, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('03', 'Banner 03', 'banner 03', 'S3.jpg', '', 3, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('04', 'Banner 04', 'banner 04', 'S4.jpg', '', 4, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('05', 'Banner 05', 'banner 05', 'S5.jpg', '', 5, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('06', 'Banner 06', 'banner 06', 'S6.jpg', '', 6, 'init', GETDATE(), 'init', GETDATE(), 0)
INSERT INTO [Banners] VALUES ('07', 'Banner 07', 'banner 07', 'S7.jpg', '', 7, 'init', GETDATE(), 'init', GETDATE(), 0)
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