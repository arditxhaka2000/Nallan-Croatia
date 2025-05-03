using Data.Privileges;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Privileges
{
    public interface IActionRootService
    {
        List<ActionRoot> GetAll();
        ActionRoot GetById(string Id);
        ActionRoot GetById(Guid Id);
      
    }
}
