CREATE TABLE [web].[Language](
	[LanguageId] [uniqueidentifier] NOT NULL,
	[Description]  [nvarchar](150) NULL,
 CONSTRAINT [[prkLanguage] PRIMARY KEY CLUSTERED ([LanguageId] ASC)
 );
