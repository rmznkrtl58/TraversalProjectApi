using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using System.Linq;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
    [EnableCors]//startup kullanımında cors yapılandırmasını yapmıştım buradada kullanıyorum
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        //200->başarılı(Ok) 404->bulunamadı(Not Found)
        [HttpGet]
        public IActionResult GetListVisitor()
        {
            
            using (var ent=new VisitorContext())
            {
                var values = ent.Visitors.ToList();
                return Ok(values);
            }
            
        }
        [HttpPost]
        public IActionResult GetListVisitor(Visitor v)
        {
            using (var ent = new VisitorContext())
            {
                ent.Visitors.Add(v);
                ent.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetVisitorById(int id)
        {
            using (var ent=new VisitorContext() )
            {
                var findVisitor = ent.Visitors.Find(id);
                if (findVisitor == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(findVisitor);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var ent=new VisitorContext())
            {
                var findVisitor =ent.Visitors.Find(id);
                if (findVisitor == null)
                {
                    return NotFound();
                }
                else
                {
                    ent.Visitors.Remove(findVisitor);
                    ent.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateVisitor(Visitor v)
        {
            using (var ent=new VisitorContext())
            {
                var findVisitor=ent.Visitors.Find(v.VisitorId);
                if (findVisitor == null)
                {
                    return NotFound();
                }
                else
                {
                    findVisitor.Surname = v.Surname;
                    findVisitor.Name = v.Name;
                    findVisitor.City = v.City;
                    findVisitor.Country = v.Country;
                    findVisitor.Mail= v.Mail;
                    ent.Visitors.Update(findVisitor);
                    ent.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
