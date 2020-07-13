CREATE TABLE [web].[FieldConfiguration](
	[FieldConfigurationId] [uniqueidentifier] NOT NULL,
	[DatDocumentXPath]  [nvarchar](500) NULL,
	[ExternalId] [uniqueidentifier] NULL,
	[Labels]  [nvarchar](MAX) NULL,
	[FieldGroup]  [nvarchar](150) NULL,
	[DisplayOrder] [int] NULL,
	[ShowAlways] bit NOT NULL,
	[DisplayFormat]  [nvarchar](150) NULL,
 CONSTRAINT [[prkFieldConfiguration] PRIMARY KEY CLUSTERED (
	[FieldConfigurationId] ASC
));

