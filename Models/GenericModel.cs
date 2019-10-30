using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Banco.Services.Models
{
    [DataContract]
    public abstract class GenericModel
    {
        [DataMember]
        public int Id { get; set; }
    }
}
