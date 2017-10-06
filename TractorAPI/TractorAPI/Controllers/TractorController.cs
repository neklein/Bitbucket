using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TractorAPI.Models;

namespace TractorAPI.Controllers
{
    public class TractorController : ApiController
    {
        [Route("tractors/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(TractorRepo.GetAll());
        }

        [Route("tractors/get")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int tractorID)
        {
            Tractor tractor = TractorRepo.Get(tractorID);

            if(tractor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tractor);
            }
        }

        [Route("tractors/get/{tractorPathId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetPathID(int tractorPathId)
        {
            Tractor tractor = TractorRepo.Get(tractorPathId);

            if (tractor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tractor);
            }

        }

        [Route("tractors/add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddTractorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Tractor tractor = new Tractor()
                {
                    TractorName = request.Name,
                    TractorDriver = request.Driver,
                    TractorClass = request.TClass
                };

                TractorRepo.Add(tractor);

                return Created($"tractors/get/{tractor.TractorID}", tractor);
            }
        }

        [Route("tractors/update")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(UpdateTractorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            Tractor tractor = TractorRepo.Get(request.updateID);
            if(tractor == null)
            {
                return NotFound();
            }

            tractor.TractorName = request.Name;
            tractor.TractorDriver = request.Driver;
            tractor.TractorClass = request.TClass;

            TractorRepo.Edit(tractor);

            return Created($"tractors/get/{tractor.TractorID}", tractor);

        }

        [Route("tractor/delete/{tractorID}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int tractorID)
        {
            Tractor tractor = TractorRepo.Get(tractorID);

            if(tractor == null)
            {
                return NotFound();
            }

            TractorRepo.Delete(tractorID);
            return Ok();
        }

    }
}