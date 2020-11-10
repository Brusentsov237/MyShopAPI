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









insert into dbo.DbVersion values(sysutcdatetime(),2)

set noexec off