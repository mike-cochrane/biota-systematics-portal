CREATE TABLE [documents].[ReferenceDocumentHistory] (
    [ReferenceId]   		UNIQUEIDENTIFIER	NOT NULL,
    [Version]				INT					NOT NULL,
	[SerializedDocument]	XML					NOT NULL,
    [ValidFrom]				DATETIME2 (2)		NOT NULL,
    [ValidTo]				DATETIME2 (2)		NOT NULL
);

GO
CREATE CLUSTERED INDEX [idxReferenceDocumentHistory]
    ON [documents].[ReferenceDocumentHistory]([ValidTo] ASC, [ValidFrom] ASC);
