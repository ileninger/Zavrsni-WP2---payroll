use edunovawp2;
go

drop database if exists PayRoll;
go

create database PayRoll;
go
alter database PayRoll collate Croatian_CI_AS;
go

use Payroll;


create table Radnici (
RadnikId int not null primary key identity (1,1),
Ime varchar (50) not null,
Prezime varchar (50) not null,
DatumZaposlenja date,
IBAN varchar (50) not null,
OiB char (11) not null
);

create table ObracunPlace (
ObracunId int not null primary key identity (1,1),
Radnik int not null,
DatumObracuna date not null,
BrojRadnihSati int not null,
CijenaRadnogSata decimal (18,2) not null,
IznosObracuna decimal(18,2) not null
);

--create table Odbici (
--OdbiciId int not null primary key identity (1,1),
--Radnik int not null,
--UkupniOdbici decimal (18,2) not null,
--OsnovicaZaObracun decimal(18,2),
--MiO_I decimal (18,2),
--MiO_II decimal (18,2),
--PorezNaDohodak decimal (18,2)
--);

create table Place (
PlacaId int not null primary key identity (1,1),
ObracunSatiId int not null,
OdbiciId int not null,
--IznosPlace decimal (18,2) not null,
--IznosOdbitaka decimal (18,2) not null,
NazivPlace varchar (50),
IznosIsplate decimal (18,2) not null
);

create table Isplate  (
IsplataId int not null primary key identity (1,1),
Radnik int not null,
PlacaId int not null,
IznosIsplate decimal (18,2) not null
);

alter table ObracunPlace add foreign key (Radnik) references Radnici (radnikId);
--alter table Odbici add foreign key (Radnik) references Radnici (radnikId);
alter table Isplate add foreign key (Radnik) references Radnici (radnikId);
alter table Place add foreign key (ObracunSatiId) references ObracunPlace(ObracunId);
--alter table Place add foreign key (OdbiciId) references Odbici(OdbiciId);
alter table Isplate add foreign key (PlacaId) references Place(PlacaId);
