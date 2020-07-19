
GO
PRINT N'Inserting ContentConfiguration system data...';
GO

DECLARE @ContentConfiguration TABLE(
	[ContentConfigurationId]	[uniqueidentifier] NOT NULL,
	[Page]						[nvarchar](100) NULL,
	[Section]					[nvarchar](100) NULL,
	[ExternalId]				[uniqueidentifier] NULL,
	DisplayOrder				int NULL)


INSERT INTO @ContentConfiguration(ContentConfigurationId, [Page], Section, ExternalId)
VALUES
		 
		 ('056236E4-DED1-477F-B930-233CC6A9103A','About'			,'Main Content'		,'C5CFCD67-9BBC-44AB-AD99-1ACD1E30470D', 1) -- page
		,('4D0E907C-8A5F-4197-AA02-C871093C0834','About Names'		,'Main Content'		,'1A946C1A-FE80-4554-AA83-BB5DAAE7B692', 1)  -- page -> child of "About"
		,('73927FE8-21E1-4AC0-894B-1CBE2060E0DD','Acknowledgements'	,'Main Content'		,'891EF250-D80B-4AEF-BE8C-5ED186F6D40D', 1)
		,('BA336AD9-178A-4C97-A0B8-ECEEDFEED8D5','Browse Page'		,'Top Content'		,'59ECF18D-E53E-4A76-B299-7B1064C4BFBF', 1)
		,('F063ECE4-265D-44DD-A807-B1D962CCFC11','Contact Us'		,'Top Content'		,'9D62245F-2197-4429-B155-43DB57C1ACD6', 1)
		,('5E56AF69-7FAE-478C-A328-22510DBDBB30','FAQ'				,'Main Content'		,'801E9034-C6E8-4761-8E79-10EE34DAAADB', 1)
		,('2374C06F-01C6-4F23-9641-6DCD07948FC5','Field Definitions','Main Content'		,'8F766C02-BD56-4B9A-BB35-27ED8F2E1826', 1)
		,('FC8F7B29-9808-4597-9D6E-118066751E37','Getting started'	,'Main Content'		,'DA45668D-76C4-4FDE-9E46-A68980CBEDD1', 1)
		,('8AF650B5-5F3C-44D3-9FA1-7D90BF6B7397','Glossary'			,'Main Content'		,'8AA49B6C-5D51-43BA-BB6F-729B64982505', 1)
		,('2D03D955-F413-481A-9A90-0AE79905351C','Help'				,'Main Content'		,'7720177A-5E44-48A4-894C-14CF9F19DEB8', 1)
		,('622279F1-5615-4A06-95CD-8B9FCD323D41','Home'				,'Menu Item'		,'9619EF7F-AC31-4BE4-8CC1-5EE631284A08', 1)  -- section of "Home"
		,('9D696A9F-5F47-4ECC-A9FF-FC187682D8DC','Home'				,'Menu Item'		,'17DBF827-8862-441F-B625-D77F96C51996', 2)
		,('1881AF0C-425B-4F66-8949-15DA217DF7EE','Home'				,'Menu Item'		,'4551CEA0-4F01-4BE7-872A-616BF5973C28', 3)
		,('E62EDC3F-5518-45BD-B1C1-1828AC07F435','Home'				,'Menu Item'		,'DFDBC08A-B8CA-4ABE-9EA4-01C82348541D', 4)
		,('0A6D9460-BD8C-46C9-A926-CFC16111342D','Privacy'			,'Main Content'		,'BF17F650-7B7B-4F50-80A6-1CF7DA6C561B', 1)
		,('DEA826F8-B127-45DC-ABFF-5C1D9D38D6B7','Search Page'		,'Top Content'		,'EAD2788D-C697-486E-8F23-F642A0D40D90', 1)
		,('FAD4A9B7-94DA-40FA-A934-27C336945C9C','Search Syntax' 	,'Main Content'		,'7E46A8E0-FB34-44C1-8433-17DA6A3E9603', 1)
		,('49D67F58-4A6F-4071-8119-14B5DF2991DA','Statistics'		,'Main Content'		,'7E66AA72-B7C5-4A94-8FDA-66F0604FA9BB', 1)
		,('2A6BD277-4C63-45B7-8D43-BEF83B744995','Terms of Use'		,'Main Content'		,'C325F4A9-CE98-4F4C-B6A3-C903AA0FEF17', 1)



MERGE INTO web.ContentConfiguration CC
USING @ContentConfiguration iCC
ON CC.ContentConfigurationId = iCC.ContentConfigurationId
WHEN NOT MATCHED BY TARGET 
	THEN 
		INSERT (ContentConfigurationId, [Page], Section, ExternalId)
		VALUES (ContentConfigurationId, [Page], Section, ExternalId)
WHEN MATCHED 
       THEN 
		UPDATE 
			SET 
				[Page]			= iCC.[Page]
				, Section		= iCC.ExternalId
				, ExternalId	= iFC.Labels
				
				
WHEN NOT MATCHED BY SOURCE
       THEN DELETE;
