using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCursos.Modelos;
using ProyectoCursos.Proveedores;

namespace ProyectoCursos.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProveedorCursos _proveedorCursos;

    public IndexModel(ILogger<IndexModel> logger, IProveedorCursos proveedorCursos)
    {
        _logger = logger;
        _proveedorCursos = proveedorCursos;
    }

    [BindProperty(SupportsGet = true)]
    public List<Curso> listaCursos {get; set;}

    [BindProperty(SupportsGet=true)]
    public String patronBuscar {get; set;}

    public void OnGet()
    {
        listaCursos = _proveedorCursos.ObtenerCursos();
    }

    public void OnPost() {
        if (String.IsNullOrEmpty(patronBuscar))
            listaCursos = _proveedorCursos.ObtenerCursos();
        else
            listaCursos = _proveedorCursos.ObtenerCursos(patronBuscar);
    }
}
