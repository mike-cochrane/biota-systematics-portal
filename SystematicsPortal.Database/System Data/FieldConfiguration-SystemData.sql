
GO
PRINT N'Inserting FieldConfiguration system data...';
GO

DECLARE @FieldConfiguration TABLE (
	[FieldConfigurationId]	[uniqueidentifier]	NOT NULL,
	[DatDocumentXPath]		[nvarchar](500)		NULL,
	[ExternalId]			[uniqueidentifier]	NULL,
	[Labels]				[nvarchar](MAX)		NULL,
	--DynamicLabels			XML,
	--DocumentClass
	[FieldGroup]			[nvarchar](150)		NULL,
	[DisplayOrder]			[int]				NULL,
	[ShowAlways]			bit					NOT NULL,
	[DisplayFormat]			[nvarchar](150)		NULL)


INSERT INTO @FieldConfiguration(FieldConfigurationId, DatDocumentXPath, ExternalId, Labels, FieldGroup, DisplayOrder, ShowAlways, DisplayFormat)
VALUES
	-- name fields
		 ('A36F39D0-89D0-4931-82D0-B0E95E6F1038', '//Document/NameScientific'										, 'AC831E4E-B297-4C39-B221-09DFC40F374A', NULL, 'Nomenclature'		, 1, 1, NULL)
	   , ('2BAD547C-AB73-415B-AAA7-C53742234960', '//Document/NameFormatted'										, 'D8620369-2FC7-451F-859C-1CF17A0048B7', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('6597657F-F67D-4EEE-AD10-3B62FED93164', '//Document/Images/Image'											, '275658C7-ACD0-4EDD-BCC8-C1CA07EF2E87', NULL, 'Images'			, 1, 0, NULL)
	   , ('7CC8EF6E-0404-4118-9BCA-2757966DAB94', '//Document/BiostatusValue[@isActive="true"]/BiostatusReference'	, 'C6E046DB-37CC-4F77-9F0D-A4B3A52A2216', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('3A9C7491-F998-42B9-AC61-80ACE6B821A6', '//Document/BiostatusValue[@isActive="true"]/Origin'				, '3450257C-E2E7-4ED9-93A8-632B4983ADC6', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('C61B3175-5ECA-4185-A4CC-0C201DDB9A4D', '//Document/BiostatusValue[@isActive="true"]/Occurrence'			, '72B3FB40-E270-4CE8-BB6E-B1A134B5BA62', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('81E9FD84-66D9-4F35-B438-76C42F529A73', '//Document/BiostatusValue[@isActive="true"]/Georegion'			, '1FB16E72-662E-4661-A6D4-70F2FD821A48', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('4CBB2B4C-9D61-40FA-AD25-970B3C2A1F6E', '//Document/BiostatusValue[@isActive="true"]/Georegion/@schema'	, '58FB786F-496A-4A30-B3BA-B27B62794400', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('1293EF09-B033-47F5-A777-FAB1130055BC', '//Document/BiostatusValue[@isActive="true"]/@isFirstRecord'		, 'B1325AE3-6BAA-4981-A4EB-06528D9E7E8B', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('498A4FEF-C348-4CEA-B052-6A475538D78D', '//Document/BiostatusValue[@isActive="true"]/Comment'				, 'A93E66DD-6E29-4689-823D-FD1B588F03AD', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('814FA598-C703-4454-B932-AA6F87D1B17D', '//Document/BiostatusValue[@isActive="true"]/@isActive'			, 'DFA7392C-7490-4CA5-9053-D300A0EC5463', NULL, 'Current Biostatus'	, 1, 0, NULL)   
	   , ('18719AEE-87A2-4E35-8CB2-D8C5FD4B0DB8', '//Document/Basionym'												, '8DD50635-5093-44EB-9E25-48AA5C5FBF80', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('DD84DBDD-5245-4257-98AD-5CCE6925C6F3', '//Document/YearOfPublication'									, 'BCD8318A-0FFE-4727-BB8F-FBBADEEE31F8', NULL, 'Nomenclature'		, 1, 0, NULL) --YearOfPublication
	   , ('FDB9D7C4-D7A6-47BE-8222-2E29D34D72BA', '//Document/YearOnPublication'									, 'DFBA5EB2-B4B1-488E-8FB5-994200B307E8', NULL, 'Nomenclature'		, 1, 0, NULL) -- YearOnPublication
	   , ('46298803-422D-4601-BBF6-8D2540E7ED96', '//Document/Orthography'											, '9A5467FA-3E9D-4DC9-B89A-9F02F228ECDA', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('29FCA017-E4DF-4A70-9BAD-1F30B7BF4B11', '//Document/Page'													, 'B56C20CC-1ADB-433A-86B9-1BAC6E720E5C', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('C1744AFF-C46D-451F-9066-CEE91122F2BF', '//Document/TypeLocality'											, 'AE1FF992-401D-4C33-AD25-37C49B82A6F5', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('BB237777-425D-4846-87F6-DF26932B7C15', '//Document/TypeTaxon'											, 'C351EFDE-E3A1-4DAC-99DE-F4E3F9461D37', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('FFFCC555-2021-4952-9F0D-203BC4ACE3F2', '//Document/SanctioningAuthor'									, '50B75AF5-59C4-4EC3-AB04-1FA3011900C1', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('FB7B280B-71D7-4B4D-8049-14FB0C5D8709', '//Document/SanctioningPage'										, 'D8F453D5-931F-4A42-8A77-7E13B4FC8E2F', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('AE74CC13-51DA-40D6-B535-931D6B69FC63', '//Document/NameReference'										, '6E166C40-F4D9-4A12-B46A-ABA6C6E810F9', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('2A4C6D10-949F-465E-AB1A-495A2CE7A244', '//Document/BasedOn'												, '01C2ACCB-8137-4641-9E53-ACC8233C125D', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('1B467C70-B392-4935-94D0-7BEEDAD28889', '//Document/Blocking'												, 'A0D781E1-E7E7-4930-A199-3FA1445BEAB4', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('354F6197-958F-4B3B-8E62-1069FA8E01AA', '//Document/AnamorphGenus'										, '3AD55DDA-50C0-4AF2-90B0-C24F6BF4974E', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('3775F32C-454D-49D3-8B43-83AF236ABC67', '//Document/AnamorphReference'									, 'A31A82B2-C674-4FF0-A489-7221548D14FA', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('86729152-09BA-4B19-AF9E-10B85B8804BE', '//Document/Name/@nomCode'										, 'BD41BB18-78D0-4E2C-AFBB-DD9A3510124E', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('A1B3D221-79B4-485B-8459-9A3F7DEAB192', '//Document/Name/@taxonRank'										, 'AA0920CE-6C83-47BC-BFD8-29068613BFF2', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('154C5FBC-3447-40E1-887C-EDE4060F64BD', '//Document/Name/@namePart'										, '2DD543DE-6A6A-48B0-AAA7-75D5393353E4', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('D1D7E111-9A1E-4650-87D2-DCAA1AC9762D', '//Document/Name/@inCitation'										, '3476F1AD-772F-4356-8484-D6902E58B832', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('B07D036E-721C-40B5-89D8-BE9FE61924C8', '//Document/Name/@misapplied'										, 'E434D6D4-0599-4B05-90F4-F4EDA12773DF', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('100A042E-E9E2-41DC-ADB1-7E97C96D369B', '//Document/Name/@dubium'											, '22B23331-BD75-4A32-B03D-D81313BC0D26', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('779892F5-129C-472D-9A69-1750E8A04D6F', '//Document/Name/@proParte'										, '1A960B30-DA50-4F65-99DA-FCAEAE7AD5E3', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('80AA7651-EED3-4F7C-BE6E-5FCD1DF97ECF', '//Document/Name/@novum'											, '63870B5C-A630-4834-8E84-49CD625E56B2', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('52E5F389-E7AB-4C77-9924-53441EC942C1', '//Document/Name/@invalid'										, '518E80CE-73A3-4C49-B870-0129F95B5244', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('C199D97B-4AF7-4707-B79B-BFF1EF8996BC', '//Document/Name/@illegitimate'									, '27D65513-C004-44F3-A51D-B473E69381E6', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('F9A25243-29CE-41F3-B78D-45157E4BB362', '//Document/Name/@autonym'										, '6F739079-C8A8-441C-A376-57DAA605EE45', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('8216CC6C-625C-439B-9515-3CAD46D516F0', '//Document/Name/@recombination'									, 'AB7038FA-4BA5-435A-BC20-FFC5A9BA398C', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('5522AF68-1833-4360-BD78-6ABB88B38FD7', '//Document/Name/@nzRelevance'									, '173AB9C2-889D-4E56-B614-B552EAF05DEF', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('C36C323E-5E93-4E35-A93B-14CDF43D85C4', '//Document/Name/@isCurrent'										, 'A73A956E-78FC-44DE-95C3-E6E44D3A20FF', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('64DC2A6D-13A1-499D-B9DA-608FDC70BCDC', '//Document/Name/@isConserved'									, '4B721D9D-A139-495F-9AA1-2C453E8323E0', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('E0413BDF-66D7-4E09-915C-1B3049218337', '//Document/Name/@isSuperfluous'									, '23A1846A-9FFB-420A-8897-E469AD289FEF', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('290F5191-D8A8-45AA-917B-65175499C664', '//Document/Name/@isNonCodeName'									, 'EC164C8C-CEE8-464D-8900-D853646459DB', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('DF794D1D-E237-42A7-ABDF-FBE6BB458B0F', '//Document/Name/@isNomNudum'										, '74A503E4-4F04-4C59-A519-E86B1FE5092C', NULL, 'Nomenclature'		, 1, 0, NULL)
	   , ('40EB37F4-DBC5-44DA-AC82-1AC01DB33EC3', '//Document/TaxonomyReference'									, 'E2AA1901-302F-47CA-9269-A97A1B763340', NULL, 'Taxonomy'			, 1, 0, NULL)
	   , ('375EE552-6A58-4B54-9D08-9DDD17B0099B', '//Document/Synonyms/Synonym'										, '8C899BDE-42CF-42C2-8050-5D27FD8A0034', NULL, 'Synonyms'			, 1, 1, NULL) -- individual or group
	   , ('0F880318-01CF-4F45-A5F2-F18C8DF078C0', '//Document/Siblings/Sibling'										, '4D98966D-FA59-4A84-9AE9-CE953F7D0886', NULL, 'Siblings'			, 1, 1, NULL) -- individual or group
	   , ('3EB6D4F3-535D-4811-855C-B02333A826F1', '//Document/Subordinates/Subordinate'								, '14A81CD8-D120-4FBA-8722-0F00363590E8', NULL, 'Subordinates'		, 1, 1, NULL) -- individual or group
	   , ('09DD789E-E309-420D-A4FE-81C3BA376C13', '//Document/CurrentName'											, '25D58E0B-DAAF-40A5-9185-65A0D712C5C4', NULL, 'Taxonomy'			, 1, 1, NULL) --CurrentName
	   , ('C67EC817-D1EF-4BA3-A7B2-2BD464377869', '//Document/Kingdom'												, '253504BA-189A-466A-91AB-FB960A89FC21', NULL, 'Classification'	, 1, 0, NULL)
	   , ('B0B8BC3A-DEF6-4848-939F-43FB19FCE85B', '//Document/Phylum'												, '72EC7266-6D19-4C42-9E81-8ED62DEF2E93', NULL, 'Classification'	, 1, 1, NULL)
	   , ('F137AEA9-D2FD-4FA3-AB01-4EDDF5FBFD39', '//Document/Class'												, 'FF7C0D90-15A5-408D-B33C-F4637FD87CF5', NULL, 'Classification'	, 1, 1, NULL)
	   , ('D28D8F1B-5201-43B8-8613-AD2CCEB7C391', '//Document/Order'												, 'DA81F30F-15A6-4D49-9275-75DBC0EFD0C5', NULL, 'Classification'	, 1, 1, NULL)
	   , ('62868A47-C2FA-4511-844F-70BA5523A6BF', '//Document/Family'												, 'CFD34F63-57B7-497E-8644-21E91BDA5C94', NULL, 'Classification'	, 1, 1, NULL)
	   , ('DFE6C2C4-C74A-457C-950D-1F4547C05AF1', '//Document/Genus'												, '9FA9D568-1CD5-4C9B-873B-631808618BB8', NULL, 'Classification'	, 1, 1, NULL)
	   , ('65C0D34B-B630-4A87-87C7-C1F856A8623B', '//Document/AppliedVernaculars/AppliedVernacular/VernacularName/@languageOfOrigin'	, '7D5ACE44-331A-4784-8371-05C97939FD18', NULL, 'Vernacular Names', 1, 0, NULL)  --	languageOfOrigin
	   , ('2D002AED-F3F2-486C-BEDF-26779FB90786', '//Document/AppliedVernaculars/AppliedVernacular/@languageOfUse'						, '2C7EB5B7-9BB1-4D26-9C91-543CF05AEFC2', NULL, 'Vernacular Names', 1, 0, NULL)  --	languageOfUse
	   , ('81DB2BF5-B4C3-4A5C-A671-1DD3313C0CDE', '//Document/AppliedVernaculars/AppliedVernacular/VernacularName'						, '247A2A6E-6DAB-4FE5-B2D4-21608ADE6BF6', NULL, 'Vernacular Names', 1, 1, NULL) --Vernacular Name
	 -- hybridisation
	   , ('C610C210-61E7-44EC-AA0D-9A7825D419CB', '//Document/Hybridisation/HybridData/HybridParentNames/HybridParentName'	, '5DDB7E85-BDDB-45F9-BDE7-E5073B01B1C9', NULL, 'Hybridisation'	, 1, 0, NULL)
	   , ('A0B7821F-C4F8-42A0-B09B-6F48977841D0', '//Document/Hybridisation/HybridData/HybridText'							, '38F80762-1B03-4F7C-9C99-304A5566B3D1', NULL, 'Hybridisation'	, 1, 0, NULL)
	 -- concepts
	   , ('F5CC2DF0-82F5-42A3-87C2-B18DE0A9751B', '//Document/Concepts/Concept/Name'										, '31D1212C-1BCF-4473-BF2F-3C8B48253A26', NULL, 'Concepts'	, 1, 0, NULL)
	   , ('220CB656-A04A-463C-94D1-8704F12A2766', '//Document/Concepts/Concept/Orthography'									, '19F17201-B4E9-46A4-9C88-6EEE15E2A359', NULL, 'Concepts'	, 1, 0, NULL)
	   , ('D06D8306-6C9A-4A7B-926B-1ECACEB5E1AE', '//Document/Concepts/Concept/Page'										, '72EEA0FC-A561-481D-8D4F-6F0214CF776A', NULL, 'Concepts'	, 1, 0, NULL)
	   , ('6A73E536-CDE5-4CA0-9376-A952D9F4E4DB', '//Document/Concepts/Concept/AccordingTo'									, 'F6A9E828-336B-413F-8ABF-34E8C5B48CEB', NULL, 'Concepts'	, 1, 0, NULL)
	   , ('B63189D9-67E5-453E-9AAB-C69A8445B214', '//Document/Concepts/Concept/Keywords/Keyword'							, '868C573D-DCF1-4173-9099-71F867E01732', NULL, 'Concepts'	, 1, 0, NULL)
	   , ('5428C84F-BE96-4D01-8541-5B4FF0FAB555', '//Document/Concepts/Concept/Description/Description/DescriptionText'		, '0B8DD3D2-DD1D-45F8-A410-F9E975D28092', NULL, 'Concepts'	, 1, 0, NULL)
	   , ('4DBC99AC-70DD-4296-8082-88753A840ECE', '//Document/Concepts/Concept/Description/Description/@type'				, '089F9083-0212-4A6C-9525-3059D1575D13', NULL, 'Concepts'	, 1, 0, NULL)
	   , ('743632A5-C1A7-4E47-AB27-22FB30F3C7F5', '//Document/Concepts/Concept/Description/Description/@language'			, '7297AD27-383E-4944-8A89-A9F31599441D', NULL, 'Concepts'	, 1, 0, NULL)
	   , ('D9DC816A-30B4-4301-814D-03875A6DBA29', '//Document/Concepts/Concept/Description/Description/@category'			, '980B44AD-44D4-45AD-8639-1274E978EA3F', NULL, 'Concepts'	, 1, 0, NULL)
	 -- historic biostatus
	   , ('5EA26FE3-058B-4B1F-8AE9-BDA2B263411F', '//Document/BiostatusValue[@isActive="false"]/BiostatusReference'	, 'C6E046DB-37CC-4F77-9F0D-A4B3A52A2216', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('58EB7C8A-3DE7-4C01-A953-74705B2B88E4', '//Document/BiostatusValue[@isActive="false"]/Origin'				, '3450257C-E2E7-4ED9-93A8-632B4983ADC6', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('319A74F1-93EA-42B5-8C67-A0DFC9595EBB', '//Document/BiostatusValue[@isActive="false"]/Occurrence'			, '72B3FB40-E270-4CE8-BB6E-B1A134B5BA62', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('B774B34F-61E4-4968-ACDA-0139AF974A85', '//Document/BiostatusValue[@isActive="false"]/Georegion'			, '1FB16E72-662E-4661-A6D4-70F2FD821A48', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('0BC94E69-A9B2-40BD-95DE-4E5D1791939E', '//Document/BiostatusValue[@isActive="false"]/Georegion/@schema'	, '58FB786F-496A-4A30-B3BA-B27B62794400', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('9712D2B6-A6F5-4F8C-9AF7-ED824BCE3896', '//Document/BiostatusValue[@isActive="false"]/@isFirstRecord'		, 'B1325AE3-6BAA-4981-A4EB-06528D9E7E8B', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('6CE2384E-04C9-44E5-9A1B-885A58BDCE77', '//Document/BiostatusValue[@isActive="false"]/Comment'			, 'A93E66DD-6E29-4689-823D-FD1B588F03AD', NULL, 'Current Biostatus'	, 1, 0, NULL)
	   , ('21BA63B8-A30F-4D0B-9927-CA3740857A72', '//Document/BiostatusValue[@isActive="false"]/@IsActive'			, 'DFA7392C-7490-4CA5-9053-D300A0EC5463', NULL, 'Current Biostatus'	, 1, 0, NULL)
	 -- links
	   , ('865111F4-6750-4956-9CC0-93A5A4D36143', '//Document/ExternalLinks/ExternalLink'							, 'AE4539DC-9084-47AA-9C92-B505BB0001A8', NULL, 'External Name resources'	, 1, 0, NULL)
	   , ('E49D1756-61E7-425E-B74E-5ED93AEEB455', '//Document/Hyperlinks/Hyperlink'									, '253B0F8B-E6BB-4320-9F42-2A862546FA2B', NULL, 'Related resources'	, 1, 0, NULL)
	 -- collection objects
	   , ('690CCFC7-A26F-4F11-BF56-7CC08B747E82', '//Document/CollectionObjects/CollectionObject/@accessionNumber'																					, 'D851C8AC-B627-4CD7-A091-BD9D1E277856', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('4B445513-011F-45C2-80FA-4350E9AEC82A', '//Document/CollectionObjects/CollectionObject/@collectionDateISO'																				, '6A7961B3-2C3A-4838-993B-A3430D46A1EF', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('D7678C8B-22CF-455C-82C3-B09C5B8F2954', '//Document/CollectionObjects/CollectionObject/@typeStatus'																						, 'F4D060F6-F592-414B-8AE5-AADFDD3EB21B', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('00B91FAD-24C8-411C-9709-4F87A9E5BD75', '//Document/CollectionObjects/CollectionObject/NameFormatted'																						, '4A1D0785-3665-4994-993C-6BE17ACA98FA', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('9207BD7D-D595-400A-AC62-9A66FF4779A4', '//Document/CollectionObjects/CollectionObject/Collector'																							, '7D2F7AB6-5370-4E49-80C9-18722154FFEC', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('18E88F0A-B4F8-4A04-AD13-9A1A1AF28F14', '//Document/CollectionObjects/CollectionObject/Substrate'																							, 'DF7B4277-B2FC-4E56-88D0-FCBBC3AF38AF', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('AE787FA1-A3EA-4E64-9517-7F70527E2BE8', '//Document/CollectionObjects/CollectionObject/PartAffected'																						, '7C07FFED-A8B3-4472-A29A-F57FC79C8BDA', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('573DB5D1-325F-4163-92AF-2107AC355826', '//Document/CollectionObjects/CollectionObject/Association'																						, 'CBF86BEA-D77C-4BD4-A8C0-2E4205F22D41', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('DDC2FE22-79A3-4A5F-B214-1A008E3C3DB6', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="Country"]/@georegion'				, '229F0CBA-0536-4B32-BAF9-64E29E688C94', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('11FDB447-A85D-4DF0-9639-4563D572055A', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="Land District"]/@georegion'			, 'F2261017-EA11-4878-9DE3-B88360D36239', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('AFC2A8A8-D7E0-4DC7-9977-BE18736E4D48', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="Ecological District"]/@georegion'	, '044485AF-EC9E-40B5-AB4E-27363D7E32A9', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('612844B7-8F49-4844-BE5F-8728C677DB8F', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="Botanical District"]/@georegion'	, '1FD06084-A286-437D-A521-88E329721E2B', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('37359383-AA18-4315-83B7-FDB6B708C79B', '//Document/CollectionObjects/CollectionObject/CollectionEventRegions/CollectionEventRegion[@georegionSchema="New Zealand Area Code"]/@georegion'	, '7130F70A-A20C-49F3-B009-ED75EED22F0D', NULL, 'Collection Objects'	, 1, 0, NULL)
	   , ('FBB567DA-1CB8-4B7B-95FE-AE68FF88DE90', '//Document/CollectionObjects/CollectionObject/CollectionObjectImages/Image'																		, '574D8EB3-9D00-4772-BE82-A0DF5106FD7D', NULL, 'Collection Objects'	, 1, 0, NULL)
	 -- notes -- some may need to be put specifically in other sections
	   , ('195FBBE2-ACBD-4980-91BD-A1386AD6FF2C', '//Document/Notes/Note/Text'										, '06468CCB-2270-4FDB-B3DC-D4FFFD7A1F01', NULL, 'Notes'	, 1, 1, NULL)
	   , ('C9A053FD-B356-42CB-B4D6-0CF38A2D801C', '//Document/Notes/Note/@type'										, '220878E3-BD35-4B6D-BD62-039AE4B6888F', NULL, 'Notes'	, 1, 1, NULL)
	   , ('64F32B53-E556-418D-ADF4-2675AF9F6B59', '//Document/Notes/Note/Reference'									, '038FCE51-A1FF-461E-B164-3364F99B0319', NULL, 'Notes'	, 1, 1, NULL)
	 -- inKeys
	   , ('4B498043-675C-4F82-8081-0EBEB591FB79', '//Document/InKeys/Key'											, '9C9EC408-4F65-4D0A-9DEA-6184008C6B34', NULL, 'Identification Keys'	, 1, 1, NULL)
	 -- metadata
	   , ('80CE83AB-9E14-46CE-8DE4-4778DB60E11C', '//Document/@documentClass'										, '4D8B9885-7F03-4C30-B62C-6C8293E57204'									, NULL, 'Metadata'		, 1, 0, NULL)
	   , ('80CE83AB-9E14-46CE-8DE4-4778DB60E11C', '//Document/@added'												, '2B128E88-FDBB-4839-B75C-C12D84A1C14B'									, NULL, 'Metadata'		, 1, 0, NULL)
	   , ('80CE83AB-9E14-46CE-8DE4-4778DB60E11C', '//Document/@updated'												, '25301EA5-6064-42D2-90C0-03B105129189'									, NULL, 'Metadata'		, 1, 0, NULL)
	   , ('80CE83AB-9E14-46CE-8DE4-4778DB60E11C', '//Document/@source'												, '4A233FC0-2677-4304-9B09-932C5A10CF7A'									, NULL, 'Metadata'		, 1, 0, NULL)



MERGE INTO web.FieldConfiguration FC
USING @FieldConfiguration iFC
ON FC.FieldConfigurationId = iFC.FieldConfigurationId
WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT (FieldConfigurationId, DatDocumentXPath, ExternalId, Labels, FieldGroup, DisplayOrder, ShowAlways, DisplayFormat)
		VALUES (FieldConfigurationId, DatDocumentXPath, ExternalId, Labels, FieldGroup, DisplayOrder, ShowAlways, DisplayFormat)
WHEN MATCHED 
       THEN 
		UPDATE 
			SET 
				DatDocumentXPath	= iFC.DatDocumentXPath
				, ExternalId		= iFC.ExternalId
				, Labels			= iFC.Labels
				, FieldGroup		= iFC.FieldGroup
				, DisplayOrder		= iFC.DisplayOrder
				, ShowAlways		= iFC.ShowAlways
				, DisplayFormat		= iFC.DisplayFormat
WHEN NOT MATCHED BY SOURCE
       THEN DELETE;
