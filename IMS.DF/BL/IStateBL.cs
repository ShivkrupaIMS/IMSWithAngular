using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.BL
{
    public interface IStateBL
    {
        IList<StateVM> GetStateList();
        StateVM AddState(StateVM c);
        StateVM EditState(StateVM c);
        int DeleteState(int StateId);
        StateVM GetStateById(int id);
    }
}
