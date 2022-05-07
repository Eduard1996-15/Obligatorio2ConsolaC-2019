using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio2
{
    public class CursoEspecializado : Curso
    {
        //atributos 
        private string _PreRequisito;

        //propiedades 
        public string PreRequisitos
        {
            set
            {
                if (value.Trim().Length >= 8)
                    _PreRequisito = value;
                else
                    throw new Exception("Error minimo 8 cracteres ");
            }
            get { return _PreRequisito; }
        }

        //constructor 
        public CursoEspecializado(string pIDE, string pNomber, int pDuracion, int pPrecio, string pPreRequisitos)
            : base(pIDE, pNomber, pDuracion, pPrecio)
        {
            PreRequisitos = pPreRequisitos;
        }

        //operciones 
        public override string ToString()
        {
            return (base.ToString() + "\nLos PreRequisitos Son : \n" + _PreRequisito+ "\n**********************************************************************************************************");
        }
    }
}
