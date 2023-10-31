using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entidades;
using Core.Especificaciones;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly IRepositorio<Orden> _repo;
        private readonly IMapper _mapper;
        
        public OrdenController(IRepositorio<Orden> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrdenDto>>> GetAll()
        { 
            return Ok(_mapper.Map<IReadOnlyList<Orden>, IReadOnlyList<OrdenDto>>(await _repo.GetAllEspecification(new OrdenesConProductosUsuariosEspecificacion())));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDto>> Get(int id)
        {
            return _mapper.Map<Orden, OrdenDto>(await _repo.GetEspecification(new OrdenesConProductosUsuariosEspecificacion(id)));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(Orden orden)
        {
            return await _repo.Create(orden);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(Orden orden)
        {
            return await _repo.Update(orden);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _repo.Delete(id);
        }
    }
}