CREATE TABLE [Pupils] (
    [Id] INT NOT NULL IDENTITY(1,1),
    [FirstName] NVARCHAR(25) NOT NULL,
    [LastName] NVARCHAR(25) NOT NULL,
    [Gender] NVARCHAR(10) NOT NULL,
    [Grade] NVARCHAR(5) NOT NULL,
    CONSTRAINT [PK_Pupils] PRIMARY KEY ([Id])
);

CREATE TABLE [Teachers] (
    [Id] INT NOT NULL IDENTITY(1,1),
    [FirstName] NVARCHAR(25) NOT NULL,
    [LastName] NVARCHAR(25) NOT NULL,
    [Gender] NVARCHAR(10) NOT NULL,
    [Subject] NVARCHAR(45) NOT NULL,
    CONSTRAINT [PK_Teachers] PRIMARY KEY ([Id])
);

CREATE TABLE [PupilTeacher] (
    [PupilsId] INT NOT NULL,
    [TeachersId] INT NOT NULL,
    CONSTRAINT [PK_PupilTeacher] PRIMARY KEY ([PupilsId], [TeachersId]),
    CONSTRAINT [FK_PupilTeacher_Pupils_PupilsId] FOREIGN KEY ([PupilsId]) REFERENCES [Pupils] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PupilTeacher_Teachers_TeachersId] FOREIGN KEY ([TeachersId]) REFERENCES [Teachers] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_PupilTeacher_TeachersId] ON [PupilTeacher] ([TeachersId]);
