using IMS.DF.BL;
using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL
{
    public class StateBL:IStateBL
    {
        private IStateDL _StateDL;

        public StateBL(IStateDL StateDL)
        {
            _StateDL = StateDL;
        }

        public StateVM AddState(StateVM c)
        {
            return _StateDL.AddState(c);
        }

        public int DeleteState(int StateId)
        {
            return _StateDL.DeleteState(StateId);
        }

        public StateVM EditState(StateVM c)
        {
            return _StateDL.EditState(c);
        }

        public StateVM GetStateById(int StateId)
        {
            return _StateDL.GetStateById(StateId);
        }

        public IList<StateVM> GetStateList()
        {
            return _StateDL.GetStateList();
        }
    }
}
