﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

        public Numeracion PrimerOperando
        {
            get { return this.primerOperando; } 
            set { this.primerOperando = value; }
        }

        public Numeracion SegundoOperando
        {
            get { return this.segundoOperando; }
            set { this.segundoOperando = value; }
        }

        public Operacion(Numeracion primerOperando, Numeracion segundoOperando)
        {
            this.primerOperando = primerOperando;
            this.segundoOperando = segundoOperando;
        }

        public Numeracion Operar(char operador)
        {
            Numeracion num = new Numeracion(0, this.primerOperando.Sistema);
            switch (operador)
            { // (+, -,*, /)
                case '-':
                    return num = this.primerOperando - this.segundoOperando;
                case '*':
                    return num = this.primerOperando * this.segundoOperando;
                case '/':
                    return num = this.primerOperando / this.segundoOperando;
                default:
                    return num = this.primerOperando + this.segundoOperando;
            }
        }
    }
}
