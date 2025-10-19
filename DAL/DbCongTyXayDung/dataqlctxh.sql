-- Dữ liệu mẫu cho QuanLyXayDung
USE QuanLyXayDung;
GO

-- 1. NHÂN VIÊN
PRINT N'Chèn dữ liệu vào bảng NhanVien...';
INSERT INTO NhanVien (HoTen, Email, Phone, VaiTro) VALUES
(N'Nguyễn Văn A', 'a.nguyen@example.com', '0901234567', N'Giám sát'),
(N'Trần Thị B', 'b.tran@example.com', '0912345678', N'Kế toán'),
(N'Lê Văn C', 'c.le@example.com', '0987654321', N'Kho'),
(N'Phạm Thị D', 'd.pham@example.com', '0934567890', N'Kinh doanh'),
(N'Võ Minh Tùng', 'tung.vo@example.com', '0945112233', N'Admin'),
(N'Đỗ Hoàng E', 'e.do@example.com', '0905678123', N'Kiến trúc sư');
GO

-- 2. NGƯỜI DÙNG HỆ THỐNG
PRINT N'Chèn dữ liệu vào bảng NguoiDung...';
-- Lưu ý: Trong thực tế, mật khẩu phải được băm (hashed) trước khi lưu.
INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro, NhanVienID) VALUES
('giam_sat_a', 'hashed_password_123', N'Nhân viên', 1),
('ke_toan_b', 'hashed_password_123', N'Nhân viên', 2),
('kho_c', 'hashed_password_123', N'Nhân viên', 3),
('kinh_doanh_d', 'hashed_password_123', N'Nhân viên', 4),
('admin', 'hashed_admin_password', N'Quản trị viên', 5);
GO

-- 3. KHÁCH HÀNG
PRINT N'Chèn dữ liệu vào bảng KhachHang...';
INSERT INTO KhachHang (HoTenKH, Email, Phone, DiaChi) VALUES
(N'Công ty TNHH An Khang', 'info@ankhang.com', '02838123456', N'123 Nguyễn Trãi, P. Bến Thành, Q.1, TP.HCM'),
(N'Anh Trần Văn Hùng', 'hung.tran@gmail.com', '0909888999', N'45 Phổ Quang, P.2, Q.Tân Bình, TP.HCM'),
(N'Chị Nguyễn Thu Thảo', 'thao.nguyen@yahoo.com', '0918777666', N'210 Lê Văn Sỹ, P.14, Q.3, TP.HCM');
GO

-- 4. NHÀ CUNG CẤP
PRINT N'Chèn dữ liệu vào bảng NhaCungCap...';
INSERT INTO NhaCungCap (TenNCC, Email, DiaChi, Phone) VALUES
(N'Công ty VLXD Hòa Phát', 'contact@hoaphat.com', N'KCN Sóng Thần, Bình Dương', '02743790888'),
(N'Nhà phân phối Thép Pomina', 'sales@pomina.com', N'KCN Phú Mỹ, Bà Rịa - Vũng Tàu', '02543895158'),
(N'Công ty Sơn Toa Việt Nam', 'info@toagroup.com.vn', N'KCN Tân Đông Hiệp, Dĩ An, Bình Dương', '02743728365');
GO

-- 5. VẬT TƯ
PRINT N'Chèn dữ liệu vào bảng VatTu...';
INSERT INTO VatTu (TenVatTu, DonViTinh, SoLuongTon, NhaCungCapID) VALUES
(N'Xi măng Holcim PC40', N'Bao 50kg', 500, 1),
(N'Cát xây tô', N'm³', 150, 1),
(N'Thép cây D16 Pomina', N'Cây 11.7m', 300, 2),
(N'Gạch ống Tuynel 8x18', N'Viên', 10000, 1),
(N'Sơn nước nội thất Toa', N'Thùng 18L', 50, 3);
GO

-- 6. HỢP ĐỒNG
PRINT N'Chèn dữ liệu vào bảng HopDong...';
INSERT INTO HopDong (MaHopDong, TenHopDong, KhachHangID, NgayKy, GiaTriHopDong, NoiDungYeuCau, ThoiHanThiCong, DieuKhoanThanhToan, TrangThai) VALUES
('HD-2025-001', N'Hợp đồng thi công nhà phố Ms. Thảo', 3, '2025-09-01', 1200000000.00, N'Xây dựng nhà 1 trệt 2 lầu, hoàn thiện cơ bản', N'6 tháng', N'Thanh toán 4 đợt', N'Đang thực hiện'),
('HD-2025-002', N'Hợp đồng cải tạo văn phòng An Khang', 1, '2025-10-10', 550000000.00, N'Sửa chữa, phân chia lại không gian văn phòng, đi lại hệ thống điện mạng', N'45 ngày', N'Thanh toán 3 đợt', N'Đang thực hiện');
GO

-- 7. DỰ ÁN / CÔNG TRÌNH
PRINT N'Chèn dữ liệu vào bảng DuAn...';
INSERT INTO DuAn (TenDuAn, KhachHangID, HopDongID, NgayBatDau, NgayKetThuc, TienDo) VALUES
(N'Dự án nhà phố Quận 3', 3, 1, '2025-09-15', '2026-03-15', N'30% - Đã xong phần thô'),
(N'Dự án văn phòng An Khang', 1, 2, '2025-10-20', '2025-12-05', N'10% - Đang thi công phần tháo dỡ');
GO

