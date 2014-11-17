using System;

namespace ConsoleFarmingSimulator
{
  /// <summary>
  /// Represents the current weather with temperature and condition
  /// </summary>
  class Weather
  {
    private double _temperature;
    private Enumerations.WeatherCondition _weatherCondition;
    private int _currentStreak;
    private int _weatherChangeChance;

    /// <summary>
    /// Current temperature
    /// </summary>
    public double Temperature
    {
      get { return _temperature; }
      private set { _temperature = value; }
    }

    /// <summary>
    /// Current weather condition
    /// </summary>
    public Enumerations.WeatherCondition WeatherCondition
    {
      get { return _weatherCondition; }
      private set { _weatherCondition = value; }
    }

    /// <summary>
    /// The current weather condition streak in days
    /// </summary>
    public int CurrentStreak
    {
      get { return _currentStreak; }
      private set { _currentStreak = value; }
    }

    /// <summary>
    /// The daily chance that the weather changes
    /// </summary>
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

    /// <summary>
    /// Initializes the weather
    /// </summary>
    /// <param name="temperature"></param>
    /// <param name="weatherCondition"></param>
    /// <param name="currentStreak"></param>
    public Weather(double temperature, Enumerations.WeatherCondition weatherCondition, int currentStreak)
    {
      Temperature = temperature;
      WeatherCondition = weatherCondition;
      CurrentStreak = currentStreak;
    }

    /// <summary>
    /// Daily calculation of the weather
    /// </summary>
    public void CalculateWeather()
    {
      CurrentStreak++;

      Random rnd = new Random((int)DateTime.Now.Ticks.GetHashCode());

      WeatherChangeChance = rnd.Next(0, 10);

      //TODO: implement this somehow
      //int[] sunChance = new int[2];
      //int[] rainChance = new int[2];
      //int[] cloudChance = new int[2];
      //int[] fogChance = new int[2];
      //int[] hailChance = new int[2];
      //int[] snowChance = new int[2];

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
        if (rnd.Next(0, 70) <= 70)
          WeatherCondition = secondSupposedChange;
        else
          WeatherCondition = supposedChange;

        CurrentStreak = 0;
      }
    }
  }
}