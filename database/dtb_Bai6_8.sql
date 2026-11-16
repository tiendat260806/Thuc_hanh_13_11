CREATE DATABASE BilliardsDB;
GO
USE BilliardsDB;
GO

-- 1. Bảng Bàn Bida
CREATE TABLE BanBida (
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    LoaiBan NVARCHAR(30), -- 'Pool (Lỗ)', 'Carom (Phăng)', 'Snooker'
    GiaTheoGio DECIMAL(18,2) NOT NULL CHECK (GiaTheoGio > 0),
    TrangThai NVARCHAR(20) DEFAULT N'Trống' -- 'Trống', 'Đang chơi'
);
GO

-- 2. Bảng Menu Dịch Vụ (Đồ ăn, nước uống, thuê gậy)
CREATE TABLE MenuDichVu (
    MaDV INT IDENTITY(1,1) PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia > 0),
    TonKho INT NOT NULL CHECK (TonKho >= 0) -- Quy ước: Dịch vụ thuê gậy không trừ kho
);
GO

-- 3. Bảng Hóa Đơn
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT NOT NULL FOREIGN KEY REFERENCES BanBida(MaBan),
    GioBatDau DATETIME NOT NULL DEFAULT GETDATE(),
    GioKetThuc DATETIME NULL,
    TienGioChoi DECIMAL(18,2) DEFAULT 0,
    TienDichVu DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);
GO

-- 4. Bảng Chi Tiết Hóa Đơn
CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaDV INT NOT NULL FOREIGN KEY REFERENCES MenuDichVu(MaDV),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHD, MaDV)
);
GO

-- Dữ liệu mẫu ban đầu
INSERT INTO BanBida (TenBan, LoaiBan, GiaTheoGio, TrangThai) VALUES
(N'Bàn Lỗ 01', N'Pool (Lỗ)', 60000, N'Trống'),
(N'Bàn Lỗ 02', N'Pool (Lỗ)', 60000, N'Trống'),
(N'Bàn Carom 01', N'Carom (Phăng)', 80000, N'Trống'),
(N'Bàn Carom 02', N'Carom (Phăng)', 80000, N'Trống'),
(N'Bàn Snooker VIP', N'Snooker', 120000, N'Trống');

INSERT INTO MenuDichVu (TenDV, DonGia, TonKho) VALUES
(N'Nước tăng lực Sting', 15000, 100),
(N'Bia Tiger Bạc', 22000, 80),
(N'Mì xào bò', 45000, 30),
(N'Thuê gậy Carbon', 50000, 10), -- Dịch vụ thuê gậy: Không trừ kho khi thanh toán
(N'Thuê gậy Phăng cơ bản', 25000, 15), -- Dịch vụ thuê gậy: Không trừ kho
(N'Nước ép dưa hấu đặc biệt', 35000, 2); -- Tồn 2 ly để test Rollback khi gọi 5
GO