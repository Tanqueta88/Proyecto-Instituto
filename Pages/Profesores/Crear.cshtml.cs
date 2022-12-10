using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyInstituto.Models;
using ProyInstituto.Servicios;

namespace ProyInstituto.Pages
{
    public class CrearModel : PageModel
    {   
        [BindProperty]
        public Profesor ProfesorIng {get;set;}

        private IProfesorServicio _prsrv;
        public CrearModel(IProfesorServicio srv){
            _prsrv=srv;
        }
        public void OnGet()
        {
        }
        public void OnPost(){
           _prsrv.Agregar(ProfesorIng);
        }
    }
}
