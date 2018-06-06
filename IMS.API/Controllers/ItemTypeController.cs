using IMS.DF.BL;
using IMS.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMS.API.Controllers
{
    public class ItemTypeController : ApiController
    {
        private IItemTypeBL _ItemTypeBL;

        public ItemTypeController(IItemTypeBL ItemTypeBL)
        {
            _ItemTypeBL = ItemTypeBL;
        }

        [HttpPost]
        public ItemTypeVM AddItemType(ItemTypeVM c)
        {
            return _ItemTypeBL.AddItemType(c);
        }
        [HttpPost]
        public int DeleteItemType(ItemTypeVM c)
        {
            return _ItemTypeBL.DeleteItemType(c.ItemTypeId);
        }
        [HttpPost]
        public ItemTypeVM EditItemType(ItemTypeVM c)
        {
            return _ItemTypeBL.EditItemType(c);
        }

        public ItemTypeVM GetItemTypeById(int ItemTypeId)
        {
            return _ItemTypeBL.GetItemTypeById(ItemTypeId);
        }

        public IList<ItemTypeVM> GetItemTypeList()
        {
            return _ItemTypeBL.GetItemTypeList();
        }
    }
}
