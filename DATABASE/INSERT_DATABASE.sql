USE QuanLySach;
GO

-- Insert data into TheKhachHang
INSERT INTO TheKhachHang (MaThe, NgayLap) VALUES
('TK001', '2023-01-01'), ('TK002', '2023-02-01'), ('TK003', '2023-03-01'), 
('TK004', '2023-04-01'), ('TK005', '2023-05-01'), ('TK006', '2023-06-01'), 
('TK007', '2023-07-01'), ('TK008', '2023-08-01'), ('TK009', '2023-09-01'), 
('TK010', '2023-10-01'), ('TK011', '2023-11-01'), ('TK012', '2023-12-01'), 
('TK013', '2024-01-01'), ('TK014', '2024-02-01'), ('TK015', '2024-03-01');

-- Insert data into Sach
INSERT INTO Sach (MaSach, TenSach, GiaBan, NhaXB, TacGia, TheLoai) VALUES
('S001', N'Cho tôi xin một vé đi tuổi thơ', 50000, N'NXB Kim Đồng',N'Nguyễn Nhật Ánh', N'Thiếu nhi'),
('S002', N'Cánh đồng bất tận', 65000, N'NXB Trẻ',N'Nguyễn Ngọc Tư', N'Tiểu thuyết'),
('S003', N'Chiếc lược ngà', 75000, N'NXB Văn Học', N'Nguyễn Quang Sáng', N'Truyện ngắn'),
('S004', N'Đắc nhân tâm', 80000, N'NXB Giáo Dục', N'Nguyễn Hiến Lê', N'Giáo dục'),
('S005', N'Dế mèn phiêu lưu ký', 55000, N'NXB Văn Hóa', N'Tô Hoài', N'Văn học'),
('S006', N'Lão Hạc', 70000, N'NXB Lao Động', N'Nam Cao', 'Văn học'),
('S007', N'Kính vạn hoa', 85000, N'NXB Thanh Niên', N'Nguyễn Nhật Ánh', N'Thiếu nhi'),
('S008', N'Mùa lạc', 60000, N'NXB Khoa Học', N'Nguyễn Quang Sáng', N'Truyện ngắn'),
('S009', N'Quả táo thần kỳ của Kimura', 72000, N'NXB Chính Trị', N'Nguyễn Văn Thọ', N'Tiểu thuyết'),
('S010', N'Mùa lá rụng trong vườn', 68000, N'NXB Đại Học', N'Nguyễn Xuân Khánh', N'Văn học'),
('S011', N'Sài Gòn chuyện đời của phố', 50000, N'NXB Kim Đồng', N'Phạm Công Luận', N'Tản văn'),
('S012', N'Tuổi thơ dữ dội', 65000, N'NXB Trẻ', N'Nguyễn Huy Thiệp', N'Tiểu thuyết'),
('S013', N'Tôi thấy hoa vàng trên cỏ xanh', 75000, N'NXB Văn Học', N'Nguyễn Nhật Ánh', N'Thiếu nhi'),
('S014', N'Xung kích', 80000, N'NXB Giáo Dục', N'Nguyễn Đình Thi', N'Tiểu thuyết'),
('S015', N'Việt Nam sử lược', 55000, N'NXB Văn Hóa', N'Nguyễn Thị Thu Trang', N'Khoa học');

-- Insert data into KhoSach
INSERT INTO KhoSach (MaLo, MaSach, NgayNhap, NgayXuat, SoLuong) VALUES
('L001', 'S001', '2023-01-10', '2023-02-10', 100),
('L002', 'S002', '2023-02-15', '2023-03-15', 150),
('L003', 'S003', '2023-03-20', '2023-04-20', 200),
('L004', 'S004', '2023-04-25', '2023-05-25', 120),
('L005', 'S005', '2023-05-30', '2023-06-30', 140),
('L006', 'S006', '2023-06-05', '2023-07-05', 180),
('L007', 'S007', '2023-07-10', '2023-08-10', 160),
('L008', 'S008', '2023-08-15', '2023-09-15', 130),
('L009', 'S009', '2023-09-20', '2023-10-20', 110),
('L010', 'S010', '2023-10-25', '2023-11-25', 170),
('L011', 'S011', '2023-11-30', '2023-12-30', 190),
('L012', 'S012', '2023-12-05', '2024-01-05', 150),
('L013', 'S013', '2024-01-10', '2024-02-10', 140),
('L014', 'S014', '2024-02-15', '2024-03-15', 160),
('L015', 'S015', '2024-03-20', '2024-04-20', 200);

