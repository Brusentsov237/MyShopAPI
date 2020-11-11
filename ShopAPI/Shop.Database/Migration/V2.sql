if (select top(1) Version from dbo.DbVersion) is null 
insert into dbo.DbVersion values(sysutcdatetime(),1)

declare @dbVersion int 

Select top(1) @dbVersion = Version 
from dbo.DbVersion 
order by Created DESC
if @dbVersion >=2 set noexec on

CREATE TABLE [dbo].[Attribute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [AK_Attribute_Name] UNIQUE NONCLUSTERED ([Name] ASC)
)
GO

CREATE TABLE [dbo].[Value](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int]  NOT NULL,
	[AttributeId] [int]  NOT NULL,
	[Value] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Value] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [AK_Value_ProductId_AttributeId] UNIQUE NONCLUSTERED ([ProductId] ASC, [AttributeId] ASC)
)
GO

ALTER TABLE [dbo].[Value]  WITH CHECK ADD  CONSTRAINT [FK_Value_Attribute] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attribute] ([Id])
GO

ALTER TABLE [dbo].[Value] CHECK CONSTRAINT [FK_Value_Attribute]
GO

ALTER TABLE [dbo].[Value]  WITH CHECK ADD  CONSTRAINT [FK_Value_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[Value] CHECK CONSTRAINT [FK_Value_Product]
GO

CREATE proc [dbo].[GetValueFromProduct](@colname nvarchar(256), @id int)
as
    begin
        set nocount on
        DECLARE @SQL NVARCHAR(MAX)
        SET @SQL = 'SELECT Top(1)' + @colname +' FROM dbo.Product WHERE Id ='+ CONVERT(nvarchar(20), @Id)

		set @SQL += ' OPTION (RECOMPILE)'
		Print @SQL

        exec sp_executesql @SQL
    end
GO

insert into Attribute (Name)
SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'Product'
AND ORDINAL_POSITION > 8

DECLARE @ID INT
SELECT	@ID = MIN(Id)
FROM	Product

WHILE @ID IS NOT NULL
	BEGIN
		DECLARE @i INT = 9
		DECLARE @ColName nvarchar(20) = ''
		WHILE @ColName IS NOT NULL
			BEGIN
				SET @ColName = COL_NAME(OBJECT_ID('dbo.Product'), @i)

				DECLARE @table Table(Result nvarchar(20)) 
				INSERT INTO @table exec GetValueFromProduct @ColName, @ID

				DECLARE @Value  nvarchar(20)
				set @Value =(SELECT TOP(1) Result 
				FROM @table)
				delete from @table
				print @Value
				if @Value is not null
				INSERT INTO [dbo].[Value](ProductId, AttributeId, Value)
				SELECT	@ID, (Select Id from [dbo].[Attribute] where Name = @ColName), @Value
					
				set @i = @i+1

			END

		SELECT	@ID = MIN(Id)
		FROM	Product
		WHERE	Id > @ID

	END

ALTER TABLE Product DROP COLUMN 
Freezer,
HasFreshZone,
HasMicrowaveMod,
HasNoFrost,
HasSafetyShutDown,
HasSpit,
MaximumProductivity,
PanelMaterial,
PanelType,
ProgramQuantity,
SpeedModQuantity,
SwitchType,
VentingMod



insert into dbo.DbVersion values(sysutcdatetime(),2)

set noexec off