using System;
using System.Collections.Generic;

namespace ConsoleFarmingSimulator
{
  /// <summary>
  /// Represents a seed which will grow to give crops
  /// </summary>
  public class Seed
  {
    private string _name;
    private double _growth;
    private double _growthRate;
    private double _baseGrowth;
    private List<Crop> _crops;
    private double _health;
    private Enumerations.SeedType _seedType;
    private Enumerations.Quality _seedQuality;
    private int _lifeSpan;
    private int _age;

    private FieldSlot _field;
    private double _requiredWaterBase;
    private double _requiredWater;
    private Crop _parentCrop;

    /// <summary>
    /// The health of the crop. If it drops to 0, the seed will die and be unusable.
    /// </summary>
    public double Health
    {
      get { return _health; }
      private set
      {
        if (value < 0)
          _health = 0;
        else
          _health = value;
      }
    }

    /// <summary>
    /// The grown crops
    /// </summary>
    public List<Crop> Crops
    {
      get { return _crops; }
      private set { }
    }

    /// <summary>
    /// The name of the seed
    /// </summary>
    public string Name
    {
      get { return _name; }
      private set { _name = value; }
    }

    /// <summary>
    /// Growth of the seed. 
    /// </summary>
    public double Growth
    {
      get { return _growth; }
      private set { _growth = value; }
    }

    /// <summary>
    /// Current growth rate of the seed
    /// </summary>
    public double GrowthRate
    {
      get { return _growthRate; }
      private set { _growthRate = value; }
    }

    /// <summary>
    /// Base growth of the seed
    /// </summary>
    public double BaseGrowth
    {
      get { return _baseGrowth; }
      private set { _baseGrowth = value; }
    }

    /// <summary>
    /// Type of the seed
    /// <remarks>Vegetable or fruit</remarks>
    /// </summary>
    public Enumerations.SeedType SeedType
    {
      get { return _seedType; }
      private set { _seedType = value; }
    }

    /// <summary>
    /// The lifespan in days, if it is reached the seed will die
    /// </summary>
    public int LifeSpan
    {
      get { return _lifeSpan; }
      private set { _lifeSpan = value; }
    }

    /// <summary>
    /// Days planted
    /// </summary>
    public int Age
    {
      get { return _age; }
      private set { _age = value; }
    }

    /// <summary>
    /// Required water per day (base)
    /// </summary>
    public double RequiredWaterBase
    {
      get { return _requiredWaterBase; }
      private set { _requiredWaterBase = value; }
    }

    /// <summary>
    /// THe crop which contained this seed
    /// </summary>
    public Crop ParentCrop
    {
      get { return _parentCrop; }
      private set { _parentCrop = value; }
    }

    /// <summary>
    /// Quality of the seed
    /// </summary>
    public Enumerations.Quality SeedQuality
    {
      get { return _seedQuality; }
      private set { _seedQuality = value; }
    }

    /// <summary>
    /// Initializes a new seed
    /// </summary>
    public Seed(string name, double baseGrowth, Enumerations.SeedType seedType, Enumerations.Quality seedQuality, int lifeSpan, double requiredWater, Crop parentCrop)
    {
      Name = name;
      BaseGrowth = baseGrowth;
      CalculateGrowthRate();
      SeedType = seedType;
      Growth = 0;
      Age = 0;
      Health = 100.0;
      SeedQuality = seedQuality;
      LifeSpan = lifeSpan;
      RequiredWaterBase = requiredWater;
      Crops = new List<Crop>();
      ParentCrop = parentCrop;
    }

    /// <summary>
    /// Displays info about the seed
    /// </summary>
    public void GetInfo()
    {
      //TODO: return strings rather than print them
      Console.WriteLine("Name: " + Name);
      Console.WriteLine("Type: " + SeedType);
      Console.WriteLine("Growth: " + Growth + "%");
      Console.WriteLine("Base Growth: " + BaseGrowth);
      Console.WriteLine("Health: " + Health + "/100%");
      Console.WriteLine("Quality: " + SeedQuality);
      Console.WriteLine();
    }

    /// <summary>
    /// Get info about all crops on this seed
    /// </summary>
    public void GetDeepInfo()
    {
      foreach (Crop crop in Crops)
      {
        crop.GetInfo();
        Console.WriteLine();
      }
    }

    /// <summary>
    /// Daily grow process
    /// </summary>
    public void Grow()
    {
      Age++;
      double factor = 1.0;
      if (_field.Water >= _requiredWaterBase)
        _field.Water -= _requiredWaterBase;
      else
      {
        double percentage = _field.Water * 100 / _requiredWaterBase;
        _field.Water = 0;

        Random rnd = new Random((int)(DateTime.Now.Ticks.GetHashCode()));
        int healthDamage = rnd.Next(1, 10 - (int)(percentage / 50)); //TODO: add robustheit lol
        Health -= healthDamage;
      }

      if (Health != 0)
        Growth += GrowthRate;
      else
      {

      }
    }

    /// <summary>
    /// Sets the field in which this seed is planted
    /// </summary>
    /// <param name="field">Field in which this seed is planted</param>
    public void SetField(FieldSlot field)
    {
      _field = field;
    }

    /// <summary>
    /// Sets the parent crop
    /// </summary>
    /// <param name="crop">The parent crop of this seed</param>
    public void SetParentCrop(Crop crop)
    {
      ParentCrop = crop;
    }

    /// <summary>
    /// Calculates the daily growth rate
    /// </summary>
    private void CalculateGrowthRate()
    {
      //TODO: do calculations based on weather, quality, current health, water, parent growth rate and a small random factor
      GrowthRate = BaseGrowth;
    }

    /// <summary>
    /// Calculates the daily required water
    /// </summary>
    private void CalculateRequiredWater()
    {
      //TODO: do calculations based on weather, current healh, water, parent robustheit...
      _requiredWater = RequiredWaterBase;
    }
  }
}
