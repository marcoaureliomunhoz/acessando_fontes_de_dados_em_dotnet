create table Estado (
    UF      char(2) not null, 
    Nome    varchar(50), 
    constraint PK_Estado primary key (UF)
);
GO 

create table Contato (
    ContatoId   int not null identity, 
    Nome	    varchar(50), 
    Valor	    varchar(20), 
    UF          char(2), 
    constraint PK_Contato primary key (ContatoId), 
    constraint FK_Contato_Estado foreign key (UF) references Estado (UF)
); 
GO