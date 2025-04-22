using System;
using System.Text;
using Xamarin.Forms;

namespace LogicaInteractiva
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAgeCheckClicked(object sender, EventArgs e)
        {
            if (int.TryParse(AgeEntry.Text, out int edad))
            {
                string resultado;
                if (edad >= 18)
                {
                    resultado = $"Con {edad} años, eres MAYOR de edad. ✅";
                }
                else if (edad >= 0)
                {
                    resultado = $"Con {edad} años, eres MENOR de edad. ❌";
                }
                else
                {
                    resultado = "La edad no puede ser negativa.";
                }
                ResultLabel.Text = "Resultado (If/Else):\n" + resultado;
            }
            else
            {
                ResultLabel.Text = "Error: Por favor, introduce una edad numérica válida.";
            }
        }

        private void OnSumPrimesWhileClicked(object sender, EventArgs e)
        {
            if (int.TryParse(LimitEntry.Text, out int limiteSuperior))
            {
                if (limiteSuperior < 2)
                {
                    ResultLabel.Text = $"No hay números primos menores que 2. Introduce un límite mayor o igual a 2.";
                    return;
                }
                long sumaDePrimos = 0;
                int numeroActual = 2;
                StringBuilder logSuma = new StringBuilder(); // Para mostrar qué números se suman

                // Bucle While para calcular la suma
                while (numeroActual <= limiteSuperior)
                {
                    if (IsPrime(numeroActual))
                    {
                        sumaDePrimos += numeroActual;
                        logSuma.Append($"{numeroActual} + "); // Construye el log visual
                    }
                    numeroActual++;
                }

                // Construcción del Mensaje de Resultado Final
                StringBuilder finalResult = new StringBuilder();
                finalResult.AppendLine($"Suma de Primos hasta {limiteSuperior} (While):"); // Encabezado
                if (logSuma.Length > 0)
                {
                    logSuma.Length -= 3; // Quita el último " + " del log
                    finalResult.AppendLine("Números primos sumados:");
                    finalResult.AppendLine(logSuma.ToString()); // Muestra los números
                    finalResult.AppendLine("-----------------------"); // Separador visual
                    finalResult.AppendLine($"✅ SUMA TOTAL = {sumaDePrimos}"); // Muestra la suma total claramente
                }
                else
                {
                    // Si no se añadieron primos (aunque con limite >= 2 siempre habrá al menos el 2)
                    finalResult.AppendLine("No se encontraron primos en el rango especificado para sumar.");
                    finalResult.AppendLine("-----------------------");
                    finalResult.AppendLine($"✅ SUMA TOTAL = 0");
                }
                ResultLabel.Text = finalResult.ToString(); // Asigna el resultado final al Label
            }
            else
            {
                ResultLabel.Text = "Error: Por favor, introduce un límite numérico válido.";
            }
        }

        private void OnDayOfWeekSwitchClicked(object sender, EventArgs e)
        {
            if (int.TryParse(DayNumberEntry.Text, out int numeroDia))
            {
                string nombreDia;
                switch (numeroDia)
                {
                    case 1: nombreDia = "Lunes"; break;
                    case 2: nombreDia = "Martes"; break;
                    case 3: nombreDia = "Miércoles"; break;
                    case 4: nombreDia = "Jueves"; break;
                    case 5: nombreDia = "Viernes"; break;
                    case 6: nombreDia = "Sábado"; break;
                    case 7: nombreDia = "Domingo"; break;
                    default:
                        nombreDia = "Número inválido (debe ser entre 1 y 7)";
                        break;
                }
                ResultLabel.Text = $"Resultado (Switch/Case):\nEl número {numeroDia} corresponde a: {nombreDia} 📅";
            }
            else
            {
                ResultLabel.Text = "Error: Por favor, introduce un número de día válido (1-7).";
            }
        }

        private void OnNumbersClicked(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder("Números del 1 al 100 (For):\n");
            for (int i = 1; i <= 100; i++) { result.Append(i).Append(" "); }
            ResultLabel.Text = result.ToString();
        }

        private void OnEvensClicked(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder("Números Pares del 1 al 100 (For, If):\n");
            for (int i = 1; i <= 100; i++) { if (i % 2 == 0) { result.Append(i).Append(" "); } }
            ResultLabel.Text = result.ToString();
        }

        private void OnOddsClicked(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder("Números Impares del 1 al 100 (For, If):\n");
            for (int i = 1; i <= 100; i++) { if (i % 2 != 0) { result.Append(i).Append(" "); } }
            ResultLabel.Text = result.ToString();
        }

        private void OnPrimesListClicked(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder("Números Primos del 1 al 100 (For, If):\n");
            for (int i = 1; i <= 100; i++)
            {
                if (IsPrime(i)) { result.Append(i).Append(" "); }
            }
            ResultLabel.Text = result.ToString();
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
