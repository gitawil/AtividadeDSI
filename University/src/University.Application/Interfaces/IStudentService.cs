using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using University.Application.ViewModels;

namespace University.Application.Interfaces {
  public interface IStudentService {
    Task < IEnumerable < StudentViewModel >> GetAllAsync();
    Task < StudentViewModel ? >GetByIdAsync(Guid id);
    Task < StudentViewModel > CreateAsync(StudentViewModel vm);
    Task < StudentViewModel ? >UpdateAsync(Guid id, StudentViewModel vm);
    Task < bool > DeleteAsync(Guid id);
  }
}