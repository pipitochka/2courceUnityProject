namespace _Source.Scripts
{
    public class CraftResultSlot : Slot
    {
        public override void LeftClick()
        {
            if (InvertoryWindow.Instance.HasCurrentItem || !InvertoryWindow.Instance.CraftController.HasResultItem)
            {
                return;
            }
            
            InvertoryWindow.Instance.SetCurrentItem(Item);
            ResetItem();
            
            InvertoryWindow.Instance.CraftController.CraftItem();
        }
    }
}