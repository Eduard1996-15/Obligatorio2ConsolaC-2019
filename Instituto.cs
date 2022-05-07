using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio2
{
    public class Instituto
    {
        //atributos
        private List<Alumno> _listadoAlumnos;
        private List<Curso> _listadoCurso;
        private List<Inscripcion> _listadoInscripcion;

        //contructor
        public Instituto()
        {
            _listadoCurso = new List<Curso>();
            _listadoAlumnos = new List<Alumno>();
            _listadoInscripcion = new List<Inscripcion>();

        }
        //metodos
        public void Agregar(Alumno pAlumno)
        {
            if (!_listadoAlumnos.Contains(pAlumno))//veo si ya no hay un alumno dentro de la lista 
                _listadoAlumnos.Add(pAlumno);//si no hay le agrego 
            else
                throw new Exception("Cedula ya esta Registrada ");//si hya mando un mje
        }

        public void Agregar(Curso curso)
        {
            if (!_listadoCurso.Contains(curso))
                _listadoCurso.Add(curso);
            else
                throw new Exception(" IDE ya esta Regsitrado ");

        }

        public void Agregar(Inscripcion inscripcion)
        {
            for (int i = 0; i < _listadoInscripcion.Count; i++)
            {
                Inscripcion aux = _listadoInscripcion[i];
                if (aux.Alumno.Cedula.Equals(inscripcion.Alumno.Cedula))
                    throw new Exception("Error, ya estaba registrado");
            }
            _listadoInscripcion.Add(inscripcion);
        }

        public Alumno Buscar(int Cedula)
        {

            foreach (Alumno alumno in _listadoAlumnos)
            {
                if (alumno.Cedula == Cedula)
                    return alumno;

            }
            return null;

        }

        public bool Eliminar(int Cedula)
        {
            foreach (Alumno alumno in _listadoAlumnos)
            {
                if (alumno.Cedula == Cedula)
                {
                    _listadoAlumnos.Remove(alumno);
                    return true;
                }

            }
            return false;
        }

        public void Modificar(Alumno Alumno)
        {
            if (Eliminar(Alumno.Cedula))
                Agregar(Alumno);
        }

        public bool HayAlumnos()
        {
            return _listadoAlumnos.Count > 0;
        }

        public bool HayCursos()
        {
            return _listadoCurso.Count > 0;
        }



        public CursoEspecializado BuscarCursoEsp(string IDE)
        {

            foreach (Curso uncursoEsp in _listadoCurso)
            {
                if (uncursoEsp.IDE == IDE)
                    return (CursoEspecializado)uncursoEsp;

            }
            return null;

        }

        public Curso BuscarCurso(string IDE)
        {

            foreach (Curso uncursoEsp in _listadoCurso)
            {
                if (uncursoEsp.IDE == IDE)
                    return uncursoEsp;

            }
            return null;

        }


        public CursoCorto BuscarCursoCorto(string IDE)
        {

            foreach (Curso uncurso in _listadoCurso)
            {
                if (uncurso.IDE == IDE)
                    return (CursoCorto)uncurso;

            }
            return null;

        }
        //propiedades
        public List<Inscripcion> ListadoInscripcion
        {
            get
            { return _listadoInscripcion; }
            set
            {
                _listadoInscripcion = value;
            }
        }

        public List<Curso> ListadoEspecializado
        {
            get
            {
                List<Curso> aux = new List<Curso>();
                for (int f = 0; f < _listadoCurso.Count; f++)
                {
                    Curso curso = _listadoCurso[f];
                    if (curso is CursoEspecializado)
                        aux.Add(curso);

                }
                return aux;
            }
        }

        public List<Curso> ListadoCorto
        {
            get
            {
                List<Curso> aux = new List<Curso>();
                for (int i = 0; i < _listadoCurso.Count; i++)
                {
                    Curso curso = _listadoCurso[i];
                    if (curso is CursoCorto)
                        aux.Add(curso);

                }
                return aux;
            }

        }

        public List<Curso> ListadoCurso
        {
            get
            {
                List<Curso> aux = new List<Curso>();
                for (int i = 0; i < _listadoCurso.Count; i++)
                {
                    Curso curso = _listadoCurso[i];
                    if (curso is Curso)
                        aux.Add(curso);

                }
                return aux;
            }

        }

        public List<Inscripcion> ListarInscripcion(Curso curso)
        {
            List<Inscripcion> aux = new List<Inscripcion>();
            foreach (Inscripcion inscripcion in _listadoInscripcion)
            {
                if (inscripcion.Curso.IDE == curso.IDE)
                    aux.Add(inscripcion);
            }
            return aux;
        }

        public List<Alumno> ListadoAlumnos(int cedula)
        {

            List<Alumno> auxi = new List<Alumno>();
            foreach (Alumno Alumno in _listadoAlumnos)
            {

                if (Alumno.Cedula == cedula)
                    auxi.Add(Alumno);

            }
            return auxi;
        }

    }
}

