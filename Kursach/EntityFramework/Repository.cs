using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kursach
{
    public class Repository<T> where T : class
    {
        public static ColiseumDbContext context;

        public DbSet<T> dbSet;

        public Repository(ColiseumDbContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }
        public void Create(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public List<T> Get(Func<T, bool> predicate)
        {
            List<T> entities = dbSet.Where(predicate).ToList();
            return entities;
        }

        public T GetById(int id)
        {
            T entity = dbSet.Find(id);
            return entity;
        }

        public List<T> GetAll()
        {
            List<T> entities = dbSet.ToList();
            return entities;
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void RemoveById(int id)
        {
            T entity = GetById(id);
            dbSet.Remove(entity);

            context.SaveChanges();
        }

        public List<Team> GetAllTeamsWithOrganizations()
        {
            return context.Set<Team>().Include(t => t.Organization).ToList();
        }

        public List<Event> GetEventsWithGames(Func<Event, bool> predicate)
        {
            return context.Set<Event>().Include(e => e.EventGame).Where(predicate).ToList();
        }

        public List<Game> GetGamesWithImages(Func<Game, bool> predicate)
        {
            return context.Set<Game>().Include(g => g.GameImage).Where(predicate).ToList();
        }

        public int CreateWithId(User entity)
        {
            context.Set<User>().Add(entity);
            context.SaveChanges();

            return entity.Id;
        }
    }
}
