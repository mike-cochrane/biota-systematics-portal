--USE Names_Fungi
USE Names_Plants
--USE Names_NZAC
GO

/*
Query to be run on an instance of the names_* database to find records with high density of information.

a couple of scores calculated
* overall score
* nomenclatural score.

Update the order fields at the end of the query to sort differently

Can limit to the set of exemplar data by retaining the join to #Testlist in the query

*/

-- this gets the same list of records as the exemplar data
IF EXISTS(SELECT * FROM tempdb.dbo.sysobjects WHERE ID = OBJECT_ID(N'tempdb..#TestList'))
	DROP TABLE #TestList
GO

CREATE TABLE #TestList (Id uniqueidentifier, objectType nvarchar(50), step nvarchar(250), NameCurrentId uniqueidentifier)
GO

INSERT INTO #testlist(id, objecttype)
VALUES ('b1f2ef2e-4de4-428d-a10f-0018878be220',  'name')  --names_plants
	, ('a3715e1f-3335-479c-9fe1-0041a8c6e8fb',  'name')    --names_plants
	, ('A34DD714-9494-47D9-AFB1-154EA0F1950D',  'name')   --names_plants
	, ('C3D7BD00-0C35-4340-97A2-694A98457222',  'name')   --names_plants
	, ('5FB0A025-DD7A-44E8-9B9F-CEA1CA3E9C76',  'name')   --names_plants
	, ('9B7F9946-33E1-4D4C-8FE1-E75B6BE1F75E', 'name')   --names_plants
	--, ('56A97ACD-D624-43AC-A7FB-06C72B67818C', 'name')    --names_plants
	--, ('81680BF6-8AAC-4706-9875-33F62A78BA86', 'name') -- names_plants:  ×Agropogon P.Fourn.	
	, ('49B6400E-6FBF-478A-80E6-361C15E65D44', 'name')  --	names_plants	Cordyline ×matthewsii Carse
	, ('5CBC34B3-5987-45C5-A97E-943CD96E9A5A', 'name')  --	Brassica rapa
	, ('09144A76-B218-4796-8EE1-67648B67F989', 'name') --	Hymenophyllum nephrophyllum Ebihara & K.Iwats.
	, ('C75BBC20-45FA-4A4E-B497-80D9BE2194BB', 'name') --	Trichomanes L.
	, ('710A7214-41D3-4BAF-9105-C5349A68FB2C', 'name') --	Gleichenia Sm.
	, ('79D423E4-8ADC-4863-A82C-CCCC71AF6A53', 'name') --	Sematophyllum uncinatum I.G.Stone & G.A.M.Scott
	, ('BF25F266-C640-4DB7-A857-3CC33DFB75D6', 'name') --	Nothofagus Blume

	, ('1CB18142-36B9-11D5-9548-00D0592D548C', 'name') -- names_fungi -- Clavaria acuta Sowerby
	, ('F18A0F26-4E13-444A-BDA2-A8FE52ADB18B', 'name') -- names_fungi -- Pseudomonas syringae pv. actinidiae Takikawa et al. 1989
	, ('1CB182DC-36B9-11D5-9548-00D0592D548C', 'name') -- names_fungi -- Clavaria pallidoechinulata R.H. Petersen
	, ('1CB18152-36B9-11D5-9548-00D0592D548C', 'name') -- names_fungi -- Clavaria flavopurpurea R.H. Petersen
	, ('1CB1A13F-36B9-11D5-9548-00D0592D548C', 'name') -- names_fungi -- Ramariopsis alutacea R.H. Petersen
	, ('19F8436D-5EA1-4DE9-9415-B83EA6BEE477', 'name') -- names_fungi -- Auricularia cornea
	, ('1CB1985D-36B9-11D5-9548-00D0592D548C', 'name') --	Peziza ammophila Durieu & Lév.
	, ('1CB17EBE-36B9-11D5-9548-00D0592D548C', 'name') --	Asterophora lycoperdoides (Bull.) Ditmar
	, ('1CB1945B-36B9-11D5-9548-00D0592D548C', 'name') --	Mycena ura Segedin
	, ('1CB1929F-36B9-11D5-9548-00D0592D548C', 'name') --	Melanoleuca Pat. 1897
	, ('1CB18FA9-36B9-11D5-9548-00D0592D548C', 'name') --	Laccaria amethystina Cooke
	, ('1CB19CDB-36B9-11D5-9548-00D0592D548C', 'name') --	Potebniamyces Smerlis
	, ('57414FE6-AA74-4541-83C5-EAD8F53CA607', 'name') --	Pluteus pauperculus E. Horak

	, ('B90EED88-CBFF-4AAA-8ED1-005A04A2C5B8', 'name') -- names_nzac -- Euplectopsis crassipes (Broun)
	, ('0C631AA2-70F7-4466-B5F4-0DC0C2D289EC', 'name') -- names_nzac -- Ichneutica brunneosa (Fox)
	, ('8E344273-3658-4908-AB28-F2DE676DCBCB', 'name') -- names_nzac -- Saphydrus suffusus Sharp
	, ('DCBA5EDB-EFFD-4F08-B4A1-19B42207ABAD', 'name') -- names_nzac -- 
	, ('098EE6E6-2ABB-4F5D-87F3-62092577483C', 'name') -- names_nzac -- Paropsis charybdis Stal
	, ('6822108A-7CA4-44BF-9B7B-4B0E0F6776C9', 'name') -- names_nzac --	Bombus terrestris
	, ('76EC3E3F-BF93-4D73-AD62-D8C71513D213', 'name')  --	Eupines (Byraxis) crassicornides Newton

