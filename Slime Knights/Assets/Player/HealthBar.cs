using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthBar : MonoBehaviour
    {
        public Slider hpSlider;
        public Gradient gradient;
        public Image fill;
        public void MaxHealth(int maxHP)
        {
            hpSlider.maxValue = maxHP;
            hpSlider.value = maxHP;
            fill.color = gradient.Evaluate(1f);
        }
        public void SetHealth(int health)
        {
            hpSlider.value = health;

            fill.color = gradient.Evaluate(hpSlider.normalizedValue);
        }

       
        
    }
}
