using System.Collections.Generic;

namespace SRM.Services.Contracts.StudentGroups
{
    public class GetStudentGroupsResponse : BaseContractResponse
    {
        public ICollection<StudentGroupModel> StudentGroups { get; set; }
    }
}
