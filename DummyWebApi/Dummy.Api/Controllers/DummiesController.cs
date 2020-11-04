using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using bl = Dummy.Business.Dummies;
using dto = Dummy.DTO;
using model = Dummy.Model;

namespace Dummy.Api.Controllers
{
    /// <summary>
    /// Allows access to Dummies CRUD
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class DummiesController : ControllerBase
    {
        private readonly bl.IDummy dummyBL;
        private readonly IMapper mapper;
        /// <summary>
        /// Dummies controller
        /// </summary>
        /// <param name="dummy"></param>
        /// <param name="mapper"></param>
        public DummiesController(bl.IDummy dummy, IMapper mapper)
        {
            this.dummyBL = dummy;
            this.mapper = mapper;
        }
        // GET: api/Dummies
        /// <summary>
        /// Allows to get all Dummies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<dto.Dummy>), 200)]
        public IEnumerable<dto.Dummy> Get()
        {

            return mapper.Map<List<dto.Dummy>>(dummyBL.GetDummies());
        }

        // GET: api/Dummies/5
        /// <summary>
        /// Allows to get a Dummy by an ID
        /// </summary>
        /// <param name="id">Dummy ID</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(dto.Dummy), 200)]
        public dto.Dummy GetById(string id)
        {
            return mapper.Map<dto.Dummy>(dummyBL.GetDummyById(id));
        }

        // POST: api/Dummies
        /// <summary>
        /// Allows to create new Dummies
        /// </summary> 
        /// <param name="value">Dummy object</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(dto.Dummy), 201)]
        public IActionResult Post([FromBody] dto.Dummy value)
        {
            model.Dummy dummy = mapper.Map<model.Dummy>(value);

            value = mapper.Map<dto.Dummy>(dummyBL.Create(dummy));

            return Created(String.Format("api/{0}/{1}", "Dummies", dummy?.Id), value);
        }

        // PUT: api/Dummies/5
        /// <summary>
        /// Allows to update a Dummy by id
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>       
        /// <response code="200">Returns Dummy updated</response>
        [HttpPut]
        [ProducesResponseType(typeof(dto.Dummy), 200)]
        public IActionResult Put([FromBody] dto.Dummy value)
        {
            model.Dummy dummy = mapper.Map<model.Dummy>(value);
            value = mapper.Map<dto.Dummy>(dummyBL.UpdateById(dummy));
            return Ok(value);
        }

        // DELETE api/Dummies/5
        /// <summary>
        /// Allows to delete Dummy by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>       
        /// <response code="200">Returns Dummy updated</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(dummyBL.DeleteDummyById(id));
        }

    }
}