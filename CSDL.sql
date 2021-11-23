--																XÂY DỰNG CƠ SỞ DỮ LIỆU 
--																								NHÓM 08
USE master;
GO
IF DB_ID (N'VanChuyenKhach') IS NOT NULL
DROP DATABASE VanChuyenKhach
GO
create database VanChuyenKhach
GO
use VanChuyenKhach

GO
-- Tạo bảng TAIKHOAN
create table TAIKHOAN 
(
	UserName varchar(50),
	PassWord varchar(50),
	TypeAcc varchar(10),
	primary key(UserName)
)
GO
-- Tạo bảng LAIXE
create table LAIXE
(
	MaLaiXe varchar(10),
	TenLaiXe nvarchar(50),
	SDT_LX varchar(15),
	DiaChi_LX nvarchar(150),
	primary key(MaLaiXe)
)
GO
-- Tạo bảng XE
create table XE
(
	BienSoXe varchar(15),
	SCN int,
	primary key(BienSoXe)
)
GO 
-- Tạo bảng TINHTRANG
create table TINHTRANG
(
	MaTinhTrang varchar(10),
	BienSoXe varchar(15),
	DongCo nvarchar(10),
	MayLanh nvarchar(10),
	NguonDien varchar(10),
	CuaXe nvarchar(10),
	ThoiGianCapNhap time,
	primary key(MaTinhTrang),
	foreign key(BienSoXe) references XE
)
GO
-- Tạo bảng DICHVU
create table DICHVU
(
	MaDichVu varchar(10),
	TenDichVu nvarchar(100),
	primary key(MaDichVu)
)
GO
-- Tạo bảng KHACHHANG
create table KHACHHANG
(
	MaKH varchar(10),
	TenKH nvarchar(50),
	SDT_KH varchar(15),
	DiaChiKH nvarchar(150),
	primary key(MaKH)
)
GO
-- Tạo bảng NHAN VIEN
create table NHANVIEN
(
	MaNV varchar(10),
	TenNV nvarchar(50),
	SDT_NV varchar(15),
	DiaChiNV nvarchar(150),
	primary key(MaNV),
)
GO
-- Tạo bảng QUANLY
create table QUANLY 
(
	MaNV varchar(10),
	MaQL varchar(10),
	MaLaiXe varchar(10),
	BienSoXe varchar(15),
	MaTinhTrang varchar(10),
	NgayBatDau date,
	NgayKetThuc date,
	TocDo int,
	DiaDiem nvarchar(50),
	primary key(MaNV, MaQL),
	foreign key(MaLaiXe) references LAIXE ON DELETE CASCADE ON UPDATE CASCADE,
	foreign key(BienSoXe) references XE ON DELETE CASCADE ON UPDATE CASCADE,
	foreign key(MaTinhTrang) references TINHTRANG ON DELETE CASCADE ON UPDATE CASCADE,
	foreign key(MaNV) references NHANVIEN ON DELETE CASCADE ON UPDATE CASCADE,
)
-- Tạo bảng DAT
create table DAT
(
	MaHD varchar(10),
	MaKH varchar(10),
	MaNV varchar(10),
	KyHieuHD varchar(10),
	MauSoHD varchar(10),
	NgayDat date,
	NgayTra date,
	DonGia MONEY,
	TongTien MONEY,
	VAT int,
	primary key(MaHD),
	foreign key(MaKH) references KHACHHANG ON DELETE CASCADE ON UPDATE CASCADE,
	foreign key(MaNV) references NHANVIEN ON DELETE CASCADE ON UPDATE CASCADE
)
GO 
GO
-- Tạo bảng DAT_CHITIET
create table DAT_CHITIET
(
	MaHD varchar(10),
	MaDichVu varchar(10),
	DonVi varchar(10),
	SoLuong int,
	ThanhTien MONEY,
	primary key(MaHD),
	foreign key(MaDichVu) references DICHVU ON DELETE CASCADE ON UPDATE CASCADE,
	foreign key(MaHD) references DAT ON DELETE CASCADE ON UPDATE CASCADE
)
GO


