﻿use master;
go

drop database if exists ObracunPlace;
go

create database ObracunPlace;
go
alter database ObracunPlace collate Croatian_CI_AS;
go

use ObracunPlace;


create table Radnici (
	Radnik_Id int not null primary key identity (1,1),
	Ime varchar (50) not null,
	Prezime varchar (50) not null,
	DatumZaposlenja date,
	IBAN varchar (50) not null,
	OiB char (11) not null,
	Bruto decimal (18,2)
);

create table ObracunPlace (
	Obracun_Id int not null primary key identity (1,1),
	Radnik int not null,
	--Placa int not null,
	DatumObracuna date not null,
	BrojRadnihSati int not null,
	CijenaRadnogSata decimal (18,2) not null,
	Bruto decimal (18,2),
	Bruto_I decimal (18,2),
	Bruto_II decimal (18,2),
	NetoIznosZaIsplatu decimal (18,2)
);

create table Place (
	Placa_Id int not null primary key identity (1,1),
	Obracun_Id int not null,
	BrojObranuca varchar (20),
	NazivPlace varchar (50),
	DatumIsplate date
);

create table Administratori (
	Administratori_ID int primary key identity (1,1) not null,
	Ime varchar (50) not null,
	Lozimka varchar (100) not null
);

alter table ObracunPlace add foreign key (Radnik) references Radnici (Radnik_Id);
alter table Place add foreign key (Obracun_ID) references ObracunPlace(Obracun_Id);


insert into Radnici (Ime,Prezime,DatumZaposlenja,IBAN,OiB) values 
('Franjo', 'Petrović', '2012-09-01','HR9325000098729379235','45723332544'),
('Tia', 'Kovačić','2015-04-01','HR2023600008261495248','99901655051'),
('Josipa', 'Vuka','2019-02-01','HR7524020067469574373','72021555457'),
('Antun', 'Kovačević ','1980-11-28','HR6623400099338743687','98409772801'),
('Andrea', 'Bogdanović','1983-04-11','HR4523400097172597877','26995264267'),
('David', 'Bogdanić','1988-09-06','HR4425000098578479351','78470072871'),
('Ivor', 'Dragović','2018-03-15','HR3124840088942484887','53278892674'),
('Lucija', 'Perković','2023-06-05','HR1024840083333865143','33956449723'),
('Melani','Bogdanović','1997-10-03','HR9424020065391732569','29358686860'),
('Antonio', 'Tomić','2000-02-15','HR3023600004274822228','67962107374');

insert into ObracunPlace(Radnik,DatumObracuna,BrojRadnihSati,CijenaRadnogSata) values 
(1,'2023-10-31',176,15.00),
(2,'2023-10-31',176,12.00),
(3,'2023-10-31',176,7.00),
(4,'2023-10-31',176,13.50),
(5,'2023-10-31',176,12.20),
(6,'2023-10-31',176,6.00),
(7,'2023-10-31',176,9.50),
(8,'2023-10-31',176,20.00),
(9,'2023-10-31',176,10.00),
(10,'2023-10-31',176,8.75);

insert into Place(Obracun_Id) values 
(1),(1),(1),(1),(1),(1),(1),(1),(1),(1);



update ObracunPlace set Bruto=BrojRadnihSati*CijenaRadnogSata;
update ObracunPlace set Bruto_I = Bruto*0.15+Bruto*0.05;
update ObracunPlace set Bruto_II = ((Bruto-530.90)*0.24)*0.11+((Bruto-530.90)*0.24);
update ObracunPlace set NetoIznosZaIsplatu = Bruto-Bruto_I-Bruto_II;

update Place set BrojObranuca='2023-10';

update Place set NazivPlace = 'Placa za studeni 2023';

--select * from Place;

select a.Ime, a.Prezime,b.DatumObracuna,c.BrojObranuca,c.NazivPlace, b.BrojRadnihSati,b.CijenaRadnogSata,b.NetoIznosZaIsplatu
	from Radnici a inner join ObracunPlace b
	on a.Radnik_Id = b.Radnik
	inner join Place c on a.Radnik_Id=c.Placa_Id;

