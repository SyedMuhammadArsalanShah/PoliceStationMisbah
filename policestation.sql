create database policestation
use policestation

Create table Casetb1(
CNum int identity(1,1) primary key not null,
Ctype varchar(100),
Cheading varchar(150),
CDetail varchar(150),
Cplace varchar(150),
CDate Date,
Cperson int,
CpersonName varchar(100),
polcode int,
polname varchar (50)
CONSTRAINT [FK1] FOREIGN KEY ([Cperson]) REFERENCES [criminaltb1]([Crcode]),
CONSTRAINT [FK3] FOREIGN KEY ([polcode]) REFERENCES [policetb1]([Empcode])

); 

create table policetb1(

Empcode int identity(1,1) primary key not null,
EmpName varchar(50),
EmpAddress varchar(150),
EmpPhone varchar(20),
EmpDes varchar(50),
EmpPass varchar(50)
);

create table criminaltb1(
Crcode int identity(1,1) primary key not null,
CrName varchar(50),
CrAdd varchar(150),
CrActivities varchar(200)
);

create table chargetb1(
CrNum int identity(1,1) primary key not null,
CaseCode int not null,
CaseHeading varchar(150),
ChargeSheet varchar(230),
Remarks varchar(230),
polcode int not null,
polname varchar(504)
CONSTRAINT [FK2] FOREIGN KEY ([polcode]) REFERENCES [policetb1]([Empcode])

);