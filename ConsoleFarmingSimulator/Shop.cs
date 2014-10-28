using System;
using System.Collections.Generic;

namespace ConsoleFarmingSimulator
{
  class Shop
  {
    private Dictionary<Seed, double> _soldSeeds;

    public Dictionary<Seed, double> SoldSeeds
    {
      get { return _soldSeeds; }
      private set { _soldSeeds = value; }
    }

    public Shop()
    {
      _soldSeeds = new Dictionary<Seed, double>();
      _soldSeeds.Add(Standards.Seeds.GetStandardSeed("Cucumber"), 0.5);  
    }

    public void ShowSoldItems()
    {
      Console.WriteLine("Seeds: ");
      Console.WriteLine();


      int i = 1;
      foreach (KeyValuePair<Seed, double> entry in SoldSeeds)
      {
        Console.WriteLine("Seed " + i + ":");
        entry.Key.GetInfo();
        Console.WriteLine("Price: " + entry.Value + "$");
        
        i++;
      }
    }

    public void BuyItem(string name)
    {
      foreach (KeyValuePair<Seed, double> entry in SoldSeeds)
      {
        if (entry.Key.Name == name)
        {
          if (Program.Game.Money >= entry.Value)
          {
            Program.Game.Money -= entry.Value;
            Program.Game.AddSeedToInventory(entry.Key);
          }
          else
            throw new Exception("Not enough money!");
        }
      }
    }
  }
}
