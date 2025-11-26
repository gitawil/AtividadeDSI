using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Application.Interfaces;
using University.Application.ViewModels;
using University.Domain.Entities;
using University.Infrastructure.Repositories;

namespace University.Application.Services {
  public class StudentService: IStudentService {
    private readonly IStudentRepository _repo;

    public StudentService(IStudentRepository repo) {
      _repo = repo;
    }

    public async Task < StudentViewModel > CreateAsync(StudentViewModel vm) {
      var student = new Student(vm.FullName, vm.Email, vm.Age);
      await _repo.AddAsync(student);
      return MapToVm(student);
    }

    public async Task < bool > DeleteAsync(Guid id) {
      var existing = await _repo.GetByIdAsync(id);
      if (existing == null) return false;
      await _repo.RemoveAsync(existing);
      return true;
    }

    public async Task < IEnumerable < StudentViewModel >> GetAllAsync() {
      var list = await _repo.GetAllAsync();
      return list.Select(MapToVm);
    }

    public async Task<IEnumerable<StudentViewModel>> SearchAsync(string term)
{
    var result = await _repo.SearchAsync(term);
    return _mapper.Map<IEnumerable<StudentViewModel>>(result);
}


    public async Task < StudentViewModel ? >GetByIdAsync(Guid id) {
      var s = await _repo.GetByIdAsync(id);
      return s == null ? null: MapToVm(s);
    }

    public async Task < StudentViewModel ? >UpdateAsync(Guid id, StudentViewModel vm) {
      var existing = await _repo.GetByIdAsync(id);
      if (existing == null) return null;
      existing.SetFullName(vm.FullName);
      existing.SetEmail(vm.Email);
      existing.SetAge(vm.Age);
      await _repo.UpdateAsync(existing);
      return MapToVm(existing);
    }

    private StudentViewModel MapToVm(Student s) =>new StudentViewModel {
      Id = s.Id,
      FullName = s.FullName,
      Email = s.Email,
      Age = s.Age
    };
  }
}
