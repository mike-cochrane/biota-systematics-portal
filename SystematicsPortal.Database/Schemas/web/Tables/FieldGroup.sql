CREATE TABLE [web].[FieldGroup](
	[FieldGroupId] [uniqueidentifier] NOT NULL,
	[DocumentClass] nvarchar(100) NOT NULL,
	[DisplayTitle] nvarchar(200) NULL,
	[Name] nvarchar(200) NOT NULL,
	[DisplayOrder] [int] NULL,
	[DisplayFormat]  [nvarchar](250) NULL,
 CONSTRAINT [[prkFieldGroup] PRIMARY KEY CLUSTERED ([FieldGroupId] ASC),
 );

