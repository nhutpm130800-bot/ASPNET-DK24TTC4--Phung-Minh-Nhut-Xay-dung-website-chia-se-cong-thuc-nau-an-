# ASPNET-DK24TTC4--Phung-Minh-Nhut-Xay-dung-website-chia-se-cong-thuc-nau-an-

# ĐỒ ÁN CHUYÊN ĐỀ ASP.NET - WEBSITE CHIA SẺ CÔNG THỨC NẤU ĂN

## 1. Thông tin sinh viên
* **Họ và tên:** Phùng Minh Nhựt
* **Mã số sinh viên:** 170124430
* **Lớp:** DK24TTC4
* **Email liên lạc:** nhutpm130800@tvu-onschool.edu.vn
* **Giảng viên hướng dẫn:** Thầy Đoàn Phước Miền 

## 2. Giới thiệu đề tài
Website được xây dựng trên nền tảng ASP.NET Core MVC nhằm cung cấp không gian cho người dùng chia sẻ, tìm kiếm và quản lý các công thức nấu ăn trực tuyến.
* **Chức năng chính:** Đăng ký/Đăng nhập (Identity), Quản lý món ăn (CRUD), Phân loại món ăn theo danh mục.

## 3. Cấu trúc Repository
Dự án được tổ chức theo quy định của trường TVU:
* `/src`: Chứa mã nguồn chương trình ASP.NET.
* `/setup`: Chứa file script SQL để khởi tạo Database.
* `/thesis`: Chứa báo cáo đồ án (định dạng .doc và .pdf).
* `/progress-report`: Chứa báo cáo tiến độ hàng tuần.

## 4. Hướng dẫn cài đặt và chạy chương trình
1. **Database:** Mở SQL Server Management Studio, chạy file script trong thư mục `setup`.
2. **Cấu hình:** Mở file `appsettings.json` trong thư mục `src`, sửa lại `ConnectionString` cho khớp với SQL Server của máy.
3. **Chạy ứng dụng:** Mở file `.slnx` (hoặc `.sln`) bằng Visual Studio 2026, nhấn `F5` để khởi chạy.

## 5. Công nghệ sử dụng
* ASP.NET Core MVC.
* Entity Framework Core (Database First/Code First).
* SQL Server.
