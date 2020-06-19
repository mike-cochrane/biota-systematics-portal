CREATE TABLE [documents].[ReferenceDocument] (
    [ReferenceId]				UNIQUEIDENTIFIER                            NOT NULL,
    [Version]				INT                                         NOT NULL,
    [SerializedDocument]	XML                                         NOT NULL,
    [ValidFrom]				DATETIME2 (2) GENERATED ALWAYS AS ROW START NOT NULL,
    [ValidTo]				DATETIME2 (2) GENERATED ALWAYS AS ROW END   NOT NULL,

    CONSTRAINT [prkReferenceDocument] PRIMARY KEY CLUSTERED ([ReferenceId] ASC),
    PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[documents].[ReferenceDocumentHistory], DATA_CONSISTENCY_CHECK=ON));
