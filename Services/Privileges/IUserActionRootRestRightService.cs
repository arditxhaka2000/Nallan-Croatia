using Data.Privileges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Privileges
{
    public interface IUserActionRootRestRightService
    {
        List<UserActionRootRestRight> GetAll();
        IQueryable<UserActionRootRestRight> GetAll(string RoleId); 
        UserActionRootRestRight GetById(string Id);

        UserActionRootRestRight GetByUserId(string UserId, Guid ComplaintTabId);
        UserActionRootRestRight Create(UserActionRootRestRight item);
        bool InsertRange(List<UserActionRootRestRight> items);
        bool Update(UserActionRootRestRight item);
        bool UpdateRange(IEnumerable<UserActionRootRestRight> items);
        bool SaveChanges();

    }
}
