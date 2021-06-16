Create Database BookDb
go 

use BookDb

create table tbl_Author
(
AuthorID int identity (1,1),
AuthorName varchar(20),
Constraint Pk_auth Primary key (AuthorID)
)
create table tbl_Books 
(
BookID int identity(1000,1),
Title varchar(50),
AuthorID int ,
Price money,
constraint PK_book Primary key (BookID),
constraint Fk_auth Foreign key (AuthorID)
references tbl_Author (AuthorID)
)
go

create proc sp_InsBook@Title varchar(20),@AuthorID int,@Price moneyasBegininsert into tbl_Books(Title, AuthorID,Price) values(@Title, @AuthorID, @Price)End
 
Exec sp_InsBook @Title='parthiban kanavu' , @AuthorID=2 , @Price=200
Exec sp_InsBook 'parthiban kanavu' , 2 , 200
 
 
create proc sp_InsertBook@Title varchar(20),@AuthorID int,@Price moneyasBegininsert into tbl_Books(Title, AuthorID,Price) values(@Title, @AuthorID, @Price)End
 
Exec sp_InsBook @Title='parthiban kanavu' , @AuthorID=2 , @Price=200

create proc sp_UpdateBook@BookID int,@Price moneyasBeginupdate tbl_Books set Price=@Price where BookID= @BookIDEnd

create proc sp_DeleteBook@BookID intasBeginDelete from tbl_Books where BookID=@BookIDEnd
 

 create  proc sp_InsertAuthor
@AuthorName varchar(20)
as
Begin
insert into tbl_author(AuthorName)
values(@AuthorName)
End

exec sp_InsertAuthor 'Mother Teresa'


create proc sp_UpdateAuthor
@AuthorID int,
@AuthorName varchar(20)
as
Begin
update tbl_author set AuthorName=@AuthorName where AuthorID=@AuthorID
End

exec  sp_UpdateAuthor 4,'Mahatma Gandhi'



create proc sp_DeleteAuthor
@AuthorID int
as
Begin
delete from tbl_author where AuthorID=@AuthorID
End

exec  sp_DeleteAuthor 4

 select * from tbl_Author
 select * from tbl_Books

 create table Movies
(
No int identity (1,1),
Movies varchar(20),
)

 alter database BookDb
 set Recursive_Triggers on