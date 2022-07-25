using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

//See https://aka.ms/new-console-template for more information

//SamuraiContext _context = new SamuraiContext();
//_context.Database.EnsureCreated();
//GetSamurais("Sebelum ditambahkan:");
//AddSamurai("Tanjiro", "Rengoku", "Zenitsu", "Muzan", "Inosuke");
//GetSamurais("Setelah ditambahkan:");
//AddSamurai("Samurai 1", "Samurai 2", "Sanemi", "Giyu Tomioka", "Obanai", "Mitsuri", "Samurai 3", "Samurai 4", "Samurai 5", "Samurai 6", "Kensin", "Shisio", "Shinobu", "Muichiro");
//AddVariousTypes();
//QueryFilter();
//QueryAggregates();
//RetrieveAndUpdateSamurai();
//RetrieveAndUpdateMultipleSamurais();
//MultipleDatabaseOperations();
//RetrieveAndDeleteSamurai();
//QueryAndUpdateBattle_Disconnect();
//InsertNewSamuraiWithQuote();
//AddQouteToExistingSamurai();
//AddQuoteToExistingSamuraiNoTracking(3);
//GetSamurais();
//SimpleAddQuoteToExistingSamuraiNoTracking(4);
//EagerLoadSamuraiWithQuote();
//ProjectingSample();
//ExplicitLoadQuotes();
//FilteringWithRelatedData();
//ModifyRelatedData();
//ModifyRelatedDataNoTracking();
//AddNewSamuraiToBattle();
//BattleWithSamurai();
//AddAllSamuraiBattle();
//RemoveSamuraiFromBattle();
//RemoveSamuraiFromBattleExplicit();

//AddNewSamuraiWithHorse();
//AddNewHorseToSamurai();
//AddNewHorseToSamuraiNoTracking();
//GetSamuraiWithHorse();
//QueryViewBattleStat();
//QueryUsingRawSql();
//QueryUsingSPRaw();

//AddSamuraiByName("Musashi", "Nobunaga", "Iyeasu");

Console.WriteLine("Press any key");
Console.ReadLine();

//void AddSamurai(params String[] names)
//{
//foreach (string name in names)
//{
//_context.Samurais.Add(new Samurai { Name = name });
//}
//_context.SaveChanges();
//}
//void AddVariousTypes()
//{
///*_context.Samurais.AddRange(
//    new Samurai { Name="Kensin"},
//    new Samurai { Name="Shisio"}
//    );
//_context.Battles.AddRange(
//    new Battle { Name="Battle Of Anegawa"},
//    new Battle { Name="Battle Of Nagashino"}
//    );*/
//_context.AddRange(new Samurai { Name = "Shinobu" }, new Samurai { Name = "Muichiro" },
//    new Battle { Name = "Battle Of District Arc" }, new Battle { Name = "Battle Of Kyoto" });
//_context.SaveChanges();
//}
//void GetSamurais()
//{
//var samurais = _context.Samurais
//    .TagWith("Get Samurai Method")
//    .ToList();
//Console.WriteLine($"Jumlah samurai adalah {samurais.Count}");
//foreach (var samurai in samurais)
//{
//Console.WriteLine(samurai.Name);
//}
//}
//void GetBattles()
//{
//var battles = _context.Battles.ToList();
//foreach (var battle in battles)
//{
//Console.WriteLine(battle);
//}
//}
//void QueryFilter()
//{
////var samurais = _context.Samurais.Where(s => s.Name == "Rengoku").ToList();
////var samurais = _context.Samurais.Where(s => s.Name.Contains("Tan")).ToList();
//var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "Re%")).ToList();
//foreach (var samurai in samurais)
//{
//Console.WriteLine(samurai.Name);
//}
//}
//void QueryAggregates()
//{
//var name = "Rengoku";
////var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name); //=> LINQ Method
///*var samurai = (from s in _context.Samurais where s.Name == name select s).FirstOrDefault();*/ //=> LINQ Query
//var samurai = _context.Samurais.Find(2);
//Console.WriteLine($"Id {samurai.Id} - Nama {samurai.Name}");

