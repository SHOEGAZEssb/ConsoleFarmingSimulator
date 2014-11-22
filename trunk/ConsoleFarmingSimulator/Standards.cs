using System.Collections.Generic;

namespace ConsoleFarmingSimulator
{
  /// <summary>
  /// Contains all standard seeds & crops
  /// </summary>
  public static class Standards
  {
    /// <summary>
    /// Contains all standard seeds
    /// </summary>
    public static class Seeds
    {
      private static Dictionary<string, Seed> _seedDic = new Dictionary<string, Seed>();

      /// <summary>
      /// Gets a standard crop from the dictionary
      /// </summary>
      /// <param name="name">Key to get value from</param>
      /// <returns>A standard seed in the dictionary</returns>
      public static Seed GetStandardSeed(string name)
      {
        return _seedDic[name];
      }

      /// <summary>
      /// Adds seeds to the dictionary
      /// </summary>
      public static void InitializeStandardSeeds()
      {
        _seedDic.Add("Cucumber", new Seed("Cucumber", 0.2734, Enumerations.SeedType.Vegetable ,Enumerations.Quality.Normal, 3, null, 25.5, 15, 0.2734));
        _seedDic.Add("Apple", new Seed("Apple", 0.0342, Enumerations.SeedType.Fruit, Enumerations.Quality.Normal, 30, null, 25, 80, 0.2734));
      }

      /// <summary>
      /// Adds the parent crop to all seeds
      /// </summary>
      public static void LinkSeedParents()
      {
        foreach (KeyValuePair<string, Seed> entry in _seedDic)
        {
          entry.Value.ParentCrop = Crops.GetStandardCrop(entry.Key);
        }
      }
    }

    /// <summary>
    /// Contains all standard crops
    /// </summary>
    public static class Crops
    {
      private static Dictionary<string, Crop> _cropDic = new Dictionary<string, Crop>();

      /// <summary>
      /// Gets a standard crop from the dictionary
      /// </summary>
      /// <param name="name">Key to get value from</param>
      /// <returns>A standard crop in the dictionary</returns>
      public static Crop GetStandardCrop(string name)
      {
        return _cropDic[name];
      }

      /// <summary>
      /// Adds crops to the dictionary
      /// </summary>
      public static void InitializeStandardCrops()
      {
        _cropDic.Add("Cucumber", new Crop("Cucumber", 0.4, null));
        _cropDic.Add("Apple", new Crop("Apple", 250, null));
      }

      /// <summary>
      /// Adds the parent seed to all crops
      /// </summary>
      public static void LinkCropParents()
      {
        foreach (KeyValuePair<string, Crop> entry in _cropDic)
        {
          entry.Value.ParentSeed = Seeds.GetStandardSeed(entry.Key);
        }
      }
    }

    /// <summary>
    /// Initializes all standard seeds & crops and links their parents
    /// </summary>
    public static void InitializeStandards()
    {
      InitializeGameObjects();
      Seeds.InitializeStandardSeeds();
      Crops.InitializeStandardCrops();
      Crops.LinkCropParents();
      Seeds.LinkSeedParents();
    }

    /// <summary>
    /// Holds all names of objects in this game
    /// </summary>
    public static List<string> Objects { get; private set; }

    /// <summary>
    /// Initializes a list with a names of all objects in the game (eg fruits and vegetables)
    /// </summary>
    private static void InitializeGameObjects()
    {
      Objects = new List<string>();
      Objects.Add("Cucumber");
      Objects.Add("Apple");
    }
  }
}