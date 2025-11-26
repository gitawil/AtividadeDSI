using System;

namespace University.Application.ViewModels {
  public class MatriculaViewModel {
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public string CourseName { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}