-- Insert data into CBQL
INSERT INTO CBQL (MaCB, TenCB, DiaChi, ThongTinLL, NgaySinh) VALUES
('CB001', N'Nguyễn Văn An', N'Hà Nội', '0123456789', '1980-01-01'),
('CB002', N'Trần Thị Bình', N'Hồ Chí Minh', '0987654321', '1981-02-02'),
('CB003', N'Lê Văn Cương', N'Đà Nẵng', '0912345678', '1982-03-03'),
('CB004', N'Phạm Thị Dương', N'Cần Thơ', '0945678912', '1983-04-04'),
('CB005', N'Ngô Văn Toàn', N'Hải Phòng', '0971234567', '1984-05-05'),
('CB006', N'Đinh Thị Thu', N'Huế', '0909876543', '1985-06-06'),
('CB007', N'Hoàng Văn Trường', N'Nha Trang', '0934567890', '1986-07-07'),
('CB008', N'Phan Thị Hạnh', N'Buôn Ma Thuột', '0967891234', '1987-08-08'),
('CB009', N'Nguyễn Thị Loan', N'Biên Hòa', '0991234567', '1988-09-09'),
('CB010', N'Trần Văn Bắc', N'Vũng Tàu', '0923456789', '1989-10-10'),
('CB011', N'Lê Thị Kim', N'Quy Nhơn', '0956789123', '1990-11-11'),
('CB012', N'Phạm Văn Long', N'Long An', '0912345678', '1991-12-12'),
('CB013', N'Ngô Thị Minh', N'Nam Định', '0945678901', '1992-01-13'),
('CB014', N'Đinh Văn Nam', N'Hà Nam', '0976543210', '1993-02-14'),
('CB015', N'Hoàng Thị Linh', N'Bắc Ninh', '0908765432', '1994-03-15');

-- Insert data into KhachHang
INSERT INTO KhachHang (MaKH, TenKH, DiaChi, ThongTinLL, NgaySinh, MaThe) VALUES
('KH001', N'Nguyễn Thị Hoa', N'Hà Nội', '0123456789', '2000-01-01', 'TK001'),
('KH002', N'Trần Văn Nam', N'Hồ Chí Minh', '0987654321', '2000-02-02', 'TK002'),
('KH003', N'Lê Thị Lan', N'Đà Nẵng', '0912345678', '2000-03-03', 'TK003'),
('KH004', N'Phạm Văn Hải', N'Cần Thơ', '0945678912', '2000-04-04', 'TK004'),
('KH005', N'Ngô Thị Minh', N'Hải Phòng', '0971234567', '2000-05-05', 'TK005'),
('KH006', N'Đinh Văn Khoa', N'Huế', '0909876543', '2000-06-06', 'TK006'),
('KH007', N'Hoàng Thị Mai', N'Nha Trang', '0934567890', '2000-07-07', 'TK007'),
('KH008', N'Phan Văn Tú', N'Buôn Ma Thuột', '0967891234', '2000-08-08', 'TK008'),
('KH009', N'Nguyễn Thị Cúc', N'Biên Hòa', '0991234567', '2000-09-09', 'TK009'),
('KH010', N'Trần Văn Tiến', N'Vũng Tàu', '0923456789', '2000-10-10', 'TK010'),
('KH011', N'Lê Thị Bích', N'Quy Nhơn', '0956789123', '2000-11-11', 'TK011'),
('KH012', N'Phạm Văn Bình', N'Long An', '0912345678', '2000-12-12', 'TK012'),
('KH013', N'Ngô Thị Thảo', N'Nam Định', '0945678901', '2000-01-13', 'TK013'),
('KH014', N'Đinh Văn Quý', N'Hà Nam', '0976543210', '2000-02-14', 'TK014'),
('KH015', N'Hoàng Thị Thu', N'Bắc Ninh', '0908765432', '2000-03-15', 'TK015');



-- Insert data into HoaDon
INSERT INTO HoaDon (MaHD, MaThe, DonGia) VALUES
('HD001', 'TK001', 50000),
('HD002', 'TK002', 65000),
('HD003', 'TK003', 75000),
('HD004', 'TK004', 80000),
('HD005', 'TK005', 55000),
('HD006', 'TK006', 70000),
('HD007', 'TK007', 85000),
('HD008', 'TK008', 60000),
('HD009', 'TK009', 72000),
('HD010', 'TK010', 68000),
('HD011', 'TK011', 50000),
('HD012', 'TK012', 65000),
('HD013', 'TK013', 75000),
('HD014', 'TK014', 80000),
('HD015', 'TK015', 55000);

-- Insert data into ChiTiet_HoaDon
INSERT INTO ChiTiet_HoaDon (MaHD, MaSach, NgayLap, MaCB) VALUES
('HD001', 'S001', '2023-01-15', 'CB001'),
('HD002', 'S002', '2023-02-20', 'CB002'),
('HD003', 'S003', '2023-03-25', 'CB003'),
('HD004', 'S004', '2023-04-30', 'CB004'),
('HD005', 'S005', '2023-05-05', 'CB005'),
('HD006', 'S006', '2023-06-10', 'CB006'),
('HD007', 'S007', '2023-07-15', 'CB007'),
('HD008', 'S008', '2023-08-20', 'CB008'),
('HD009', 'S009', '2023-09-25', 'CB009'),
('HD010', 'S010', '2023-10-30', 'CB010'),
('HD011', 'S011', '2023-11-05', 'CB011'),
('HD012', 'S012', '2023-12-10', 'CB012'),
('HD013', 'S013', '2024-01-15', 'CB013'),
('HD014', 'S014', '2024-02-20', 'CB014'),
('HD015', 'S015', '2024-03-25', 'CB015');
