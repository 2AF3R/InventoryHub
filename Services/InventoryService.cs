using InventoryHub.Api.Models;
using System.Xml.Linq;

namespace InventoryHub.Api.Services
{
    public class InventoryService
    {
        private readonly List<Item> _items = new()
        {
            new Item { Id = 1, Name = "Laptop", Quantity = 10, Price = 1200 },
            new Item { Id = 2, Name = "Mouse", Quantity = 50, Price = 25 }
        };

        public IEnumerable<Item> GetAll() => _items;

        public Item? GetById(int id) => _items.FirstOrDefault(i => i.Id == id);

        public Item Add(Item item)
        {
            item.Id = _items.Max(i => i.Id) + 1;
            _items.Add(item);
            return item;
        }

        public bool Update(int id, Item updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.Quantity = updated.Quantity;
            existing.Price = updated.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }
    }
}
