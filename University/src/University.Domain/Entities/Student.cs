using System;
using System.ComponentModel.DataAnnotations;

namespace University.Domain.Entities {
  public class Student {
    public Guid Id {
      get;
      private set;
    }

    [Required][StringLength(100)]
    public string FullName {
      get;
      private set;
    }

    [Required][EmailAddress]
    public string Email {
      get;
      private set;
    }

    [Range(16, 120)]
    public int Age {
      get;
      private set;
    }

    public DateTime CreatedAt {
      get;
      private set;
    }

    // Construtor para EF
    protected Student() {}

    public Student(string fullName, string email, int age) {
      Id = Guid.NewGuid();
      SetFullName(fullName);
      SetEmail(email);
      SetAge(age);
      CreatedAt = DateTime.UtcNow;
    }

    // Exemplo de encapsulamento de regras de dominio
    public void SetFullName(string fullName) {
      if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Nome é obrigatório.");
      FullName = fullName.Trim();
    }

    public void SetEmail(string email) {
      if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email é obrigatório.");
      Email = email.Trim().ToLowerInvariant();
    }

    public void SetAge(int age) {
      if (age < 16 || age > 120) throw new ArgumentException("Idade inválida.");
      Age = age;
    }
  }
}