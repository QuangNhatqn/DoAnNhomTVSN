CREATE DATABASE up
use up

CREATE DATABASE NEW
use NEW



CREATE TABLE BENHNHAN
(
	MaBN int IDENTITY not null,
	TenBN nvarchar(255),
	NgaySinh smalldatetime,
	DiaChi nvarchar(255),
	DienThoai varchar(20),
	GioiTinh nvarchar(10)
)
ALTER TABLE BENHNHAN ADD
CONSTRAINT BN_MaBN_PK PRIMARY KEY (MaBN)

CREATE TABLE PHIEUKHAM
(
	MaPK int IDENTITY not null,
	MaBS int,
	MaBN int,
	NgayKham smalldatetime,
	TrieuChung nvarchar(255),
	KetQua nvarchar(255)
)
ALTER TABLE PHIEUKHAM ADD
CONSTRAINT PK_MaPK_PK PRIMARY KEY (MaPK)



CREATE TABLE BACSI
(
	MaBS int IDENTITY not null,
	TenBS nvarchar(255),
	TenDangNhap varchar(255),
	MatKhau varchar(255)
)
ALTER TABLE BACSI ADD
CONSTRAINT BS_MaBS_PK PRIMARY KEY (MaBS)

CREATE TABLE HOADON
(
	MaHD int IDENTITY not null,
	MaPK int,
	TienKham money,
	TienThuoc money,
	TongTien money
)
ALTER TABLE HOADON ADD
CONSTRAINT HD_MaHD_PK PRIMARY KEY (MaHD)

ALTER TABLE HOADON ADD
CONSTRAINT HD_MaPK_FK FOREIGN KEY (MaPK) REFERENCES PHIEUKHAM(MaPK)

CREATE TABLE THUOC
( 
	MaThuoc int IDENTITY not null,
	TenThuoc nvarchar(255)not null,
	DonViTinh nvarchar(20),
	Gia money
)
ALTER TABLE THUOC ADD
CONSTRAINT TH_TenThuoc_PK PRIMARY KEY (MaThuoc)

CREATE TABLE CTTT
(
	MaPK int not null,
	MaThuoc int not null,
	TenThuoc nvarchar(255),
	SoLuong int,
	DonGia money,
	CachDung nvarchar(max)
)

ALTER TABLE CTTT ADD
CONSTRAINT CTTT_MaPK_TenThuoc_PK PRIMARY KEY (MaPK, MaThuoc)

ALTER TABLE PHIEUKHAM ADD
CONSTRAINT PK_MaBS_FK FOREIGN KEY (MaBS) REFERENCES BACSI(MaBS)

ALTER TABLE PHIEUKHAM ADD
CONSTRAINT PK_MaBN_FK FOREIGN KEY (MaBN) REFERENCES BENHNHAN(MaBN)

--ALTER TABLE CTTT ADD
--CONSTRAINT CTTT_MaPK_FK FOREIGN KEY (MaPK) REFERENCES PHIEUKHAM(MaPK)

--ALTER TABLE CTTT ADD
--CONSTRAINT CTTT_TenThuoc_FK FOREIGN KEY (MaThuoc) REFERENCES THUOC(MaThuoc)

ALTER TABLE CTTT ADD
CONSTRAINT FK_CTTT_PHIEUKHAM FOREIGN KEY (MaPK) REFERENCES PHIEUKHAM(MaPK)

ALTER TABLE CTTT ADD
CONSTRAINT FK_CTTT_THUOC FOREIGN KEY (MaThuoc) REFERENCES THUOC(MaThuoc)


