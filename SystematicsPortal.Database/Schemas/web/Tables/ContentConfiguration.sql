CREATE TABLE [web].[ContentConfiguration](
	[ContentConfigurationId] [uniqueidentifier] NOT NULL,
	[Page]  [nvarchar](100) NULL,
	[Section] [nvarchar](100) NULL,
	[ExternalId] [uniqueidentifier] NULL,
 CONSTRAINT [[prkContentConfiguration] PRIMARY KEY CLUSTERED (
	[ContentConfigurationId] ASC
));
