using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCursos.Modelos;
using ProyectoCursos.Proveedores;

namespace ProyectoCursos.Pages;

public class EditarCursoModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProveedorCursos _proveedorCursos;

    public EditarCursoModel(ILogger<IndexModel> logger, IProveedorCursos proveedorCursos)
    {
        _logger = logger;
        _proveedorCursos = proveedorCursos;
    }

    [BindProperty(SupportsGet = true)]
    public Curso curso {get; set;}

    [BindProperty(SupportsGet = true)]
    public int cursoNuevo { get; set; }

    public IActionResult OnGet(String id)
    {
        if (id.Equals("0"))
        {
            curso = new Curso()
            {
                Nombre = "- Nuevo Curso -",
                FechaInicio = DateTime.Now,
                FechaTermino = DateTime.Now.AddDays(30),
                NoHoras = 40
           };
            cursoNuevo = 1;
        }
        else
        {
            curso = _proveedorCursos.BuscarCurso(id);
            cursoNuevo = 0;
        }

        if (curso == null) {
            HttpContext.Response.Redirect("Index");            
            return null;
        } else
            return Page();
        
    }

    public void OnPost() {
        bool correcto = true;
        if (ModelState.IsValid)
        {
            if (cursoNuevo == 1)
                correcto = _proveedorCursos.AgregarCurso(curso);
            else
                correcto = _proveedorCursos.GuardarCurso(curso);

            if (correcto)
                HttpContext.Response.Redirect("/Index");
        }
    }
}
