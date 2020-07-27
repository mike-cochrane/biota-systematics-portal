
GO
PRINT N'Inserting FieldConfiguration system data...';
GO

DECLARE @FieldConfiguration TABLE (
	[FieldConfigurationId]	[uniqueidentifier]	NOT NULL,
	[DataDocumentXPath]		[nvarchar](500)		NULL,
	[ExternalId]			[uniqueidentifier]	NULL,
	DocumentClass			varchar(15)         ,
	[Labels]				XML		NULL,
	[FieldGroupId]			UNIQUEIDENTIFIER	,
	[DisplayOrder]			[int]				NULL,
	[ShowAlways]			bit					NOT NULL,
	[DisplayFormat]			[nvarchar](150)		NULL)

	-- Field group ids
DECLARE  @name_ActiveBiostatus_Id		UNIQUEIDENTIFIER = '6CD69A89-0AFB-4C0A-96A0-79E064A8AD66'
		, @name_Children_Id				UNIQUEIDENTIFIER = '824E901A-0685-4F63-B275-36C4DE97FABD'
		, @name_Classification_Id		UNIQUEIDENTIFIER = 'B45FAF01-FCB9-40CF-9EFA-DD6B57ACF6E4'
		, @name_CollectionData_Id		UNIQUEIDENTIFIER = '32537FC4-BBEA-4DF1-8A92-D567901D24CA'
		, @name_Concepts_Id				UNIQUEIDENTIFIER = 'C7367F22-38D9-4A34-BB1E-F0063D1FDC70'
		, @name_ExternalNames_Id		UNIQUEIDENTIFIER = 'DAFF9AB3-4AAD-44D4-89A6-8F090BD13AB0'
		, @name_Hybridisation_Id		UNIQUEIDENTIFIER = '9ED00B87-7D3B-4476-AE5E-0E284B6BB276'
		, @name_Hyperlinks_Id			UNIQUEIDENTIFIER = '5DE88990-6648-4AE8-8717-B52088B05DDF'
		, @name_InactiveBiostatus_Id	UNIQUEIDENTIFIER = '4899BD5F-FFE2-4512-9E4B-02077BE0075F'
		, @name_InKeys_Id				UNIQUEIDENTIFIER = 'BF0D359C-95E6-41DF-9847-B9AC8316EC37'
		, @name_Metadata_Id				UNIQUEIDENTIFIER = '88953ACB-15CC-4D1F-A15C-54B81C5A107E'
		, @name_Nomenclature_Id			UNIQUEIDENTIFIER = '242CDD89-3D1D-40CA-A992-FBF62DC5F90E'
		, @name_Notes_Id				UNIQUEIDENTIFIER = '2542FEF5-7339-446A-B85D-26119AD8016A'
		, @name_Siblings_Id				UNIQUEIDENTIFIER = '842838C6-B3F4-4106-8323-0A806F81F080'
		, @name_Synonymy_Id				UNIQUEIDENTIFIER = 'D636F428-5DD3-4DF1-9306-2EBF7E8D59F9'
		, @name_TaxonImages_Id			UNIQUEIDENTIFIER = '4443464C-02B5-4684-95E8-860792B83185'
		, @name_Taxonomy_Id				UNIQUEIDENTIFIER = '65C76D3B-6BB9-434B-B4A2-D6515F02E690'
		, @name_Title_Id				UNIQUEIDENTIFIER = '752E8906-3CDD-427D-A1F7-D862A23F0F00'
		, @name_VernacularNames_Id		UNIQUEIDENTIFIER = 'A4CCD8EE-D5AB-4106-9E0F-5D030B6EE9CE'
		, @reference_CitedTaxa_Id		UNIQUEIDENTIFIER = '7531F1D0-7D56-43BB-ACE5-064930B4F276'
		, @reference_Concepts_Id		UNIQUEIDENTIFIER = '336915FE-DB39-4352-BD0F-6B58CD297EE4'
		, @reference_Details_Id			UNIQUEIDENTIFIER = '9A09CB53-C18B-4897-95C6-F2F3AC247F51'
		, @reference_Keys_Id			UNIQUEIDENTIFIER = 'B42799C5-8F02-4A97-8E73-53CBF9C8D659'
		, @reference_Metadata_Id		UNIQUEIDENTIFIER = '8ED5F036-DA9E-4F32-94AF-1177E61690A7'
		, @reference_Title_Id			UNIQUEIDENTIFIER = '12BFF4CE-23DD-4C41-8F74-7C98EFAA2BB2'
		, @vernacular_Details_Id		UNIQUEIDENTIFIER = '15CD2BEA-B10B-49F4-916C-6AC3E2EA2F59'
		, @vernacular_Metadata_Id		UNIQUEIDENTIFIER = '99AA0896-9905-4E5D-95C0-308153D9CF83'
		, @vernacular_Title_Id			UNIQUEIDENTIFIER = 'E3E09925-BBB2-4111-A6D0-8260842A231F'
		, @vernacular_Usage_Id			UNIQUEIDENTIFIER = 'A3EC7BB1-25C4-45BB-B145-45B8317116CA'


