using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;
using University.Domain.Repositories;
using University.Infrastructure.Persistence;

namespace University.Infrastructure.Repositories {
    public class MatriculaRepository : IMatriculaRepository {
        private readonly AppDbContext _context;

        public MatriculaRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Matricula> GetByIdAsync(Guid id) =>
            await _context.Matriculas.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<IEnumerable<Matricula>> GetByStudentIdAsync(Guid studentId) =>
            await _context.Matriculas.Where(m => m.StudentId == studentId).ToListAsync();

        public async Task AddAsync(Matricula matricula) {
            await _context.Matriculas.AddAsync(matricula);
        }

        public async Task DeleteAsync(Matricula matricula) {
            _context.Matriculas.Remove(matricula);
        }

        public async Task SaveChangesAsync() {
            await _context.SaveChangesAsync();
        }
    }
}
