// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
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
db.TestFormes.Add(new Marche("Test Marche", new TestType { Type = 1 }));
db.TestFormes.Add(new AccordCadre("Test AccordCadre", new TestType { Type = 1 }));

await db.SaveChangesAsync();

var res = await db.TestFormes.ToListAsync();

Console.WriteLine("Yo");

