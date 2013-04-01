using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Common.Utils
{
    public class CartCom
    {
        public IList<CartItem> Items { get; set; }
        public bool Empty { get { return Items.Count == 0; } }
        public decimal Count { get { return Items.Sum(o => o.Quantity); } }
        public decimal TotalAmount { get { return Items.Sum(item => item.Amount); } }
        public string GiftCd { get; set; }
        public decimal GiftPrice { get; set; }
        public decimal TotalPrice { get { return Items.Sum(item => item.Amount) - GiftPrice; } }
        public CartItem this[int index]
        {
            get
            {
                if (index < 0 || index > Items.Count - 1) { return null; }
                return Items[index];
            }
        }

        public CartCom(object items)
        {
            Items = DataHelper.ConvertInputCart(items);
        }

        public CartCom(IList<CartItem> items)
        {
            Items = DataHelper.ConvertInputCart(items);
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item">Item</param>
        public void AddItem(CartItem item)
        {
            if (Items.Contains(item))
            {
                var index = Items.IndexOf(item);
                Items[index].Quantity += item.Quantity;
            }
            else { Items.Add(item); }
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item">Item</param>
        public void UpdateItem(CartItem item)
        {
            if (Items.Contains(item))
            {
                // If we are setting the quantity to 0, remove the item entirely
                if (item.Quantity == decimal.Zero)
                {
                    DeleteItem(item);
                    return;
                }

                var index = Items.IndexOf(item);
                Items[index].Quantity = item.Quantity;
            }
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item">Item</param>
        public void DeleteItem(CartItem item)
        {
            if (Items.Contains(item)) Items.Remove(item);
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item">ItemCd</param>
        public void DeleteItem(string itemCd)
        {
            var item = new CartItem(itemCd);
            DeleteItem(item);
        }
    }
}