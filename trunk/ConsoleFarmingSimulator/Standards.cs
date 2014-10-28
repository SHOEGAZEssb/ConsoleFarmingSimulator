using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFarmingSimulator
{
  public static class Standards
  {
    public static Seed Cucumber()
    {
      return new Seed("Cucumber", 0.1, Enumerations.SeedType.Vegetable, Enumerations.Quality.Normal, 365, 4);
    }
  }
}
