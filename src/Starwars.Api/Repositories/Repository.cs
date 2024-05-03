using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;

public class Repository<T> : IRepository<T> where T : class
{
    private SqliteConnection _connection;
    public Repository()
    {
        _connection = new SqliteConnection("Data Source=./app.db");
    }
    public async Task Add(T entity)
    {
        await _connection.InsertAsync(entity);
    }
    public async Task Delete(T entity)
    {
        await _connection.DeleteAsync(entity);
    }
    public async Task<IEnumerable<T>> GetAll()
    {
        return await _connection.GetAllAsync<T>();
    }
    public async Task<T> GetById(int id){
        return await _connection.GetAsync<T>(id);
    }
}
public interface IRepository<T> where T : class
{
    Task Add(T entity);
    Task Delete(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
}