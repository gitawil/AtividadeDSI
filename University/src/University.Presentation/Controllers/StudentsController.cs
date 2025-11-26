using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using University.Application.Interfaces;
using University.Application.ViewModels;

namespace University.Presentation.Controllers {
  public class StudentsController: Controller {
    private readonly IStudentService _service;

    public StudentsController(IStudentService service) {
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Search(string term)
    {
        var students = await _studentService.SearchAsync(term);
        return PartialView("_StudentsTable", students); 
    }

    // GET: /Students
    public async Task < IActionResult > Index() {
      var list = await _service.GetAllAsync();
      return View(list);
    }

    // GET: /Students/Create
    public IActionResult Create() {
      return View(new StudentViewModel());
    }

    // POST: /Students/Create
    [HttpPost][ValidateAntiForgeryToken]
    public async Task < IActionResult > Create(StudentViewModel vm) {
      if (!ModelState.IsValid) return View(vm);

      await _service.CreateAsync(vm);
      TempData["SuccessMessage"] = "Aluno cadastrado com sucesso!";
      return RedirectToAction(nameof(Index));
    }

    // GET: /Students/Edit/{id}
    public async Task < IActionResult > Edit(Guid id) {
      var vm = await _service.GetByIdAsync(id);
      if (vm == null) return NotFound();

      return View(vm);
    }

    // POST: /Students/Edit/{id}
    [HttpPost][ValidateAntiForgeryToken]
    public async Task < IActionResult > Edit(Guid id, StudentViewModel vm) {
      if (!ModelState.IsValid) return View(vm);

      var updated = await _service.UpdateAsync(id, vm);
      if (updated == null) return NotFound();

      TempData["SuccessMessage"] = "Aluno atualizado com sucesso!";
      return RedirectToAction(nameof(Index));
    }

    // GET: /Students/Delete/{id}
    public async Task < IActionResult > Delete(Guid id) {
      var vm = await _service.GetByIdAsync(id);
      if (vm == null) return NotFound();

      return View(vm);
    }

    // POST: /Students/Delete/{id}
    [HttpPost, ActionName("Delete")][ValidateAntiForgeryToken]
    public async Task < IActionResult > DeleteConfirmed(Guid id) {
      var result = await _service.DeleteAsync(id);
      if (!result) return NotFound();

      TempData["SuccessMessage"] = "Aluno excluído com sucesso!";
      return RedirectToAction(nameof(Index));
    }

    // GET: /Students/Details/{id}
    public async Task < IActionResult > Details(Guid id) {
      var vm = await _service.GetByIdAsync(id);
      if (vm == null) return NotFound();

      return View(vm);
    }
  }
}
