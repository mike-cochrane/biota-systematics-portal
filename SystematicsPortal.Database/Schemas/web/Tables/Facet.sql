CREATE TABLE [web].[Facet](
	[FacetId] [uniqueidentifier] NOT NULL,
	[FacetGroup] [varchar](100) NOT NULL,
	[Facet] [varchar](100) NOT NULL,
	[FacetType] [varchar](20) NOT NULL,
	[SolrFieldName] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NULL,
 CONSTRAINT [prkFacet] PRIMARY KEY CLUSTERED 
(
	[FacetId] ASC
));