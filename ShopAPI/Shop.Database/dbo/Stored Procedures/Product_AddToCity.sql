
CREATE procedure [dbo].[Product_AddToCity]
	@productId int,
	@color nvarchar(6),
	@quantity int,
	@cityId int

  as
declare @CPId int = 0

  Select top(1) @CPId = cp.Id 
	from dbo.City_Product as cp
	where  @productId = cp.ProductId 
	and @cityId = cp.CityId
	and @color = cp.Color

if @CPId = 0 
	begin 
		insert into dbo.City_Product(productId,color,quantity,cityId)
		values(@productId, @color, @quantity, @cityId)

		select 'Return Value' = @quantity
	end
else 
	begin
		update City_Product
		set Quantity = Quantity + @quantity
		where Id = @CPId

		select 'Return Value' = Quantity
		from City_Product
		where Id = @CPId
	end
  
