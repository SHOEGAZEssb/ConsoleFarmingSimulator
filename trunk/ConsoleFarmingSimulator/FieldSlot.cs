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
    /// <param name="crop">Crop to plant</param>
    public void PlantCrop(Seed crop)
    {
      if (PlantedSeed == null)
      {
        PlantedSeed = crop;
        PlantedSeed.SetField(this);
        Program.GlobalSeedList.Add(crop);
      }
      else
        throw new Exception("There is already a seed planted!");
    }

    public void GetInfo()
    {
      Console.WriteLine("Field Info:");
      Console.WriteLine("Water: " + Water + " litres.");
      Console.WriteLine();
      Console.WriteLine("Planted seed: ");
      GetSeedInfo();
      Console.WriteLine();
    }

    public void GetSeedInfo()
    {
      if (PlantedSeed != null)
        PlantedSeed.GetInfo();
      else
        Console.WriteLine("There is no seed planted.");
    }
  }
}
