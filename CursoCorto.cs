using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio2
{
    public class CursoCorto : Curso
    {
        //atributos
        private string _AreaAplicacion;

        //Propiedades

        public string AreaAplicacion
        {
            set { _AreaAplicacion = value;}
            get { return _AreaAplicacion; }
        }
        //Contructor por defecto
        
        //constructor 
        public CursoCorto(string pIDE, string pNomber, int pDuracion, int pPrecio, string pAreaAplicacon)
            : base(pIDE, pNomber, pDuracion, pPrecio)
        {
            AreaAplicacion = pAreaAplicacon;
        }

        //operaciones 
        public override string ToString()
        {
            return (base.ToString() + "\nAREA DE APLICACION :" + _AreaAplicacion + "\n*********************************************************************************************");
        }
    }
}
