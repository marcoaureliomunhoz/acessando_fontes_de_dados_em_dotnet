create table Editora (
    EditoraId           int not null identity, 
    Nome                varchar(100), 
    constraint PK_Editora primary key (EditoraId)
); 
GO 

create table Autor (
    AutorId             int not null identity, 
    Nome                varchar(100), 
    constraint PK_Autor primary key (AutorId)
); 
GO 

create table Livro (
    LivroId             int not null identity, 
    Titulo              varchar(100), 
    EditoraId           int, 
    constraint PK_Livro primary key (LivroId), 
    constraint FK_Livro__Editora foreign key (EditoraId) references Editora (EditoraId)
); 
GO 

create table Livro_Autor (
    LivroId             int not null, 
    AutorId             int not null, 
    constraint PK_Livro_Autor primary key (LivroId, AutorId), 
    constraint FK_Livro_Autor__Livro foreign key (LivroId) references Livro (LivroId), 
    constraint FK_Livro_Autor__Autor foreign key (AutorId) references Autor (AutorId)
); 
GO 
