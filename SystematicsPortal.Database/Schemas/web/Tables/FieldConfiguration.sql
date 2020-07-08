CREATE TABLE [web].[FieldConfiguration](
	[FieldConfigurationId] [uniqueidentifier] NOT NULL,
	[XPath]  [nvarchar](max) NULL,
	[DisplayOrder] [int] NULL,
 CONSTRAINT [[prkFieldConfiguration] PRIMARY KEY CLUSTERED (
	[FieldConfigurationId] ASC
));

