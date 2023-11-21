use PayRoll;
go

delete from Radnici;
insert into Radnici (Ime,Prezime,DatumZaposlenja,IBAN,OiB) values 
('Franjo', 'Petrović', '2012-09-01','HR9325000098729379235','45723332544'),
('Tia', 'Kovačić','2015-04-01','HR2023600008261495248','99901655051'),
('Josipa', 'Vuka','2019-02-01','HR7524020067469574373','72021555457');
select * from Radnici;

insert into ObracunPlace(Radnik,DatumObracuna,BrojRadnihSati,CijenaRadnogSata) values 
(1,'2023-10-31',176,15.00),
(2,'2023-10-31',176,12.00),
(3,'2023-10-31',176,7.00);

update ObracunPlace set Bruto=BrojRadnihSati*CijenaRadnogSata;
update ObracunPlace set Bruto_I = Bruto*0.15+Bruto*0.05;
update ObracunPlace set Bruto_II = ((Bruto-530.90)*0.24)*0.11+((Bruto-530.90)*0.24);
update ObracunPlace set Neto_IznosZaIsplatu = Bruto-Bruto_I-Bruto_II;
select * from ObracunPlace;