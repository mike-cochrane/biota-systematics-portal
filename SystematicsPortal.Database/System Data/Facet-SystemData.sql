
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

	-- assume display order is within the group?
	-- how are groups 
INSERT INTO @Facet(FacetId, FacetGroup, Facet, FacetType, SolrFieldName, DisplayOrder)
VALUES
		   ('8F49080A-E5C4-4465-830E-BCF2A9D7C9A9','Metadata'			,'Document Class'		, 'text', 'documentClass_ss'				, 100)
		 , ('7429207F-923A-4BDE-BA55-6948D7040B9A','Metadata'			,'Record Source'		, 'text', 'source_ss'						, 110)
		 , ('74BB3DDD-59D3-4E55-BEBB-71BBB7493105','Metadata'			,'Added'				, 'date', 'added_ss'						, 120)
		 , ('DD2D2F5C-05CF-4D7F-BD0E-1D222E468553','Metadata'			,'Updated'				, 'date', 'updated_ss'						, 130)
		 -- has images
		 -- has collection objects
		 
		 , ('25D9F03F-6C22-47FC-9BD3-970680CC6469','Nomenclature'		,'Nomenclatural Code'	, 'text', 'nomCode_ss'						, 240)
		 , ('06E1971F-C48F-49AE-AD3F-09BD3919C560','Nomenclature'		,'Taxonomic Rank'		, 'text', 'taxonRank_ss'					, 250)
		 , ('2F559A6A-CE3A-4CB3-97BA-58E9B02A24B6','Nomenclature'		,'Combination Author'	, 'text', 'combinationAuthor_ss'			, 260)
		 , ('52DED31C-6031-462F-9D3F-7560F607840E','Nomenclature'		,'Original Author'		, 'text', 'basionymAuthor_ss'				, 270)
		 , ('A880AE70-621E-4C69-A178-DB51C185E2E6','Nomenclature'		,'Epithet'				, 'text', 'canonical_ss'					, 280)
		 -- nomenclatural status
		 -- year published
		 -- published in
		 -- basionym

		 , ('7ABE85EE-2B16-4CB2-AB9D-EDB98D206A88','Classification'		,'Kingdom'				, 'text', 'kingdom_ss'						, 410)
		 , ('D730674F-EA6C-47C0-A8E2-5A749CC259F8','Classification'		,'Class'				, 'text', 'class_ss'						, 420)
		 , ('8BD6F502-A3CD-4A32-AEB7-C0013E6471F8','Classification'		,'Order'				, 'text', 'order_ss'						, 430)
		 , ('B2CF1F73-17BA-4214-9F42-22AD4FB61779','Classification'		,'Family'				, 'text', 'family_ss'						, 440)
		 , ('31D9FC11-FB25-491A-A3CF-416C867FFA64','Classification'		,'Genus'				, 'text', 'genus_ss'						, 450)
		 , ('2865EA29-E414-4DA2-A3CB-9C21419C3A03','Classification'		,'Parent'				, 'text', 'parent_ss'						, 460)
		 -- classification reference?
		 
		 , ('7828FE87-1966-4402-A9CD-72DA040292E4','Taxonomy'			,'Current Name'			, 'text', 'current_ss'						, 510)
		 -- current name reference
		 , ('41F5E9EC-FF7B-486B-AC7A-C0A96B23D2A6','Taxonomy'			,'Hybrid Parent'		, 'text', 'hybridParent_ss'					, 520)

		 , ('20A9D851-9B5F-465E-BD3F-7BE0787220C7','Vernacular Name'	,'Vernacular Name'		, 'text', 'vernacularName_ss'				, 610)
		 , ('918DBA49-33A5-4E12-9A6A-B10BAB0A336A','Vernacular Name'	,'Language of Use'		, 'text', 'vernacularLanguageOfUse_ss'		, 620)
		 , ('31DAE5E3-C869-4111-956E-7FB55180E773','Vernacular Name'	,'Language of Origin'	, 'text', 'vernacularLanguageOfOrigin_ss'	, 630)
		 , ('5231DFD2-CA88-407C-A4C3-D3A5F5A34EDC','Vernacular Name'	,'Region of Use'		, 'text', 'vernacularRegionOfUse_ss'		, 640)
		 , ('3E6908D3-B66F-4E9C-9DAB-6D44703FF686','Vernacular Name'	,'Region of Origin'		, 'text', 'vernacularRegionOfOrigin_ss'		, 650)
		 -- applies to?

		 , ('72BADBC0-DA09-4AFE-8F84-B07E4097F8BF','NZ Biostatus'		,'Occurrence'			, 'text', 'nzOccurrence_ss'					, 710)
		 , ('3E89DE4F-FB30-48F9-81C7-9941CF41A477','NZ Biostatus'		,'Origin'				, 'text', 'nzOrigin_ss'						, 720)
		 , ('1885F062-F978-464C-BE14-56D278B285A2','NZ Biostatus'		,'Biostatus source'		, 'text', 'nzBioStatusReference_ss'			, 730)
		
		, ('75DD093E-7F23-4C97-AA22-5C2506C7430A','Biological Associations'		,'Linked to'			, 'text', 'associationType_ss'		, 810)
		--, ('','Biological Associations'		,'Substrate'			, 'text', 'associationType_ss', 100) 
		--, ('','Biological Associations'		,'Part Affected'			, 'text', 'associationType_ss', 100)
		--, ('','Biological Associations'		,'Host species'			, 'text', 'associationType_ss', 100)

		, ('2A1A223A-E298-4A0F-8EE3-D0EC99820A63','Global Names'		,'Linked to'			, 'text', 'externalLinkSource_ss'			, 910)

		, ('586B4D95-3A83-41D0-A375-5C3D1D286C59','Literature'		,'Type of reference'			, 'text', 'referenceType_ss'			, 1000)

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
