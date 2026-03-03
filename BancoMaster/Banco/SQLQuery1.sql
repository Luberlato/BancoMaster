create database BancoMaster
go

use BancoMaster
go

create table Usuario(
	UsuarioId int identity primary key,
	CPF nvarchar(15) not null unique,
	Nome nvarchar(200) not null unique,
	Email nvarchar(150) not null,
	Senha varbinary(32)not null,
)

create table Conta(
	ContaId int identity primary key,
	UsuarioId int foreign key references Usuario(UsuarioId),
	Saldo decimal(18, 2) not null
)

create table Transacao(
	TransacaoId int identity primary key,
	EnviadorId int foreign key references Usuario(UsuarioId),
	RepecetorId int foreign key references Usuario(UsuarioId),
	Valor decimal (18, 2)
)

                          



