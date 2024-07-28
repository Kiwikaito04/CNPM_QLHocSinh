use master
if exists (select * from sysdatabases where name = 'CNPM_QLHocSinh')
	drop database CNPM_QLHocSinh
go
create database CNPM_QLHocSinh
go
use CNPM_QLHocSinh
go

create table KhoiLop(
	MaKL char(2) primary key,
	TenKL nvarchar(20) not null,
	MoTa nvarchar(100),
	CapBac integer not null
)
insert into KhoiLop
values	('K1',N'Khối 1', null, 1),
		('K2',N'Khối 2', null, 2),
		('K3', N'Khối 3', null, 3),
		('K4', N'Khối 4', null, 4),
		('K5', N'Khối 5', null, 5)

create table LopHoc(
	MaLop char(2) primary key,
	TenLop nvarchar(20) not null,
	MoTa nvarchar(100),
	MaKL char(2) foreign key references KhoiLop(MaKL)
)
insert into LopHoc
values	('01',N'1A1', null, 'K1'),
		('02',N'1A2', null, 'K1'),
		('03',N'1A3', null, 'K1'),
		('04',N'2A1', null, 'K2'),
		('05',N'2A2', null, 'K2')
-- Thêm lớp học cho khối 3 (K3)
insert into LopHoc (MaLop, TenLop, MoTa, MaKL)
values	('06', N'3A1', null, 'K3'),
		('07', N'3A2', null, 'K3'),
		('08', N'3A3', null, 'K3'),
		('09', N'3A4', null, 'K3'),
		('10', N'3A5', null, 'K3'),
		('11', N'3A6', null, 'K3'),
		('12', N'3A7', null, 'K3'),
		('13', N'3A8', null, 'K3'),
		('14', N'3A9', null, 'K3'),
		('15', N'3A10', null, 'K3');

-- Thêm lớp học cho khối 4 (K4)
insert into LopHoc (MaLop, TenLop, MoTa, MaKL)
values	('16', N'4A1', null, 'K4'),
		('17', N'4A2', null, 'K4'),
		('18', N'4A3', null, 'K4'),
		('19', N'4A4', null, 'K4'),
		('20', N'4A5', null, 'K4'),
		('21', N'4A6', null, 'K4'),
		('22', N'4A7', null, 'K4'),
		('23', N'4A8', null, 'K4'),
		('24', N'4A9', null, 'K4'),
		('25', N'4A10', null, 'K4');

-- Thêm lớp học cho khối 5 (K5)
insert into LopHoc (MaLop, TenLop, MoTa, MaKL)
values	('26', N'5A1', null, 'K5'),
		('27', N'5A2', null, 'K5'),
		('28', N'5A3', null, 'K5'),
		('29', N'5A4', null, 'K5'),
		('30', N'5A5', null, 'K5'),
		('31', N'5A6', null, 'K5'),
		('32', N'5A7', null, 'K5'),
		('33', N'5A8', null, 'K5'),
		('34', N'5A9', null, 'K5'),
		('35', N'5A10', null, 'K5');

create table TrangThaiHS(
	MaTT char(2) primary key,
	TenTT nvarchar(20) not null,
	MoTa nvarchar(100)
)
insert into TrangThaiHS
values	('CH',N'Còn học', null),
		('LL',N'Lên lớp', null),
		('BL',N'Bảo lưu', null),
		('OL',N'Ở lại lớp', null),
		('TN',N'Tốt nghiệp', null),
		('TS',N'Học sinh mới', null)

create table HocSinh(
	MaHS char(10) primary key,
	HoTen nvarchar(20) not null,
	GioiTinh bit not null,
	NgaySinh date not null,
	DiaChi nvarchar(50) not null,
	Email nvarchar(30),
	SDT char(10),
	MaTT char(2) foreign key references TrangThaiHS(MaTT),
	MaLop char(2) foreign key references LopHoc(MaLop),
	Pass nvarchar(20) not null
)
insert into HocSinh
values	('HS00000001',N'Phạm Văn A', 1, '20110122', N'123 ABC', null, null, 'TS', null, 'abc'),
		('HS00000002',N'Nguyễn Văn B', 1, '20110102', N'123 ABC', null, null, 'TS', null, 'abc'),
		('HS00000003',N'Đào Thị C', 0, '20101102', N'123 ABC', null, null, 'TS', null, 'abc')
