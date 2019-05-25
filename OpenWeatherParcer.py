import requests
import Sqlite as sqlite
import schedule
import time

city = 'Kyiv'
url = f"http://api.openweathermap.org/data/2.5/forecast?q={city}&APPID=d11bb903dc603c72460d40d7eba625dc&units=metric"

def parseOpenWeather():
    res = requests.get(url)
    data = res.json()

    nowList = data['list'][0]
    nowDate = str(nowList['dt_txt'])
    nowTime = (int(str(nowDate.split(' ')[1]).split(':')[0]))
    nowTemperature = float(nowList['main']['temp'])
    nowPressure = float(nowList['main']['pressure'])
    nowWindDirection = nowList['wind']['deg']
    nowWindSpeed = float(nowList['wind']['speed'])
    nowSky = nowList['weather'][0]['main']

    tomorrowIndex = 8 + (12-nowTime)/3

    tomorrowList = data['list'][int(tomorrowIndex)]
    tomorrowDate = tomorrowList['dt_txt']
    tomorrowTemperature = float(tomorrowList['main']['temp'])
    tomorrowPressure = float(tomorrowList ['main']['pressure'])
    tomorrowWindDirection = tomorrowList ['wind']['deg']
    tomorrowWindSpeed = float(tomorrowList ['wind']['speed'])
    tomorrowSky = tomorrowList ['weather'][0]['main']

    try:
         sqlite.createTableOpenWeather()
    except:
        sqlite.deleteTableOpenWeather()
        sqlite.createTableOpenWeather()

    sqlite.clearTableOpenWeather()

    sqlite.addDayOpenWeather(nowDate,nowTemperature,nowPressure,nowWindDirection,nowWindSpeed,nowSky)
    sqlite.addDayOpenWeather(tomorrowDate,tomorrowTemperature,tomorrowPressure,tomorrowWindDirection,tomorrowWindSpeed,tomorrowSky)

    for i in range(4):
        currentList = data['list'][int(tomorrowIndex+8*i)]
        currentDate = currentList['dt_txt']
        currentTemperature = float(currentList['main']['temp'])
        currentPressure = float(currentList['main']['pressure'])
        currentWindDirection = currentList['wind']['deg']
        currentWindSpeed = float(currentList['wind']['speed'])
        currentSky = currentList['weather'][0]['main']
        sqlite.addDayOpenWeather(currentDate,currentTemperature,currentPressure,currentWindDirection,currentWindSpeed,currentSky)
    sqlite.showTableOpenWeather()

parseOpenWeather()
schedule.every(10).seconds.do(parseOpenWeather)

while True:
    schedule.run_pending()
   # time.sleep(1)

input('Press ENTER to exit')