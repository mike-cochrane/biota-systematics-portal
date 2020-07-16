CREATE TABLE [web].[FieldConfiguration](
	[FieldConfigurationId] [uniqueidentifier] NOT NULL,
	[DocumentClass] nvarchar(200) NULL,
	[DataDocumentXPath]  [nvarchar](500) NULL,
	[ExternalId] [uniqueidentifier] NULL,
	[Labels]  XML NULL,
	[FieldGroupId]  [uniqueidentifier] NOT NULL,
	[DisplayOrder] [int] NULL,
	[ShowAlways] bit NOT NULL,
	[DisplayFormat]  [nvarchar](150) NULL,
	[DisplayAsIcon] [nvarchar](150) NULL,
	CONSTRAINT [[prkFieldConfiguration] PRIMARY KEY CLUSTERED ([FieldConfigurationId] ASC),
	CONSTRAINT [frkFieldConfigurationFieldGroup] FOREIGN KEY ([FieldGroupId]) REFERENCES [web].[FieldGroup] ([FieldGroupId]),
 );

