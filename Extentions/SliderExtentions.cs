using System;
using UnityEngine.UI;

public static class SliderExtentions
{
    public static void Add(this Slider slider, Action<float> action)
    {
        slider.onValueChanged.AddListener((value) => action(value));
    }

    public static void Remove( this Slider slider, Action<float> action)
    {
        slider.onValueChanged.RemoveListener((value) => action(value));
    }
}