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
}
