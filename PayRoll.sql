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
radnikId int not null primary key identity (1,1),
Ime varchar (50) not null,
Prezime varchar (50) not null,
DatumZaposlenja date,
IBAN varchar (50) not null,
OiB char (11) not null
);

create table Obracun (
ObracunId int not null identity (1,1),
Radnik int not null,
DatumObracuna date not null,
BrojRadnihSati int not null,
CijenaRadnogSata decimal (18,2) not null,
IznosObracuna decimal(18,2) not null primary key
);

create table Odbici (
OdbiciId int not null identity (1,1),
UkupniOdbici decimal (18,2) not null primary key,
OsnovicaZaObracun decimal(18,2) not null,
MiO_I decimal (18,2),
MiO_II decimal (18,2),
PorezNaDohodak decimal (18,2)
);

create table Placa (
IznosPlace decimal (18,2) not null,
IznosOdbitaka decimal (18,2) not null,
IznosIsplate decimal (18,2) not null primary key
);

create table Isplata  (
IsplataId int not null primary key identity (1,1),
IznosIsplate decimal (18,2) not null
);

alter table Obracun add foreign key (Radnik) references Radnici (radnikId);
alter table Odbici add foreign key (OsnovicaZaObracun) references Obracun(IznosObracuna);
alter table Placa add foreign key (IznosPlace) references Obracun(IznosObracuna);
alter table Placa add foreign key (IznosOdbitaka) references Odbici(UkupniOdbici);
alter table Isplata add foreign key (IznosIsplate) references Placa(IznosIsplate);