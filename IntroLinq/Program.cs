using IntroLinq;
using IntroLinq.IntroduccionLinq;

#region Introduccion
// Declaramos un array de strings llamado 'palabras' que contiene varios nombres de animales y una secuencia numérica.
string[] palabras;
palabras = new string[] { "gato", "perro", "lagarto", "tortuga", "cocodrilo", "serpiente", "123456789" };

// Imprimimos un mensaje en la consola que indica que vamos a buscar palabras con más de 5 letras.
Console.WriteLine("Más de 5 letras");
// Creamos una lista vacía llamada 'resultado' para almacenar las palabras que cumplen con la condición.
List<string> resultado = new List<string>();

// Iteramos sobre cada string en el array 'palabras'.
foreach (string str in palabras)
{
    // Si la longitud de la palabra es mayor que 5, la agregamos a la lista 'resultado'.
    if (str.Length > 5)
    {
        resultado.Add(str);
    }
}

// Iteramos sobre la lista 'resultado' y mostramos cada palabra en la consola.
foreach (var r in resultado)
    Console.WriteLine(r);

#endregion
#region utilizando Linq
// Imprimimos una línea separadora en la consola para distinguir entre los diferentes métodos de filtrado.
Console.WriteLine("-----------------------------------------------------");

// Utilizamos LINQ para seleccionar las palabras del array 'palabras' que tengan más de 8 caracteres.
IEnumerable<string> list = from r in palabras where r.Length > 8 select r;

// Iteramos sobre la lista 'list' y mostramos cada palabra que cumple con la condición en la consola.
foreach (var listado in list)
    Console.WriteLine(listado);
// Imprimimos otra línea separadora para indicar el final de esta sección.
Console.WriteLine("-----------------------------------------------------");

#endregion
#region ListaModelos
// Creamos dos listas vacías: una para almacenar objetos de tipo 'Casa' y otra para almacenar objetos de tipo 'Habitante'.
List<Casa> ListaCasas = new List<Casa>();
List<Habitante> ListaHabitantes = new List<Habitante>();
#endregion
#region listaCasa
// Agregamos tres objetos 'Casa' a la lista 'ListaCasas', cada uno con diferentes propiedades como Id, Dirección, Ciudad, y número de habitaciones.
ListaCasas.Add(new Casa
{
    Id = 1,
    Direccion = "3 av Norte ArcanCity",
    Ciudad = "Gotham City",
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
// Agregamos varios objetos 'Habitante' a la lista 'ListaHabitantes', asignando a cada habitante un IdHabitante, Nombre, Edad, y IdCasa.

// Agregamos a Bruno Díaz, de 36 años, a la casa con Id 1.
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Bruno Diaz",
    Edad = 36,
    IdCasa = 1
});

// Agregamos a Clark Kent, de 40 años, a la casa con Id 2.
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Clark Kent",
    Edad = 40,
    IdCasa = 2
});

// Agregamos a Peter Parker, de 25 años, a la casa con Id 3.
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Peter Parker",
    Edad = 25,
    IdCasa = 3
});

// Agregamos a Tía May, de 85 años, a la casa con Id 3.
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Tia Mey",
    Edad = 85,
    IdCasa = 3
});

// Agregamos a Lois Lane, de 40 años, a la casa con Id 2 (nótese el error tipográfico en el nombre "Luise Lain", que corregimos aquí).
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Lois Lane",
    Edad = 40,
    IdCasa = 2
});

// Agregamos a Selina Kyle, de 30 años, a la casa con Id 1.
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Selina Kyle",
    Edad = 30,
    IdCasa = 1
});

// Agregamos a Alfred, de 65 años, a la casa con Id 1.
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Alfred",
    Edad = 65,
    IdCasa = 1
});

// Agregamos a Nathan Drake, de 37 años, a la casa con Id 1.
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Nathan Drake",
    Edad = 37,
    IdCasa = 1
});

#endregion
#region SentenciasLinQ
// Creamos una colección IEnumerable llamada 'ListaEdad' que selecciona los habitantes cuya edad es mayor a 40 años.
IEnumerable<Habitante> ListaEdad = from ObjetoProvicional
                                   in ListaHabitantes
                                   where ObjetoProvicional.Edad > 40
                                   select ObjetoProvicional;

// Iteramos sobre cada habitante en 'ListaEdad' y mostramos sus datos utilizando el método 'datosHabitante'.
foreach (Habitante objetoProcicional2 in ListaEdad)
{
    Console.WriteLine(objetoProcicional2.datosHabitante());
}

// Realizamos una operación de Join para unir las listas de 'Habitantes' y 'Casas' con base en el Id, 
// seleccionando solo aquellos habitantes que residen en "Gotham City".
IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in ListaHabitantes
                                         join objetoTemporalCasa in ListaCasas
                                         on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.Id
                                         where objetoTemporalCasa.Ciudad == "Gotham City"
                                         select objetoTemporalHabitante;

