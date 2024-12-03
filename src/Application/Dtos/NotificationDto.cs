using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class NotificationDto
    {
        public DataDto Data { get; set; }
    }
       
    public class DataDto
    {
        public string Id { get; set; }
    }
    
}
