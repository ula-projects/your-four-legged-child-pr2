using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace your_four_legged_child.src.models
{
	/*
    TDA CLIENTE (-> Hereda de PERSONA)

    - Propiedades
    Booleano    contribuyenteEspecial

    - Métodos
    vacío       ImprimirDetalles() [sobreescrito]
    */
	internal class Client : Person
    {
        bool specialTaxpayer;

        public Client(string _name, string _lastName, int _idNumber, string _phone, string _residence, bool _specialTaxpayer) : base(_name, _lastName, _idNumber, _phone, _residence)
        {
            this.specialTaxpayer = _specialTaxpayer;
        }

        public bool GetSpecialTaxpayer() => this.specialTaxpayer;

        public override void PrintDetails()
        {
            base.PrintDetails();
            string specialTaxpayerText = this.specialTaxpayer ? "Si" : "No";
            Console.WriteLine("Contribuyente Especial: " + specialTaxpayerText);
        }
    }
}
