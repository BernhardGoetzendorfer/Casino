--create database dbCasino_IN19

use dbCasino_IN19

--drop table tblSpiel
--drop table tblBegriff
--drop table tblKategorie
--drop table tblHighscore
--drop table tblqrcode

create table tblkategorie
(
	IDKategorie int identity(1,1) primary key,
	Kategorie varchar(100) not null unique
)

create table tblBegriff
(
	IDBegriff int identity(1,1) primary key,
	Begriff varchar(30) not null check(len(begriff)>=6 and len(begriff) <= 14),
	FKKategorie int  not null foreign key references tblkategorie
)

create table tblSpiel
(
	IDSpiel int identity(1,1) primary key,
	Spiel varchar(30) not null,
	Ovocoin float not null check(Ovocoin>=0)
)

create table tblHighscore
(
	IDHighscore int identity(1,1) primary key,
	FKSpiel int foreign key references tblspiel,
	Spieler varchar(30) not null,
	Punkte float not null check(Punkte >0 ),
	Datum smalldatetime not null default (getdate())
)
 

/* QR Code ist noch sehr fiktiv , nur ein erstvorschlag */

create table tblQRCode
(
	QRBAN char(14) not null primary key,
	Ovocoin float not null,
	Eingeloggt bit not null default(0),
	Datum smalldatetime not null default (getdate())
)

--für Ersteintrag damit DB nicht leer

Insert into tblQRCode(QRBAN,Ovocoin)
Values
('1111-1111-1111',0)

Insert into tblKategorie(Kategorie)
Values
('Serien Star'),
('Schauspieler'),
('Chemie'),
('Sportler'),
('Physik')

Insert into tblBegriff(Begriff,Fkkategorie)
Values
('Ichabod Crane',1),
('Dr House',1),
('Al Bundy',1),
('Nicolas Cage',2),
('Brad Pitt',2),
('Johnny Depp',2),
('Oxidation',3),
('Reduktion',3),
('Filtration',3),
('David Alaba',4),
('Michael Jordan',4),
('Lindsy Vonn',4),
('Hygroskopie',5),
('Graviton',5),
('Steifigkeit',5)


insert into tblSpiel(Spiel,Ovocoin)
values
('Gluecksrad',1),
('Escalero',1),
('Slotmaschine',1),
('Roulette',1)


