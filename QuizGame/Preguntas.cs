using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Preguntas
    {
        public int Id { get; set; }
        public string preguntaTexto { get; set; }

        public List<Opciones> Opciones { get; set; }

    }
}