-- Insert data
insert into LAIXE values('LX001', N'Nguyễn Quang Mạnh', '01638843209', N'K45/22 Hoàng Diệu, quận Hải Châu, Đà Nẵng')
insert into LAIXE values('LX002', N'Huỳnh Tấn Dũng', '0962883220', N'132 Hùng Vương, quận Hải Châu, Đà Nẵng')
insert into LAIXE values('LX003', N'Trần Ngọc Nhi', '0975208772', N'762 Tôn Đức Thắng, quận Hòa Khánh, Đà Nẵng')
insert into LAIXE values('LX004', N'Lê Minh Lộc', '01645500071', N'22 Hai Bà Trưng, phường Vĩnh Ninh, Huế')
insert into LAIXE values('LX005', N'Nguyễn Minh Tuấn', '0969590517', N'276 Huỳnh Thúc Kháng, Tam Kỳ, Quảng Nam')
insert into LAIXE values('LX006', N'Trần Huỳnh Đức', '0914163750', N'84 Ngô Quyền, quận Sơn Trà, Đà Nẵng')
insert into LAIXE values('LX007', N'Lê Thị Như', '0975423897', N'K12/23 Tôn Đản, quận Ngũ Hành Sơn, Đà Nẵng')
insert into LAIXE values('LX008', N'Trần Văn Khải', '0976308098', N'Thôn Thanh Quýt 1, Điện Bàn, Quảng Nam')
insert into LAIXE values('LX009', N'Nguyễn Huỳnh Quang', '0935637834', N'K38/16 Huỳnh Ngọc Huệ, quận Thanh Khê, Đà Nẵng')
insert into LAIXE values('LX010', N'Huỳnh Thị Mai', '0983154896', N'K45/2 Hoàng Diệu, quận Hải Châu, Đà Nẵng')

insert into DICHVU values('DV001', N'Dịch vụ xe 4 chỗ')
insert into DICHVU values('DV002', N'Dịch vụ xe 7 chỗ')
insert into DICHVU values('DV003', N'Dịch vụ xe 16 chỗ')
insert into DICHVU values('DV004', N'Dịch vụ xe 21 chỗ')

insert into KHACHHANG values ('KH001', N'Mai Văn Thuận', '0122423176', N'112 Nguyễn Thái Học, phường Phú Hội, Huế')
insert into KHACHHANG values ('KH002', N'Trần Đức Tuấn', '0126546238', N'90 Trần Phú, Hải Châu, Đà Nẵng')
insert into KHACHHANG values ('KH003', N'Phan Văn Nam', '0126103278', N'56 Châu Thị Vĩnh Tế, Ngũ Hành Sơn, Đà Nẵng')
insert into KHACHHANG values ('KH004', N'Nguyễn Ngọc Hoa', '0165231700', N'330 Nguyễn Tất Thành, Thanh Khê, Đà Nẵng')
insert into KHACHHANG values ('KH005', N'Hà Nguyễn Công Huy', '0932689103', N'11 Hà Huy Tập, phường Phú Hội, Huế')
insert into KHACHHANG values ('KH006', N'Huỳnh Thanh Tâm', '0165897001', N'03 Nguyễn Chí Thanh, Hải Châu, Đà Nẵng')
insert into KHACHHANG values ('KH007', N'Hoàng Ngọc Như', '0905136754', N'K05/12 Huỳnh Thúc Kháng, Tam Kỳ, Quảng Nam')
insert into KHACHHANG values ('KH008', N'Trần Nguyệt Mỹ', '0932689021', N'100 Tiểu La, Hải Châu, Đà Nẵng')
insert into KHACHHANG values ('KH009', N'Lê Minh Trí', '0905368136', N'16 Đường số 1, Điện Bàn, Quảng Nam')
insert into KHACHHANG values ('KH010', N'Phan Ngọc Quốc', '0983100365', N'489 Điện Biên Phủ, Thanh Khê, Đà Nẵng')
insert into KHACHHANG values ('KH011', N'Phan Quốc Minh', '0983100365', N'K05/78 Tiểu La, quận Hải Châu, Đà Nẵng')
insert into KHACHHANG values ('KH012', N'Nguyễn Thị Tâm', '0983100365', N'12 Châu Thị Vĩnh Tế, quận Ngũ Hành Sơn, Đà Nẵng')
insert into KHACHHANG values ('KH013', N'Hoàng Thị Thanh', '0983100365', N'K72/12 Nguyễn Sinh Sắc, quận Liên Chiểu, Đà Nẵng')
insert into KHACHHANG values ('KH014', N'Nguyễn Lê Minh Quân ', '0983100365', N'105 Yết Kiêu, quận Sơn Trà, Đà Nẵng')
insert into KHACHHANG values ('KH015', N'Mai Ngọc Thịnh', '0983100365', N'12 Hà Huy Tập, phường Phú Hội, Huế')
insert into KHACHHANG values ('KH016', N'Huỳnh Ngọc Lân', '0983100365', N'Thôn Thanh Quýt 2, Điện Bàn, Quảng Nam')
insert into KHACHHANG values ('KH017', N'Đào Lê Thục Uyên', '0983100365', N'40 Hà Huy Tập, quận Thanh Khê, Đà Nẵng')
insert into KHACHHANG values ('KH018', N'Trần Văn Quốc Khang', '0983100365', N'K12/11 Phan Thanh, quận Thanh Khê, Đà Nẵng')
insert into KHACHHANG values ('KH019', N'Thái Đức Tiến', '0983100365', N'K23/25 Huỳnh Thúc Kháng, Tam Kỳ, Quảng Nam')
insert into KHACHHANG values ('KH020', N'Nguyễn Ngọc Phương', '0983100365', N'452 Trưng Nữ Vương, quận Hải Châu, Đà Nẵng')

