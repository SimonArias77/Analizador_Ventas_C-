// ANALIZADOR DE VENTAS PARA UNA TIENDA DE ELECTRODOMÉSTICOS

using System;
using System.Collections.Generic;
using System.Linq;

public class Venta
{
    // Propiedades de la clase Venta
    public int Id { get; set; }
    public DateTime FechaDeVenta { get; set; }
    public decimal ValorProducto { get; set; }
    public int CantidadDeProductos { get; set; }
    public string Vendedor { get; set; }
    public string Comprador { get; set; }
    public int TiempoGarantiaFuncionalidades { get; set; }

    // Constructor para inicializar la venta
    public Venta(int id, DateTime fecha, decimal valor, int cantidad, string vendedor, string comprador, int garantia)
    {
        Id = id;
        FechaDeVenta = fecha;
        ValorProducto = valor;
        CantidadDeProductos = cantidad;
        Vendedor = vendedor;
        Comprador = comprador;
        TiempoGarantiaFuncionalidades = garantia;
    }
}


public class Program
{
    // Lista para almacenar las ventas
    public static List<Venta> ventas = new List<Venta>();

    public static void Main()
    {
        // Agregamos algunas ventas de ejemplo
        ventas.Add(new Venta(1, new DateTime(2024, 7, 1), 100.50m, 2, "Juan", "Cliente A", 12));
        ventas.Add(new Venta(2, new DateTime(2024, 7, 2), 75.25m, 1, "Pedro", "Cliente B", 6));
        ventas.Add(new Venta(3, new DateTime(2024, 7, 3), 200.00m, 3, "Juan", "Cliente C", 18));
        ventas.Add(new Venta(4, new DateTime(2024, 7, 4), 50.75m, 1, "María", "Cliente A", 9));

        // Ejecutamos la interfaz de usuario
        MostrarMenu();
    }

