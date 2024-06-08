using BF_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF_Core.DTOs
{
    public class UserDTO
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Partfolio { get; set; }


        public static implicit operator UserDTO(User other)=>
            new() 
            { 
                Id = other.Id, 
                Name = other.Name, 
                Partfolio = other.Partfolio 
            };
    }
}
