using UnityEngine;
using System.Linq;

namespace _Source.Scripts
{
    public class CraftController : MonoBehaviour
    {
        [SerializeField]
        private GameObject slotPrefab;
        [SerializeField]
        private Transform craftGrid;
        [SerializeField]
        private Transform craftTransform;
        
        [SerializeField] 
        public CraftResultSlot craftResultSlot;
        public CraftSlot[,] craftSlots { get; private set; }
        
        bool isInitialized = false;
        
        public bool HasResultItem => craftResultSlot != null;
        
        public void Init()
        {
            if (!isInitialized)
            {
                craftSlots = new CraftSlot[3, 3];
                isInitialized = true;
                CreateSlotsPrefabs();
            }
        }

        private void CreateSlotsPrefabs()
        {
            for (int i = 0; i < craftSlots.GetLength(0); i++)
            {
                for (int j = 0; j < craftSlots.GetLength(1); j++)
                {
                    var slot = Instantiate(slotPrefab, craftGrid, false);
                    craftSlots[i, j] = slot.GetComponent<CraftSlot>();
                    craftSlots[i, j].RefreshUI();
                }
            }
            var craftslot = Instantiate(slotPrefab, craftTransform, false);
            craftResultSlot = craftslot.GetComponent<CraftResultSlot>();
            craftResultSlot.RefreshUI();
        }

        public void CheckCraft()
        {
            ItemInSlot newItem = null;

            int currentRecipeW = 0;
            int currentRecipeH = 0;
            int currentRecipeWStartIndex = -1;
            int currentRecipeHStartIndex = -1;

            for (int i = 0; i < craftSlots.GetLength(0); i++)
            {
                for (int j = 0; j < craftSlots.GetLength(1); j++)
                {
                    if (craftSlots[i, j].HasItem)
                    {
                        if (currentRecipeHStartIndex == -1)
                        {
                            currentRecipeHStartIndex = i;
                        }

                        currentRecipeH++;
                        break;
                    }

                    
                }
            }
            
            for (int i = 0; i < craftSlots.GetLength(0); i++)
            {
                for (int j = 0; j < craftSlots.GetLength(1); j++)
                {
                    if (craftSlots[j, i].HasItem)
                    {
                        if (currentRecipeWStartIndex == -1)
                        {
                            currentRecipeWStartIndex = i;
                        }

                        currentRecipeW++;
                        break;
                    }

                    
                }
            }
            
            var CraftOrder = new Item[currentRecipeW * currentRecipeH];
            for (int orderId = 0, i = currentRecipeHStartIndex; i < currentRecipeH + currentRecipeHStartIndex; i++)
            {
                for (int j = currentRecipeWStartIndex; j < currentRecipeW + currentRecipeWStartIndex; j++)
                {
                    CraftOrder[orderId++] = craftSlots[i, j].Item?.Item;
                }
            }

            foreach (var item in ItemsManager.Instance.Items)
            {
                if (item.HasRecipe && item.Recipe.ItemsOrder.SequenceEqual(CraftOrder))
                {
                    newItem = new ItemInSlot(item, item.Recipe.Amount);
                    break;
                }
            }

            if (newItem != null)
            {
                craftResultSlot.SetItem(newItem);
            }
            else
            {
                craftResultSlot.ResetItem();
            }
        }

        public void CraftItem()
        {
            for (int x = 0; x < craftSlots.GetLength(0); x++)
            {
                for (int y = 0; y < craftSlots.GetLength(1); y++)
                {
                    if (craftSlots[x, y] != null)
                    {
                        craftSlots[x, y].DecreaseItemAmount(1);
                    }
                }
            }
            CheckCraft();
        }
    }
}