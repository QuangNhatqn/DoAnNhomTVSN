
CREATE DATABASE QLKB
use QLKB

CREATE TABLE BENHNHAN
(
	MaBN int IDENTITY(1,1) not null,
	TenBN nvarchar(40),
	NgaySinh smalldatetime,
	DiaChi nvarchar(80),
	DienThoai varchar(20),
	GioiTinh nvarchar(20),
	TrangThai int
)
ALTER TABLE BENHNHAN ADD
CONSTRAINT BN_MaBN_PK PRIMARY KEY (MaBN)

CREATE TABLE NHANVIEN
(
	MaNV int IDENTITY(1,1)not null,
	TenNV nvarchar(40),
	TenDangNhap varchar(40),
	MatKhau varchar(40),
	LoaiNV int,
	TrangThai int
)
ALTER TABLE NHANVIEN ADD
CONSTRAINT NV_MaNV_PK PRIMARY KEY (MaNV)

CREATE TABLE PHIEUKHAM
(
	MaPK int IDENTITY(1,1) not null,
	MaNV int,
	MaBN int,
	NgayKham smalldatetime,
	TrieuChung nvarchar(80),
	KetQua nvarchar(80),
	TrangThai int
)
ALTER TABLE PHIEUKHAM ADD
CONSTRAINT PK_MaPK_PK PRIMARY KEY (MaPK),
CONSTRAINT PK_MaNV_FK FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
CONSTRAINT PK_MaBN_FK FOREIGN KEY (MaBN) REFERENCES BENHNHAN(MaBN)

CREATE TABLE HOADON
(
	MaHD int IDENTITY(1,1)not null,
	MaPK int,
	TienKham money,
	TienThuoc money,
	TongTien money,
	TrangThai int
)
ALTER TABLE HOADON ADD
CONSTRAINT HD_MaHD_PK PRIMARY KEY (MaHD),
CONSTRAINT HD_MaPK_FK FOREIGN KEY (MaPK) REFERENCES PHIEUKHAM(MaPK)

CREATE TABLE THUOC
(
	TenThuoc nvarchar(40)not null,
	DonViTinh nvarchar(20),
	Gia money,
	TrangThai int
)
ALTER TABLE THUOC ADD
CONSTRAINT TH_TenThuoc_PK PRIMARY KEY (TenThuoc)

CREATE TABLE CTTT
(
	MaPK int not null,
	TenThuoc nvarchar(40)not null,
	SoLuong int,
	DonGia money,
	CachDung nvarchar(max),
	TrangThai int
)
ALTER TABLE CTTT ADD
CONSTRAINT CTTT_MaPK_TenThuoc_PK PRIMARY KEY (MaPK, TenThuoc),
CONSTRAINT CTTT_MaPK_FK FOREIGN KEY (MaPK) REFERENCES PHIEUKHAM(MaPK),
CONSTRAINT CTTT_TenThuoc_FK FOREIGN KEY (TenThuoc) REFERENCES THUOC(TenThuoc)

CREATE TABLE QUIDINH
(
	TienKham money
)

SET DATEFORMAT DMY
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Hồ Thị Thu Thủy',	'05/01/1997', N'100 Lý Thường Kiệt, Phường 14, Quận 10, Hồ Chí Minh', '998623462', N'Nữ', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Nguyễn Văn Trường', '26/4/1998',	N'212 Lý Thường Kiệt, Phường 14, Quận 10, Hồ Chí Minh', '982123312', N'Nam', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Trần Văn A',	'01/01/1976',	N'33 Lý Chính Thắng, Phường 8, Quận 3, Tp Hồ Chí Minh',	'1256387623',	N'Nam', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Võ Văn Hồng Nhật', 	'11/12/1970',	N'Tô Vĩnh Diện, Đông Hoà, Dĩ An, Bình Dương',	'1237646521',	N'Nam', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Nguyễn Thị Thương', 	'02/02/2012',	N'248 Lý Chính Thắng, Phường 9, Quận 3, Hồ Chí Minh',	'983762318',	N'Nữ', '1')	
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Nguyễn Thị Hồng Tú',	'14/1/1988',	N'87 Sư Vạn Hạnh, Phường 10, Quận 10, Hồ Chí Minh',	'1258730981',	N'Nữ', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Trần Quốc Trung',	'15/11/1998',	N'Tô Vĩnh Diện, Đông Hoà, Dĩ An, Bình Dương',	'9857821878',	N'Nam', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Nguyễn Thị Kiều Oanh',	'03/02/1996',	N'Ba Tháng Hai, Xuân Khánh, Ninh Kiều, Cần Thơ',	'1237652817',	N'Nữ', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Nguyễn Thị Ngọc Thùy',	'07/02/1998',	N'Lãnh Tú, Xuân Lãnh, Đồng Xuân, Phú Yên',	'1256384921',	N'Nữ', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Võ Thị Vân',	'15/11/1999',	N'Lãnh Trường , Xuân Lãnh, Đồng Xuân, Phú Yên',	'1256383924',	N'Nữ', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Trần Đình Sỹ',	'03/01/1990',	N'133/123C Tô Hiến Thành, Phường 13, Quận 10, Hồ Chí Minh',	'1256172111',	N'Nam', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Ngô Mỹ Anh',	'05/04/2005',	N'Phường Cầu Ông Lãnh, District 1, Ho Chi Minh City',	'9872019181',	N'Nữ', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Trần Vân',	'07/07/1995',	N'484 Lê Văn Việt, Tăng Nhơn Phú A, Quận 9, Hồ Chí Minh',	'976287165',	N'Nữ', '1')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh, TrangThai)
VALUES(N'Nguyễn Song Nguyên',	'03/08/1992',	N'121 Nguyễn Xí, phường 26, Bình Thạnh, Hồ Chí Minh',	'1256172123',	N'Nam', '1')

