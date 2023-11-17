use master;
go

drop database if exists PayRoll;
go

create database PayRoll;
go

use Payroll;


create table radnici (
sifra int not null primary key identity (1,1),
ime varchar (50) not null,
prezime varchar (50) not null,
iban varchar (50) not null,
zaposlenOd date not null
);

create table placa (
sifra int not null primary key identity (1,1),
radnik int not null,
naziv varchar (50) not null,
obracunskoRazdoblje date not null,
isplata int
);

create table iznosZaIsplatu(
bruto decimal (18,2) not null,
neto decimal (18,2) not null,
dodaci decimal (18,2) not null,
obustave decimal (18,2) not null,
ukupanIznosZaIsplatu int
);

alter table placa add foreign key (radnik) references radnici (sifra);
alter table placa add foreign key (isplata) references  iznosZaIsplatu (ukupanIznosZaIsplatu);