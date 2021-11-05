using System;
using System.Net.Mime;
using System.Threading;

namespace SimonDice
{
    public class Partida
    {
        private static int dificultad = 5;
        private static Random random = new Random();
        
        public static void AccederMenu()
        {
            Console.Clear();
            
            Console.WriteLine("¡Bienvenido al Simon Dice! \n");
            
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Reglas");
            Console.WriteLine("3. Controles");
            Console.WriteLine("4. Salir");

            Console.WriteLine("\nIntroduce tu elección: ");

            int eleccion = -1;
            
            do
            {
                try
                {
                    eleccion = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Introduce un valor correcto.");
                    Console.WriteLine("Pulsa cualquier tecla...");
                    
                    Console.ReadKey();
                    AccederMenu();
                }
            } 
            while (eleccion < 1  || eleccion > 4);
            
            Console.Clear();

            switch (eleccion)
            {
                case 1:
                {
                    //Jugar
                    Jugar();
                    break;
                }
                case 2:
                {
                    //Reglas
                    Reglas();
                    break;
                }
                case 3:
                {
                    //Controles
                    Controles();
                    Console.WriteLine("Controles");
                    break;
                }
                case 4:
                {
                    //Salir
                    Environment.Exit(0);
                    break;
                }
            }
        }

        private static void Jugar()
        {
            ConsoleKey key = ConsoleKey.A;
            int[] numerosPregunta = new int[dificultad];
            string[] numerosRespuesta = new string[dificultad];

            for (int i = 0; i < dificultad; i++)
            {
                numerosPregunta[i] = random.Next(0, 10);
            }

            int ronda = 1;

            while (key != ConsoleKey.Escape)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("----------- Simon Dice -----------");
                    Console.CursorVisible = false;
                    for (int i = 0; i < ronda; i++)
                    {
                        Console.SetCursorPosition(0,1);
                        Console.Write(numerosPregunta[i]);
                        Thread.Sleep(1000);

                        if (i < ronda - 1)
                        {
                            Console.SetCursorPosition(0,1);
                            Console.Write(" ");
                            Thread.Sleep(500);
                        }
                    }
                    
                    Console.SetCursorPosition(0,1);
                    Console.Write(" ");
                    Console.CursorVisible = true;

                    bool numerosCorrectos = true;

                    Console.WriteLine("\nIntroduce los numeros separados por espacios: ");
                    
                    string respuesta = Console.ReadLine();

                    if (respuesta.Length >= ronda * 2 - 1)
                    {
                        for (int i = 0; i < ronda; i++)
                        {
                            numerosRespuesta[i] = respuesta[i * 2].ToString();
                        }
                    }
                    
                    

                    if (numerosRespuesta.Length >= ronda)
                    {
                        for (int i = 0; i < ronda; i++)
                        {
                            if (numerosRespuesta[i] != numerosPregunta[i].ToString())
                            {
                                numerosCorrectos = false;
                            }
                        }
                    }
                    else numerosCorrectos = false;
                    

                    if (numerosCorrectos == false)
                    {
                        string seguirJugando = " ";
                        
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Has fallado, ¿quieres volver a jugar?");
                            Console.WriteLine("SI           NO");
                            Console.WriteLine("\nIntroduce tu respuesta: ");
                            
                            seguirJugando = Console.ReadLine();

                            if (seguirJugando.ToLower() == "si")
                            {
                                Jugar();
                            }
                            else if (seguirJugando.ToLower() == "no")
                            {
                                AccederMenu();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Introduce un valor correto");
                                Console.ReadKey();
                            }
                        } while (seguirJugando.ToLower() != "si" && seguirJugando.ToLower() != "no");
                    }

                    if (ronda == dificultad)
                    {
                        string seguirJugando = " ";
                        
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("¡Has ganado! ¿Quieres volver a jugar?");
                            Console.WriteLine("SI           NO");
                            Console.WriteLine("\nIntroduce tu respuesta: ");
                            
                            seguirJugando = Console.ReadLine();

                            if (seguirJugando.ToLower() == "si")
                            {
                                Jugar();
                            }
                            else if (seguirJugando.ToLower() == "no")
                            {
                                AccederMenu();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Introduce un valor correto");
                                Console.ReadKey();
                            }
                        } while (seguirJugando.ToLower() != "si" && seguirJugando.ToLower() != "no");
                    }
                    
                    ronda++;
                    
                    /*Console.WriteLine("Pulsa escape para salir...");
                    Console.ReadKey();*/
                    
                } while (ronda <= dificultad);

                key = Console.ReadKey().Key;
                AccederMenu();
            }
        }

        private static void Reglas()
        {
            Console.WriteLine("----------- Reglas del Juego -----------\n");
            
            Console.WriteLine("Se irá mostando una serie de números consecutivos.");
            Console.WriteLine("Por cada ronda, en caso de acierto,  se ira sumando un número a la cadena.");
            Console.WriteLine("Deberás ir introduciendo estos números en orden de aparición, separando cada número por un espacio.");
            
            Console.WriteLine("\nPulsa cualquier tecla...");
            
            Console.ReadKey();
            AccederMenu();
        }

        private static void Controles()
        {
            Console.WriteLine("----------- Controles del Juego -----------\n");
            
            Console.WriteLine("Se utilizará el teclado para introducir los números");
            Console.WriteLine("Enter para confirmar los números introducidos");
            Console.WriteLine("Espacio para separar los números introducidos");
            Console.WriteLine("Escape para volver al menú.");
            
            Console.WriteLine("\nPulsa cualquier tecla...");
            
            Console.ReadKey();
            AccederMenu();
        }
    }
}