insert into NHANVIEN values ('NV001', N'Trần Trọng Nghĩa', '0905236789', N'114 Phan Tứ, quận Ngũ Hành Sơn, Đà Nẵng')
insert into NHANVIEN values ('NV002', N'Đoàn Nhật Thùy', '0905123756', N'12 Thái Phiên, quận Hải Châu, Đà Nẵng')
insert into NHANVIEN values ('NV003', N'Mai Thị Thảo Vy', '0983168752', N'20 Thái Thị Bôi, quận Thanh Khê, Đà Nẵng')
insert into NHANVIEN values ('NV004', N'Huỳnh Vân Quỳnh', '0983100365', N'17 Trần Cao Vân, quận Thanh Khê, Đà Nẵng')
insert into NHANVIEN values ('NV005', N'Nguyễn Bảo Tín', '0358126987', N'235 Hùng Vương, quận Hải Châu, Đà Nẵng')
insert into NHANVIEN values ('NV006', N'Đặng Phước Minh', '0358961200', N'175 Phan Bội Châu, phường Vĩnh Ninh, Huế')
insert into NHANVIEN values ('NV007', N'Trần Văn Phúc', '0975120365', N'114 Nguyễn Huệ, phường Vĩnh Ninh, Huế')
insert into NHANVIEN values ('NV008', N'Nguyễn Nhật Linh', '0966521368', N'11 Trần Nhân Tông, quận Sơn Trà, Đà Nẵng')
insert into NHANVIEN values ('NV009', N'Nguyễn Đình Nguyên', '0966325987', N'50 Yết Kiêu, quận Sơn Trà, Đà Nẵng')
insert into NHANVIEN values ('NV010', N'Lê Thị Uyên Thảo', '0975102358', N'12 Huỳnh Thúc Kháng, Tam Kỳ, Quảng Nam')

insert into XE values ('43A136.25', 4)
insert into XE values ('43A569.32', 7)
insert into XE values ('43A512.36', 16)
insert into XE values ('92A236.22', 4)
insert into XE values ('43A243.21', 7)
insert into XE values ('92A126.33', 4)
insert into XE values ('43B236.30', 16)
insert into XE values ('43A178.55', 7)
insert into XE values ('92B893.78', 16)
insert into XE values ('43A953.85', 4)

