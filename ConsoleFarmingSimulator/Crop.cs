using System;

namespace ConsoleFarmingSimulator
{
  /// <summary>
  /// Represents a crop grown on a seed
  /// </summary>
  public class Crop
  {
    private string _name;
    private double _endWeight;
    private double _currentWeight;
    private Enumerations.Quality _cropQuality;
    private Seed _parentSeed;
    private double _growth;

    /// <summary>
    /// The name of this crop
    /// </summary>
    public string Name
    {
      get { return _name; }
      private set { _name = value; }
    }

    /// <summary>
    /// The weight this crop will have when its fully grown
    /// </summary>
    public double EndWeight
    {
      get { return _endWeight; }
      private set
      {
        string val = value.ToString("0.0000");
        _endWeight = double.Parse(val);
      }
    }

    /// <summary>
    /// The weight this crop will have when its fully grown
    /// </summary>
    public double CurrentWeight
    {
      get { return _currentWeight; }
      private set 
      {
        string val = value.ToString("0.0000");
        _currentWeight = double.Parse(val); 
      }
    }

    /// <summary>
    /// Growth of this crop
    /// </summary>
    public double Growth
    {
      get { return _growth; }
      set 
      {
        string val = value.ToString("0.0000");
        _growth = double.Parse(val);

        if (Growth <= 100)
          CurrentWeight = (EndWeight * Growth) / 100;
        else
          CurrentWeight = EndWeight;
      }
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
      EndWeight = weight;
      ParentSeed = parentSeed;
      CalculateQuality();
    }

    /// <summary>
    /// Gets info about this crop
    /// </summary>
    /// <returns>String with info</returns>
    public string GetInfo()
    {
      string info = "Name: " + Name + "\r\nWeight: " + CurrentWeight + "kg\r\nGrowth: " + Growth + "%\r\n";
      return info;    
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