using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraTopicos
{
    class OperacionesAritmeticas
    {
        public decimal Suma(decimal Operando1, decimal Operando2)
        {
            Exception _exception = null;
            decimal resultado = 0;
            try
            {
                resultado = Operando1 + Operando2;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
            finally
            {
                if (_exception != null)
                    throw new Exception("Error de sintaxis, favor de corregir");
            }
            return resultado;
        }
        public decimal Resta(decimal Operando1, decimal Operando2)
        {
            Exception _exception = null;
            decimal resultado = 0;
            try
            {
                resultado = Operando1 - Operando2;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
            finally
            {
                if (_exception != null)
                    throw new Exception("Error de sintaxis, favor de corregir");
            }
            return resultado;
        }
        public int Multiplicacion(int Operando1, int Operando2)
        {
            if (Operando2 == 0 || Operando1 == 0)
                return 0;
            if (Operando1 == 1)
                return Operando2;
            if (Operando2 == 1)
                return Operando1;
            else
            {
                return Operando1 + Multiplicacion(Operando1, --Operando2);
            }
        }
        public int Division(int Operando1, int Operando2)
        {
            if (Operando2 == 1)
                return Operando1;
            if (Operando2 == 0 || Operando1 == 0)
                throw new Exception("No puede dividirse entre 0");
            if (Operando1 < Operando2)
                throw new Exception("No soporta division entre decimales");
            else
                return 1 + Division(Operando1 - Operando2, Operando2);
        }
        public int factorial(int Operando1)
        {
            if (Operando1 == 0)
                return 1;
            if (Operando1 == 1)
                return 1;
            else
            {
                return Operando1 * factorial(Operando1 - 1);
            }
        }
        public int Potencia(int Operando1, int Operando2)
        {
            int auxiliar = Operando1;
            for (int i = 1; i <= Operando2 - 1; i++)
                auxiliar = auxiliar * Operando1;
            return auxiliar;
        }
        public string Parentesis(string Cadena)
        {
            return "";
        }
        public void MetodoPruebaParentesis()
        {
            string _operacion = "1+5*(3-2-(25-1+3-8))";
            if (_operacion.Contains('('))
            {
                var _cadena = _operacion.ToCharArray().ToList();
                int _aux = 0, _aux2 = 0;
                for (int _i = _cadena.Count() - 1; _i > 0; _i--)
                {
                    if (_cadena[_i] == ')')
                        _aux = _i;
                    if (_cadena[_i] == '(')
                        if (_aux2 < _i)
                        {
                            _aux2 = _i;
                            break;
                        }
                }
                var _cadenaInterna = _operacion.Substring(_aux2 + 1, _aux - _aux2 - 1);
                _operacion = EvaluacionOperadores(_operacion, _cadenaInterna).ToString();
            }
        }
        private decimal EvaluacionOperadores(string _operacion, string _cadenaInterna,
        char Operador = '-')
        {
            decimal resultado = 0;
            
            var listaOperandos = _cadenaInterna.Split(Operador);
            int i = 0;
            foreach (string cadena in listaOperandos)
            {
                if (cadena.Contains('+'))
                {
                    resultado = EvaluacionOperadores(_operacion, cadena, '+');
                    _cadenaInterna = _cadenaInterna.Replace(cadena, resultado.ToString());
                    listaOperandos[i] = resultado.ToString();
                }
                i++;
            }
            if (_cadenaInterna.Contains("-"))
            {
                resultado = CicloResta(listaOperandos);
            }
            if (_cadenaInterna.Contains("+"))
            {
                resultado = CicloSuma(listaOperandos);
            }
            if (_cadenaInterna.Contains("*"))
            {
            }
            return resultado;
        }
        public decimal CicloResta(string[] listaOperandos)
        {
            decimal resultado = Convert.ToDecimal(listaOperandos[0]);
            for (int i = 1; i < listaOperandos.Count(); i++)
            {
                resultado = Resta(resultado,
                Convert.ToDecimal(listaOperandos[i]));
            }
            return resultado;
        }
        public decimal CicloSuma(string[] listaOperandos)
        {
            decimal resultado = Convert.ToDecimal(listaOperandos[0]);
            for (int i = 1; i < listaOperandos.Count(); i++)
            {
                resultado = Suma(resultado,
                Convert.ToDecimal(listaOperandos[i]));
            }
            return resultado;
        }
        public List<string> Parentesis(List<string> Cadena)
        {
            return new List<string>();
        }
    }
}
