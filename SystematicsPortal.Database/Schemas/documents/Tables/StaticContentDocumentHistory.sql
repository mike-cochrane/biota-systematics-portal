CREATE TABLE [documents].[StaticContentDocumentHistory] (
    [StaticContentId]	    UNIQUEIDENTIFIER	NOT NULL,
    [Version]				INT					NOT NULL,
	[SerializedDocument]	XML					NOT NULL,
    [ValidFrom]				DATETIME2 (2)		NOT NULL,
    [ValidTo]				DATETIME2 (2)		NOT NULL
);

GO
CREATE CLUSTERED INDEX [idxStaticContentDocumentHistory]
    ON [documents].[StaticContentDocumentHistory]([ValidTo] ASC, [ValidFrom] ASC);
