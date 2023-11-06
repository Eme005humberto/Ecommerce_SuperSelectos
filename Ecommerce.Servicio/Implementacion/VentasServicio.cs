﻿using System;
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
    public class VentasServicio : IVentaServicio
    {
        //Solo trabajaremos con el modelo usuario
        private readonly IVentaRepositorio _modeloRepositorio;
        private readonly IMapper _mapper;

        public VentasServicio(IVentaRepositorio modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Venta>(modelo);//Vamos a convertir un usuario
                var ventaGenerada = await _modeloRepositorio.Registrar(dbModelo);

                if (ventaGenerada.IdVenta != 0)
                    throw new TaskCanceledException("No se puedo registrar");
                return _mapper.Map<VentaDTO>(ventaGenerada);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
