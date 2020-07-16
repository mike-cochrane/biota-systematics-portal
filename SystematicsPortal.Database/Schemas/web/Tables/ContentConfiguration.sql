CREATE TABLE [web].[ContentConfiguration](
	[ContentConfigurationId] [uniqueidentifier] NOT NULL,
	[Page]  [nvarchar](100) NULL,
	[Section] [nvarchar](100) NULL,
	[SectionTitle] nvarchar(200) NULL,
	[ExternalId] [uniqueidentifier] NULL,
    [DisplayOrder] [int] NULL,
 CONSTRAINT [[prkContentConfiguration] PRIMARY KEY CLUSTERED (
	[ContentConfigurationId] ASC
));
