CREATE DATABASE QuanLyXayDung;
GO
USE QuanLyXayDung;
GO

-- 1. NHÂN VIÊN
CREATE TABLE NhanVien (
    NhanVienID INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255),
    Phone NVARCHAR(20),
    VaiTro NVARCHAR(50) NOT NULL, -- Giám sát, Kế toán, Kho, Kinh doanh, Admin...
    AnhDaiDien VARBINARY(MAX) NULL
);
GO

-- 2. NGƯỜI DÙNG HỆ THỐNG
CREATE TABLE NguoiDung (
    NguoiDungID INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(50) NOT NULL, -- Quản trị viên / Nhân viên
    NhanVienID INT UNIQUE,
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID)
);
GO

-- 3. KHÁCH HÀNG
CREATE TABLE KhachHang (
    KhachHangID INT IDENTITY(1,1) PRIMARY KEY,
    HoTenKH NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255),
    Phone NVARCHAR(20),
    DiaChi NVARCHAR(255),
    AnhDaiDien VARBINARY(MAX) NULL
);
GO

-- 4. HỢP ĐỒNG (Gộp yêu cầu khách hàng + lưu file hợp đồng)
CREATE TABLE HopDong (
    HopDongID INT IDENTITY(1,1) PRIMARY KEY,
    MaHopDong NVARCHAR(50) NOT NULL UNIQUE,               -- Mã hợp đồng
    TenHopDong NVARCHAR(255) NOT NULL,
    KhachHangID INT NOT NULL,
    DuAnID INT NULL,
    NgayKy DATE NOT NULL DEFAULT GETDATE(),
    GiaTriHopDong DECIMAL(18,2) NOT NULL,
    NoiDungYeuCau NVARCHAR(MAX) NULL,                     -- Gộp nội dung yêu cầu khách hàng
    ThoiHanThiCong NVARCHAR(100) NULL,
    DieuKhoanThanhToan NVARCHAR(255) NULL,
    TrangThai NVARCHAR(50) DEFAULT N'Đang thực hiện',
    FileHopDong VARBINARY(MAX) NULL,                      -- Lưu file hợp đồng ký kết
    FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID)
);
GO

-- 5. DỰ ÁN / CÔNG TRÌNH
CREATE TABLE DuAn (
    DuAnID INT IDENTITY(1,1) PRIMARY KEY,
    TenDuAn NVARCHAR(255) NOT NULL,
    KhachHangID INT,
    HopDongID INT NULL,
    NgayBatDau DATE,
    NgayKetThuc DATE,
    TienDo NVARCHAR(100),
    HinhAnhDuAn VARBINARY(MAX) NULL,
    FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID),
    FOREIGN KEY (HopDongID) REFERENCES HopDong(HopDongID)
);
GO

-- 6. PHÂN CÔNG NHÂN SỰ
CREATE TABLE PhanCong (
    PhanCongID INT IDENTITY(1,1) PRIMARY KEY,
    DuAnID INT,
    NhanVienID INT,
    NhiemVu NVARCHAR(255),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    FOREIGN KEY (DuAnID) REFERENCES DuAn(DuAnID),
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID)
);
GO

-- 7. NHÀ CUNG CẤP
CREATE TABLE NhaCungCap (
    NhaCungCapID INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(255) NOT NULL,
    Email NVARCHAR(50),
    DiaChi NVARCHAR(255),
    Phone NVARCHAR(20),
    Logo VARBINARY(MAX) NULL
);
GO
CREATE TABLE PhanCongHopDong (
    PhanCongID INT PRIMARY KEY IDENTITY(1,1),
    HopDongID INT NOT NULL,
    NhanVienID INT NOT NULL,
    VaiTro NVARCHAR(100) NOT NULL,
    FOREIGN KEY (HopDongID) REFERENCES HopDong(HopDongID),
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID)
);
GO
-- 8. VẬT TƯ
CREATE TABLE VatTu (
    VatTuID INT IDENTITY(1,1) PRIMARY KEY,
    TenVatTu NVARCHAR(255) NOT NULL,
    DonViTinh NVARCHAR(50),
    SoLuongTon INT DEFAULT 0,
    NhaCungCapID INT,
    HinhAnhVatTu VARBINARY(MAX) NULL,
    FOREIGN KEY (NhaCungCapID) REFERENCES NhaCungCap(NhaCungCapID)
);
GO

