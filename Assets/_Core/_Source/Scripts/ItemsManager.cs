using System.Collections.Generic;
using UnityEngine;

namespace _Source.Scripts
{
    public class ItemsManager : MonoBehaviour
    {
        public static ItemsManager Instance;
        
        public List<Item> Items;
        
        public Sprite[] ItemSprites;

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            GenerateItems();
        }

        private void GenerateItems()
        {
            Items = new List<Item>();
            
            Items.Add(new Item("Wood", ItemSprites[0]));

            var PlankRecipe = new Item[,]
            {
                {Items[0]}
            };
            
            Items.Add(new Item("Planks", ItemSprites[1], new CraftRecipe(PlankRecipe, 4)));
            
            var StickRecipe = new Item[,]
            {
                {Items[1]}, 
                {Items[1]}
            };
            
            Items.Add(new Item("Sticks", ItemSprites[2], new CraftRecipe(StickRecipe, 4)));
            
            Items.Add(new Item("Coal", ItemSprites[3]));
            
            var TorchRecipe = new Item[,]
            {
                {Items[3]}, 
                {Items[2]}
            };
            
            Items.Add(new Item("Torch", ItemSprites[4], new CraftRecipe(TorchRecipe, 4)));
            
            Items.Add(new Item("Diamon", ItemSprites[5]));
            
            var AxeRecipe = new Item[,]
            {
                {Items[5], Items[5]}, 
                {Items[5], Items[2]},
                {null, Items[2]}
            };
            
            Items.Add(new Item("Axe", ItemSprites[6], new CraftRecipe(AxeRecipe, 1)));


        }
        
    }
}