SET DATEFORMAT DMY
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(N'H? Th? Thu Th?y',	'05/01/1997', N'100 L� Th??ng Ki?t, Ph??ng 14, Qu?n 10, H? Ch� Minh', '998623462', N'N?')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Nguy?n V?n Tr??ng', '1998-04-26',	N'212 L� Th??ng Ki?t, Ph??ng 14, Qu?n 10, H? Ch� Minh', '982123312', N'Nam')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Tr?n V?n A',	'01/01/1976',	N'33 L� Ch�nh Th?ng, Ph??ng 8, Qu?n 3, Tp H? Ch� Minh',	'1256387623',	N'Nam')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'V� V?n H?ng Nh?t', 	'1970-12-11',	N'T� V?nh Di?n, ?�ng Ho�, D? An, B�nh D??ng',	'1237646521',	N'Nam')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Nguy?n Th? Th??ng', 	'02/02/2012',	N'248 L� Ch�nh Th?ng, Ph??ng 9, Qu?n 3, H? Ch� Minh',	'983762318',	N'N?')	
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Nguy?n Th? H?ng T�',	'1988-01-14',	N'87 S? V?n H?nh, Ph??ng 10, Qu?n 10, H? Ch� Minh',	'1258730981',	N'N?')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Tr?n Qu?c Trung',	'1998-11-15',	N'T� V?nh Di?n, ?�ng Ho�, D? An, B�nh D??ng',	'9857821878',	N'Nam')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Nguy?n Th? Ki?u Oanh',	'03/02/1996',	N'Ba Th�ng Hai, Xu�n Kh�nh, Ninh Ki?u, C?n Th?',	'1237652817',	N'N?')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Nguy?n Th? Ng?c Th�y',	'07/02/1998',	N'L�nh T�, Xu�n L�nh, ??ng Xu�n, Ph� Y�n',	'1256384921',	N'N?')
INSERT INTO BENHNHAN (TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'V� Th? V�n',	'1999-11-15',	N'L�nh Tr??ng , Xu�n L�nh, ??ng Xu�n, Ph� Y�n',	'1256383924',	N'N?')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(N'Tr?n ?�nh S?',	'03/01/1990',	N'133/123C T� Hi?n Th�nh, Ph??ng 13, Qu?n 10, H? Ch� Minh',	'1256172111',	N'Nam')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Ng� M? Anh',	'05/04/2005',	N'Ph??ng C?u �ng L�nh, District 1, Ho Chi Minh City',	'9872019181',	N'N?')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Tr?n V�n',	'07/07/1995',	N'484 L� V?n Vi?t, T?ng Nh?n Ph� A, Qu?n 9, H? Ch� Minh',	'976287165',	N'N?')
INSERT INTO BENHNHAN ( TenBN, NgaySinh, DiaChi, DienThoai, GioiTinh)
VALUES(	N'Nguy?n Song Nguy�n',	'03/08/1992',	N'121 Nguy?n X�, ph??ng 26, B�nh Th?nh, H? Ch� Minh',	'1256172123',	N'Nam')

INSERT INTO BACSI ( TenBS, TenDangNhap, MatKhau)
VALUES(	N'Nguy?n Thi',	'nguyenthi',	'123')
INSERT INTO BACSI ( TenBS, TenDangNhap, MatKhau)
VALUES(	N'Tr?n V?n Kim',	'tranvankim',	'212')	
INSERT INTO BACSI ( TenBS, TenDangNhap, MatKhau)
VALUES(	N'Ng� B?o Kim',	'ngobaokim',	'126')
INSERT INTO BACSI ( TenBS, TenDangNhap, MatKhau)
VALUES(	N'V� Th?y',	'vothuy',	'324')
INSERT INTO BACSI ( TenBS, TenDangNhap, MatKhau)
VALUES(	N'T?ng Trinh',	'tongtrinh',	'541')

INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'1',	'1',	'01/01/2018',	N'D? ?ng theo m�a nh? h?t h?i, ch?y n??c m?i, ng?a h?ng ho?c ng?a, ch?y n??c m?t',	N'D?u hi?u b?t th??ng nh?.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES('3',	'5',	'01/02/2018',	N'Ch?y n??c m?t, ch?y n??c m?i, ng?a m?t/m?i, h?t h?i, ph�t ban v� ng?a',	N'D?u hi?u b?t th??ng trung b�nh.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'2',	'7',	'03/10/2018',	N'Vi�m ph? qu?n',	N'D?u hi?u b?t th??ng cao.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'5',	'2',	'03/11/2018',	N'T?ng huy?t �p.',	N'D?u hi?u b?t th??ng cao.')
INSERT INTO PHIEUKHAM (MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES('2',	'3',	'2018-03-15',	N'B?ng da', 	N'D?u hi?u b?t th??ng trung b�nh.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES('4',	'4',	'2018-03-22',	N'?au kh?p, s?ng v� c?ng kh?p,  vi�m kh?p',	 N'D?u hi?u b?t th??ng nh?.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'5',	'6',	'2018-03-24',	N'Cholesterol m�u cao.',	N'D?u hi?u b?t th??ng cao.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES('1',	'8',	'2018-03-25',	N'?au kh?p',	N'D?u hi?u b?t th??ng trung b�nh.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'3',	'9',	'04/01/2018',	N'Da n?i m?n ??.',	N'D?u hi?u b?t th??ng trung b�nh.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'4',	'10',	'04/05/2018',	N'T?n th??ng t?y s?ng',	N'D?u hi?u b?t th??ng trung b�nh.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'1',	'11',	'04/06/2018',	N'Nhi?m Vi Khu?n',	N'D?u hi?u b?t th??ng trung b�nh.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'3',	'12',	'04/07/2018',	N'M�u ?�ng c?c',	N'D?u hi?u b?t th??ng cao.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'2',	'13',	'04/08/2018',	N'Vi�m nang bu?ng tr?ng',	N'D?u hi?u b?t th??ng trung b�nh.')
INSERT INTO PHIEUKHAM ( MaBS, MaBN, NgayKham, TrieuChung, KetQua)
VALUES(	'5',	'14',	'04/10/2018',	N'Co th?t c? b?p',	 N'D?u hi?u b?t th??ng nh?.')



INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'1',	100000,	400000,	500000)
INSERT INTO HOADON (MaPK, TienKham, TienThuoc, TongTien)
VALUES('2',	100000,	100000,	200000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'3',	100000,	750000,	850000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'4',	100000,	1000000,	1100000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES('5',	100000,	300000,	400000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'6',	100000,	300000,	400000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'7',	100000,	1000000,	1100000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'8',	100000,	300000,	400000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'9',	100000,	1000000,	1100000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'10',	100000,	300000,	400000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'11',	100000,	500000,	600000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES('12',	100000,	2000000,	2100000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'13',	100000,	1000000,	1100000)
INSERT INTO HOADON ( MaPK, TienKham, TienThuoc, TongTien)
VALUES(	'14',	100000,	500000,	600000)

INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Telfast',	N'H?p',	200000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Fexofenadine',	N'H?p',	100000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Augmentin',	N'H?p', 	250000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('TENOFOVIR',	N'H?p', 	500000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Minoxidil',	N'H?p',	500000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES(N'B?c nitrat',	N'H?p',	300000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Feldene',	N'H?p',	300000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Fenofibrat',	N'H?p',	500000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Fenoprofen',	N'H?p',	300000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Dacarbazine',	N'H?p',	1000000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Dantrolene',	N'H?p',	300000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Daptomycin',	N'H?p',	500000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Heparin',	N'H?p',	2000000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Ganirelix',	N'H?p',	1000000)
INSERT INTO THUOC (TenThuoc, DonViTinh, Gia)
VALUES('Kaleorid',	N'H?p',	500000)

INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('1',	'1',	'2',	400000,	N'B?n c� th? d�ng thu?c fexofenadine b?ng c�ch u?ng k�m ho?c kh�ng k�m v?i th?c ?n. Khi d�ng thu?c fexofenadine, b?n n�n u?ng m?t ly n??c ??y v� kh�ng u?ng c�ng v?i n??c tr�i c�y v� c� th? l�m gi?m t�c d?ng c?a thu?c')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('2',	'2',	'1',	100000,	N'D�ng 30 mg cho tr? u?ng hai l?n m?t ng�y')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('3',	'3',	'3',	750000,	N'U?ng thu?c v?i m?t c?c n??c ??y. U?ng ? ??u b?a ?n ?? tr�nh g�y r?i lo?n ti�u h�a v� d�ng thu?c trong th?i ?i?m c? ??nh m?i ng�y v� nhai tr??c khi nu?t, kh�ng nu?t c? vi�n khi ch?a nhai.')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('4',	'4',	'2',	1000000,	N'Li?u l??ng ban ??u: u?ng 5 mg m?t l?n m?t ng�y; Li?u l??ng duy tr�: d�ng 10-40 mg, chia th�nh 1-2 li?u.')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('5',	N'5',	'1',	300000,	N'Thoa l�n c�c v?t b?ng  2-3 l?n m?t tu?n.')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('6',	'6',	'1',	300000,	N'D�ng 20 mg, u?ng m?t l?n m?i ng�y ho?c 10 mg, u?ng hai l?n m?i ng�y. Li?u t?i ?a h�ng ng�y l� 20 mg.')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('7',	'7',	'2',	1000000,	N'B?n u?ng 1 vi�n n�n 145 mg 1 l?n m?i ng�y. Nh?ng ng??i ?� s? d?ng vi�n nang fenofibrat 200 mg ho?c vi�n n�n 160 mg th?i gian g?n ?�y c� th? chuy?n sang u?ng vi�n n�n 145 mg m� kh�ng c?n hi?u ch?nh li?u.')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('8',	'8',	'1',	300000,	N'D�ng thu?c n�y b?ng ???ng u?ng v?i m?t ly n??c ??y (240 ml), tr? khi b�c s? c?a b?n c� ch? d?n kh�c. ??ng n?m xu?ng trong �t nh?t 10 ph�t sau khi u?ng thu?c n�y. N?u b?n b? kh� ch?u ? d? d�y trong khi d�ng thu?c n�y, h�y u?ng thu?c v?i th?c ph?m, s?a, ho?c thu?c kh�ng axit')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('9',	'9',	'1',	1000000,	N'Ti�m t?nh m?ch 2-4,5 mg/kg m?i ng�y m?t l?n trong 10 ng�y, l?p l?i m?i 4 tu?n ho?c ti�m t?nh m?ch 250 mg/m²  m?t l?n m?i ng�y trong 5 ng�y, l?p l?i m?i 3 tu?n.')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('10', '10',	'1',	300000,	N'Ti�m truy?n t?nh m?ch: 2,5 mg/kg, b?t ??u kho?ng 75 ph�t tr??c khi g�y m� v� truy?n t?nh m?ch trong kho?ng 1 gi?. U?ng: 4-8 mg/kg/ng�y u?ng chia th�nh ba ho?c b?n li?u trong 1 ho?c 2 ng�y tr??c khi ph?u thu?t, li?u cu?i c�ng u?ng v?i l??ng n??c t?i thi?u kho?ng 3-4 gi? tr??c khi ph?u thu?t.')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('11',	'11',	'1',	500000,	N'Ti�m t?nh m?ch 6 mg/kg m?i 24 ti?ng trong 2 ??n 6 tu?n.')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('12',	'12',	'1',	2000000,	N'??i v?i d?ng thu?c truy?n t?nh m?ch, b?n d�ng kho?ng 5000 ??n v? m?t l?n, ti?p theo truy?n t?nh m?ch li�n t?c 1300 ??n v?/gi?. Ngo�i ra, b?n c� th? ti�m t?nh m?ch m?t li?u 80 ??n v? m?t l?n. Sau ?�, b?n c� th? c?n ti�m truy?n t?nh m?ch li�n t?c 18 ??n v?/kg/gi?')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('13',	'13',	'1',	1000000,	N'25 mg ti�m d??i da 1 l?n/ng�y. Ganirelix ???c d�ng thu?n ti?n nh?t ? v�ng b?ng quanh r?n ho?c ?�i tr�n. Th�ng th??ng, nang hormone k�ch th�ch (FSH) ngo?i sinh ???c ti�m trong ng�y kinh th? 2 ho?c 3. Ganirelix ???c b?t ??u ti�m v�o ng�y 7 ho?c 8 (ng�y th? 6 trong ?i?u tr? FSH). Tr? li?u Ganirelix ???c ti?p t?c cho ??n khi nang tr??ng th�nh ??y ??, th?i ?i?m ?� s? b?t ??u ti�m hCG')
INSERT INTO CTTT (MaPK, MaThuoc, SoLuong, DonGia, CachDung)
VALUES('14',	'14',	'1',	500000,	N'U?ng c? vi�n thu?c v?i 1 ly n??c ??y.')




--alter table PHIEUKHAM  drop PK_MaBS_FK
--alter table PHIEUKHAM  drop PK_MaBN_FK
--alter table HOADON  drop HD_MaPK_FK
--alter table CTTT  drop CTTT_MaPK_FK
--alter table CTTT  drop CTTT_TenThuoc_FK
--alter table BENHNHAN DROP BN_MaBN_PK
--ALTER TABLE PHIEUKHAM DROP PK_MaPK_PK
--ALTER TABLE BACSI DROP BS_MaBS_PK
--ALTER TABLE HOADON DROP HD_MaHD_PK
--ALTER TABLE THUOC DROP TH_TenThuoc_PK
--ALTER TABLE CTTT DROP CTTT_MaPK_TenThuoc_PK
 

--select * from BACSI
--select * from BENHNHAN
--select * from CTTT
--select * from HOADON
--select * from PHIEUKHAM
--select * from THUOC

--delete BACSI
--delete BENHNHAN 
--delete CTTT
--delete HOADON
--delete PHIEUKHAM
--delete THUOC


--drop table BACSI
--drop table BENHNHAN
--drop table CTTT
--drop table HOADON
--drop table PHIEUKHAM
--drop table THUOC

--USE QLKB
--GO
--CREATE PROC USP_layThongTinBenhNhan
--AS
--SELECT * FROM DBO.BENHNHAN
--GO

--EXEC DBO.USP_layThongTinBenhNhan


--use NEW
--go

--CREATE PROC USP_INSERT_BenhNhan2
--(
--    @MABN INT OUTPUT,
--	@TEN nvarchar(255),
--	@NgaySinh varchar(30),
--	@DiaChi nvarchar(255),
--	@DienThoai varchar(20),
--	@GioiTinh nvarchar(10)
--)
--AS
--insert into BENHNHAN (TenBN, [NgaySinh],[DiaChi], DienThoai,[GioiTinh])
--values (@TEN, @NgaySinh, @DiaChi, @DienThoai, @GioiTinh)
--set @MABN = SCOPE_IDENTITY()

CREATE PROC USP_DANGNHAP
@TenDangNhap nvarchar(100), @MatKhau nvarchar(100)
AS
BEGIN
	SELECT * FROM BACSI WHERE TenDangNhap = @TenDangNhap and MatKhau = @MatKhau
END
GO


CREATE PROC USP_ChinhSuaThongTinBACSI
@MaBS char(5), @HoTen nvarchar(255), @TenDangNhap nvarchar(255) , @MatKhau nvarchar(255), @MKMoi nvarchar(255)
as
BEGIN
	DECLARE   @DungMatKhau int = 0
		select @DungMatKhau = count(*) from BACSI where MaBS = @MaBS and MatKhau = @MatKhau
	if(@DungMatKhau = 1)
	BEGIN
		if(@MKMoi = NULL OR @MKMoi = '')
		BEGIN
			UPDATE BACSI SET TenDangNhap = @TenDangNhap WHERE MaBS = @MaBS
		END
		ELSE
			UPDATE BACSI SET TenBS = @HoTen, TenDangNhap = @TenDangNhap, MatKhau = @MKMoi WHERE MaBS = @MaBS
	END
END

