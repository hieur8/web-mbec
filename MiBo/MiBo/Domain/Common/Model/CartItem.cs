using System;

namespace MiBo.Domain.Common.Model
{
    [Serializable]
    public class CartItem
    {
        public string ItemCd { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get { return Quantity * Price; } }

        public CartItem()
        {
        }

        public CartItem(string itemCd)
        {
            ItemCd = itemCd;
        }

        public CartItem(string itemCd, decimal price, int quantity)
        {
            ItemCd = itemCd;
            Price = price;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (CartItem)obj;
            return (ItemCd == null) ? (other.ItemCd == null) : ItemCd.Equals(other.ItemCd);
        }

        public override int GetHashCode()
        {
            var hash = 5;
            hash = 59 * hash + (ItemCd != null ? ItemCd.GetHashCode() : 0);
            return hash;
        }
    }
}