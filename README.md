# WeatherAPI 
 
This project was worked on for weeks, using a WeatherAPI for the results. The application is open source, and not packed into a installation file. The weather application returns a lot of data see below for more.

## Preview
![weather-githu](https://github.com/joelb-services/WeatherAPI/assets/144958989/a9d6d3f5-e403-4aed-8137-da98cbc512de)


## Project Contains
- Moon: Moonrise, Moonset, Moon Phase
- Sun: Sunrise, Sunset
- Cloud Strength
- Humidity
- Temperature
- UV Scale
- Visibility
- Wind Speed

## Some cool features
- Unit conversion: miles/km ~ °C/°F ~ mph/kph
- Basic settings
- Sound effects

## How it works?
The API will return a temperature and condition, which we then group categorys and place them into string lists. Depending on the match we will then assing an icon to the weather condition.

## Weather Conditions 
```CSHARP
            string[] Thunderstorm = { // All use thunderstorm.png
                "Thunderstorm", 
                "Thunderstorm with light rain", 
                "Thunderstorm with rain", 
                "Thunderstorm with heavy rain",
                "Light thunderstorm",
                "Heavy thunderstorm",
                "Ragged thunderstorm",
                "Thunderstorm with light drizzle",
                "Thunderstorm with drizzle",
                "Thunderstorm with heavy drizzle"
            };

            string[] Drizzle = { // All use drizzle.png
                "Drizzle",
                "Light intensity drizzle",
                "Heavy intensity drizzle",
                "light intensity drizzle rain",
                "Drizzle rain",
                "Heavy intensity drizzle rain",
                "Shower rain and drizzle",
                "Heavy shower rain and drizzle",
                "Shower drizzle"
            };

            string[] Rain = { // All use rain.png OR rain_night.png
                "Rain",
                "Light rain",
                "Moderate rain",
                "Heavy intensity rain",
                "Very heavy rain",
                "Extreme rain",
                "Freezing rain",
                "Light intensity shower rain",
                "Shower rain",
                "Heavy intensity shower rain",
                "Ragged shower rain"
            };

            string[] Snow = { // All use snow.png
                "Snow",
                "Light snow",
                "Heavy snow",
                "Sleet",
                "Light shower sleet",
                "Shower sleet",
                "Light rain and snow",
                "Rain and snow",
                "Light shower snow",
                "Shower snow",
                "Heavy shower snow"
            };

            string[] Atmosphere = {
                "Mist",  // Mist.png
                "Smoke", // Mist.png
                "Haze",  // Haze.png
                "Fog"   // fog.png
            };

            string[] Clear = {
                "Clear", // Clear.png OR clear_night.png
                "Sunny"
            };

            string[] Clouds = {
                "Clouds", // clouds.png
                "Overcast", // clouds.png
                "Partly cloudy" // Partially_cloudy.png (DAYONLY)
            };
```
