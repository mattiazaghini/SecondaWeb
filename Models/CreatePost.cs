using System;
using Microsoft.AspNetCore.Http;

namespace Zaghini.Mattia._5H.SecondaWeb.Models
{
    public class CreatePost
    {
        public IFormFile MyCSV {get;set;}
        public string Descrizione { get; set; }
    }
}