using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Instituto instituto = new Instituto();
            Menu();
            Console.Clear();
        }
        //Menu
        public static void Menu()
        {
            bool SigoEjecutando = true;
            string OpcionMenu = "";
            Instituto instituto = new Instituto();
            while (SigoEjecutando)
            {
                Console.Clear();
                Console.WriteLine("\n********** INSTITUTO *********\n   ");
                Console.WriteLine(" 1-     MANTENIMIENTO ALUMNO         ");
                Console.WriteLine(" 2-     AGREGAR CURSO CORTO          ");
                Console.WriteLine(" 3-     AGREGAR CURSO ESPECIALIZACION");
                Console.WriteLine(" 4-     INSCRIPCION A CURSOS         ");
                Console.WriteLine(" 5-     LISTADO DE CURSOS            ");
                Console.WriteLine(" 6-     LISTADO DE INSCRIPCIONES     ");
                Console.WriteLine(" 0-              SALIR               ");

                OpcionMenu = Console.ReadLine();

                switch (OpcionMenu)
                {
                    case "1":
                        {
                            MantenimientoAlumno(instituto);
                            break;
                        }
                    case "2":
                        {
                            //AgreCursoCorto();
                            AltaCursoCorto(instituto);
                            break;
                        }
                    case "3":
                        {
                            //AgreCursoEspecializado();
                            AltaCursoEspecializado(instituto);
                            break;
                        }
                    case "4":
                        {

                            InscripcionCursos(instituto);

                            break;
                        }
                    case "5":
                        {
                            ListadeCursos(instituto);
                            break;
                        }
                    case "6":
                        {
                            ListaInscripciones(instituto);
                            break;
                        }
                    case "0":
                        {
                            SigoEjecutando = false;
                            Console.Clear();
                            Console.WriteLine("GRACIAS POR USAR EL PROGRAMA !!!! ");
                            Console.ReadLine();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("ERROR- Ingrese opcion del 1 al 6");
                            Console.ReadLine();
                            break;
                        }
                }
            }
        }

        public static void InscripcionCursos(Instituto instituto)
        {


            if (instituto.HayAlumnos())
            {
                if (instituto.HayCursos())
                {
                    try
                    {
                        Console.WriteLine("Ingrese la cedula");
                        int cedula = Convert.ToInt32(Console.ReadLine());
                        Alumno alumno = instituto.Buscar(cedula);

                        if (alumno == null)
                        {
                            Console.WriteLine("No hay nadie registrado con la cedula " + cedula);
                            Console.ReadLine();
                        }


                        else
                        {


                            List<Alumno> ListaA = instituto.ListadoAlumnos(cedula);
                            Console.WriteLine(" ALUMNO  :  ");


                            foreach (Alumno Alumno in ListaA)
                            {
                                Console.WriteLine(Alumno);
                            }
                            Console.ReadLine();
                            Console.WriteLine("Que curso desea inscribirse :");
                            Console.WriteLine("1 - Corto");
                            Console.WriteLine("2 - Especializacion");
                            int tipo = Convert.ToInt32(Console.ReadLine());
                            while (tipo != 1 && tipo != 2)
                            {
                                Console.WriteLine("Opcion desconocida");
                                Console.ReadLine();
                            }
                            List<Curso> lista;
                            if (tipo == 1)
                                lista = instituto.ListadoCorto;
                            else
                                lista = instituto.ListadoEspecializado;

                            if (lista.Count == 0)
                            {
                                Console.WriteLine("No hay curso de este tipo");
                                Console.ReadLine();
                            }
                            else
                            {

                                for (int i = 1; i <= lista.Count; i++)
                                {
                                    Curso curso = lista[i - 1];
                                    Console.WriteLine(i + " - " + curso.Nombre);
                                }

                                int opcion = Convert.ToInt32(Console.ReadLine()) - 1;
                                while (opcion < 0 || opcion > lista.Count)
                                {
                                    Console.WriteLine("Opcion desconocida, es entre 1 a " + lista.Count);
                                    opcion = Convert.ToInt32(Console.ReadLine()) - 1;

                                }
                                Console.WriteLine("Ingrese Nombre de Empleado :");
                                string Emp = Console.ReadLine();

                                Curso aux = lista[opcion];

                                Inscripcion inscripcion = new Inscripcion(alumno, aux, Emp);

                                instituto.Agregar(inscripcion);

                                Console.WriteLine("Se registro la inscripcion correctamente");
                                Console.ReadLine();

                            }

                        }


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("No hay curso, hay que registrar primero");
                    Console.ReadLine();
                }
            }

            else
            {
                Console.WriteLine("No hay alumnos, hay que registrar primero");
                Console.ReadLine();
            }
        }

        public static void MantenimientoAlumno(Instituto instituto)
        {

            try
            {

                Console.Write("Ingrese Cedula ");
                int Cedula = Convert.ToInt32(Console.ReadLine());
                if (instituto.Buscar(Cedula) == null)
                {

                    Console.WriteLine("No existe la cedula");
                    Console.WriteLine("Desea dar de alta?\n 1- Si\n2 - No\n");
                    int decidio = Convert.ToInt32(Console.ReadLine());
                    while (decidio != 1 && decidio != 2)
                    {
                        Console.WriteLine("Opcion desconocida");
                        Console.WriteLine("Desea dar de alta?\n 1-  Si\n 2-  No\n");
                        decidio = Convert.ToInt32(Console.ReadLine());
                    }
                    if (decidio == 1)
                        AltaAlumno(instituto, Cedula);
                }
                else
                {
                    Console.WriteLine("\n El nunmero de C.I: " + Cedula + " " + "fue encontrado \n");
                    Console.WriteLine(" \nTiene 3 Opciones \n");
                    Console.WriteLine(" \n 1-    Modificar\n  \n 2-    Eliminar\n");
                    Console.WriteLine(" \n 0-    Salir ");
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine();
                            Console.Clear();
                            break;
                        case 1:
                            ModificarAlumno(instituto, Cedula);
                            break;
                        case 2:
                            BajaAlumno(instituto, Cedula);
                            break;
                        default:
                            Console.WriteLine("Opcion desconocida");
                            Console.ReadLine();
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
        public static void AltaCursoEspecializado(Instituto instituto)
        {

            try
            {

                Console.WriteLine("Ingrese IDE :");
                string IDE = Console.ReadLine();


                if (IsLetters(IDE) == true)
                {

                    Console.WriteLine("IDE ingresado corectamente");
                }
                else
                {
                    Console.WriteLine("Error solo se aceptan letras ");
                    Console.ReadLine();
                    return;
                }
                Console.ReadLine();

                if (instituto.BuscarCursoEsp(IDE) != null)
                {
                    Console.WriteLine("Error - ya existe un curso con dicho IDE");

                }

                else
                {

                    Console.Write("Ingrese Nombre :");
                    string nombre = Console.ReadLine();

                    Console.Write("Ingrese duracion de curso :");
                    int duracion = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese Precio :");
                    int precio = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese Prerrequisitos Pra el curso : ");
                    string prerequisito = Console.ReadLine();


                    CursoEspecializado cursoEspecializado = new CursoEspecializado(IDE, nombre, duracion, precio, prerequisito);
                    instituto.Agregar(cursoEspecializado);
                    Console.WriteLine("Se ingreso correctamente : \n" + cursoEspecializado);
                    Console.ReadLine();

                }
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        public static void AltaCursoCorto(Instituto instituto)
        {
            try
            {
                Console.WriteLine("Ingrese IDE :");
                string IDE = Console.ReadLine();
                if (IsLetters(IDE) == true && IDE.Length == 6)
                {
                    Console.WriteLine("IDE ingresado - correcto");

                }
                else
                {
                    Console.WriteLine("Error solo se aceptan letras \n * y debe ser igual a 6 caracteres ");
                    Console.ReadLine();
                    return;
                }
                Console.ReadLine();

                if (instituto.BuscarCurso(IDE) != null)
                {
                    Console.WriteLine("Error - ya existe un curso con dicho IDE");
                    Console.ReadLine();
                }
                else
                {

                    Console.Write("Ingrese Nombre :");
                    string nombre = Console.ReadLine();

                    Console.Write("Ingrese duracion de curso en semanas :");
                    int duracion = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese Precio :");
                    int precio = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese Area que Desea Realizar ");
                    Console.WriteLine("1 - Programacion");
                    Console.WriteLine("2 - Economia");
                    Console.WriteLine("3 - Diseño");
                    int areaAplicacion = Convert.ToInt32(Console.ReadLine());
                    while (areaAplicacion < 1 || areaAplicacion > 3)
                    {
                        Console.WriteLine("Error debe elejir area de 1 a 3 ");
                        areaAplicacion = Convert.ToInt32(Console.ReadLine());
                    }

                    String area = "";
                    switch (areaAplicacion)
                    {
                        case 1:
                            area = "Programacion";
                            break;
                        case 2:
                            area = "Economia";
                            break;
                        default:
                            area = "Diseño";
                            break;

                    }
                    Console.Clear();

                    CursoCorto cursoCorto = new CursoCorto(IDE, nombre, duracion, precio, area);
                    instituto.Agregar(cursoCorto);
                    Console.WriteLine("\nSe ingreso correctamente el curso : \n" + cursoCorto);
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        public static void AltaAlumno(Instituto instituto, int cedula)
        {
            try
            {


                Console.Write("Ingrese Nombre :");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese Telefono :");
                string telefono = Console.ReadLine();

                Console.Write("Ingrese Direccion :");
                string direcion = Console.ReadLine();

                Alumno Alumno = new Alumno(cedula, nombre, telefono, direcion);
                instituto.Agregar(Alumno);
                Console.WriteLine("Se ingreso correctamente ");
                Console.Clear();
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }


        public static void ModificarAlumno(Instituto instituto, int cedula)
        {
            try
            {
                Console.Write("Ingrese un nuevo Nombre :");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese un nuevo Telefono :");
                string telefono = Console.ReadLine();

                Console.Write("Ingrese un nueva Direccion :");
                string direcion = Console.ReadLine();

                Alumno Alumno = new Alumno(cedula, nombre, telefono, direcion);
                instituto.Modificar(Alumno);
                Console.WriteLine("Se modifico correctamente ");
                Console.ReadLine();


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        public static void BajaAlumno(Instituto instituto, int cedula)
        {

            try
            {

                if (instituto.Eliminar(cedula))
                {
                    Console.WriteLine("\nSe Elimino el alumno " + cedula);
                    Console.ReadLine();
                }
                else
                    Console.WriteLine("No existe la cedula ");
                Console.ReadLine();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }

        public static void ListadeCursos(Instituto instituto)
        {

            Console.WriteLine(" LISTAS DE CURSOS  CORTOS ");
            Console.ReadLine();
            List<Curso> listaC;
            //listaC.Sort((p, q) => string.Compare(p.IDE, q.IDE));

            listaC = instituto.ListadoCorto;
            listaC = listaC.OrderBy(l => l.IDE).ToList();

            if (listaC.Count == 0)
            {
                Console.WriteLine("no hay cursos cortos para mostrar");
                Console.ReadLine();
            }
            else
            {

                for (int i = 0; i < listaC.Count; i++)
                {
                    Console.WriteLine(listaC[i]);
                    Console.ReadLine();
                }
            }
            Console.WriteLine("\nLISTADO CURSOS ESPECIALIZADOS  \n ");
            List<Curso> listaEs;

            listaEs = instituto.ListadoEspecializado;
            listaEs = listaEs.OrderBy(l => l.IDE).ToList();
            if (listaEs.Count == 0)
            {
                Console.WriteLine("no hay cursos especializados para mostrar");
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < listaEs.Count; i++)
                {
                    Console.WriteLine(listaEs[i]);
                    Console.ReadLine();
                }
            }
            Console.Clear();

            List<Inscripcion> ToInscripcion = new List<Inscripcion>();
            ToInscripcion = instituto.ListadoInscripcion;
            int ToIns = ToInscripcion.Count();

            Console.WriteLine("El total de Inscripciones es : " + ToIns);
            Console.ReadLine();
        }
        public static void ListaInscripciones(Instituto instituto)
        {
            try
            {
                Console.WriteLine("Ingrese IDE del curso que desea ver:");
                string IDE = Console.ReadLine();
                Curso curso = instituto.BuscarCurso(IDE);

                if (curso == null)
                {
                    Console.WriteLine("Error - no existe un curso con dicho IDE");
                    Console.ReadLine();
                }
                else
                {
                    List<Inscripcion> ListaI = instituto.ListarInscripcion(curso);
                    Console.WriteLine(" LISTAS DE INSCRIPCIONES ");


                    foreach (Inscripcion inscripcion in ListaI)
                    {
                        Console.WriteLine(inscripcion.ToString());

                    }
                    Console.ReadLine();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();


            }
        }
        public static bool IsLetters(string IDE)//funcion que verifica si tiene letras 
        {

            foreach (char ch in IDE)//un char en el ide
            {
                if (!char.IsLetter(ch) && ch != 32)//si no hay una letra
                {
                    return false;//si hay una letra retorno false
                }
            }
            return true;//si no retorno true
        }


    }

}

