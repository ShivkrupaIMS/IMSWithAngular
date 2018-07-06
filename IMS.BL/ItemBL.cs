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
    public class ItemBL : IItemBL
    {
        private IItemDL _ItemDL;

        public ItemBL(IItemDL ItemDL)
        {
            _ItemDL = ItemDL;
        }

        public ItemVM AddItem(ItemVM c)
        {
            return _ItemDL.AddItem(c);
        }

        public int DeleteItem(int ItemId)
        {
            return _ItemDL.DeleteItem(ItemId);
        }

        public ItemVM EditItem(ItemVM c)
        {
            return _ItemDL.EditItem(c);
        }

        public ItemVM GetItemById(int ItemId)
        {
            return _ItemDL.GetItemById(ItemId);
        }

        public IList<ItemVM> GetItemList()
        {
            return _ItemDL.GetItemList();
        }
    }
}
