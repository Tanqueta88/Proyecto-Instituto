using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyInstituto.Models;
using ProyInstituto.Servicios;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyInstituto.Pages.Profesores
{
    public class EditarModel : PageModel
    {
        [BindProperty]
        public Profesor ProfesorEdit {get;set;}
        public List<SelectListItem> MateriasLista {get;set;}
        private IProfesorServicio _profServicio;
        private IMateriaServicio _matSrv;
        public EditarModel(IProfesorServicio prosrv,IMateriaServicio matSrv){
            _profServicio=prosrv;
            _matSrv=matSrv;
        }
        public void OnGet(int id)
        {
            var lista= _profServicio.MostrarTodos();
            ProfesorEdit=lista.Where(x=>x.Id==id).First();
            MateriasLista=_matSrv.MostrarMaterias().Select(a=>
                                new SelectListItem{
                                    Value=a.Id.ToString(),
                                    Text=a.Descripcion
                                }
                            ).ToList();
        }
        public IActionResult OnPost(){
            if(ModelState.IsValid){
                _profServicio.Modificar(ProfesorEdit);
                return RedirectToPage("Listado");
            }
           else{
            return Page();
           }
        }
    }
}
