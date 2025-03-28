using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace _Source.Scripts
{
    public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private Image Image;
        private Image ItemImage;
        private Text ItemAmount;
        
        private Color defaultColor = new Color32(140, 140, 140, 255);
        private Color hilightedColor = new Color32(121, 121, 121, 255);

        
        public ItemInSlot Item;
        
        public bool HasItem => Item != null;

        private void Awake()
        {
            Image = GetComponent<Image>();
            ItemImage = transform.GetChild(0).GetComponent<Image>();
            ItemAmount = transform.GetChild(1).GetComponent<Text>();
            
            ItemImage.preserveAspect = true;
        }

        public void SetItem(ItemInSlot item)
        {
            Item = item;
            RefreshUI();
        }

        public void ResetItem()
        {
            Item = null;
            RefreshUI();
        }
        
        private void RefreshUI()
        {
            ItemImage.gameObject.SetActive(HasItem);
            ItemImage.sprite = Item?.Item.Sprite;
            
            ItemAmount.gameObject.SetActive(HasItem && Item.Amount > 1);
            ItemAmount.text = Item?.Amount.ToString();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                LeftClick();
            }
            else
            {
                RightClick();
            }
        }

        public void AddItem(ItemInSlot item, int amount)
        {
            item.Amount -= amount;

            if (!HasItem)
            {
                SetItem(new ItemInSlot(item.Item, amount));
            }
            else
            {
                Item.Amount += amount;
                RefreshUI();
            }
        }
        public virtual void LeftClick()
        {
            var currItem = InvertoryWindow.Instance.CurrentItem;

            if (HasItem)
            {
                if (currItem == null || Item.Item != currItem.Item)
                {
                    InvertoryWindow.Instance.SetCurrentItem(Item);
                    ResetItem();
                }
                else
                {
                    AddItem(currItem, currItem.Amount);
                    InvertoryWindow.Instance.CheckCurrentItem();
                    return;
                }
            }
            else
            {
                InvertoryWindow.Instance.RemoveCurrentItem();
            }

            if (currItem != null)
            {
                SetItem(currItem);
            }
        }

        public virtual void RightClick()
        {
            if (!InvertoryWindow.Instance.HasCurrentItem)
            {
                return;
            }

            if (!HasItem && InvertoryWindow.Instance.CurrentItem.Item == Item.Item)
            {
                AddItem(InvertoryWindow.Instance.CurrentItem, 1);
                InvertoryWindow.Instance.CheckCurrentItem();
            }
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            Image.color = hilightedColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Image.color = defaultColor;
        }
    }
}