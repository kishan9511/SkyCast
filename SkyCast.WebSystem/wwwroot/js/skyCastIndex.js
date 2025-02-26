document.getElementById("weatherForm").addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent page reload

    let city = document.getElementById("cityId").value;
    if (!city) {
        alert("Please enter a city.");
        return;
    }

    fetch(`/SkyCast/GetWeatherJson?city=${city}`)
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response was not ok");
            }
            return response.json();
        })
        .then(data => {
            if (data && data.name) {
                document.getElementById("weatherResult").innerHTML = `
             <div class="custom-block-overlay-text d-flex flex-column align-items-center">
                        <h2 class="text-white">Weather in ${data.name}</h2>
                        <img src="https://openweathermap.org/img/wn/${data.weather[0].icon}.png" class="weather-icon" alt="Weather Icon">
                        <p class="text-white"><strong>Temperature:</strong> ${data.main.temp} °C</p>
                        <p class="text-white"><strong>Humidity:</strong> ${data.main.humidity}%</p>
                        <p class="text-white"><strong>Condition:</strong> ${data.weather[0].main} - ${data.weather[0].description}</p>
                    </div>
        `;
            } else {
                document.getElementById("weatherResult").innerHTML = `
          <p class="text-danger fw-bold">Weather data is not available.</p>
        `;
            }
        })

        .catch(error => {
            console.error("Error fetching weather data:", error);
            document.getElementById("weatherResult").innerHTML = `<p class="text-danger">Error fetching weather data.</p>`;
        });

});
