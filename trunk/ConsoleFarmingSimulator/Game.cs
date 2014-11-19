using System;
using System.Collections.Generic;

namespace ConsoleFarmingSimulator
{
  ///
  class Game
  {
    private Enumerations.Difficulty _difficulty;
    private double _money;
    private string _farmName;
    private int _level;
    private int _xp;
    private int _maxXP;
    private int _day;

    private List<FieldSlot> _fields;
    private Dictionary<string, List<Seed>> _seedInventory;
    private Dictionary<string, List<Crop>> _cropInventory;
    private Weather _currentWeather;

    /// <summary>
    /// Difficulty of current game
    /// </summary>
    public Enumerations.Difficulty Difficulty
    {
      get { return _difficulty; }
      set { _difficulty = value; }
    }

    /// <summary>
    /// Money of current game
    /// </summary>
    public double Money
    {
      get { return _money; }
      set { _money = value; }
    }

    /// <summary>
    /// Name of the farm of current game
    /// </summary>
    public string FarmName
    {
      get { return _farmName; }
      set { _farmName = value; }
    }

    /// <summary>
    /// Level of current game
    /// </summary>
    public int Level
    {
      get { return _level; }
      set { _level = value; }
    }

    /// <summary>
    /// XP of current game
    /// </summary>
    public int XP
    {
      get { return _xp; }
      set { _xp = value; }
    }

    /// <summary>
    /// MaxXP of current game
    /// </summary>
    public int MaxXP
    {
      get { return _maxXP; }
      set { _maxXP = value; }
    }

    /// <summary>
    /// Fields of current game
    /// </summary>
    public List<FieldSlot> Fields
    {
      get { return _fields; }
      private set { _fields = value; }
    }

    /// <summary>
    /// Seeds of current game
    /// </summary>
    public Dictionary<string, List<Seed>> SeedInventory
    {
      get { return _seedInventory; }
      private set { _seedInventory = value; }
    }

    public Dictionary<string, List<Crop>> CropInventory
    {
      get { return _cropInventory; }
      private set { _cropInventory = value; }
    }

    /// <summary>
    /// Day of current game
    /// </summary>
    public int Day
    {
      get { return _day; }
      set { _day = value; }
    }

    public Weather CurrentWeather
    {
      get { return _currentWeather; }
      private set { _currentWeather = value;  }
    }

    /// <summary>
    /// Initializes a new game
    /// </summary>
    /// <param name="farmName"></param>
    /// <param name="difficulty"></param>
    public Game(string farmName, Enumerations.Difficulty difficulty)
    {
      SeedInventory = new Dictionary<string, List<Seed>>();
      CropInventory = new Dictionary<string, List<Crop>>();
      InitializeInventories();
      FarmName = farmName;
      Difficulty = difficulty;
      _money = 10000.0;
      Fields = new List<FieldSlot>();
      Fields.Add(new FieldSlot());
      Fields.Add(new FieldSlot());
      CurrentWeather = new Weather(25.0, Enumerations.WeatherCondition.Sun, 0);
    }   

    /// <summary>
    /// Gets info about all fields
    /// </summary>
    public string GetFieldInfo()
    {
      string info = "";

      for(int i = 0; i < Fields.Count; i++)
      {
        info += "Field " + (i + 1) + ":\r\n" + "Water: " + Fields[i].Water + " litres\r\n\r\nPlanted seed in field " + (i + 1) + ":\r\n" + Fields[i].GetSeedInfo() + "\r\n";
      }

      return info;
    }

    /// <summary>
    /// Initialize the seed inventory with empty entries for each seed type in the game
    /// </summary>
    private void InitializeInventories()
    {
      foreach (string name in Standards.Objects)
      {
        SeedInventory.Add(name, new List<Seed>());
        CropInventory.Add(name, new List<Crop>());
      }
    }

    /// <summary>
    /// Adds a seed to the seed inventory
    /// </summary>
    /// <param name="seed">Seed to add to the seed inventory</param>
    public void AddSeedToInventory(Seed seed)
    {
      SeedInventory[seed.Name].Add(seed);
    }

    /// <summary>
    /// Remove a seed from the inventory
    /// </summary>
    /// <param name="seed">Seed to remove from inventory</param>
    public void RemoveSeedFromInventory(Seed seed)
    {
      SeedInventory[seed.Name].Remove(seed);
    }

    /// <summary>
    /// Adds a crop to the inventory
    /// </summary>
    /// <param name="crop">Crop to add to the inventory</param>
    public void AddCropToInventory(Crop crop)
    {
      CropInventory[crop.Name].Add(crop);
    }

    /// <summary>
    /// Removes a crop from the inventory
    /// </summary>
    /// <param name="crop">Crop to remove from inventory</param>
    public void RemoveCropFromInventory(Crop crop)
    {
      CropInventory[crop.Name].Remove(crop);
    }

    /// <summary>
    /// Gets information about all seeds in the seed inventory
    /// </summary>
    /// <returns>String with info</returns>
    public string PrintSeedInventory()
    {
      string info = "";

      foreach(KeyValuePair<string, List<Seed>> entry in SeedInventory)
      {
        if(entry.Value.Count > 0)
        {
          info += entry.Key + " Seeds:\r\n\r\n";

          for(int i = 0; i < entry.Value.Count; i++)
          {
            info += "Seed " + (i + 1) + " :\r\n" + entry.Value[i].GetInfo() + "\r\n";
          }
        }
      }

      return info;
    }
  }
}