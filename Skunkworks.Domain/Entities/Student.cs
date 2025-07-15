using Skunkworks.Domain.Base;
namespace Skunkworks.Domain.Entities;

public  class Student: BaseClass
{
    public Profile? StudentProfile { get; set; } 
    //public List<Module>? Modules { get; set; }
    public List<Course>? Courses { get; set; }
}
