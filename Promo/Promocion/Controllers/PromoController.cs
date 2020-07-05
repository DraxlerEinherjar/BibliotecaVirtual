using Promocion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Promocion.Controllers
{
    public class PromoController : ApiController
    {
        // GET: api/Promo
        public IEnumerable<Models.Promocion> Get()
        {
            using (PromocionEntities db = new PromocionEntities())
            {
                return db.Promocion.ToList();
            }
        }

        // GET: api/Promo/5
        public Models.Promocion Get(int id)
        {
            using (PromocionEntities db = new PromocionEntities())
            {
                return db.Promocion.Where(w => w.Id == id).FirstOrDefault();
            }
        }

        // POST: api/Promo
        public HttpResponseMessage Post([FromBody] Models.Promocion value)
        {
            int res = 0;
            HttpResponseMessage msj = null;
            try
            {
                using (PromocionEntities db = new PromocionEntities())
                {
                    db.Entry(value).State = EntityState.Added;
                    res = db.SaveChanges();
                    msj = Request.CreateResponse(HttpStatusCode.OK, res);
                }
            }
            catch (Exception ex)
            {
                msj = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msj;
        }

    }
}
