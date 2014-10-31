using System;

namespace ConsoleFarmingSimulator
{
  public class Crop
  {
    private string _name;
    private double _weight;
    private Enumerations.Quality _cropQuality;
    private Seed _parentSeed;

    /// <summary>
    /// The name of this crop
    /// </summary>
    public string Name
    {
      get { return _name; }
      private set {_name = value;}
    }

    /// <summary>
    /// The weight of this crop
    /// </summary>
    public double Weight
    {
      get { return _weight; }
      private set { _weight = value; }
    }

    /// <summary>
    /// The quality of this crop
    /// </summary>
    public Enumerations.Quality CropQuality
    {
      get { return _cropQuality; }
      private set { _cropQuality = value; }
    }

    /// <summary>
    /// The parent seed of this crop
    /// </summary>
    public Seed ParentSeed
    {
      get { return _parentSeed; }
      private set { _parentSeed = value; }
    }

    /// <summary>
    /// Initializes a new crop
    /// </summary>
    public Crop(string name, double weight, Seed parentSeed)
    {
      Name = name;
      Weight = weight;
      CalculateQuality();
    }

    /// <summary>
    /// Prints info about this crop
    /// </summary>
    public void GetInfo()
    {
      //TODO: return strings rather than printing them
      Console.WriteLine("Name: " + _name);
      Console.WriteLine("Weight: " + _weight);
    }

    /// <summary>
    /// Sets the parent seed
    /// </summary>
    /// <param name="seed">Seed to set as parent</param>
    public void SetParentSeed(Seed seed)
    {
      ParentSeed = seed;
    }

    /// <summary>
    /// Calculates the quality based on... (?)
    /// </summary>
    private void CalculateQuality()
    {
      
    }
  }
}