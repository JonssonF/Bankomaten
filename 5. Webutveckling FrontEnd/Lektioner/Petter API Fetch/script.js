const BASE_URL = "https://api.openweathermap.org/data/2.5/weather";
const API_KEY = "bd5e378503939ddaee76f12ad7a97608";

async function getWeatherData(city) {
  const url = `${BASE_URL}?q=${city}&units=metric&appid=${API_KEY}`;

  const response = await fetch(url);

  if (!response.ok) {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }

  const data = await response.json();
  console.log(data);
}

getWeatherData("Varberg");


document.addEventListener("keydown", (e) =>  { 
    if(e.key === "Enter")

})

try{
if (!response.ok) {
    if (response.status === 404) {
        showError("City not found. Please enter a valid city name.");
        return;
    }
    throw new Error(`HTTP error! Status: ${response.status}`);
}

const data = await response.json();
displayWeatherData(data);
} catch (error) {
console.error("Fel vid hämtning av väderdata:", error);
showError("An error occurred while fetching weather data. Please try again later.");
}