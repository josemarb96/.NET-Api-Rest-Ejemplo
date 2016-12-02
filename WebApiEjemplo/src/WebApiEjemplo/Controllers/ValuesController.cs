﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL.Listado;
using BL.Manejadora;
using ENT;

namespace WebApiEjemplo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            return new clsListados_BL().getListadoPersonasBL();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            return new clsManejadora_BL().selectPersonaBL(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]clsPersona value)
        {
            new clsManejadora_BL().insertarPersonaBL(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]clsPersona value)
        {
            new clsManejadora_BL().updatePersonaBL(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new clsManejadora_BL().deletePersonaBL(id);
        }
    }
}
