using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCursos.Modelos;
using ProyectoCursos.Proveedores;

namespace ProyectoCursos.Pages;

public class DetallesCursoModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProveedorCursos _proveedorCursos;

    public DetallesCursoModel(ILogger<IndexModel> logger, IProveedorCursos proveedorCursos)
    {
        _logger = logger;
        _proveedorCursos = proveedorCursos;
    }

    [BindProperty(SupportsGet = true)]
    public Curso curso {get; set;}

    public void OnGet(String id)
    {
        curso = _proveedorCursos.BuscarCurso(id);
        if (curso == null)
            Redirect("Index");
    }
}
