
GO
PRINT N'Inserting Facet system data...';
GO

DECLARE @Facet TABLE (
	[FacetId]		[uniqueidentifier] NOT NULL,
	[FacetGroup]	[varchar](100) NOT NULL,
	[Facet]			[varchar](100) NOT NULL,
	[FacetType]		[varchar](20) NOT NULL,
	[SolrFieldName] [varchar](100) NOT NULL,
	[DisplayOrder]	[int] NULL)


INSERT INTO @Facet(FacetId, FacetGroup, Facet, FacetType, SolrFieldName, DisplayOrder)
VALUES
		   ('8F49080A-E5C4-4465-830E-BCF2A9D7C9A9','Metadata'			,'Document Class'		, 'text', 'documentClass', 100)
		 , ('74BB3DDD-59D3-4E55-BEBB-71BBB7493105','Metadata'			,'Added'				, 'date', 'added', 100)
		 , ('DD2D2F5C-05CF-4D7F-BD0E-1D222E468553','Metadata'			,'Updated'				, 'date', 'updated', 100)
		 --, ('','Metadata'			,'Document Class'		, 'text', 'documentClass', 100)
		 --, ('','Metadata'			,'Document Class'		, 'text', 'documentClass', 100)
		 --, ('','Metadata'			,'Document Class'		, 'text', 'documentClass', 100)
		 --, ('','Metadata'			,'Document Class'		, 'text', 'documentClass', 100)
		 --, ('','Metadata'			,'Document Class'		, 'text', 'documentClass', 100)
		 --, ('','Metadata'			,'Document Class'		, 'text', 'documentClass', 100)
		


MERGE INTO web.Facet Fa
USING @Facet iFa
ON Fa.FacetId = iFa.FacetId
WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT (FacetId, FacetGroup, Facet, FacetType, SolrFieldName, DisplayOrder)
		VALUES (FacetId, FacetGroup, Facet, FacetType, SolrFieldName, DisplayOrder)
WHEN MATCHED 
       THEN 
		UPDATE 
			SET 
				FacetGroup			= iFa.FacetGroup
				, Facet				= iFa.Facet
				, FacetType	 	    = iFa.FacetType
				, SolrFieldName		= iFa.SolrFieldName
				, DisplayOrder		= iFa.DisplayOrder
				
				
WHEN NOT MATCHED BY SOURCE
       THEN DELETE;
