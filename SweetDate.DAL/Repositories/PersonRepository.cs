using Microsoft.EntityFrameworkCore;
using SweetDate.DAL.Interfaces;
using SweetDate.Domain.Entity;

namespace SweetDate.DAL.Repositories;

public class PersonRepository : IBaseRepository<Person>
{
    private readonly ApplicationDbContext _db;

    public PersonRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task Create(Person entity)
    {
        await _db.Person.AddAsync(entity);
        await _db.SaveChangesAsync();
        
    }

    public async Task Delete(Person entity)
    {
        _db.Person.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<Person> Update(Person entity)
    {
        _db.Person.Update(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public IQueryable<Person> GetAll()
    {
        return _db.Person;
    }

}