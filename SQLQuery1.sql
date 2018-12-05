CREATE TABLE [dbo].[Addresses] (
    [AddressId]     NVARCHAR (128) NOT NULL,
    [UserId]		NVARCHAR (128) NOT NULL,
    [StreetAddress] NVARCHAR (MAX) NOT NULL,
    [Type]          NVARCHAR (64)  NULL,
    [Number]        NVARCHAR (64)  NULL,
    [City]          NVARCHAR (MAX) NULL,
    [PostalCode]    NVARCHAR (MAX) NOT NULL,
    [Region]        NVARCHAR (MAX) NOT NULL,
    [Country]       NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([AddressId] ASC),
    CONSTRAINT [AK_Addresses_Column] UNIQUE NONCLUSTERED ([AddressId] ASC),
    CONSTRAINT [FK_Addresses_ToTable] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

CREATE TABLE [dbo].[PhoneNumbers] (
    [PhoneNumberId] NVARCHAR (128) NOT NULL,
    [UserId]		NVARCHAR (128) NOT NULL,
    [Type]          NVARCHAR (18)     NOT NULL,
    [Number]        NVARCHAR (10)     NOT NULL,
    [Extension]     NVARCHAR (64)     NULL,
    PRIMARY KEY CLUSTERED ([PhoneNumberId] ASC),
    CONSTRAINT [AK_PhoneNumbers_Column] UNIQUE NONCLUSTERED ([PhoneNumberId] ASC),
    CONSTRAINT [FK_PhoneNumbers_ToTable] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

CREATE TABLE [dbo].[FundingSources] (
    [FundingSourceId]	NVARCHAR (128) NOT NULL,
    [UserId]			NVARCHAR (128) NOT NULL,
    [AccountNumber]		NVARCHAR (MAX) NOT NULL,
    [Nickname]          NVARCHAR (MAX) NOT NULL,
    [Type]              NVARCHAR (64)     NULL,
    PRIMARY KEY CLUSTERED ([FundingSourceId] ASC),
    CONSTRAINT [AK_FundingSources_Column] UNIQUE NONCLUSTERED ([FundingSourceId] ASC),
    CONSTRAINT [FK_FundingSources_ToTable] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

CREATE TABLE [dbo].[Payees] (
    [PayeeId]					NVARCHAR (128) NOT NULL,
    [DefaultName]               NVARCHAR (MAX) NOT NULL,
    [DefaultStreetAddress]      NVARCHAR (MAX) NOT NULL,
    [DefaultStreetAddressTwo]	NVARCHAR (MAX) NULL,
    [DefaultCity]               NVARCHAR (MAX) NOT NULL,
    [DefaultRegion]             NVARCHAR (MAX) NOT NULL,
    [DefaultCountry]            NVARCHAR (MAX) NOT NULL,
    [DefaultPostalCode]         NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([PayeeId] ASC),
    CONSTRAINT [AK_Payees_Column] UNIQUE NONCLUSTERED ([PayeeId] ASC)
);

CREATE TABLE [dbo].[UserPayees] (
    [UserPayeeId]			NVARCHAR (128) NOT NULL,
    [UserId]				NVARCHAR (128) NOT NULL,
    [Payeeid]				NVARCHAR (128) NOT NULL,
    [Nickname]				NVARCHAR (MAX) NOT NULL,
    [PayeeAccountNumber]	NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserPayeeId] ASC),
    CONSTRAINT [AK_UserPayees_Column] UNIQUE NONCLUSTERED ([UserPayeeId] ASC),
    CONSTRAINT [FK_UserPayees_ToTable] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_UserPayees_ToTable_1] FOREIGN KEY ([PayeeId]) REFERENCES [dbo].[Payees] ([PayeeId])
);

CREATE TABLE [dbo].[Payments] (
    [PaymentId]			NVARCHAR (128) NOT NULL,
    [UserPayeeId]		NVARCHAR (128) NOT NULL,
    [FundingSourceId]	NVARCHAR (128) NOT NULL,
    [Amount]			FLOAT (53) NOT NULL,
    [DateCreated]		DATETIME NOT NULL,
    [Currency]			NVARCHAR (8) NOT NULL,
    PRIMARY KEY CLUSTERED ([PaymentId] ASC),
    CONSTRAINT [AK_Payments_Column] UNIQUE NONCLUSTERED ([PaymentId] ASC),
    CONSTRAINT [FK_Payments_ToTable] FOREIGN KEY ([UserPayeeId]) REFERENCES [dbo].[UserPayees] ([UserPayeeId]),
    CONSTRAINT [FK_Payments_ToTable_1] FOREIGN KEY ([FundingSourceId]) REFERENCES [dbo].[FundingSources] ([FundingSourceId])
);
