-- drop database dbBancoApp; --
create database dbBancoApp;
use dbBancoApp;
create table usuario
(
IdUsu int primary key auto_increment,
nomeUsu varchar(50) not null,
Cargo varchar(50) not null,
DataNasc datetime
);
/* insert into usuario(nomeUsu,Cargo,DataNasc)
 values('Robison','Gerente','1978-05-01'),
('Luisao','Colaborador','2000-12-10'); */
-- select * from usuario; --
create table cliente
(
IdCli int primary key auto_increment,
nomeCli varchar(50) not null,
DataNasc datetime
);
/* insert into cliente(nomeCli,DataNasc)
values('Jeferson',1987-03-20'),
('Jonathan','2000-01-27'); */
-- select * from cliente
