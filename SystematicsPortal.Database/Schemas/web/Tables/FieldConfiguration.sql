CREATE TABLE [web].[FieldConfiguration](
	[FieldConfigurationId]			[uniqueidentifier] NOT NULL,
	[FieldGroupId]					[uniqueidentifier] NULL, -- can be null, but only if ParentFieldConfigurationId is NOT NULL (and vice versa)
	[ParentFieldConfigurationId]	[uniqueidentifier] NULL,
	[ExternalId]					[uniqueidentifier] NULL,
	[DataDocumentXPath]				[nvarchar](500) NULL,
	[SiblingFilterXPath]			[nvarchar](500) NULL, -- this is the xpath predicate that will help filter child elements when a complex query is used.
	[Labels]						XML NULL, -- these are obtained from dScribe as part of the harvest process.
	[DisplayOrder]					[int] NULL,
	[DisplayTemplate]				[nvarchar](150) NULL,
	[DisplayAsIcon]					[nvarchar](150) NULL,
	[ShowAlways]					bit NOT NULL,
	CONSTRAINT [[prkFieldConfiguration] PRIMARY KEY CLUSTERED ([FieldConfigurationId] ASC),
	CONSTRAINT [frkFieldConfigurationFieldGroup] FOREIGN KEY ([FieldGroupId]) REFERENCES [web].[FieldGroup] ([FieldGroupId]),
 );
 GO
  CREATE INDEX idxParentFieldConfigurationId ON [web].[FieldConfiguration]([ParentFieldConfigurationId]) ;
 GO

