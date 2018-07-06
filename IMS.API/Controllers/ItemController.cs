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
    public class ItemController : ApiController
    {
        private IItemBL _ItemBL;

        public ItemController(IItemBL ItemBL)
        {
            _ItemBL = ItemBL;
        }

        [HttpPost]
        public ItemVM AddItem(ItemVM c)
        {
            return _ItemBL.AddItem(c);
        }
        [HttpPost]
        public int DeleteItem(ItemVM c)
        {
            return _ItemBL.DeleteItem(c.ItemId);
        }
        [HttpPost]
        public ItemVM EditItem(ItemVM c)
        {
            return _ItemBL.EditItem(c);
        }

        public ItemVM GetItemById(int ItemId)
        {
            return _ItemBL.GetItemById(ItemId);
        }

        public IList<ItemVM> GetItemList()
        {
            return _ItemBL.GetItemList();
        }
    }
}
