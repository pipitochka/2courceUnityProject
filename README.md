Итоговая работа по Unity
Разработка системы крафтинга

Данная система крафтинга позволяет создавать предметы
Чтобы добавить новую сущность нужно загрузить в ItemManager спрайт и добавить
```C#
Items.Add(new Item("Wood", ItemSprites[0]));
//случай предмета без крафта

var PlankRecipe = new Item[,]
{
  {Items[0]}
};
          
Items.Add(new Item("Planks", ItemSprites[1], new CraftRecipe(PlankRecipe, 4)));
//случай предмета с кравтом          
```