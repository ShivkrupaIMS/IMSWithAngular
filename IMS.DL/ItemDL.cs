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
    public class ItemDL : BaseDL, IItemDL
    {
        public ItemVM AddItem(ItemVM c)
        {
            DB.tblItem Item = IMSDB.tblItems.Add(
                new DB.tblItem
                {
                   ItemName =c.ItemName,
                   ItemTypeId = c.ItemType.ItemTypeId,
                   Ingredient = c.Ingredient,
                   HsnSacId = c.HSNCode.HSNSACId,
                   SGST=c.SGST,
                   CGST=c.CGST,
                   IGST=c.IGST,
                   Comment=c.Comment,
                   Description=c.Description,
                   IsActive = c.IsActive
                });

            c.ItemDetails.ForEach(p =>
                IMSDB.tblItemDetails.Add(
                    new DB.tblItemDetail
                    {
                       Discount = p.Discount,
                       ItemUnitId = p.ItemUnit.ItemUnitId,
                       ManufacturerId=p.Manufacturer.ManufacturerId,
                       MinQuantity = p.MinQuantity,
                       MRP= p.MRP,
                       PurchasePrice = p.PurchasePrice, 
                       SalePrice=p.SalePrice,
                       Sku = p.SKU,
                       IsActive = p.IsActive,
                       tblItem = Item
                    })
                );
            c.Licenses.ForEach(p =>
                IMSDB.tblItemLicenseDetails.Add(
                    new DB.tblItemLicenseDetail
                    {
                        LicenseTypeId = p.LicenseTypeId,
                        IsActive = p.IsActive,
                        tblItem = Item
                    })
                );
            IMSDB.SaveChanges();
            c.ItemId = Item.ItemId;
            return c;
        }

        public int DeleteItem(int ItemId)
        {
            IMSDB.tblItemDetails.RemoveRange(IMSDB.tblItemDetails.Where(p => p.ItemId == ItemId));
            IMSDB.tblItems.Remove(IMSDB.tblItems.Where(p => p.ItemId == ItemId).FirstOrDefault());
            IMSDB.SaveChanges();
            return 1;
        }

        public ItemVM EditItem(ItemVM c)
        {
            DB.tblItem Item = IMSDB.tblItems.Find(c.ItemId);
            if (Item != null)
            {
                IMSDB.tblItemDetails.RemoveRange(IMSDB.tblItemDetails.Where(p => p.ItemId == c.ItemId));
                IMSDB.tblItemLicenseDetails.RemoveRange(IMSDB.tblItemLicenseDetails.Where(p => p.ItemId == c.ItemId));

                Item.ItemName = c.ItemName;
                Item.ItemTypeId = c.ItemType.ItemTypeId;
                Item.Ingredient = c.Ingredient;
                Item.HsnSacId = c.HSNCode.HSNSACId;
                Item.SGST = c.SGST;
                Item.CGST = c.CGST;
                Item.IGST = c.IGST;
                Item.Comment = c.Comment;
                Item.Description = c.Description;
                Item.IsActive = c.IsActive;

                c.ItemDetails.ForEach(p =>
                IMSDB.tblItemDetails.Add(
                    new DB.tblItemDetail
                    {
                        Discount = p.Discount,
                        ItemUnitId = p.ItemUnit.ItemUnitId,
                        ManufacturerId = p.Manufacturer.ManufacturerId,
                        MinQuantity = p.MinQuantity,
                        MRP = p.MRP,
                        PurchasePrice = p.PurchasePrice,
                        SalePrice = p.SalePrice,
                        Sku = p.SKU,
                        IsActive = p.IsActive,
                        tblItem = Item
                    })
                );
                c.Licenses.ForEach(p =>
                    IMSDB.tblItemLicenseDetails.Add(
                        new DB.tblItemLicenseDetail
                        {
                            LicenseTypeId = p.LicenseTypeId,
                            IsActive = p.IsActive,
                            tblItem = Item
                        })
                    );

                IMSDB.Entry(Item).State = EntityState.Modified;
                IMSDB.SaveChanges();
            }
            return c;
        }

        public ItemVM GetItemById(int ItemId)
        {
            DB.tblItem Item = IMSDB.tblItems.Where(p => p.ItemId == ItemId).FirstOrDefault();
            if (Item != null)
            {
                List<LicenseTypeVM> licenseList = new List<LicenseTypeVM>();
                List<ItemDetailsVM> itemDetailsList = new List<ItemDetailsVM>();
                Item.tblItemLicenseDetails.ToList().ForEach(p =>
                    licenseList.Add(new LicenseTypeVM {
                        LicenseType = p.tblLicenseType.LicenseType,
                        LicenseTypeId = p.LicenseTypeId,
                        IsActive = p.tblLicenseType.IsActive,
                        ShortName = p.tblLicenseType.ShortName,
                        Description = p.tblLicenseType.Description,
                    })
                );

                Item.tblItemDetails.ToList().ForEach(p =>
                    itemDetailsList.Add(new ItemDetailsVM
                    {
                        Description = p.Description,
                        Discount= (float) p.Discount,
                        ItemUnit = new ItemUnitVM {ItemUnit = p.tblItemUnit.ItemUnit, ItemUnitId = p.tblItemUnit.ItemUnitId, IsActive=p.tblItemUnit.IsActive},
                        Manufacturer = new ManufacturerVM { Description = p.tblManufacturer.Description, IsActive= p.tblManufacturer.IsActive, ManufacturerId=p.tblManufacturer.ManufacturerId, ManufacturerName=p.tblManufacturer.ManufacturerName, ShortName = p.tblManufacturer.ShortName},
                        IsActive = p.IsActive,
                        MinQuantity = p.MinQuantity,
                        MRP= (float)p.MRP,
                        PurchasePrice= (float)p.PurchasePrice,
                        SalePrice= (float)p.SalePrice,
                        SKU=p.Sku
                    })
                );

                return new ItemVM()
                {
                    ItemName = Item.ItemName,
                    ItemType = new ItemTypeVM { ItemType = Item.tblItemType.ItemType, ItemTypeId = Item.tblItemType.ItemTypeId, IsActive= Item.tblItemType.IsActive},
                    Ingredient = Item.Ingredient,
                    HSNCode = new HSNSACVM { HSNSACId = Item.tblHSNSAC.HSNSACId, HSNSACNo = Item.tblHSNSAC.HSNSACNo, TaxRate = Item.tblHSNSAC.TaxRate, IsActive = Item.tblHSNSAC.IsActive},
                    SGST = (float)Item.SGST,
                    CGST = (float)Item.CGST,
                    IGST = (float)Item.IGST,
                    Comment = Item.Comment,
                    Description = Item.Description,
                    IsActive = Item.IsActive,
                    Licenses  = licenseList,
                    ItemDetails = itemDetailsList
                };
            }
            return null;

        }

        public IList<ItemVM> GetItemList()
        {
            List<ItemVM> ItemList = new List<ItemVM>();
            List<DB.tblItem> items = IMSDB.tblItems.ToList();
            if (items != null)
            {
                items.ForEach(Item => {
                    List<LicenseTypeVM> licenseList = new List<LicenseTypeVM>();
                    List<ItemDetailsVM> itemDetailsList = new List<ItemDetailsVM>();
                    Item.tblItemLicenseDetails.ToList().ForEach(p =>
                       licenseList.Add(new LicenseTypeVM
                       {
                           LicenseType = p.tblLicenseType.LicenseType,
                           LicenseTypeId = p.LicenseTypeId,
                           IsActive = p.tblLicenseType.IsActive,
                           ShortName = p.tblLicenseType.ShortName,
                           Description = p.tblLicenseType.Description,
                       })
                   );

                    Item.tblItemDetails.ToList().ForEach(p =>
                        itemDetailsList.Add(new ItemDetailsVM
                        {
                            Description = p.Description,
                            Discount = (float)p.Discount,
                            ItemUnit = new ItemUnitVM { ItemUnit = p.tblItemUnit.ItemUnit, ItemUnitId = p.tblItemUnit.ItemUnitId, IsActive = p.tblItemUnit.IsActive },
                            Manufacturer = new ManufacturerVM { Description = p.tblManufacturer.Description, IsActive = p.tblManufacturer.IsActive, ManufacturerId = p.tblManufacturer.ManufacturerId, ManufacturerName = p.tblManufacturer.ManufacturerName, ShortName = p.tblManufacturer.ShortName },
                            IsActive = p.IsActive,
                            MinQuantity = p.MinQuantity,
                            MRP = (float)p.MRP,
                            PurchasePrice = (float)p.PurchasePrice,
                            SalePrice = (float)p.SalePrice,
                            SKU = p.Sku
                        })
                    );

                    ItemList.Add(
                     new ItemVM()
                     {
                         ItemName = Item.ItemName,
                         ItemType = new ItemTypeVM { ItemType = Item.tblItemType.ItemType, ItemTypeId = Item.tblItemType.ItemTypeId, IsActive = Item.tblItemType.IsActive },
                         Ingredient = Item.Ingredient,
                         HSNCode = new HSNSACVM { HSNSACId = Item.tblHSNSAC.HSNSACId, HSNSACNo = Item.tblHSNSAC.HSNSACNo, TaxRate = Item.tblHSNSAC.TaxRate, IsActive = Item.tblHSNSAC.IsActive },
                         SGST = (float)Item.SGST,
                         CGST = (float)Item.CGST,
                         IGST = (float)Item.IGST,
                         Comment = Item.Comment,
                         Description = Item.Description,
                         IsActive = Item.IsActive,
                         Licenses = licenseList,
                         ItemDetails = itemDetailsList
                     });
                });
            }

            return ItemList;
        }
    }
}
