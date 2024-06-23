
# Perform sales software testing for Mini supermarkets

The project `Mini supermarket management software` is a software development project, with the purpose of building an employee, product, and order management system for mini supermarkets. The system will calculate costs based on the number of products that have been purchased, and provide management, reporting and statistics functions. In order for users to have a good experience when using it, it needs to be tested before being used more widely.

## Supermarket Management Application Installation Instructions
### Prerequisites
Before you begin, ensure you have the following software installed:

1. [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
   - Workload: `.NET Desktop Development`
2. [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
   - Ensure `SQL Server` is running and you have the necessary credentials.
3. [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

### Step-by-Step Installation Guide

**Step 1.** Clone the Repository

   First, clone the repository containing the application source code.

   ```bash
   git clone https://github.com/your-username/supermarket-management-app.git
   ```

**Step 2.** Create database

   Open `SQL Server Management Studio` (SSMS) and connect to your SQL Server instance.
   
   Create a new database by executing an SQL command [Create Database](https://github.com/Burhan-Q/ultralytics/edit/main/README.md)

## User Manual

## Features of the Supermarket Management Application
### Login
- Login for admin
- Login for sales staff
- Show and hide passwords
### Admin
- Overview
- Invoice Management
- Customer management
- Supplier management
- Employee manager
- Warehouse Management
- Log out

### Sales staff
- Make an invoice
- View invoice history
- See warehouse
- Change Password
- Log out

## Test Scope

- Log in
- Employee manager
- Product Management
- Order management
- Goods import management
- Main functions of the supermarket management system (Invoicing, statistics, etc.)


## Demo of some outstanding features of the product
#### Login for admin and staff

Use the account I provide below to log in with manager rights. If you want to log in with employee rights, create a new employee

```bash
admin account: admin
password: 1234
```

<img src="" width="800" alt="" />

#### Admin
##### Overview
##### Employee manager
#### Sales staff
##### Sales







##  White box testing

**Task 1.** Product search function

| Testcase   |  Function name                                          | Describe                                                         | Result |
|-------------|----------------------------------------------------|---------------------------------------------------------------|---------|
|  1  | Search_WithEmptySearchString_ShouldDoNothing        | Checks when the search string is empty                             | Passing |
|  2  | Search_WithMatchingSearchString_ShouldReturnResults | Checks when the search string matches an element             | Passing |
|  3  | Search_WithNonMatchingSearchString_ShouldReturnNoResults | Checks when the search string does not match any elements | Passing |
|  4  | Search_WithMultipleMatchingResults_ShouldReturnAllResults | Checks when there are multiple elements matching the search string        | Passing |
|  5  | Search_WithCaseInsensitiveSearchString_ShouldReturnResults | Checks when the search string is not case sensitive        | Failing |
|  6  | Search_WithSpecialCharacters_ShouldHandleGracefully | Checks when the search string contains special characters              | Passing |
|  7  | Search_WithPartialMatchingSearchString_ShouldReturnResults | Checks when the search string only partially matches the element    | Passing |
|  8  | Search_WithException_ShouldHandleGracefully         | Check when an exception occurs during a search        | Failing |
|  9  | Search_WithMatchingSearchString_ShouldReturnResul   | Check when adding leading and trailing spaces                 | Passing |

**Task 2.** Function to add products to invoice

**Task 3.** Invoice saving function

**Task 4.** Invoice search function

## <div align="left">Contact</div>

To report bugs and request features of software, please contact me for questions and discussion!
<br>
<div align="center">
  <a href="#"><img src="https://github.com/ultralytics/assets/raw/main/social/logo-social-github.png" width="3%" alt="Ultralytics GitHub"></a>
  <img src="https://github.com/ultralytics/assets/raw/main/social/logo-transparent.png" width="3%" alt="space">
  <a href="#"><img src="https://github.com/ultralytics/assets/raw/main/social/logo-social-linkedin.png" width="3%" alt="Ultralytics LinkedIn"></a>
  <img src="https://github.com/ultralytics/assets/raw/main/social/logo-transparent.png" width="3%" alt="space">
  <a href="#"><img src="https://github.com/ultralytics/assets/raw/main/social/logo-social-twitter.png" width="3%" alt="Ultralytics Twitter"></a>
  <img src="https://github.com/ultralytics/assets/raw/main/social/logo-transparent.png" width="3%" alt="space">
  <a href="#"><img src="https://github.com/ultralytics/assets/raw/main/social/logo-social-youtube.png" width="3%" alt="Ultralytics YouTube"></a>
  <img src="https://github.com/ultralytics/assets/raw/main/social/logo-transparent.png" width="3%" alt="space">
  <a href="#"><img src="https://github.com/ultralytics/assets/raw/main/social/logo-social-tiktok.png" width="3%" alt="Ultralytics TikTok"></a>
  <img src="https://github.com/ultralytics/assets/raw/main/social/logo-transparent.png" width="3%" alt="space">
  <a href="#"><img src="https://github.com/ultralytics/assets/raw/main/social/logo-social-instagram.png" width="3%" alt="Ultralytics Instagram"></a>
  <img src="https://github.com/ultralytics/assets/raw/main/social/logo-transparent.png" width="3%" alt="space">
  <a href="#"><img src="https://github.com/ultralytics/assets/raw/main/social/logo-social-discord.png" width="3%" alt="Ultralytics Discord"></a>
</div>
