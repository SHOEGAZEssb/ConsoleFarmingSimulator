using System;
using System.Collections.Generic;

namespace ConsoleFarmingSimulator
{
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


    public Enumerations.Difficulty Difficulty
    {
      get { return _difficulty; }
      set { _difficulty = value; }
    }

    public double Money
    {
      get { return _money; }
      set { _money = value; }
    }

    public string FarmName
    {
      get { return _farmName; }
      set { _farmName = value; }
    }

    public int Level
    {
      get { return _level; }
      set { _level = value; }
    }

    public int XP
    {
      get { return _xp; }
      set { _xp = value; }
    }

    public int MaxXP
    {
      get { return _maxXP; }
      set { _maxXP = value; }
    }

    public List<FieldSlot> Fields
    {
      get { return _fields; }
      private set { _fields = value; }
    }

    public Dictionary<string, List<Seed>> SeedInventory
    {
      get { return _seedInventory; }
      private set { _seedInventory = value; }
    }

    public int Day
    {
      get { return _day; }
      set { _day = value; }
    }

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

    public void GetFieldInfo()
    {
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

    private void InitializeSeedInventory()
    {
      SeedInventory.Add("Cucumber", new List<Seed>());
    }

    public void AddSeedToInventory(Seed seed)
    {
      SeedInventory[seed.Name].Add(seed);
    }

    public void RemoveSeedFromInventory(Seed seed)
    {
      SeedInventory[seed.Name].Remove(seed);
    }

    public void PrintSeedInventory()
    {
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
