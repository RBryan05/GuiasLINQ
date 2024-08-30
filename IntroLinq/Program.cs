using IntroLinq;
using IntroLinq.IntroduccionLinq;

#region Introduccion 
string[] palabras;
palabras = new string[] { "gato", "perro", "lagarto", "tortuga", "cocdrilo", "serpiente", "123456789" };
Console.WriteLine("Mas de 5 letras");

List<string> resultado = new List<string>();

foreach (string str in palabras)
{
    if (str.Length > 5)
    {
        resultado.Add(str);
    }
}

foreach (var r in resultado)
    Console.WriteLine(r);

#endregion
#region utilizando Linq
Console.WriteLine("-----------------------------------------------------");
IEnumerable<string> list = from r in palabras where r.Length > 8 select r;
foreach (var listado in list)
    Console.WriteLine(listado);
Console.WriteLine("-----------------------------------------------------");

#endregion
#region ListaModelos
List<Casa> ListaCasas = new List<Casa>();
List<Habitante> ListaHabitantes = new List<Habitante>();
#endregion
#region listaCasa
ListaCasas.Add(new Casa
{
    Id = 1,
    Direccion = "3 av Norte ArcanCity",
    Ciudad = "Gothan City",
    numeroHabitaciones = 20,
});
ListaCasas.Add(new Casa
{
    Id = 2,
    Direccion = "6 av Sur SmollVille",
    Ciudad = "Metropolis",
    numeroHabitaciones = 5,
});
ListaCasas.Add(new Casa
{
    Id = 3,
    Direccion = "Forest Hills, Queens, NY 11375",
    Ciudad = "New York"
});
#endregion
#region ListaHabitante
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Bruno Diaz",
    Edad = 36,
    IdCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Clark Kent.",
    Edad = 40,
    IdCasa = 2
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Peter Parker",
    Edad = 25,
    IdCasa = 3
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Tia Mey",
    Edad = 85,
    IdCasa = 3
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Luise Lain",
    Edad = 40,
    IdCasa = 2
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Selina Kyle",
    Edad = 30,
    IdCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Alfred",
    Edad = 65,
    IdCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Nathan Drake",
    Edad = 37,
    IdCasa = 1
});
#endregion
#region SentenciasLinQ

IEnumerable<Habitante> ListaEdad = from ObjetoProvicional
                                   in ListaHabitantes
                                   where ObjetoProvicional.Edad > 40
                                   select ObjetoProvicional;

foreach (Habitante objetoProcicional2 in ListaEdad)
{
    Console.WriteLine(objetoProcicional2.datosHabitante());
}

//Join
IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in ListaHabitantes
                                         join objetoTemporalCasa in ListaCasas
                                         on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.Id
                                         where objetoTemporalCasa.Ciudad == "Gothan City"
                                         select objetoTemporalHabitante;
Console.WriteLine("----------------------------------------------------------------------------------------------");
foreach (Habitante h in listaCasaGothan)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion
#region FirsthAndFirsthOrDefault
Console.WriteLine("----------------------------------------------------------------------------------------------");
var primeraCasa = ListaCasas.First(); //esto no es linQ es  una fucnin de los Ienumarable
Console.WriteLine(primeraCasa.dameDatosCasa());

//aplicando una restriccion sin restricion lambda
Habitante personaEdad = (from variableTemporalHabitante in ListaHabitantes where variableTemporalHabitante.Edad > 25 select variableTemporalHabitante).First();
Console.WriteLine(personaEdad.datosHabitante());
Console.WriteLine("---------------------------Lo mismo pero con lambdas---------------------------------------------------------");
var Habitante1 = ListaHabitantes.First(objectTemp => objectTemp.Edad > 25);
Console.WriteLine(Habitante1.datosHabitante());

// Si no tenemos el elemento que buscamos entoences la sonsulta devolvera una exepcion esto detendra el codigo en su totalidad

