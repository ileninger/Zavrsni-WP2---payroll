use PayRoll;
go

delete from Radnici;
insert into Radnici (RadnikId,Ime,Prezime,DatumZaposlenja,IBAN,OiB)
values (1,'Mirko', 'Miric', '2023-01-01','HR148617543','13456789101');

insert into ObracunRadnihSati (Radnik, DatumObracuna,BrojRadnihSati,CijenaRadnogSata, IznosObracuna)
values (1,'2023-10-31',176,50.00,8800.00);
