using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Modelo;
using Ecommerce.DTO;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Servicio.Contrato;
using AutoMapper;
namespace Ecommerce.Servicio.Implementacion
{
    public class DashboardServicio :IDashboardServicio
    {
        //Solo trabajaremos con el modelo usuario
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IGenericoRepositorio<Producto> _productoRepositorio;
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IMapper _mapper;

        public DashboardServicio(IGenericoRepositorio<Usuario> usuarioRepositorio,
            IGenericoRepositorio<Producto> productoRepositorio,
            IVentaRepositorio ventaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;
            _ventaRepositorio = ventaRepositorio;
        }
        private string Ingresos()
        {
            var consulta = _ventaRepositorio.Consultar();
            decimal? Ingresos = consulta.Sum(x => x.Total);//Realizamos la suma de los ingresos
            return Convert.ToString(Ingresos);
        }
        public int Ventas()
        {
            var consulta = _ventaRepositorio.Consultar();
            int total = consulta.Count();//Para obtener el total de ventas
            return total;
        }
        public int Clientes()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol.ToLower() == "cliente");
            int total = consulta.Count(); //Para obtener el total de ventas
            return total;
        }
        public int Productos()
        {
            var consulta = _productoRepositorio.Consultar();
            int total = consulta.Count(); //Para obtener el total de productos
            return total;
        }
        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalVentas = Ventas(),
                    TotalClientes = Clientes(),
                    TotalProductos = Productos()
                };
                return dto;//Nos devulve estos datos al admi
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
