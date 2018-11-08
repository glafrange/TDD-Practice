using System;
using System.Collections.Generic;

namespace GreetingService
{
    public class Class1
    {
        public string Greet()
        {
            return Greet("my friend");
        }

        public string Greet(string name)
        {
            if (name == "") return Greet();
            if (Char.IsUpper(name[1]))
            {
                foreach (char letter in name)
                {
                    Char.ToUpper(letter);
                }
                var greeting = "HELLO " + name + "!";
                return greeting;
            } else
            {
                var greeting = "Hello, " + name + ".";
                return greeting;
            }
        }

        public string Greet(string[] names)
        {
            var greeting = "Hello";
            List<string> namesSplit = new List<string>();


            foreach (string name in names)
            {
                if (name[0] != '\"')
                {
                    if (name.Contains(","))
                    {
                        var splitNames = name.Split(',');
                        foreach (string x in splitNames) namesSplit.Add(x.TrimStart(' '));
                    }
                    else
                    {
                        namesSplit.Add(name);
                    }
                }
                else
                {
                    namesSplit.Add(name.TrimStart('\"').TrimEnd('\"'));
                }
                
            }

            List<string> namesLower = new List<string>();
            List<string> namesUpper = new List<string>();

            foreach (string name in namesSplit)
            {
                if (IsAllUpper(name))
                    namesUpper.Add(name);
                else
                    namesLower.Add(name);
            }

            if (namesLower.Count == 2)
            {
                greeting += ", " + namesLower[0] + " and " + namesLower[1] + ".";
            }
            else
            {
                for (int i = 0; i < namesLower.Count - 1; i++)
                {
                    greeting += ", " + namesLower[i];
                }

                for (int i = namesLower.Count - 1; i < namesLower.Count; i++)
                {
                    greeting += ", and " + namesLower[i];
                }

                greeting += ".";
            }
        
            if (namesUpper.Count > 0)
            {
                greeting += " AND HELLO";
                for (int i = 0; i < namesUpper.Count; i++)
                {
                    greeting += " " + namesUpper[i];
                }
                greeting += "!";
            }
            

            return greeting;
        }

        private bool IsAllUpper(string str)
        {
            foreach (char letter in str)
            {
                if (!Char.IsUpper(letter))
                    return false;
            }
            return true;
        }
    }
}
