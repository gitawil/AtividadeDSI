using System;
using System.ComponentModel.DataAnnotations;

namespace University.Domain.Entities
{
    public class Matricula
    {
        public Guid Id { get; private set; }

        [Required]
        public DateTime Data { get; private set; }

        public Guid StudentId { get; private set; }

        public Student Student { get; private set; }

        protected Matricula() {}

        public Matricula(Guid studentId)
        {
            Id = Guid.NewGuid();
            StudentId = studentId;
            Data = DateTime.UtcNow;
        }

        public void DefinirData(DateTime data)
        {
            if (data > DateTime.UtcNow)
                throw new ArgumentException("A data da matrícula não pode estar no futuro.");

            Data = data;
        }
    }
}
