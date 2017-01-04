using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TypeLite;

namespace TechHome.Webs.WebSpider.Models
{
    [TsClass(Module = "Models")]
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Ended { get; set; }
        public int ListId { get; set; }
    }
}
