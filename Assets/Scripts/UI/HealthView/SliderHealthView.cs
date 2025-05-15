using UnityEngine;
using UnityEngine.UI;

public class SliderHealthView : HealthView
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Image _sliderFillImage;

    private float _healthScale = 100f;

    private void SetSliderValue(Slider slider, float currentHealth)
    {
        slider.value = currentHealth / _healthScale;
        _sliderFillImage.enabled = slider.value != 0;
    }

    protected override void UpdateHealthDisplay(float currentHealth)
    {
        if (_healthSlider != null)
            SetSliderValue(_healthSlider, currentHealth);
    }
}
