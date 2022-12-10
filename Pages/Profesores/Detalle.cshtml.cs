using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyInstituto.Models;
using ProyInstituto.Servicios;

namespace ProyInstituto.Pages.Profesores
{
    public class DetalleModel : PageModel
    {
        [BindProperty]
        public Profesor ProfesorDetalle{get;set;}
        private IProfesorServicio _profSrv;
        public DetalleModel(IProfesorServicio profSrv){
            _profSrv=profSrv;
        }

        public void OnGet(int id)
        {
            ProfesorDetalle=_profSrv.MostrarTodos()
                    .Where(x=>x.Id==id)
                    .First();
        }
    }
}
