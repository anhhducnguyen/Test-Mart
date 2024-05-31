#  Kiểm thử hộp trắng

### Các trường hợp kiểm thử ở đây được tạo cho các mô hình và biểu mẫu của ứng dụng quản lý siêu thị mini:

#### 1. Chức năng tìm kiếm sản phẩm
![img](https://github.com/AnhNguyen7303/TestMart/blob/main/imageTest/SearchProductTests.png)
| Test case | Tên func                                           | Mô tả                                                         | Kết quả |
|-----------|----------------------------------------------------|---------------------------------------------------------------|---------|
| Testcase1 | Search_WithEmptySearchString_ShouldDoNothing        | Kiểm tra khi chuỗi tìm kiếm rỗng                             | Passing |
| Testcase2 | Search_WithMatchingSearchString_ShouldReturnResults | Kiểm tra khi chuỗi tìm kiếm khớp với một phần tử             | Passing |
| Testcase3 | Search_WithNonMatchingSearchString_ShouldReturnNoResults | Kiểm tra khi chuỗi tìm kiếm không khớp với bất kỳ phần tử nào | Passing |
| Testcase4 | Search_WithMultipleMatchingResults_ShouldReturnAllResults | Kiểm tra khi có nhiều phần tử khớp với chuỗi tìm kiếm        | Passing |
| Testcase5 | Search_WithCaseInsensitiveSearchString_ShouldReturnResults | Kiểm tra khi chuỗi tìm kiếm không phân biệt hoa thường        | Failing |
| Testcase6 | Search_WithSpecialCharacters_ShouldHandleGracefully | Kiểm tra khi chuỗi tìm kiếm chứa ký tự đặc biệt              | Passing |
| Testcase7 | Search_WithPartialMatchingSearchString_ShouldReturnResults | Kiểm tra khi chuỗi tìm kiếm chỉ khớp một phần với phần tử    | Passing |
| Testcase8 | Search_WithException_ShouldHandleGracefully         | Kiểm tra khi xảy ra ngoại lệ trong quá trình tìm kiếm        | Failing |
| Testcase9 | Search_WithMatchingSearchString_ShouldReturnResul   | Kiểm tra khi thêm khoảng trắng ở đầu và cuối                 | Passing |
#### 2. Chức năng thêm sản phẩm vào hóa đơn
![img](https://github.com/AnhNguyen7303/TestMart/blob/main/imageTest/UpdateThongTinMatHangTests.png)
#### 3. Chức năng lưu hóa đơn
#### 4. Chức năng tìm kiếm hóa đơn
