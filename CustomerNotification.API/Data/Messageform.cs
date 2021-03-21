using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CustomerNotification.API.Models;

namespace CustomerNotification.API.Data
{
    
    public class UserData
    {
        [Required]
        [StringLength(20)]
        public string UserId { get; set; }
       
    }
    public class NewUserRegistered
    {
        [Required]
        [StringLength(20)]        
        public string messageType { get; set; }
        public Message data { get; set; }

    }
    public class UserDeleted
    {
        [Required]
        [StringLength(20)]
        public string messageType { get; set; }

        public UserData data { get; set; }       
     
    }
    public class UserBlocked
    {
        [Required]
        [StringLength(20)]
        public string messageType { get; set; }
        public UserData data { get; set; }
    }

}
