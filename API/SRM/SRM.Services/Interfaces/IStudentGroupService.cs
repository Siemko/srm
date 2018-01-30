using SRM.Services.Contracts;
using SRM.Services.Contracts.StudentGroups;

namespace SRM.Services.Interfaces
{
    public interface IStudentGroupService
    {
        GetStudentGroupsResponse Get();
    }
}
