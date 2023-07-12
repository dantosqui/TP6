using Microsoft.AspNetCore.Mvc;

namespace TP6.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.listaPartidos = BD.ListarPartidos();
        return View();
    }

    public IActionResult DetallePartido(int idPartido){
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);

        return View();
    }

    public IActionResult DetalleCandidato(int idCandidato){
        ViewBag.DetalleCandidato=BD.VerInfoCandidato(idCandidato);
        return View();
    }

    public IActionResult AgregarCandidato(int idPartido){
        ViewBag.idPartido = idPartido;

        return View("FormularioCandidatos");
    }

    public IActionResult AgregarPartido(){
        

        return View("FormularioPartidos");
    }


    [HttpPost] public IActionResult GuardarCandidato(Candidato can, int idPartido){
        if(BD.ListarCandidatos(idPartido).Any(Candidato => Candidato.DNI == can.DNI)){
            Console.WriteLine("holaaaaa");
        }
        BD.AgregarCandidato(can);
        return RedirectToAction("DetallePartido", new {idPartido=idPartido});
    }

    [HttpPost] public IActionResult GuardarPartido(Partido part){
        BD.AgregarPartido(part);
        return RedirectToAction("Index");
    }

    //zarekegorritos @gorritos.com

    public IActionResult EliminarCandidato(int idCandidato, int idPartido){
        int registros=BD.EliminarCandidato(idCandidato);
        return RedirectToAction("DetallePartido", new {idPartido=idPartido});
    }
    public IActionResult EliminarPartido(int idPartido){
        int registros=BD.EliminarPartido(idPartido);
        return RedirectToAction("Index");
    }

    public IActionResult Elecciones(){
        return View();
    } 
    public IActionResult Creditos(){
        return View();
    }
}
