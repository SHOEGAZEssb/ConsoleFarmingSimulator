namespace ConsoleFarmingSimulator
{
  /// <summary>
  /// Contains common enumerations
  /// </summary>
  public static class Enumerations
  {
    public enum Difficulty { easy, medium, hard};
    public enum SeedType { Fruit, Vegetable };
    public enum Quality { Uneatable = -3, VeryBad = -2, Bad = -1, Normal = 1, Good = 2, VeryGood = 3, Fantastic = 4, Phenomenal = 5, GeneticWonder = 6};
    public enum WeatherCondition { Sun, Cloudy, Rain, Snow, Fog, Hail}
  }
}