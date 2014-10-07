using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _VoluntariosLN : _Voluntarios
    {
        public _VoluntariosLN()
        { 
            this.idVoluntarios = 0;
            this.nombres = "";
            this.apellidos = "";
            this.telefono = "";
            this.direccion = "";
            this.correo = "";
            this.activo = true;
            this.personaEmergencia = "";
            this.telefonoEmergencia = "";
            this.municipio = 0;
            this.departamento = 0;
            this._errores = new List<Error>();
        }

        public _VoluntariosLN(string nombres, string apellidos, string telefon, string direccion, string correo, bool activo, int departamento, int municipio, string personaEm, string telefonoEm)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefon;
            this.direccion = direccion;
            this.correo = correo;
            this.activo = activo;
            this.municipio = municipio;
            this.departamento = departamento;
            this.personaEmergencia = personaEm;
            this.telefonoEmergencia = telefonoEm;

            this._errores = new List<Error>();
        
        }
        public Boolean Ingresar_V()
        {
            Boolean _correcto = true;
            _Voluntarios _voluntario = new _Voluntarios(0,nombres, apellidos, telefono, direccion, correo, activo, municipio, departamento, personaEmergencia, telefonoEmergencia);
            this.idVoluntarios = _voluntario.idVoluntarios;
            this.nombres = _voluntario.nombres;
            this.apellidos = _voluntario.apellidos;
            this.telefono = _voluntario.telefono;
            this.direccion = _voluntario.direccion;
            this.correo = _voluntario.correo;
            this.activo = _voluntario.activo;
            this.personaEmergencia = _voluntario.personaEmergencia;
            this.telefonoEmergencia = _voluntario.telefonoEmergencia;
            this.municipio = _voluntario.municipio;
            this.departamento = _voluntario.departamento;
            
            this._errores = _voluntario._errores;

            if (_errores.Count > 0)
            {
                _correcto = false;
            }
            return _correcto;
        }

        public string _obtenerError()
        {
            Error error = _errores[0];
            return error.mensaje;
        }
    }
}
