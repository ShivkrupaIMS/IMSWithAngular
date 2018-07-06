using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IItemDL
    {
        IList<ItemVM> GetItemList();
        ItemVM AddItem(ItemVM c);
        ItemVM EditItem(ItemVM c);
        int DeleteItem(int ItemId);
        ItemVM GetItemById(int id);
    }
}
