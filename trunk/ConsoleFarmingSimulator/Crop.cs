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
    private double _growth;
    private Seed _parentSeed;

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
      set { _parentSeed = value; } //TODO: safety
    }

    /// <summary>
    /// Initializes a new crop
    /// </summary>
    public Crop(string name, double weight, Seed parentSeed)
    {
      Name = name;
      EndWeight = weight;
      CalculateQuality();
      ParentSeed = parentSeed;
    }

    public Crop()
    {

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
    /// Calculates the quality based on... (?)
    /// </summary>
    private void CalculateQuality()
    {
      CropQuality = Enumerations.Quality.Normal;
    }

    /// <summary>
    /// Calculates the price of this crop based on quality and weight
    /// </summary>
    /// <returns>Calculated price</returns>
    public double CalculatePrice()
    {
      double price = ((CurrentWeight * Standards.Crops.SingleValues.Prices.GetStandardPrice(Name)) * Standards.Crops.GetStandardCrop(Name).EndWeight)  * (1.0 + ((double)CropQuality / 10.0));
      return price;
    }
  }
}