-- Thêm học sinh 1 đến 10
insert into HocSinh (MaHS, HoTen, GioiTinh, NgaySinh, DiaChi, Email, SDT, MaTT, MaLop, Pass)
values
    ('HS00000004', N'Trần Thị D', 0, '20101212', N'456 XYZ', 'trand@example.com', '1234567890', 'TS', null, 'abc'),
    ('HS00000005', N'Lê Văn E', 1, '20110305', N'789 PQR', 'levane@example.com', '0987654321', 'TS', null, 'abc'),
    ('HS00000006', N'Hoàng Văn F', 1, '20100515', N'567 UVW', 'hoangvanf@example.com', '9876543210', 'TS', null, 'abc'),
    ('HS00000007', N'Mai Thị G', 0, '20110228', N'234 EFG', 'maithig@example.com', '8765432109', 'TS', null, 'abc'),
    ('HS00000008', N'Vũ Văn H', 1, '20101010', N'890 HIJ', 'vuvanh@example.com', '7654321098', 'TS', null, 'abc'),
    ('HS00000009', N'Ngô Thị I', 0, '20100707', N'123 JKL', 'ngothii@example.com', '6543210987', 'TS', null, 'abc'),
    ('HS00000010', N'Đặng Văn K', 1, '20110420', N'456 MNO', 'dangvank@example.com', '5432109876', 'TS', null, 'abc'),
    ('HS00000011', N'Lương Thị L', 0, '20100808', N'789 PQR', 'luongthil@example.com', '4321098765', 'TS', null, 'abc'),
    ('HS00000012', N'Phan Văn M', 1, '20100909', N'567 STU', 'phanvanm@example.com', '3210987654', 'TS', null, 'abc'),
    ('HS00000013', N'Đỗ Thị N', 0, '20101225', N'890 VWX', 'dothin@example.com', '2109876543', 'TS', null, 'abc');

-- Thêm học sinh 11 đến 20
insert into HocSinh (MaHS, HoTen, GioiTinh, NgaySinh, DiaChi, Email, SDT, MaTT, MaLop, Pass)
values
    ('HS00000014', N'Bùi Văn O', 1, '20110501', N'123 YZA', 'buivano@example.com', '1098765432', 'TS', null, 'abc'),
    ('HS00000015', N'Chu Thị P', 0, '20101111', N'456 BCD', 'chuthip@example.com', '0987654321', 'TS', null, 'abc'),
    ('HS00000016', N'Lý Văn Q', 1, '20100606', N'789 CDE', 'lyvanq@example.com', '9876543210', 'TS', null, 'abc'),
    ('HS00000017', N'Hoàng Thị R', 0, '20110315', N'567 DEF', 'hoangthir@example.com', '8765432109', 'TS', null, 'abc'),
    ('HS00000018', N'Nguyễn Văn S', 1, '20100220', N'890 EFG', 'nguyenvans@example.com', '7654321098', 'TS', null, 'abc'),
    ('HS00000019', N'Trần Thị T', 0, '20110101', N'123 GHI', 'trant@example.com', '6543210987', 'TS', null, 'abc'),
    ('HS00000020', N'Phạm Văn U', 1, '20100909', N'456 HIJ', 'phamvanu@example.com', '5432109876', 'TS', null, 'abc'),
    ('HS00000021', N'Đỗ Thị V', 0, '20100808', N'789 JKL', 'dothiv@example.com', '4321098765', 'TS', null, 'abc'),
    ('HS00000022', N'Nguyễn Văn X', 1, '20100707', N'567 MNO', 'nguyenvanx@example.com', '3210987654', 'TS', null, 'abc'),
    ('HS00000023', N'Trần Thị Y', 0, '20101225', N'890 PQR', 'tranthiy@example.com', '2109876543', 'TS', null, 'abc');

create table ChucVu(
	MaCV char(2) primary key,
	TenCV nvarchar(20) not null,
	MoTa nvarchar(100)
)
insert into ChucVu
values	('HS', N'Quản lý học sinh', null),
		('NS', N'Quản lý nhân sự', null),
		('DD', N'Đào tạo', null),
		('GV', N'Giáo viên', null)

create table GiaoVien(
	MaGV char(3) primary key,
	HoTen nvarchar(20) not null,
	GioiTinh bit not null,
	NgaySinh date not null,
	DiaChi nvarchar(50) not null,
	Email nvarchar(30),
	SDT char(10),
	MaCV char(2) foreign key references ChucVu(MaCV),
	Pass nvarchar(20) not null
)
insert into GiaoVien
values	('001',N'Quỳnh Thị A', 1, '20110122', N'123 ABC', null, null, 'GV', 'abc'),
		('002',N'Quỳnh Thị B', 1, '20110121', N'123 ABC', null, null, 'DD', 'abc'),
		('003',N'Quỳnh Thị A', 1, '20110120', N'123 ABC', null, null, 'NS', 'abc')
