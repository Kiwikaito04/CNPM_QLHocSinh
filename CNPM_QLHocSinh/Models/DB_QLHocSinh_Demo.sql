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
		('K2',N'Khối 2', null, 2)

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
values	('001',N'Quỳnh Thị A', 1, '20110122', N'123 ABC', null, null, 'GV', 'abc')

create table MonHoc(
	MaMH char(2) primary key,
	TenMH nvarchar(20) not null,
	MoTa nvarchar(100)
)
insert into MonHoc
values	('01', N'Toán', null),
		('02', N'Ngữ Văn', null),
		('03', N'Vật lý', null)

create table CaHoc(
	MaCa char(2) primary key,
	ThoiGianBatDau time not null,
	ThoiGianKetThuc time not null
)
insert into CaHoc
values	('01', '06:45:00', '09:15:00'),
		('02', '09:30:00', '11:45:00')

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






