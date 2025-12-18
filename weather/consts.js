// Каждая функция является чистой, то есть всегда возвращают новый DOM элемент, 
// не меняя внешнее состояние. То есть детерминированные.
export function getClouds() {
  // Создание DOM-элемента
  const cloud1 = document.createElement("img");
  // Установка атрибутов элемента
  cloud1.id = "weather_visibility";
  cloud1.className = "weather__header-clouds";
  cloud1.src = "Clouds.png";
  const cloud2 = document.createElement("img");
  cloud2.id = "weather_visibility";
  cloud2.className = "weather__header-clouds-2";
  cloud2.src = "Clouds.png";

  // Возврат значения
  return [cloud1, cloud2];
}

export function getRain(){
  const rain = document.createElement("img");
  rain.id = "weather_visibility";
  rain.className = "weather__header-rain";
  rain.src = "rain.gif";
  
  return rain;
}
export function getClear(){
  const blik = document.createElement("img");
  blik.id = "weather_visibility";
  blik.className = "weather__header-blik";
  blik.src = "blik.png";
  
  return blik;
}
export function getSnow(){
  const snow = document.createElement("img");
  snow.id = "weather_visibility";
  snow.className = "weather__header-snow";
  snow.src = "snow2.gif";
   
  return snow;
}
export function getFog(){
  const fog = document.createElement("img");
  fog.id = "weather_visibility";
  fog.className = "weather__header-fog";
  fog.src = "fog.gif";

  return fog;
}