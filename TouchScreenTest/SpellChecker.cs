using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TouchScreenTest
{
    class SpellChecker
    {

        public static String GetSpellBuild(List<SpellCounter> allCounters)//, String[] spellToCheck) 
        {
            //Temp
            String[] spellToCheck = {"1,2","2,3","3,4" };
       
            List<String> mappedValues = new List<String>();
            for (int i = 0; i < allCounters.Count; i++)
            {
                SpellCounter currentCounter = allCounters[i];
                List<SpellCounter> connectors = currentCounter.GetConnectors();
                String mainId = currentCounter.id.ToString();
       

                foreach(SpellCounter counterConnected in connectors){
                    String connectorId = counterConnected.id.ToString();
       
                    string map = mainId + "," + connectorId;
                    mappedValues.Add(map);
                }
            }

            mappedValues.Sort(sortSpell);

            

            bool isEqual = true;

            isEqual = mappedValues.Count == spellToCheck.Length && mappedValues.Count > 0;
            String showValue = "";

            if (isEqual) {
                for (int i = 0; i < mappedValues.Count; i++)
                {
                    isEqual &= mappedValues[i].CompareTo(spellToCheck[i]) == 0;
                   
                }
            }
            for (int i = 0; i < mappedValues.Count; i++)
            {
                showValue += "(" + mappedValues[i] + ") ";
                if (i % 15 == 0 && i != 0)
                    showValue += Environment.NewLine;
            }
            

            return isEqual ? "Success" : showValue;

        }

        private static int sortSpell(string connector1, string connector2)
        {

            String[] spellInformationA = connector1.Split(',');
            String[] spellInformationB = connector2.Split(',');

            if (int.Parse(spellInformationA[0]) == int.Parse(spellInformationB[0]))
            {
                return int.Parse(spellInformationA[1]).CompareTo(int.Parse(spellInformationB[1]));
            }
            else
            {
                return int.Parse(spellInformationA[0]).CompareTo(int.Parse(spellInformationB[0]));
            }

        }

    }
}
