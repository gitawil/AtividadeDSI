using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Domain.Entities;

namespace University.Infrastructure.Repositories {
  public interface IStudentRepository {
    Task < IEnumerable < Student >> GetAllAsync();
    Task < Student ? >GetByIdAsync(Guid id);
    Task AddAsync(Student s);
    Task UpdateAsync(Student s);
    Task RemoveAsync(Student s);
    Task<IEnumerable<Student>> SearchAsync(string term);
  }
}
