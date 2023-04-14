<h1>Library Program</h1>

<p>This is a library program that allows employees to browse and add items to the database, also to create accounts, and add authors and publishers to the correct form of media. The program is built using C# and .NET Framework and uses a SQL Server database to store information about books, authors, and users of the program.</p>

<h2>Getting Started</h2>

<p>To use the library program, you will need to have something like for example Visual Studio and SQL Server installed on your computer. If the correct type of software is installed follow the following steps:</p>

<ol>
  <li>Clone this repository to your local machine.</li>
  <li>Open the Library.sln solution file in Visual Studio.</li>
  <li>Build the solution by clicking Build > Build Solution.</li>
</ol>

<h2>Features</h2>

<p>The library program includes the following features:</p>

<ul>
  <li>Browse books by title, author, or category</li>
  <li>Browse authors by books</li>
  <li>Browse publishers by other types of items</li>
  <li>Add new books, other items, authors, and categories to the library</li>
</ul>


///// Important /////
<p> Incase the User Migration is not doing as it should (it tripped the last day)
Is here a SQL-Script for the User table</p>

CREATE TABLE [dbo].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Middlename]  NVARCHAR (MAX) NULL,
    [Lastname]    NVARCHAR (MAX) NULL,
    [Adress]      NVARCHAR (MAX) NULL,
    [City]        NVARCHAR (MAX) NULL,
    [Housenumber] INT            NULL,
    [Postalcode]  NVARCHAR (MAX) NULL,
    [Email]       NVARCHAR (100) NOT NULL,
    [Phonenumber] NVARCHAR (MAX) NULL,
    [Password]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

