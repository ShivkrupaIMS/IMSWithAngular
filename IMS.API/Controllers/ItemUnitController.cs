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
    public class ItemUnitController : ApiController
    {
        private IItemUnitBL _ItemUnitBL;

        public ItemUnitController(IItemUnitBL ItemUnitBL)
        {
            _ItemUnitBL = ItemUnitBL;
        }

        [HttpPost]
        public ItemUnitVM AddItemUnit(ItemUnitVM c)
        {
            return _ItemUnitBL.AddItemUnit(c);
        }
        [HttpPost]
        public int DeleteItemUnit(ItemUnitVM c)
        {
            return _ItemUnitBL.DeleteItemUnit(c.ItemUnitId);
        }
        [HttpPost]
        public ItemUnitVM EditItemUnit(ItemUnitVM c)
        {
            return _ItemUnitBL.EditItemUnit(c);
        }

        public ItemUnitVM GetItemUnitById(int ItemUnitId)
        {
            return _ItemUnitBL.GetItemUnitById(ItemUnitId);
        }

        public IList<ItemUnitVM> GetItemUnitList()
        {
            return _ItemUnitBL.GetItemUnitList();
        }
    }
}
