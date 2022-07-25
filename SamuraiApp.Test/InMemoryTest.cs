using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Test
{
    [TestClass]
    public class InMemoryTest
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDatabaseInMemory()
        {
            var builder = new DbContextOptionsBuilder<SamuraiContext>();
            builder.UseInMemoryDatabase("CanInsertSamurai");
            using (var context = new SamuraiContext(builder.Options))
            {
                var samurai = new Samurai() {  Name="Musahsi"};
                context.Samurais.Add(samurai);
                Debug.WriteLine($"Sebelum save: {samurai.Id}");
                context.SaveChanges();
                Debug.WriteLine($"Setelah save: {samurai.Id}");
                Assert.AreNotEqual(0, samurai.Id);
                //Assert.AreEqual(EntityState.Added,context.Entry(samurai).State);
            }
        }
    }
}
