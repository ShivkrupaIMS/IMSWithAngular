using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DF.DL
{
    public interface IItemTypeDL
    {
        IList<ItemTypeVM> GetItemTypeList();
        ItemTypeVM AddItemType(ItemTypeVM c);
        ItemTypeVM EditItemType(ItemTypeVM c);
        int DeleteItemType(int ItemTypeId);
        ItemTypeVM GetItemTypeById(int id);
    }
}
