using System;
using System.Collections.Generic;
using System.Text;

namespace Programa_incentivo_ahorro
{
    class Cliente
    {

        private string cedula;
        private int estrato;
        private int metaAhorro;
        private int consumoActual;


        public string Cedula { get => cedula; set => cedula = value; }
        public int Estrato { get => estrato; set => estrato = value; }
        public int MetaAhorro { get => metaAhorro; set => metaAhorro = value; }
        public int ConsumoActual { get => consumoActual; set => consumoActual = value; }
    }



}
