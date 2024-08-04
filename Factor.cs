
using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEnv
{
  public class Factor
  {
    public Dictionary<string, int> Discretes = new Dictionary<string, int>();
    public ArrayList Values = new ArrayList();
    public ArrayList Probabilities = new ArrayList();
    public string Name = (string) null;
    public double Sum = 0.0;
    public double Expectation = 0.0;
    public double Dispersion = 0.0;
    public bool IsOptimal = false;
    public int ValidIndex = -1;

    public Factor(CSVFile file, int index)
    {
      this.Name = file.names[index].ToString();
      for (int index1 = 0; index1 < file.names.Count; ++index1)
      {
        if (file.names[index1].ToString().IndexOf("Valid") >= 0 && this.ValidIndex == -1)
          this.ValidIndex = index1;
      }
      for (int index2 = 0; index2 < file.lines.Count; ++index2)
      {
        CSVLine line = (CSVLine) file.lines[index2];
        if (this.ValidIndex == -1 || line.values[this.ValidIndex].ToString().ToUpper().Equals("Y"))
        {
          string str = (string) line.values[index];
          double result = 0.0;
          if (double.TryParse(str, out result))
          {
            this.Values.Add((object) result);
          }
          else
          {
            if (!this.Discretes.ContainsKey(str))
              this.Discretes.Add(str, this.Discretes.Count);
            this.Values.Add((object) 1.0);
          }
        }
      }
      for (int index3 = 0; index3 < this.Values.Count; ++index3)
        this.Sum += (double) this.Values[index3];
      for (int index4 = 0; index4 < this.Values.Count; ++index4)
      {
        this.Probabilities.Add((object) ((double) this.Values[index4] / this.Sum));
        this.Expectation += (double) this.Values[index4] * (double) this.Probabilities[index4];
      }
      for (int index5 = 0; index5 < this.Values.Count; ++index5)
        this.Dispersion += (double) this.Probabilities[index5] * Math.Pow((double) this.Values[index5] - this.Expectation, 2.0);
    }
  }
}
