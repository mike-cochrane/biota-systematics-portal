CREATE TABLE [documents].[VernacularNameDocumentHistory] (
    [VernacularNameId]				UNIQUEIDENTIFIER	NOT NULL,
    [Version]				INT					NOT NULL,
	[SerializedDocument]	XML					NOT NULL,
    [ValidFrom]				DATETIME2 (2)		NOT NULL,
    [ValidTo]				DATETIME2 (2)		NOT NULL
);

GO
CREATE CLUSTERED INDEX [idxVernacularNameDocumentHistory]
    ON [documents].[VernacularNameDocumentHistory]([ValidTo] ASC, [ValidFrom] ASC);
