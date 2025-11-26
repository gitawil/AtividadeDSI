using Mapster;
using University.Domain.Entities;
using University.Application.ViewModels;

namespace University.Application.Mappings {
  public class StudentMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {

      config.NewConfig<Student, StudentViewModel>()
          .Map(dest => dest.Id, src => src.Id)
          .Map(dest => dest.FullName, src => src.FullName)
          .Map(dest => dest.Email, src => src.Email)
          .Map(dest => dest.Age, src => src.Age);

    }
  }
}
