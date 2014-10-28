using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFarmingSimulator
{
  public class Crop
  {
    private string _name;
    private double _weight;
    private Enumerations.Quality _cropQuality;

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

    private void CalculateQuality(Seed parentSeed)
    {
      
    }

  }
}
