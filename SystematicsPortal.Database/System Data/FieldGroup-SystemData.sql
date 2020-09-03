
GO
PRINT N'Inserting FieldGroup system data...';
GO

ALTER TABLE [web].[FieldConfiguration] DROP CONSTRAINT [frkFieldConfigurationFieldGroup]
GO


DECLARE @FieldGroup TABLE (
	[FieldGroupId]					[uniqueidentifier] NOT NULL,
	[ExternalId]					[uniqueidentifier] NULL,
	[DocumentClass]					nvarchar(100) NOT NULL,
	[Name]							nvarchar(200) NOT NULL,
	[DisplayTitle]					nvarchar(200) NULL, -- the title used in the website, to be replaced by display title
	[Labels]						XML NULL,
	[DisplayOrder]					[int] NULL
	)


INSERT INTO @FieldGroup(FieldGroupId, DocumentClass, DisplayTitle, [Name], DisplayOrder, [ExternalId])
VALUES
	-- name groups
	  ('752E8906-3CDD-427D-A1F7-D862A23F0F00', 'name'		, NULL						, 'Title'				, 10, NULL)
	--, ('4443464C-02B5-4684-95E8-860792B83185', 'name'		, 'Images'					, 'Taxon Images'		, 20, NULL)
	, ('6CD69A89-0AFB-4C0A-96A0-79E064A8AD66', 'name'		, 'Biostatus'				, 'Active Biostatus'	, 30, NULL)	
	, ('242CDD89-3D1D-40CA-A992-FBF62DC5F90E', 'name'		, 'Nomenclature'			, 'Nomenclature'		, 40, NULL)
	, ('B45FAF01-FCB9-40CF-9EFA-DD6B57ACF6E4', 'name'		, 'Classification'			, 'Classification'		, 50, NULL)
	--, ('824E901A-0685-4F63-B275-36C4DE97FABD', 'name'		, 'Subordinates'			, 'Children'			, 60, NULL)
	, ('A4CCD8EE-D5AB-4106-9E0F-5D030B6EE9CE', 'name'		, 'Vernacular Names'		, 'Vernacular Names'	, 70, NULL)
	--, ('65C76D3B-6BB9-434B-B4A2-D6515F02E690', 'name'		, 'Taxonomy'				, 'Taxonomy'			, 50, NULL)
	, ('D636F428-5DD3-4DF1-9306-2EBF7E8D59F9', 'name'		, 'Synonyms'				, 'Synonymy'			, 80, NULL)
	--, ('842838C6-B3F4-4106-8323-0A806F81F080', 'name'		, 'Siblings'				, 'Siblings'			, 70, NULL)
	, ('9ED00B87-7D3B-4476-AE5E-0E284B6BB276', 'name'		, 'Hybridisation'			, 'Hybridisation'		, 90, NULL)
	, ('569c6148-0150-4963-b2e8-5aabcf6024a6', 'name'		, 'Associations'			, 'Assocations'			, 100, NULL)
	, ('2f68c123-f9a0-4c0a-bed5-bb874bdc8fba', 'name'		, 'Descriptions'			, 'Descriptions'		, 110, NULL)
	, ('C7367F22-38D9-4A34-BB1E-F0063D1FDC70', 'name'		, 'Taxonomic Concepts'		, 'Concepts'			, 120, NULL)
	, ('4899BD5F-FFE2-4512-9E4B-02077BE0075F', 'name'		, 'Historic Biostatus'		, 'Inactive Biostatus'	, 130, NULL)
	, ('DAFF9AB3-4AAD-44D4-89A6-8F090BD13AB0', 'name'		, 'External Name Resources'	, 'External Names'		, 140, NULL)
	, ('5DE88990-6648-4AE8-8717-B52088B05DDF', 'name'		, 'Related resources'		, 'Hyperlinks'			, 150, NULL)
	, ('32537FC4-BBEA-4DF1-8A92-D567901D24CA', 'name'		, 'Collections'				, 'Collection Data'		, 160, NULL)
	, ('BF0D359C-95E6-41DF-9847-B9AC8316EC37', 'name'		, 'Identification Keys'		, 'InKeys'				, 170, NULL)
	, ('2542FEF5-7339-446A-B85D-26119AD8016A', 'name'		, 'Notes'					, 'Notes'				, 180, NULL)
	, ('88953ACB-15CC-4D1F-A15C-54B81C5A107E', 'name'		, 'Metadata'				, 'Metadata'			, 190, NULL)
	-- reference groups
	, ('12BFF4CE-23DD-4C41-8F74-7C98EFAA2BB2', 'reference'	, NULL						, 'Title'				, 10, NULL)
	, ('9A09CB53-C18B-4897-95C6-F2F3AC247F51', 'reference'	, 'Details'					, 'Details'				, 20, NULL)
	, ('336915FE-DB39-4352-BD0F-6B58CD297EE4', 'reference'	, 'Taxonomic Concepts'		, 'Concepts'			, 30, NULL)

	, ('7531F1D0-7D56-43BB-ACE5-064930B4F276', 'reference'	, 'Cited taxa'				, 'Cited Taxa'			, 40, NULL)
	, ('B42799C5-8F02-4A97-8E73-53CBF9C8D659', 'reference'	, 'Identification Keys'		, 'Keys'				, 50, NULL)
	, ('8ED5F036-DA9E-4F32-94AF-1177E61690A7', 'reference'	, 'Record Metadata'			, 'Metadata'			, 60, NULL)

	-- vernacular groups
	, ('E3E09925-BBB2-4111-A6D0-8260842A231F', 'vernacular'	, NULL						, 'Title'				, 10, NULL)
	, ('15CD2BEA-B10B-49F4-916C-6AC3E2EA2F59', 'vernacular'	, 'Details'					, 'Details'				, 20, NULL)
	, ('A3EC7BB1-25C4-45BB-B145-45B8317116CA', 'vernacular'	, 'Usage'					, 'Usage'				, 30, NULL)
	, ('99AA0896-9905-4E5D-95C0-308153D9CF83', 'vernacular'	, 'Record Metadata'			, 'Metadata'			, 40, NULL)
	  
MERGE INTO web.FieldGroup FG
USING @FieldGroup iFG
ON FG.FieldGroupId = iFG.FieldGroupId
WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT (FieldGroupId, [ExternalId], DocumentClass, DisplayTitle, [Name], DisplayOrder)
		VALUES (FieldGroupId, [ExternalId], DocumentClass, DisplayTitle, [Name], DisplayOrder)
WHEN MATCHED 
       THEN 
		UPDATE 
			SET 
				DocumentClass		= iFG.DocumentClass
				, [ExternalId]		= iFG.[ExternalId]
				, DisplayTitle		= iFG.DisplayTitle
				, [Name]			= iFG.[Name]
				, DisplayOrder		= iFG.DisplayOrder
WHEN NOT MATCHED BY SOURCE
       THEN DELETE;
