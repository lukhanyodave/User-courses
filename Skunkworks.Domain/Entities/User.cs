

using Skunkworks.Domain.Base;

namespace Skunkworks.Domain.Entities;

public  class User : BaseClass
{ 
        public string Email { get; set; } = string.Empty;
        public bool IsTeacher { get; set; }
   
}
