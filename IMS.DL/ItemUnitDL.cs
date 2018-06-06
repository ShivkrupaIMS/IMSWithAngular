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
    public class ItemUnitDL : BaseDL, IItemUnitDL
    {
        public ItemUnitVM AddItemUnit(ItemUnitVM c)
        {
            DB.tblItemUnit ItemUnit = IMSDB.tblItemUnits.Add(
                new DB.tblItemUnit
                {
                    ItemUnit = c.ItemUnit,
                    IsActive = c.IsActive
                });
            IMSDB.SaveChanges();
            c.ItemUnitId = ItemUnit.ItemUnitId;
            return c;
        }

        public int DeleteItemUnit(int ItemUnitId)
        {
            IMSDB.tblItemUnits.Remove(IMSDB.tblItemUnits.Where(p => p.ItemUnitId == ItemUnitId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public ItemUnitVM EditItemUnit(ItemUnitVM c)
        {
            DB.tblItemUnit ItemUnit = IMSDB.tblItemUnits.Find(c.ItemUnitId);
            ItemUnit.ItemUnit = c.ItemUnit;
            ItemUnit.IsActive = c.IsActive;
            IMSDB.Entry(ItemUnit).State = EntityState.Modified;
            IMSDB.SaveChanges();
            return c;
        }

        public ItemUnitVM GetItemUnitById(int ItemUnitId)
        {
            DB.tblItemUnit ItemUnit = IMSDB.tblItemUnits.Where(p => p.ItemUnitId == ItemUnitId).FirstOrDefault();
            return new ItemUnitVM()
            {
                ItemUnitId = ItemUnit.ItemUnitId,
                ItemUnit = ItemUnit.ItemUnit,
                IsActive = ItemUnit.IsActive
            };

        }

        public IList<ItemUnitVM> GetItemUnitList()
        {
            List<ItemUnitVM> itemUnitList = new List<ItemUnitVM>();
            IMSDB.tblItemUnits.ToList().ForEach(p => itemUnitList.Add(
                    new ItemUnitVM()
                    {
                        ItemUnitId = p.ItemUnitId,
                        ItemUnit = p.ItemUnit,
                        IsActive = p.IsActive
                    }
                    ));
            return itemUnitList;
        }
    }
}
