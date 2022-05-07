using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio2
{
    public abstract class Curso
    {
        //atributos 
        private string _IDE;
        private string _Nombre;
        private int  _Duracion;
        private int _Precio;

        //propiedades

        public string IDE
        {
            set
            {
                if (value.Length == 6)
                    _IDE = value;

                else
                    throw new Exception("Error IDE-No se pueden tener + o - de 6 caracteres ");
            }
            get { return _IDE; }
        }

        public string Nombre
        {
            set
            {
                if (value.Length >= 3)
                    _Nombre = value;
                else
                    throw new Exception("Nombre minimo 3 letras ");
            }
            get { return _Nombre; }
        }
        public int Duracion
        {
            set
            {
                if ((value >= 4) && (value <= 156))
                    _Duracion = value;
                else if ((value < 4) && (value > 156))
                    throw new Exception("\nError\n \nDebe ser mayor a cuatro semanas\n \n Menor a 156\n");
            }
            get { return _Duracion; }
        }
         public int Precio

         {
             set {
                 if ((value >= 12000) && (value <= 250000))
                     _Precio = value;
                 else if ((value < 12000) || (value > 250000))
                     throw new Exception("\nError \nPrecio debe ser mayor a 12.000 $\n \n  Menor a 250.000 $ ");
             }
             get { return _Precio; }
         }
        
        //constructor completo

         public Curso(string pIDE, string pNombre, int pDuracion, int pPrecio)
         {
             IDE = pIDE;
             Nombre = pNombre;
             Duracion = pDuracion;
             Precio = pPrecio;
         }
        public bool Equals(Object obj)
         {
            bool verdadero = false;
        if (obj is Curso)
             {
                Curso aux = (Curso)obj;
                if (aux.IDE == _IDE)
                {
                    verdadero = true;
                }
             }
            return verdadero;
         }

        //operaciones 
         public  override string ToString()
         {
            Console.WriteLine("************************************************************************************************");
             return ("\nNOMBRE : " + " " + _Nombre + "\nIDE :" + " " + _IDE + " \nDURACION: " + " " + _Duracion + " -  SEMANAS " + " \nPRECIO  : " + " " + _Precio + " - Mil PESOS URUGUAYOS ");
         }



    }
}
