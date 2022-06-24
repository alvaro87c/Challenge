using API.DTO;
using AutoMapper;
using CORE.Entidades;
using CORE.Interfaces;
using Infraestructura.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Authorize(Roles = "Empleado")]
public class ClientesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ClientesController (IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
    {
        var clientes = await _unitOfWork.Clientes
                            .GetAllAsync();

        return _mapper.Map<List<ClienteDTO>>(clientes);

    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDTO>> Get(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return _mapper.Map<ClienteDTO>(cliente);
    }

    //POST: api/Clientes
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post(ClienteAddUpdateDTO clienteDTO)
    {
        var cliente = _mapper.Map<Cliente>(clienteDTO);
        _unitOfWork.Clientes.Add(cliente);
        await _unitOfWork.Save();
        if (cliente == null)
        {
            return BadRequest();

        }
        clienteDTO.Id = cliente.Id;
        return CreatedAtAction(nameof(Post), new {id= clienteDTO.Id}, clienteDTO);
    }


    //PUT: api/Clientes/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteAddUpdateDTO>> Put(int id, [FromBody] ClienteAddUpdateDTO clienteDTO)
    {
        
        if (clienteDTO == null)
        {
            return NotFound();

        }
        var cliente = _mapper.Map<Cliente>(clienteDTO);
        _unitOfWork.Clientes.Update(cliente);
        await _unitOfWork.Save();
        return clienteDTO;
    }

    //DELETE: api/Clientes/
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }
        _unitOfWork.Clientes.Remove(cliente);
        await _unitOfWork.Save();
        return NoContent();
    }
}
