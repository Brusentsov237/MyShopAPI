
CREATE PROCEDURE [dbo].[Search_Product]
(
	@Id INT = NULL,
	@Name	nvarchar(20)	= NULL,
	@ManufacturerId	int	= NULL,
	@PriceMin	decimal(18, 2)	= 1,
	@PriceMax	decimal(18, 2)	= 10000000000,

	@CityId int	= NULL,
	@Color nvarchar(6)	= NULL,

	@Freezer	nvarchar(6)	= NULL,
	@HasNoFrost	bit	= NULL,
	@HasFreshZone	bit	= NULL,
	@HasSafetyShutDown	bit	= NULL,
	@HasSpit	bit	= NULL,
	@HasMicrowaveMod	bit	= NULL,
	@SwitchType	nvarchar(12)	= NULL,
	@SpeedModQuantity	int	= NULL,
	@VentingMod	nvarchar(12)	= NULL,
	@MaximumProductivity	int	= NULL,
	@ProgramQuantity	int	= NULL,
	@PanelMaterial	nvarchar(20)	= NULL,
	@PanelType	nvarchar(20)	= NULL
)
AS 
begin
DECLARE @resultSQL nvarchar (max) = '
	SELECT P.Id
      ,P.Name
      ,P.ManufacturerId
      ,P.Price
	  ,P.Weight
      ,P.Xrange
      ,P.Yrange
      ,P.Zrange
      ,P.Freezer
      ,P.HasNoFrost
      ,P.HasFreshZone
      ,P.HasSafetyShutDown
      ,P.HasSpit
      ,P.HasMicrowaveMod
      ,P.SwitchType
      ,P.SpeedModQuantity
      ,P.VentingMod
      ,P.MaximumProductivity
      ,P.ProgramQuantity
      ,P.PanelMaterial
      ,P.PanelType
	  ,cp.Id
	  ,cp.CityId
	  ,cp.Color
	  ,cp.Quantity
  FROM [dbo].[Product] as P
	left join [dbo].[City_Product] as cp on cp.ProductId = P.Id
    WHERE   (1=1)
	'
	if( @Id IS NOT NULL)
		begin 
			set @resultSQL += ' and P.[Id] = ' + CONVERT(nvarchar(20), @Id)
		end

	if( @Name IS NOT NULL)
		begin
			set @resultSQL += ' and P.Name LIKE ' + '''%' + CONVERT(nvarchar(50), @Name) + '%'''
		end

	if( @ManufacturerId IS NOT NULL)
		begin
			set @resultSQL += ' and P.ManufacturerId = ' + CONVERT(nvarchar(6), @ManufacturerId)
		end

	if( @PriceMin IS NOT NULL and @PriceMax IS NOT NULL)
		begin
			set @resultSQL += ' and P.Price BETWEEN ' + 
			'''' + CONVERT(nvarchar(20), @PriceMin) + '''' + 'AND'+
			'''' + CONVERT(nvarchar(20), @PriceMax) + ''''
		end	

	if( @CityId IS NOT NULL)
		begin
			set @resultSQL += ' and cp.CityId = ' + CONVERT(nvarchar(6), @CityId)
		end

	if( @Color IS NOT NULL)
		begin
			set @resultSQL += ' and cp.Color = ''' + CONVERT(nvarchar(6), @Color) +''''
		end

	if( @Freezer IS NOT NULL)
		begin
			set @resultSQL += ' and P.Freezer = ''' + CONVERT(nvarchar(6), @Freezer) +''''
		end

	if( @HasNoFrost IS NOT NULL)
		begin
			set @resultSQL += ' and P.HasNoFrost = ' + CONVERT(nvarchar(6), @HasNoFrost)
		end

	if( @HasFreshZone IS NOT NULL)
		begin
			set @resultSQL += ' and P.HasFreshZone = ' + CONVERT(nvarchar(6), @HasFreshZone)
		end

	if( @HasSafetyShutDown IS NOT NULL)
		begin
			set @resultSQL += ' and P.HasSafetyShutDown = ' + CONVERT(nvarchar(6), @HasSafetyShutDown)
		end

	if( @HasSpit IS NOT NULL)
		begin
			set @resultSQL += ' and P.HasSpit = ' + CONVERT(nvarchar(6), @HasSpit)
		end

	if( @HasMicrowaveMod IS NOT NULL)
		begin
			set @resultSQL += ' and P.HasMicrowaveMod = ' + CONVERT(nvarchar(6), @HasMicrowaveMod)
		end

	if( @SwitchType IS NOT NULL)
		begin
			set @resultSQL += ' and P.SwitchType = ''' + CONVERT(nvarchar(15), @SwitchType) + ''''
		end

	if( @SpeedModQuantity IS NOT NULL)
		begin
			set @resultSQL += ' and P.SpeedModQuantity = ' + CONVERT(nvarchar(3), @SpeedModQuantity)
		end

	if( @VentingMod IS NOT NULL)
		begin
			set @resultSQL += ' and P.VentingMod = ''' + CONVERT(nvarchar(15), @VentingMod) + ''''
		end

	if( @MaximumProductivity IS NOT NULL)
		begin
			set @resultSQL += ' and P.MaximumProductivity = ' + CONVERT(nvarchar(8), @MaximumProductivity)
		end

	if( @ProgramQuantity IS NOT NULL)
		begin
			set @resultSQL += ' and P.ProgramQuantity = ' + CONVERT(nvarchar(6), @ProgramQuantity)
		end

	if( @PanelMaterial IS NOT NULL)
		begin
			set @resultSQL += ' and P.PanelMaterial = ''' + CONVERT(nvarchar(20), @PanelMaterial) + ''''
		end

	if( @PanelType IS NOT NULL)
		begin
			set @resultSQL += ' and P.PanelType = ''' + CONVERT(nvarchar(20), @PanelType) + ''''
		end
	
		set @resultSQL += ' OPTION (RECOMPILE)'
		Print @resultSQL
		exec sp_executesql @resultSQL			
end
