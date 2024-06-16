using System;

class Program
{
    static void Main()
    {
        // Generar el número secreto de cuatro dígitos
        Random random = new Random();
        string secretNumber = GenerateSecretNumber(random);

        Console.WriteLine("Bienvenido al juego de Picas y Fijas!");
        Console.WriteLine("Intenta adivinar el número secreto de 4 dígitos.");

        bool isGuessed = false;

        // Bucle principal del juego
        while (!isGuessed)
        {
            Console.Write("Ingresa tu intento (debe ser un número de 4 dígitos): ");
            string guess = Console.ReadLine();

            // Validar la entrada del usuario
            if (guess.Length != 4 || !int.TryParse(guess, out _))
            {
                Console.WriteLine("Debes ingresar un número válido de 4 dígitos.");
                continue;
            }

            // Calcular picas y fijas
            int fijas = 0;
            int picas = 0;

            // Arrays para contar dígitos en el número secreto y en el intento
            int[] secretCount = new int[10];
            int[] guessCount = new int[10];

            // Contar fijas y picas
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secretNumber[i])
                {
                    fijas++;
                }
                else
                {
                    secretCount[secretNumber[i] - '0']++;
                    guessCount[guess[i] - '0']++;
                }
            }

            // Contar picas
            for (int i = 0; i < 10; i++)
            {
                picas += Math.Min(secretCount[i], guessCount[i]);
            }

            // Mostrar resultados al usuario
            Console.WriteLine($"Resultado: {fijas} Fijas, {picas} Picas");

            // Verificar si el usuario adivinó el número secreto
            if (fijas == 4)
            {
                isGuessed = true;
                Console.WriteLine($"¡Felicidades! Has adivinado el número secreto {secretNumber}");
            }
        }
    }

    // Función para generar un número secreto de cuatro dígitos único
    static string GenerateSecretNumber(Random random)
    {
        string secretNumber = "";
        while (secretNumber.Length < 4)
        {
            char digit = (char)('0' + random.Next(0, 10));
            if (!secretNumber.Contains(digit))
            {
                secretNumber += digit;
            }
        }
        return secretNumber;
    }
}
