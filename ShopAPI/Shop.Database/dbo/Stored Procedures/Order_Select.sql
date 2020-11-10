

CREATE procedure [dbo].[Order_Select]
	@Id int

  as

SELECT o.Id
      ,o.CustomerId
      ,o.SellDate
      ,o.CityId
	  ,op.Id
	  ,op.ProductId
	  ,op.OrderId
	  ,op.Color
	  ,op.Quantity
  FROM [Order] as o
  left join Order_Product as op on o.Id = op.OrderId
  where o.Id = @Id