-- Cập nhật lại HopDong để liên kết với DuAn (mối quan hệ 2 chiều)
PRINT N'Cập nhật DuAnID cho bảng HopDong...';
UPDATE HopDong SET DuAnID = 1 WHERE HopDongID = 1;
UPDATE HopDong SET DuAnID = 2 WHERE HopDongID = 2;
GO

-- 8. PHÂN CÔNG NHÂN SỰ
PRINT N'Chèn dữ liệu vào bảng PhanCong...';
INSERT INTO PhanCong (DuAnID, NhanVienID, NhiemVu, NgayBatDau, NgayKetThuc) VALUES
(1, 1, N'Giám sát thi công phần móng và kết cấu', '2025-09-15', '2025-12-15'),
(1, 6, N'Thiết kế bản vẽ hoàn công', '2026-02-01', '2026-03-01'),
(2, 1, N'Giám sát thi công toàn bộ dự án', '2025-10-20', '2025-12-05'),
(2, 4, N'Làm việc với khách hàng về tiến độ', '2025-10-20', '2025-12-05');
GO

-- 9. ĐƠN ĐẶT HÀNG
PRINT N'Chèn dữ liệu vào bảng DonDatHang...';
INSERT INTO DonDatHang (NhaCungCapID, NhanVienID, NgayDat, TrangThai) VALUES
(1, 3, '2025-09-10', N'Đã giao'),
(2, 3, '2025-09-12', N'Đã giao'),
(3, 3, '2025-10-15', N'Đang giao');
GO

-- 10. CHI TIẾT ĐƠN ĐẶT HÀNG
PRINT N'Chèn dữ liệu vào bảng ChiTietDonDatHang...';
INSERT INTO ChiTietDonDatHang (DonDatHangID, VatTuID, SoLuong, DonGia) VALUES
(1, 1, 200, 85000.00), -- 200 bao xi măng
(1, 2, 50, 250000.00), -- 50 m3 cát
(2, 3, 150, 155000.00); -- 150 cây thép D16
GO

-- 11. KHO (NHẬP / XUẤT)
PRINT N'Chèn dữ liệu vào bảng Kho...';
-- Giao dịch nhập kho từ đơn đặt hàng
INSERT INTO Kho (VatTuID, LoaiGiaoDich, SoLuong, NgayGiaoDich, DonDatHangID, NhanVienID) VALUES
(1, N'Nhập', 200, '2025-09-14', 1, 3),
(2, N'Nhập', 50, '2025-09-14', 1, 3),
(3, N'Nhập', 150, '2025-09-16', 2, 3);
-- Giao dịch xuất kho cho dự án
INSERT INTO Kho (VatTuID, LoaiGiaoDich, SoLuong, NgayGiaoDich, DuAnID, NhanVienID) VALUES
(1, N'Xuất', 80, '2025-09-20', 1, 1), -- Giám sát A nhận 80 bao xi măng cho dự án 1
(2, N'Xuất', 20, '2025-09-21', 1, 1), -- Giám sát A nhận 20 m3 cát cho dự án 1
(3, N'Xuất', 50, '2025-09-25', 1, 1); -- Giám sát A nhận 50 cây thép cho dự án 1
GO

-- 12. THANH TOÁN
PRINT N'Chèn dữ liệu vào bảng ThanhToan...';
-- Khách hàng thanh toán đợt 1 cho dự án 1
INSERT INTO ThanhToan (NgayThanhToan, SoTien, HinhThuc, GhiChu, DuAnID, NhanVienID) VALUES
('2025-09-15', 300000000.00, N'Chuyển khoản', N'Khách hàng thanh toán đợt 1 - Dự án nhà Q.3', 1, 2);
-- Công ty thanh toán cho nhà cung cấp
INSERT INTO ThanhToan (NgayThanhToan, SoTien, HinhThuc, GhiChu, DonDatHangID, NhanVienID) VALUES
('2025-09-20', 29500000.00, N'Chuyển khoản', N'Thanh toán cho NCC Hòa Phát cho DDH #1', 1, 2);
GO

-- 13. BẢNG LƯƠNG
PRINT N'Chèn dữ liệu vào bảng BangLuong...';
INSERT INTO BangLuong (NhanVienID, Thang, Nam, LuongCoBan, Thuong, KhauTru, NgayCong, PhuCap) VALUES
(1, 9, 2025, 15000000.00, 2000000.00, 500000.00, 26, 1000000.00), -- Giám sát
(2, 9, 2025, 12000000.00, 1000000.00, 500000.00, 26, 500000.00),  -- Kế toán
(3, 9, 2025, 10000000.00, 0, 500000.00, 26, 500000.00);           -- Kho
GO

-- 14. BÁO CÁO
PRINT N'Chèn dữ liệu vào bảng BaoCao...';
INSERT INTO BaoCao (NhanVienID, DuAnID, NoiDung, NgayBaoCao) VALUES
(1, 1, N'Báo cáo tiến độ tuần 4 tháng 9. Đã hoàn thành đổ bê tông sàn lầu 1. Chất lượng đảm bảo. Xin cấp thêm 50 cây thép D12 cho giai đoạn tiếp theo.', '2025-09-28');
INSERT INTO BaoCao (NhanVienID, ThanhToanID, NoiDung, NgayBaoCao) VALUES
(2, 1, N'Báo cáo tài chính: Đã nhận thanh toán đợt 1 từ khách hàng cho dự án nhà Q.3, số tiền 300,000,000 VND.', '2025-09-16');
GO

PRINT N'Hoàn tất chèn dữ liệu mẫu!';
GO


select * from BangLuong
select * from Nhanvien