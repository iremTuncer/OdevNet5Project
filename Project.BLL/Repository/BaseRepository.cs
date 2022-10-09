using Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using Project.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project.BLL.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ProjectContext _context;
        private DbSet<T> _entities;
        public BaseRepository(ProjectContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }


        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity != null)
            {
                _entities.Add(entity);
                SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            if (entity != null)
            {
                _entities.Remove(entity);
                SaveChanges();
            }
            //todo: silme tarihi
        }

        public string SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return "veri kaydedildi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                SaveChanges();
                //todo: veri güncelleme işleminde de savechanges() bize "veri kaydedildi" değerini döndürecek. isterseniz bu metodu değiştirebilirsiniz.
                //todo: güncelleme tarihi
            }
        }
    }
}
