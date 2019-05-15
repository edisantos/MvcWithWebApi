using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TutorialWebApi.WebApi.Models;

namespace TutorialWebApi.WebApi.Contexto
{
    public class DataContexto:DbContext
    {
        public DataContexto()
            :base("StrConexao")
        {

        }

        public DbSet<Projetos> Projetos { get; set; }
    }
}