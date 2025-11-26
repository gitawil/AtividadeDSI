using University.Application.ViewModels;
using University.Application.Requests;

namespace University.Application.Services {
    public interface IMatriculaService {
        Task<MatriculaViewModel> CreateAsync(CreateMatriculaRequest request);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<MatriculaViewModel>> GetByStudentIdAsync(Guid studentId);
    }
}
