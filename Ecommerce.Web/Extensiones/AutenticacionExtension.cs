using Ecommerce.DTO;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Linq.Expressions;

namespace Ecommerce.Web.Extensiones
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _sininformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacionExtension(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public async Task ActualizarEstadoAutenticacion(SesionDTO? sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;
            if(sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name,sesionUsuario.NombreCompleto),
                    new Claim(ClaimTypes.Email,sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role,sesionUsuario.Rol),
                },"JwtAuth"));
                await _localStorageService.SetItemAsync("sesionUsuario", sesionUsuario);
            }
            else
            {
                claimsPrincipal = _sininformacion;
                await _localStorageService.RemoveItemAsync("sesionUsuario");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _localStorageService.GetItemAsync<SesionDTO>("sesionUsuario");

            if (sesionUsuario == null)
                return await Task.FromResult(new AuthenticationState(_sininformacion));

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,sesionUsuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name,sesionUsuario.NombreCompleto),
                new Claim(ClaimTypes.Email,sesionUsuario.Correo),
                new Claim(ClaimTypes.Role,sesionUsuario.Rol)
            },"JwtAuth"));
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
    }
}
