namespace Entidades
{
    public enum ESistema {Decimal,Binario};
    public class Numeracion
    {

        private ESistema sistema;
        private double valorNumerico;

        public ESistema Sistema
        {
            get
            {
                return sistema;
            }
        }

        public string Valor
        {
            get { return this.valorNumerico.ToString(); }
        }


        public Numeracion(double valor, ESistema sistema)
        {
            InicializarValores(valor.ToString(), sistema);
        }

        public Numeracion(string valor, ESistema sistema)
        {
            InicializarValores(valor, sistema);
        }

        private void InicializarValores(string valor, ESistema sistema)
        {
            this.sistema = sistema;
            double strToDouble;

            if(valor != String.Empty && this.EsBinario(valor))
            {
                this.valorNumerico = this.BinarioADecimal(valor);
            }
            else if(double.TryParse(valor, out strToDouble))
            {
                this.valorNumerico = Math.Abs(strToDouble);
            }
            else
            {
                this.valorNumerico = double.MinValue;
            }
        }


        public static Numeracion operator +(Numeracion n1, Numeracion n2)
        {
            return new Numeracion((n1.valorNumerico + n2.valorNumerico), n1.sistema);
        }

        public static Numeracion operator -(Numeracion n1, Numeracion n2)
        {
            return new Numeracion((n1.valorNumerico - n2.valorNumerico), n1.sistema);
        }

        public static Numeracion operator *(Numeracion n1, Numeracion n2)
        {
            return new Numeracion((n1.valorNumerico * n2.valorNumerico), n1.sistema);
        }

        public static Numeracion operator /(Numeracion n1, Numeracion n2)
        {
            return new Numeracion((n1.valorNumerico / n2.valorNumerico), n1.sistema);
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            return (n1.sistema == n2.sistema);
        }
        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }

        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            return (sistema == numeracion.sistema);
        }

        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            return !(sistema == numeracion);
        }

        private bool EsBinario(string valor)
        {
            foreach(char c in valor)
            {
                if(c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        public string ConvertirA(ESistema sistema)
        {
            if((int)sistema == (int)ESistema.Decimal)
            {
                return $"{this.valorNumerico}";
            }
            else
            {
                return $"{this.DecimalABinario((int)this.valorNumerico)}";
            }
        }

        private double BinarioADecimal(string valor)
        {
            if (valor != String.Empty && this.EsBinario(valor))
            {
                return Math.Abs(Convert.ToDouble(valor));
            }
            return 0;
        }

        /*
        Ambas opciones del método DecimalBinario convertirán un número 
        decimal a binario, en caso de ser posible.Caso contrario retornará 
        "Numero inválido". Reutilizar código
        */
        private string DecimalABinario(int valor)
        {
            string bin = Convert.ToString(valor, 2);
            return this.DecimalABinario(bin);
        }

        private string DecimalABinario(string valor)
        {
            if (this.EsBinario(valor))
            {
                return valor;
            }
            return "Numero inválido";
        }
    }
}