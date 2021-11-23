// See https://aka.ms/new-console-template for more information


using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>();
dbContextOptions.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SqlUnionIssue;Trusted_Connection=True;MultipleActiveResultSets=true");

var dbContext = new ApplicationDbContext(dbContextOptions.Options);
dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();

var licenseQuery = (from l in dbContext.Licenses
                    select l);

// This works without performing a union:
var licenses = licenseQuery.Include(x => x.Registrations).ToList();

licenseQuery = licenseQuery.Union(from l in dbContext.Licenses
                                  join fl in dbContext.FreeLicenses on l.Id equals fl.Id
                                  select l);

licenseQuery = licenseQuery.Union(from l in dbContext.Licenses
                                  join fl in dbContext.PurchasedLicenses on l.Id equals fl.Id
                                  select l);

licenseQuery = licenseQuery.Union(from l in dbContext.Licenses
                                  join fl in dbContext.TrialLicenses on l.Id equals fl.Id
                                  select l);

// Here we get an error because of the Unions I'm assuming
licenses = licenseQuery.Include(x => x.Registrations).ToList();