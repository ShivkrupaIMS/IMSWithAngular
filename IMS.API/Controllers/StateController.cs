using IMS.DF.BL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMS.API.Controllers
{
    public class StateController : ApiController
    {
        private IStateBL _StateBL;

        public StateController(IStateBL StateBL)
        {
            _StateBL = StateBL;
        }

        [HttpPost]
        public StateVM AddState(StateVM c)
        {
            return _StateBL.AddState(c);
        }
        [HttpPost]
        public int DeleteState(StateVM c)
        {
            return _StateBL.DeleteState(c.StateId);
        }
        [HttpPost]
        public StateVM EditState(StateVM c)
        {
            return _StateBL.EditState(c);
        }

        public StateVM GetStateById(int StateId)
        {
            return _StateBL.GetStateById(StateId);
        }

        public IList<StateVM> GetStateList()
        {
            return _StateBL.GetStateList();
        }
    }
}
