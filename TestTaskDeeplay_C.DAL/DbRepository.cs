using Microsoft.EntityFrameworkCore;
using TestTaskDeeplay_C.DAL.Context;
using TestTaskDeeplay_C.DAL.Entityes.Base;
using TestTaskDeeplay_C.Interfaces;


namespace TestTaskDeeplay_C.DAL
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {

        private readonly TestTaskDB _db;
        private readonly DbSet<T> _Set;

        public bool AutoSave { get; set; } = true;
        public DbRepository(TestTaskDB db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _Set;

        #region Получение
        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken cancel = default) =>
            await Items.SingleOrDefaultAsync(item => item.Id == id, cancel).ConfigureAwait(false);
        #endregion

        #region Добавление
        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSave) _db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSave) await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }
        #endregion

        #region Удаление
        public void Remove(int id)
        {
            var item = _Set.Local.FirstOrDefault(n => n.Id == id) ?? new T { Id = id };
            _db.Remove(item);
            if (AutoSave) _db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken cancel = default)
        {
            var item = _Set.Local.FirstOrDefault(n => n.Id == id) ?? new T { Id = id };
            _db.Remove(item);
            if (AutoSave) await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
        #endregion

        #region Обновление
        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSave) _db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSave) await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
        #endregion
    }
}
