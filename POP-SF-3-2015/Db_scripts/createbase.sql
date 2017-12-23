create table TipNamestaja (
	Id int primary key identity(1, 1),
	Naziv varchar(80),
	Opis varchar(80),
	Obrisan bit
)
go
create table Namestaj (
	Id int primary key identity(1, 1),
	TipNamestajaId int,
	AkcijaId int,
	Naziv varchar (100),
	Sifra varchar (50),
	Cena numeric(9, 2),
	Kolicina int,
	Obrisan bit,
	foreign key (TipNamestajaId) references TipNamestaja(Id)
)

create table TipKorisnika (
	Id int primary key identity(1, 1),
	Naziv varchar(80),
	Opis varchar(80),
	Obrisan bit
)
go
create table Korisnik (
	Id int primary key identity(1, 1),
	TipKorisnikaId int,
	Ime varchar (50),
	Prezime varchar (50),
	JMBG varchar (50),
	DatumRodjenja datetime,
	KorisnickoIme varchar (20),
	Lozinka varchar (20),
	active int,
	foreign key (TipKorisnikaId) references TipKorisnika(Id)
)
