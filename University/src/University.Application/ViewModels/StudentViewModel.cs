using System;
using System.ComponentModel.DataAnnotations;

namespace University.Application.ViewModels {
  public class StudentViewModel {
    public Guid Id {
      get;
      set;
    }

    [Required(ErrorMessage = "Nome é obrigatório")][StringLength(100, ErrorMessage = "Nome pode ter até 100 caracteres")]
    public string FullName {
      get;
      set;
    }

    [Required(ErrorMessage = "Email é obrigatório")][EmailAddress(ErrorMessage = "Email inválido")]
    public string Email {
      get;
      set;
    }

    [Range(16, 120, ErrorMessage = "Idade deve ser entre 16 e 120")]
    public int Age {
      get;
      set;
    }
  }
}