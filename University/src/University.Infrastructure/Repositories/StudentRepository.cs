using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;
using University.Infrastructure.Persistence;

namespace University.Infrastructure.Repositories {
  public class StudentRepository: IStudentRepository {
    private readonly AppDbContext _db;

    public StudentRepository(AppDbContext db) {
      _db = db;
    }

    public async Task AddAsync(Student s) {
      await _db.Students.AddAsync(s);
      await _db.SaveChangesAsync();
    }

    public async Task < IEnumerable < Student >> GetAllAsync() {
      return await _db.Students.ToListAsync();
    }

    public async Task < Student ? >GetByIdAsync(Guid id) {
      return await _db.Students.FindAsync(id);
    }

    public async Task RemoveAsync(Student s) {
      _db.Students.Remove(s);
      await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student s) {
      _db.Students.Update(s);
      await _db.SaveChangesAsync();
    }
  }
}