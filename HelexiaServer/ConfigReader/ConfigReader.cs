using System;
using System.IO;
using System.Collections.Generic;

namespace HelexiaServer.ConfigReader
{
    public class ConfigReader
    {
        public string path
        {
            set
            {

            }
            private get
            {
                return path;
            }
        }

        public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        
        public void Read()
        {
            foreach(string line in File.ReadAllLines(path))
            {
                string[] parts = line.Split(Convert.ToChar("="));
                string value = "";
                int i = 0;
                foreach(string s in parts)
                {
                    if(i < 0)
                    {
                        if(i == 1)
                        {
                            value = s;
                        }
                        else
                        {
                            value += s + " ";
                        }
                    }
                    i++;
                }
                keyValuePairs.Add(parts[0], value);
            }
        }
        public string GetValue(string key)
        {
            try
            {
                string result = keyValuePairs[key];
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Key " + key + "not found");
            }
        }
    }
}