INSERT INTO NHANVIEN (TenNV, TenDangNhap, MatKhau, LoaiNV, TrangThai)
VALUES(N'Nguyễn Thi',	'admin',	'123', '1', '1')
INSERT INTO NHANVIEN (TenNV, TenDangNhap, MatKhau, LoaiNV, TrangThai)
VALUES(N'Trần Văn Kim',	'tranvankim',	'212', '2', '1')	
INSERT INTO NHANVIEN (TenNV, TenDangNhap, MatKhau, LoaiNV, TrangThai)
VALUES(N'Ngô Bảo Kim',	'ngobaokim',	'126', '2', '1')
INSERT INTO NHANVIEN (TenNV, TenDangNhap, MatKhau, LoaiNV, TrangThai)
VALUES(N'Võ Thụy',	'vothuy',	'324', '2', '1')
INSERT INTO NHANVIEN (TenNV, TenDangNhap, MatKhau, LoaiNV, TrangThai)
VALUES(N'Tống Trinh',	'tongtrinh',	'541', '2', '1')

INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('1',	'1',	'01/01/2018',	N'Dị ứng theo mùa như hắt hơi, chảy nước mũi, ngứa họng hoặc ngứa, chảy nước mắt',	N'Viêm Xoan.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('3',	'5',	'01/02/2018',	N'Chảy nước mắt, chảy nước mũi, ngứa mắt/mũi, hắt hơi, phát ban và ngứa',	N'Dấu hiệu bất thường trung bình.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('2',	'7',	'03/02/2018',	N'Ho, hắt hơi thường xuyên',	N'Viêm phế quản.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('5',	'2',	'03/03/2018',	N'Chống mặt, nhức đầu thường xuyên.',	N'Huyết áp cao.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('1',	'1',	'07/03/2018',	N'Dị ứng theo mùa như hắt hơi, chảy nước mũi, ngứa họng hoặc ngứa, chảy nước mắt',	N'Viêm Xoan.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('2',	'3',	'15/3/2018',	N'Bỏng da', 	N'Viêm da.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('4',	'4',	'22/3/2018',	N'Đau khớp, sưng và cứng khớp,  viêm khớp',	 N'Thiếu canxi.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('5',	'6',	'24/3/2018',	N'Nhói tim.',	N'Cholesterol trong máu cao vì ăn quá nhiều đồ ăn dầu mỡ.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('1',	'8',	'25/3/2018',	N'Đau khớp',	N'Sụn khớp và thiếu canxi trầm trọng.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('3',	'9',	'04/01/2018',	N'Da nổi mẩn đỏ.',	N'Thủy đậu.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('4',	'10',	'04/03/2018',	N'Đau vùng gối thường xuyên',	N'Tổn thương tủy sống.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('1',	'11',	'04/04/2018',	N'Sưng và đau nhức ở cánh tay.', N'Vết thương bị nhiềm trùng.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('3',	'12',	'04/05/2018',	N'Vết thương không ngừng chảy máu',	N'Máu khó đông.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('2',	'13',	'08/05/2018',	N'Không thụ thai trong 4 năm',	N'Viêm nang buồng trứng.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('5',	'14',	'09/05/2018',	N'Đau nhói vùng sau gáy',	 N'Co thắt cơ.', '1')
INSERT INTO PHIEUKHAM (MaNV, MaBN, NgayKham, TrieuChung, KetQua, TrangThai)
VALUES('5',	'1',	'09/05/2018',	N'Dị ứng theo mùa như hắt hơi, chảy nước mũi, ngứa họng hoặc ngứa, chảy nước mắt.',	 N'Viêm Xoan.', '1')



INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('1',	100000,	400000,	500000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('2',	100000,	100000,	200000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('3',	100000,	750000,	850000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('4',	100000,	1000000,	1100000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('5',	100000,	150000,	250000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('6',	100000,	300000,	400000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('7',	100000,	300000,	400000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('8',	100000,	1000000,	1100000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('9',	100000,	300000,	400000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('10',	100000,	1000000,	1100000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('11',	100000,	300000,	400000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('12',	100000,	500000,	600000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('13',	100000,	2000000,	2100000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('14',	100000,	1000000,	1100000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('15',	100000,	500000,	600000, '1')
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien, TrangThai)
VALUES('16',	100000,	500000,	600000, '1')


INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Telfast',	N'Hộp',	200000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Fexofenadine',	N'Hộp',	100000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Augmentin',	N'Hộp', 	250000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('TENOFOVIR',	N'Hộp', 	500000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Minoxidil',	N'Hộp',	500000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES(N'Bạc nitrat',	N'Hộp',	300000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Feldene',	N'Hộp',	300000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Fenofibrat',	N'Hộp',	500000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Fenoprofen',	N'Hộp',	300000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Dacarbazine',	N'Hộp',	1000000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Dantrolene',	N'Hộp',	300000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Daptomycin',	N'Hộp',	500000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Heparin',	N'Hộp',	2000000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Ganirelix',	N'Hộp',	1000000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Kaleorid',	N'Hộp',	500000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Panadol',	N'Hộp',	500000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Migrin',	N'Hộp',	150000, '1')
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia, TrangThai)
VALUES('Methylen',	N'Chai',150000, '1')


INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('1',	'Telfast',	'2',	400000,	N'Bạn có thể dùng thuốc fexofenadine bằng cách uống kèm hoặc không kèm với thức ăn. Khi dùng thuốc fexofenadine, bạn nên uống một ly nước đầy và không uống cùng với nước trái cây vì có thể làm giảm tác dụng của thuốc', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('2',	'Fexofenadine',	'1',	100000,	N'Dùng 30 mg cho trẻ uống hai lần một ngày', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('3',	'Augmentin',	'3',	750000,	N'Uống thuốc với một cốc nước đầy. Uống ở đầu bữa ăn để tránh gây rối loạn tiêu hóa và dùng thuốc trong thời điểm cố định mỗi ngày và nhai trước khi nuốt, không nuốt cả viên khi chưa nhai.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('4',	'Minoxidil',	'2',	1000000,	N'Liều lượng ban đầu: uống 5 mg một lần một ngày; Liều lượng duy trì: dùng 10-40 mg, chia thành 1-2 liều.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('5',	N'Migrin',	'1',	150000,	N'Uống 2-3 lần một ngày sau bữa ăn.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('6',	N'Bạc nitrat',	'1',	300000,	N'Thoa lên các vết bỏng  2-3 lần một tuần.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('7',	'Feldene',	'1',	300000,	N'Dùng 20 mg, uống một lần mỗi ngày hoặc 10 mg, uống hai lần mỗi ngày. Liều tối đa hàng ngày là 20 mg.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('8',	'Fenofibrat',	'2',	1000000,	N'Bạn uống 1 viên nén 145 mg 1 lần mỗi ngày. Những người đã sử dụng viên nang fenofibrat 200 mg hoặc viên nén 160 mg thời gian gần đây có thể chuyển sang uống viên nén 145 mg mà không cần hiệu chỉnh liều.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('9',	'Fenoprofen',	'1',	300000,	N'Dùng thuốc này bằng đường uống với một ly nước đầy (240 ml), trừ khi bác sĩ của bạn có chỉ dẫn khác. Đừng nằm xuống trong ít nhất 10 phút sau khi uống thuốc này. Nếu bạn bị khó chịu ở dạ dày trong khi dùng thuốc này, hãy uống thuốc với thực phẩm, sữa, hoặc thuốc kháng axit', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('10',	'Dacarbazine',	'1',	1000000,	N'Tiêm tĩnh mạch 2-4,5 mg/kg mỗi ngày một lần trong 10 ngày, lặp lại mỗi 4 tuần hoặc tiêm tĩnh mạch 250 mg/mÂ²  một lần mỗi ngày trong 5 ngày, lặp lại mỗi 3 tuần.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('11', 'Dantrolene',	'1',	300000,	N'Tiêm truyền tĩnh mạch: 2,5 mg/kg, bắt đầu khoảng 75 phút trước khi gây mê và truyền tĩnh mạch trong khoảng 1 giờ. Uống: 4-8 mg/kg/ngày uống chia thành ba hoặc bốn liều trong 1 hoặc 2 ngày trước khi phẫu thuật, liều cuối cùng uống với lượng nước tối thiểu khoảng 3-4 giờ trước khi phẫu thuật.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('12',	'Daptomycin',	'1',	500000,	N'Tiêm tĩnh mạch 6 mg/kg mỗi 24 tiếng trong 2 đến 6 tuần.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('13',	'Heparin',	'1',	2000000,	N'Đối với dạng thuốc truyền tĩnh mạch, bạn dùng khoảng 5000 đơn vị một lần, tiếp theo truyền tĩnh mạch liên tục 1300 đơn vị/giờ. Ngoài ra, bạn có thể tiêm tĩnh mạch một liều 80 đơn vị một lần. Sau đó, bạn có thể cần tiêm truyền tĩnh mạch liên tục 18 đơn vị/kg/giờ', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('14',	'Ganirelix',	'1',	1000000,	N'25 mg tiêm dưới da 1 lần/ngày. Ganirelix được dùng thuận tiện nhất ở vùng bụng quanh rốn hoặc đùi trên. Thông thường, nang hormone kích thích (FSH) ngoại sinh được tiêm trong ngày kinh thứ 2 hoặc 3. Ganirelix được bắt đầu tiêm vào ngày 7 hoặc 8 (ngày thứ 6 trong điều trị FSH). Trị liệu Ganirelix được tiếp tục cho đến khi nang trưởng thành đầy đủ, thời điểm đó sẽ bắt đầu tiêm hCG', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)
VALUES('15',	'Kaleorid',	'1',	500000,	N'Uống cả viên thuốc với 1 ly nước đầy.', '1')
INSERT INTO CTTT (MaPK, TenThuoc, SoLuong, DonGia, CachDung, TrangThai)	
VALUES('16',	'Panadol',	'1',	500000,	N'Uống ba bữa trong ngày và sau khi ăn.', '1')

INSERT INTO QUIDINH (TienKham)
VALUES (100000)

--select * from NHANVIEN
--select * from BENHNHAN
--select * from CTTT
--select * from HOADON
--select * from PHIEUKHAM
--select * from THUOC

--delete NHANVIEN
--delete BENHNHAN 
--delete CTTT
--delete HOADON
--delete PHIEUKHAM
--delete THUOC


--drop table NHANVIEN
--drop table BENHNHAN
--drop table CTTT
--drop table HOADON
--drop table PHIEUKHAM
--drop table THUOC

--------------------------------------------------------------------------------------------------------------------------------



CREATE PROC USP_DieuKienDangNhap
@TenDangNhap nvarchar(100), @MatKhau nvarchar(100)
As
BEGIN
   
	SELECT * FROM NHANVIEN WHERE (TenDangNhap = @TenDangNhap and MatKhau = @MatKhau) and (TrangThai = '1' and LoaiNV != 4)
	
END
--------------------------------------------------------------------------------------------------------------------------

CREATE PROC USP_CapNhatThongTinNhanVien
@MaNV int, @HoTen nvarchar(255), @TenDangNhap nvarchar(255) , @MatKhau nvarchar(255), @MKMoi nvarchar(255)
as
BEGIN
	DECLARE   @DungMatKhau int = 0
		select @DungMatKhau = count(*) from NHANVIEN where MaNV = @MaNV and MatKhau = @MatKhau
	if(@DungMatKhau = 1)
	BEGIN
		if(@MKMoi = NULL OR @MKMoi = '')
		BEGIN
			UPDATE NHANVIEN SET TenDangNhap = @TenDangNhap WHERE MaNV = @MaNV
		END
		ELSE
			UPDATE NHANVIEN SET TenNV = @HoTen, TenDangNhap = @TenDangNhap, MatKhau = @MKMoi WHERE MaNV = @MaNV
	END
END

