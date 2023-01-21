﻿using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.DTO;

namespace SampleProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        public async Task<ActionResult> Create(ProductDTO request)
        {
            try
            {
                var result = await _mediator.Send(new Application.Products.Create.Request(request.Title, request.Type, request.Price, request.Color));
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Edit")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult> Edit(UpdateProduct request)
        {
            try
            {
                var result = await _mediator.Send(new Application.Products.Update.Request(request.Id, request.Title, request.Type, request.Price, request.Color));
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new Application.Products.Delete.Request(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/products")]
        public async Task<ActionResult> GetProducts(int pageSize, int pageNumber)
        {
            try
            {
                var result = await _mediator.Send(new Application.Products.GetPagination.Request { PageSize = pageSize, PageNumber = pageNumber });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/products/search")]
        public async Task<ActionResult> FindProducts(int pageSize, int pageNumber, int type, int color)
        {
            try
            {

                var ret = await _mediator.Send(new Application.Products.SearchPagination.Request() { Type = type, Color = color, PageSize = pageSize, PageNumber = pageNumber });
                return Ok(ret);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
