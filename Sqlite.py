import sqlite3

index:int
def createTableOpenWeather():
    connection = sqlite3.connect('weather.db')
    cursor = connection.cursor()
    global index
    cursor.execute("""CREATE TABLE openweather (
                    id integer,
                    date text,
                    temperature real,
                    pressure real,
                    wind text,
                    speedOfWind real,
                    sky text
                    )""")
    index = 0
    connection.commit()
    connection.close()

def addDayOpenWeather(date:str,temperature:float,pressure:float,wind:str,speedOfWind:float,sky:str):
    connection = sqlite3.connect('weather.db')
    cursor = connection.cursor()
    global index
    cursor.execute(f"INSERT INTO openweather VALUES ('{index}','{date}','{temperature}',{pressure},'{wind}','{speedOfWind}','{sky}')")
    index+=1
    connection.commit()
    connection.close()

def showTableOpenWeather():
    connection = sqlite3.connect('weather.db')
    cursor = connection.cursor()
    cursor.execute("SELECT * FROM openweather")
    print(cursor.fetchall())
    connection.commit()
    connection.close()

def clearTableOpenWeather():
    connection = sqlite3.connect('weather.db')
    cursor = connection.cursor()
    global index
    cursor.execute("DELETE FROM openweather")
    index = 0
    connection.commit()
    connection.close()

def deleteTableOpenWeather():
    connection = sqlite3.connect('weather.db')
    cursor = connection.cursor()
    cursor.execute("DROP TABLE openweather")
    connection.commit()
    connection.close()
