namespace Modificacion_Natillera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool volver = true;

            while (volver)
            {
                decimal aporteMensual1, aporteMensual2, rendimientoMensual1, rendimientoMensual2, aporteTotal1 = 0, aporteTotal2 = 0, rendimientoTotal1 = 0, rendimientoTotal2 = 0, bonoTotal1 = 0, bonoTotal2 = 0;
                decimal prestamo1 = 0, prestamo2 = 0, interesesPrestamo1 = 0, interesesPrestamo2 = 0;
                int multas1 = 0, multas2 = 0;
                decimal aporteTotalNeto1 = 0, aporteTotalNeto2 = 0;
                string continuar;

                Random random = new Random();

                for (int mes = 1; mes <= 12; mes++)
                {
                    Console.Write($"Ingrese la cantidad que desea ahorrar en el mes {mes} - Socio 1: ");
                    aporteMensual1 = Convert.ToDecimal(Console.ReadLine());

                    Console.Write($"Ingrese la cantidad que desea ahorrar en el mes {mes} - Socio 2: ");
                    aporteMensual2 = Convert.ToDecimal(Console.ReadLine());

                    // Multa si no se realizó aporte
                    if (aporteMensual1 == 0)
                    {
                        Console.WriteLine("Socio 1: Se aplicó una multa de $20.000");
                        multas1++;
                        aporteMensual1 -= 20000;
                    }
                    if (aporteMensual2 == 0)
                    {
                        Console.WriteLine("Socio 2: Se aplicó una multa de $20.000");
                        multas2++;
                        aporteMensual2 -= 20000;
                    }

                    aporteTotal1 += aporteMensual1;
                    aporteTotal2 += aporteMensual2;

                    decimal tasaMensual1 = (decimal)random.Next(10, 51) / 10;
                    decimal tasaMensual2 = (decimal)random.Next(10, 51) / 10;

                    rendimientoMensual1 = aporteMensual1 * (tasaMensual1 / 100);
                    rendimientoMensual2 = aporteMensual2 * (tasaMensual2 / 100);

                    if (tasaMensual1 < 1.5M)
                    {
                        bonoTotal1 += aporteMensual1 * 0.4M;
                    }
                    if (tasaMensual2 < 1.5M)
                    {
                        bonoTotal2 += aporteMensual2 * 0.4M;
                    }

                    aporteTotalNeto1 = rendimientoTotal1 + aporteTotal1 + bonoTotal1 - prestamo1 + interesesPrestamo1;
                    aporteTotalNeto2 = rendimientoTotal2 + aporteTotal2 + bonoTotal2 - prestamo2 + interesesPrestamo2;

                    Console.WriteLine($"MES {mes}\n" +
                                      $"Socio 1:\n" +
                                      $"Aporte: {aporteMensual1:C}\n" +
                                      $"Tasa: {tasaMensual1}%\n" +
                                      $"Rendimiento: {rendimientoMensual1:C}\n" +
                                      $"Bono: {bonoTotal1:C}\n" +
                                      $"---------------------------------------\n" +
                                      $"Socio 2:\n" +
                                      $"Aporte: {aporteMensual2:C}\n" +
                                      $"Tasa: {tasaMensual2}%\n" +
                                      $"Rendimiento: {rendimientoMensual2:C}\n" +
                                      $"Bono: {bonoTotal2:C}\n" +
                                      $"---------------------------------------\n");
                }

                Console.WriteLine($"Socio 1:\n" +
                                  $"Aportes totales: {aporteTotal1:C}\n" +
                                  $"Rendimientos totales: {rendimientoTotal1:C}\n" +
                                  $"Bonos totales: {bonoTotal1:C}\n" +
                                  $"Multas pagadas: {multas1}\n" +
                                  "--------------------------------\n" +
                                  $"TOTAL NETO: {aporteTotalNeto1:C}\n");

                Console.WriteLine($"Socio 2:\n" +
                                  $"Aportes totales: {aporteTotal2:C}\n" +
                                  $"Rendimientos totales: {rendimientoTotal2:C}\n" +
                                  $"Bonos totales: {bonoTotal2:C}\n" +
                                  $"Multas pagadas: {multas2}\n" +
                                  "--------------------------------\n" +
                                  $"TOTAL NETO: {aporteTotalNeto2:C}\n");

                Console.WriteLine("¿Desea ingresar a la natillera para el siguiente año? (s/n)");
                continuar = Console.ReadLine().ToLower();
                if (continuar == "n") volver = false;
            }
        }
    }
}
