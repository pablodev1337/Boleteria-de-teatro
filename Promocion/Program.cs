using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promocion
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARO VARIABLES Y ASIGNO VALORES.
            Random aleatorio = new Random();
            int[,] butacas = new int[6, 10];
            double precio_pref = 10000, precio_plb = 6000, precio_pla = 3000, recaudado = 0;
            int eleccion, opcion;

            // CICLO FOR PARA MOSTRAR BUTACAS VENDIDAS (0) Y DISPONIBLES (1) GENERADAS ALEATORIAMENTE.
            for (int i = 0; i < butacas.GetLength(0); i++)
            {
                for (int j = 0; j < butacas.GetLength(1); j++)
                {
                    butacas[i, j] = aleatorio.Next(0, 2);
                    if (butacas[i, j] == 1)
                    {
                        // SUMO LOS PRECIOS DE LOS SECTORES A LO RECAUDADO SI YA ESTA VENDIDO DESDE EL INICIO.
                        if (i == 5)
                        {
                            recaudado += precio_pref;
                        }
                        else
                        {
                            if (i == 3 || i == 4)
                            {
                                recaudado += precio_plb;
                            }
                            else
                            {
                                recaudado += precio_pla;
                            }
                        }
                    }
                }
            }

            while (true)
            {
                // TABLA DE OPCIONES DEL TEATRO.
                Console.Clear();
                Console.WriteLine("┌────────────────────────────┐");
                Console.WriteLine("│  BIENVENIDOS/AS AL TEATRO  │");
                Console.WriteLine("├────────────────────────────┤");
                Console.WriteLine("│ 1. Ver Venta de butacas    │");
                Console.WriteLine("│ 2. Ver recaudacion         │");
                Console.WriteLine("│ 3. Ver disponibilidad      │");
                Console.WriteLine("│ 4. Salir                   │");
                Console.WriteLine("└────────────────────────────┘");
                Console.Write("Elija una opcion: ");

                if (int.TryParse(Console.ReadLine(), out eleccion))
                {
                    // FUNCION SWITCH PARA CADA OPCION.
                    switch (eleccion)
                    {
                        case 1:
                            // VENTA DE BUTACAS.
                            Console.Clear();
                            Console.WriteLine("┌───────────────────────────────────┐");
                            Console.WriteLine("│         VENTA DE BUTACAS          │");
                            Console.WriteLine("├───────────────────────────────────┤");
                            Console.WriteLine("│ 1. Preferenciales ($10.000 Pesos) │ (FILA 5)");
                            Console.WriteLine("│ 2. Platea Baja    ($6.000 Pesos)  │ (FILAS 4-3)");
                            Console.WriteLine("│ 3. Platea Alta    ($3.000 Pesos)  │ (FILAS 2-1-0)");
                            Console.WriteLine("└───────────────────────────────────┘");
                            Console.Write("Elija una opcion: ");
                            opcion = Convert.ToInt32(Console.ReadLine());

                            int disponibles = 0;

                            // CICLO FOR PARA CONTAR LAS BUTACAS DISPONIBLES SEGUN EL SECTOR ELEGIDO.
                            for (int i = 0; i < butacas.GetLength(0); i++)
                            {
                                if ((opcion == 1 && i == 5) || (opcion == 2 && (i == 3 || i == 4)) || (opcion == 3 && (i >= 0 && i <= 2)))
                                {
                                    for (int j = 0; j < butacas.GetLength(1); j++)
                                    {
                                        if (butacas[i, j] == 0)
                                        {
                                            disponibles++;
                                        }
                                    }
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine($"Butacas disponibles en ese sector: {disponibles}");

                            if (disponibles == 0)
                            {
                                Console.WriteLine("No hay butacas disponibles en este sector.");
                                Console.ReadKey();
                                break;
                            }

                            // MAPA DE BUTACAS PARA QUE EL USUARIO ELIGA LA BUTACA EN DONDE SE QUIERA SENTAR.
                            Console.WriteLine();
                            Console.WriteLine("          ┌─────────────────────────────────────┐");
                            Console.WriteLine("          │           MAPA DE BUTACAS           │");
                            Console.WriteLine("          ├─────────────────────────────────────┤");
                            for (int i = 0; i < butacas.GetLength(0); i++)
                            {
                                Console.Write("FILA " + (i) + " -› │ ");
                                string linea_mapa = "";
                                
                                for (int j = 0; j < butacas.GetLength(1); j++)
                                {
                                    if (butacas[i, j] == 0)
                                    {
                                        linea_mapa += "_ ";
                                    }
                                    else
                                    {
                                        linea_mapa += "X ";
                                    }
                                }

                                string sector = "";

                                if (i == 5)
                                {
                                    sector = "Preferenciales";
                                }
                                else
                                {
                                    if (i == 3 || i == 4)
                                    {
                                        sector = "Platea baja";
                                    }
                                    else
                                    {
                                        sector = "Platea alta";
                                    }
                                }

                                string linea_completa = linea_mapa + " " + sector;

                                int espacios_faltantes = 36 - linea_completa.Length;
                                for (int e = 0; e < espacios_faltantes; e++)
                                {
                                    linea_completa += " ";
                                }

                                Console.WriteLine(linea_completa + "│");
                            }
                            Console.WriteLine("          └─────────────────────────────────────┘");

                            // ACA LE PIDO LA BUTACA QUE EL USUARIO DESEA COMPRAR.
                            Console.WriteLine();
                            Console.Write("Elija la fila: ");
                            int fila = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("(RECUERDE QUE PARA ELEGIR LA COLUMNA DEBE RESTARLE UN 1 A SU OPCION Y ESCRIBIRLO)");
                            Console.Write("Elija la columna: ");
                            int columna = Convert.ToInt32(Console.ReadLine());

                            // ACA SE VALIDA SI ESTA LIBRE Y SI CORRESPONDE AL SECTOR QUE ELIGIO EL USUARIO.
                            bool valido = false;
                            if ((opcion == 1 && fila == 5) || (opcion == 2 && (fila == 3 || fila == 4)) || (opcion == 3 && (fila >= 0 && fila <= 2)))
                            {
                                valido = true;
                            }

                            if (!valido)
                            {
                                Console.WriteLine("Esa fila no corresponde al sector elegido.");
                                Console.ReadKey();
                                break;
                            }

                            if (butacas[fila, columna] == 0)
                            {
                                butacas[fila, columna] = 1;
                                double precio_venta = 0;

                                if (fila == 5)
                                {
                                    precio_venta = precio_pref;
                                }
                                else
                                {
                                    if (fila == 3 || fila == 4)
                                    {
                                        precio_venta = precio_plb;
                                    }
                                    else
                                    {
                                        precio_venta = precio_pla;
                                    }
                                }

                                recaudado += precio_venta;
                                Console.WriteLine($"Butaca vendida por ${precio_venta}.");
                            }
                            else
                            {
                                Console.WriteLine("Esa butaca ya esta ocupada.");
                            }
                            Console.ReadKey();
                            break;

                        case 2:
                            // ACA SE MUESTRA LO RECAUDADO EN TOTAL DE TODAS LAS BUTACAS VENDIDAS.
                            Console.Clear();
                            Console.WriteLine("┌────────────────────────────────────────┐");
                            Console.WriteLine("│           RECAUDACION TOTAL            │");
                            Console.WriteLine("├────────────────────────────────────────┤");
                            Console.WriteLine($"│ Recaudacion total: ${recaudado}             │");
                            Console.WriteLine("└────────────────────────────────────────┘");
                            Console.ReadKey();
                            break;

                        case 3:
                            // ACA SE MUESTRA UN MAPA IGUAL QUE EL DEL CASE 1 PERO ESTA VEZ INDICANDO CUANTAS BUTACAS SE VENDIERON Y QUEDAN DISPONIBLES.
                            Console.Clear();
                            Console.WriteLine("┌────────────────────────────────────────┐");
                            Console.WriteLine("│           ESTADO DE BUTACAS            │");
                            Console.WriteLine("├───────────────────┬────────────────────┤");
                            Console.WriteLine("│ _ ‹- DISPONIBLE   │ X ‹- VENDIDO       │");
                            Console.WriteLine("├───────────────────┴────────────────────┤");

                            int but_disponibles = 0, but_vendidas = 0;
                            int pref_disponibles = 0, plb_disponibles = 0, pla_disponibles = 0;

                            for (int i = 0; i < butacas.GetLength(0); i++)
                            {
                                Console.Write("│ ");
                                string linea_mapa = "";

                                for (int j = 0; j < butacas.GetLength(1); j++)
                                {
                                    if (butacas[i, j] == 0)
                                    {
                                        linea_mapa += "_ ";
                                        but_disponibles++;

                                        if (i == 5)
                                        {
                                            pref_disponibles++;
                                        }
                                        else
                                        {
                                            if (i == 3 || i == 4)
                                            {
                                                plb_disponibles++;
                                            }
                                            else
                                            {
                                                pla_disponibles++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        linea_mapa += "X ";
                                        but_vendidas++;
                                    }
                                }

                                string sector = "";

                                if (i == 5)
                                {
                                    sector = "‹- Preferenciales";
                                }
                                else
                                {
                                    if (i == 3 || i == 4)
                                    {
                                        sector = "‹- Platea baja";
                                    }
                                    else
                                    {
                                        sector = "‹- Platea alta";
                                    }
                                }

                                string linea_completa = linea_mapa + " " + sector;

                                int espacios_faltantes = 39 - linea_completa.Length;
                                for (int e = 0; e < espacios_faltantes; e++)
                                {
                                    linea_completa += " ";
                                }

                                Console.WriteLine(linea_completa + "│");
                            }
                            Console.WriteLine("├────────────────────────────────────────┤");
                            Console.WriteLine($"│ Disponibles Preferenciales: {pref_disponibles,1}          │");
                            Console.WriteLine($"│ Disponibles Platea Baja   : {plb_disponibles,2}         │");
                            Console.WriteLine($"│ Disponibles Plata Alta    : {pla_disponibles}         │");
                            Console.WriteLine("├───────────────────┬────────────────────┤");
                            Console.WriteLine($"│ Disponibles: {but_disponibles,-5}│ Vendidas: {but_vendidas,-9}│");
                            Console.WriteLine("└───────────────────┴────────────────────┘");
                            Console.ReadKey();
                            break;

                        case 4:
                            // ACA SE MUESTRA LA LEYENDA DE AGRADECIMIENTO POR UTILIZAR EL PROGRAMA.
                            Console.Clear();
                            Console.WriteLine("Gracias por utilizar nuestro sistema.");
                            Console.ReadKey();
                            return;

                        default:
                            // ANTE CUALQUIER OPCION INVALIDA INGRESADA SE MOSTRARA UN TEXTO DE ERROR.
                            Console.WriteLine("[ERROR] - Opcion invalida.");
                            Console.ReadKey();
                            break;

                    }
                }
                else
                {
                    // SI EL USUARIO NO INGRESA NINGUN NUMERO SE MOSTRARA ESTO.
                    Console.WriteLine("[ERROR] - Ingrese un numero.");
                    Console.ReadKey();
                }
            }
        }
    }
}
