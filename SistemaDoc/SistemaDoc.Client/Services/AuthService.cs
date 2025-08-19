using Microsoft.JSInterop;
using SistemaDoc.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace SistemaDoc.Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;

        public AuthService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
        }

        public async Task<Usuario?> Login(string usuario, string contrasena)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", new
            {
                NombreUsuario = usuario,
                Contrasena = contrasena
            });

            if (!response.IsSuccessStatusCode)
                return null;

            var user = await response.Content.ReadFromJsonAsync<Usuario>();
            if (user != null)
            {
                await _js.InvokeVoidAsync("localStorage.setItem", "usuarioActual", JsonSerializer.Serialize(user));
            }
            return user;
        }

        public async Task<Usuario?> ObtenerUsuarioActual()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", "usuarioActual");
            return string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.Deserialize<Usuario>(json);
        }

        public async Task Logout()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", "usuarioActual");
        }

        
        
    }

}
