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
    public class ItemTypeDL : BaseDL, IItemTypeDL
    {
        public ItemTypeVM AddItemType(ItemTypeVM c)
        {
            DB.tblItemType ItemType = IMSDB.tblItemTypes.Add(
                new DB.tblItemType
                {
                    ItemType = c.ItemType,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.ItemTypeId = ItemType.ItemTypeId;
            return c;
        }

        public int DeleteItemType(int ItemTypeId)
        {
            IMSDB.tblItemTypes.Remove(IMSDB.tblItemTypes.Where(p => p.ItemTypeId == ItemTypeId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public ItemTypeVM EditItemType(ItemTypeVM c)
        {
            DB.tblItemType ItemType = IMSDB.tblItemTypes.Find(c.ItemTypeId);
            if (ItemType != null)
            {
                ItemType.ItemType = c.ItemType;
                ItemType.IsActive = c.IsActive;
                IMSDB.Entry(ItemType).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public ItemTypeVM GetItemTypeById(int ItemTypeId)
        {
            DB.tblItemType ItemType = IMSDB.tblItemTypes.Where(p => p.ItemTypeId == ItemTypeId).FirstOrDefault();
            if(ItemType!=null)
            {
                return new ItemTypeVM()
                {
                    ItemTypeId = ItemType.ItemTypeId,
                    ItemType = ItemType.ItemType,
                    IsActive = ItemType.IsActive
                };
            }

            return null;
        }

        public IList<ItemTypeVM> GetItemTypeList()
        {
            List<ItemTypeVM> itemTypeList = new List<ItemTypeVM>();
            List<DB.tblItemType> itemTypes = IMSDB.tblItemTypes.ToList();
            if(itemTypes!=null)
            {
                itemTypes.ForEach(p => itemTypeList.Add(
                    new ItemTypeVM()
                    {
                        ItemTypeId = p.ItemTypeId,
                        ItemType = p.ItemType,
                        IsActive = p.IsActive
                    }
                    ));
            }
            
            return itemTypeList;
        }
    }
}
