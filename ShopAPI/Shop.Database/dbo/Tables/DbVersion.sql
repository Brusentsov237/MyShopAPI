create table [dbo].[DbVersion] 
(
   [Id] int NOT NULL PRIMARY KEY Identity (1,1),
    [Created]   datetime2 (0)  constraint DF_DbVersion_Created default sysutcdatetime() NOT NULL, 
    [Version] decimal(18,2)  not null 
);
