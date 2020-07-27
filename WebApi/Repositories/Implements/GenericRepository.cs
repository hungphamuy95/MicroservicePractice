using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Repositories.Interfaces;
using MongoDatabaseSettings = WebApi.Models.MongoDatabaseSettings;

namespace WebApi.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T:BaseEntity
    {
        private readonly IMongoCollection<T> _collection;
        public GenericRepository(IOptions<MongoDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionsString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<T>((typeof(T).Name));
        }

        public async Task<IEnumerable<T>> GetAll() => await _collection.Find(x => true).ToListAsync();


        public async Task<T> GetById(string id) => await _collection.Find<T>(x => x.Id == id).FirstOrDefaultAsync();

        public virtual async Task<T> Insert(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreatedBy = "admin";
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public virtual async Task Update(string id, T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = "admin";
            await _collection.ReplaceOneAsync(x => x.Id == id, entity);
        }

        public async Task Delete(T entity) => await _collection.DeleteOneAsync(x => x.Id == entity.Id);
        public IQueryable<T> Get() =>_collection.AsQueryable();
        
    }
}
