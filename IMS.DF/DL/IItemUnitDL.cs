using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IItemUnitDL
    {
        IList<ItemUnitVM> GetItemUnitList();
        ItemUnitVM AddItemUnit(ItemUnitVM c);
        ItemUnitVM EditItemUnit(ItemUnitVM c);
        int DeleteItemUnit(int ItemUnitId);
        ItemUnitVM GetItemUnitById(int id);
    }
}
