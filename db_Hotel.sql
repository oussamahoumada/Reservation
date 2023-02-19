create database Db_Hotel
go
use Db_Hotel
go
create table Client (
CIN varchar(50) primary key,
Nom varchar(50),
Tel varchar(50)
)
go
create table Maison (
id_Maison int IDENTITY(1,1) primary key,
Num int,
)
go
create table Reservation (
Id_Reservation int IDENTITY(1,1) primary key,
CIN varchar(50) references Client(CIN) ON DELETE CASCADE ON update CASCADE,
id_Maison int references Maison(id_Maison) ON DELETE CASCADE ON update CASCADE,
dateDebut date,
dateFin date,
avance float,
date_reservation date,
prix float,
etat bit,
duree as datediff(day,dateDebut,dateFin)
)
go
create table Pertes (
Id_Pert int IDENTITY(1,1) primary key ,
Descrip varchar(255), 
datePert date,
valeur float
)

create view selectAll as 
select  CIN,id_Maison,prix,avance,(prix-avance)as 'Reste',dateDebut,dateFin ,datediff(day,dateDebut,dateFin) as "durre",etat from Reservation