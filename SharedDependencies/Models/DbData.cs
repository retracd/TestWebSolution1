using System.ComponentModel.DataAnnotations;

namespace SharedDependencies.Models {
    public class DbData {
        public int id { get; set; }
        [StringLength(50)]
        public string? fName { get; set; }
        [StringLength(50)]
        public string? lName { get; set; }
        [StringLength(30)]
        public string? state { get; set; }
        [StringLength(60)]
        public string? country { get; set; }
    }
}
