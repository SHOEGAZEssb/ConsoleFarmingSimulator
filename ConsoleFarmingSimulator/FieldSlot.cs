using System;

namespace ConsoleFarmingSimulator
{
  /// <summary>
  /// Describes a field which is used to plant seeds
  /// </summary>
  public class FieldSlot
  {
    private Seed _plantedSeed;
    private double _water;

    /// <summary>
    /// The planted seed
    /// </summary>
    public Seed PlantedSeed
    {
      get { return _plantedSeed; }
      private set { _plantedSeed = value; }
    }

    /// <summary>
    /// Current litres of water in the field
    /// </summary>
    public double Water
    {
      get { return _water; }
      set 
      { 
        //TODO: safety
        _water = value; 
      }
    }

    /// <summary>
    /// Initializes a new fieldSlot
    /// </summary>
    public FieldSlot()
    {
      Water = 100.0;
    }

    /// <summary>
    /// Plants the given crop in this field
    /// </summary>
    /// <param name="seed">Crop to plant</param>
    public void PlantSeed(Seed seed)
    {
      if (PlantedSeed == null)
      {
        PlantedSeed = seed;
        PlantedSeed.SetField(this);
        PlantedSeed.InitializeCrops();
      }
      else
        throw new Exception("There is already a seed planted!");
    }

    /// <summary>
    /// Removes the planted seed from this field and the GlobalSeedList
    /// </summary>
    public void RemoveSeed()
    {
      if (PlantedSeed != null)
        PlantedSeed = null;      
      else
        throw new Exception("There is no seed planted!");
    }

    /// <summary>
    /// Gets info about the field
    /// </summary>
    /// <returns>String with info</returns>
    public string GetInfo()
    {
      return "Field Info:\r\nWater: " + Water + " litres\r\n\r\nPlanted seed:\r\n" + GetSeedInfo() + "\r\n";
    }

    public string GetSeedInfo()
    {
      if (PlantedSeed != null)
        return PlantedSeed.GetInfo();
      else
        return "There is no seed planted.\r\n"; //TODO: exception (mabye?)
    }
  }
}
