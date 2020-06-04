USE Names_Plants
GO

IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#Name'))
	DROP TABLE #Name

IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#Occurrence'))
	DROP TABLE #Occurrence

IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#Vernacular'))
	DROP TABLE #Vernacular

IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#Reference'))
	DROP TABLE #Reference
GO


IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#TestList'))
	DROP TABLE #TestList
GO

CREATE TABLE #TestList (Id uniqueidentifier, objectType nvarchar(50))
GO

/*

-- useful for finding subsets
SELECT DISTINCT N.NameGuid, NameFull, NameUpdatedDate
FROM tblName N
	INNER JOIN tblNameBiostatus NB ON N.NameGUID = NB.NameBiostatusNameFk
	INNER JOIN tblbibliography B ON N.NameGuid = B.BibliographyNameFk
--	INNER JOIN tblImageLink IL ON N.NameGuid = IL.RecordID 
	--INNER JOIN tblVernacularUse VU ON N.NameGuid = VU.VernacularUseNameFk
	INNER JOIN tblNameNotes NN ON N.NameGuid = NN.NameNoteNameFk
--	INNER JOIN  tblNomenclaturalStatus NS ON N.Nameguid = NS.NomenclaturalStatusNameFk
--	INNER JOIN tblExternalName EN ON N.NameGuid = EN.NameGuid
where N.NameCurrentFk = N.NameGuid
ORDER BY NameUpdatedDAte desc
*/
GO


INSERT INTO #testlist(id, objecttype)
VALUES ('b1f2ef2e-4de4-428d-a10f-0018878be220',  'name')  --names_plants
	, ('a3715e1f-3335-479c-9fe1-0041a8c6e8fb',  'name')    --names_plants
	, ('A34DD714-9494-47D9-AFB1-154EA0F1950D',  'name')   --names_plants
	, ('C3D7BD00-0C35-4340-97A2-694A98457222',  'name')   --names_plants
	, ('5FB0A025-DD7A-44E8-9B9F-CEA1CA3E9C76',  'name')   --names_plants
	, ('9B7F9946-33E1-4D4C-8FE1-E75B6BE1F75E', 'name')   --names_plants
	, ('56A97ACD-D624-43AC-A7FB-06C72B67818C', 'name')    --names_plants

	, ('1CB18142-36B9-11D5-9548-00D0592D548C', 'name') -- names_fungi -- Clavaria acuta Sowerby
	, ('F18A0F26-4E13-444A-BDA2-A8FE52ADB18B', 'name') -- names_fungi -- Pseudomonas syringae pv. actinidiae Takikawa et al. 1989
	, ('1CB182DC-36B9-11D5-9548-00D0592D548C', 'name') -- names_fungi -- Clavaria pallidoechinulata R.H. Petersen
	, ('1CB18152-36B9-11D5-9548-00D0592D548C', 'name') -- names_fungi -- Clavaria flavopurpurea R.H. Petersen
	, ('1CB1A13F-36B9-11D5-9548-00D0592D548C', 'name') -- names_fungi -- Ramariopsis alutacea R.H. Petersen
	--, ('', 'name') -- names_fungi -- 
	--, ('', 'name') -- names_fungi -- 
	--, ('', 'name') -- names_fungi -- 

	, ('B90EED88-CBFF-4AAA-8ED1-005A04A2C5B8', 'name') -- names_nzac -- Euplectopsis crassipes (Broun)
	, ('0C631AA2-70F7-4466-B5F4-0DC0C2D289EC', 'name') -- names_nzac -- Ichneutica brunneosa (Fox)
	, ('8E344273-3658-4908-AB28-F2DE676DCBCB', 'name') -- names_nzac -- Saphydrus suffusus Sharp
	, ('DCBA5EDB-EFFD-4F08-B4A1-19B42207ABAD', 'name') -- names_nzac -- 2020-02-23 13:44:11.283
	, ('098EE6E6-2ABB-4F5D-87F3-62092577483C', 'name') -- names_nzac -- Paropsis charybdis Stal

INSERT INTO #TestList(id, objectType)
SELECT DISTINCT FN.FlatNameNameUFk, 'name'
FROM tblFlatName FN
	INNER JOIN #TestList TL ON FN.FlatNameSeedName = TL.Id
	INNER JOIN tblName N ON FN.FlatNameNameUFk = N.Nameguid
		AND ISNULL(N.NameSuppress, 0) = 0


