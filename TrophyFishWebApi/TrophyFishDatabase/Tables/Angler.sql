CREATE TABLE [dbo].[Angler] (
    [ID]       INT            NOT NULL,
    [UserID]   NVARCHAR (128) NOT NULL,
    [UserName] NVARCHAR (50)  NOT NULL,
    [Avatar]   VARCHAR (50)   NULL,
    [Points]   SMALLINT       NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

