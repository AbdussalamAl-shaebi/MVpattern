# MVpattern
MVpattern,Design pattern ,C#,SqlServer
#-C# .net 3.5
#-sqlserver 2014

#Procedure spBooks
#database name LlibraryDB
#table name Books(BookId int,BookName nvarchar 50)

create PROCEDURE spBooks 
	@BookId int =null, 
	@BookName nvarchar(50) =null,
	@OperationsType int =null
AS
if @OperationsType = 1
	INSERT INTO dbo.Books
           (BookId
           ,BookName)
     VALUES
           (@BookId
           ,@BookName)

else if @OperationsType = 2
	UPDATE dbo.Books
		SET BookName = @BookName
		where BookId = @BookId

else if @OperationsType = 3
		DELETE FROM [dbo].[Books]
		where [BookId] = @BookId


else if @OperationsType = 4
		SELECT [BookId]
			,[BookName]
		FROM [dbo].[Books
