using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherUI : MonoBehaviour
{
    private Text weatherText;

    public static WeatherUI instance;
    private void Awake()
    {
        weatherText = this.GetComponent<Text>();
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        weatherText.text = GetWeatherText(WeatherManager.instance.currentWeather);
    }

    string GetWeatherText(WeatherManager.WeatherType weatherType)
    {
        switch (weatherType)
        {
            case WeatherManager.WeatherType.Clear:
                return "Clear";
            case WeatherManager.WeatherType.Cloudy:
                return "Cloudy";
            case WeatherManager.WeatherType.Rainy:
                return "Rainy";
            case WeatherManager.WeatherType.Foggy:
                return "Foggy";
            default:
                return null;
        }
    }
}
