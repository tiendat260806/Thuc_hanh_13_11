USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'ClinicDB')
BEGIN
    ALTER DATABASE ClinicDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ClinicDB;
END
GO

CREATE DATABASE ClinicDB;
GO
USE ClinicDB;
GO

-- 1. Bảng Bệnh nhân
CREATE TABLE BenhNhan (
    MaBN INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) UNIQUE,
    NamSinh INT
);

-- 2. Bảng Hồ sơ khám
CREATE TABLE HoSoKham (
    MaHoSo INT IDENTITY(1,1) PRIMARY KEY,
    MaBN INT FOREIGN KEY REFERENCES BenhNhan(MaBN),
    NgayKham DATETIME DEFAULT GETDATE(),
    TrieuChung NVARCHAR(MAX),
    ChanDoan NVARCHAR(250)
);

-- 3. Bảng Danh mục thuốc
CREATE TABLE Thuoc (
    MaThuoc INT IDENTITY(1,1) PRIMARY KEY,
    TenThuoc NVARCHAR(150) NOT NULL,
    DonViTinh NVARCHAR(20),
    DonGia DECIMAL(18,2),
    SoLuongTon INT CHECK (SoLuongTon >= 0)
);

-- 4. Bảng Đơn thuốc
CREATE TABLE DonThuoc (
    MaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaHoSo INT FOREIGN KEY REFERENCES HoSoKham(MaHoSo),
    TienKham DECIMAL(18,2),
    TongTien DECIMAL(18,2),
    TrangThai NVARCHAR(30) -- 'Chờ lấy thuốc', 'Đã thanh toán'
);

-- 5. Bảng Chi tiết đơn thuốc
CREATE TABLE ChiTietDonThuoc (
    MaDon INT FOREIGN KEY REFERENCES DonThuoc(MaDon),
    MaThuoc INT FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuong INT CHECK (SoLuong > 0),
    LieuDung NVARCHAR(100),
    PRIMARY KEY (MaDon, MaThuoc)
);
GO

-- Dữ liệu mẫu
INSERT INTO BenhNhan (HoTen, SoDienThoai, NamSinh) VALUES
(N'Nguyễn Hoàng Nam', '0901234567', 1995),
(N'Lê Thị Mai', '0987654321', 1988);

INSERT INTO HoSoKham (MaBN, NgayKham, TrieuChung, ChanDoan) VALUES
(1, GETDATE(), N'Sốt nhẹ, đau họng, ho khan', N'Viêm họng cấp');

INSERT INTO Thuoc (TenThuoc, DonViTinh, DonGia, SoLuongTon) VALUES
(N'Paracetamol 500mg', N'Vỉ', 15000, 50),
(N'Amoxicillin 500mg', N'Vỉ', 25000, 30),
(N'Siro ho Bảo Thanh', N'Chai', 45000, 5), -- Số lượng ít để test Rollback
(N'Vitamin C 1000mg', N'Tuýp', 35000, 20);
GO