CREATE TABLE [web].[FieldGroup](
	[FieldGroupId]					[uniqueidentifier] NOT NULL,
	[ExternalId]					[uniqueidentifier] NULL,
	[DocumentClass]					nvarchar(100) NOT NULL,
	[Name]							nvarchar(200) NOT NULL,
	[DisplayTitle]					nvarchar(200) NULL, -- the title used in the website, to be replaced by display title
	[Labels]						XML NULL,
	[DisplayOrder]					[int] NULL,
	
 CONSTRAINT [[prkFieldGroup] PRIMARY KEY CLUSTERED ([FieldGroupId] ASC),
 );

