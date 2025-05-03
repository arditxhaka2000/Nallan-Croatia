using Data;
using Data.Privileges;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Privileges
{
    public class ActionRootService : IActionRootService
    {
        private IRepository<ActionRoot> _repo;

        public ActionRootService(IRepository<ActionRoot> repository)
        {
            _repo = repository;
        }
         
        public List<ActionRoot> GetAll()
        {
            return this._repo.GetAll();
        }

        public ActionRoot GetById(Guid Id)
        {
            return this._repo.GetById(Id.ToString());
        }
        public ActionRoot GetById(string Id)
        {
            return this._repo.GetById(Id.ToString());
        }
         
    }
}
