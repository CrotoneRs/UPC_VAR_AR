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
            public MOLECULE SubstanceName { get; set; }
            public List<ATOM> Elements { get; set; }

            public ChemistryMatch(MOLECULE newName, List<ATOM> newElements)
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

        public Dictionary<string, ATOM> NameToAtomDictionary { get; set; }

        public ChemistryMatches()
        {
            this.CreateChemistryMatches();
            this.CreateNameToAtomDictionary();
        }

        private void CreateChemistryMatches()
        {
            this.ChemistryMatchesInstance = new List<ChemistryMatch>();

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.DIHYDROGEN_MONOXIDE,
                new List<ATOM>() { ATOM.HYDROGEN, ATOM.OXYGEN, ATOM.HYDROGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.CARBON_DIOXIDE,
                new List<ATOM>() { ATOM.OXYGEN, ATOM.CARBON, ATOM.OXYGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.DICARBON_MONIXIDE,
                new List<ATOM>() { ATOM.CARBON, ATOM.OXYGEN, ATOM.CARBON }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.SODIUM_HYDROXIDE,
                new List<ATOM>() { ATOM.SODIUM, ATOM.OXYGEN, ATOM.HYDROGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.NITROGEN_DIOXIDE,
                new List<ATOM>() { ATOM.OXYGEN, ATOM.NITROGEN, ATOM.OXYGEN }));
        }

        private void CreateNameToAtomDictionary()
        {
            this.NameToAtomDictionary = new Dictionary<string, ATOM>();

            this.NameToAtomDictionary.Add("Carbon", ATOM.CARBON);
            this.NameToAtomDictionary.Add("Hydrogen", ATOM.HYDROGEN);
            this.NameToAtomDictionary.Add("Nitrogen", ATOM.NITROGEN);
            this.NameToAtomDictionary.Add("Oxygen", ATOM.OXYGEN);
            this.NameToAtomDictionary.Add("Phosphorus", ATOM.PHOSPHORUS);
            this.NameToAtomDictionary.Add("Silicon", ATOM.SILICON);
            this.NameToAtomDictionary.Add("Sodium", ATOM.SODIUM);
            this.NameToAtomDictionary.Add("Sulfur", ATOM.SULFUR);
        }
    }
}