// Imprimimos una línea separadora para distinguir los resultados.
Console.WriteLine("----------------------------------------------------------------------------------------------");

// Iteramos sobre la lista resultante 'listaCasaGothan' y mostramos los datos de cada habitante utilizando 'datosHabitante'.
foreach (Habitante h in listaCasaGothan)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion
#region FirsthAndFirsthOrDefault

// Imprimimos una línea separadora.
Console.WriteLine("----------------------------------------------------------------------------------------------");

// Utilizamos el método 'First' para obtener el primer elemento de la lista 'ListaCasas' y mostramos sus datos.
var primeraCasa = ListaCasas.First(); // Esto no es LINQ, es una función de IEnumerable.
Console.WriteLine(primeraCasa.dameDatosCasa());

// Aplicamos una restricción en la lista 'ListaHabitantes' para obtener el primer habitante con más de 25 años usando LINQ.
Habitante personaEdad = (from variableTemporalHabitante in ListaHabitantes where variableTemporalHabitante.Edad > 25 select variableTemporalHabitante).First();
Console.WriteLine(personaEdad.datosHabitante());

// Mostramos un mensaje indicando que haremos lo mismo, pero con una expresión lambda.
Console.WriteLine("---------------------------Lo mismo pero con lambdas---------------------------------------------------------");

// Utilizamos una expresión lambda para obtener el primer habitante con más de 25 años.
var Habitante1 = ListaHabitantes.First(objectTemp => objectTemp.Edad > 25);
Console.WriteLine(Habitante1.datosHabitante());

// Si intentamos obtener un elemento que no existe con 'First', el código lanzaría una excepción, 
// lo que detendría la ejecución del programa. Aquí se ejemplifica cómo manejar esto con 'FirstOrDefault'.

// Casa EdadError = (from vCasaTemp in ListaCasas where vCasaTemp.Id >10 select vCasaTemp).First();
// Console.WriteLine(EdadError.dameDatosCasa());

// Utilizamos 'FirstOrDefault' para intentar obtener una casa con Id mayor a 200. 
// Si no existe, la variable será null y mostramos un mensaje.
Casa CasaConFirsthOrDedault = ListaCasas.FirstOrDefault(vCasa => vCasa.Id > 200);
if (CasaConFirsthOrDedault == null)
{
    Console.WriteLine("No existe !No hay!");
    return;
}
Console.WriteLine("¡Existe! ¡Sí existe!");

#endregion
#region Last

// Utilizamos 'Last' para obtener la última casa cuyo Id es mayor que 1 y mostramos sus datos.
Casa ultimaCasa = ListaCasas.Last(temp => temp.Id > 1);
Console.WriteLine(ultimaCasa.dameDatosCasa());
Console.WriteLine("_____________________________________________________");

// Usamos LINQ para obtener el último habitante con más de 60 años. Si no se encuentra, devolvemos null y mostramos un mensaje de error.
var h1 = (from objHabitante in ListaHabitantes where objHabitante.Edad > 60 select objHabitante)
    .LastOrDefault();
if (h1 == null)
{
    Console.WriteLine("Algo falló");
    return;
}
// Si el habitante existe, mostramos sus datos.
Console.WriteLine(h1.datosHabitante());

#endregion
#region ElementAt
// Utilizamos el método 'ElementAt' para obtener la tercera casa en la lista 'ListaCasas' (índice 2) y mostramos sus datos.
var terceraCasa = ListaCasas.ElementAt(2);
Console.WriteLine($"La tercera casa es {terceraCasa.dameDatosCasa()}");

// Usamos 'ElementAtOrDefault' para intentar obtener una casa en el índice 3 (cuarta casa). 
// Si no existe, el resultado será null, y verificamos esto antes de intentar acceder a sus datos.
var casaError = ListaCasas.ElementAtOrDefault(3);
if (casaError != null)
{
    Console.WriteLine($"La cuarta casa es {casaError.dameDatosCasa()}");
}

// Seleccionamos el segundo habitante en la lista 'ListaHabitantes' usando 'ElementAtOrDefault' y mostramos sus datos.
var segundoHabitante = (from objetoTem in ListaHabitantes select objetoTem).ElementAtOrDefault(2);
Console.WriteLine($"El segundo habitante es: {segundoHabitante.datosHabitante()}");

#endregion
#region single

