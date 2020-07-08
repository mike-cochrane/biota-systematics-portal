CREATE TABLE [web].[Label](
	[LabelId] [uniqueidentifier] NOT NULL,
	[DisplayTitle]  [nvarchar](500) NULL,
	[LanguageId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [[prkLabel] PRIMARY KEY CLUSTERED ([LabelId] ASC),
  CONSTRAINT [frkLabelLanguage] FOREIGN KEY ([LanguageId]) REFERENCES [web].[Language] ([LanguageId]),
 );
