use master;
go

drop database if exists ObracunPlace;
go

create database ObracunPlace;
go
alter database ObracunPlace collate Croatian_CI_AS;
go

use ObracunPlace;

create table Radnici (
	Sifra int not null primary key identity (1,1),
	Ime varchar (50) not null,
	Prezime varchar (50) not null,
	OiB char (11) not null,
	DatumZaposlenja date,
	IBAN varchar (50) not null,
);

create table Obracun(
	Sifra int not null primary key identity (1,1),
	Radnik int not null,
	DatumObracuna date not null,
	BrojRadnihSati int not null,
	CijenaRadnogSata decimal (18,2) not null,
	KoeficijentRadnogMjesta decimal (18,2) not null,
	OsnovniOsobniOdbitak decimal (18,2) not null,
	UdioZaPrviMirovinskiStup decimal (18,2) not null,
	UdioZaDrugiMirovinskiStup decimal (18,2) not null,
	PorezNaDohodak decimal (18,2) not null,
	PoreznaOsnovica decimal (18,2) not null,
	Bruto decimal (18,2),
	Bruto_I decimal (18,2),
	Bruto_II decimal (18,2),
	NetoIznosZaIsplatu decimal (18,2)
);

create table Place (
	Sifra int not null primary key identity (1,1),
	Obracun int not null,
	NazivPlace varchar (50),
);

create table Administratori (
	Administratori_ID int primary key identity (1,1) not null,
	Ime varchar (50) not null,
	Lozimka varchar (100) not null
);

alter table Obracun add foreign key (Radnik) references Radnici (Sifra);
alter table Place add foreign key (Obracun) references Obracun(Sifra);
