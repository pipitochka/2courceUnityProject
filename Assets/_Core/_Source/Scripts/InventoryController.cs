using UnityEngine;

namespace _Source.Scripts
{
    public class InventoryController : MonoBehaviour
    {
        public Slot[,] MainSlots { get; private set; }
        
        public Slot[,] AdditionalSlots {get; private set;}
        
        [SerializeField]
        private GameObject slotPrefab;
        
        [SerializeField]
        private Transform mainSlotsGrid;
        [SerializeField]
        private Transform additionalSLotsGrid;
        
        public void Init()
        {
            InitTestInventory();
        }

        private void InitTestInventory()
        {
            MainSlots = new Slot[1, 9];

            AdditionalSlots = new Slot[3, 9];

            CreateSlotsPrefab();
            
            AdditionalSlots[0, 0].SetItem(new ItemInSlot(ItemsManager.Instance.Items[0], 4));
            AdditionalSlots[0, 1].SetItem(new ItemInSlot(ItemsManager.Instance.Items[3], 2));
            AdditionalSlots[0, 2].SetItem(new ItemInSlot(ItemsManager.Instance.Items[5], 3));

        }

        private void CreateSlotsPrefab()
        {
            for (int i = 0; i < MainSlots.GetLength(0); i++)
            {
                var slot = Instantiate(slotPrefab, mainSlotsGrid, false);
                MainSlots[0, i] = slot.AddComponent<Slot>();
            }

            for (int i = 0; i < AdditionalSlots.GetLength(0); i++)
            {
                for (int j = 0; j < AdditionalSlots.GetLength(1); j++)
                {
                    var slot = Instantiate(slotPrefab, additionalSLotsGrid, false);
                    AdditionalSlots[i, j] = slot.AddComponent<Slot>();
                }
            }
        }
    }
}