    // Método para mostrar el menú y manejar la interacción con el usuario
    public static void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("===== Menú Principal =====");
            Console.WriteLine("1. Registrar nueva venta");
            Console.WriteLine("2. Calcular valor total de una venta específica");
            Console.WriteLine("3. Calcular promedio de ventas diarias");
            Console.WriteLine("4. Mostrar empleado del Mes");
            Console.WriteLine("5. Mostrar cliente del Mes");
            Console.WriteLine("6. Filtrar ventas después de una fecha específica");
            Console.WriteLine("7. Vendedores con ventas por encima de cierto valor");
            Console.WriteLine("8. Total de ventas mensuales");
            Console.WriteLine("9. Vendedor con mayor número de ventas en un período");
            Console.WriteLine("10. Ordenar ventas por valor total descendente");
            Console.WriteLine("11. Productos más vendidos en un año");
            Console.WriteLine("12. Validar si existe una venta con un valor específico");
            Console.WriteLine("13. Buscar ventas de un cliente específico");
            Console.WriteLine("14. Calcular total y promedio de ventas por vendedor");
            Console.WriteLine("15. Mes con mayor número de ventas");
            Console.WriteLine("0. Salir");
            Console.Write("Ingrese opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine(); // Salto de línea para separar la entrada del menú
                EjecutarOpcion(opcion);
            }
            else
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
            }

            Console.WriteLine(); // Salto de línea al final de cada iteración
        } while (opcion != 0);
    }

    // Método para ejecutar la opción seleccionada por el usuario
    public static void EjecutarOpcion(int opcion)
    {
        switch (opcion)
        {
            case 1:
                RegistrarNuevaVenta();
                break;
            case 2:
                CalcularValorTotalVenta();
                break;
            case 3:
                CalcularPromedioVentasDiarias();
                break;
            case 4:
                MostrarEmpleadoDelMes();
                break;
            case 5:
                MostrarClienteDelMes();
                break;
            case 6:
                FiltrarVentasDespuesDeFecha();
                break;
            case 7:
                VendedoresConVentasPorEncimaDe();
                break;
            case 8:
                TotalVentasMensuales();
                break;
            case 9:
                VendedorConMasVentasEnPeriodo();
                break;
            case 10:
                OrdenarVentasPorValorTotalDescendente();
                break;
            case 11:
                ProductosMasVendidosEnAnio();
                break;
            case 12:
                ValidarVentaConValorEspecifico();
                break;
            case 13:
                BuscarVentasDeClienteEspecifico();
                break;
            case 14:
                CalcularTotalYPromedioVentasPorVendedor();
                break;
            case 15:
                MesConMayorNumeroDeVentas();
                break;
            case 0:
                Console.WriteLine("Saliendo del programa.");
                break;
            default:
                Console.WriteLine("Opción no reconocida.");
                break;
        }
    }

    public static void RegistrarNuevaVenta()
    {
        Console.WriteLine("Ingrese los datos de la nueva venta:");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Fecha de Venta (yyyy-MM-dd): ");
        DateTime fecha = DateTime.Parse(Console.ReadLine());

        Console.Write("Valor del Producto: ");
        decimal valor = decimal.Parse(Console.ReadLine());

        Console.Write("Cantidad de Productos: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Nombre del Vendedor: ");
        string vendedor = Console.ReadLine();

        Console.Write("Nombre del Comprador: ");
        string comprador = Console.ReadLine();

        Console.Write("Tiempo de Garantía/Funcionalidades (en meses): ");
        int garantia = int.Parse(Console.ReadLine());

        ventas.Add(new Venta(id, fecha, valor, cantidad, vendedor, comprador, garantia));

        Console.WriteLine("Venta registrada correctamente.");
    }

    public static void CalcularValorTotalVenta()
    {
        Console.Write("Ingrese el Id de la venta: ");
        if (int.TryParse(Console.ReadLine(), out int idVenta))
        {
            var venta = ventas.FirstOrDefault(v => v.Id == idVenta);
            if (venta != null)
            {
                decimal totalVenta = venta.ValorProducto * venta.CantidadDeProductos;
                Console.WriteLine($"El valor total de la venta {idVenta} es: {totalVenta:C}");
            }
            else
            {
                Console.WriteLine($"No se encontró la venta con Id {idVenta}.");
            }
        }
        else
        {
            Console.WriteLine("Id de venta inválido.");
        }
    }

    public static void CalcularPromedioVentasDiarias()
    {
        double promedioVentas = ventas.Count / (DateTime.Now - ventas.Min(v => v.FechaDeVenta)).TotalDays;
        Console.WriteLine($"El promedio de ventas diarias es: {promedioVentas:F2}");
    }

    public static void MostrarEmpleadoDelMes()
    {
        var empleadoDelMes = ventas.GroupBy(v => v.Vendedor)
                                   .Select(g => new { Vendedor = g.Key, TotalVentas = g.Sum(v => v.ValorProducto * v.CantidadDeProductos) })
                                   .OrderByDescending(x => x.TotalVentas)
                                   .FirstOrDefault();

        if (empleadoDelMes != null)
        {
            Console.WriteLine($"El empleado del mes es: {empleadoDelMes.Vendedor}");
        }
        else
        {
            Console.WriteLine("No hay ventas registradas.");
        }
    }

    public static void MostrarClienteDelMes()
    {
        var clienteDelMes = ventas.GroupBy(v => v.Comprador)
                                  .Select(g => new { Cliente = g.Key, TotalCompras = g.Sum(v => v.ValorProducto * v.CantidadDeProductos) })
                                  .OrderByDescending(x => x.TotalCompras)
                                  .FirstOrDefault();

        if (clienteDelMes != null)
        {
            Console.WriteLine($"El cliente del mes es: {clienteDelMes.Cliente}");
        }
        else
        {
            Console.WriteLine("No hay ventas registradas.");
        }
    }

    public static void FiltrarVentasDespuesDeFecha()
    {
        Console.Write("Ingrese la fecha límite (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaLimite))
        {
            var ventasDespuesDeFecha = ventas.Where(v => v.FechaDeVenta > fechaLimite);
            MostrarVentas(ventasDespuesDeFecha);
        }
        else
        {
            Console.WriteLine("Fecha inválida.");
        }
    }

    public static void VendedoresConVentasPorEncimaDe()
    {
        Console.Write("Ingrese el valor mínimo de ventas: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal valorMinimo))
        {
            var vendedores = ventas.GroupBy(v => v.Vendedor)
                                   .Where(g => g.Sum(v => v.ValorProducto * v.CantidadDeProductos) > valorMinimo)
                                   .Select(g => g.Key);

            Console.WriteLine($"Vendedores con ventas por encima de {valorMinimo:C}:");
            foreach (var vendedor in vendedores)
            {
                Console.WriteLine(vendedor);
            }
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }
    }

    public static void TotalVentasMensuales()
    {
        var ventasMensuales = ventas.GroupBy(v => new { Mes = v.FechaDeVenta.Month, Anio = v.FechaDeVenta.Year })
                                    .Select(g => new { MesAnio = $"{g.Key.Mes}-{g.Key.Anio}", TotalVentas = g.Sum(v => v.ValorProducto * v.CantidadDeProductos) });

        Console.WriteLine("Total de ventas mensuales:");
        foreach (var ventaMensual in ventasMensuales)
        {
            Console.WriteLine($"{ventaMensual.MesAnio}: {ventaMensual.TotalVentas:C}");
        }
    }

    public static void VendedorConMasVentasEnPeriodo()
    {
        Console.Write("Ingrese la fecha de inicio del período (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaInicio))
        {
            Console.Write("Ingrese la fecha de fin del período (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaFin))
            {
                var vendedorConMasVentas = ventas.Where(v => v.FechaDeVenta >= fechaInicio && v.FechaDeVenta <= fechaFin)
                                                 .GroupBy(v => v.Vendedor)
                                                 .Select(g => new { Vendedor = g.Key, TotalVentas = g.Count() })
                                                 .OrderByDescending(x => x.TotalVentas)
                                                 .FirstOrDefault();

                if (vendedorConMasVentas != null)
                {
                    Console.WriteLine($"El vendedor con más ventas entre {fechaInicio.ToShortDateString()} y {fechaFin.ToShortDateString()} es: {vendedorConMasVentas.Vendedor}");
                }
                else
                {
                    Console.WriteLine($"No hay ventas registradas entre {fechaInicio.ToShortDateString()} y {fechaFin.ToShortDateString()}.");
                }
            }
            else
            {
                Console.WriteLine("Fecha de fin inválida.");
            }
        }
        else
        {
            Console.WriteLine("Fecha de inicio inválida.");
        }
    }

    public static void OrdenarVentasPorValorTotalDescendente()
    {
        var ventasOrdenadas = ventas.OrderByDescending(v => v.ValorProducto * v.CantidadDeProductos)
                                    .ToList();

        MostrarVentas(ventasOrdenadas);
    }

    public static void ProductosMasVendidosEnAnio()
    {
        Console.Write("Ingrese el año para el cual desea conocer los productos más vendidos: ");
        if (int.TryParse(Console.ReadLine(), out int anio))
        {
            var productosMasVendidos = ventas.Where(v => v.FechaDeVenta.Year == anio)
                                             .GroupBy(v => v.Id) // Agrupamos por Id del producto
                                             .Select(g => new { ProductoId = g.Key, CantidadVendida = g.Sum(v => v.CantidadDeProductos) })
                                             .OrderByDescending(x => x.CantidadVendida)
                                             .ToList();

            if (productosMasVendidos.Any())
            {
                Console.WriteLine($"Productos más vendidos en el año {anio}:");
                foreach (var producto in productosMasVendidos)
                {
                    Console.WriteLine($"Producto ID: {producto.ProductoId}, Cantidad Vendida: {producto.CantidadVendida}");
                }
            }
            else
            {
                Console.WriteLine($"No hay ventas registradas para el año {anio}.");
            }
        }
        else
        {
            Console.WriteLine("Año inválido.");
        }
    }

    public static void ValidarVentaConValorEspecifico()
    {
        Console.Write("Ingrese el valor específico a buscar: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal valorBuscado))
        {
            bool existeVenta = ventas.Any(v => (v.ValorProducto * v.CantidadDeProductos) == valorBuscado);
            if (existeVenta)
            {
                Console.WriteLine($"Sí existe al menos una venta con valor {valorBuscado:C}.");
            }
            else
            {
                Console.WriteLine($"No existe ninguna venta con valor {valorBuscado:C}.");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido.");
        }
    }

    public static void BuscarVentasDeClienteEspecifico()
    {
        Console.Write("Ingrese el nombre del cliente a buscar: ");
        string clienteBuscado = Console.ReadLine();

        var ventasCliente = ventas.Where(v => v.Comprador.Equals(clienteBuscado, StringComparison.OrdinalIgnoreCase)).ToList();

        if (ventasCliente.Any())
        {
            Console.WriteLine($"Ventas realizadas al cliente {clienteBuscado}:");
            MostrarVentas(ventasCliente);
        }
        else
        {
            Console.WriteLine($"No se encontraron ventas para el cliente {clienteBuscado}.");
        }
    }

    public static void CalcularTotalYPromedioVentasPorVendedor()
    {
        var totalVentasPorVendedor = ventas.GroupBy(v => v.Vendedor)
                                           .Select(g => new
                                           {
                                               Vendedor = g.Key,
                                               TotalVentas = g.Sum(v => v.ValorProducto * v.CantidadDeProductos),
                                               CantidadVentas = g.Count()
                                           })
                                           .ToList();

        if (totalVentasPorVendedor.Any())
        {
            Console.WriteLine("Total y promedio de ventas por vendedor:");
            foreach (var vendedor in totalVentasPorVendedor)
            {
                decimal promedioVentas = vendedor.TotalVentas / vendedor.CantidadVentas;
                Console.WriteLine($"Vendedor: {vendedor.Vendedor}, Total Ventas: {vendedor.TotalVentas:C}, Promedio Ventas: {promedioVentas:C}");
            }
        }
        else
        {
            Console.WriteLine("No hay ventas registradas.");
        }
    }

    public static void MesConMayorNumeroDeVentas()
    {
        var mesConMasVentas = ventas.GroupBy(v => new { Mes = v.FechaDeVenta.Month, Anio = v.FechaDeVenta.Year })
                                    .Select(g => new { MesAnio = $"{g.Key.Mes}-{g.Key.Anio}", TotalVentas = g.Count() })
                                    .OrderByDescending(x => x.TotalVentas)
                                    .FirstOrDefault();

        if (mesConMasVentas != null)
        {
            Console.WriteLine($"El mes con mayor número de ventas es: {mesConMasVentas.MesAnio}, con {mesConMasVentas.TotalVentas} ventas.");
        }
        else
        {
            Console.WriteLine("No hay ventas registradas.");
        }
    }

    public static void MostrarVentas(IEnumerable<Venta> ventas)
    {
        foreach (var venta in ventas)
        {
            Console.WriteLine($"Id: {venta.Id}, Fecha: {venta.FechaDeVenta.ToShortDateString()}, " +
                              $"Valor: {venta.ValorProducto:C}, Cantidad: {venta.CantidadDeProductos}, " +
                              $"Vendedor: {venta.Vendedor}, Comprador: {venta.Comprador}, " +
                              $"Garantía/Funcionalidades: {venta.TiempoGarantiaFuncionalidades} meses");
        }
    }
}