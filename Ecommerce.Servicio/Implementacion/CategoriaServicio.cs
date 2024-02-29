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
    public class CategoriaServicio : ICategoriaServicio
    {
        //Solo trabajaremos con el modelo usuario
        private readonly IGenericoRepositorio<Categoria> _modeloRepositorio;
        private readonly IMapper _mapper;

        public CategoriaServicio(IGenericoRepositorio<Categoria> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> Crear(CategoriaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Categoria>(modelo);//Vamos a convertir un usuario
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdCategoria != 0)
                    return _mapper.Map<CategoriaDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se puede crear!!");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoria == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                //Si encontro un usuario
                if (fromDbModelo != null)
                {
                    var respuesta = await _modeloRepositorio.Eliminar(fromDbModelo);
                    if (!respuesta)
                        throw new TaskCanceledException("No se puedo eliminar");

                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Editar(CategoriaDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoria == modelo.IdCategoria);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    //Procedemos a modificar
                    fromDbModelo.Nombre = modelo.Nombre;
                   
                    var respuesta = await _modeloRepositorio.Modificar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se puedo editar");
                    return respuesta;
                }
                else
                    throw new TaskCanceledException("No se encontraron resultado");

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CategoriaDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>p.Nombre.Contains(buscar.ToLower())
               );

                List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CategoriaDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoria == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<CategoriaDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
