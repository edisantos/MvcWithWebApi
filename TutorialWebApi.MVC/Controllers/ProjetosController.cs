using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TutorialWebApi.MVC.Models;

namespace TutorialWebApi.MVC.Controllers
{
    public class ProjetosController : Controller
    {
        // GET: Projetos
        public ActionResult Index()
        {
            IEnumerable<ProjetosMVC> ListProjetc;
            HttpResponseMessage response = GlobalApiVariables.WebApiClient.GetAsync("Projetos").Result;
            ListProjetc = response.Content.ReadAsAsync<IEnumerable<ProjetosMVC>>().Result;
            return View(ListProjetc);
        }
        public ActionResult Create(int id = 0)
        {
            if(id==0)
            {
                return View(new ProjetosMVC());
            }
            else
            {
                HttpResponseMessage response = GlobalApiVariables.WebApiClient.GetAsync("Projetos/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ProjetosMVC>().Result);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjetosMVC model)
        {
            if(model.Id == 0)
            {
                HttpResponseMessage response = GlobalApiVariables.WebApiClient.PostAsJsonAsync("Projetos", model).Result;
                TempData["SuccessMessage"] = "Saved Successfully!";
            }
            else
            {
                HttpResponseMessage response = GlobalApiVariables.WebApiClient.PutAsJsonAsync("Projetos/"+ model.Id, model).Result;
                TempData["SuccessMessage"] = "Updated Successfully!";
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Excluir(int id)
        {
            HttpResponseMessage response = GlobalApiVariables.WebApiClient.DeleteAsync("Projetos/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}