
using System;
using System.Collections;
using System.IO;

namespace ProjectEnv
{
  public class Experiment
  {
    public ArrayList Factors = new ArrayList();

    public Experiment(CSVFile file)
    {
      for (int index = 0; index < file.names.Count; ++index)
      {
        if (((string) file.names[index]).IndexOf("Valid") == -1)
          this.Factors.Add((object) new Factor(file, index));
      }
    }

    public void Save(Stream stream)
    {
      StreamWriter streamWriter = new StreamWriter(stream);
      streamWriter.WriteLine("Name,Expectation,Dispersion,IsOptimal");
      for (int index = 0; index < this.Factors.Count; ++index)
      {
        Factor factor = (Factor) this.Factors[index];
        streamWriter.WriteLine(factor.Name + "," + factor.Expectation.ToString().Replace(',', '.') + "," + factor.Dispersion.ToString().Replace(',', '.') + "," + factor.IsOptimal.ToString());
      }
      streamWriter.Close();
    }

    public void Optimize(int m)
    {
      int length = 1;
      for (int index = 0; index < this.Factors.Count; ++index)
      {
        Factor factor = (Factor) this.Factors[index];
        length += (int) Math.Round(factor.Dispersion * 100.0);
      }
      int[,] numArray1 = new int[length, m + 1];
      int[,] numArray2 = new int[length, m + 1];
      int[,] numArray3 = new int[length, m + 1];
      for (int index1 = 0; index1 < length; ++index1)
      {
        for (int index2 = 0; index2 <= m; ++index2)
        {
          numArray1[index1, index2] = -1;
          numArray2[index1, index2] = -1;
          numArray3[index1, index2] = -1;
        }
      }
      numArray1[0, 0] = 0;
      for (int index3 = 0; index3 < this.Factors.Count; ++index3)
      {
        Factor factor = (Factor) this.Factors[index3];
        int num = (int) Math.Round(factor.Dispersion * 100.0);
        factor.IsOptimal = false;
        for (int index4 = m; index4 >= 1; --index4)
        {
          for (int index5 = length - 1; index5 >= 0; --index5)
          {
            if (index5 >= num && numArray1[index5 - num, index4 - 1] != -1 && numArray1[index5, index4] == -1)
            {
              numArray1[index5, index4] = numArray1[index5 - num, index4 - 1] + num;
              numArray2[index5, index4] = index5 - num;
              numArray3[index5, index4] = index3;
            }
          }
        }
      }
      int index6 = -1;
      for (int index7 = 0; index7 < length; ++index7)
      {
        if (numArray1[index7, m] >= 0)
        {
          index6 = index7;
          break;
        }
      }
      if (index6 < 0)
        return;
      for (int index8 = m; index8 > 0; --index8)
      {
        ((Factor) this.Factors[numArray3[index6, index8]]).IsOptimal = true;
        index6 = numArray2[index6, index8];
      }
    }
  }
}
