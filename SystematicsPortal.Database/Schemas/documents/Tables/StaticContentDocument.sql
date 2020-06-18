CREATE TABLE [documents].[StaticContentDocument] (
    [StaticContentId]   	UNIQUEIDENTIFIER                            NOT NULL,
    [Version]				INT                                         NOT NULL,
    [SerializedDocument]	XML                                         NOT NULL,
    [ValidFrom]				DATETIME2 (2) GENERATED ALWAYS AS ROW START NOT NULL,
    [ValidTo]				DATETIME2 (2) GENERATED ALWAYS AS ROW END   NOT NULL,

    CONSTRAINT [prkStaticContentDocument] PRIMARY KEY CLUSTERED ([StaticContentId] ASC),
    PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=[documents].[StaticContentDocumentHistory], DATA_CONSISTENCY_CHECK=ON));
