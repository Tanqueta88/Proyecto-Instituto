using ProyInstituto.Models;

namespace ProyInstituto.Servicios
{
    public interface IMateriaServicio{
        List<Materia> MostrarMaterias();
    }
    public class MateriaServicio :IMateriaServicio{
        public List<Materia> MostrarMaterias(){
            return new List<Materia>(){
             new Materia(){Id=1,Descripcion="Herramientas"},
             new Materia(){Id=2,Descripcion="POO"},
             new Materia(){Id=3,Descripcion="WEB"},
            };
        }
    }
    public interface IProfesorServicio{
        List<Profesor> MostrarTodos();
        void Agregar(Profesor profesornuevo);
        void Modificar(Profesor profesoreditado);
        void Eliminar(Profesor profesorborrado);
    }
    public class ProfesorServicio : IProfesorServicio
    {
        private List<Profesor> ListaCompletaProfes;
        public ProfesorServicio(){
           ListaCompletaProfes=new List<Profesor>()
            {
                new Profesor(){Id=101,FechaNacimiento=new DateTime(1986,10,16),Legajo=11111,ADistancia=true,Nombre="Laura",Apellido="Alonso",Nivel=1,Materia=1},
                new Profesor(){Id=102,FechaNacimiento=new DateTime(1984,05,04),Legajo=22222,ADistancia=false,Nombre="Marina",Apellido="Lopez",Nivel=2,Materia=2},
                new Profesor(){Id=103,FechaNacimiento=new DateTime(1999,06,14),Legajo=33333,ADistancia=true,Nombre="Lucas",Apellido="Martinez",Nivel=1,Materia=3},
                new Profesor(){Id=104,FechaNacimiento=new DateTime(1998,08,01),Legajo=44444,ADistancia=false,Nombre="Matias",Apellido="Rossi",Nivel=3,Materia=1},
                new Profesor(){Id=105,FechaNacimiento=new DateTime(2003,12,17),Legajo=55555,ADistancia=true,Nombre="Cynthia",Apellido="Ferrari",Nivel=2,Materia=2},
            };
        }
        public List<Profesor> MostrarTodos(){
            return ListaCompletaProfes;
        }
        public void Agregar(Profesor profesornuevo){
            ListaCompletaProfes.Add(profesornuevo);
        }
        public void Modificar(Profesor profesoreditado){
            var profesorSinModificar=ListaCompletaProfes.Where(x=>x.Id==profesoreditado.Id).First();
            ListaCompletaProfes.Remove(profesorSinModificar);
            ListaCompletaProfes.Add(profesoreditado);
        }
        public void Eliminar(Profesor profesorborrado){
            var profesoraborrar=ListaCompletaProfes.Where(x=>x.Id==profesorborrado.Id).First();
            ListaCompletaProfes.Remove(profesoraborrar);
        }
    }
}