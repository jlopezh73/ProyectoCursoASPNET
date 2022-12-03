using ProyectoCursos.Modelos;

namespace ProyectoCursos.Proveedores;
public interface IProveedorCursos {
    public List<Curso> ObtenerCursos();
    public List<Curso> ObtenerCursos(String patronBusqueda);
    public Curso BuscarCurso(String clave);
    public Boolean GuardarCurso(Curso curso);
    public Boolean AgregarCurso(Curso curso);
    public Boolean EliminarCurso(String clave);
}