INSERT INTO @FieldConfiguration(FieldConfigurationId, DataDocumentXPath, ExternalId, Labels, FieldGroupId, DisplayOrder, ShowAlways, DisplayFormat, DocumentClass)
VALUES
	-- name fields
		 ('A36F39D0-89D0-4931-82D0-B0E95E6F1038', '//Document/NameScientific'															, 'AC831E4E-B297-4C39-B221-09DFC40F374A', NULL, @name_Nomenclature_Id	, 1, 1, NULL, 'name')
	   , ('2BAD547C-AB73-415B-AAA7-C53742234960', '//Document/NameFormatted'															, 'D8620369-2FC7-451F-859C-1CF17A0048B7', NULL, @name_title_id			, 1, 0, NULL, 'name')
	   , ('6597657F-F67D-4EEE-AD10-3B62FED93164', '//Document/Images/Image'																, '275658C7-ACD0-4EDD-BCC8-C1CA07EF2E87', NULL, @name_TaxonImages_Id	, 1, 0, NULL, 'name')	   
	   , ('7CC8EF6E-0404-4118-9BCA-2757966DAB94', '//Document/BiostatusValue[@isActive="true"]/BiostatusReference'						, 'C6E046DB-37CC-4F77-9F0D-A4B3A52A2216', NULL, @name_ActiveBiostatus_id	, 1, 0, NULL, 'name')
	   , ('3A9C7491-F998-42B9-AC61-80ACE6B821A6', '//Document/BiostatusValue[@isActive="true"]/Origin'									, '3450257C-E2E7-4ED9-93A8-632B4983ADC6', NULL, @name_ActiveBiostatus_id	, 1, 0, NULL, 'name')
	   , ('C61B3175-5ECA-4185-A4CC-0C201DDB9A4D', '//Document/BiostatusValue[@isActive="true"]/Occurrence'								, '72B3FB40-E270-4CE8-BB6E-B1A134B5BA62', NULL, @name_ActiveBiostatus_id	, 1, 0, NULL, 'name')
	   , ('81E9FD84-66D9-4F35-B438-76C42F529A73', '//Document/BiostatusValue[@isActive="true"]/Georegion'								, '1FB16E72-662E-4661-A6D4-70F2FD821A48', NULL, @name_ActiveBiostatus_id	, 1, 0, NULL, 'name')
	   , ('4CBB2B4C-9D61-40FA-AD25-970B3C2A1F6E', '//Document/BiostatusValue[@isActive="true"]/Georegion/@schema'						, '58FB786F-496A-4A30-B3BA-B27B62794400', NULL, @name_ActiveBiostatus_id	, 1, 0, NULL, 'name')
	   , ('1293EF09-B033-47F5-A777-FAB1130055BC', '//Document/BiostatusValue[@isActive="true"]/@isFirstRecord'							, 'B1325AE3-6BAA-4981-A4EB-06528D9E7E8B', NULL, @name_ActiveBiostatus_id	, 1, 0, NULL, 'name')
	   , ('498A4FEF-C348-4CEA-B052-6A475538D78D', '//Document/BiostatusValue[@isActive="true"]/Comment'									, 'A93E66DD-6E29-4689-823D-FD1B588F03AD', NULL, @name_ActiveBiostatus_id	, 1, 0, NULL, 'name')
	   , ('814FA598-C703-4454-B932-AA6F87D1B17D', '//Document/BiostatusValue[@isActive="true"]/@isActive'								, 'DFA7392C-7490-4CA5-9053-D300A0EC5463', NULL, @name_ActiveBiostatus_id	, 1, 0, NULL, 'name')   
	   , ('18719AEE-87A2-4E35-8CB2-D8C5FD4B0DB8', '//Document/Basionym'																	, '8DD50635-5093-44EB-9E25-48AA5C5FBF80', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('DD84DBDD-5245-4257-98AD-5CCE6925C6F3', '//Document/YearOfPublication'														, 'BCD8318A-0FFE-4727-BB8F-FBBADEEE31F8', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name') --YearOfPublication
	   , ('FDB9D7C4-D7A6-47BE-8222-2E29D34D72BA', '//Document/YearOnPublication'														, 'DFBA5EB2-B4B1-488E-8FB5-994200B307E8', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name') -- YearOnPublication
	   , ('46298803-422D-4601-BBF6-8D2540E7ED96', '//Document/Orthography'																, '9A5467FA-3E9D-4DC9-B89A-9F02F228ECDA', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('29FCA017-E4DF-4A70-9BAD-1F30B7BF4B11', '//Document/Page'																		, 'B56C20CC-1ADB-433A-86B9-1BAC6E720E5C', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('C1744AFF-C46D-451F-9066-CEE91122F2BF', '//Document/TypeLocality'																, 'AE1FF992-401D-4C33-AD25-37C49B82A6F5', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('BB237777-425D-4846-87F6-DF26932B7C15', '//Document/TypeTaxon'																, 'C351EFDE-E3A1-4DAC-99DE-F4E3F9461D37', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('FFFCC555-2021-4952-9F0D-203BC4ACE3F2', '//Document/SanctioningAuthor'														, '50B75AF5-59C4-4EC3-AB04-1FA3011900C1', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('FB7B280B-71D7-4B4D-8049-14FB0C5D8709', '//Document/SanctioningPage'															, 'D8F453D5-931F-4A42-8A77-7E13B4FC8E2F', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('AE74CC13-51DA-40D6-B535-931D6B69FC63', '//Document/NameReference'															, '6E166C40-F4D9-4A12-B46A-ABA6C6E810F9', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('2A4C6D10-949F-465E-AB1A-495A2CE7A244', '//Document/BasedOn'																	, '01C2ACCB-8137-4641-9E53-ACC8233C125D', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('1B467C70-B392-4935-94D0-7BEEDAD28889', '//Document/Blocking'																	, 'A0D781E1-E7E7-4930-A199-3FA1445BEAB4', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('354F6197-958F-4B3B-8E62-1069FA8E01AA', '//Document/AnamorphGenus'															, '3AD55DDA-50C0-4AF2-90B0-C24F6BF4974E', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('3775F32C-454D-49D3-8B43-83AF236ABC67', '//Document/AnamorphReference'														, 'A31A82B2-C674-4FF0-A489-7221548D14FA', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('86729152-09BA-4B19-AF9E-10B85B8804BE', '//Document/Name/@nomCode'															, 'BD41BB18-78D0-4E2C-AFBB-DD9A3510124E', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('A1B3D221-79B4-485B-8459-9A3F7DEAB192', '//Document/Name/@taxonRank'															, 'AA0920CE-6C83-47BC-BFD8-29068613BFF2', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('154C5FBC-3447-40E1-887C-EDE4060F64BD', '//Document/Name/@namePart'															, '2DD543DE-6A6A-48B0-AAA7-75D5393353E4', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('D1D7E111-9A1E-4650-87D2-DCAA1AC9762D', '//Document/Name/@inCitation'															, '3476F1AD-772F-4356-8484-D6902E58B832', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('B07D036E-721C-40B5-89D8-BE9FE61924C8', '//Document/Name/@misapplied'															, 'E434D6D4-0599-4B05-90F4-F4EDA12773DF', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('100A042E-E9E2-41DC-ADB1-7E97C96D369B', '//Document/Name/@dubium'																, '22B23331-BD75-4A32-B03D-D81313BC0D26', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('779892F5-129C-472D-9A69-1750E8A04D6F', '//Document/Name/@proParte'															, '1A960B30-DA50-4F65-99DA-FCAEAE7AD5E3', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('80AA7651-EED3-4F7C-BE6E-5FCD1DF97ECF', '//Document/Name/@novum'																, '63870B5C-A630-4834-8E84-49CD625E56B2', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('52E5F389-E7AB-4C77-9924-53441EC942C1', '//Document/Name/@invalid'															, '518E80CE-73A3-4C49-B870-0129F95B5244', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('C199D97B-4AF7-4707-B79B-BFF1EF8996BC', '//Document/Name/@illegitimate'														, '27D65513-C004-44F3-A51D-B473E69381E6', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('F9A25243-29CE-41F3-B78D-45157E4BB362', '//Document/Name/@autonym'															, '6F739079-C8A8-441C-A376-57DAA605EE45', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('8216CC6C-625C-439B-9515-3CAD46D516F0', '//Document/Name/@recombination'														, 'AB7038FA-4BA5-435A-BC20-FFC5A9BA398C', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('5522AF68-1833-4360-BD78-6ABB88B38FD7', '//Document/Name/@nzRelevance'														, '173AB9C2-889D-4E56-B614-B552EAF05DEF', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('C36C323E-5E93-4E35-A93B-14CDF43D85C4', '//Document/Name/@isCurrent'															, 'A73A956E-78FC-44DE-95C3-E6E44D3A20FF', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('64DC2A6D-13A1-499D-B9DA-608FDC70BCDC', '//Document/Name/@isConserved'														, '4B721D9D-A139-495F-9AA1-2C453E8323E0', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('E0413BDF-66D7-4E09-915C-1B3049218337', '//Document/Name/@isSuperfluous'														, '23A1846A-9FFB-420A-8897-E469AD289FEF', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('290F5191-D8A8-45AA-917B-65175499C664', '//Document/Name/@isNonCodeName'														, 'EC164C8C-CEE8-464D-8900-D853646459DB', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('DF794D1D-E237-42A7-ABDF-FBE6BB458B0F', '//Document/Name/@isNomNudum'															, '74A503E4-4F04-4C59-A519-E86B1FE5092C', NULL, @name_Nomenclature_Id		, 1, 0, NULL, 'name')
	   , ('40EB37F4-DBC5-44DA-AC82-1AC01DB33EC3', '//Document/TaxonomyReference'														, 'E2AA1901-302F-47CA-9269-A97A1B763340', NULL, @name_Taxonomy_Id			, 1, 0, NULL, 'name')
	   , ('375EE552-6A58-4B54-9D08-9DDD17B0099B', '//Document/Synonyms/Synonym'															, '8C899BDE-42CF-42C2-8050-5D27FD8A0034', NULL, @name_Synonymy_Id			, 1, 1, NULL, 'name') -- individual or group
	   , ('0F880318-01CF-4F45-A5F2-F18C8DF078C0', '//Document/Siblings/Sibling'															, '4D98966D-FA59-4A84-9AE9-CE953F7D0886', NULL, @name_Siblings_Id			, 1, 1, NULL, 'name') -- individual or group
	   , ('3EB6D4F3-535D-4811-855C-B02333A826F1', '//Document/Subordinates/Subordinate'													, '14A81CD8-D120-4FBA-8722-0F00363590E8', NULL, @name_Children_Id			, 1, 1, NULL, 'name') -- individual or group
	   , ('09DD789E-E309-420D-A4FE-81C3BA376C13', '//Document/CurrentName'																, '25D58E0B-DAAF-40A5-9185-65A0D712C5C4', NULL, @name_Taxonomy_Id			, 1, 1, NULL, 'name') --CurrentName
	   , ('C67EC817-D1EF-4BA3-A7B2-2BD464377869', '//Document/Kingdom'																	, '253504BA-189A-466A-91AB-FB960A89FC21', NULL, @name_classification_id		, 10, 0, NULL, 'name')
	   , ('B0B8BC3A-DEF6-4848-939F-43FB19FCE85B', '//Document/Phylum'																	, '72EC7266-6D19-4C42-9E81-8ED62DEF2E93', NULL, @name_classification_id		, 20, 1, NULL, 'name')
	   , ('F137AEA9-D2FD-4FA3-AB01-4EDDF5FBFD39', '//Document/Class'																	, 'FF7C0D90-15A5-408D-B33C-F4637FD87CF5', NULL, @name_classification_id		, 30, 1, NULL, 'name')
	   , ('D28D8F1B-5201-43B8-8613-AD2CCEB7C391', '//Document/Order'																	, 'DA81F30F-15A6-4D49-9275-75DBC0EFD0C5', NULL, @name_classification_id		, 40, 1, NULL, 'name')
	   , ('62868A47-C2FA-4511-844F-70BA5523A6BF', '//Document/Family'																	, 'CFD34F63-57B7-497E-8644-21E91BDA5C94', NULL, @name_classification_id		, 50, 1, NULL, 'name')
	   , ('DFE6C2C4-C74A-457C-950D-1F4547C05AF1', '//Document/Genus'																	, '9FA9D568-1CD5-4C9B-873B-631808618BB8', NULL, @name_classification_id		, 60, 1, NULL, 'name')
	   , ('65C0D34B-B630-4A87-87C7-C1F856A8623B', '//Document/AppliedVernaculars/AppliedVernacular/VernacularName/@languageOfOrigin'	, '7D5ACE44-331A-4784-8371-05C97939FD18', NULL, @name_VernacularNames_Id	, 20, 0, NULL, 'name')  --	languageOfOrigin
	   , ('2D002AED-F3F2-486C-BEDF-26779FB90786', '//Document/AppliedVernaculars/AppliedVernacular/@languageOfUse'						, '2C7EB5B7-9BB1-4D26-9C91-543CF05AEFC2', NULL, @name_VernacularNames_Id	, 30, 0, NULL, 'name')  --	languageOfUse
	   , ('81DB2BF5-B4C3-4A5C-A671-1DD3313C0CDE', '//Document/AppliedVernaculars/AppliedVernacular/VernacularName'						, '247A2A6E-6DAB-4FE5-B2D4-21608ADE6BF6', NULL, @name_VernacularNames_Id	, 10, 1, NULL, 'name') --Vernacular Name
	 -- hybridisation
	   , ('C610C210-61E7-44EC-AA0D-9A7825D419CB', '//Document/Hybridisation/HybridData/HybridParentNames/HybridParentName'				, '5DDB7E85-BDDB-45F9-BDE7-E5073B01B1C9', NULL, @name_Hybridisation_id		, 1, 0, NULL, 'name')
	   , ('A0B7821F-C4F8-42A0-B09B-6F48977841D0', '//Document/Hybridisation/HybridData/HybridText'										, '38F80762-1B03-4F7C-9C99-304A5566B3D1', NULL, @name_Hybridisation_id		, 1, 0, NULL, 'name')
	 -- concepts
	   , ('F5CC2DF0-82F5-42A3-87C2-B18DE0A9751B', '//Document/Concepts/Concept/Name'													, '31D1212C-1BCF-4473-BF2F-3C8B48253A26', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	   , ('220CB656-A04A-463C-94D1-8704F12A2766', '//Document/Concepts/Concept/Orthography'												, '19F17201-B4E9-46A4-9C88-6EEE15E2A359', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	   , ('D06D8306-6C9A-4A7B-926B-1ECACEB5E1AE', '//Document/Concepts/Concept/Page'													, '72EEA0FC-A561-481D-8D4F-6F0214CF776A', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	   , ('6A73E536-CDE5-4CA0-9376-A952D9F4E4DB', '//Document/Concepts/Concept/AccordingTo'												, 'F6A9E828-336B-413F-8ABF-34E8C5B48CEB', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	   , ('B63189D9-67E5-453E-9AAB-C69A8445B214', '//Document/Concepts/Concept/Keywords/Keyword'										, '868C573D-DCF1-4173-9099-71F867E01732', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	   , ('5428C84F-BE96-4D01-8541-5B4FF0FAB555', '//Document/Concepts/Concept/Description/Description/DescriptionText'					, '0B8DD3D2-DD1D-45F8-A410-F9E975D28092', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	   , ('4DBC99AC-70DD-4296-8082-88753A840ECE', '//Document/Concepts/Concept/Description/Description/@type'							, '089F9083-0212-4A6C-9525-3059D1575D13', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	   , ('743632A5-C1A7-4E47-AB27-22FB30F3C7F5', '//Document/Concepts/Concept/Description/Description/@language'						, '7297AD27-383E-4944-8A89-A9F31599441D', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	   , ('D9DC816A-30B4-4301-814D-03875A6DBA29', '//Document/Concepts/Concept/Description/Description/@category'						, '980B44AD-44D4-45AD-8639-1274E978EA3F', NULL, @name_Concepts_Id			, 1, 0, NULL, 'name')
	 -- historic biostatus
	   , ('5EA26FE3-058B-4B1F-8AE9-BDA2B263411F', '//Document/BiostatusValue[@isActive="false"]/BiostatusReference'						, 'C6E046DB-37CC-4F77-9F0D-A4B3A52A2216', NULL, @name_InactiveBiostatus_Id	, 1, 0, NULL, 'name')
	   , ('58EB7C8A-3DE7-4C01-A953-74705B2B88E4', '//Document/BiostatusValue[@isActive="false"]/Origin'									, '3450257C-E2E7-4ED9-93A8-632B4983ADC6', NULL, @name_InactiveBiostatus_Id	, 1, 0, NULL, 'name')
	   , ('319A74F1-93EA-42B5-8C67-A0DFC9595EBB', '//Document/BiostatusValue[@isActive="false"]/Occurrence'								, '72B3FB40-E270-4CE8-BB6E-B1A134B5BA62', NULL, @name_InactiveBiostatus_Id	, 1, 0, NULL, 'name')
	   , ('B774B34F-61E4-4968-ACDA-0139AF974A85', '//Document/BiostatusValue[@isActive="false"]/Georegion'								, '1FB16E72-662E-4661-A6D4-70F2FD821A48', NULL, @name_InactiveBiostatus_Id	, 1, 0, NULL, 'name')
	   , ('0BC94E69-A9B2-40BD-95DE-4E5D1791939E', '//Document/BiostatusValue[@isActive="false"]/Georegion/@schema'						, '58FB786F-496A-4A30-B3BA-B27B62794400', NULL, @name_InactiveBiostatus_Id	, 1, 0, NULL, 'name')
	   , ('9712D2B6-A6F5-4F8C-9AF7-ED824BCE3896', '//Document/BiostatusValue[@isActive="false"]/@isFirstRecord'							, 'B1325AE3-6BAA-4981-A4EB-06528D9E7E8B', NULL, @name_InactiveBiostatus_Id	, 1, 0, NULL, 'name')
	   , ('6CE2384E-04C9-44E5-9A1B-885A58BDCE77', '//Document/BiostatusValue[@isActive="false"]/Comment'								, 'A93E66DD-6E29-4689-823D-FD1B588F03AD', NULL, @name_InactiveBiostatus_Id	, 1, 0, NULL, 'name')
	   , ('21BA63B8-A30F-4D0B-9927-CA3740857A72', '//Document/BiostatusValue[@isActive="false"]/@IsActive'								, 'DFA7392C-7490-4CA5-9053-D300A0EC5463', NULL, @name_InactiveBiostatus_Id	, 1, 0, NULL, 'name')
	 -- links
	   , ('865111F4-6750-4956-9CC0-93A5A4D36143', '//Document/ExternalLinks/ExternalLink'												, 'AE4539DC-9084-47AA-9C92-B505BB0001A8', NULL, @name_ExternalNames_Id		, 1, 0, NULL, 'name')
	   , ('E49D1756-61E7-425E-B74E-5ED93AEEB455', '//Document/Hyperlinks/Hyperlink'														, '253B0F8B-E6BB-4320-9F42-2A862546FA2B', NULL, @name_Hyperlinks_Id			, 1, 0, NULL, 'name')
	 -- collection objects
	   , ('690CCFC7-A26F-4F11-BF56-7CC08B747E82', '//Document/CollectionObjects/CollectionObject/@accessionNumber'						, 'D851C8AC-B627-4CD7-A091-BD9D1E277856', NULL, @name_CollectionData_Id		, 1, 0, NULL, 'name')
	   , ('4B445513-011F-45C2-80FA-4350E9AEC82A', '//Document/CollectionObjects/CollectionObject/@collectionDateISO'					, '6A7961B3-2C3A-4838-993B-A3430D46A1EF', NULL, @name_CollectionData_Id		, 1, 0, NULL, 'name')
	   , ('D7678C8B-22CF-455C-82C3-B09C5B8F2954', '//Document/CollectionObjects/CollectionObject/@typeStatus'							, 'F4D060F6-F592-414B-8AE5-AADFDD3EB21B', NULL, @name_CollectionData_Id		, 1, 0, NULL, 'name')
	   , ('00B91FAD-24C8-411C-9709-4F87A9E5BD75', '//Document/CollectionObjects/CollectionObject/NameFormatted'							, '4A1D0785-3665-4994-993C-6BE17ACA98FA', NULL, @name_CollectionData_Id		, 1, 0, NULL, 'name')
	   , ('9207BD7D-D595-400A-AC62-9A66FF4779A4', '//Document/CollectionObjects/CollectionObject/Collector'								, '7D2F7AB6-5370-4E49-80C9-18722154FFEC', NULL, @name_CollectionData_Id		, 1, 0, NULL, 'name')
	   , ('18E88F0A-B4F8-4A04-AD13-9A1A1AF28F14', '//Document/CollectionObjects/CollectionObject/Substrate'								, 'DF7B4277-B2FC-4E56-88D0-FCBBC3AF38AF', NULL, @name_CollectionData_Id		, 1, 0, NULL, 'name')
	   , ('AE787FA1-A3EA-4E64-9517-7F70527E2BE8', '//Document/CollectionObjects/CollectionObject/PartAffected'							, '7C07FFED-A8B3-4472-A29A-F57FC79C8BDA', NULL, @name_CollectionData_Id		, 1, 0, NULL, 'name')
	   , ('573DB5D1-325F-4163-92AF-2107AC355826', '//Document/CollectionObjects/CollectionObject/Association'							, 'CBF86BEA-D77C-4BD4-A8C0-2E4205F22D41', NULL, @name_CollectionData_Id		, 1, 0, NULL, 'name')
	   , ('DDC2FE22-79A3-4A5F-B214-1A008E3C3DB6', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="Country"]/@georegion'				, '229F0CBA-0536-4B32-BAF9-64E29E688C94', NULL, @name_CollectionData_Id, 1, 0, NULL, 'name')
	   , ('11FDB447-A85D-4DF0-9639-4563D572055A', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="Land District"]/@georegion'			, 'F2261017-EA11-4878-9DE3-B88360D36239', NULL, @name_CollectionData_Id, 1, 0, NULL, 'name')
	   , ('AFC2A8A8-D7E0-4DC7-9977-BE18736E4D48', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="Ecological District"]/@georegion'	, '044485AF-EC9E-40B5-AB4E-27363D7E32A9', NULL, @name_CollectionData_Id, 1, 0, NULL, 'name')
	   , ('612844B7-8F49-4844-BE5F-8728C677DB8F', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="Botanical District"]/@georegion'	, '1FD06084-A286-437D-A521-88E329721E2B', NULL, @name_CollectionData_Id, 1, 0, NULL, 'name')
	   , ('37359383-AA18-4315-83B7-FDB6B708C79B', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="New Zealand Area Code"]/@georegion'	, '7130F70A-A20C-49F3-B009-ED75EED22F0D', NULL, @name_CollectionData_Id, 1, 0, NULL, 'name')
	   , ('FBB567DA-1CB8-4B7B-95FE-AE68FF88DE90', '//Document/CollectionObjects/CollectionObject/CollectionObjectImages/Image'																		, '574D8EB3-9D00-4772-BE82-A0DF5106FD7D', NULL, @name_CollectionData_Id, 1, 0, NULL, 'name')
	 -- notes -- some may need to be put specifically in other sections
	   , ('195FBBE2-ACBD-4980-91BD-A1386AD6FF2C', '//Document/Notes/Note/Text'															, '06468CCB-2270-4FDB-B3DC-D4FFFD7A1F01', NULL, @name_Notes_Id				, 1, 1, NULL, 'name')
	   , ('C9A053FD-B356-42CB-B4D6-0CF38A2D801C', '//Document/Notes/Note/@type'															, '220878E3-BD35-4B6D-BD62-039AE4B6888F', NULL, @name_Notes_Id				, 1, 1, NULL, 'name')
	   , ('64F32B53-E556-418D-ADF4-2675AF9F6B59', '//Document/Notes/Note/Reference'														, '038FCE51-A1FF-461E-B164-3364F99B0319', NULL, @name_Notes_Id				, 1, 1, NULL, 'name')
	 -- inKeys
	   , ('4B498043-675C-4F82-8081-0EBEB591FB79', '//Document/InKeys/Key'																, '9C9EC408-4F65-4D0A-9DEA-6184008C6B34', NULL, @name_InKeys_Id				, 1, 1, NULL, 'name')
	 -- metadata
	   , ('80CE83AB-9E14-46CE-8DE4-4778DB60E11C', '//Document/@documentId'																, '9810F995-0D18-443B-95B8-9F4822DFFEFE', NULL, @name_Metadata_Id			, 10, 0, NULL, 'name')
	   , ('7FF05165-11F9-448C-94C6-237F91B99EF0', '//Document/@documentClass'															, '4D8B9885-7F03-4C30-B62C-6C8293E57204', NULL, @name_Metadata_Id			, 20, 0, NULL, 'name')
	   , ('AB625FC7-850C-49E5-9072-0A7618BC3DB5', '//Document/@added'																	, '2B128E88-FDBB-4839-B75C-C12D84A1C14B', NULL, @name_Metadata_Id			, 30, 0, NULL, 'name')
	   , ('5577F520-4A05-455B-9201-950414A722B8', '//Document/@updated'																	, '25301EA5-6064-42D2-90C0-03B105129189', NULL, @name_Metadata_Id			, 40, 0, NULL, 'name')
	   , ('62A14DAB-D57E-41E8-84DE-C8C93E29EEB0', '//Document/@source'																	, '4A233FC0-2677-4304-9B09-932C5A10CF7A', NULL, @name_Metadata_Id			, 50, 0, NULL, 'name')

	 --  **************  reference object  ****************
	   , ('5A692FF8-0E13-4B37-8292-D486AE00E6EC', '//Document/Title'																	, '60A078F6-4E08-42E9-B18B-DE5F8989C288', NULL, @reference_Title_Id			, 1, 0, NULL, 'reference')
	   --, ('ED6DF942-4CC0-457A-8543-18F1C7C88B68', '//Document/Fields/Field/@type'														, 'externalId', NULL, 'Details'				, 1, 0, NULL, 'reference')
	   --, ('A6822CBE-6D2C-4CCC-B874-EFF347084522', '//Document/Fields/Field'															, 'externalId', NULL, 'Details'				, 1, 0, NULL, 'reference')
	   , ('EFA34B19-F603-4349-8C2D-4C05EBB0EC89', '//Document/DefinedConcepts/DefinedConcept/NameFormatted'								, 'B3B0DF3B-AFFD-4FD3-977A-B19A932EF5F6', NULL, @reference_Concepts_Id, 1, 0, NULL, 'reference')
	   , ('51156422-82B0-433F-BEB7-598CF879176A', '//Document/DefinedConcepts/DefinedConcept/Associations/Association'					, 'F8D8DF88-E8CC-4D84-9E7E-C4AA03F21B5F', NULL, @reference_Concepts_Id, 1, 0, NULL, 'reference')
	   , ('EA385D09-7CDA-492E-B9C9-5CC1DA8460F9', '//Document/DefinedConcepts/DefinedConcept/Associations/Association/@type'			, '6F48E789-8E9C-426F-8839-E037C0EAFD8E', NULL, @reference_Concepts_Id, 1, 0, NULL, 'reference')
	   , ('3C1769BD-6684-4B24-99AD-58C223707DEE', '//Document/DefinedConcepts/DefinedConcept/Associations/Association/@relatedName'		, 'EE8AA413-D695-4BDF-A12A-F722C7A5B870', NULL, @reference_Concepts_Id, 1, 0, NULL, 'reference')
	   , ('1C9223A4-C4D4-47C3-8B3F-A6DBDC4C9E65', '//Document/CitedTaxa/CitedTaxon'														, 'B3BE2B30-DB74-4EB9-BA2C-7C7591F47638', NULL, @reference_CitedTaxa_Id, 1, 0, NULL, 'reference')
	   , ('2F08E6B9-34F3-4CE7-AB2C-2BE954208F66', '//Document/IncludedKey/Key/@title'													, 'A09B7D85-ABC1-4F80-864E-DD11C780906A', NULL, @reference_Keys_Id, 1, 0, NULL, 'reference')
	   , ('8DC20908-A33E-4EFD-BA89-227288600978', '//Document/IncludedKey/Key'															, 'ACAF6957-DB0A-44F4-B46F-30D664328DBD', NULL, @reference_Keys_Id, 1, 0, NULL, 'reference')
	   , ('72ACA6CD-3849-4A64-941D-5BCBB5E0A5B4', '//Document/@documentId'																, '9810F995-0D18-443B-95B8-9F4822DFFEFE', NULL, @reference_Metadata_Id, 10, 0, NULL, 'reference')
	   , ('A4FC99D1-4A56-4E0B-9D10-B115C43ECFB1', '//Document/@documentClass'															, '4D8B9885-7F03-4C30-B62C-6C8293E57204', NULL, @reference_Metadata_Id, 20, 0, NULL, 'reference')
	   , ('A29799B8-9BD2-45BB-B0D8-D52D630DFCCC', '//Document/@added'																	, '2B128E88-FDBB-4839-B75C-C12D84A1C14B', NULL, @reference_Metadata_Id, 30, 0, NULL, 'reference')
	   , ('BDD22195-555D-49EF-97E5-DA2F1DC94D3F', '//Document/@updated'																	, '25301EA5-6064-42D2-90C0-03B105129189', NULL, @reference_Metadata_Id, 40, 0, NULL, 'reference')
	   , ('CFBC7C95-9D71-4402-A1A9-6286DB58FEFF', '//Document/@source'																	, '4A233FC0-2677-4304-9B09-932C5A10CF7A', NULL, @reference_Metadata_Id, 50, 0, NULL, 'reference')

	 -- ************  vernacular object ***************
	  , ('5160052F-36F5-4D36-9FA6-DF864E7D5E4D', '//Document/VernacularName'														, '247A2A6E-6DAB-4FE5-B2D4-21608ADE6BF6', NULL, @vernacular_Title_Id, 1, 0, NULL, 'vernacular')
	  , ('9F16DFB8-43AC-4CA1-B3F4-1BAC554166B3', '//Document/VernacularName/@languageOfOrigin'										, '7D5ACE44-331A-4784-8371-05C97939FD18', NULL, @vernacular_Details_Id, 1, 0, NULL, 'vernacular')
	  , ('FDE5BDB8-CC4A-428C-A5F7-A70A34D49C4C', '//Document/VernacularName/@regionOfOrigin'										, '52B88B27-367D-48E0-9A76-29276815116E', NULL, @vernacular_Details_Id, 1, 0, NULL, 'vernacular')
	  , ('4710166A-8618-4DCE-9B69-099D2A98E39B', '//Document/Translation'															, '1581F812-7006-43F2-8DB5-1471524E99DE', NULL, @vernacular_Details_Id, 1, 0, NULL, 'vernacular')
	  , ('7999F2E1-9173-4528-B748-76A3FA84FE7B', '//Document/Transliteration'														, 'D1FAE4ED-CEE9-4D77-A8D6-D0021E363F09', NULL, @vernacular_Details_Id, 1, 0, NULL, 'vernacular')
	  , ('46B25EE7-6C45-46BA-98A1-691E819471E7', '//Document/VernacularUses/VernacularUse/Name'										, '35B6FEED-C6BE-44AB-9A8F-29CD2A355ADA', NULL, @vernacular_Usage_Id, 1, 0, NULL, 'vernacular')
	  , ('11ACE31F-7113-44AA-A731-954D9EDF21B1', '//Document/VernacularUses/VernacularUse/@georegionOfUse'							, '423880A9-7DAF-47EC-938F-A3B2F5511B7C', NULL, @vernacular_Usage_Id, 1, 0, NULL, 'vernacular')
	  , ('27D1D4E3-887B-4878-BFF4-0DA958974903', '//Document/VernacularUses/VernacularUse/@languageOfUse'							, '2C7EB5B7-9BB1-4D26-9C91-543CF05AEFC2', NULL, @vernacular_Usage_Id, 1, 0, NULL, 'vernacular')
	  , ('DAD7CB3C-A28D-456A-AD64-51A1730C7BEB', '//Document/VernacularUses/VernacularUse/AppliesTo'								, '604D2574-A024-4BA4-8586-435789227CC5', NULL, @vernacular_Usage_Id, 1, 0, NULL, 'vernacular')
	  , ('94A28604-23AA-4AB9-B55E-20E861BEEA83', '//Document/VernacularUses/VernacularUse/References/Reference'						, '5B77E856-1779-42E0-9DCD-2C675EE2B9EC', NULL, @vernacular_Usage_Id, 1, 0, NULL, 'vernacular')
	  , ('FF143EF7-0947-4258-91D0-22C37AC3B528', '//Document/VernacularUses/VernacularUse/@languageOfUseISO'						, '7A5D204A-04BA-4F35-9175-F819C3B0FFAD', NULL, @vernacular_Usage_Id, 1, 0, NULL, 'vernacular')
	  , ('F708F68A-1BBF-47E3-AE35-268BD1524906', '//Document/@documentId'															, '9810F995-0D18-443B-95B8-9F4822DFFEFE', NULL, @vernacular_Metadata_Id, 10, 0, NULL, 'vernacular')
	  , ('A9D7EA61-A80E-481E-8B6B-C13FC8C49612', '//Document/@documentClass'														, '4D8B9885-7F03-4C30-B62C-6C8293E57204', NULL, @vernacular_Metadata_Id, 20, 0, NULL, 'vernacular')
	  , ('2D8A61F0-5E9A-454C-B40D-1D6BF2722D84', '//Document/@added'																, '2B128E88-FDBB-4839-B75C-C12D84A1C14B', NULL, @vernacular_Metadata_Id, 30, 0, NULL, 'vernacular')
	  , ('CA4482F6-677B-4404-96C2-A3C830A2D22D', '//Document/@updated'																, '25301EA5-6064-42D2-90C0-03B105129189', NULL, @vernacular_Metadata_Id, 40, 0, NULL, 'vernacular')
	  , ('75A92DFB-4BA0-4037-92A4-6D45D5B0937E', '//Document/@source'																, '4A233FC0-2677-4304-9B09-932C5A10CF7A', NULL, @vernacular_Metadata_Id, 50, 0, NULL, 'vernacular')

MERGE INTO web.FieldConfiguration FC
USING @FieldConfiguration iFC
ON FC.FieldConfigurationId = iFC.FieldConfigurationId
WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT (FieldConfigurationId, DataDocumentXPath, ExternalId, DocumentClass, Labels, FieldGroupId, DisplayOrder, ShowAlways, DisplayFormat)
		VALUES (FieldConfigurationId, DataDocumentXPath, ExternalId, DocumentClass, Labels, FieldGroupId, DisplayOrder, ShowAlways, DisplayFormat)
WHEN MATCHED 
       THEN 
		UPDATE 
			SET 
				DataDocumentXPath	= iFC.DataDocumentXPath
				, ExternalId		= iFC.ExternalId
				, DocumentClass		= iFC.DocumentClass
				, Labels			= iFC.Labels
				, FieldGroupId		= iFC.FieldGroupId
				, DisplayOrder		= iFC.DisplayOrder
				, ShowAlways		= iFC.ShowAlways
				, DisplayFormat		= iFC.DisplayFormat
WHEN NOT MATCHED BY SOURCE
       THEN DELETE;
