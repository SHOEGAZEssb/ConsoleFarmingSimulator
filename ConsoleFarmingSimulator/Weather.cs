using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFarmingSimulator
{
  class Weather
  {
    private double _temperature;
    private Enumerations.WeatherCondition _weatherCondition;
    private int _currentStreak;
    private int _weatherChangeChance;

    public double Temperature
    {
      get { return _temperature; }
      private set { _temperature = value; }
    }

    public Enumerations.WeatherCondition WeatherCondition
    {
      get { return _weatherCondition; }
      private set { _weatherCondition = value; }
    }

    public int CurrentStreak
    {
      get { return _currentStreak; }
      private set { _currentStreak = value; }
    }

    public int WeatherChangeChance
    {
      get { return _weatherChangeChance; }
      private set
      {
        if (value < 0)
          _weatherChangeChance = 0;
        else if (value > 100)
          _weatherChangeChance = 100;
        else
          _weatherChangeChance = value;
      }
    }

    public Weather(double temperature, Enumerations.WeatherCondition weatherCondition, int currentStreak)
    {
      Temperature = temperature;
      WeatherCondition = weatherCondition;
      CurrentStreak = currentStreak;
    }

    public void CalculateWeather()
    {
      CurrentStreak++;

      Random rnd = new Random((int)DateTime.Now.Ticks.GetHashCode());

      WeatherChangeChance = rnd.Next(0, 10);
      Enumerations.WeatherCondition supposedChange = Enumerations.WeatherCondition.Sun;
      Enumerations.WeatherCondition secondSupposedChange = Enumerations.WeatherCondition.Sun;

      if (WeatherCondition == Enumerations.WeatherCondition.Sun)
      {
        WeatherChangeChance += CurrentStreak * 5;
        supposedChange = Enumerations.WeatherCondition.Rain;
        secondSupposedChange = Enumerations.WeatherCondition.Cloudy;
      }
      else if (WeatherCondition == Enumerations.WeatherCondition.Rain)
      {
        WeatherChangeChance += CurrentStreak * 12;
        supposedChange = Enumerations.WeatherCondition.Cloudy;
        secondSupposedChange = Enumerations.WeatherCondition.Sun;
      }
      else if (WeatherCondition == Enumerations.WeatherCondition.Cloudy)
      {
        WeatherChangeChance += CurrentStreak * 8;
        supposedChange = Enumerations.WeatherCondition.Sun;
        secondSupposedChange = Enumerations.WeatherCondition.Rain;
      }

      if (rnd.Next(0, 100 - WeatherChangeChance) == 0)
      {
        if (rnd.Next(0, 70) == 70)
          WeatherCondition = secondSupposedChange;
        else
          WeatherCondition = supposedChange;

        CurrentStreak = 0;
      }
    }
  }
}
