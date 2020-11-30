using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Text.RegularExpressions;

namespace CalculadoraTopicos
{
    public partial class FrmCalculadora : Form
    {
        string _acumulador = string.Empty;
        List<string> _listaAcumuladores = new List<string>();

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "0";
            txtPntll.Text = _acumulador;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "1";
            txtPntll.Text = _acumulador;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "2";
            txtPntll.Text = _acumulador;
        }


        private void btn3_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "3";
            txtPntll.Text = _acumulador;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "4";
            txtPntll.Text = _acumulador;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "5";
            txtPntll.Text = _acumulador;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "6";
            txtPntll.Text = _acumulador;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "7";
            txtPntll.Text = _acumulador;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "8";
            txtPntll.Text = _acumulador;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "9";
            txtPntll.Text = _acumulador;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtPntll.Clear();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "+";
            txtPntll.Text = _acumulador;

        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "-";
            txtPntll.Text = _acumulador;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "/";
            txtPntll.Text = _acumulador;
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "*";
            txtPntll.Text = _acumulador;
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + ".";
            txtPntll.Text = _acumulador;
        }

        private void btnParIzq_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "(";
            txtPntll.Text = _acumulador;
        }

        private void btnParDer_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + ")";
            txtPntll.Text = _acumulador;
        }

        private void btnElevar_Click(object sender, EventArgs e)
        {
            _acumulador = _acumulador + "^";
            txtPntll.Text = _acumulador;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            string igualar = ValidarParentesis(txtPntll.Text);
            
            String pattern = @"([-+]?)(\d+)\s?";

            if (Regex.IsMatch(igualar, pattern))
            {
                txtPntll.Text = igualar;
            }
            else
            {
                ValidarParentesis(igualar);
            }
        }

        public string Sumas_Restas(string sumarest)
        { 
            string pattern1 = @"([+-]?)(\d+)([+-])(\d+).?";
            string aux = "";
            Regex r1 = new Regex(pattern1, RegexOptions.IgnoreCase);
            Match m1 = r1.Match(sumarest);
            if (m1.Success)
            {
                for (int i = 1; i <= 4; i++)
                {
                    aux += m1.Groups[i].Value;
                }

                string resultado = "";
                int value1 = Convert.ToInt32(m1.Groups[2].Value);
                int value2 = Convert.ToInt32(m1.Groups[4].Value);

                switch (m1.Groups[3].Value)
                {
                    case "+":
                        if (value1 > value2 && m1.Groups[1].Value == "-")
                        {
                            resultado = "-" + (value1 - value2).ToString();
                            sumarest = sumarest.Replace(aux, resultado);
                        }
                        else if (value1 < value2 && m1.Groups[1].Value == "-")
                        {
                            resultado = (value2 - value1).ToString();
                            sumarest = sumarest.Replace(aux, resultado);
                        }
                        else if (value1 == value2 && m1.Groups[1].Value == "-")
                        {
                            resultado = "0";
                            sumarest = sumarest.Replace(aux, "");
                        }
                        else
                        {
                            resultado = (value1 + value2).ToString();
                            sumarest = sumarest.Replace(aux, resultado);
                        }

                        break;
                    case "-":
                        if (value1 > value2 && m1.Groups[1].Value != "-")
                        {
                            resultado = (value1 - value2).ToString();
                            sumarest = sumarest.Replace(aux, resultado);
                        }
                        else if (value1 < value2 && m1.Groups[1].Value != "-")
                        {
                            resultado = "-" + (value2 - value1).ToString();
                            sumarest = sumarest.Replace(aux, resultado);
                        }
                        else if (value1 == value2 && m1.Groups[1].Value != "-")
                        {
                            resultado = "0";
                            sumarest = sumarest.Replace(aux, "");
                        }
                        else
                        {
                            resultado = "-" + (value1 + value2).ToString();
                            sumarest = sumarest.Replace(aux, resultado);
                        }
                        break;
                }
                return sumarest;
            }
            else

                return sumarest;
        }
        public string correciones(string corregir)
        {
            if (corregir.Contains("-*-"))
            {
                corregir = corregir.Replace("-*-", "+");
            }
            if (corregir.Contains("-*+"))
            {
                corregir = corregir.Replace("-*+", "-");
            }
            if (corregir.Contains("**"))
            {
                corregir = corregir.Replace("**", "*");

            }
            if (corregir.Contains("+*"))
            {
                corregir = corregir.Replace("+*", "+");
            }
            if (corregir.StartsWith("*"))
            {
                corregir = corregir.Substring(1);
            }
            MessageBox.Show(corregir);
            return corregir;
        }
        public string multiplicar(string mul)
        {

            string mul_final = "";
            char[] caracteres = mul.ToCharArray();
            string pattern = @"([-+]?)(\d+)([*])([+-]?)(\d+)\s";

            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

            Match m = r.Match(mul);
            if (m.Success)
            {

                int value1 = Convert.ToInt32(m.Groups[2].Value);
                int value2 = Convert.ToInt32(m.Groups[5].Value);
                mul_final = (value1 * value2).ToString();
                if (m.Groups[1].Value != m.Groups[4].Value)
                {
                    mul_final = "-" + mul_final;
                    return mul_final;
                }
                return mul_final;
            }
            else
            {
                for (int i = 0; i < caracteres.Length; i++)
                {

                    if (caracteres[i] == '*')
                    {
                        int aux = i;
                        int contDer = 0;
                        int contIzq = 0;
                        string der = "";
                        string izq = "";
                        if (caracteres[i + 1] == '-')
                        {
                            mul_final += "-";
                            for (int v = i + 2; v < caracteres.Length; v++)
                            {
                                if (caracteres[v] != '-' || caracteres[v] != '+' || caracteres[v] != '/' || caracteres[v] != '*' || caracteres[v] != '^')
                                {
                                    der += caracteres[v];
                                    contDer++;
                                }
                                else
                                    break;

                            }
                            if (caracteres[i - 1] == '-')
                            {
                                mul_final = "";
                            }
                            for (int v = i; v < caracteres.Length && v >= 0; v--)
                            {
                                if (caracteres[v] != '-' || caracteres[v] != '+' || caracteres[v] != '/' || caracteres[v] != '*' || caracteres[v] != '^')
                                {
                                    izq += caracteres[v];
                                    contIzq++;
                                }
                                else
                                    break;
                            }
                            izq.Reverse();
                            aux = aux - contIzq;

                            int resultado = Convert.ToInt32(der) * Convert.ToInt32(izq);
                            for (int f = 0; f < aux; f++)
                            {
                                mul_final += caracteres[f];

                            }
                            mul_final += resultado.ToString();
                            for (int f = i + contDer; f < caracteres.Length; f++)
                            {
                                mul_final += caracteres[f];
                            }
                        }
                        //Derecha
                        else
                        {
                            for (int v = i + 1; v < caracteres.Length; v++)
                            {
                                if (caracteres[v] != '*')
                                {
                                    der += caracteres[v];
                                    contDer++;
                                }
                                else
                                    break;

                            }

                            for (int v = i - 1; v < caracteres.Length && v >= 0; v--)
                            {
                                if (caracteres[v] != '-' || caracteres[v] != '+' || caracteres[v] != '/' || caracteres[v] != '*' || caracteres[v] != '^')
                                {
                                    izq += caracteres[v];
                                    contIzq++;
                                }
                                else
                                    break;
                            }
                            char[] izqArr = izq.ToCharArray();
                            Array.Reverse(izqArr);
                            string auxstring = "";
                            foreach (var item in izqArr)
                            {
                                auxstring += item;

                            }
                            if (aux - contIzq != 0)
                            {
                                for (int y = 0; y < aux - contIzq; y++)
                                {
                                    mul_final += caracteres[y];
                                }

                            }
                            char[] derArray = der.ToCharArray();
                            int resultado;
                            if (derArray[0] == '-' && derArray[1] == '-')
                            {
                                resultado = Convert.ToInt32(derArray[2]) * Convert.ToInt32(auxstring);
                                mul_final += resultado;
                                for (int j = 3; j < derArray.Length; j++)
                                {
                                    mul_final += derArray[j];
                                }
                            }

                            else if (derArray[0] == '-')
                            {
                                resultado = Convert.ToInt32(derArray[1]) * Convert.ToInt32(auxstring);
                                mul_final += "-" + resultado;
                                for (int j = 2; j < derArray.Length; j++)
                                {
                                    mul_final += derArray[j];
                                }
                            }
                            ////////////////////////////////////////////////////
                            else
                            {
                                resultado = Convert.ToInt32(derArray[0].ToString()) * Convert.ToInt32(auxstring);
                                mul_final += resultado;
                                for (int j = 1; j < derArray.Length; j++)
                                {
                                    mul_final += derArray[j];
                                }
                            }


                            MessageBox.Show(mul_final);
                            if (mul_final.Contains("*"))
                            {
                                mul_final = multiplicar(mul_final);
                            }
                            return mul_final;
                        }
                        break;
                    }

                }
            }

            return mul_final;
        }
        public string operaciones(string operar)
        {
            String pattern = @"([-+]?)(\d+)([-+*/^])([-+]?)(\d+)\s?";

            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);


            Match m = r.Match(operar);
            if (m.Success)
            {
                string resultado = "";
                int value1 = Convert.ToInt32(m.Groups[2].Value);
                int value2 = Convert.ToInt32(m.Groups[5].Value);
                switch (m.Groups[3].Value)
                {
                    case "+":

                        if (value1 > value2 && m.Groups[1].Value == "-")
                        {
                            resultado = '-' + (value1 - value2).ToString();
                            operar = resultado;
                            break;
                        }
                        resultado = (value1 + value2).ToString();

                        operar = resultado;
                        MessageBox.Show(operar);
                        break;
                    case "-":
                        if (value2 > value1)
                        {
                            resultado = '-' + (value2 - value1).ToString();
                            MessageBox.Show(resultado.ToString());
                            operar = resultado;
                            break;
                        }
                        resultado = (value1 - value2).ToString();
                        operar = resultado;
                        break;
                    case "*":
                        if (value2 == 0 || value1 == 0)
                            resultado = "0";
                        if (value1 == 1)
                            resultado = value2.ToString();
                        if (value2 == 1)
                            resultado = value1.ToString();
                        resultado = (value1 * value2).ToString();
                        operar = resultado;
                        break;
                    case "/":
                        if (value2 == 1)
                        {
                            resultado = value1.ToString();
                        }
                        else if (value1 == 0 || value2 == 0)
                        {
                            MessageBox.Show("No puede dividirse entre 0", "Dato no admitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Application.Exit();
                        }
                        if (value1 < value2)
                        {
                            MessageBox.Show("No soporta division entre decimales", "Dato no admitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        resultado = (value1 / value2).ToString();
                        operar = resultado;
                        break;
                    case "^":
                        int auxiliar = value1;
                        for (int i = 1; i < value2; i++)
                        {
                            auxiliar = auxiliar * value1;
                        }
                        resultado = auxiliar.ToString();
                        operar = resultado;
                        break;
                }
            }
            return operar;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string resultado_final = ValidarParentesis(txtPntll.Text);
            resultado_final = correciones(resultado_final);
            if (resultado_final.Contains("*"))
            {
                resultado_final = multiplicar(resultado_final);
            }

            resultado_final = Sumas_Restas(resultado_final);

            MessageBox.Show(resultado_final.ToString());
        }
        public string ValidarParentesis(string Parentesis)
        {
            string acumular = "";

            if (Parentesis.Contains("("))
            {

                char[] delimitar = { '(' };

                string[] cadenas = Parentesis.Split(delimitar, 2);

                for (int i = 0; i < cadenas.Length; i++)
                {
                    if (cadenas[i] != "")
                    {

                        acumular += '*' + ValidarParentesis(cadenas[i]);
                    }
                }
            }
            else if (Parentesis.Contains(")"))
            {

                char[] delimitar = { ')' };

                string[] cadenas = Parentesis.Split(delimitar, 2);

                for (int v = 0; v < cadenas.Length; v++)
                {
                    if (cadenas[v] != "")
                    {
                        acumular += ValidarParentesis(cadenas[v]);
                    }
                }

                return acumular;
            }
            else
            {
                if (Parentesis.Contains("^") || Parentesis.Contains("/"))
                {
                    Parentesis = operaciones(Parentesis);
                }
                else if (Parentesis.Contains("*"))
                {
                    Parentesis = multiplicar(Parentesis);
                }
                else if (Parentesis.Contains("-") || Parentesis.Contains("+"))
                {
                    Parentesis = Sumas_Restas(Parentesis);
                }

                acumular += Parentesis.ToString();

                return acumular;
            }
            return acumular;
        }
    }
}