// Intentamos encontrar un único habitante cuya edad esté entre 40 y 70 años usando el método 'Single'. 
// Si hay más de uno o ninguno, se lanzará una excepción.
try
{
    var habitantes = ListaHabitantes.Single(variableTem => variableTem.Edad > 40 && variableTem.Edad < 70);

    // Realizamos la misma consulta pero usando LINQ para encontrar un único habitante con edad mayor a 70 años. 
    // Si no existe tal habitante, 'SingleOrDefault' devolverá null.
    var habitante2 = (from obtem in ListaHabitantes where obtem.Edad > 70 select obtem).SingleOrDefault();

    Console.WriteLine($"Habitante con edad entre 40 y 70 años: {habitantes.datosHabitante()}");
    if (habitante2 != null)
        Console.WriteLine($"Habitante con más de 70 años: {habitante2.datosHabitante()}");
}
catch (Exception)
{
    // Si ocurre una excepción (por ejemplo, si hay más de un habitante que cumple con la condición), la capturamos y mostramos un mensaje.
    Console.WriteLine("Ocurrió un error");
}

#endregion
#region typeOf

// Creamos una lista de empleados que contiene objetos de tipo 'Medico' y 'Enfermero'.
var listaEmpleados = new List<Empleado>() {
    new Medico(){ nombre= "Jorge Casa" },
    new Enfermero(){ nombre = "Raul Blanco"}
};

// Filtramos la lista para obtener solo los objetos de tipo 'Medico' usando 'OfType'.
var medico = listaEmpleados.OfType<Medico>();

// Como sabemos que hay un único médico en la lista, utilizamos 'Single' para obtenerlo y mostramos su nombre.
Console.WriteLine(medico.Single().nombre);

#endregion
#region OrderBy

// Ordenamos la lista de habitantes por edad de menor a mayor usando 'OrderBy' y expresiones lambda.
var edadA = ListaHabitantes.OrderBy(x => x.Edad);

// Realizamos la misma operación pero usando LINQ, ordenando la lista de habitantes por edad.
var edadAC = from vt in ListaHabitantes orderby vt.Edad select vt;

// Iteramos sobre la lista ordenada y mostramos los datos de cada habitante.
foreach (var edad in edadAC)
{
    Console.WriteLine(edad.datosHabitante());
}

#endregion
#region OrderBYDescending()

// Ordenamos la lista de habitantes por edad de mayor a menor usando 'OrderByDescending'.
var listaEdad = ListaHabitantes.OrderByDescending(x => x.Edad);

// Iteramos sobre la lista ordenada y mostramos los datos de cada habitante.
foreach (Habitante h in listaEdad)
{
    Console.WriteLine(h.datosHabitante());
}

// Mostramos una línea separadora para distinguir los resultados.
Console.WriteLine("-------------------------------------------");

// Realizamos la misma operación pero usando LINQ, ordenando la lista de habitantes por edad en orden descendente.
var ListaEdad2 = from h in ListaHabitantes orderby h.Edad descending select h;

// Iteramos sobre la lista ordenada y mostramos los datos de cada habitante.
foreach (Habitante h in ListaEdad2)
{
    Console.WriteLine(h.datosHabitante());
}

#endregion
#region ThenBy
// Ordenamos la lista 'ListaHabitantes' primero por edad de menor a mayor y luego, dentro de cada grupo de edad, por nombre en orden alfabético ascendente.
// Creamos una colección llamada 'habitantes3' con este ordenamiento.
var habitantes3 = ListaHabitantes.OrderBy(x => x.Edad).ThenBy(x => x.Nombre);

// Utilizamos LINQ para realizar la misma ordenación: primero por edad y luego por nombre en orden alfabético.
// Creamos una colección llamada 'edadATA' con esta consulta.
var edadATA = from h in ListaHabitantes
              orderby h.Edad, h.Nombre
              select h;

// Iteramos sobre la colección 'edadATA' y mostramos los datos de cada habitante.
foreach (var h in edadATA)
{
    Console.WriteLine(h.datosHabitante());
}

// Imprimimos una línea separadora para distinguir los resultados.
Console.WriteLine("------------------");

#endregion
#region ThenByDescending

// Ordenamos la lista 'ListaHabitantes' primero por edad de menor a mayor y luego, dentro de cada grupo de edad, por nombre en orden alfabético descendente.
// Creamos una colección llamada 'habitantes4' con este ordenamiento.
var habitantes4 = ListaHabitantes.OrderBy(x => x.Edad).ThenByDescending(x => x.Nombre);

// Iteramos sobre la colección 'habitantes4' y mostramos los datos de cada habitante.
foreach (var h in habitantes4)
{
    Console.WriteLine(h.datosHabitante());
}

// Realizamos la misma operación utilizando LINQ: ordenamos primero por edad y luego por nombre en orden alfabético descendente.
// Creamos una colección llamada 'lista5' con esta consulta.
var lista5 = from h in ListaHabitantes
             orderby h.Edad, h.Nombre descending
             select h;

// Iteramos sobre la colección 'lista5' y mostramos los datos de cada habitante.
foreach (var h in lista5)
{
    Console.WriteLine(h.datosHabitante());
}
#endregion
