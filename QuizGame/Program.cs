
using QuizGame;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Quiz Game...");

var preguntas = new List<Preguntas>();
var respuestas = new List<Respuesta>();
var puntajes = new Dictionary<string, int>();
crearPreguntas();
IniciarJuego();




void IniciarJuego()
{
    Console.WriteLine("Estás Listo? Empecemos!");
    Console.WriteLine("Cuál es tu nombre?");

    var jugador = Console.ReadLine();

    Console.WriteLine($"Ok, {jugador} hagámoslo!");

    foreach (var item in preguntas)
    {
        Console.WriteLine($"{item.Id}.{item.preguntaTexto}");
        Console.WriteLine("Por favor, presione 1, 2,3 o 4");

        foreach (var opcion in item.Opciones)
        {
            Console.WriteLine($"{opcion.Id}. {opcion.Texto}");

        }

        var respuesta = obtenerRespuesta();
        AgregarRespuestaALista(respuesta, item);
    }



    int puntaje = obtenerPuntaje();
    Console.WriteLine($"Buen trabajo {jugador}! Respondiste bien {puntaje} preguntas...");

    actualizarPuntajes(jugador, puntaje);
    mostrarPuntajes();

    respuestas = new List<Respuesta>();

    Console.WriteLine("Desea jugar nuevamente?");
    Console.WriteLine("Presione si para seguir jugando o cualquier tecla para salir...");
    var jugarDeNuevo = Console.ReadLine();
    if (jugarDeNuevo?.ToLower().Trim() == "si")
        IniciarJuego();


}





void AgregarRespuestaALista(string respuesta, Preguntas pregunta)
{

    respuestas.Add(new Respuesta
    {
        IdPregunta = pregunta.Id,

        opcionSeleccionada = obtenerOpcionSeleccionada(respuesta,pregunta)

    }
        ); ; 

}


Opciones obtenerOpcionSeleccionada(string respuesta, Preguntas pregunta)
{
    var opcionSeleccionada = new Opciones();
    foreach (var item in pregunta.Opciones)
    {
        if(item.Id == int.Parse(respuesta))
        {
            opcionSeleccionada = item;
        }
    }

    return opcionSeleccionada;
}


string obtenerRespuesta()
{
    var respuesta = Console.ReadLine();

    if (respuesta != null && (respuesta == "1") || (respuesta == "2") || (respuesta == "3") || (respuesta == "4"))
        return respuesta;
    else
    {
        Console.WriteLine("Esta no es una opción válida, por favor inténte nuevamente");
       respuesta= obtenerRespuesta();
    }

    return respuesta;
}











void crearPreguntas()
{
    preguntas.Add(new Preguntas
    {
        Id = 1,
        preguntaTexto = "¿Cuál es el país más grande de la tierra?",
        Opciones = new List<Opciones>()
        {
            new Opciones { Id =1, Texto="Australia"},
            new Opciones { Id =2, Texto="Brasil"},
            new Opciones { Id =3, Texto="China"},
            new Opciones { Id =4, Texto="Russia" , EsCorrecta = true}

        }
    }
        );

    preguntas.Add(new Preguntas
    {
        Id = 2,
        preguntaTexto = "¿Cuál es el país que tiene mayor población?",
        Opciones = new List<Opciones>()
        {
            new Opciones{ Id = 1 , Texto="India"},
            new Opciones{Id = 2, Texto = "EEUU" },
            new Opciones{Id = 3, Texto = "China", EsCorrecta=true },
            new Opciones{Id = 4, Texto = "Noruega" }
        }


    });


    preguntas.Add(new Preguntas
    {
        Id = 3,
        preguntaTexto = "¿Cuál es la flor nacional de japon?",
        Opciones = new List<Opciones>()
        {
            new Opciones{ Id = 1 , Texto="Manzana"},
            new Opciones{Id = 2, Texto = "Cerezo" , EsCorrecta= true },
            new Opciones{Id = 3, Texto = "Fresa" },
            new Opciones{Id = 4, Texto = "Uva" }
        }


    });

    preguntas.Add(new Preguntas
    {
        Id = 4,
        preguntaTexto = "¿Qué órgano del cuerpo humano consume más energia?",
        Opciones = new List<Opciones>()
        {
            new Opciones{ Id = 1 , Texto="Cerebro" , EsCorrecta= true},
            new Opciones{Id = 2, Texto = "Higado"},
            new Opciones{Id = 3, Texto = "Riñones" },
            new Opciones{Id = 4, Texto = "Corazon" }
        }


    });


    preguntas.Add(new Preguntas
    {
        Id = 5,
        preguntaTexto = "¿Qué país tiene más islas en el mundo",
        Opciones = new List<Opciones>()
        {
            new Opciones{ Id = 1 , Texto="Noruega", EsCorrecta= true},
            new Opciones{Id = 2, Texto = "Suecia"},
            new Opciones{Id = 3, Texto = "Canadá" },
            new Opciones{Id = 4, Texto = "Tonga" }
        }


    });
}


int obtenerPuntaje()
{
    int puntaje = 0;


    foreach (var item in respuestas)
    {
        if (item.opcionSeleccionada.EsCorrecta)
            puntaje++;

    }
    return puntaje;

}



void actualizarPuntajes (string jugador, int puntaje)

{
    bool actualizado = false;
    foreach (var item in puntajes)
    {
        
        if(item.Key == jugador)
        {
            puntajes[item.Key] = puntaje;
            actualizado = true;
        }

       
    }

    if (!actualizado)
    {
        puntajes.Add(jugador, puntaje);
    }
}


void mostrarPuntajes()
{
    Console.WriteLine("Puntajes:");

    foreach (var item in puntajes)
    {
        Console.WriteLine($"{item.Key}, puntaje: {item.Value}");
    }
}