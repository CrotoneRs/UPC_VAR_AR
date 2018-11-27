/* System Usings */
using System.Collections.Generic;

/*
    File Defines Matches Between Elements and Substances Used in Application
*/

namespace Assets.Scripts.Chemistry
{
    public class ChemistryMatches
    {
        public struct ChemistryMatch
        {
            public SUSBSTANCE SubstanceName { get; set; }
            public List<ELEMENTS> Elements { get; set; }

            public ChemistryMatch(SUSBSTANCE newName, List<ELEMENTS> newElements)
            {
                this.SubstanceName = newName;
                this.Elements = newElements;
            }
        }

        private static ChemistryMatches mInstance = null;
        private static readonly object lockObject = new object();

        public static ChemistryMatches Instance
        {
            get
            {
                lock (ChemistryMatches.lockObject)
                {
                    if (ChemistryMatches.mInstance == null)
                    {
                        ChemistryMatches.mInstance = new ChemistryMatches();
                    }
                }

                return ChemistryMatches.mInstance;
            }
        }

        public List<ChemistryMatch> ChemistryMatchesInstance { get; set; }

        public ChemistryMatches()
        {
            this.ChemistryMatchesInstance = new List<ChemistryMatch>();

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(SUSBSTANCE.WATER,
                new List<ELEMENTS>() { ELEMENTS.HYDROGEN, ELEMENTS.OXYGEN, ELEMENTS.HYDROGEN }));
        }
    }
}
