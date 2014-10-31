using System;
using System.Collections.Generic;

namespace ConsoleFarmingSimulator
{
  /// <summary>
  /// Shop class to buy and sell items
  /// </summary>
  class Shop
  {
    private Dictionary<Seed, double> _soldSeeds;

    /// <summary>
    /// Dictionary with seeds as keys and prices for values
    /// </summary>
    public Dictionary<Seed, double> SoldSeeds
    {
      get { return _soldSeeds; }
      private set { _soldSeeds = value; }
    }

    /// <summary>
    /// Initializes a new shop
    /// </summary>
    public Shop()
    {
      _soldSeeds = new Dictionary<Seed, double>();
      _soldSeeds.Add(Standards.Seeds.GetStandardSeed("Cucumber"), 0.5);  
    }

    /// <summary>
    /// Prints information about all items that are for sale
    /// </summary>
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

    /// <summary>
    /// Buys an item 
    /// </summary>
    /// <param name="name">Name of the item to buy</param>
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
            throw new Exception("Not enough money!"); //TODO: exception -> Game.Money
        }
        else
          throw new Exception("The shop does not sell this item!");
      }
    }
  }
}
