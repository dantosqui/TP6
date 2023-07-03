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

    [HttpPost] public IActionResult GuardarCandidato(Candidato can, int idPartido){
        BD.AgregarCandidato(can);
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        ViewBag.idPartido=idPartido;
        return View("DetallePartido");
    }

    //zarekegorritos @gorritos.com

    public IActionResult EliminarCandidato(int idCandidato, int idPartido){
        int registros=BD.EliminarCandidato(idCandidato);
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        ViewBag.ListaCandidatos = BD.ListarCandidatos(idPartido);
        return View("DetallePartido");
    }

    public IActionResult Elecciones(){
        return View();
    } 
    public IActionResult Creditos(){
        return View();
    }
}