-- Thêm giáo viên 1 đến 10
insert into GiaoVien (MaGV, HoTen, GioiTinh, NgaySinh, DiaChi, Email, SDT, MaCV, Pass)
values
    ('004', N'Nguyễn Văn C', 1, '19891205', N'456 XYZ', 'nguyenvanc@example.com', '1234567890', 'GV', 'abc'),
    ('005', N'Trần Thị D', 0, '19901115', N'789 PQR', 'trand@example.com', '0987654321', 'DD', 'abc'),
    ('006', N'Lê Văn E', 1, '19880325', N'567 UVW', 'levane@example.com', '9876543210', 'NS', 'abc'),
    ('007', N'Hoàng Văn F', 1, '19900610', N'234 EFG', 'hoangvanf@example.com', '8765432109', 'GV', 'abc'),
    ('008', N'Mai Thị G', 0, '19920228', N'890 HIJ', 'maithig@example.com', '7654321098', 'DD', 'abc'),
    ('009', N'Vũ Văn H', 1, '19911230', N'123 JKL', 'vuvanh@example.com', '6543210987', 'NS', 'abc'),
    ('010', N'Ngô Thị I', 0, '19870407', N'456 MNO', 'ngothii@example.com', '5432109876', 'GV', 'abc'),
    ('011', N'Đặng Văn K', 1, '19930420', N'789 PQR', 'dangvank@example.com', '4321098765', 'DD', 'abc'),
    ('012', N'Lương Thị L', 0, '19880808', N'567 STU', 'luongthil@example.com', '3210987654', 'NS', 'abc'),
    ('013', N'Phan Văn M', 1, '19890909', N'890 VWX', 'phanvanm@example.com', '2109876543', 'GV', 'abc');

-- Thêm giáo viên 11 đến 20
insert into GiaoVien (MaGV, HoTen, GioiTinh, NgaySinh, DiaChi, Email, SDT, MaCV, Pass)
values
    ('014', N'Đỗ Thị N', 0, '19951225', N'123 YZA', 'dothin@example.com', '1098765432', 'DD', 'abc'),
    ('015', N'Bùi Văn O', 1, '19941111', N'456 BCD', 'buivano@example.com', '0987654321', 'NS', 'abc'),
    ('016', N'Chu Thị P', 0, '19920606', N'789 CDE', 'chuthip@example.com', '9876543210', 'GV', 'abc'),
    ('017', N'Lý Văn Q', 1, '19910315', N'567 DEF', 'lyvanq@example.com', '8765432109', 'DD', 'abc'),
    ('018', N'Hoàng Thị R', 0, '19890220', N'890 EFG', 'hoangthir@example.com', '7654321098', 'NS', 'abc'),
    ('019', N'Nguyễn Văn S', 1, '19921225', N'123 GHI', 'nguyenvans@example.com', '6543210987', 'GV', 'abc'),
    ('020', N'Trần Thị T', 0, '19880101', N'456 HIJ', 'trant@example.com', '5432109876', 'DD', 'abc'),
    ('021', N'Phạm Văn U', 1, '19900909', N'789 JKL', 'phamvanu@example.com', '4321098765', 'NS', 'abc'),
    ('022', N'Đỗ Thị V', 0, '19970807', N'567 MNO', 'dothiv@example.com', '3210987654', 'GV', 'abc'),
    ('023', N'Nguyễn Văn X', 1, '19940625', N'890 PQR', 'nguyenvanx@example.com', '2109876543', 'DD', 'abc');

create table MonHoc(
	MaMH char(2) primary key,
	TenMH nvarchar(20) not null,
	MoTa nvarchar(100)
)
insert into MonHoc
values	('01', N'Toán', null),
		('02', N'Ngữ Văn', null),
		('03', N'Vật lý', null)
-- Thêm các môn học và dữ liệu mẫu
insert into MonHoc (MaMH, TenMH, MoTa)
values
    ('04', N'Kỹ thuật', N'Môn học về các kỹ thuật sản xuất và công nghệ'),
    ('05', N'Hội họa', N'Môn học về hội họa và nghệ thuật vẽ'),
    ('06', N'Âm nhạc', N'Môn học về âm nhạc và nghệ thuật biểu diễn'),
    ('07', N'Hóa học', N'Môn học về các phản ứng hoá học và cấu trúc của vật chất'),
    ('08', N'Lịch sử', N'Môn học về sự phát triển của xã hội và con người qua các giai đoạn lịch sử'),
    ('09', N'Địa lý', N'Môn học về địa hình, khí hậu, và môi trường'),
    ('10', N'Sinh học', N'Môn học về sự sống và các sinh vật'),
    ('11', N'Tin học', N'Môn học về công nghệ thông tin và máy tính'),
    ('12', N'Ngoại ngữ', N'Môn học về các ngôn ngữ nước ngoài'),
    ('13', N'Thể dục', N'Môn học về thể dục thể thao và sức khỏe')

