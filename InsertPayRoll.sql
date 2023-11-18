use PayRoll;
go

delete from Radnici;
insert into Radnici (Ime,Prezime,DatumZaposlenja,IBAN,OiB)
values ('Mirko', 'Miric', '2023-01-01','HR148617543','13456789101');

insert into ObracunRadnihSati (Radnik, DatumObracuna,BrojRadnihSati,CijenaRadnogSata, IznosObracuna)
values (1,'2023-10-31',176,50.00,8800.00);

insert into Odbici (Radnik,UkupniOdbici)
values (1,3000.00);

insert into Placa (ObracunSatiId,OdbiciId,IznosIsplate)
values (1,1,5800.00);

insert into Isplata (Radnik,PlacaId,IznosIsplate)
values (1,1,5800.00);