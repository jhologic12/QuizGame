using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Opciones
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool EsCorrecta { get; set; }
    }
}
