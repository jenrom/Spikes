use master
DROP DATABASE Payments
CREATE  DATABASE Payments
USE Payments

CREATE TABLE PaymentMethods
(
	id int primary key identity(1,1),
	name varchar(50) not null,
	[status] tinyint  not null,
	registrationDate datetime not null,	
	holderName varchar(50) null,
	bankAccountNumber varchar(50) null,
	cardNumber char(16) null,
	cardHolderName varchar(40) null,
	cardType varchar(30) null,
	assignedToCustomerId int not null
)

CREATE TABLE Customers
(
	id int primary key identity(1,1),
	name varchar(50) not null,
	usedPaymentMethodId int,
	CONSTRAINT usedPaymentMethodId FOREIGN KEY (usedPaymentMethodId)
	REFERENCES PaymentMethods(id)
)

CREATE TABLE Contacts
(
	Id int primary key identity(1,1),
	Name varchar(255),
)

CREATE TABLE Adressses
(
	Id int primary key identity(1,1),
	Street varchar(255),
	ContactId int 
	CONSTRAINT contactAdress FOREIGN KEY (ContactId)
	REFERENCES Contacts(Id)
)


CREATE TABLE Services
(
	Id int Primary Key identity(1,1),
    Name varchar(255) not null,
    MonthlyFee decimal(2,2) not null,
    BoughtByCustomerId int not null
    CONSTRAINT serviceToCustomer FOREIGN KEY(BoughtByCustomerId)
    REFERENCES Customers(Id)
)

ALTER TABLE PaymentMethods ADD CONSTRAINT paymentMethodAssignedTo 
	FOREIGN KEY (assignedToCustomerId)
	REFERENCES Customers(id)