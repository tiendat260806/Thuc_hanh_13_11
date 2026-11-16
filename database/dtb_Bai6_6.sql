USE master;
GO

-- Xóa database cũ nếu đã tồn tại để làm sạch từ đầu
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'LibraryDB')
BEGIN
    ALTER DATABASE LibraryDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE LibraryDB;
END
GO

CREATE DATABASE LibraryDB;
GO
USE LibraryDB;
GO

-- 1. Bảng Độc giả
CREATE TABLE DocGia (
    MaDocGia INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    NgayHetHanThe DATETIME
);

-- 2. Bảng Đầu sách
CREATE TABLE DauSach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(200) NOT NULL,
    TheLoai NVARCHAR(50),
    SoLuongCon INT CHECK (SoLuongCon >= 0)
);

-- 3. Bảng Phiếu mượn
CREATE TABLE PhieuMuon (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    MaDocGia INT FOREIGN KEY REFERENCES DocGia(MaDocGia),
    NgayMuon DATETIME DEFAULT GETDATE(),
    HanTra DATETIME,
    TrangThai NVARCHAR(50)
);

-- 4. Bảng Chi tiết mượn
CREATE TABLE ChiTietMuon (
    MaPhieu INT FOREIGN KEY REFERENCES PhieuMuon(MaPhieu),
    MaSach INT FOREIGN KEY REFERENCES DauSach(MaSach),
    SoLuong INT CHECK (SoLuong > 0),
    PRIMARY KEY (MaPhieu, MaSach)
);
GO

-- Dữ liệu mẫu chuẩn Unicode
INSERT INTO DocGia (HoTen, Email, NgayHetHanThe) VALUES
(N'Nguyễn Văn An', 'an.nv@gmail.com', DATEADD(MONTH, 6, GETDATE())),
(N'Trần Thị Bình', 'binh.tt@gmail.com', DATEADD(YEAR, 1, GETDATE())),
(N'Lê Hoàng Cường', 'cuong.lh@gmail.com', DATEADD(DAY, -10, GETDATE()));

INSERT INTO DauSach (TenSach, TheLoai, SoLuongCon) VALUES
(N'Lập trình C# căn bản đến nâng cao', N'Công nghệ thông tin', 10),
(N'Cấu trúc dữ liệu và Giải thuật', N'Công nghệ thông tin', 5),
(N'Kinh tế học vĩ mô', N'Kinh tế', 8),
(N'Số Đỏ', N'Văn học', 12);

INSERT INTO PhieuMuon (MaDocGia, NgayMuon, HanTra, TrangThai) VALUES
(1, DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, 12, GETDATE()), N'Đang mượn'),
(2, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -5, GETDATE()), N'Đang mượn'),
(1, DATEADD(DAY, -30, GETDATE()), DATEADD(DAY, -15, GETDATE()), N'Đã trả');

INSERT INTO ChiTietMuon (MaPhieu, MaSach, SoLuong) VALUES
(1, 1, 1),
(1, 3, 1),
(2, 2, 2),
(3, 4, 1);
GO