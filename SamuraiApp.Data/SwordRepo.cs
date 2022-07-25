using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.DTO;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SwordRepo : ISword
    {
        private readonly SamuraiContext _context;

        public SwordRepo(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteSword = await GetById(id);
                _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException DbEx)
            {

                throw new Exception(DbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var results = await _context.Swords.OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Sword> GetById(int id)
        {
            var results = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
            if (results == null) throw new Exception($"Data Sword id : {id} tidak ditemukan");
            return results;
        }

        public async Task<Sword> Insert(Sword obj)
        {
            try
            {
                _context.Swords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateConcurrencyException DbEx)
            {

                throw new Exception(DbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Element> InsertElement(Element element)
        {
            try
            {
                _context.Elements.Add(element);
                await _context.SaveChangesAsync();
                return element;
            }
            catch (DbUpdateConcurrencyException DbEx)
            {

                throw new Exception(DbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SwordElement> InsertSwordElement(SwordElement swordelement)
        {
            try
            {
                _context.SwordElements.Add(swordelement);
                await _context.SaveChangesAsync();
                return swordelement;
            }
            catch (DbUpdateConcurrencyException DbEx)
            {

                throw new Exception(DbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Sword> InsertSwordElementDetail(Sword sword, List<Element> elementList)
        {
            try
            {
                _context.Swords.Add(sword);
                _context.Elements.AddRangeAsync(elementList);
                await _context.SaveChangesAsync();

                return sword;
            }
            catch (DbUpdateConcurrencyException DbEx)
            {

                throw new Exception(DbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Sword> Update(int id, Sword obj)
        {
            try
            {
                var updateSword = await GetById(id);

                updateSword.Name = obj.Name;
                await _context.SaveChangesAsync();
                return updateSword;
            }
            catch (DbUpdateConcurrencyException DbEx)
            {

                throw new Exception(DbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
