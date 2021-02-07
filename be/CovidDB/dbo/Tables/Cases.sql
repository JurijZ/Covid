CREATE TABLE [dbo].[Cases] (
    [X]                 DECIMAL (17, 14) NULL,
    [Y]                 DECIMAL (17, 14) NULL,
    [case_code]         VARCHAR (100)    NULL,
    [confirmation_date] DATETIME         NULL,
    [municipality_code] VARCHAR (50)     NULL,
    [municipality_name] VARCHAR (50)     NULL,
    [age_bracket]       VARCHAR (20)     NULL,
    [gender]            VARCHAR (20)     NULL,
    [object_id]         INT              IDENTITY (1, 1) NOT NULL
);





