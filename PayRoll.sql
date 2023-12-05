use master;
go

drop database if exists PayRoll;
go

create database PayRoll;
go
alter database PayRoll collate Croatian_CI_AS;
go

use Payroll;


create table Radnici (
Radnik_Id int not null primary key identity (1,1),
Ime varchar (50) not null,
Prezime varchar (50) not null,
DatumZaposlenja date,
IBAN varchar (50) not null,
OiB char (11) not null
);

create table ObracunPlace (
Obracun_Id int not null primary key identity (1,1),
Radnik int not null,
DatumObracuna date not null,
BrojRadnihSati int not null,
CijenaRadnogSata decimal (18,2) not null,
Bruto decimal(18,2),
Bruto_I decimal(18,2),
Bruto_II decimal (18,2),
Neto_IznosZaIsplatu decimal (18,2)
);

create table Place (
Placa_Id int not null primary key identity (1,1),
Broj_Obracuna char(20),
NazivPlace varchar (50),
Bruto decimal (18,2),
Neto_IznosZaIsplatu decimal (18,2)
);

create table Isplate  (
Isplata_Id int not null primary key identity (1,1),
Placa_Id int not null,
Radnik int not null,
Neto_IznosZaIsplatu decimal (18,2) not null
);

alter table ObracunPlace add foreign key (Radnik) references Radnici (radnik_Id);
alter table Isplate add foreign key (Radnik) references Radnici (radnik_Id);
alter table Place add foreign key (Obracun_Id) references ObracunPlace(Obracun_Id);
alter table Isplate add foreign key (Placa_Id) references Place(Placa_Id);