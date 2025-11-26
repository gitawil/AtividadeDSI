using Microsoft.AspNetCore.Mvc;
using University.Application.Services;
using University.Application.Requests;

namespace University.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class MatriculasController : ControllerBase {
        private readonly IMatriculaService _service;

        public MatriculasController(IMatriculaService service) {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMatriculaRequest request) {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> ListByStudent(Guid studentId) {
            var result = await _service.GetByStudentIdAsync(studentId);
            return Ok(result);
        }
    }
}
