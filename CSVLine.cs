
using System.Collections;

namespace ProjectEnv
{
  public class CSVLine
  {
    public static int ROW_ID = -1;
    public ArrayList values = new ArrayList();
    public int rowid;

    public CSVLine(ParsingStream stream)
    {
      while (!stream.atEnd())
      {
        this.values.Add((object) this.parseValue(stream));
        if (stream.current == 10)
        {
          stream.Read();
          break;
        }
      }
      this.rowid = ++CSVLine.ROW_ID;
    }

    public string parseValue(ParsingStream stream)
    {
      string str = "";
      stream.parseBlanks();
      int num = -1;
      if (stream.current == 34 || stream.current == 39)
      {
        num = stream.current;
        stream.Read();
      }
      if (num == -1)
      {
        while (!stream.atEnd() && ",;".IndexOf((char) stream.current) == -1 && stream.current != 10)
        {
          if (stream.current == 92 && num != -1)
          {
            stream.Read();
            str += ((char) stream.current).ToString();
          }
          else
            str += ((char) stream.current).ToString();
          stream.Read();
        }
      }
      else
      {
        while (!stream.atEnd() && stream.current != 10 && stream.current != num && ",;".IndexOf((char) stream.current) == -1)
        {
          if (stream.current == 92)
          {
            stream.Read();
            str += ((char) stream.current).ToString();
          }
          else
            str += ((char) stream.current).ToString();
          stream.Read();
        }
        if (stream.current == num)
          stream.Read();
      }
      stream.parseBlanks();
      if (",; \t".IndexOf((char) stream.current) >= 0)
        stream.Read();
      stream.parseBlanks();
      return str.Trim();
    }
  }
}
