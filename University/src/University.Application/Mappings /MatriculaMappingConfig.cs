using Mapster;
using University.Domain.Entities;
using University.Application.ViewModels;

namespace University.Application.Mappings {
  public class MatriculaMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {

      config.NewConfig<Matricula, MatriculaViewModel>()
          .Map(dest => dest.Id, src => src.Id)
          .Map(dest => dest.StudentId, src => src.StudentId)
          .Map(dest => dest.CourseName, src => src.CourseName)
          .Map(dest => dest.CreatedAt, src => src.CreatedAt);
    }
  }
}
