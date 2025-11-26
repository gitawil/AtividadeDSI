using University.Domain.Entities;

namespace University.Domain.Repositories {
    public interface IMatriculaRepository {
        Task<Matricula> GetByIdAsync(Guid id);
        Task<IEnumerable<Matricula>> GetByStudentIdAsync(Guid studentId);
        Task AddAsync(Matricula matricula);
        Task DeleteAsync(Matricula matricula);
        Task SaveChangesAsync();
    }
}
