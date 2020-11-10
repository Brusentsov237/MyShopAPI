

CREATE PROCEDURE [dbo].[Search_Order]
(
	@Id int = NULL,
	@CustomerId int = NULL,
	@SellDateFrom date =  N'2000-10-12',
	@SellDateTo date =  N'3000-10-12',
	@CityId int =  NULL
)
AS 
begin
DECLARE @resultSQL nvarchar (max) = '
	SELECT O.Id
      ,O.CustomerId
      ,O.SellDate
      ,O.CityId
	FROM [dbo].[Order] as O
    WHERE   (1=1)
	'
	if( @Id IS NOT NULL)
		begin 
			set @resultSQL += ' and O.[Id] = ' + CONVERT(nvarchar(10), @Id)
		end

	if( @CustomerId IS NOT NULL)
		begin
			set @resultSQL += ' and O.CustomerId = ' + CONVERT(nvarchar(10), @CustomerId)
		end

	if( @CityId IS NOT NULL)
		begin
			set @resultSQL += ' and O.CityId = ' + CONVERT(nvarchar(6), @CityId)
		end

	set @resultSQL += ' and (O.SellDate BETWEEN '+ '''' 
	+ CONVERT(nvarchar(20), @SellDateFrom) + ''' AND ' + '''' 
	+ CONVERT(nvarchar(20), @SellDateTo) + ''')'

	set @resultSQL += ' OPTION (RECOMPILE)'
	Print @resultSQL
	exec sp_executesql @resultSQL			
end