//}
//void RetrieveAndUpdateSamurai()
//{
//var samurai = _context.Samurais.SingleOrDefault(s => s.Id == 2);
//samurai.Name = "Kyojiro Rengoku";
//_context.SaveChanges();
//}
//void RetrieveAndUpdateMultipleSamurais()
//{
//var samurais = _context.Samurais.Skip(0).Take(5).ToList();
//samurais.ForEach(s => s.Name += " San");
//_context.SaveChanges();
//}
//void MultipleDatabaseOperations()
//{
//var samurai = _context.Samurais.OrderBy(s => s.Id).LastOrDefault();
//samurai.Name += " San";
//_context.Samurais.Add(new Samurai { Name = "Gyomei Himejima" });
//_context.SaveChanges();
//}
//void RetrieveAndDeleteSamurai()
//{
//var samurai = _context.Samurais.Find(6);
//_context.Samurais.Remove(samurai);
//var samurais = _context.Samurais
//    .Where(s => s.Name.StartsWith("Samurai")).ToList(); // Memanggil data dari tabel Samurais yang memiliki nama depan samurai kedalam  variabel samurais
//_context.Samurais.RemoveRange(samurais); //Menghapus data yang di simpan di dalam variabel samurais
//_context.SaveChanges();
//}
//void QueryAndUpdateBattle_Disconnect()
//{
///*List<Battle> disconnectedBattles;
//using (var context1 = new SamuraiContext())
//{
//    disconnectedBattles = context1.Battles.ToList();
//}//context1 sudah di dispose
//disconnectedBattles.ForEach(b =>
//{
//    b.StartDate = new DateTime(1570, 01, 01);
//    b.EndDate = new DateTime(1575, 01, 01);
//});

//using (var context2 = new SamuraiContext())
//{
//    context2.UpdateRange(disconnectedBattles);
//    context2.SaveChanges();
//}*/
//}
//void InsertNewSamuraiWithQuote()
//{
//var samurai = new Samurai
//{
//Name = "Miyamoto Mushasi",
//Quotes = new List<Quote>
//        {
//            new Quote {Text = "Think lightly of yourself and deeply world"},
//            new Quote {Text = " Do nothing that is of no use"}
//        }
//};
//_context.Samurais.Add(samurai);
//_context.SaveChanges();
//}
//void AddQouteToExistingSamurai()
//{
//var samurai = _context.Samurais.Where(s => s.Id == 1).FirstOrDefault();
//samurai.Quotes.Add(new Quote
//{
//Text = "Do not fear death"
//});
//_context.SaveChanges();
//}
//void AddQuoteToExistingSamuraiNoTracking(int samuraiID)
//{
//var samurai = _context.Samurais.Find(samuraiID);
//samurai.Quotes.Add(new Quote
//{
//Text = "Do Not Fear Death"
//});

//using (var context1 = new SamuraiContext())
//{
//context1.Samurais.Update(samurai);
//context1.SaveChanges();
//}
//}
//void SimpleAddQuoteToExistingSamuraiNoTracking(int samuraiID)
//{
//var quote = new Quote { Text = "Never stray from the way", SamuraiId = samuraiID };
//using (var context1 = new SamuraiContext())
//{
//context1.Quotes.Add(quote);
//context1.SaveChanges();
//}
//}
//void EagerLoadSamuraiWithQuote()
//{
//var samuraiWithQuotes = _context.Samurais.Include(s => s.Quotes).ToList();
//var splitquery = _context.Samurais.AsSplitQuery().Include(s => s.Quotes).ToList();
//var filteredEntity = _context.Samurais.Include(s => s.Quotes.Where(q => q.Text.Contains("fear"))).ToList();
//var filteredEntityInclude = _context.Samurais.Where(s => s.Name.Contains("San")).Include(s => s.Quotes).ToList();
//var filtersingle = _context.Samurais.Where(s => s.Id == 1).Include(s => s.Quotes).FirstOrDefault();
//}
//void ProjectingSample()
//{
//var results = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList();
//var idandnameresult = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();
//var resultsWithCount = _context.Samurais.Select(s => new { s.Id, s.Name, NumOfQuote = s.Quotes }).ToList();
//var samuraiAndQoutes = _context.Samurais.Select(s => new { Samurai = s, BestQuote = s.Quotes.Where(q => q.Text.Contains("fear")) }).ToList();
//}
//void ExplicitLoadQuotes()
//{
//_context.Set<Horse>().Add(new Horse { SamuraiId = 1, Name = "Yamatomaru" });
//_context.SaveChanges();

//var samurai = _context.Samurais.Find(1);
//_context.Entry(samurai).Collection(s => s.Quotes).Load();
//}
//void FilteringWithRelatedData()
//{
//var samurais = _context.Samurais.Where(s => s.Quotes.Any(q => q.Text.Contains("fear"))).ToList();
//}
//void ModifyRelatedData()
//{
//var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 21);
//samurai.Quotes[0].Text = "You  Only Life Once";
//_context.Quotes.Remove(samurai.Quotes[1]);
//_context.SaveChanges();
//}
//void ModifyRelatedDataNoTracking()
//{
//var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 21);
//var quote = samurai.Quotes[0];
//quote.Text = "You Only Life Once";

