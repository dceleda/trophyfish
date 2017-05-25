CREATE TABLE [dbo].[Fish] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [AirTemp]          SMALLINT       NULL,
    [CatchDate]        DATETIME2 (7)  NOT NULL,
    [CloudID]          TINYINT        NULL,
    [CountryID]        TINYINT        NOT NULL,
    [FisheryTypeID]    TINYINT        NOT NULL,
    [Length]           SMALLINT       NULL,
    [LureBaitDesc]     NVARCHAR (50)  NULL,
    [LureBaitID]       TINYINT        NULL,
    [MethodID]         TINYINT        NULL,
    [MoonPhase]        TINYINT        NULL,
    [PrecipitationID]  TINYINT        NULL,
    [Pressure]         SMALLINT       NULL,
    [PressureChangeID] TINYINT        NULL,
    [SpecieID]         TINYINT        NOT NULL,
    [StatusID]         TINYINT        NOT NULL,
    [UserID]           NVARCHAR (450) NOT NULL,
    [WaterLevelID]     TINYINT        NULL,
    [WaterTemp]        SMALLINT       NULL,
    [Weight]           SMALLINT       NULL,
    [WindDirID]        TINYINT        NULL,
    [WindSpeed]        TINYINT        NULL,
    CONSTRAINT [PK_Fish] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Fish_CloudDict_CloudID] FOREIGN KEY ([CloudID]) REFERENCES [dbo].[CloudDict] ([ID]),
    CONSTRAINT [FK_Fish_CountryDict_CountryID] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[CountryDict] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Fish_FisheryTypeDict_FisheryTypeID] FOREIGN KEY ([FisheryTypeID]) REFERENCES [dbo].[FisheryTypeDict] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Fish_FishStatusDict_StatusID] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[FishStatusDict] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Fish_LureBaitDict_LureBaitID] FOREIGN KEY ([LureBaitID]) REFERENCES [dbo].[LureBaitDict] ([ID]),
    CONSTRAINT [FK_Fish_MethodDict_MethodID] FOREIGN KEY ([MethodID]) REFERENCES [dbo].[MethodDict] ([ID]),
    CONSTRAINT [FK_Fish_PrecipitationDict_PrecipitationID] FOREIGN KEY ([PrecipitationID]) REFERENCES [dbo].[PrecipitationDict] ([ID]),
    CONSTRAINT [FK_Fish_PressureChangeDict_PressureChangeID] FOREIGN KEY ([PressureChangeID]) REFERENCES [dbo].[PressureChangeDict] ([ID]),
    CONSTRAINT [FK_Fish_SpecieDict_SpecieID] FOREIGN KEY ([SpecieID]) REFERENCES [dbo].[SpecieDict] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Fish_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Fish_WaterLevelDict_WaterLevelID] FOREIGN KEY ([WaterLevelID]) REFERENCES [dbo].[WaterLevelDict] ([ID]),
    CONSTRAINT [FK_Fish_WindDirectionDict_WindDirID] FOREIGN KEY ([WindDirID]) REFERENCES [dbo].[WindDirectionDict] ([ID])
);




GO
CREATE NONCLUSTERED INDEX [IX_Fish_WindDirID]
    ON [dbo].[Fish]([WindDirID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_WaterLevelID]
    ON [dbo].[Fish]([WaterLevelID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_UserID]
    ON [dbo].[Fish]([UserID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_StatusID]
    ON [dbo].[Fish]([StatusID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_SpecieID]
    ON [dbo].[Fish]([SpecieID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_PressureChangeID]
    ON [dbo].[Fish]([PressureChangeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_PrecipitationID]
    ON [dbo].[Fish]([PrecipitationID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_MethodID]
    ON [dbo].[Fish]([MethodID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_LureBaitID]
    ON [dbo].[Fish]([LureBaitID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_FisheryTypeID]
    ON [dbo].[Fish]([FisheryTypeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_CountryID]
    ON [dbo].[Fish]([CountryID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Fish_CloudID]
    ON [dbo].[Fish]([CloudID] ASC);

