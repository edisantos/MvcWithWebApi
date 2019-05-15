using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorialWebApi.MVC.Models
{
    public class ProjetosMVC
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        [Display(Name = "Projeto")]
        public string NomeProjeto { get; set; }
    }
}