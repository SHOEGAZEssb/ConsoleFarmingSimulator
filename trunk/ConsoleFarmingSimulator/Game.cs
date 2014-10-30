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

    /// <summary>
    /// Day of current game
    /// </summary>
    public int Day
    {
      get { return _day; }
      set { _day = value; }
    }

    /// <summary>
    /// Initializes a new game
    /// </summary>
    /// <param name="farmName"></param>
    /// <param name="difficulty"></param>
    public Game(string farmName, Enumerations.Difficulty difficulty)
    {
      SeedInventory = new Dictionary<string, List<Seed>>();
      InitializeSeedInventory();
      FarmName = farmName;
      Difficulty = difficulty;
      _money = 10000.0;
      Fields = new List<FieldSlot>();
      Fields.Add(new FieldSlot());
      Fields.Add(new FieldSlot());
    }   

    /// <summary>
    /// Prints info about all fields
    /// </summary>
    public void GetFieldInfo()
    {
      //TODO: return strings rather than print them
      for(int i = 0; i < Fields.Count; i++)
      {
        Console.WriteLine("Field " + (i+1) + ":");
        Console.WriteLine("Water: " + Fields[i].Water + " litres.");
        Console.WriteLine();
        Console.WriteLine("Planted seed in field " + (i+1) + ":");
        Fields[i].GetSeedInfo();
        Console.WriteLine();
      }
    }

    /// <summary>
    /// Initialize the seed inventory with empty entries for each seed type in the game
    /// </summary>
    private void InitializeSeedInventory()
    {
      SeedInventory.Add("Cucumber", new List<Seed>());
    }

    /// <summary>
    /// Add a seed to the seed inventory
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
    /// Print all seeds in the seed inventory
    /// </summary>
    public void PrintSeedInventory()
    {
      //TODO: return strings rather than print them
      foreach(KeyValuePair<string, List<Seed>> entry in SeedInventory)
      {
        if(entry.Value.Count > 0)
        {
          Console.WriteLine(entry.Key + " Seeds:");
          Console.WriteLine();
          for(int i = 0; i < entry.Value.Count; i++)
          {
            Console.WriteLine("Seed " + (i + 1) + " :");
            entry.Value[i].GetInfo();
            Console.WriteLine();
          }
        }
      }
    }
  }
}