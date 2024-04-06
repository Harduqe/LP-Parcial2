namespace Juego_Adivina_el_Número

   internal class Program
    {
    public static void Main()
    {
        // Declarando variables

        Random random = new Random();
        bool jugarDeNuevo = true;

        while (jugarDeNuevo)
        {
            Console.Clear();
            Console.WriteLine("¡Bienvenido al juego Adivina el número!\n");

            int numJugadores;
            bool entradaValida = false;
            do
            {
                // Pedimos el numero de jugadores

                Console.Write("Ingrese el número de jugadores (entre 2 y 4): ");
                string input = Console.ReadLine();
                int.TryParse(input, out numJugadores);

                // Comparamos si el numero de jugadores es valido

                if (numJugadores >= 2 && numJugadores <= 4)
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Intente nuevamente.");
                }
            } while (!entradaValida);

            // Rango máximo según el número de jugadores

            int rangoMaximo = numJugadores * 50; 

            int numeroAleatorio = random.Next(rangoMaximo + 1);

            bool juegoTerminado = false;

            // Iniciamos el ciclo para cada intento por jugador

            for (int intentos = 1; !juegoTerminado; intentos++)
            {
                Console.Write($"\nJugador {intentos % numJugadores + 1}, adivina el número (entre 0 y {rangoMaximo}): ");
                string input = Console.ReadLine();
                int intento;

                //Comparamos para determinar si es mayor o menor

                if (!int.TryParse(input, out intento) || intento < 0 || intento > rangoMaximo)
                {
                    Console.WriteLine($"Entrada inválida. Intente nuevamente (entre 0 y {rangoMaximo}).");
                    continue;
                }

                if (intento < numeroAleatorio)
                {
                    Console.WriteLine("MAYOR");
                }
                else if (intento > numeroAleatorio)
                {
                    Console.WriteLine("MENOR");
                }

                // Si acierta 
                else
                {
                    Console.WriteLine($"¡¡¡¡HAS GANADO, Jugador {intentos % numJugadores + 1}!!!!");
                    juegoTerminado = true;
                }
            }

            //Preguntamos si quiere otro intento

            Console.Write("\n¿Desea jugar de nuevo? (s/n): ");
            string respuesta = Console.ReadLine().Trim().ToLower();
            if (respuesta == "s")
            {
                jugarDeNuevo = true;
            }
            else
            {
                jugarDeNuevo = false;
                Console.WriteLine("¡Gracias por jugar!");
            }
        }
    }
}