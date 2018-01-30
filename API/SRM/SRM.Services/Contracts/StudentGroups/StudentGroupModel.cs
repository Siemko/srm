using SRM.Core.Entities;

namespace SRM.Services.Contracts.StudentGroups
{
    public class StudentGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudentGroupModel(StudentGroup studentGroup)
        {
            Id = studentGroup.Id;
            Name = studentGroup.Name;
        }
    }
}
