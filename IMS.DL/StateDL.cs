using IMS.DF.DL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DL
{
    public class StateDL : BaseDL, IStateDL
    {
        public StateVM AddState(StateVM c)
        {
            DB.tblState State = IMSDB.tblStates.Add(
                new DB.tblState
                {
                    //StateCode = c.StateCode,
                    StateName = c.StateName,
                    CountryId = c.Country.CountryId,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.StateId = State.StateId;
            return c;
        }

        public int DeleteState(int StateId)
        {
            IMSDB.tblStates.Remove(IMSDB.tblStates.Where(p => p.StateId == StateId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public StateVM EditState(StateVM c)
        {
            DB.tblState State = IMSDB.tblStates.Find(c.StateId);
            State.StateName = c.StateName;
            State.CountryId = c.Country.CountryId;
            //State.StateCode = c.StateCode;
            State.IsActive = c.IsActive;
            IMSDB.Entry(State).State = EntityState.Modified;
            IMSDB.SaveChanges();
            return c;
        }

        public StateVM GetStateById(int StateId)
        {
            DB.tblState State = IMSDB.tblStates.Where(p => p.StateId == StateId).FirstOrDefault();
            return new StateVM()
            {
                StateId = State.StateId,
                StateName = State.StateName,
                //StateCode = State.StateCode,
                Country = new CountryVM { CountryId = State.tblCountry.CountryId,CountryCode= State.tblCountry.CountryCode, CountryName = State.tblCountry.CountryName, IsActive = State.tblCountry.IsActive},
                IsActive = State.IsActive
            };

        }

        public IList<StateVM> GetStateList()
        {
            List<StateVM> StateList = new List<StateVM>();
            IMSDB.tblStates.ToList().ForEach(p => StateList.Add(
                    new StateVM()
                    {
                        StateId = p.StateId,
                        StateName = p.StateName,
                        //StateCode = p.StateCode,
                        Country = new CountryVM { CountryId = p.tblCountry.CountryId, CountryCode = p.tblCountry.CountryCode, CountryName = p.tblCountry.CountryName, IsActive = p.tblCountry.IsActive },
                        IsActive = p.IsActive
                    }
                    ));
            return StateList;
        }
    }
}
