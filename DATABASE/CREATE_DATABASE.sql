-- Tạo cơ sở dữ liệu QuanLySach
CREATE DATABASE QuanLySach;
GO

-- Sử dụng cơ sở dữ liệu QuanLySach
USE QuanLySach;
GO

-- Tạo bảng TheKhachHang
CREATE TABLE TheKhachHang (
    MaThe VARCHAR(10) PRIMARY KEY,
    NgayLap DATE
);

-- Tạo bảng Sach
CREATE TABLE Sach (
    MaSach VARCHAR(10) PRIMARY KEY,
	TenSach NVARCHAR(100),
    GiaBan DECIMAL(10, 2),
    NhaXB NVARCHAR(100),
    TacGia NVARCHAR(100),
    TheLoai NVARCHAR(100)
);

-- Tạo bảng KhoSach
CREATE TABLE KhoSach (
    MaLo VARCHAR(10) PRIMARY KEY,
    MaSach VARCHAR(10),
    NgayNhap DATE,
    NgayXuat DATE,
    SoLuong INT,
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- Tạo bảng CBQL
CREATE TABLE CBQL (
    MaCB VARCHAR(10) PRIMARY KEY,
    TenCB NVARCHAR(100),
    DiaChi NVARCHAR(100),
    ThongTinLL VARCHAR(100),
    NgaySinh DATE
);

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY,
    TenKH NVARCHAR(100),
    DiaChi NVARCHAR(100),
    ThongTinLL NVARCHAR(100),
    NgaySinh DATE,
    MaThe VARCHAR(10),
    FOREIGN KEY (MaThe) REFERENCES TheKhachHang(MaThe)
);

-- Tạo bảng HoaDon
CREATE TABLE HoaDon (
    MaHD VARCHAR(10) PRIMARY KEY,
    MaThe VARCHAR(10),
    DonGia DECIMAL(10, 2),
    FOREIGN KEY (MaThe) REFERENCES TheKhachHang(MaThe)
);

-- Tạo bảng ChiTiet_HoaDon
CREATE TABLE ChiTiet_HoaDon (
    MaHD VARCHAR(10),
    MaSach VARCHAR(10),
    NgayLap DATE,
    MaCB VARCHAR(10),
    PRIMARY KEY (MaHD, MaSach),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach),
    FOREIGN KEY (MaCB) REFERENCES CBQL(MaCB)
);