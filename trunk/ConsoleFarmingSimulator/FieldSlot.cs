using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFarmingSimulator
{
  public class FieldSlot
  {
    private Seed _plantedSeed;
    private double _water;

    public Seed PlantedSeed
    {
      get { return _plantedSeed; }
      private set { _plantedSeed = value; }
    }

    public double Water
    {
      get { return _water; }
      set 
      { 
        //TODO: safety
        _water = value; 
      }
    }

    public FieldSlot()
    {
      Water = 100.0;
    }

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
