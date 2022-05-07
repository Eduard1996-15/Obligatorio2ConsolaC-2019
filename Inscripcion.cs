using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio2
{
    public class Inscripcion
    {
        //atributos 

        private int _NumInscripcion;
        private DateTime _Fecha;
        private static int ultimoId = 100;
        private Alumno _Alumno;
        private Curso _Curso;
        private string _Empleado;
        //Propiedades

        public string Empleado
        {
            get { return _Empleado; }
            set
            {
                if (value.Trim().Length >= 3)
                    _Empleado = value;
                else
                    throw new Exception("Error debe se mayor a 3 digitos ");
            }


        }
        public Alumno Alumno
        {
            set
            {
                _Alumno = value;
            }
            get { return _Alumno; }
        }

        public Curso Curso
        {
            set
            {
                _Curso = value;
            }
            get { return _Curso; }
        }

        public int NumInscripcion
        {
            set
            { 
                _NumInscripcion = value;
            }
            get { return _NumInscripcion; }
        }

        public DateTime Fecha
        {
            set
            {

                if (value <= DateTime.Now)
                    _Fecha = value;
               
                
            }
            get { return _Fecha; }
        }

        //constructor

        public Inscripcion(Alumno pAlumno,Curso pCurso, string pEmpleado)
        {
            Empleado = pEmpleado;
            NumInscripcion = ultimoId;
            ultimoId++;
            Fecha = DateTime.Now;
            _Alumno = pAlumno;
            _Curso = pCurso;
        }

        //operaciones 
        public override string ToString()
        {
            return ("\n CURSO :" + " " + _Curso + "\n \n  ALUMNO : " + " " + _Alumno + "\nNUMERO DE INSCRICION :" + " " + _NumInscripcion + " \nFECHA :" + " " + _Fecha + "\n EMPLEADO QUE INSCRIBE  :" + " " + Empleado);
        }    
    }
}