//Casa EdadError = (from vCasaTemp in ListaCasas where vCasaTemp.Id >10 select vCasaTemp).First() ;
//Console.WriteLine(EdadError.dameDatosCasa());

Casa CasaConFirsthOrDedault = ListaCasas.FirstOrDefault(vCasa => vCasa.Id > 200);
if (CasaConFirsthOrDedault == null)
{
    Console.WriteLine("No existe !No hay!");
    return;
}
Console.WriteLine("existe !Si existe!");

#endregion
#region Last
Casa ultimaCasa = ListaCasas.Last(temp => temp.Id > 1);
Console.WriteLine(ultimaCasa.dameDatosCasa());
Console.WriteLine("_____________________________________________________");
var h1 = (from objHabitante in ListaHabitantes where objHabitante.Edad > 60 select objHabitante)
    .LastOrDefault();
if (h1 == null)
{
    Console.WriteLine("Algo fallo");
    return;
}
Console.WriteLine(h1.datosHabitante());

#endregion
#region ElementAt
var terceraCasa = ListaCasas.ElementAt(2);
Console.WriteLine($"La tercera casa es {terceraCasa.dameDatosCasa()}");

var casaError = ListaCasas.ElementAtOrDefault(3);
if (casaError != null) { Console.WriteLine($"La tercera casa es {casaError.dameDatosCasa()}"); }

var segundoHabitante = (from objetoTem in ListaHabitantes select objetoTem).ElementAtOrDefault(2);
Console.WriteLine($" segundo habitante es : {segundoHabitante.datosHabitante()}");

#endregion
#region single

try
{
    var habitantes = ListaHabitantes.Single(variableTem => variableTem.Edad > 40 && variableTem.Edad < 70);
    // Creando esta consulta pero con LinQ
    var habitante2 = (from obtem in ListaHabitantes where obtem.Edad > 70 select obtem).SingleOrDefault();

    Console.WriteLine($"habitante con menos de 20 años {habitantes.datosHabitante()}");
    if (habitante2 != null) Console.WriteLine($"habitante con mas de 70 años {habitante2.datosHabitante()}");
}
catch (Exception)
{
    Console.WriteLine($"Ocurrio el error");
}

#endregion
#region typeOf
var listaEmpleados = new List<Empleado>() {
    new Medico(){ nombre= "Jorge Casa" },
    new Enfermero(){ nombre = "Raul Blanco"}
};

var medico = listaEmpleados.OfType<Medico>();
Console.WriteLine(medico.Single().nombre);

#endregion
#region OrderBy
var edadA = ListaHabitantes.OrderBy(x => x.Edad);
var edadAC = from vt in ListaHabitantes orderby vt.Edad select vt;
foreach (var edad in edadAC)
{
    Console.WriteLine(edad.datosHabitante());
}

#endregion
#region OrderBYDescending()
var listaEdad = ListaHabitantes.OrderByDescending(x => x.Edad);
foreach (Habitante h in listaEdad)
{
    Console.WriteLine(h.datosHabitante());
}
Console.WriteLine("-------------------------------------------");
var ListaEdad2 = from h in ListaHabitantes orderby h.Edad descending select h;
foreach (Habitante h in ListaEdad2)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion
#region ThenBy
var habitantes3 = ListaHabitantes.OrderBy(x => x.Edad).ThenBy(x => x.Nombre);

var edadATA = from h in ListaHabitantes orderby h.Edad, h.Nombre descending select h;

foreach (var h in edadATA)
{
    Console.WriteLine(h.datosHabitante());
}

Console.WriteLine("------------------");

#endregion
#region ThenByDescending
var habitantes4 = ListaHabitantes.OrderBy(x => x.Edad).ThenByDescending(x => x.Nombre);

foreach (var h in habitantes4)
{
    Console.WriteLine(h.datosHabitante());
}

var lista5 = from h in ListaHabitantes orderby h.Edad, h.Nombre descending select h;

foreach (var h in lista5)
{
    Console.WriteLine(h.datosHabitante());
}
#endregion