insert into TINHTRANG values ('TT001', '43A136.25', N'Nổ', N'Tắt', '10W', N'Đóng', '08:15')
insert into TINHTRANG values ('TT002', '43A569.32', N'Nổ', N'Bật', '12W', N'Đóng', '12:36')
insert into TINHTRANG values ('TT003', '43A512.36', N'Nổ', N'Bật', '18W', N'Mở', '19:20')
insert into TINHTRANG values ('TT004', '92A236.22', N'Tắt', N'Tắt', '10W', N'Đóng', '22:10')
insert into TINHTRANG values ('TT005', '43A243.21', N'Tắt', N'Tắt', '12W', N'Mở', '23:15')
insert into TINHTRANG values ('TT006', '92A126.33', N'Nổ', N'Tắt', '10W', N'Đóng', '18:05')
insert into TINHTRANG values ('TT007', '43B236.30', N'Nổ', N'Bật', '18W', N'Mở', '09:30')
insert into TINHTRANG values ('TT008', '43A178.55', N'Tắt', N'Tắt', '12W', N'Mở', '10:09')
insert into TINHTRANG values ('TT009', '92B893.78', N'Tắt', N'Tắt', '18W', N'Đóng', '12:00')
insert into TINHTRANG values ('TT010', '43A953.85', N'Tắt', N'Tắt', '10W', N'Đóng', '15:45')

insert into TAIKHOAN values ( 'Anh','123456',N'Nhân Viên')
insert into TAIKHOAN values ( 'Chau','67890',N'Nhân Viên')
insert into TAIKHOAN values ( 'Hoai','112233',N'Admin')
insert into TAIKHOAN values ( 'Truong','556677',N'Admin')

insert into QUANLY values ('NV001', 'QL001', 'LX001','43A136.25','TT001','2021/10/19','2021/10/20','40',N'Ngô Quyền,Mẫn Thái, Sơn Trà, Đà Nẵng') 
insert into QUANLY values ('NV002', 'QL002', 'LX002','43A569.32','TT002','2021/10/21','2021/10/25','40',N'Ngô Quyền, An Hải Bắc, Sơn Trà, Đà Nẵng') 
insert into QUANLY values ('NV003', 'QL003', 'LX003','43A512.36','TT003','2021/10/18','2021/10/20','37',N'Trần Phú, Hải Châu, Đà Nẵng') 
insert into QUANLY values ('NV004', 'QL004', 'LX006','92A126.33','TT006','2021/10/19','2021/10/21','41',N'Nguyễn Chí Thanh, Hải Châu, Đà Nẵng') 

insert into DAT values ('HD001', 'KH001', 'NV001', '10001', 'MS01', '2021/10/20', '2021/10/21', '4000000', '4400000','10')
insert into DAT values ('HD002', 'KH002', 'NV002', '10002', 'MS02', '2021/10/21', '2021/10/22', '7000000', '7700000','10')
insert into DAT values ('HD003', 'KH003', 'NV003', '10003', 'MS03', '2021/10/18', '2021/10/22', '16000000', '17600000','10')
insert into DAT values ('HD004', 'KH004', 'NV004', '10004', 'MS04', '2021/10/19', '2021/10/23', '4000000', '4400000','10')
insert into DAT values ('HD005', 'KH005', 'NV004', '10005', 'MS05', '2021/10/20', '2021/10/24', '4000000', '4400000','10')

insert into DAT_CHITIET values( 'HD001','DV001','VND','1','4000000')
insert into DAT_CHITIET values( 'HD002','DV002','VND','1','7000000')
insert into DAT_CHITIET values( 'HD003','DV003','VND','1','16000000')
insert into DAT_CHITIET values( 'HD004','DV001','VND','1','4000000')
insert into DAT_CHITIET values( 'HD005','DV001','VND','1','4000000')


--select * from KHACHHANG
--select * from LAIXE
--select * from DICHVU
--select * from NHANVIEN
--select * from XE
--select * from TINHTRANG
--select * from QUANLY
--select * from DAT
--select * from DAT_CHITIET
--select * from TAIKHOAN

GO
create trigger TinhTongTien_DAT on DAT
AFTER INSERT 
AS
	DECLARE @hd varchar(10) 
	SELECT @hd = MaHD from inserted
	BEGIN
		UPDATE DAT
		SET TongTien = DonGia + (DonGia*VAT/100)
		WHERE MaHD = @hd
END

GO
--Tạo index SCN thuộc bảng XE
CREATE INDEX idx_SCN on XE(SCN)


