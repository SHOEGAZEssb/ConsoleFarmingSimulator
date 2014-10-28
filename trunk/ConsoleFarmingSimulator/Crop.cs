using System;

namespace ConsoleFarmingSimulator
{
  public class Crop
  {
    private string _name;
    private double _weight;
    private Enumerations.Quality _cropQuality;
    private Seed _parentSeed;

    public string Name
    {
      get { return _name; }
      private set {_name = value;}
    }

    public double Weight
    {
      get { return _weight; }
      private set { _weight = value; }
    }

    public Enumerations.Quality CropQuality
    {
      get { return _cropQuality; }
      private set { _cropQuality = value; }
    }

    public Seed ParentSeed
    {
      get { return _parentSeed; }
      private set { _parentSeed = value; }
    }

    public Crop(string name, double weight, Seed parentSeed)
    {
      Name = name;
      Weight = weight;
      CalculateQuality(parentSeed);
    }

    public void GetInfo()
    {
      Console.WriteLine("Name: " + _name);
      Console.WriteLine("Weight: " + _weight);
    }

    public void SetParentSeed(Seed seed)
    {
      ParentSeed = seed;
    }

    private void CalculateQuality(Seed parentSeed)
    {
      
    }

  }
}
