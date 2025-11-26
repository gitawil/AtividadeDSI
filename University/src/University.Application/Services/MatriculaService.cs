using MapsterMapper;
using University.Application.Requests;
using University.Application.Services;
using University.Application.ViewModels;
using University.Domain.Entities;
using University.Domain.Repositories;

namespace University.Application.Services {
    public class MatriculaService : IMatriculaService {
        private readonly IMatriculaRepository _repo;
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;

        public MatriculaService(
            IMatriculaRepository repo,
            IStudentRepository studentRepo,
            IMapper mapper) 
        {
            _repo = repo;
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        public async Task<MatriculaViewModel> CreateAsync(CreateMatriculaRequest request) {
            var student = await _studentRepo.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new Exception("Aluno não encontrado.");

            var matricula = new Matricula(request.StudentId, request.CourseName);

            await _repo.AddAsync(matricula);
            await _repo.SaveChangesAsync();

            return _mapper.Map<MatriculaViewModel>(matricula);
        }

        public async Task DeleteAsync(Guid id) {
            var matricula = await _repo.GetByIdAsync(id);
            if (matricula == null)
                throw new Exception("Matrícula não encontrada.");

            await _repo.DeleteAsync(matricula);
            await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<MatriculaViewModel>> GetByStudentIdAsync(Guid studentId) {
            var matriculas = await _repo.GetByStudentIdAsync(studentId);
            return _mapper.Map<IEnumerable<MatriculaViewModel>>(matriculas);
        }
    }
}