INSERT INTO #TestList(Id, objectType)
SELECT DISTINCT NameGuid, 'name'
FROM tblName
WHERE NameCurrentFk IN (SELECT id from #TestList)
		AND NameGuid NOT IN (SELECT id from #TestList)

; WITH CitedRefs AS(
	SELECT NameReferenceFk as referenceid
	FROM tblName
	WHERE NameGuid IN (SELECT id from #TestList)

	UNION ALL

	SELECT NameParentReferenceFk
	FROM tblName
	WHERE NameGuid IN (SELECT id from #TestList)

	UNION ALL

	SELECT NameTaxonomyReferenceFk
	FROM tblName
	WHERE NameGuid IN (SELECT id from #TestList)

	UNION ALL

	SELECT NameSanctioningReferenceFk
	FROM tblName
	WHERE NameGuid IN (SELECT id from #TestList)

	UNION ALL

	SELECT NameNoteReferenceFk
	FROM tblNameNotes
	WHERE NameNoteNameFk IN (SELECT id from #TestList)

	UNION ALL

	SELECT NomenclaturalStatusReferenceFk
	FROM tblNomenclaturalStatus
	WHERE NomenclaturalStatusNameFk IN (SELECT id from #TestList)

	UNION ALL

	SELECT NameBiostatusReferenceFk
	FROM tblNameBiostatus
	WHERE NameBiostatusNameFk IN (SELECT id from #TestList)

	UNION ALL

	SELECT VA.VernacularArticleReferenceFk
	FROM tblVernacularUse VU
		INNER JOIN tblVernacularArticle VA ON VU.VernacularUseCounterPk = VA.VernacularArticleVernacularUseFK
	WHERE VernacularUseNameFk IN (SELECT id from #TestList)

	UNION ALL

	SELECT BibliographyReferenceFk
	FROM tblBibliography 
	WHERE BibliographyNameFk IN (SELECT id from #TestList)


)
, Refs AS (
	SELECT R.ReferenceId
	FROM tblReference R
		LEFT JOIN tblReference PR ON R.ReferenceParentID = PR.ReferenceID
	WHERE ISNULL(R.ReferenceIsDeleted, 0) = 0
		AND ISNULL(R.ReferenceSuppress, 0) = 0
		AND ISNULL(PR.ReferenceIsDeleted, 0) = 0
		AND ISNULL(PR.ReferenceSuppress, 0) = 0
		AND R.ReferenceID in (SELECT ReferenceID FROM CitedRefs)

	UNION ALL

	SELECT PR.ReferenceId
	FROM tblReference R
		INNER JOIN tblReference PR ON R.ReferenceParentID = PR.ReferenceID
	WHERE ISNULL(R.ReferenceIsDeleted, 0) = 0
		AND ISNULL(R.ReferenceSuppress, 0) = 0
		AND ISNULL(PR.ReferenceIsDeleted, 0) = 0
		AND ISNULL(PR.ReferenceSuppress, 0) = 0
		AND R.ReferenceID in (SELECT ReferenceID FROM CitedRefs)
)
	--SELECT * FROM CitedRefs
	INSERT INTO #TestList(id, objectType)
	SELECT DISTINCT referenceid, 'reference'
	FROM Refs
	WHERE referenceid is not null
GO

INSERT INTO #TestList (id, objectType)
SELECT DISTINCT V.VernacularGuid, 'vernacular'
FROM tblVernacularUse VU
	INNER JOIN tblVernacular V ON VU.VernacularUseVernacularFk = V.VernacularGuid
		AND ISNULL(V.VernacularSuppress, 0) = 0
WHERE ISNULL(VU.VernacularUseIsDeleted, 0) = 0 AND ISNULL(VU.VernacularUseSuppress, 0) = 0
	AND VU.VernacularUseNameFk IN (SELECT id FROM #TestList)

GO

--SELECT N.Namefull, n.nameguid 
--	FROM tblName	N
--	INNER JOIN tblDeprecated D ON CAST(N.NameGuid as nvarchar(50)) = D.DeprecatedNewKey
--	INNER JOIN tblNameNotes NN ON N.NameGuid = NN.NameNoteNameFk
--	INNER JOIN tblVernacularUse VU ON N.NameGuid = VU.VernacularUseNameFk
--	INNER JOIN tblNomenclaturalStatus NS ON N.NameGuid = NS.NomenclaturalStatusNameFk
--	INNER JOIN tblNameBiostatus B ON N.NameGuid = B.NameBiostatusNameFk
--	--INNER JOIN tblImageLink IL ON N.NameGuid = IL.RecordID
--where n.nameguid = n.NameCurrentFk

CREATE TABLE #Name (
	NameGuid uniqueidentifier
	, Title nvarchar(1000)
	, Canonical nvarchar(300)
	, NameFull nvarchar(250)
	, NameFormatted nvarchar(300)
	, NamePartFormatted nvarchar(300)
	, NameFormattedEscaped nvarchar(300)
	, NamePartFormattedEscaped nvarchar(300)
	, Orthography nvarchar(100)
	, Authors nvarchar(255)
	, [Page] nvarchar(20)
	, YearOfPublication nvarchar(10)
	, YearOnPublication nvarchar(10)
	, InCitation bit
	, Misapplied bit
	, Dubium bit
	, ProParte bit
	, Novum bit
	, Invalid bit
	, Illegitimate bit
	, Autonym bit
	, IsRecombination bit
	, [Aggregate] bit
	, ClassificationFK int
	, [Classification] nvarchar(255)
	, IsAnamorph bit
	, TypeLocality nvarchar(50)
	, SanctioningAuthor nvarchar(10)
	, SanctioningPage nvarchar(15)
	, HybridLink nvarchar(1)
	, CheckStatus varchar(10)
	, NomCode nvarchar(5)
	, Suppress bit
	, ReferenceFK uniqueidentifier
	, Reference xml
	, TaxonomyReferenceFk uniqueidentifier
	, TaxonomyReference xml --nvarchar(max)
	, ParentReferenceFK uniqueidentifier
	, ParentReference xml
	, Parent nvarchar(450)
	, ParentFK uniqueidentifier
	, CurrentName nvarchar(450)
	, CurrentFK uniqueidentifier
	, IsCurrent bit DEFAULT(0)
	, Basionym nvarchar(450)
	, BasionymFK uniqueidentifier
	, BasedOn nvarchar(450)
	, BasedOnFk uniqueidentifier
	, Blocking nvarchar(450)
	, BlockingFk uniqueidentifier
	, AnamorphGenus nvarchar(450)
	, AnamorphGenusFk uniqueidentifier
	, AnamorphReferenceFK uniqueidentifier
	, AnamorphReference xml
	, TypeTaxon nvarchar(450)
	, TypeTaxonFK uniqueidentifier
	, ForeignId nvarchar(255)
	, NamePart nvarchar(100)
	, AddedDate datetime
	, UpdatedDate datetime
	, Source nvarchar(50)
	, Kingdom nvarchar(500)
	, KingdomId uniqueidentifier
	, Phylum nvarchar(500)
	, PhylumId uniqueidentifier
	, Class nvarchar(500)
	, ClassId uniqueidentifier
	, [Order] nvarchar(500)
	, OrderId uniqueidentifier
	, Family nvarchar(500)
	, FamilyId uniqueidentifier
	, Genus nvarchar(500)
	, GenusId uniqueidentifier
	, TaxonRank nvarchar(250)
	, TaxonRankSort int
	, VernacularXML xml
	, VernacularSOLRXML xml
	, NZRelevance nvarchar(150)
	, BiostatusXML xml
	, BiostatusSOLRXML xml
	, ConceptsXML xml
	, ConceptsSOLRXML xml
	, NotesXML xml
	, NotesSOLRXML xml
	, ImageXML xml
	, ImageSOLRXML xml
	, ExternalLinkXML xml
	, ExternalLinkSOLRXML xml
	, NomenclaturalStatusXML xml
	, NomenclaturalStatusSOLR xml
	, DeprecatedIdSOLR xml
	, HybridXML xml
	, HybridSOLRXML xml
	, HyperLinkXML xml
	, HyperLinkSOLRXML XML
	, CollectionObjectXML xml
	, CollectionObjectSOLRXML xml
	, KeyXML xml
	, KeySOLRXML xml
	)
CREATE INDEX idxNameId		ON #Name(NameGUID)
CREATE INDEX idxCurrentId	ON #Name(CurrentFK)
CREATE INDEX idxParentId	ON #Name(ParentFK)
GO
CREATE TABLE #Reference (
	ReferenceId uniqueidentifier
	, Title nvarchar(max)
	, TitleUnformatted nvarchar(max)
	, Source nvarchar(50)
	, ReferenceType nvarchar(150)
	, Added datetime
	, Updated datetime
	, FieldsXML xml
	, FieldsSOLRXML xml
	, ParentReference nvarchar(max)
	, ParentReferenceId uniqueidentifier
	, ConceptsXML xml
	, ConceptsSOLRXML xml
	, KeysXML xml
	, KeysSOLRXML xml
	, CitationsXML xml
	, CitationsSOLRXML xml
	)

GO
CREATE TABLE #Vernacular(
	VernacularId uniqueidentifier
	, VernacularName nvarchar(255)
	, Translation nvarchar(255)
	, Transliteration nvarchar(255)
	, LanguageOfOrigin nvarchar(250)
	, LanguageFK int
	, RegionOfOrigin nvarchar(250)
	, GeoregionFK int
	, Added datetime
	, Updated datetime
	, UsesXML xml
	, UsesSOLRXML xml
)

GO
CREATE TABLE #Occurrence(
	OccurrenceCodePk nvarchar(5)
	, OccurrenceDescription nvarchar(255)
	, OccurrenceSort numeric(2,1)
	)
GO
INSERT INTO #Occurrence(OccurrenceCodePk, OccurrenceDescription, OccurrenceSort)
SELECT OccurrenceCodePK, OccurrenceDescription, CAST(OccurrenceCodePK as numeric(2,1))
FROM tblOccurrence

UPDATE #Occurrence SET OccurrenceSort = 2.0 WHERE OccurrenceCodePk = 1.0
UPDATE #Occurrence SET OccurrenceSort = 2.1 WHERE OccurrenceCodePk = 1.1
UPDATE #Occurrence SET OccurrenceSort = 2.2 WHERE OccurrenceCodePk = 1.2
UPDATE #Occurrence SET OccurrenceSort = 2.3 WHERE OccurrenceCodePk = 1.3
UPDATE #Occurrence SET OccurrenceSort = 2.4 WHERE OccurrenceCodePk = 1.4
UPDATE #Occurrence SET OccurrenceSort = 1.0 WHERE OccurrenceCodePk = 2.0
UPDATE #Occurrence SET OccurrenceSort = 1.1 WHERE OccurrenceCodePk = 2.1
UPDATE #Occurrence SET OccurrenceSort = 1.3 WHERE OccurrenceCodePk = 2.2
UPDATE #Occurrence SET OccurrenceSort = 1.2 WHERE OccurrenceCodePk = 2.3
--UPDATE #Occurrence SET OccurrenceSort = 3.0 WHERE OccurrenceCodePk = 3.0

-- relabel some of the Occurrence descriptions.
IF DB_Name() = 'Names_Plants'
BEGIN
	UPDATE #Occurrence SET OccurrenceDescription = 'Cultivated' WHERE OccurrenceCodePk = 2.2
	UPDATE #Occurrence SET OccurrenceDescription = 'Vagrant' WHERE OccurrenceCodePk = 2.3
END
ELSE IF DB_Name() = 'Names_Fungi'
BEGIN
	UPDATE #Occurrence SET OccurrenceDescription = 'Cultivated' WHERE OccurrenceCodePk = 2.2
	UPDATE #Occurrence SET OccurrenceDescription = 'Vagrant' WHERE OccurrenceCodePk = 2.3
END
ELSE
BEGIN
	UPDATE #Occurrence SET OccurrenceDescription = 'Captive' WHERE OccurrenceCodePk = 2.2
	UPDATE #Occurrence SET OccurrenceDescription = 'Vagrant' WHERE OccurrenceCodePk = 2.3
END
-- relabel some of the origin descriptions?

GO

INSERT INTO #Name(NameGuid, Canonical, NameFull, Orthography
	, [Page], YearOfPublication, YearOnPublication
	, InCitation, Misapplied, Dubium, ProParte 
	, Novum, Invalid, Illegitimate, Autonym 
	, IsRecombination, [Aggregate], ClassificationFK, [Classification]
	, IsAnamorph, TypeLocality, SanctioningAuthor 
	, SanctioningPage, HybridLink, CheckStatus 
	, NomCode, Suppress, ReferenceFK, TaxonomyReferenceFk 
	, ParentReferenceFK, ParentFK, CurrentFK
	, BasionymFK, BasedOnFk, BlockingFk, AnamorphGenusFk 
	, AnamorphReferenceFK, TypeTaxonFK, ForeignId 
	, NamePart, AddedDate, UpdatedDate, Source
	, TaxonRank, TaxonRankSort, IsCurrent
)

SELECT NameGuid, NameCanonical, NameFull, NameOrthographyVariant
	, NamePage, NameYearOfPublication, NameYearOnPublication
	, NameInCitation, NameMisapplied, NameDubium, NameProParte 
	, NameNovum, NameInvalid, NameIllegitimate, NameAutonym 
	, NameIsRecombination, NameAggregate, NameClassificationFK, C.ClassificationDescription
	, NameIsAnamorph, NameTypeLocality, NameSanctioningAuthor 
	, NameSanctioningPage, NameHybridLink, NameCheckStatus 
	, NameNomCode, NameSuppress, NameReferenceFK, NameTaxonomyReferenceFk 
	, NameParentReferenceFK, NameParentFK, NameCurrentFK
	, NameBasionymFK, NameBasedOnFk, NameBlockingFk, NameAnamorphGenusFk 
	, NameAnamorphReferenceFK, NameTypeTaxonFK, NameForeignId 
	, NamePart, NameAddedDate, NameUpdatedDate, DB_Name()
	, TR.TaxonRankName, TR.TaxonRankSort
	, CASE NameCurrentFk WHEN NameGuid THEN 1 ELSE 0 END AS IsCurrent
 FROM tblName N
	INNER JOIN tblTaxonRank TR ON N.NameTaxonRankFk = TR.TaxonRankPk
	LEFT JOIN tblClassification C ON N.NameClassificationFK = C.ClassificationCounterPk
WHERE NameGuid IN (SELECT id from #TestList WHERE objectType = 'name')

GO
UPDATE #Name SET NomCode = 'ICN' where NomCode = 'ICBN'
GO

UPDATE N
	SET Kingdom = FN.FlatNameCanonical
		, KingdomId = FN.FlatNameNameUFk
FROM #Name N
	INNER JOIN tblFlatName FN ON N.NameGuid = FN.FlatNameSeedName
			AND FN.FlatNameRankName = 'Kingdom'
		INNER JOIN tblName NA ON FN.FlatNameNameUFk = NA.NameGuid
			AND ISNULL(NA.NameSuppress, 0) = 0

DELETE FROM #Name WHERE Kingdom = 'kingdomtemp'

UPDATE N
	SET Phylum = FN.FlatNameCanonical
		, PhylumId = FN.FlatNameNameUFk
FROM #Name N
	INNER JOIN tblFlatName FN ON N.NameGuid = FN.FlatNameSeedName
			AND FN.FlatNameRankName IN ('Division','Phylum')
		INNER JOIN tblName NA ON FN.FlatNameNameUFk = NA.NameGuid
			AND ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET Class = FN.FlatNameCanonical
		, ClassId = FN.FlatNameNameUFk
FROM #Name N
	INNER JOIN tblFlatName FN ON N.NameGuid = FN.FlatNameSeedName
			AND FN.FlatNameRankName = 'Class'
		INNER JOIN tblName NA ON FN.FlatNameNameUFk = NA.NameGuid
			AND ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET [Order] = FN.FlatNameCanonical
		, OrderId = FN.FlatNameNameUFk
FROM #Name N
	INNER JOIN tblFlatName FN ON N.NameGuid = FN.FlatNameSeedName
			AND FN.FlatNameRankName = 'Order'
		INNER JOIN tblName NA ON FN.FlatNameNameUFk = NA.NameGuid
			AND ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET Family = FN.FlatNameCanonical
		, FamilyId = FN.FlatNameNameUFk
FROM #Name N
	INNER JOIN tblFlatName FN ON N.NameGuid = FN.FlatNameSeedName
			AND FN.FlatNameRankName = 'Family'
		INNER JOIN tblName NA ON FN.FlatNameNameUFk = NA.NameGuid
			AND ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET Genus = FN.FlatNameCanonical
		, GenusId = FN.FlatNameNameUFk
FROM #Name N
	INNER JOIN tblFlatName FN ON N.NameGuid = FN.FlatNameSeedName
			AND FN.FlatNameRankName = 'genus'
		INNER JOIN tblName NA ON FN.FlatNameNameUFk = NA.NameGuid
			AND ISNULL(NA.NameSuppress, 0) = 0

GO
-- delete extraneous names here

-- in ed.

GO
DECLARE @DB nvarchar(50)
SELECT @DB = DB_Name()

IF @DB = 'Names_Plants'
BEGIN
	UPDATE #Name  SET NameFormatted =     dbo.GetFullName(NameGuid, 1, 0, 1, 1, 0, '05239F83-EE34-471C-B536-7EA097EDE250', 0)
					, NamePartFormatted = dbo.GetFullName(NameGuid, 1, 0, 0, 0, 0, '05239F83-EE34-471C-B536-7EA097EDE250', 0)
END
ELSE IF @DB = 'Names_Fungi'
BEGIN
	UPDATE #Name  SET NameFormatted =     dbo.GetFullName(NameGuid, 1, 1, 1, 1, 0, '05239F83-EE34-471C-B536-7EA097EDE250', 0)
				    , NamePartFormatted = dbo.GetFullName(NameGuid, 1, 0, 0, 0, 0, '05239F83-EE34-471C-B536-7EA097EDE250', 0)
END
ELSE IF @DB = 'Names_NZAC'
BEGIN
	UPDATE #Name  SET NameFormatted =	  dbo.GetFullName(NameGuid, 1, 1, 1, 1, 0, '05239F83-EE34-471C-B536-7EA097EDE250', 0)
					, NamePartFormatted = dbo.GetFullName(NameGuid, 1, 0, 0, 0, 0, '05239F83-EE34-471C-B536-7EA097EDE250', 0)
END

GO
UPDATE #Name Set NameFormattedEscaped		= REPLACE(REPLACE(NameFormatted, '<i>', '_'), '</i>', '_')
UPDATE #Name Set NamePartFormattedEscaped	= REPLACE(REPLACE(NamePartFormatted, '<i>', '_'), '</i>', '_')

GO

-- basionym
UPDATE N
	SET Basionym = NA.NameFull
FROM #Name N
	INNER JOIN tblName NA ON N.BasionymFK = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET BasionymFk = NULL
FROM #Name N
	INNER JOIN tblName NA ON N.BasionymFK = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 1

-- current name
UPDATE N
	SET CurrentName = NA.NameFull
FROM #Name N
	INNER JOIN tblName NA ON N.CurrentFK = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET CurrentFK = NULL
FROM #Name N
	INNER JOIN tblName NA ON N.CurrentFK = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 1

-- based on
UPDATE N
	SET BasedOn = NA.NameFull
FROM #Name N
	INNER JOIN tblName NA ON N.BasedOnFk = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET BasedOnFk = NULL
FROM #Name N
	INNER JOIN tblName NA ON N.BasedOnFk = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 1

-- parent
UPDATE N
	SET Parent = NA.NameFull
FROM #Name N
	INNER JOIN tblName NA ON N.ParentFK = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET ParentFK = NULL
FROM #Name N
	INNER JOIN tblName NA ON N.ParentFK = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 1

-- blocking
UPDATE N
	SET Blocking = NA.NameFull
FROM #Name N
	INNER JOIN tblName NA ON N.BlockingFk = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET BlockingFk = NULL
FROM #Name N
	INNER JOIN tblName NA ON N.BlockingFk = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 1
-- AnamorphGenus
UPDATE N
	SET AnamorphGenus = NA.NameFull
FROM #Name N
	INNER JOIN tblName NA ON N.AnamorphGenusFk = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET AnamorphGenusFk = NULL
FROM #Name N
	INNER JOIN tblName NA ON N.AnamorphGenusFk = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 1
-- typetaxon
UPDATE N
	SET TypeTaxon = NA.NameFull
FROM #Name N
	INNER JOIN tblName NA ON N.TypeTaxonFK = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 0

UPDATE N
	SET TypeTaxonFK = NULL
FROM #Name N
	INNER JOIN tblName NA ON N.TypeTaxonFK = NA.NameGuid
WHERE ISNULL(NA.NameSuppress, 0) = 1

GO
--, ReferenceFK uniqueidentifier
--	, Reference nvarchar(max)

UPDATE N
	SET Reference = CAST(REPLACE(R.ReferenceGenCitation, '&', '&amp;') as xml)
FROM #Name N
	INNER JOIN tblReference R ON N.ReferenceFK = R.ReferenceID
WHERE ISNULL(R.ReferenceSuppress, 0) = 0

UPDATE N
	SET ReferenceFK = NULL
FROM #Name N
	INNER JOIN tblReference R ON N.ReferenceFK = R.ReferenceID
WHERE ISNULL(R.ReferenceSuppress, 0) = 1


--	, TaxonomyReferenceFk uniqueidentifier
--	, TaxonomyReference nvarchar(max)

UPDATE N
	SET TaxonomyReference = CAST(replace(R.ReferenceGenCitation, '&', '&amp;') AS xml)
FROM #Name N
	INNER JOIN tblReference R ON N.TaxonomyReferenceFk = R.ReferenceID
WHERE ISNULL(R.ReferenceSuppress, 0) = 0

UPDATE N
	SET TaxonomyReferenceFk = NULL
FROM #Name N
	INNER JOIN tblReference R ON N.TaxonomyReferenceFk = R.ReferenceID
WHERE ISNULL(R.ReferenceSuppress, 0) = 1
--	, ParentReferenceFK uniqueidentifier
--	, ParentReference nvarchar(max)

UPDATE N
	SET ParentReference = CAST(REPLACE(R.ReferenceGenCitation, '&', '&amp;') as xml)
FROM #Name N
	INNER JOIN tblReference R ON N.ParentReferenceFK = R.ReferenceID
WHERE ISNULL(R.ReferenceSuppress, 0) = 0

UPDATE N
	SET ParentReferenceFK = NULL
FROM #Name N
	INNER JOIN tblReference R ON N.ParentReferenceFK = R.ReferenceID
WHERE ISNULL(R.ReferenceSuppress, 0) = 1

--, AnamorphReferenceFK uniqueidentifier
--	, AnamorphReference nvarchar(max)

UPDATE N
	SET AnamorphReference = CAST(REPLACE(R.ReferenceGenCitation, '&', '&amp;') as xml)
FROM #Name N
	INNER JOIN tblReference R ON N.AnamorphReferenceFK = R.ReferenceID
WHERE ISNULL(R.ReferenceSuppress, 0) = 0

UPDATE N
	SET AnamorphReferenceFK = NULL
FROM #Name N
	INNER JOIN tblReference R ON N.AnamorphReferenceFK = R.ReferenceID
WHERE ISNULL(R.ReferenceSuppress, 0) = 1


GO

-- vernacular names
; WITH Vernacular AS(
	SELECT VernacularUseNameFk NameId
		, VU.VernacularUseCounterPk 
		, VU.VernacularUseAddedDate
		, VU.VernacularUseUpdatedDate
		, V.VernacularGuid
		, LV.LanguageEnglish LanguageOfOrigin
		, LV.LanguageISOCode LanguageOfOriginIso
		, V.VernacularAddedDate 
		, V.VernacularUpdatedDate 
		, V.VernacularName  
		, CASE ISNULL(V.VernacularEnglishTranslation, '')
				WHEN '' THEN NULL
				ELSE V.VernacularEnglishTranslation 
		 END AS VernacularEnglishTranslation
		, CASE ISNULL(V.VernacularEnglishTransliteration, '')
			WHEN '' THEN NULL
			else V.VernacularEnglishTransliteration
		 END AS VernacularEnglishTransliteration
		, VUGS.GeoRegionSchemaName AS RegionOfUseSchema
		, VUG.GeoRegionName AS RegionOfUse
		, L.LanguageISOCode LanguageOfUseIso
		, L.LanguageCounterPK LanguageOfUseId
		, L.LanguageEnglish  LanguageOfUse
		, VU.VernacularUseNote
	FROM tblVernacularUse VU
			INNER JOIN tblVernacular V ON VU.VernacularUseVernacularFk = V.VernacularGuid
						AND ISNULL(V.VernacularSuppress, 0) = 0
				LEFT JOIN tblLanguage LV ON V.VernacularLanguageFk = LV.LanguageCounterPK
			LEFT JOIN tblGeoRegion VUG ON VU.VernacularUseGeoRegionFk = VUG.GeoRegionCounterPK	
				LEFT JOIN tblGeoRegionSchema VUGS ON VUG.GeoRegionSchemaFK = VUGS.GeoRegionSchemaCounterPK
			LEFT JOIN tblLanguage L ON VU.VernacularUseLanguageFk = L.LanguageCounterPK
	WHERE ISNULL(VU.VernacularUseIsDeleted, 0) = 0
	AND ISNULL(VU.VernacularUseSuppress, 0) = 0
),
VernacularDistinct AS (
	SELECT DISTINCT NameId, vernacularName, VernacularGuid
	FROM Vernacular
)
, VernacularRegion AS (
	SELECT DISTINCT NameId, RegionOfUse
	FROM Vernacular
)
, VernacularLanguageUse AS (
	SELECT DISTINCT NameId, LanguageOfUse
	FROM Vernacular
)
, VernacularLanguageOrigin AS (
	SELECT DISTINCT NameId, LanguageOfOrigin
	FROM Vernacular
)
UPDATE N
	SET VernacularXML = (SELECT 
								V.VernacularUseCounterPk as '@id'
								, V.LanguageOfUseId '@languageOfUseId'
								, V.LanguageOfUse  '@languageOfUse'
								, V.LanguageOfOriginIso '@languageOfUseIso'
								, V.RegionOfUseSchema AS '@regionOfUseSchema'
								, V.RegionOfUse AS '@regionOfUse'
								, V.VernacularUseAddedDate as '@added'
								, V.VernacularUseUpdatedDate as '@updated'
								, LOWER(V.VernacularGuid)	'VernacularName/@vernacularId'
								, V.LanguageOfOrigin as 'VernacularName/@languageOfOrigin'
								, V.LanguageOfOriginIso as 'VernacularName/@languageOfOriginIso'
								, V.VernacularAddedDate as 'VernacularName/@added'
								, V.VernacularUpdatedDate as 'VernacularName/@updated'
								, V.VernacularName  AS 'VernacularName/text()'
								, V.VernacularEnglishTranslation  as Translation
								, V.VernacularEnglishTransliteration AS Trasliteration												
								, V.VernacularUseNote
							FROM Vernacular V
						 WHERE V.NameId = N.NameGuid
						FOR XML PATH('AppliedVernacular'), ROOT('AppliedVernaculars'), TYPE)
		
		, VernacularSOLRXML = (SELECT
									(SELECT 
										 (SELECT 'verncularId'					as '@name'			,	LOWER(VD.VernacularGuid)		as 'text()' for xml path('field'), TYPE)
		  								, (SELECT 'verncularName'				as '@name'			,	VD.VernacularName			as 'text()' for xml path('field'), TYPE)
									FROM VernacularDistinct VD
									WHERE VD.NameId = N.NameGuid
									FOR XML PATH(''), TYPE)
								, (SELECT
										(SELECT 'verncularRegionOfUse'		as '@name'			,	VR.RegionOfUse				as 'text()' for xml path('field'), TYPE)
									FROM VernacularRegion VR
									WHERE VR.NameId = N.NameGuid
									FOR XML PATH(''), TYPE)
								, (SELECT
										(SELECT 'verncularLanguageOfUse'		as '@name'			,	VLU.LanguageOfUse				as 'text()' for xml path('field'), TYPE)
									FROM VernacularLanguageUse VLU
									WHERE VLU.NameId = N.NameGuid
									FOR XML PATH(''), TYPE)
								, (SELECT
										(SELECT 'verncularLanguageOfOrigin'		as '@name'			,	VO.LanguageOfOrigin				as 'text()' for xml path('field'), TYPE)
									FROM VernacularLanguageOrigin VO
									WHERE VO.NameId = N.NameGuid
									FOR XML PATH(''), TYPE)
								FOR XML PATH(''), TYPE)
FROM #Name N
GO
-- biostatus
; WITH Biostatus AS (
						SELECT NB.NameBiostatusCounterPK AS BiostatusId
							, NB.NameBiostatusNameFk AS NameId
							, ISNULL(NB.NameBiostatusIsActive, 0)  IsActive									
							, CASE ISNULL(NB.NameBiostatusIsFirstRecord, 0) WHEN 0 THEN 'false' ELSE 'true' END AS 'FirstRecord'
							, NB.NameBiostatusAddedDate AS Added
							, NB.NameBiostatusUpdatedDate AS Updated
							, LOWER(R.ReferenceID) AS ReferenceId
							, REPLACE(R.ReferenceGenCitation, '&', '&amp;') AS BiostatusReference
							, B.BiostatusCodePK AS OriginCode
							, B.BioStatusDescription as Origin
							, O.OccurrenceCodePK as OccurrenceCode
							, O.OccurrenceDescription as Occurrence
							, O.OccurrenceSort
							, GS.GeoRegionSchemaName AS GeoregionSchema
							, G.GeoRegionName AS Georegion
							, CASE LEFT(CAST(NB.NameBiostatusComment as nvarchar(max)), 9)
								WHEN '<Not Set>' THEN NULL
								ELSE NB.NameBiostatusComment END AS Comment							
						FROM tblNameBiostatus NB
							LEFT JOIN tblReference R ON NB.NameBiostatusReferenceFk = R.ReferenceID
							LEFT JOIN tblBioStatus B ON NB.NameBiostatusBiostatusFk = B.BiostatusCodePK
							LEFT JOIN #Occurrence O ON NB.NameBiostatusOccurrenceFK = O.OccurrenceCodePK
							LEFT JOIN tblGeoRegion G ON NB.NameBiostatusGeoRegionFK = G.GeoRegionCounterPK
								LEFT JOIN tblGeoRegionSchema GS ON G.GeoRegionSchemaFK = GS.GeoRegionSchemaCounterPK
							
						WHERE NB.NameBiostatusNameFk IN (SELECT id from #TestList)
							AND ISNULL(NB.NameBiostatusIsDeleted, 0) = 0
)
, SortedList AS (
	SELECT NameId, Occurrence, OccurrenceCode, Origin, OriginCode, Georegion, GeoregionSchema
	, CASE OccurrenceCode
		WHEN 2.1 THEN 'yes' 
		WHEN 2.2 then 'yes'
		WHEN 2.0 THEN 'yes'
		WHEN 2.0 THEN 'yes'
		WHEN 3.0 then 'uncertain'
		WHEN 1.2 then 'yes'
		WHEN 1.4 THEN 'border'
		ELSE 'no'	
	 END AS NZRelevance
		, ROW_NUMBER() OVER(Partition BY NameId ORDER BY IsActive DESC, OccurrenceSort) as UseOrder	
	FROM Biostatus
	WHERE Georegion = 'New Zealand'
)
UPDATE N
	SET BiostatusXML = (SELECT B.BiostatusId AS '@id'
							, CASE ISNULL(B.IsActive, 0)
									WHEN 0 THEN 'false'
									ELSE
										CASE N.IsCurrent
											WHEN 0 THEN 'false'  -- set to false if the name is a synonym
											else 'true' END
									END AS '@isActive' 
							, B.FirstRecord AS '@isFirstRecord'
							, B.Added AS '@added'
							, B.Updated AS '@updated'
							, LOWER(B.ReferenceId) AS 'BiostatusReference/@referenceId'
							, CAST(B.BiostatusReference AS xml) AS BiostatusReference
							, B.OriginCode AS 'Origin/@code'
							, B.Origin as Origin
							, B.OccurrenceCode as 'Occurrence/@code'
							, B.Occurrence as Occurrence
							, B.GeoregionSchema AS 'Georegion/@schema'
							, B.Georegion AS Georegion
							, B.Comment 						
						FROM Biostatus B
						WHERE B.NameId = N.NameGuid						
						FOR XML PATH ('BiostatusValue'), ROOT('BiostatusValues'), TYPE)
		, NZRelevance = (SELECT TOP 1 NZRelevance FROM SortedList WHERE Nameid = N.NameGuid)
FROM #Name N
WHERE N.IsCurrent = 1

; WITH Biostatus AS
(
	SELECT  NameBiostatusAddedDate AS Added
		, NameBiostatusUpdatedDate AS Updated
		, NameBiostatusNameFk
		, R.ReferenceID
		, REPLACE(REPLACE(replace(R.ReferenceGenCitation, '&', '&amp;'), '<i>', '_'), '</i>', '_') AS Citation
		, replace(replace(replace(R.ReferenceGenCitation, '<i>', ''), '</i>', ''), '&', '&amp;') AS CitationUnformated
		, B.BioStatusDescription as Origin
		, O.OccurrenceDescription AS Occurrence
		, ROW_NUMBER() OVER(Partition BY NB.NameBiostatusNameFk ORDER BY O.OccurrenceSort)  AS UseOrder
	FROM tblNameBiostatus NB
				LEFT JOIN tblReference R ON NB.NameBiostatusReferenceFk = R.ReferenceID
				LEFT JOIN tblBioStatus B ON NB.NameBiostatusBiostatusFk = B.BiostatusCodePK
				LEFT JOIN #Occurrence  O ON NB.NameBiostatusOccurrenceFK = O.OccurrenceCodePK
				LEFT JOIN tblGeoRegion G ON NB.NameBiostatusGeoRegionFK = G.GeoRegionCounterPK
	WHERE  ISNULL(NB.NameBiostatusIsDeleted, 0) = 0
				AND NB.NameBiostatusIsActive = 1
				AND G.GeoRegionName = 'New Zealand'
)
UPDATE N
	SET BiostatusSOLRXML = (SELECT 			

							  (SELECT 'nzBiostatusAdded'			as '@name'			, B.Added								as 'text()' for xml path('field'), TYPE)
							, (SELECT CASE ISNULL(B.Updated, '')		WHEN '' THEN NULL ELSE 'nzbiostatusupdated'	END	as 'field/@name',	B.Updated	as 'field/text()' for xml path(''), TYPE) 	
							, (SELECT 'nzBiostatusReferenceId'		as '@name'			, LOWER(B.ReferenceID)					as 'text()' for xml path('field'), TYPE)
							, (SELECT 'nzBiostatusReference'		as '@name'			, CitationUnformated					as 'text()'	for xml path('field'), TYPE)
							, (SELECT 'nzBiostatusReferenceDisplay'	as '@name'			, Citation								as 'text()'	for xml path('field'), TYPE)
							, (SELECT 'nzOrigin'					as '@name'			, B.Origin								as 'text()' for xml path('field'), TYPE)
							, (SELECT 'nzOccurrence'				as '@name'			, B.Occurrence							as 'text()' for xml path('field'), TYPE)
						FROM Biostatus B
						WHERE B.NameBiostatusNameFk = N.NameGuid	
							AND B.UseOrder = 1					
						FOR XML PATH (''), /*ROOT('BiostatusValues'),*/ TYPE)

FROM #Name N
WHERE N.IsCurrent = 1

GO
-- hybrids
; WITH Hybrids AS
(SELECT HybridPK as HybridId
	, HybridNameFk AS NameId
	, HybridNodePreText as PreText
	, HybridNodePostText as PostText
	, HybridNodeNameFk as ParentNameId
	, HybridNodeNextHybridNodeFk as NextNodeId
	, 1 as [sequence]
	, N.NameFull
	, CAST(ISNULL(HybridNodePreText, '' ) + N.NameFull + COALESCE(HybridNodePostText + ' ', ' ') as nvarchar(max)) as FullHybrid
FROM tblHybrid H
	LEFT JOIN tblHybridNode HN ON H.HybridFirstHybridNodeFk = HN.HybridNodePk
		AND HN.delme IS NULL
	INNER JOIN tblName N ON HN.HybridNodeNameFk = N.NameGuid
		AND ISNULL(N.NameSuppress, 0)  = 0
WHERE H.delme is NULL
	AND H.HybridNameFk IN (SELECT Nameguid FROM #Name)

UNION ALL

SELECT H.HybridId, H.NameId
	, HN.HybridNodePreText, HN.HybridNodePostText
	, HN.HybridNodeNameFk, HN.HybridNodeNextHybridNodeFk
	, H.[sequence] + 1
	, N.NameFull
	, H.FullHybrid + COALESCE(HybridNodePreText + ' ', ' ' ) + N.NameFull + COALESCE(HybridNodePostText + ' ', ' ')
FROM Hybrids H
	INNER JOIN tblHybridNode HN ON H.NextNodeId = HN.HybridNodePk
	INNER JOIN tblName N ON HN.HybridNodeNameFk = N.NameGuid
		AND ISNULL(N.NameSuppress, 0)  = 0

)
, FinalSequence AS (
	SELECT DISTINCT HybridId, (SELECT MAX([sequence]) FROM Hybrids WHERE HybridId = H2.HybridId) AS FinalSequence
	FROM Hybrids H2
)
UPDATE N
	SET HybridXML = (SELECT
						(SELECT RTRIM(FullHybrid)  FROM Hybrids H
								INNER JOIN FinalSequence FS ON H.HybridId = FS.HybridId AND H.[sequence] = FS.FinalSequence
							WHERE H.NameId = N.NameGuid) as HybridText
						, (SELECT  ParentNameId '@nameId'
								, PreText  AS '@prefixText'
								, PostText AS '@suffixText'
								, NameFull 
								--TO DO -- ? ADD Formatted Name
							FROM Hybrids 
							WHERE NameId = N.NameGuid
							order by HybridId, [sequence] 
							FOR XML PATH('HybridParentName'), ROOT('HybridParentNames'), type)
						FOR XML PATH('HybridData'), ROOT('Hybridisation'), TYPE)
		, HybridSOLRXML = (SELECT 
								(SELECT 'hybridParentId'   as '@name', H.ParentNameId	as 'text()' for XML PATH('field'), TYPE)
								, (SELECT 'hybridParent'   as '@name', H.NameFull		as 'text()' for XML PATH('field'), TYPE)
							FROM Hybrids H
							WHERE NameId = N.NameGuid
							FOR XML PATH (''), TYPE)
							
FROM #Name N
WHERE N.NameGuid IN (SELECT NameId FROM Hybrids)
GO
--hyperlinks

; WITH Hyperlink AS (
	SELECT HyperLinkRecordFK
		, HyperLinkCaption as Caption
		, HyperLinkAddedDate as Added
		, HyperLinkUpdatedDate as Updated
		, HLT.HyperLinkTypeText as LinkType
		, HL.HyperLinkURL as LinkUrl
	FROM tblHyperLink HL
		INNER JOIN tblHyperLinkType HLT ON HL.HyperLinkTypeFK = HLT.HyperLinkTypePk
	WHERE ISNULL(HL.HyperLinkInvalid, 0) = 0
)
UPDATE N
	SET HyperLinkXML = (SELECT  Added as '@added'
							, Updated as '@updated'
							, LinkType as '@type'
							, LinkUrl
							, Caption

						FROM Hyperlink
						WHERE HyperLinkRecordFK = CAST(N.NameGUID as nvarchar(50))
						FOR XML PATH('Hyperlink'), ROOT('Hyperlinks'), TYPE)
		, HybridSOLRXML = (SELECT
							(SELECT 'hyperLinkType'   as '@name', LinkType	as 'text()' for XML PATH('field'), TYPE)
						FROM Hyperlink
						WHERE HyperLinkRecordFK = CAST(N.NameGUID as nvarchar(50))
						FOR XML PATH(''), TYPE)

FROM #Name N

GO
-- specimens
; WITH SpecimenSummary AS(
	SELECT S.SpecimenGuid
		, S.SpecimenId
		, S.AccessionNumber
		, CO.Acronym as CollectionAcronym
		, TS.TypeStatus
		, WN.SourceNameId
		, CE.StartDate
		, Ce.VerbatimCollector
		, (SELECT GR.GeoRegion '@georegion', GRS.GeoRegionSchema '@georegionSchema'
				FROM cis_chr.spec.CollectionEventRegion CER 
					INNER JOIN cis_chr.spec.CollectionEventRegionValue CERV ON CER.CollectionEventRegionId = CERV.CollectionEventRegionId
						INNER JOIN cis_chr.spec.GeoRegion GR ON CERV.GeoRegionId = GR.GeoRegionId
							INNER JOIN cis_chr.spec.GeoRegionSchema GRS ON GR.GeoRegionSchemaId = GRS.GeoRegionSchemaId
				WHERE CE.CollectionEventId = CER.CollectionEventId
				FOR XML PATH('CollectionEventRegion'), TYPE) AS CollectionEventRegions
		, (SELECT IL.ImageURL as '@imageUrl'
			FROM CIS_CHR.system.ImageLink IL
			WHERE IL.SourceId = S.SpecimenId AND IL.SourceTable = 'tblSpecimen'
			FOR XML PATH('Image'), TYPE) as CollectionObjectImages
	FROM cis_chr.spec.Specimen S
		INNER JOIN cis_chr.spec.SpecimenComponent SC ON S.specimenId = SC.SpecimenId
			INNER JOIN CIS_CHR.spec.Identification I ON SC.SpecimenComponentId = I.SpecimenComponentId
					AND I.IsActive = 1
					AND I.SecurityLevelId = 40
				INNER JOIN cis_chr.spec.IdentificationName IdN ON I.IdentificationId = IdN.IdentificationId
					INNER JOIN cis_chr.wName.WorkingName WN ON IdN.WorkingNameId = WN.WorkingNameId
		LEFT JOIN cis_chr.spec.TypeStatus TS ON S.TypeStatusId = TS.TypeStatusId
			AND ISNULL(TS.IsNotType, 0) = 0
		LEFT JOIN cis_chr.Spec.CollectionEventSpecimen CES ON S.SpecimenId = CES.SpecimenId
					AND CES.IsPrimary = 1
			LEFT JOIN cis_chr.spec.CollectionEvent CE ON CES.CollectionEventId = CE.CollectionEventId
		INNER JOIN cis_chr.spec.[Collection] CO ON S.CollectionId = CO.CollectionId		
	WHERE S.SecurityLevelId = 40
		AND CO.Acronym = 'CHR' -- do not include RARE records
		AND WN.SourceNameId IN (SELECT NameGuid FROM #Name)
		
		UNION ALL

		SELECT S.SpecimenGuid
		, S.SpecimenId
		, S.AccessionNumber
		, CO.Acronym as CollectionAcronym
		, TS.TypeStatus
		, WN.SourceNameId
		, CE.StartDate
		, Ce.VerbatimCollector
		, (SELECT GR.GeoRegion '@georegion', GRS.GeoRegionSchema '@georegionSchema'
				FROM cis_chr.spec.CollectionEventRegion CER 
					INNER JOIN cis_chr.spec.CollectionEventRegionValue CERV ON CER.CollectionEventRegionId = CERV.CollectionEventRegionId
						INNER JOIN cis_chr.spec.GeoRegion GR ON CERV.GeoRegionId = GR.GeoRegionId
							INNER JOIN cis_chr.spec.GeoRegionSchema GRS ON GR.GeoRegionSchemaId = GRS.GeoRegionSchemaId
				WHERE CE.CollectionEventId = CER.CollectionEventId
				FOR XML PATH('CollectionEventRegion'), TYPE) AS CollectionEventRegions
		, (SELECT IL.ImageURL as '@imageUrl'
			FROM CIS_CHR.system.ImageLink IL
			WHERE IL.SourceId = S.SpecimenId AND IL.SourceTable = 'tblSpecimen'
			FOR XML PATH('Image'), TYPE) as CollectionObjectImages
	FROM CIS_ICMP.spec.Specimen S
		INNER JOIN CIS_ICMP.spec.SpecimenComponent SC ON S.specimenId = SC.SpecimenId
			INNER JOIN CIS_ICMP.spec.Identification I ON SC.SpecimenComponentId = I.SpecimenComponentId
					AND I.IsActive = 1
					AND I.SecurityLevelId = 40
				INNER JOIN CIS_ICMP.spec.IdentificationName IdN ON I.IdentificationId = IdN.IdentificationId
					INNER JOIN CIS_ICMP.wName.WorkingName WN ON IdN.WorkingNameId = WN.WorkingNameId
		LEFT JOIN CIS_ICMP.spec.TypeStatus TS ON S.TypeStatusId = TS.TypeStatusId
			AND ISNULL(TS.IsNotType, 0) = 0
		LEFT JOIN CIS_ICMP.Spec.CollectionEventSpecimen CES ON S.SpecimenId = CES.SpecimenId
					AND CES.IsPrimary = 1
			LEFT JOIN CIS_ICMP.spec.CollectionEvent CE ON CES.CollectionEventId = CE.CollectionEventId
		INNER JOIN CIS_ICMP.spec.[Collection] CO ON S.CollectionId = CO.CollectionId		
	WHERE S.SecurityLevelId = 40
		AND WN.SourceNameId IN (SELECT NameGuid FROM #Name)

	UNION ALL

		SELECT S.SpecimenGuid
		, S.SpecimenId
		, S.AccessionNumber
		, CO.Acronym as CollectionAcronym
		, TS.TypeStatus
		, WN.SourceNameId
		, CE.StartDate
		, Ce.VerbatimCollector
		, (SELECT GR.GeoRegion '@georegion', GRS.GeoRegionSchema '@georegionSchema'
				FROM cis_chr.spec.CollectionEventRegion CER 
					INNER JOIN cis_chr.spec.CollectionEventRegionValue CERV ON CER.CollectionEventRegionId = CERV.CollectionEventRegionId
						INNER JOIN cis_chr.spec.GeoRegion GR ON CERV.GeoRegionId = GR.GeoRegionId
							INNER JOIN cis_chr.spec.GeoRegionSchema GRS ON GR.GeoRegionSchemaId = GRS.GeoRegionSchemaId
				WHERE CE.CollectionEventId = CER.CollectionEventId
				FOR XML PATH('CollectionEventRegion'), TYPE) AS CollectionEventRegions
		, (SELECT IL.ImageURL as '@imageUrl'
			FROM CIS_CHR.system.ImageLink IL
			WHERE IL.SourceId = S.SpecimenId AND IL.SourceTable = 'tblSpecimen'
			FOR XML PATH('Image'), TYPE) as CollectionObjectImages
	FROM CIS_NZAC.spec.Specimen S
		INNER JOIN CIS_NZAC.spec.SpecimenComponent SC ON S.specimenId = SC.SpecimenId
			INNER JOIN CIS_NZAC.spec.Identification I ON SC.SpecimenComponentId = I.SpecimenComponentId
					AND I.IsActive = 1
					AND I.SecurityLevelId = 40
				INNER JOIN CIS_NZAC.spec.IdentificationName IdN ON I.IdentificationId = IdN.IdentificationId
					INNER JOIN CIS_NZAC.wName.WorkingName WN ON IdN.WorkingNameId = WN.WorkingNameId
		LEFT JOIN CIS_NZAC.spec.TypeStatus TS ON S.TypeStatusId = TS.TypeStatusId
			AND ISNULL(TS.IsNotType, 0) = 0
		LEFT JOIN CIS_NZAC.Spec.CollectionEventSpecimen CES ON S.SpecimenId = CES.SpecimenId
					AND CES.IsPrimary = 1
			LEFT JOIN CIS_NZAC.spec.CollectionEvent CE ON CES.CollectionEventId = CE.CollectionEventId
		INNER JOIN CIS_NZAC.spec.[Collection] CO ON S.CollectionId = CO.CollectionId		
	WHERE S.SecurityLevelId = 40
		AND WN.SourceNameId IN (SELECT NameGuid FROM #Name)

	UNION ALL

		SELECT S.SpecimenGuid
		, S.SpecimenId
		, S.AccessionNumber
		, CO.Acronym as CollectionAcronym
		, TS.TypeStatus
		, WN.SourceNameId
		, CE.StartDate
		, Ce.VerbatimCollector
		, (SELECT GR.GeoRegion '@georegion', GRS.GeoRegionSchema '@georegionSchema'
				FROM cis_chr.spec.CollectionEventRegion CER 
					INNER JOIN cis_chr.spec.CollectionEventRegionValue CERV ON CER.CollectionEventRegionId = CERV.CollectionEventRegionId
						INNER JOIN cis_chr.spec.GeoRegion GR ON CERV.GeoRegionId = GR.GeoRegionId
							INNER JOIN cis_chr.spec.GeoRegionSchema GRS ON GR.GeoRegionSchemaId = GRS.GeoRegionSchemaId
				WHERE CE.CollectionEventId = CER.CollectionEventId
				FOR XML PATH('CollectionEventRegion'), TYPE) AS CollectionEventRegions
		, (SELECT IL.ImageURL as '@imageUrl'
			FROM CIS_CHR.system.ImageLink IL
			WHERE IL.SourceId = S.SpecimenId AND IL.SourceTable = 'tblSpecimen'
			FOR XML PATH('Image'), TYPE) as CollectionObjectImages
	FROM CIS_PDD.spec.Specimen S
		INNER JOIN CIS_PDD.spec.SpecimenComponent SC ON S.specimenId = SC.SpecimenId
			INNER JOIN CIS_PDD.spec.Identification I ON SC.SpecimenComponentId = I.SpecimenComponentId
					AND I.IsActive = 1
					AND I.SecurityLevelId = 40
				INNER JOIN CIS_PDD.spec.IdentificationName IdN ON I.IdentificationId = IdN.IdentificationId
					INNER JOIN CIS_PDD.wName.WorkingName WN ON IdN.WorkingNameId = WN.WorkingNameId
		LEFT JOIN CIS_PDD.spec.TypeStatus TS ON S.TypeStatusId = TS.TypeStatusId
			AND ISNULL(TS.IsNotType, 0) = 0
		LEFT JOIN CIS_PDD.Spec.CollectionEventSpecimen CES ON S.SpecimenId = CES.SpecimenId
					AND CES.IsPrimary = 1
			LEFT JOIN CIS_PDD.spec.CollectionEvent CE ON CES.CollectionEventId = CE.CollectionEventId
		INNER JOIN CIS_PDD.spec.[Collection] CO ON S.CollectionId = CO.CollectionId		
	WHERE S.SecurityLevelId = 40
		AND WN.SourceNameId IN (SELECT NameGuid FROM #Name)


)
UPDATE N
	SET  CollectionObjectXML = (SELECT SpecimenGuid as '@specimenGuid'
								, SpecimenId as '@specimenId'
								, AccessionNumber as '@accessionNumber'
								, CollectionAcronym as '@collectionAcronym'
								, TypeStatus as '@typeStatus'
								, StartDate as '@collectionDateISO'
								, VerbatimCollector as Collector
								, CollectionEventRegions
								, CollectionObjectImages
							FROM SpecimenSummary
							WHERE SourceNameId = N.NameGuid
							FOR XML PATH('CollectionObject'), ROOT('CollectionObjects'), TYPE)

FROM #Name N 



-- notes
--SELECT * FROM Names_nzac.dbo.tblNameNoteType
DECLARE @DB nvarchar(50)
select @DB = DB_Name()

DECLARE @AllowedNoteTypes TABLE(TypeId int, NamesInstance nvarchar(50) )

INSERT INTO @AllowedNoteTypes
VALUES --(4,  'Names_Plants') --'copyright/intellectual property information'
	  (1,  'Names_Plants') -- 'editorial',
	 , (7,  'Names_Plants') --	taxonomic status
	 , (10, 'Names_Plants') --typification
	 , (11, 'Names_Plants') --Etymology
	 , (13, 'Names_Plants') --Emendavit
	 , (14, 'Names_Plants') --ex Author(s)
	 , (1,  'Names_Fungi') -- 'editorial',
	 , (7,  'Names_Fungi') --	taxonomic status
	 , (10, 'Names_Fungi') --	typification
	 , (11, 'Names_Fungi') --	Etymology
	 , (12, 'Names_Fungi') --	Compilation
	 , (13, 'Names_Fungi') --	Authority 
	 , (1,  'Names_NZAC')	--editorial
	 , (7,  'Names_NZAC')	--	taxonomic status
	 , (10, 'Names_NZAC')	--	typification
	 , (11, 'Names_NZAC')	--	Etymology

; WITH Notes as (
SELECT NNT.NoteTypeText  AS NoteType
	, NN.NameNoteCounterPK AS Id
	, NN.NameNoteAddedDate aS added
	, NN.NameNoteUpdatedWhen  AS Updated
	, NN.NameNoteText  as [Text]
	, NN.NameNoteReferenceFk as ReferenceId
	, CAST(REPLACE(R.ReferenceGenCitation, '&', '&amp;') as XML) AS Reference
	, NN.NameNoteNameFk AS NameId
FROM tblNameNotes NN
	INNER JOIN tblNameNoteType NNT ON NN.NameNoteTypeFK = NNT.NoteTypeCounterPK
	LEFT JOIN tblReference R ON NN.NameNoteReferenceFk = R.ReferenceID
		AND ISNULL(R.ReferenceIsDeleted, 0) = 0
WHERE NN.NameNoteTypeFK IN (SELECT TypeId from @AllowedNoteTypes WHERE NamesInstance = @db)
	AND ISNULL(NN.NameNoteIsDeleted, 0) = 0)
UPDATE NA
	SET NotesXML = (SELECT
						Id AS '@id' 
						, NoteType as '@type'
						, added as '@added'
						, Updated as '@updated'
						, [Text]
						, ReferenceId AS 'Reference/@referenceId'
						, Reference
					FROM Notes N
					WHERE N.NameId = NA.NameGuid
					FOR XML PATH('Note'), ROOT('Notes'), TYPE)
		, NotesSOLRXML = (SELECT					
							    (SELECT 'note'			as '@name'			, [Text]				as 'text()' for xml path('field'), TYPE)
							  , (SELECT 'noteType'		as '@name'			, NoteType				as 'text()' for xml path('field'), TYPE)
						FROM Notes N
						WHERE N.NameId = NA.NameGuid
					FOR XML PATH(''), TYPE)
		
FROM #Name NA

GO
-- nomenclatural status
--SELECT * FROM tblNomenclaturalStatusType
; WITH StatusNotes as (
SELECT NST.NomenclaturalStatusTypeText  AS StatusType
	, NS.NomenclaturalStatusCounterPK AS Id
	, NS.NomenclaturalStatusAddedDate aS added
	, NS.NomenclaturalStatusUpdatedDate  AS Updated
	, NS.NomenclaturalStatusComment  as Comment
	, NS.NomenclaturalStatusReferenceFk as ReferenceId
	, CAST(REPLACE(R.ReferenceGenCitation, '&', '&amp;') as XML) AS Reference
	, NS.NomenclaturalStatusNameFk AS NameId
	, ISNULL(NS.NomenclaturalStatusIsTrue, 1) AS IsTrue
FROM tblNomenclaturalStatus NS
	INNER JOIN tblNomenclaturalStatusType NST ON NS.NomenclaturalStatusStatusTypeFK = NST.NomenclaturalStatusTypeCounterPK
	LEFT JOIN tblReference R ON Ns.NomenclaturalStatusReferenceFk = R.ReferenceID
		AND ISNULL(R.ReferenceIsDeleted, 0) = 0
WHERE ISNULL(NS.NomenclaturalStatusIsDeleted, 0) = 0)
UPDATE NA
	SET NomenclaturalStatusXML = (SELECT
						Id AS '@id' 
						, StatusType as '@type'
						, CASE IsTrue WHEN 1 THEN 'true' ELSE 'false' END '@isTrue'
						, added as '@added'
						, Updated as '@updated'
						, Comment
						, ReferenceId AS 'Reference/@referenceId'
						, Reference
					FROM StatusNotes SN
					WHERE SN.NameId = NA.NameGuid
					FOR XML PATH('NomenclaturalStatus'), ROOT('NomenclaturalStatusValues'), TYPE)

	-- add true status values to SOLR index
		, NomenclaturalStatusSOLR = (SELECT
							   (SELECT 'statusType'		as '@name'			, StatusType				as 'text()' for xml path('field'), TYPE)
						FROM StatusNotes SN
						WHERE SN.NameId = NA.NameGuid
							AND SN.IsTrue = 1
					FOR XML PATH(''), TYPE)
		
FROM #Name NA


-- keys
; WITH Keys as (
SELECT DISTINCT KD.KeyDataNameFk as NameId
	, K.KeyReferenceFk as ReferenceId
	, K.KeyPk  AS KeyId
FROM tblKeyData KD
	INNER JOIN tblKey K ON KD.KeyDataKeyFk = K.KeyPk
		INNER JOIN tblReference R ON K.KeyReferenceFk = R.ReferenceID
			AND ISNULL(R.ReferenceIsDeleted, 0) = 0
			AND ISNULL(R.ReferenceSuppress, 0) = 0
	)
UPDATE N
	SET KeyXML = (SELECT LOWER(DB_Name()) + '-key-' +  CAST(keyId as nvarchar(10)) as '@keyId'
						, ReferenceId as '@referenceId'
					FROM keys 
					WHERE Nameid = N.NameGuid
					FOR XML PATH('Key'), ROOT('InKeys'), TYPE)
FROM #Name N

-- concepts + descriptions
; WITH Concepts AS (
	SELECT BibliographyNameFk AS NameId
		, B.BibliographyAddedDate AS Added
		, B.BibliographyUpdatedDate AS Updated
		, B.BibliographyGuid as Id
		, B.BibliographyName as [Name]
		, B.BibliographyOrthographyVariant as Orthography
		, B.BibliographyPage  as [Page]
		, ISNULL(B.BibliographyExplicit, 0) [Explicit]
		, B.BibliographyReferenceFk ReferenceId
		, CAST(REPLACE(R.ReferenceGenCitation, '&', '&amp;') as xml) as AccordingTo	
			
	FROM tblBibliography B 
		INNER JOIN tblReference R ON B.BibliographyReferenceFk = R.ReferenceID
			AND ISNULL(R.ReferenceIsDeleted, 0) = 0
			AND ISNULL(R.ReferenceSuppress, 0) = 0
	WHERE ISNULL(B.BibliographyIsDeleted, 0) = 0
)
, Relationships AS
(
	SELECT 'normal'  as direction
		, BR.BibliographyRelationshipBibliographyFromFk  ConceptId1
		, BR.BibliographyRelationshipBibliographyToFk  ConceptId2
		, N.NameGuid AS NameId
		, N.NameFull NameFullConcept2
		, BR.BibliographyRelationshipDateAdded  Added
		, BR.BibliographyRelationshipPk    RelationshipId
		, BRT.BibliographyRelationshipTypeText RelationshipType
	FROM tblBibliographyRelationship BR
		INNER JOIN tblBibliographyRelationshipType BRT ON BR.BibliographyRelationshipTypeFk = BRT.BibliographyRelationshipTypePk
		INNER JOIN tblBibliography B ON BR.BibliographyRelationshipBibliographyToFk = B.BibliographyGuid
			INNER JOIN tblName N ON B.BibliographyNameFk = N.NameGuid
	WHERE ISNULL(B.BibliographyIsDeleted, 0) = 0

UNION ALL

	SELECT 'inverse'  as inversion
		, BR.BibliographyRelationshipBibliographyToFk
		, BR.BibliographyRelationshipBibliographyFromFk  
		, N.NameGuid AS NameId
		, N.NameFull AS NameFullConcept2
		, BR.BibliographyRelationshipDateAdded
		, BR.BibliographyRelationshipPk
		, BRT.InverseText
	FROM tblBibliographyRelationship BR
		INNER JOIN tblBibliographyRelationshipType BRT ON BR.BibliographyRelationshipTypeFk = BRT.BibliographyRelationshipTypePk
		INNER JOIN tblBibliography B ON BR.BibliographyRelationshipBibliographyFromFk = B.BibliographyGuid
			INNER JOIN tblName N ON B.BibliographyNameFk = N.NameGuid
	WHERE ISNULL(B.BibliographyIsDeleted, 0) = 0
)
UPDATE N
	SET ConceptsXML = (SELECT id '@id'
							,  CASE [Explicit] WHEN 1 THEN 'true' else 'false' end AS '@explicit'
							, Added as '@added'
							, Updated as '@updated'
							, [Name]
							, Orthography
							, [Page]
							, ReferenceId AS 'AccordingTo/@referenceId'
							, AccordingTo
							, (SELECT 
									BK.BibliographyKeywordText As 'text()'
								FROM tblBibliographyKeyword BK
								WHERE BK.BibliographyKeywordBibliographyFk = C.id
								FOR XML PATH('Keyword'), ROOT('Keywords'), TYPE)
							, (SELECT R.direction as '@direction'
									, R.RelationshipType  as '@type'
									, R.ConceptId2 AS '@conceptId'
									, R.Added as '@added'
									, R.NameId AS 'RelatedTaxon/@nameId'
									, R.NameFullConcept2 AS RelatedTaxon
								FROM Relationships R
								WHERE R.ConceptId1 = C.id
								ORDER BY R.RelationshipId, direction, R.NameFullConcept2
								FOR XML PATH('RelatedConcept'), ROOT('RelatedConcepts'), TYPE)
						    , (SELECT DescriptionGuid '@id'
									, DT.[Type] AS '@type' 
									, DC.Category  '@category'
									, AddedDate '@added'
									, UpdatedDate '@updated'
									, L.LanguageEnglish '@language'
									, L.LanguageISOCode '@languageIso'
									, DescriptionIconFilename 
									, DescriptionText
									, DescriptionUrl
								FROM tblDescription D
									LEFT JOIN tblDescriptionType DT ON D.DescriptionTypeFk = DT.DescriptionTypeGuid
									LEFT JOIN tblDescriptionCategory DC ON D.DescriptionCategoryFk = DC.DescriptionCategoryGuid
									LEFT JOIN tblLanguage L ON D.LanguageFk = L.LanguageCounterPK
								WHERE D.BibliographyFk = C.id
								FOR XML PATH('Description'), ROOT('Descriptions'), TYPE)
						FROM Concepts C
						WHERE C.NameId = N.NameGuid
						FOR XML PATH('Concept'), ROOT('Concepts'), TYPE)
FROM #Name N

GO



-- images
UPDATE N
	SET ImageXML = (SELECT ImageURL AS '@imageURI'
					FROM tblImageLink IL 
					WHERE IL.RecordID = N.NameGuid
					FOR XML PATH('Image'), ROOT('Images'), TYPE)
		, ImageSOLRXML = (SELECT
							(SELECT 'imageUri'			as '@name'			, ImageURL				as 'text()' for xml path('field'), TYPE)
						FROM tblImageLink IL 
						WHERE IL.RecordID = N.NameGuid
					FOR XML PATH(''), TYPE)
FROM #Name N

-- external links
; WITH ExternalLink AS
(SELECT EN.ExternalNameId as Id
	, NameGuid 
	, ExternalID
	, ExternalGuid
	, ExternalNameURL  
	, ExternalNameFullName  AS ExternalFullName
	, ES.[Name] aS  ExternalSource
	--, ES.Category
	--, ES.RetrieveUrl
FROM tblExternalName EN
	INNER JOIN ext.ExternalSource ES ON EN.ExternalSourceId = ES.ExternalSourceId)
UPDATE N
	SET ExternalLinkXML = (SELECT Id AS '@id'
								, ExternalID as '@externalId'
								, ExternalGuid as '@externalGuid'
								, ExternalNameURL AS '@url'
								, ExternalSource as '@source'
								, ExternalFullName
								
							FROM ExternalLink EL
							WHERE EL.NameGuid = N.NameGuid
							FOR XML PATH('ExternalLink'), ROOT('ExternalLinks'), TYPE)
		, ExternalLinkSOLRXML = (SELECT
							(SELECT 'externalLinkSource'			as '@name'			, ExternalSource				as 'text()' for xml path('field'), TYPE)
						FROM (SELECT DISTINCT ExternalSource, NameGuid FROM ExternalLink) EL 
						WHERE EL.NameGuid = N.NameGuid
					FOR XML PATH(''), TYPE)
FROM #Name N

GO

-- deprecatedIds
UPDATE N
	SET DeprecatedIdSOLR = (SELECT 
								(SELECT 'deprecatedId'	as '@name', lower(DeprecatedOldKey)	as 'text()' for xml path('field'), TYPE) 
							FROM tblDeprecated D 
							WHERE D.DeprecatedNewKey = CAST(N.NameGuid as nvarchar(50)) FOR XML PATH(''), TYPE)
FROM #Name N
	

-- standardise fields - convert '' to NULL to reduce number of elements
UPDATE #Name SET YearOfPublication = NULL	WHERE YearOfPublication = ''
UPDATE #Name SET YearOnPublication = NULL	WHERE YearOnPublication = ''
UPDATE #Name SET SanctioningAuthor = NULL	WHERE SanctioningAuthor = ''
UPDATE #Name SET SanctioningPage = NULL		WHERE SanctioningPage = ''
UPDATE #Name SET TypeLocality = NULL		WHERE TypeLocality = ''
UPDATE #Name SET Orthography = NULL			WHERE Orthography = ''
UPDATE #Name SET HybridLink = NULL			WHERE HybridLink = '' OR HybridLink = ' '
UPDATE #Name SET [Page] = NULL				WHERE [Page] = ''

-- add calculated fields

--SELECT * FROM names_nzac.dbo.tblReferenceFormatStyle

--  05239F83-EE34-471C-B536-7EA097EDE250	Abbreviated  -- Names_Plants, Names_Fungi, Names_NZAC
-- 
GO


-- generate result
SELECT LOWER(NameGuid) as '@nameId'
	, 'name' as '@documentClass'
	, [Source] '@source'
	, AddedDate  '@added'
	, UpdatedDate '@updated'
	, NamePart  'Name/@namePart'
	, Canonical 'Name/@canonical'
	, CASE ISNULL(InCitation, 0)		WHEN 0 THEN 'false' else 'true' end 'Name/@inCitation'
	, CASE ISNULL(Misapplied, 0)		WHEN 0 THEN 'false' else 'true' end 'Name/@misapplied'
	, CASE ISNULL(Dubium, 0)			WHEN 0 THEN 'false' else 'true' end 'Name/@dubium'
	, CASE ISNULL(ProParte, 0)			WHEN 0 THEN 'false' else 'true' end 'Name/@proParte'
	, CASE ISNULL(Novum, 0)				WHEN 0 THEN 'false' else 'true' end 'Name/@novum'
	, CASE ISNULL(Invalid, 0)			WHEN 0 THEN 'false' else 'true' end 'Name/@invalid'
	, CASE ISNULL(Illegitimate, 0)		WHEN 0 THEN 'false' else 'true' end 'Name/@illegitimate'
	, CASE ISNULL(Autonym, 0)			WHEN 0 THEN 'false' else 'true' end 'Name/@autonym' 
	, CASE ISNULL(IsRecombination, 0)	WHEN 0 THEN 'false' else 'true' end 'Name/@recombination'
	, CASE ISNULL([Aggregate], 0)		WHEN 0 THEN 'false' else 'true' end 'Name/@isAggregate' 
	, CASE ISNULL(IsAnamorph, 0)		WHEN 0 THEN 'false' else 'true' end 'Name/@isAnamorph'
	, NomCode as 'Name/@nomCode'
	, CASE ISNULL(Suppress, 0)			WHEN 0 THEN 'false' else 'true' end  as 'Name/@isSuppressed'
	, TaxonRank 'Name/@taxonRank'
	, TaxonRankSort 'Name/@taxonRankSort'
	, NZRelevance AS 'Name/@nzRelevance'
	, NameFull	
	, CAST(REPLACE(NameFormatted, '&', '&amp;') as XML) NameFormatted
	, CAST(REPLACE(NamePartFormatted, '&', '&amp;') as XML) NamePartFormatted
	, Orthography
	, [Page]
	, YearOfPublication
	, YearOnPublication
	, ClassificationFK as 'Classification/@id'
	, [Classification]
	, TypeLocality
	, SanctioningAuthor 
	, SanctioningPage
	, HybridLink
	, CheckStatus 
	, LOWER(ReferenceFK) AS 'NameReference/@referenceId'
	, Reference as NameReference
	, LOWER(TaxonomyReferenceFk)	as 'TaxonomyReference/@referenceId'
	, TaxonomyReference 	
	, LOWER(ParentReferenceFK)		AS 'ParentReference/@referenceId'
	, ParentReference		
	, LOWER(ParentFK)				as 'Parent/@nameId'
	, Parent						as 'Parent/text()'
	, LOWER(CurrentFK)				as 'CurrentName/@nameId'
	, CurrentName					as 'CurrentName/text()'
	, LOWER(BasionymFK)				as 'Basionym/@nameId'
	, Basionym						as 'Basionym/text()'
	, LOWER(BasedOnFk)				AS 'BasedOn/@nameId'
	, BasedOn						AS 'BasedOn/text()'
	, LOWER(BlockingFk)				AS 'Blocking/@nameId'
	, Blocking						AS 'Blocking/text()'
	, LOWER(AnamorphGenusFk)		AS 'AnamorphGenus/@nameId'
	, AnamorphGenus					AS 'AnamorphGenus/text()'
	, LOWER(AnamorphReferenceFK)	AS 'AnamorphReference/@referenceId'
	, AnamorphReference		
	, LOWER(TypeTaxonFK)			AS 'TypeTaxon/@nameId'
	, TypeTaxon						AS 'TypeTaxon/text()'
	, LOWER(ForeignId) AS ForeignId
	
	, LOWER(KingdomId)		AS 'Kingdom/@nameId'
	, Kingdom				AS 'Kingdom/text()'
	, LOWER(PhylumId)		AS 'Phylum/@nameId'
	, Phylum				AS 'Phylum/text()'
	, LOWER(ClassId)		AS 'Class/@nameId'
	, [Class]				AS 'Class/text()'
	, LOWER(OrderId)		AS 'Order/@nameId'
	, [Order]				AS 'Order/text()'
	, LOWER(FamilyId)		AS 'Family/@nameId'
	, Family				AS 'Family/text()'
	, VernacularXML.query('(//AppliedVernaculars)[1]')
	, BiostatusXML.query('(//BiostatusValues)[1]')
	, ConceptsXML.query('(//Concepts)[1]')
	, NotesXML.query('(//Notes)[1]')
	, ImageXML.query('(//Images)[1]')
	, ExternalLinkXML.query('(//ExternalLinks)[1]')
	, NomenclaturalStatusXML.query('(//NomenclaturalStatusValues)[1]')
	, HybridXML.query('(//Hybridisation)[1]')
	, HyperLinkXML.query('(//Hyperlinks)[1]')
	, CollectionObjectXML.query('(//CollectionObjects)[1]')
	, KeyXML.query('(//InKeys)[1]')
FROM #Name N
FOR XML PATH('Document'), ROOT('Documents')

SELECT  
		(SELECT 'source'		as '@name'			,	DB_Name()				as 'text()' for xml path('field'), TYPE)
	,	(SELECT 'id'			as '@name'			,	lower(NameGuid)			as 'text()' for xml path('field'), TYPE)
	,	(SELECT 'documentClass' as '@name'			,	'name'					as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'nameFull'		as '@name'			,	NameFull				as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'title'			as '@name'			,	NameFormattedEscaped	as 'text()' for xml path('field'), TYPE) 
	,   (SELECT 'titleUnformatted' 	as '@name'		,	NameFull				as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'namePart'		as '@name'			,	NamePart				as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'namePartFormatted'  as '@name'		,  NamePartFormattedEscaped as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'nameFormatted' as '@name'			,   NameFormattedEscaped	as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'canonical'		as '@name'			,	Canonical				as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'nomCode'		as '@name'			,	NomCode					as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'kingdom'		as '@name'			,	Kingdom					as 'text()' for xml path('field'), TYPE)
	,   CASE ISNULL(Phylum, '')
			WHEN '' THEN NULL
			ELSE (SELECT 'phylum'		as '@name'			,	Phylum			as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL(Phylum, '')
			WHEN '' THEN NULL
			ELSE (SELECT 'phylumId'		as '@name'			,	PhylumId		as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL(class, '') 
			WHEN '' THEN NULL
			ELSE (SELECT 'class'			as '@name'			,	[Class]		as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL(class, '') 
			WHEN '' THEN NULL
			ELSE (SELECT 'classId'			as '@name'			,	[ClassId]	as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL([order], '') 
			WHEN '' THEN NULL
			ELSE (SELECT 'order'			as '@name'			,	[order]		as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL([order], '') 
			WHEN '' THEN NULL
			ELSE (SELECT 'orderId'			as '@name'			,	[OrderId]	as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL(family, '')
			WHEN '' THEN NULL
			ELSE (SELECT 'family'			as '@name'			,	family		as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL(family, '')
			WHEN '' THEN NULL
			ELSE (SELECT 'familyId'			as '@name'			,	FamilyId	as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL(Genus, '')
			WHEN '' THEN NULL
			ELSE (SELECT 'genus'			as '@name'			,	genus		as 'text()' for xml path('field'), TYPE)
		END
	,   CASE ISNULL(Genus, '')
			WHEN '' THEN NULL
			ELSE (SELECT 'genusId'			as '@name'			,	GenusId		as 'text()' for xml path('field'), TYPE)
		END
	,   (SELECT 'taxonRank'		as '@name'			,	TaxonRank		as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'taxonRankSort' as '@name'			,	TaxonRankSort	as 'text()' for xml path('field'), TYPE)
	,  (SELECT CASE ISNULL(Parent, '')			WHEN '' THEN NULL ELSE 'parent'		END	as 'field/@name',	Parent			as 'field/text()' for xml path(''), TYPE) 	
	,  (SELECT CASE ISNULL(Parent, '')			WHEN '' THEN NULL ELSE 'parentId'	END	as 'field/@name',	LOWER(ParentFK)	as 'field/text()' for xml path(''), TYPE) 	
	,  (SELECT CASE ISNULL(CurrentName, '')		WHEN '' THEN NULL ELSE 'current'	END	as 'field/@name',	CurrentName		as 'field/text()' for xml path(''), TYPE) 	
	,  (SELECT CASE ISNULL(CurrentName, '')		WHEN '' THEN NULL ELSE 'currentId'	END	as 'field/@name',	LOWER(CurrentFK) as 'field/text()' for xml path(''), TYPE) 	
	
	, (SELECT VernacularSOLRXML.query('(//field)') for xml path(''), TYPE)
	, (SELECT BiostatusSOLRXML.query('(//field)') for xml path(''), TYPE)
	, (SELECT NotesSOLRXML.query('(//field)') for xml path(''), TYPE)
	, (SELECT ImageSOLRXML.query('(//field)') for xml path(''), TYPE)
	, (SELECT ExternalLinkSOLRXML.query('(//field)') for xml path(''), TYPE)
	, (SELECT ExternalLinkSOLRXML.query('(//field)') for xml path(''), TYPE)
	, (SELECT DeprecatedIdSOLR.query('(//field)') for xml path(''), TYPE)
	, (SELECT HybridSOLRXML.query('(//field)') for xml path(''), TYPE)
	, (SELECT HyperLinkSOLRXML.query('(//field)') for xml path(''), TYPE)

FROM #Name
FOR XML PATH('doc'), ROOT('update')
GO

--SELECT * FROM #Name

INSERT INTO #Reference(ReferenceId, ParentReferenceId, ParentReference, Title, TitleUnformatted, Source, Added, Updated, ReferenceType)
SELECT R.ReferenceID
	, R.ReferenceParentID
	, CASE ISNULL(ParentRef.referenceGenCitation, '')
		WHEN '' THEN ''
		ELSE REPLACE(REPLACE(ParentRef.ReferenceGenCitation, '<i>', ''), '</i>', '')
	  END  -- ParentReference
	, replace(R.ReferenceGenCitation, '&', '&amp;') -- Title
	, REPLACE(REPLACE(R.ReferenceGenCitation, '<i>', ''), '</i>', '') -- TitleUnformatted
	, db_name()	
	, R.ReferenceAddedDate
	, R.ReferenceUpdatedDate
	, RT.ReferenceTypeText
FROM tblReference R
	inner JOIN tblReferenceType RT ON R.ReferenceTypeID = rT.ReferenceTypeID
		LEFT JOIN tblReference ParentRef ON R.ReferenceParentID = ParentRef.ReferenceID
			AND ISNULL(Parentref.ReferenceIsDeleted, 0) = 0
			AND ISNULL(ParentRef.ReferenceSuppress, 0) = 0
WHERE R.ReferenceID IN (SELECT Id FROM #TestList)

UPDATE #Reference SET ParentReferenceId  = NULL where ParentReferenceId = '00000000-0000-0000-0000-000000000000'
UPDATE #Reference SET ParentReferenceId  = NULL where ParentReference = ''
UPDATE #Reference SET ReferenceType = 'Book'		WHERE ReferenceType = 'Book (in series)'
UPDATE #Reference SET ReferenceType = 'Article'		WHERE ReferenceType = 'Article in journal'
UPDATE #Reference SET ReferenceType = 'Unpublished' WHERE ReferenceType = 'Unpublished work (in series)'
UPDATE #Reference SET ReferenceType = 'Electronic'  WHERE ReferenceType = 'Electronic citation in electronic source'
UPDATE #Reference SET ReferenceType = 'Serial'		WHERE ReferenceType = 'Serial (book/monograph) in series'
UPDATE #Reference SET ReferenceType = 'Report'		WHERE ReferenceType = 'Report (in series)'


GO
-- which fields to include
-- which keywords
; WITH RefFields AS (
	SELECT RFT.ReferenceFieldTypeText as FieldType
		, RF.ReferenceID
		, RF.ReferenceFieldText
	FROM tblReferenceField RF
		INNER JOIN tblReferenceFieldType RFT ON RF.ReferenceFieldTypeID = RFT.ReferenceFieldTypeID
	WHERE RF.ReferenceFieldText NOT IN ('User def', 'Note', 'Reprint')
)
UPDATE R
	SEt FieldsXML = (SELECT FieldType '@type'
							, ReferenceFieldText as 'text()'
						FROM RefFields 
						WHERE ReferenceID = R.ReferenceId
						FOR XML PATH('Field'), ROOT('Fields'), TYPE)
		--, SOLR -- type, keywords?, parent
FROM #Reference R

GO
; WITH Concepts AS(
	SELECT B.BibliographyReferenceFk
		, B.BibliographyGuid
		, N.NameGuid
		, N.NameFull
	FROM tblBibliography B
		INNER JOIN tblName N ON B.BibliographyNameFk = N.NameGuid
	WHERE B.BibliographyReferenceFk IN (SELECT id FROM #TestList)
		AND B.BibliographyNameFk IN (SELECT Id from #TestList)
		AND ISNULL(B.BibliographyIsDeleted, 0) = 0
		
)
, ConceptRel AS (
	SELECT BRT.BibliographyRelationshipTypeText AS RelationshipType
		, BR.BibliographyRelationshipBibliographyFromFk AS BibId
		, LOWER(C.BibliographyGuid) AS RelatedConceptId
		, lower(C.NameGuid) AS RelatedNameId
		, C.NameFull as RelatedName
		, 'from' as direction
	FROM tblBibliographyRelationship BR
		INNER JOIN tblBibliographyRelationshipType BRT ON BR.BibliographyRelationshipTypeFk = BRT.BibliographyRelationshipTypePk
		INNER JOIN Concepts C ON BR.BibliographyRelationshipBibliographyToFk = C.BibliographyGuid		
	WHERE BR.BibliographyRelationshipBibliographyFromFk IN (SELECT BibliographyGuid FROM Concepts)

	UNION ALL

	SELECT BRT.InverseText AS RelationshipType
		, BR.BibliographyRelationshipBibliographyToFk AS BibId
		, LOWER(C.BibliographyGuid) AS RelatedConceptId
		, LOWER(C.NameGuid) AS RelatedNameId
		, C.NameFull as RelatedName
		, 'to' as direction
	FROM tblBibliographyRelationship BR
		INNER JOIN tblBibliographyRelationshipType BRT ON BR.BibliographyRelationshipTypeFk = BRT.BibliographyRelationshipTypePk
		INNER JOIN Concepts C ON BR.BibliographyRelationshipBibliographyFromFk = C.BibliographyGuid		
	WHERE BR.BibliographyRelationshipBibliographyToFk IN (SELECT BibliographyGuid FROM Concepts)
		AND BR.BibliographyRelationshipBibliographyFromFk <> br.BibliographyRelationshipBibliographyToFk
)
, DistinctTypes AS(
	SELECT DISTINCT RelationshipType, C.BibliographyReferenceFk as ReferenceId
	FROM ConceptRel CR
		INNER JOIN Concepts C ON CR.BibId = C.BibliographyGuid
)
--, DistinctNames AS(
--	SELECT DISTINCT BibliographyReferenceFk as ReferenceId, NameGuid, NameFull
--	FROM Concepts 
--)
UPDATE R
	SET ConceptsXML = (SELECT lower(BibliographyGuid) as '@conceptId'
							, LOWER(NameGuid) as '@nameId'
							, NameFull as '@nameFull'
							, (SELECT RelationshipType as '@type'
								, direction as '@direction'
								, RelatedConceptId as '@relatedConceptId'
								, RelatedNameId as '@relatedNameId'
								, RelatedName as '@relatedName'
								-- to do add formatted name?
							FROM ConceptRel
							WHERE BibId = C.BibliographyGuid
							FOR XML PATH('Association'), ROOT('Associations'), TYPE)
						FROM Concepts C
						WHERE BibliographyReferenceFk = R.ReferenceId
						FOR XML PATH('DefinedConcept') , ROOT('DefinedConcepts'), TYPE)
			, ConceptsSOLRXML = (SELECT
									(SELECT
										(SELECT 'associationType'	as '@name'	, RelationshipType	as 'text()' for xml path('field'), TYPE)
										FROM DistinctTypes DT
											WHERE ReferenceId = R.ReferenceId
										FOR XML PATH(''), TYPE)
									--, (SELECT 
									--		  (SELECT 'citedNameId'		as '@name'	, lower(NameGuid)	as 'text()' for xml path('field'), TYPE)
									--		, (SELECT 'citedName'		as '@name'	, NameFull			as 'text()' for xml path('field'), TYPE)
									--	FROM DistinctNames
									--	WHERE ReferenceId = R.ReferenceId
									--  FOR XML PATH(''), TYPE)
								FOR XML PATH(''), TYPE)
FROM #Reference R

--

; WITH CitedNames AS (
	SELECT DISTINCT N.Nameguid, N.NameFull, TLR.Id as ReferenceId
		FROM tblName N
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON N.NameTaxonomyReferenceFk = TLR.Id AND TLR.objectType = 'reference'
	UNION ALL

	SELECT DISTINCT N.Nameguid, N.NameFull, TLR.Id as ReferenceId
		FROM tblName N
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON N.NameParentReferenceFk = TLR.Id AND TLR.objectType = 'reference'

	UNION ALL

	SELECT DISTINCT N.Nameguid, N.NameFull, TLR.Id as ReferenceId
		FROM tblName N
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON N.NameReferenceFk = TLR.Id AND TLR.objectType = 'reference'

	UNION ALL

	SELECT DISTINCT N.Nameguid, N.NameFull, TLR.Id as ReferenceId
		FROM tblName N
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON N.NameAnamorphReferenceFk = TLR.Id AND TLR.objectType = 'reference'

	UNION ALL

	SELECT DISTINCT N.Nameguid, N.NameFull, TLR.Id as ReferenceId
		FROM tblName N
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON N.NameSanctioningReferenceFk = TLR.Id AND TLR.objectType = 'reference'

	UNION ALL

	SELECT DISTINCT N.Nameguid, N.NameFull, TLR.Id as ReferenceId
		FROM tblName N
			INNER JOIN tblNameNotes NN ON N.NameGuid = NN.NameNoteNameFk
				AND ISNULL(NN.NameNoteIsDeleted, 0) = 0
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON NN.NameNoteReferenceFk = TLR.Id AND TLR.objectType = 'reference'

	UNION ALL

	SELECT DISTINCT N.Nameguid, N.NameFull, TLR.Id as ReferenceId
		FROM tblName N
			INNER JOIN tblNomenclaturalStatus NN ON N.NameGuid = NN.NomenclaturalStatusNameFk
				AND ISNULL(NN.NomenclaturalStatusIsDeleted, 0) = 0
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON NN.NomenclaturalStatusReferenceFk = TLR.Id AND TLR.objectType = 'reference'
	-- biostatus

	UNION ALL

	SELECT DISTINCT B.NameBiostatusNameFk, N.NameFull, TLR.Id as ReferenceId
		FROM tblNameBiostatus B
			INNER JOIN tblName N ON B.NameBiostatusNameFk = N.NameGuid
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON B.NameBiostatusReferenceFk = TLR.Id AND TLR.objectType = 'reference'
		WHERE ISNULL(B.NameBiostatusIsDeleted, 0) = 0

	-- vernacular

	UNION ALL

	SELECT DISTINCT VU.VernacularUseNameFk, N.NameFull, TLR.Id as ReferenceId
		FROM tblVernacularUse VU
			INNER JOIN tblName N ON VU.VernacularUseNameFk = N.NameGuid
				AND ISNULL(VU.VernacularUseIsDeleted, 0) = 0
				AND ISNULL(VU.VernacularUseSuppress, 0) = 0
			INNER JOIN tblVernacularArticle VA ON VA.VernacularArticleVernacularUseFK = VU.VernacularUseCounterPk
				AND ISNULL(VA.VernacularArticleIsDeleted, 0) = 0
			INNER JOIN tblVernacular V ON VU.VernacularUseVernacularFk = V.VernacularGuid
				AND ISNULL(V.VernacularSuppress, 0) = 0
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON VA.VernacularArticleReferenceFk = TLR.Id AND TLR.objectType = 'reference'

	UNION ALL

	SELECT DISTINCT B.BibliographyNameFk, N.NameFull, TLR.Id as ReferenceId
		FROM tblBibliography B
			INNER JOIN tblName N ON B.BibliographyNameFk = N.NameGuid
			INNER JOIN #TestList TL ON N.NameGuid = TL.Id AND objectType = 'name'
			INNER JOIN #TestList TLR ON B.BibliographyReferenceFk = TLR.Id AND TLR.objectType = 'reference'
		WHERE ISNULL(B.BibliographyIsDeleted, 0) = 0
)
, DistinctList AS (SELECT DISTINCT NameGuid, NameFull, ReferenceId  FROM CitedNames)
UPDATE R
	SET CitationsXML = (SELECT 
							lower(NameGuid) as '@id'
							, NameFull as 'text()'
							-- to do add formatted name?
						FROM DistinctList CN
						WHERE CN.ReferenceId = R.ReferenceId
						FOR XML PATH('CitedTaxon'), ROOT('CitedTaxa'), TYPE)
		, CitationsSOLRXML = (SELECT
									 (SELECT 'citedNameId'		as '@name'	, lower(NameGuid)	as 'text()' for xml path('field'), TYPE)
									 , (SELECT 'citedName'		as '@name'	, NameFull	as 'text()' for xml path('field'), TYPE)
							  FROM DistinctList
							  WHERE ReferenceId = R.ReferenceId
							  FOR XML PATH(''), TYPE)

FROM #Reference R

--

UPDATE R
	SET KeysXML = (SELECT  DB_Name() + '-key-' + CAST(K.KeyPk as nvarchar(10)) as '@keyId' 
						,KeyTitle as '@title'
					 , KeyAddedDate as '@added'
					 , KeyUpdatedDate as '@updated'
					 , CAST(REPLACE(CAST(KeyAcknowledgement as nvarchar(max)), '&','&amp;') AS xml) as Acknowledgement
					 , KeyStartNotes as PrefaceNote
					 , KeyEndNote AS SuffixNote
					 , (SELECT KeyDataPk AS '@id' 
							, KD.KeyDataLinePrefix '@linePrefix'
							, CAST(kd.KeyDataText AS xml) AS Characteristic
							, LOWER(KD.KeyDataNameFk) as 'ResultText/@nameId'
							, KD.KeyDataCoupletFk AS 'ResultText/@lineId'
							, KD.KeyDataLinkKeyFk as 'ResultText/@otherKeyLineId'
							, CAST(REPLACE(kd.KeyDataResultText, '&', '&amp;')  as xml) AS ResultText
						FROM tblKeyData KD
						WHERE KD.KeyDataKeyFk = K.KeyPk
						ORDER BY KeyDataSequence
						FOR XML PATH('Line'), TYPE)
					FROM tblKey K
					WHERE K.KeyReferenceFk = R.ReferenceId
					FOR XML PATH('Key'), ROOT('IncludedKeys'))

FROM #Reference R
---

UPDATE #Reference SET ParentReference	= NULL WHERE ParentReference = ''
UPDATE #Reference SET Added				= NULL WHERE Added = ''
UPDATE #Reference SET Updated			= NULL WHERE Updated = ''

SELECT LOWER(ReferenceId) AS '@referenceId'
	, 'reference' as '@documentClass'
	, [Source] as '@source'
	, Added as '@added'
	, Updated as '@updated'
	--, LOWER(ParentReferenceId) as 'Reference/@parentId'
	, ReferenceType as 'Reference/@type'
	, CAST(Title as xml) as Title
	, TitleUnformatted
	, lower(ParentReferenceId) as 'ParentReference/@referenceId'
	, ParentReference as ParentReference
	, FieldsXML.query('(//Fields)[1]')
	, ConceptsXML.query('(//DefinedConcepts)[1]')
	, CitationsXML.query('(//CitedTaxa)[1]')
	, KeysXML.query('(//IncludedKeys)[1]')
	-- keys
FROM #Reference
FOR XML PATH('Document'), ROOT('Documents')


SELECT  
		(SELECT 'source'				as '@name'			,	DB_Name()			as 'text()' for xml path('field'), TYPE)
	,	(SELECT 'id'					as '@name'			,	lower(ReferenceId)	as 'text()' for xml path('field'), TYPE)
	,	(SELECT 'documentClass'			as '@name'			,	'reference'			as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'titleUnformatted'		as '@name'			,	TitleUnformatted	as 'text()' for xml path('field'), TYPE) 
	,   (SELECT 'title'					as '@name'			,	CAST(Title	as xml)			 for xml path('field'), TYPE) 
	,   (SELECT 'referenceType'			as '@name'			,	ReferenceType		as 'text()' for xml path('field'), TYPE)
	,   CASE ISNULL(Added, '') 
			WHEN '' THEN NULL
			ELSE (SELECT 'added'					as '@name'			,	Added				as 'text()' for xml path('field'), TYPE)
		END
	,  CASE ISNULL(Updated, '')
			WHEN '' THEN NULL
			ELSE (SELECT 'updated'				as '@name'			,	Updated				as 'text()' for xml path('field'), TYPE)
		END
	,  (SELECT CASE ISNULL(ParentReference, '')	WHEN '' THEN NULL ELSE 'parent'		END	as 'field/@name',	ParentReference 			as 'field/text()' for xml path(''), TYPE) 	
	,  (SELECT CASE ISNULL(ParentReference, '') WHEN '' THEN NULL ELSE 'parentId'	END	as 'field/@name',	LOWER(ParentReferenceId)	as 'field/text()' for xml path(''), TYPE) 	

	, (SELECT ConceptsSOLRXML.query('(//field)') for xml path(''), TYPE)
	, (SELECT CitationsSOLRXML.query('(//field)') for xml path(''), TYPE)
FROM #Reference
FOR XML PATH('doc'), ROOT('update')

--SELECT * FROM #Reference
GO

INSERT INTO #Vernacular(VernacularId, VernacularName, Added, Updated
			, LanguageFK, LanguageOfOrigin
			, GeoregionFK, RegionOfOrigin
			, Translation, Transliteration)
SELECT VernacularGuid, vernacularName
	, v.VernacularAddedDate, V.VernacularUpdatedDate
	, VernacularLanguageFk, L.LanguageEnglish
	, VernacularGeoRegionFk, G.GeoRegionName -- TO DO - add schema?
	, VernacularEnglishTranslation, VernacularEnglishTransliteration
FROM tblVernacular V
	INNER JOIN #TestList TL ON V.VernacularGuid = TL.Id
	LEFt JOIN tblLanguage L ON V.VernacularLanguageFk = L.LanguageCounterPK
	LEFT JOIN tblGeoRegion G ON V.VernacularGeoRegionFk = G.GeoRegionCounterPK


; WITH Uses AS (SELECT VU.VernacularUseCounterPk AS id
		--, VU.VernacularUseGeoRegionFk AS RegionId
		, G.GeoRegionName AS GeoregionOfUse
		, L.LanguageEnglish AS LanguageOfUse
		, L.LanguageISOCode AS languageOfUseIso
		--, VU.VernacularUseLanguageFk  as LanguageId
		, LOWER(VU.VernacularUseNameFk) as NameId
		, N.NameFull
		, N.NameFormatted
		, VU.VernacularUseAddedDate AS Added
		, vu.VernacularUseUpdatedDate AS Updated
		, VU.VernacularUseAppliesTo AppliesTo
		, VU.VernacularUseVernacularFk  AS VernacularId
FROM tblVernacularUse VU
	LEFT JOIN tblLanguage L ON VU.VernacularUseLanguageFk = L.LanguageCounterPK
	LEFT JOIN tblGeoRegion G ON VU.VernacularUseGeoRegionFk = G.GeoRegionCounterPK
	INNER JOIN #Name N ON VU.VernacularUseNameFk = N.NameGuid
WHERE ISNULL(VU.VernacularUseIsDeleted, 0) = 0
		AND ISNULL(VU.VernacularUseSuppress, 0) = 0
		AND VU.VernacularUseVernacularFk IN (SELECT id FROM #TestList WHERE objectType = 'vernacular')
)
, Articles AS (
	SELECT DISTINCT VA.VernacularArticleReferenceFk AS ReferenceId, VernacularArticleVernacularUseFK UseId, R.ReferenceGenCitation AS Reference
	FROM tblVernacularArticle VA
		INNER JOIN tblReference R ON VA.VernacularArticleReferenceFk = R.ReferenceID
	WHERE VA.VernacularArticleVernacularUseFK IN (SELECT Id FROM Uses)
		AND ISNULL(VA.VernacularArticleIsDeleted, 0) = 0
		AND VernacularArticleReferenceFk IS NOT NULL
)
, LanguagesOfUse AS (
	SELECT DISTINCT LanguageOfUse, VernacularId
	FROM Uses
	WHERE LanguageOfUse IS NOT NULL
)
, RegionsOfUse AS (
	SELECT DISTINCT GeoregionOfUse, VernacularId
	FROM Uses
	WHERE LanguageOfUse IS NOT NULL
)
UPDATE V
	SET UsesXML = (SELECT id	 AS '@id'
					, GeoregionOfUse AS '@georegionOfUse'
					, LanguageOfUse AS '@languageOfUse'
					, languageOfUseIso AS '@languageOfUseIso'
					, LOWER(NameId) as '@nameId'				
					, Added AS '@added'
					, Updated AS '@updated'
					, NameFull
					, CAST(REPLACE(NameFormatted, '&', '&amp;') as xml) AS NameFormatted
					, AppliesTo	
					, (SELECT ReferenceId as '@referenceId'
						, CAST(REPLACE(Reference, '&', '&amp;') as xml) 
						FROM Articles
						WHERE UseId = U.Id
						FOR XML PATH('Reference'), ROOT('References'), TYPE)
			FROM Uses U
			WHERE VernacularId = V.VernacularId
			FOR XML PATH('VernacularUse'), ROOT('VernacularUses'), TYPE)
		, UsesSOLRXML = (SELECT
							(SELECT
							   (SELECT 'appliedToNameId'		as '@name'			,	LOWER(NameId)				as 'text()' for xml path('field'), TYPE)
							 , (SELECT 'appliedToNameFull'		as '@name'			,	NameFull					as 'text()' for xml path('field'), TYPE)
							FROM Uses U
							WHERE VernacularId = V.VernacularId
							FOR XML PATH(''), TYPE)
						  , (SELECT
							    (SELECT 'vernacularLanguageOfUse'		as '@name'	,	LanguageOfUse	as 'text()' for xml path('field'), TYPE)
								FROM LanguagesOfUse 
								WHERE VernacularId = V.VernacularId
								FOR XML PATH(''), TYPE)
						, (SELECT
							    (SELECT 'vernacularRegionOfUse'			as '@name'	,	GeoregionOfUse	as 'text()' for xml path('field'), TYPE)
								FROM RegionsOfUse 
								WHERE VernacularId = V.VernacularId
								FOR XML PATH(''), TYPE)
						FOR XML PATH(''), TYPE)
FROM #Vernacular V


UPDATE #Vernacular SET Translation		= NULL WHERE Translation = ''
UPDATE #Vernacular SET Transliteration	= NULL WHERE Transliteration = ''
--SELECT * FROM #Vernacular

SELECT LOWER(VernacularId) AS '@vernacularId'
	, 'vernacular' as '@documentClass'
	, DB_Name() as '@source'
	
	, Added as '@added'
	, Updated as '@updated'
	, LanguageOfOrigin as 'VernacularName/@languageOfOrigin'
	, RegionOfOrigin as 'VernacularName/@regionOfOrigin'
	, VernacularName
	, Translation
	, Transliteration
	, UsesXML.query('(//VernacularUses)[1]')
FROM #Vernacular
FOR XML PATH('Document'), ROOT('Documents')


SELECT  
		(SELECT 'source'						as '@name'	,	DB_Name()			as 'text()' for xml path('field'), TYPE)
	,	(SELECT 'id'							as '@name'	,	lower(VernacularId)	as 'text()' for xml path('field'), TYPE)
	,	(SELECT 'documentClass'					as '@name'	,	'vernacular'		as 'text()' for xml path('field'), TYPE)
	,   (SELECT 'titleUnformatted'				as '@name'	,	vernacularName		as 'text()' for xml path('field'), TYPE) 
	,   (SELECT 'title'							as '@name'	,	vernacularName		as 'text()'	 for xml path('field'), TYPE)
	,   (SELECT 'vernacularName'				as '@name'	,	vernacularName		as 'text()'	 for xml path('field'), TYPE)
	,   (SELECT 'vernacularLanguageOfOrigin'	as '@name'	,	LanguageOfOrigin	as 'text()'	 for xml path('field'), TYPE)	
	,   CASE ISNULL(RegionOfOrigin, '') 
			WHEN '' THEN NULL
			ELSE (SELECT 'vernacularRegionOfOrigin'	as '@name',	RegionOfOrigin		as 'text()'	 for xml path('field'), TYPE)
		END
	,   CASE ISNULL(Added, '') 
			WHEN '' THEN NULL
			ELSE (SELECT 'added'				as '@name'	,	Added				as 'text()' for xml path('field'), TYPE)
		END
	,  CASE ISNULL(Updated, '')
			WHEN '' THEN NULL
			ELSE (SELECT 'updated'				as '@name'	,	Updated				as 'text()' for xml path('field'), TYPE)
		END
	, (SELECT UsesSOLRXML.query('(//field)') for xml path(''), TYPE)
FROM #Vernacular
FOR XML PATH('doc'), ROOT('update')
