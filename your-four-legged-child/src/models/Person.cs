using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace your_four_legged_child.src.models
{
    /*
    TDA PERSONA

    - Propiedades
    Cadena de caracteres    nombre
    Cadena de caracteres    apellido
    Entero                  numIdentificación
    Cadena de caracteres    númeroTelefono //Es un string por tener en cuenta los guiones y espacios
    Cadena de caracteres    residencia

    - Métodos
                            Persona(nombre, apellido, numIdentificación, númeroTelefono, residencia)
    vacío                   ImprimirDetalles()
    */
    internal class Person
    {
        string name;
        string lastName;
        int idNumber;
        string phoneNumber;
        string residence;

        //constructor
        public Person(string _name, string _lastName, int _idNumber, string _phone, string _residence)
        {
            this.name = _name;
            this.lastName = _lastName;
            this.idNumber = _idNumber;
            this.phoneNumber = _phone;
            this.residence = _residence;
        }

        //getters
        public string GetName() => this.name;
        public string GetLastName() => this.lastName;
        public string GetFullName() => this.name + " " + this.lastName;
        public int GetIdNumber() => this.idNumber;
        public string GetPhoneNumber() => this.phoneNumber;
        public string GetResidence() => this.residence;

        /// <summary>
        /// Imprime la informacion basica de una persona
        /// </summary>
        public virtual void PrintDetails()
        {
            Console.WriteLine("Nombre: " + GetFullName());
            Console.WriteLine("Cedula: " + this.idNumber);
            Console.WriteLine("Telefono: " + this.phoneNumber);
            Console.WriteLine("Direccion: " + this.residence);
        }
    }
}
