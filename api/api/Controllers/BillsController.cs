using domain.Model.Contracts.Enumerators;
using domain.Model.Contracts.Interfaces;
using domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace api.Controllers
{
    public class BillsController : ApiController
    {
        private readonly IBillsRepository BillsRepository;

        public BillsController(IBillsRepository billsRepository)
        {
            this.BillsRepository = billsRepository;
        }

        // GET: api/Bills
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(this.BillsRepository.List());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET: api/Bills/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(this.BillsRepository.Get(id));
            }
            catch 
            {
                return NotFound();
            }
        }

        // POST: api/Bills
        public IHttpActionResult Post([FromBody]Bill bill)
        {
            try
            {
                return Ok(BillsRepository.Create(bill));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Bills/5
        public IHttpActionResult Put(int id, [FromBody]Bill bill)
        {
            try
            {
                bill.Id = id;
                this.BillsRepository.Update(bill);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Bills/5
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
