CREATE TABLE [documents].[Document] (
    [DocumentId]    		UNIQUEIDENTIFIER                            NOT NULL,
    [Version]				INT                                         NOT NULL,
    [SerializedDocument]	XML                                         NOT NULL,
    [ValidFrom]				DATETIME2 (2) GENERATED ALWAYS AS ROW START NOT NULL,
    [ValidTo]				DATETIME2 (2) GENERATED ALWAYS AS ROW END   NOT NULL,

    CONSTRAINT [prkDocument] PRIMARY KEY CLUSTERED ([DocumentId] ASC),
    PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[documents].[DocumentHistory], DATA_CONSISTENCY_CHECK=ON));
