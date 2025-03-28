using _Source.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Scripts
{
    public class InvertoryWindow : MonoBehaviour
    {
        public static InvertoryWindow Instance;

        public CraftController CraftController;
        public InventoryController InventoryController;
        
        [SerializeField]
        private Image currentItemImage;

        public ItemInSlot CurrentItem;
        
        public bool HasCurrentItem => CurrentItem != null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            Open();
        }

        public void Open()
        {
            Debug.Log("Opening invertory window");
            gameObject.SetActive(true);
            CraftController.Init();
            InventoryController.Init();
        }

        public void SetCurrentItem(ItemInSlot item)
        {
            CurrentItem = item;
            currentItemImage.gameObject.SetActive(true);
            currentItemImage.sprite = CurrentItem.Item.Sprite;
        }

        public void RemoveCurrentItem()
        {
            CurrentItem = null;
            currentItemImage.gameObject.SetActive(false);
        }

        public void CheckCurrentItem()
        {
            if (CurrentItem != null && CurrentItem.Amount < 1)
            {
                RemoveCurrentItem();
            }
        }

        private void Update()
        {
            if (CurrentItem == null)
            {
                return;
            }
            currentItemImage.transform.position = Input.mousePosition;
        }
    }
}