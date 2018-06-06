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
    public class ItemUnitBL:IItemUnitBL
    {
        private IItemUnitDL _ItemUnitDL;

        public ItemUnitBL(IItemUnitDL ItemUnitDL)
        {
            _ItemUnitDL = ItemUnitDL;
        }

        public ItemUnitVM AddItemUnit(ItemUnitVM c)
        {
            return _ItemUnitDL.AddItemUnit(c);
        }

        public int DeleteItemUnit(int ItemUnitId)
        {
            return _ItemUnitDL.DeleteItemUnit(ItemUnitId);
        }

        public ItemUnitVM EditItemUnit(ItemUnitVM c)
        {
            return _ItemUnitDL.EditItemUnit(c);
        }

        public ItemUnitVM GetItemUnitById(int ItemUnitId)
        {
            return _ItemUnitDL.GetItemUnitById(ItemUnitId);
        }

        public IList<ItemUnitVM> GetItemUnitList()
        {
            return _ItemUnitDL.GetItemUnitList();
        }
    }
}
