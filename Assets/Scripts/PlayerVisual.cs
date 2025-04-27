using UnityEngine;

namespace Kinnly
{
    public class PlayerVisual : MonoBehaviour
    {
        // Компонент аниматора для управления анимациями
        public Animator animator; 

        // Константы для параметров анимации
        private const string HORIZONTAL = "Horizontal";  // Горизонтальное движение
        private const string VERTICAL = "Vertical";      // Вертикальное движение
        private const string SPEED = "Speed";           // Скорость движения

        private void Awake()
        {
            animator = GetComponent<Animator>();
        } 

        // Обновление параметров анимации на основе движения игрока
        private void Update()
        {
            animator.SetFloat(HORIZONTAL, Player.Instance.GetHorizontalInput());
            animator.SetFloat(VERTICAL, Player.Instance.GetVerticalInput());
            animator.SetFloat(SPEED, Player.Instance.GetSpeed());
        } 
    }
}
