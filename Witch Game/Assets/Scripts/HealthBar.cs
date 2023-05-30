using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;  // assign this in the inspector

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}