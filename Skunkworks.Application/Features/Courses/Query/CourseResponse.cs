
namespace Skunkworks.Application.Features.Courses.Query;

public  class CourseResponse
{
   public Guid Id { get;set; }
   public  string Name{ get; set; }= string.Empty;
    public string PreRequisites { get; set; } = string.Empty;
}
