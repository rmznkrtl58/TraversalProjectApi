using System.ComponentModel.DataAnnotations;

namespace TraversalApiProject.DAL.Entities
{
    public class Visitor
    {
        public int VisitorId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Surname { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [StringLength(30)]
        public string Country { get; set; }
        [StringLength(30)]
        public string Mail { get; set; }
    }
}
