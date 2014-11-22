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
    private double _seedGrowth;
    private double _seedGrowthRate;
    private double _baseSeedGrowth;
    private double _cropGrowth;
    private double _cropGrowthRate;
    private double _baseCropGrowth;
    private List<Crop> _crops;
    private double _health;
    private Enumerations.SeedType _seedType;
    private Enumerations.Quality _seedQuality;
    private int _age;
    private double _optimalTemperature;
    private FieldSlot _field;
    private double _requiredWaterBase;
    private double _requiredWater;
    private int _cropRate;
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
      private set { _crops = value; }
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
    public double SeedGrowth
    {
      get { return _seedGrowth; }
      private set { _seedGrowth = value; }
    }

    /// <summary>
    /// Current growth rate of the seed
    /// </summary>
    public double SeedGrowthRate
    {
      get { return _seedGrowthRate; }
      private set { _seedGrowthRate = value; }
    }

    /// <summary>
    /// Base growth of the seed
    /// </summary>
    public double BaseSeedGrowth
    {
      get { return _baseSeedGrowth; }
      private set { _baseSeedGrowth = value; }
    }

    /// <summary>
    /// Growth of the seed. 
    /// </summary>
    public double CropGrowth
    {
      get { return _cropGrowth; }
      private set { _cropGrowth = value; }
    }

    /// <summary>
    /// Current growth rate of the seed
    /// </summary>
    public double CropGrowthRate
    {
      get { return _cropGrowthRate; }
      private set { _cropGrowthRate = value; }
    }

    /// <summary>
    /// Base growth of the seed
    /// </summary>
    public double BaseCropGrowth
    {
      get { return _baseCropGrowth; }
      private set { _baseCropGrowth = value; }
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

    public Enumerations.SeedType SeedType
    {
      get { return _seedType; }
      private set { _seedType = value; }
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
    /// The optimal temperature for this seed to get his full grow potential
    /// </summary>
    public double OptimalTemperature
    {
      get { return _optimalTemperature; }
      private set { _optimalTemperature = value; }
    }

    /// <summary>
    /// The field this seed is planted in
    /// </summary>
    public FieldSlot Field
    {
      get { return _field; }
      private set { _field = value; }
    }

    /// <summary>
    /// The crop which contained this seed
    /// </summary>
    public Crop ParentCrop
    {
      get { return _parentCrop; }
      set { _parentCrop = value; } //TODO: safety
    }

    /// <summary>
    /// Initializes a new seed
    /// </summary>
    public Seed(string name, double baseSeedGrowth, Enumerations.SeedType seedType, Enumerations.Quality seedQuality, double requiredWater, Crop parentCrop, double optimalTemperature, int cropRate, double baseCropGrowth)
    {
      Name = name;
      BaseSeedGrowth = baseSeedGrowth;
      SeedGrowth = 0;
      BaseCropGrowth = baseCropGrowth;
      Age = 0;
      Health = 100.0;
      SeedType = seedType;
      SeedQuality = seedQuality;
      RequiredWaterBase = requiredWater;
      Crops = new List<Crop>();
      OptimalTemperature = optimalTemperature;
      _cropRate = cropRate;
      ParentCrop = parentCrop;
    }

    public Seed()
    {

    }

    /// <summary>
    /// Gets info about the seed
    /// </summary>
    /// <returns>String with info</returns>
    public string GetInfo()
    {
      return "Name: " + Name + "\r\nType: " + SeedType + "\r\nGrowth: " + SeedGrowth + "&\r\nHealth: " + Health + "%\r\n";
    }

    /// <summary>
    /// Get info about all crops on this seed
    /// </summary>
    /// <returns>String with info</returns>
    public string GetDeepInfo()
    {
      string info = "";

      for (int i = 0; i < Crops.Count; i++ )
      {
        info += Crops[i].GetInfo();
        info += "\r\n";
      }
      
      return info;
    }

    /// <summary>
    /// Daily grow process
    /// </summary>
    public void Grow()
    {
      Age++;

      CalculateRequiredWater();
      if (_field.Water >= _requiredWater)
        _field.Water -= _requiredWater;
      else
      {
        double percentage = _field.Water * 100 / _requiredWater;
        _field.Water = 0;

        Random rnd = new Random((int)(DateTime.Now.Ticks.GetHashCode()));
        int healthDamage = rnd.Next(1, 10 - (int)(percentage / 50)); //TODO: add robustheit lol
        Health -= healthDamage;
      }

      if (Health != 0)
      {
        CalculateSeedGrowthRate();
        CalculateCropGrowthRate();

        SeedGrowth += SeedGrowthRate;
        CropGrowth += CropGrowthRate;
        GrowCrops();
      }
      else
      {

      }
    }

    /// <summary>
    /// Sets the growth of the crops to adapt their weights
    /// </summary>
    private void GrowCrops()
    {
      foreach(Crop crop in Crops)
      {
        crop.Growth = CropGrowth;
      }
    }

    /// <summary>
    /// Harvest all crops from this seed
    /// </summary>
    public void Harvest()
    {      
      foreach (Crop crop in Crops)
      {
        Program.Game.AddCropToInventory(crop);
        this.Crops.Remove(crop);
      }

      if(SeedType == Enumerations.SeedType.Vegetable)
        Field.RemoveSeed();
    }

    /// <summary>
    /// Sets the field in which this seed is planted
    /// </summary>
    /// <param name="field">Field in which this seed is planted</param>
    public void SetField(FieldSlot field)
    {
      Field = field;
    }

    /// <summary>
    /// Calculates the daily seed growth rate
    /// </summary>
    private void CalculateSeedGrowthRate()
    {
      //TODO: do calculations based on weather, quality, current health, water, parent growth rate and a small random factor
      SeedGrowthRate = BaseSeedGrowth;
    }

    /// <summary>
    /// Calculates the daily crop growth rate
    /// </summary>
    private void CalculateCropGrowthRate()
    {
      if (SeedType == Enumerations.SeedType.Vegetable)
        CropGrowthRate = BaseCropGrowth;
      else
      {
        Random rnd = new Random((int)DateTime.Now.Ticks.GetHashCode());
        double num = rnd.Next(-10, 10);
        double newRate = (((1.0 + (num / 100)) + (int)Program.Game.CurrentWeather.WeatherCondition / 10) + (BaseCropGrowth - Standards.Seeds.GetStandardSeed("Cucumber").BaseCropGrowth)) * BaseCropGrowth;
        CropGrowthRate = newRate;
      }
    }

    /// <summary>
    /// Calculates the daily required water
    /// </summary>
    private void CalculateRequiredWater()
    {
      //TODO: do calculations based on weather, current healh, water, parent robustheit...
      double faktor = 1.0;

      if (Program.Game.CurrentWeather.WeatherCondition == Enumerations.WeatherCondition.Sun)
      {
        faktor += Program.Game.CurrentWeather.Temperature / 70;
      }

      if (Program.Game.CurrentWeather.Temperature < OptimalTemperature + 2 && Program.Game.CurrentWeather.Temperature > OptimalTemperature - 2)
        faktor -= 0.25;

      _requiredWater = RequiredWaterBase * faktor;
    }

    public double CalculatePrice()
    {
      //TODO: Calculate price based on health, quality etc..
      return 10;
    }

    /// <summary>
    /// Initializes the crops added when planting this seed
    /// </summary>
    public void InitializeCrops()
    {
      Random rnd = new Random((int)DateTime.Now.Ticks.GetHashCode());

      //TODO: this will be used when extracting seeds from the finished crop
      //int extraCropChance = 0;
      //extraCropChance += (int)SeedQuality;
      //if (rnd.Next(extraCropChance, 100) == extraCropChance)
      //  _cropRate++;

      int cropsToGrow = _cropRate;
      cropsToGrow += rnd.Next(-2, 2);

      for(int i = 0; i < cropsToGrow; i++)
      {
        double num = rnd.Next(-10, 10);
        double newWeight = ((double)((num / 100) * -(int)SeedQuality) * ParentCrop.EndWeight) + ParentCrop.EndWeight;
        Crops.Add(new Crop(Name, newWeight, this));
      }    
    }
  }
}