using UnityEditor;

namespace _Source.Scripts
{
    public class CraftRecipe
    {
        public Item[,] Items { get; private set; }
        
        public int Amount { get; private set; }
        
        public Item[] ItemsOrder { get; private set; }

        public CraftRecipe(Item[,] items, int amount)
        {
            Items = items;
            Amount = amount;
            
            ItemsOrder = new Item[Items.Length];
            int t = 0;
            for (int x = 0; x < Items.GetLength(0); x++)
            {
                for (int y = 0; y < Items.GetLength(1); y++)
                {
                    ItemsOrder[t++] = Items[x, y];
                }
            }
        }
    }
}
