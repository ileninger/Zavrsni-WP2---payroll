use master;
go

drop database if exists PayRoll;
go

create database PayRoll;
go

use Payroll;


create table Radnici (
radnikId int not null primary key identity (1,1),
Ime varchar (50) not null,
Prezime varchar (50) not null,
DatumZaposlenja date,
IBAN varchar (50) not null,
OiB char (11) not null
);

create table Obracun (
ObracunId int not null primary key identity (1,1),
DatumObracuna date not null,
BrojRadnihSati int not null,
CijenaRadnogSata decimal (18,2) not null,
IznosObracuna decimal (18,2) not null
);

create table Odbici (
OdbiciId int not null primary key identity (1,1),
UkupniOdbici decimal (18,2) not null,
OsnovicaZaObracun decimal (18,2) not null,
MiO_I decimal (18,2),
MiO_II decimal (18,2),
PorezNaDohodak decimal (18,2)
);

create table Placa (
Radnik int not null primary key,
IznosPlace decimal (18,2) not null,
Odbici decimal (18,2) not null,
Isplata decimal (18,2) not null
);

create table Isplata  (
IsplataId int not null primary key identity (1,1),
IznosIsplate decimal (18,2) not null
);