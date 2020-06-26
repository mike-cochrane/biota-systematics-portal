CREATE TABLE [documents].[DocumentHistory] (
    [DocumentId]			UNIQUEIDENTIFIER	NOT NULL,
    [Version]				INT					NOT NULL,
	[SerializedDocument]	XML					NOT NULL,
    [ValidFrom]				DATETIME2 (2)		NOT NULL,
    [ValidTo]				DATETIME2 (2)		NOT NULL
);

GO
CREATE CLUSTERED INDEX [idxDocumentHistory]
    ON [documents].[DocumentHistory]([ValidTo] ASC, [ValidFrom] ASC);
