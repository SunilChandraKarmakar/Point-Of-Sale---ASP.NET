create database POS_Web

create table Country
(
	ID int identity primary key,
	CountryName varchar(15) not null unique
)

create table City
(
	ID int identity primary key,
	CityName varchar(15) not null,
	CountryID int not null,
	foreign key (CountryID) references Country(ID)
)

create  table Employee
(
	ID int identity primary key,
	EmployeeName varchar(30) not null,
	EmployeeContact varchar(20) not null unique,
	EmployeeEmail varchar(30) not null unique,
	EmployeePassword varchar(200) not null,
	EmployeeGender bit not null,
	EmployeeJoinDate date not null,
	EmployeeDateOfBirth date not null,
	EmployeeAddress varchar(1000) not null,
	EmployeeCityID int,
	EmployeePicture varchar(1000) not null
	foreign key (EmployeeCityID) references City(ID)
)

create table EmployeeAdmin
(
	EmployeeID int,
	foreign key (EmployeeID) references Employee(ID)
)

create table Brand
(
	ID int identity primary key,
	BrandName varchar(20) not null unique,
	Origin varchar(50) not null
)

create table Category
(
	ID int identity primary key,
	CategoryName varchar(30) not null unique,
	CategoryDescription varchar(200) not null,
	CategoryID int,
	foreign key(CategoryID) references Category(ID)
)

create table Unit
(
	ID int identity primary key,
	UnitName varchar(20) not null unique,
	UnitDescription varchar(50) not null,
	UnitPrimaryQty int not null
)

create table Product
(
	ID int identity primary key,
	ProductName varchar(20) not null unique,
	ProductCode varchar(20) not null unique,
	ProductQuentity int not null,
	ProductDescription varchar(200) not null,
	ProductPosition varchar(200) not null,
	CategoryID int not null,
	BrandID int not null,
	foreign key (CategoryID) references Category(ID),
	foreign key (BrandID) references Brand(ID)
)

create table ProductPrice
(
	ID int identity primary key,
	ProductID int not null,
	ProductPrice float not null,
	foreign key (ProductID) references Product(ID)
)

create table ProductImage
(
	ID int identity primary key,
	ProductID int not null,
	ProductImage varchar(2000),
	ProductTitle varchar(50),
	foreign key (ProductID) references Product(ID)
)