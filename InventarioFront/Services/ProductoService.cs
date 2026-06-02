using InventarioModelo.Entidades;
using System.Net.Http.Json;

namespace InventarioFront.Services;

public class ProductoService
{
    private readonly HttpClient _http;

    public ProductoService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Producto>> GetProductos()
    {
        return await _http.GetFromJsonAsync<List<Producto>>
            ("http://localhost:5221/api/Productos")
            ?? new List<Producto>();
    }

    public async Task CrearProducto(Producto producto)
    {
        await _http.PostAsJsonAsync(
            "http://localhost:5221/api/Productos",
            producto);
    }

    public async Task ActualizarProducto(Producto producto)
    {
        await _http.PutAsJsonAsync(
            $"http://localhost:5221/api/Productos/{producto.Id}",
            producto);
    }

    public async Task EliminarProducto(int id)
    {
        await _http.DeleteAsync(
            $"http://localhost:5221/api/Productos/{id}");
    }
}
