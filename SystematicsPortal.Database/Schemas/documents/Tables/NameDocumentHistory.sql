CREATE TABLE [documents].[NameDocumentHistory] (
    [NameId]				UNIQUEIDENTIFIER	NOT NULL,
    [Version]				INT					NOT NULL,
	[SerializedDocument]	XML					NOT NULL,
    [ValidFrom]				DATETIME2 (2)		NOT NULL,
    [ValidTo]				DATETIME2 (2)		NOT NULL
);

GO
CREATE CLUSTERED INDEX [idxNameDocumentHistory]
    ON [documents].[NameDocumentHistory]([ValidTo] ASC, [ValidFrom] ASC);
