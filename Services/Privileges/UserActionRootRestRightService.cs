using Data.Privileges;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Privileges
{
    public class UserActionRootRestRightService : IUserActionRootRestRightService
    {
        private readonly IRepository<UserActionRootRestRight> _repo;

        public UserActionRootRestRightService(IRepository<UserActionRootRestRight> repo)
        {
            _repo = repo;
        }

        public UserActionRootRestRight Create(UserActionRootRestRight item)
        {
            _repo.Insert(item);
            return item;
        }

        public List<UserActionRootRestRight> GetAll()
        {
            return _repo.GetAll();
        }

        public IQueryable<UserActionRootRestRight> GetAll(string RoleId)
        {
            string[] includes = { "ActionRoot" };
            return this._repo.Get(filter: x => x.IdentityRoleId == RoleId, includeProperties: includes, orderBy: c => c.OrderBy(v => v.ActionRoot.TypeId)).AsQueryable();
        }

        public UserActionRootRestRight GetById(string Id)
        {
            return this._repo.GetById(Id.ToString());
        }

        public UserActionRootRestRight GetByUserId(string UserId, Guid ComplaintTabId)
        {
            return this._repo.Get(filter: x => x.IdentityRoleId == UserId && x.ActionRootId == ComplaintTabId).FirstOrDefault();
        }

        public bool InsertRange(List<UserActionRootRestRight> items)
        {
            foreach (var Item in items)
            {
                Create(Item);
            }
            return true;
        }

        public bool SaveChanges()
        {
            this._repo.SaveChanges();
            return true;
        }

        public bool Update(UserActionRootRestRight item)
        {
            _repo.Update(item);
            return true;
        }

        public bool UpdateRange(IEnumerable<UserActionRootRestRight> items)
        {
            foreach (var Item in items)
            {
                Update(Item);
            }
            return true;
        }
    }
}
