using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace prviProjekatDrugiPut
{
    public class Datoteke<Object>
    {
        public static List<Object> citanje(string putanja)
        {
            List<Object> list = new List<Object>();
            try
            {
                if (!File.Exists(putanja)) {
                    return list;
                }

                FileStream fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();      
                list = bf.Deserialize(fs) as List<Object>;
                fs.Flush();
                fs.Dispose();

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
            return list;
        }


        public static bool upis(string putanja, List<Object> list)
        {
            try
            {
                FileStream fs = File.OpenWrite(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, list);
                fs.Flush();
                fs.Dispose();
            }
            catch (Exception exp)
            {
                return false;
            }
            return true;
        }
    }
}
