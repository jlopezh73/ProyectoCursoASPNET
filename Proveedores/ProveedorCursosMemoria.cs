using ProyectoCursos.Modelos;

namespace ProyectoCursos.Proveedores;

public class ProveedorCursosMemoria : IProveedorCursos {
    private List<Curso> listaCursos;
    public ProveedorCursosMemoria() {
            listaCursos = new List<Curso>();
            listaCursos.Add(new Curso() {
                Clave="123456", Nombre="Análisis de Datos", NoHoras=40, 
                Descripcion="En este curso se revisan técnicas de análisis de datos", Instructor="MIA. Juan Luis López Herrera",
                FechaInicio=DateTime.Parse("09/02/2023"), FechaTermino=DateTime.Parse("07/03/2023") 
            });
            listaCursos.Add(new Curso() {
                Clave="678990", Nombre="HTML Avanzado", NoHoras=80, 
                Descripcion="En este curso se revisan técnicas de HTML avanzado", Instructor="Dr. Pedro Xavier Sánchez",
                FechaInicio=DateTime.Parse("06/05/2023"), FechaTermino=DateTime.Parse("07/07/2023") 
            });
    }
    public List<Curso> ObtenerCursos()
    {
        return listaCursos;        
    }    

    public List<Curso> ObtenerCursos(String patronBusqueda) {
        return listaCursos.Where(c => c.Nombre.Contains(patronBusqueda)).ToList();
    }
    public Curso BuscarCurso(String clave) {
        return listaCursos.FirstOrDefault(c => c.Clave.Equals(clave));
    }

    public Boolean GuardarCurso(Curso curso) {
        Curso cursoG = listaCursos.FirstOrDefault(c => c.Clave.Equals(curso.Clave));
        if (cursoG != null) {
            cursoG.Clave = curso.Clave;
            cursoG.Descripcion = curso.Descripcion;
            cursoG.Nombre = curso.Nombre;
            cursoG.NoHoras = curso.NoHoras;
            cursoG.FechaInicio = curso.FechaInicio;
            cursoG.FechaTermino = curso.FechaTermino;
            cursoG.Instructor = curso.Instructor;
            return true;
        }
        return false;
    }

    public Boolean AgregarCurso(Curso curso) {
        listaCursos.Add(curso);
        return true;
    }

    public Boolean EliminarCurso(String clave) {
        //var curso = BuscarCurso(clave);
        var curso = listaCursos.FirstOrDefault(c => c.Clave.Equals(clave));
        if (curso != null) {
            listaCursos.Remove(curso);
            return true;
        }
        return false;
    }
}
