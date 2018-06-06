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
    public class ItemTypeBL:IItemTypeBL
    {
        private IItemTypeDL _ItemTypeDL;

        public ItemTypeBL(IItemTypeDL ItemTypeDL)
        {
            _ItemTypeDL = ItemTypeDL;
        }

        public ItemTypeVM AddItemType(ItemTypeVM c)
        {
            return _ItemTypeDL.AddItemType(c);
        }

        public int DeleteItemType(int ItemTypeId)
        {
            return _ItemTypeDL.DeleteItemType(ItemTypeId);
        }

        public ItemTypeVM EditItemType(ItemTypeVM c)
        {
            return _ItemTypeDL.EditItemType(c);
        }

        public ItemTypeVM GetItemTypeById(int ItemTypeId)
        {
            return _ItemTypeDL.GetItemTypeById(ItemTypeId);
        }

        public IList<ItemTypeVM> GetItemTypeList()
        {
            return _ItemTypeDL.GetItemTypeList();
        }
    }
}