GO

; WITH Parents AS (
	SELECT DISTINCT NameParentFk 
			FROM tblName NP 
			 INNER JOIN #TestList T ON NP.NameGuid = T.Id
		WHERE ISNULL(NP.NameSuppress, 0) = 0
			
)
INSERT INTO #TestList(id, objectType, step)
SELECT N.NameGuid, 'name', 'siblings'
FROM tblName N
	INNER JOIN Parents P ON N.NameParentFk = P.NameParentFk
WHERE ISNULL(N.NameSuppress, 0) = 0
	AND N.NameGUID NOT IN (SELECT id FROM #TestList)
	AND N.NameCurrentFk = N.NameGuid

-- descendants, only current names

INSERT INTO #TestList(id, objectType, step)
SELECT N.NameGuid, 'name', 'descendants'
FROM tblName N
		INNER JOIN tblFlatName FN ON N.NameGuid = FN.FlatNameSeedName
			INNER JOIN #TestList TL ON FN.FlatNameNameUFk = TL.Id
WHERE N.NameCurrentFk = N.NameGuid
	AND ISNULL(N.NameSuppress, 0) = 0
	AND N.NameGuid NOT IN (SELECT id FROM #TestList)
	

	-- ancestors
INSERT INTO #TestList(id, objectType, step)
SELECT DISTINCT FN.FlatNameNameUFk, 'name', 'ancestors'
FROM tblFlatName FN
	INNER JOIN #TestList TL ON FN.FlatNameSeedName = TL.Id
	INNER JOIN tblName N ON FN.FlatNameNameUFk = N.Nameguid
		AND ISNULL(N.NameSuppress, 0) = 0
WHERE FN.FlatNameNameUFk NOT IN (SELECT id FROM #TestList)

INSERT INTO #TestList(Id, objectType, step)
SELECT DISTINCT NameGuid, 'name', 'synonyms'
FROM tblName
WHERE NameCurrentFk IN (SELECT id from #TestList)
		AND NameGuid NOT IN (SELECT id from #TestList)

GO


-- this calculates the score
; WITH Names AS (SELECT NameGuid, NameFull
	, (SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END FROM tblNameNotes				WHERE NameNoteNameFk = N.NameGuid				AND ISNULL(NameNoteIsDeleted, 0) = 0)				HasNameNotes
	, (SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END FROM tblNomenclaturalStatus	WHERE NomenclaturalStatusNameFk = N.NameGuid	AND ISNULL(NomenclaturalStatusIsDeleted, 0) = 0)	HasNomenNotes
	, (SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END FROM tblImageLink	IL			WHERE IL.RecordID = N.NameGuid)																		HasImages
	, (SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END FROM tblVernacularUse VU		WHERE VU.VernacularUseNameFk = N.NameGuid		AND ISNULL(VU.VernacularUseIsDeleted, 0) = 0)		HasVernacular
	, (SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END FROM tblBibliography B			WHERE B.BibliographyNameFk = N.NameGuid			AND ISNULL(B.BibliographyIsDeleted, 0) = 0)			HasConcepts
	, (SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END FROM tblNameBiostatus  NB		WHERE NB.NameBiostatusNameFk = N.NameGuid		AND ISNULL(NB.NameBiostatusIsDeleted, 0) = 0	AND NB.NameBiostatusIsActive = 1)	HasBiostatusActive
	, (SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END FROM tblNameBiostatus  NB		WHERE NB.NameBiostatusNameFk = N.NameGuid		AND ISNULL(NB.NameBiostatusIsDeleted, 0) = 0	AND NB.NameBiostatusIsActive = 0)	HasBiostatusInActive
	, (SELECT CASE COUNT(*) WHEN 0 THEN 0 ELSE 1 END FROM tblName  SYN				WHERE SYN.NameCurrentFk = N.NameGuid			AND SYN.NameCurrentFk <> SYN.NameGuid			AND ISNULL(SYN.NameSuppress, 0) = 0) HasSynonyms
	, CASE ISNULL(CAST(NameReferenceFK AS nvarchar(50)), '')			WHEN '' THEN 0 ELSE 1 END HasProtologue
	, CASE ISNULL(CAST(NameBasedonFk AS nvarchar(50)), '')				WHEN '' THEN 0 ELSE 1 END HasBasedOn
	, CASE ISNULL(CAST(NameBlockingFk AS nvarchar(50)), '')				WHEN '' THEN 0 ELSE 1 END HasBlocking
	, CASE ISNULL(CAST(NameTaxonomyReferenceFk AS nvarchar(50)), '')	WHEN '' THEN 0 ELSE 1 END HasTaxonomyReference
	, CASE ISNULL(CAST(NameParentReferenceFk AS nvarchar(50)), '')		WHEN '' THEN 0 ELSE 1 END HasParentReference
	, CASE ISNULL(NameOrthographyVariant, '')							WHEN '' THEN 0 ELSE 1 END HasOrthography
	, CASE ISNULL(NameYearOfPublication, '')							WHEN '' THEN 0 ELSE 1 END HasYear
	, CASE ISNULL(NamePage, '')											WHEN '' THEN 0 ELSE 1 END HasPage
FROM tblName N
WHERE ISNULL(N.NameSuppress, 0) = 0)
, NamesScored AS (SELECT (HasNameNotes + HasNomenNotes + HasImages + HasVernacular + HasConcepts + HasBiostatusActive + HasBiostatusInActive
			+ HasProtologue + HasBasedOn + HasBlocking + HasTaxonomyReference + HasParentReference + HasSynonyms + HasOrthography + HasYear + HasPage)  AS Score
		
		, (HasProtologue + HasBasedOn + HasBlocking + HasOrthography + HasYear + HasPage) AS NomenclatureScore
		
		, N.NameGuid, NameFull
			, HasNameNotes , HasNomenNotes , HasImages , HasVernacular , HasConcepts , HasBiostatusActive , HasBiostatusInActive
			, HasProtologue , HasBasedOn , HasBlocking , HasTaxonomyReference , HasParentReference , HasSynonyms , HasOrthography , HasYear , HasPage
FROM Names N
	INNER JOIN #TestList TL ON N.NameGuid = TL.Id) -- comment out to look at all names in database
SELECT * FROM NamesScored
ORDER BY Score DESC
 --ORDER BY  NomenclatureScore DESC



	
