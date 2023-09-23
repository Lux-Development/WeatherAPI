![weather-githu](https://github.com/joelb-services/WeatherAPI/assets/144958989/a9d6d3f5-e403-4aed-8137-da98cbc512de)

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [How It Works](#how-it-works)
- [Weather Conditions](#weather-conditions)
- [Getting Started](#getting-started)

- ## Overview

The WeatherAPI Weather Application is an open-source project designed to provide comprehensive weather information using the WeatherAPI. This application offers a wide range of weather data, including moon and sun details, cloud strength, humidity, temperature, UV scale, visibility, wind speed, and wind direction. With a user-friendly interface and useful features, it's a valuable tool for staying informed about weather conditions.

## Features

### Detailed Weather Information

- **Moon Information**: Get moonrise, moonset, and moon phase details.

- **Sun Information**: Access sunrise and sunset times.

- **Cloud Strength**: View information about cloud cover.

- **Humidity**: Check the current humidity level.

- **Temperature**: Get the current temperature and feels-like temperature.

- **UV Scale**: Monitor the UV index.

- **Visibility**: Know the current visibility conditions.

- **Wind Speed**: Get information about wind speed.

- **Wind Direction**: Check the direction of the wind.

### User-Friendly Features

- **Unit Conversion**: Easily switch between miles/km, °C/°F, and mph/kph.

- **Basic Settings**: Customize your preferences.

- **Sound Effects**: Enjoy open and click sounds for a better user experience.

- **Daily Update Notifications** (Work in Progress): Stay informed with daily weather updates.

- **Tooltips**: Hover over buttons and text boxes for helpful tooltips.

- **Draggable UI**: Arrange the user interface to your liking.

- **Lock to Taskbar**: Keep the app readily accessible on your taskbar.

## How It Works

The WeatherAPI Weather Application makes HTTP requests to the WeatherAPI to retrieve weather data. Here's a simplified overview of the process:

1. **HTTP Request**: The application sends an HTTPS request to the WeatherAPI, providing the location (e.g., city) and API key.

```js
https://api.weatherapi.com/v1/astronomy.xml?key=YOUR_API_KEY&q={CITY}
```

2. **XML Return**: The WeatherAPI responds with XML data containing various weather-related information, including location details, astronomy data (e.g., sunrise and sunset times), and more.
```xml
<root>
<location>
<name>London</name>
<region>City of London, Greater London</region>
<country>United Kingdom</country>
<lat>51.52</lat>
<lon>-0.11</lon>
<tz_id>Europe/London</tz_id>
<localtime_epoch>1695509046</localtime_epoch>
<localtime>2023-09-23 23:44</localtime>
</location>
<astronomy>
<astro>
<sunrise>06:47 AM</sunrise>
<sunset>06:57 PM</sunset>
<moonrise>04:31 PM</moonrise>
<moonset>11:11 PM</moonset>
<moon_phase>Waxing Gibbous</moon_phase>
<moon_illumination>52</moon_illumination>
<is_moon_up>0</is_moon_up>
<is_sun_up>0</is_sun_up>
</astro>
</astronomy>
</root>
```

## Weather Conditions
The application categorizes weather conditions into various categories, each associated with specific weather icons. Here are some examples:

Thunderstorm: 
Thunderstorm, thunderstorm with rain, and more.

Drizzle: 
Drizzle, light intensity drizzle, and more.

Rain: 
Rain, light rain, heavy intensity rain, and more.

Snow: 
Snow, light snow, sleet, and more.

Atmosphere: 
Mist, smoke, haze, and fog.

Clear: 
Clear and sunny conditions.

Clouds: 
Cloudy and partly cloudy conditions.

## Getting Started
To use the WeatherAPI Weather Application, follow these steps:

- Clone or Download: Clone this repository or download the source code to your local machine.

Add SiticoneUI Reference:
- Open your project in Visual Studio 2022.
- Right-click on "References" in the Solution Explorer and choose "Add Reference..."
- Click the "Browse" button and locate the downloaded SiticoneUI DLL.
- Click "Add" and then "OK" to add the SiticoneUI reference to your project.

Config & Build:
- Replace YOUR_API_KEY in the API request URL with your [openweathermap](https://openweathermap.org/) API key. (Or use the one available if you are just exploring)
- Build the Project: Use Visual Studio 2022 or your preferred C# development environment to build the project.
- Explore and enjoy the features and weather information it provides.
