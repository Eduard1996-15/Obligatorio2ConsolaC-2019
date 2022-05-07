using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio2
{
   public class Alumno
    {
        
        //atributos
        private int _Cedula;
        private string _Nombre;
        private string  _Telefono;
        private string _Direcion;

        //propiedades
        public int Cedula
        {
            set
            {
                if ((value >= 1000000) || (value <= 10000000))
                    _Cedula = value;
                else
                    throw new Exception("Error_ debe tener  7 0 8 digitos la cedula ");

            }
            get { return _Cedula; }
        }

        public string Nombre
        {
          
            set
            {
                if (value.Trim().Length >= 3)
                    _Nombre = value;
                else
                    throw new Exception("Error_ debe tener  3 digitos ");
            }
            get { return _Nombre; }
        }

        public string Telefono
        {
            set
            {
                if ((value.Trim().Length >= 8) || (value.Trim().Length <= 9))
                    _Telefono = value;
                else
                    throw new Exception("Error_  debe tener  8 digitos 0  9");
            }
            get { return _Telefono; }
           
        }

        public string Direccion
        {
            set
            {
                if (value.Trim().Length >= 5)
                    _Direcion = value;
                else
                    throw new Exception("Error_   5 digitos la direccion ");
            }
            get { return _Direcion; }
        }

        //constructor completo
        public Alumno(int pCedula, string pNombre, string pTelefono, string pDirecion)
        {
            Cedula = pCedula;
            Nombre = pNombre;
            Telefono = pTelefono;
            Direccion = pDirecion;
        }

        public  bool  Equals(Object obj)
        {
            bool valido = false;
            if( obj is Alumno)
            {
                Alumno aux = (Alumno)obj;
                if (aux.Cedula == _Cedula)
                {
                    valido = true;
                }
            }
            return valido;
        }

        //operaciones

        public override string ToString()
        {
            Console.WriteLine("*********************************************************************************************");
            return (" \nNOMBRE :" + " " + _Nombre + "\nCEDULA : " + " " + _Cedula + "\nTELEFONO:" + " " + _Telefono + "\nDIRECCION :" + " " + _Direcion +"\n *********************************************************************************************");
        }
    }
}
