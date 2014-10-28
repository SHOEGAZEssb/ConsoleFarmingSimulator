using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFarmingSimulator
{
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
        if (_health - value < 0)
          Health = 0;
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

    public Enumerations.SeedType SeedType
    {
      get { return _seedType; }
      private set { _seedType = value; }
    }
      
    public int LifeSpan
    {
      get { return _lifeSpan; }
      private set { _lifeSpan = value; }
    }



    public int Age
    {
      get { return _age; }
      private set { _age = value; }
    }
    
    

    /// <summary>
    /// Quality of the seed
    /// </summary>
    public Enumerations.Quality SeedQuality
    {
      get { return _seedQuality; }
      private set { _seedQuality = value; }
    }
    
    public Seed (string name, double baseGrowth, Enumerations.SeedType seedType, Enumerations.Quality seedQuality, int lifeSpan, double requiredWater)
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
      _requiredWater = requiredWater;
      Crops = new List<Crop>();   
    }

    public void GetInfo()
    {
      Console.WriteLine("Name: " + Name);
      Console.WriteLine("Type: " + SeedType);
      Console.WriteLine("Growth: " + Growth + "%");
      Console.WriteLine("Base Growth: " + BaseGrowth);
      Console.WriteLine("Health: " + Health + "/100%");
      Console.WriteLine("Quality: " + SeedQuality);
      Console.WriteLine();
    }

    public void GetDeepInfo()
    {
      foreach (Crop crop in Crops)
      {
        crop.GetInfo();
        Console.WriteLine();
      }
    }

    public void Grow()
    {


      double factor = 1.0;
      if(_field.Water >= _requiredWater)
      {
        _field.Water -= _requiredWater;
        
      }
      else
      {
        double percentage = _field.Water * 100 / _requiredWater;
        _field.Water = 0;

        Random rnd = new Random((int)(DateTime.Now.Ticks.GetHashCode()));
        int healthDamage = rnd.Next(1, 10 - (int)(percentage/50)); //TODO: add robustheit lol
        Health -= healthDamage;      
      }

      if(Health != 0)
        Growth += GrowthRate;
      else
      {

      }
    }

    public void SetField(FieldSlot field)
    {
      _field = field;
    }

    private void CalculateGrowthRate()
    {
      //TODO: do calculations based on weather, quality, current health, water, parent growth rate and a small random factor
      GrowthRate = BaseGrowth;
    }
  }
}
