insert into TipNamestaja (Naziv, Opis, Obrisan) values ('Krevet', 'bracni', 0);
insert into TipNamestaja (Naziv, Opis, Obrisan) values ('sto', 'trpezarijski', 0);
insert into TipNamestaja (Naziv, Opis, Obrisan) values ('kauc', 'ugaona', 0);

insert into Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) values (1, 'francuski Krevet','bracni', 123.5, 22, 0);
insert into Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) values (2, 'sofija ugaona','kauc', 343.5, 42, 0);
insert into Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan) values (3, 'ivan kauc','sto', 554.5, 33, 0);

insert into TipKorisnika (Naziv, Opis, Obrisan) values ('admin', 'admin1', 0);

insert into dbo.Korisnik (TipKorisnikaId, Ime, Prezime, JMBG, DatumRodjenja, KorisnickoIme, Lozinka, active) values (1, 'aca','miladin','1234','1995-02-11','a','m',1)

