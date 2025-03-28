using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

namespace _Source.Scripts
{
    public class Buttons : MonoBehaviour
    {
        public Button button1; // Первая кнопка
        public Button button2; // Вторая кнопка

        private void Start()
        {
            // Назначаем методы для кнопок
            button1.onClick.AddListener(() => Toggle(button1, button2));
            button2.onClick.AddListener(() => Toggle(button2, button1));

            // Вторая кнопка скрыта в начале
            button2.gameObject.SetActive(false);
        }

        private void Toggle(Button hideButton, Button showButton)
        {
            hideButton.gameObject.SetActive(false); // Скрываем кнопку
            showButton.gameObject.SetActive(true);  // Показываем другую
        }
    }
    
}