namespace _Source.Scripts
{
    public class CraftSlot : Slot
    {
        public override void LeftClick()
        {
            base.LeftClick();
            InvertoryWindow.Instance.CraftController.CheckCraft();
        }

        public override void RightClick()
        {
            base.RightClick();
            InvertoryWindow.Instance.CraftController.CheckCraft();

        }

        public void DecreaseItemAmount(int amout)
        {
            Item.Amount -= amout;

            if (Item.Amount < 1)
            {
                ResetItem();
            }
            
            RefreshUI();
        }
    }
}