-- 9. ĐƠN ĐẶT HÀNG
CREATE TABLE DonDatHang (
    DonDatHangID INT IDENTITY(1,1) PRIMARY KEY,
    NhaCungCapID INT NOT NULL,
    NhanVienID INT NOT NULL,
    NgayDat DATE NOT NULL DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) DEFAULT N'Đang giao',
    FOREIGN KEY (NhaCungCapID) REFERENCES NhaCungCap(NhaCungCapID),
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID)
);
GO

-- 10. CHI TIẾT ĐƠN ĐẶT HÀNG
CREATE TABLE ChiTietDonDatHang (
    ChiTietID INT IDENTITY(1,1) PRIMARY KEY,
    DonDatHangID INT NOT NULL,
    VatTuID INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (DonDatHangID) REFERENCES DonDatHang(DonDatHangID),
    FOREIGN KEY (VatTuID) REFERENCES VatTu(VatTuID)
);
GO

-- 11. KHO (NHẬP / XUẤT)
CREATE TABLE Kho (
    KhoID INT IDENTITY(1,1) PRIMARY KEY,
    VatTuID INT,
    LoaiGiaoDich NVARCHAR(50), -- Nhập / Xuất
    SoLuong INT,
    NgayGiaoDich DATE DEFAULT GETDATE(),
    DuAnID INT NULL,
    DonDatHangID INT NULL,
    NhanVienID INT NOT NULL,
    FOREIGN KEY (VatTuID) REFERENCES VatTu(VatTuID),
    FOREIGN KEY (DuAnID) REFERENCES DuAn(DuAnID),
    FOREIGN KEY (DonDatHangID) REFERENCES DonDatHang(DonDatHangID),
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID)
);
GO

-- 12. THANH TOÁN
CREATE TABLE ThanhToan (
    ThanhToanID INT IDENTITY(1,1) PRIMARY KEY,
    NgayThanhToan DATE NOT NULL DEFAULT GETDATE(),
    SoTien DECIMAL(18,2) NOT NULL,
    HinhThuc NVARCHAR(50), -- Tiền mặt / Chuyển khoản
    GhiChu NVARCHAR(255),
    DuAnID INT NULL,
    DonDatHangID INT NULL,
    NhanVienID INT NOT NULL,
    FOREIGN KEY (DuAnID) REFERENCES DuAn(DuAnID),
    FOREIGN KEY (DonDatHangID) REFERENCES DonDatHang(DonDatHangID),
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID),
    CHECK (DuAnID IS NOT NULL OR DonDatHangID IS NOT NULL)
);
GO

-- 13. BẢNG LƯƠNG
CREATE TABLE BangLuong (
    BangLuongID INT IDENTITY(1,1) PRIMARY KEY,
    NhanVienID INT NOT NULL,
    Thang INT NOT NULL,
    Nam INT NOT NULL,
    LuongCoBan DECIMAL(18,2) NOT NULL,
    Thuong DECIMAL(18,2) DEFAULT 0,
    KhauTru DECIMAL(18,2) DEFAULT 0,
    TongLuong AS (LuongCoBan + Thuong - KhauTru) PERSISTED,
    NgayCong INT,
    GioTangCa INT,
    PhuCap DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID)
);
GO

-- 14. BÁO CÁO
CREATE TABLE BaoCao (
    BaoCaoID INT IDENTITY(1,1) PRIMARY KEY,
    NhanVienID INT NOT NULL,
    DuAnID INT NULL,
    ThanhToanID INT NULL,
    NoiDung NVARCHAR(MAX),
    NgayBaoCao DATE NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (NhanVienID) REFERENCES NhanVien(NhanVienID),
    FOREIGN KEY (DuAnID) REFERENCES DuAn(DuAnID),
    FOREIGN KEY (ThanhToanID) REFERENCES ThanhToan(ThanhToanID)
);
GO
