using System;
using System.ComponentModel.DataAnnotations;

namespace TutorialWebApi.WebApi.Models
{
    public class Projetos
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        [Display(Name ="Projeto")]
        
        public string NomeProjeto { get; set; }
        

    }
}