create table CaHoc(
	MaCa char(2) primary key,
	ThoiGianBatDau time not null,
	ThoiGianKetThuc time not null
)
insert into CaHoc
values	('01', '06:45:00', '09:15:00'),
		('02', '09:30:00', '12:00:00'),
		('03', '12:45:00', '15:15:00'),
		('04', '15:30:00', '18:00:00'),
		('05', '18:15:00', '20:45:00')

create table LichGiangDay(
	MaLop char(2) not null,
	MaMH char(2) not null,
	MaGV char(3) not null,
	MaCa char(2) not null,
	primary key (MaLop, MaMH, MaGV),
	foreign key (MaLop) references LopHoc(MaLop),
	foreign key (MaMH) references MonHoc(MaMH),
	foreign key (MaGV) references GiaoVien(MaGV),
	foreign key (MaCa) references CaHoc(MaCa)
)
insert into LichGiangDay
values	('01', '01', '001', '01'),
		('01', '02', '001', '02')

-- Thêm dữ liệu mẫu vào bảng LichGiangDay
-- Môn học Toán (MaMH = '01')
insert into LichGiangDay (MaLop, MaMH, MaGV, MaCa)
values
    ('01', '01', '002', '03'),
    ('02', '01', '003', '04'),
    ('03', '01', '004', '01'),
    ('04', '01', '005', '02'),
    ('05', '01', '006', '03'),
    ('06', '01', '007', '04'),
    ('07', '01', '008', '01'),
    ('08', '01', '009', '02'),
    ('09', '01', '010', '03'),
    ('10', '01', '011', '04'),
    ('01', '01', '012', '01'),
    ('02', '01', '013', '02'),
    ('03', '01', '014', '03'),
    ('04', '01', '015', '04'),
    ('05', '01', '016', '01'),
    ('06', '01', '017', '02'),
    ('07', '01', '018', '03'),
    ('08', '01', '019', '04'),
    ('09', '01', '020', '01'),
    ('10', '01', '021', '02');

-- Môn học Ngữ Văn (MaMH = '02')
insert into LichGiangDay (MaLop, MaMH, MaGV, MaCa)
values
    ('01', '02', '002', '03'),
    ('02', '02', '003', '04'),
    ('03', '02', '004', '01'),
    ('04', '02', '005', '02'),
    ('05', '02', '006', '03'),
    ('06', '02', '007', '04'),
    ('07', '02', '008', '01'),
    ('08', '02', '009', '02'),
    ('09', '02', '010', '03'),
    ('10', '02', '011', '04'),
    ('01', '02', '012', '01'),
    ('02', '02', '013', '02'),
    ('03', '02', '014', '03'),
    ('04', '02', '015', '04'),
    ('05', '02', '016', '01'),
    ('06', '02', '017', '02'),
    ('07', '02', '018', '03'),
    ('08', '02', '019', '04'),
    ('09', '02', '020', '01'),
    ('10', '02', '021', '02');

-- Môn học Vật lý (MaMH = '03')
insert into LichGiangDay (MaLop, MaMH, MaGV, MaCa)
values
    ('01', '03', '002', '03'),
    ('02', '03', '003', '04'),
    ('03', '03', '004', '01'),
    ('04', '03', '005', '02'),
    ('05', '03', '006', '03'),
    ('06', '03', '007', '04'),
    ('07', '03', '008', '01'),
    ('08', '03', '009', '02'),
    ('09', '03', '010', '03'),
    ('10', '03', '011', '04'),
    ('01', '03', '012', '01'),
    ('02', '03', '013', '02'),
    ('03', '03', '014', '03'),
    ('04', '03', '015', '04'),
    ('05', '03', '016', '01'),
    ('06', '03', '017', '02'),
    ('07', '03', '018', '03'),
    ('08', '03', '019', '04'),
    ('09', '03', '020', '01'),
    ('10', '03', '021', '02');

create table BangDiem(
	MaLop char(2) not null,
	MaMH char(2) not null,
	MaHS char(10) not null,
	foreign key (MaLop) references LopHoc(MaLop),
	foreign key (MaMH) references MonHoc(MaMH),
	foreign key (MaHS) references HocSinh(MaHS),
	DiemLan1 integer,
	DiemLan2 integer,
	DiemLan3 integer,
	DiemGK integer,
	DiemCK integer,
)

insert into BangDiem
values	('01', '02', 'HS00000001', 9, 8, 7, 6, 7),
		('02', '01', 'HS00000001', 9, 8, 7, 6, 7)


--Select table
select * from KhoiLop
select * from LopHoc
select * from TrangThaiHS
select * from HocSinh
select * from ChucVu
select * from GiaoVien
select * from MonHoc
select * from CaHoc
select * from LichGiangDay
select * from BangDiem