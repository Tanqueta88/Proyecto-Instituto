using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyInstituto.Models;
using ProyInstituto.Servicios;
namespace ProyInstituto.Pages.Profesores
{
    public class ListadoModel : PageModel
    {
        [BindProperty]
        public List<Profesor> NominaProfesores {get;set;}

        private IProfesorServicio _profesorServicio;
        public string NombreOrden;
        public ListadoModel(IProfesorServicio profSrv){
            _profesorServicio=profSrv;
        }
        public void OnGet(string FiltroNombre,string FiltroApellido,string CampoOrden)
        {
           NominaProfesores=_profesorServicio.MostrarTodos();
           NombreOrden = (CampoOrden == "Nombre_Asc") ? "Nombre_Desc" : "Nombre_Asc";
                            
           if(FiltroNombre!=null && FiltroNombre.Length > 0)
            {
                //NominaProfesores = NominaProfesores.Where(x => x.Nombre == FiltroNombre).ToList();LAURA MARINA MATIAS  MA
                NominaProfesores = NominaProfesores
                                    .Where(x => 
                                            x.Nombre.ToUpper()
                                            .Contains(FiltroNombre.ToUpper())   
                                           )
                                    .ToList();
            }
            /*
            if (CampoOrden == "OrdenPorNombre")
            {
                NominaProfesores = NominaProfesores.OrderBy(x => x.Nombre).ToList();
            }
            else if(CampoOrden == "OrdenPorApellido")
            {
                NominaProfesores = NominaProfesores.OrderBy(x => x.Apellido).ToList();
            }
            else
            {
                NominaProfesores = NominaProfesores.OrderBy(x => x.Id).ToList();
            }
            */
            switch (CampoOrden) {
                case "Nombre_Asc":
                    NominaProfesores = NominaProfesores.OrderBy(x => x.Nombre).ToList();
                    break;
                case "Nombre_Desc":
                    NominaProfesores = NominaProfesores.OrderByDescending(x => x.Nombre).ToList();
                    break;
                case "OrdenPorApellido":
                    NominaProfesores = NominaProfesores.OrderBy(x => x.Apellido).ToList();
                    break;
                case "OrdenPorApellidoDesc":
                    NominaProfesores = NominaProfesores.OrderByDescending(x => x.Apellido).ToList();
                    break;
                default:
                    NominaProfesores = NominaProfesores.OrderBy(x => x.Id).ToList();
                    break;
            }
            
        }

        public void OnGetBorrar(int idBorrar) {
            var profeborrar = _profesorServicio.MostrarTodos().Where(x => x.Id == idBorrar).First();
            _profesorServicio.Eliminar(profeborrar);
            NominaProfesores = _profesorServicio.MostrarTodos().ToList();
        }


    }
}
