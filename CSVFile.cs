
using System.Collections;
using System.Collections.Generic;

namespace ProjectEnv
{
  public class CSVFile
  {
    public string name = (string) null;
    public ArrayList names = new ArrayList();
    public Dictionary<string, int> namesIndex = new Dictionary<string, int>();
    public ArrayList lines = new ArrayList();

    public CSVFile(ParsingStream stream, string name)
    {
      this.name = name;
      CSVLine csvLine1 = new CSVLine(stream);
      int num = 0;
      foreach (string key in csvLine1.values)
      {
        this.names.Add((object) key);
        this.namesIndex.Add(key, num++);
      }
      while (!stream.atEnd())
      {
        CSVLine csvLine2 = new CSVLine(stream);
        if (csvLine2.values.Count > 0)
          this.lines.Add((object) csvLine2);
      }
    }
  }
}
