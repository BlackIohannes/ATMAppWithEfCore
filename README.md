# Bank ATM App Using Ef Core
This is a simple console application for a bank ATM that allows users to register, login, and perform various account transactions such as withdrawing funds, making deposits, transferring funds to other accounts, and checking account balances.

## Features
1. User registration and login
2. Withdraw funds from user account
3. Deposit funds into user account
4. Transfer funds to other accounts
5. Check account balance

## Getting Started
### Prerequisites
### [.Net 5+](https://dotnet.microsoft.com/en-us/)

### Installation
1. Clone the repository to your local machine:
```csharp
git clone https://github.com/your-username/bank-atm-app.git
```
2. Navigate to the project directory:
```csharp
cd bank-atm-app
```
3. Run the project:
```csharp
dotnet run
```
### Usage
1. When the application starts, you will be presented with the main menu:
```csharp
Welcome to the Bank ATM App!

1. Login
2. Register
3. Exit

Please enter your choice:
```
2. To register a new user account, select option "2" from the main menu and follow the prompts to enter your name, email, and password.
3. To log in to an existing user account, select option "1" from the main menu and enter your email and password when prompted.
4. After logging in, you will be presented with the account options menu:
```csharp
Welcome, John Doe!

1. Deposit
2. Withdraw
3. Transfer
4. Check Balance
5. Logout

Please enter your choice:
```
5. Select an option from the account options menu to perform the desired transaction. For example, to make a deposit, select option "1" and follow the prompts to enter the deposit amount.
6. After completing the transaction, you will be returned to the account options menu. To log out, select option "5" from the account options menu.

### Built With
1. C# console app
2. Entity Framework Core for database management

### Author
Chukwu, Chidiebere John

### License
This project is licensed under the MIT License.
