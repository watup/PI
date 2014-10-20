using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI.Models
{
    [MetadataType(typeof(WardMetadata))]
    public partial class Ward
    {
    }

    public class WardMetadata
    {
        [Required]
        public string Name { get; set; }
    }
}
