CREATE TABLE [dbo].[employees] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [ad_sid]           VARCHAR (46)   DEFAULT ('') NOT NULL,
    [id_manager]       INT            NOT NULL,
    [surname]          NVARCHAR (50)  NOT NULL,
    [name]             NVARCHAR (50)  NOT NULL,
    [patronymic]       NVARCHAR (50)  NULL,
    [full_name]        NVARCHAR (150) NOT NULL,
    [display_name]     NVARCHAR (100) NOT NULL,
    [id_position]      INT            NOT NULL,
    [id_organization]  INT            NOT NULL,
    [email]            NVARCHAR (150) NULL,
    [work_num]         NVARCHAR (50)  NULL,
    [mobil_num]        NVARCHAR (50)  NULL,
    [id_emp_state]     SMALLINT       NOT NULL,
    [id_department]    INT            NOT NULL,
    [id_city]          INT            NOT NULL,
    [enabled]          BIT            DEFAULT ((1)) NOT NULL,
    [dattim1]          DATETIME       DEFAULT (getdate()) NOT NULL,
    [dattim2]          DATETIME       DEFAULT ('3.3.3333') NOT NULL,
    [date_came]        DATE           NULL,
    [birth_date]       DATE           NULL,
    [male]             BIT            DEFAULT ((1)) NOT NULL,
    [id_position_org]  INT            NOT NULL,
    [has_ad_account]   BIT            DEFAULT ((0)) NOT NULL,
    [creator_sid]      VARCHAR (46)   NULL,
    [ad_login]         NVARCHAR (50)  NULL,
    [date_fired]       DATE           NULL,
    [full_name_dat]    NVARCHAR (150) NULL,
    [full_name_rod]    NVARCHAR (150) NULL,
    [newvbie_delivery] BIT            DEFAULT ((0)) NOT NULL,
    [id_budget]        INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_employee_id_department]
    ON [dbo].[employees]([id_department] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_employee_id_manager]
    ON [dbo].[employees]([id_manager] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_employee_ad_sid]
    ON [dbo].[employees]([ad_sid] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_employee_id_emp_state]
    ON [dbo].[employees]([id_emp_state] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_employee_enabled]
    ON [dbo].[employees]([enabled] DESC);

