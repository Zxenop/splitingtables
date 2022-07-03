// See https://aka.ms/new-console-template for more information
using TestMultiEEntity;
using TestMultiEEntity.Models;



//La table derrière c'est 
/*
CREATE TABLE[dbo].[TestMultiEntity]
(

   [Id] INT NOT NULL PRIMARY KEY IDENTITY,
   [Forme] INT NOT NULL,
   [Type] INT NOT NULL,
   [Label] VARCHAR(5000) NULL
)
*/


var db = new TestDbContext();

//Two Entities, One Table
db.TestFormes.Add(new TestForme
{
    Forme = 1,
    Label = "Test Add",
    Type = new TestType
    {
        Type = 1,
    }
});

await db.SaveChangesAsync();