//using (var context1 = new SamuraiContext())
//{
//context1.Quotes.Update(quote);
//context1.Entry(quote).State = EntityState.Modified;
//context1.SaveChanges();
//}
//}

////relasi tabel many to many
//void AddNewSamuraiToBattle()
//{
//    var battle = _context.Battles.FirstOrDefault();
//    battle.Samurais.Add(new Samurai { Name = "Nobunaga Oda" });
//    _context.SaveChanges();
//    //}
//    void BattleWithSamurai()
//{
//    var battle = _context.Battles.Include(b => b.Samurais).FirstOrDefault(b => b.BattleId == 1);
//    var battles = _context.Battles.Include(b => b.Samurais).ToList();
//    //}
//    void AddAllSamuraiBattle()
//    {
//        var allbatles = _context.Battles.ToList();
//        var allsamurais = _context.Samurais.ToList();
//        foreach (var battle in allbatles)
//        {
//            battle.Samurais.AddRange(allsamurais);
//        }
//        _context.SaveChanges();
//    }
//    void RemoveSamuraiFromBattle()
//    {
//        var battleWithSamurai = _context.Battles.Include(b => b.Samurais.Where(s => s.Id == 23))
//            .SingleOrDefault(b => b.BattleId == 1);
//        var Samurai = battleWithSamurai.Samurais[0];
//battleWithSamurai.Samurais.Remove(Samurai);
//_context.SaveChanges();
//}
//void RemoveSamuraiFromBattleExplicit()
//{
//var battlesamurai = _context.Set<BattleSamurai>()
//    .SingleOrDefault(bs => bs.BattleId == 1 && bs.SamuraiId == 22);
//if (battlesamurai != null)
//{
//_context.Remove(battlesamurai);
//_context.SaveChanges();
//}
//}
//void AddNewSamuraiWithHorse()
//{
//var samurai = new Samurai { Name = "Kensin Himura" };
//samurai.Horse = new Horse { Name = "Nekochan" };
//_context.Samurais.Add(samurai);
//_context.SaveChanges();
//}
//void AddNewHorseToSamurai()
//{
//var horse = new Horse { Name = "Red Hare", SamuraiId = 2 };
//_context.Add(horse);
//_context.SaveChanges();
//}//Belum Di ekseskusi
//void AddNewHorseToSamuraiNoTracking()
//{
//var samurai = _context.Samurais.AsNoTracking().FirstOrDefault(s => s.Id == 3);
//samurai.Horse = new Horse { Name = "Silver Thunder" };

//using (var context1 = new SamuraiContext())
//{
//context1.Samurais.Attach(samurai);
//context1.SaveChanges();
//}
//}//Belum di eksekusi
//void GetSamuraiWithHorse()
//{
//var samurais = _context.Samurais.Include(s => s.Horse).ToList();
//var horseaja = _context.Set<Horse>().Find(1);
//}

//void QueryViewBattleStat()
//{
///*var results = _context.SamuraiBattleStats.ToList();
//foreach(var stat in results)
//{
//    Console.WriteLine($"{stat.Name} - {stat.NumberOfBattles} - {stat.EarliestBattle}");
//}*/

//var firststat = _context.SamuraiBattleStats.FirstOrDefault(s => s.Name == "Nobunaga Oda");
//Console.WriteLine($"{firststat.Name}-{firststat.NumberOfBattles}-{firststat.EarliestBattle}");
//}
//void QueryUsingRawSql()
//{
////var samurais = _context.Samurais.FromSqlRaw("select * from Samurais").ToList();
//var name = "Kensin";
//var samurais = _context.Samurais
//    .FromSqlInterpolated($"select * from samurais where Name={name}").ToList();
//}
//void QueryUsingSPRaw()
//{
//var text = "fear";
////var samurais = _context.Samurais.FromSqlRaw("exec dbo.SamuraisWhoSaidAWord {0}", text).ToList();
//var samurais = _context.Samurais.FromSqlInterpolated($"exec dbo.SamuraisWhoSaidAWord {text}").ToList();
//var samuraiId = 16;
//_context.Database.ExecuteSqlRaw("exec dbo.DeleteQuotesForSamurai {0}", samuraiId);
//Console.WriteLine($"Quotes dari Samurai dengan Id {samuraiId} berhasil didelete");
//}

////void AddSamuraiByName(params string[] names)
////{
////var bs = new BusinessDataLogic();
////var newSamuraiCreateCount = bs.AddSamuraiByName(names);
////}
//struct IdAndName
//{
//    public IdAndName(int id, string name)
//    {
//        Id = id;
//        Name = name;
//    }
//    public int Id;
//    public string Name;
//}