using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TutorialWebApi.WebApi.Contexto;
using TutorialWebApi.WebApi.Models;

namespace TutorialWebApi.WebApi.Controllers
{
    public class ProjetosController : ApiController
    {
        private DataContexto db = new DataContexto();

        // GET: api/Projetos
        public IQueryable<Projetos> GetProjetos()
        {
            return db.Projetos;
        }

        // GET: api/Projetos/5
        [ResponseType(typeof(Projetos))]
        public IHttpActionResult GetProjetos(int id)
        {
            Projetos projetos = db.Projetos.Find(id);
            if (projetos == null)
            {
                return NotFound();
            }

            return Ok(projetos);
        }

        // PUT: api/Projetos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjetos(int id, Projetos projetos)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != projetos.Id)
            {
                return BadRequest();
            }

            db.Entry(projetos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projetos
        [ResponseType(typeof(Projetos))]
        public IHttpActionResult PostProjetos(Projetos projetos)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Projetos.Add(projetos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projetos.Id }, projetos);
        }

        // DELETE: api/Projetos/5
        [ResponseType(typeof(Projetos))]
        public IHttpActionResult DeleteProjetos(int id)
        {
            Projetos projetos = db.Projetos.Find(id);
            if (projetos == null)
            {
                return NotFound();
            }

            db.Projetos.Remove(projetos);
            db.SaveChanges();

            return Ok(projetos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjetosExists(int id)
        {
            return db.Projetos.Count(e => e.Id == id) > 0;
        }
    }
}