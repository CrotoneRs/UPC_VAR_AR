/*
    File Defines Matches Between Elements and Substances Used in Application
*/

/* System Usings */
using System.Collections.Generic;

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
        public Dictionary<MOLECULE, string> MoleculeToNameDictionary { get; set; }

        public ChemistryMatches()
        {
            this.CreateChemistryMatches();

            this.CreateNameToAtomDictionary();
            this.CreateNameToMoleculeDictionary();
        }

        private void CreateChemistryMatches()
        {
            this.ChemistryMatchesInstance = new List<ChemistryMatch>();

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.CARBON_DIOXIDE,
                new List<ATOM>() { ATOM.OXYGEN, ATOM.CARBON, ATOM.OXYGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.SILICON_DIOXIDE,
                new List<ATOM>() { ATOM.OXYGEN, ATOM.SILICON, ATOM.OXYGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.DICARBON_MONIXIDE,
                new List<ATOM>() { ATOM.CARBON, ATOM.OXYGEN, ATOM.CARBON }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.HYDROGEN_CYANIDE,
                new List<ATOM>() { ATOM.HYDROGEN, ATOM.CARBON, ATOM.NITROGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.HYDROGEN_ISOCYANIDE,
               new List<ATOM>() { ATOM.HYDROGEN, ATOM.NITROGEN, ATOM.CARBON }));

            //this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.NITROUS_OXIDE,
            //   new List<ATOM>() { ATOM.NITROGEN, ATOM.OXYGEN, ATOM.NITROGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.SODIUM_HYDROXIDE,
               new List<ATOM>() { ATOM.SODIUM, ATOM.OXYGEN, ATOM.HYDROGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.DIHYDRIDOCARBON,
               new List<ATOM>() { ATOM.HYDROGEN, ATOM.CARBON, ATOM.HYDROGEN }));
            
            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.DIHYDROGEN_MONOXIDE,
                new List<ATOM>() { ATOM.HYDROGEN, ATOM.OXYGEN, ATOM.HYDROGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.DIHYDROGEN_MONOSULIFIDE,
                new List<ATOM>() { ATOM.HYDROGEN, ATOM.SULFUR, ATOM.HYDROGEN }));
            
            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.NITROGEN_DIOXIDE,
                new List<ATOM>() { ATOM.OXYGEN, ATOM.NITROGEN, ATOM.OXYGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.SULFUR_DIOXIDE,
               new List<ATOM>() { ATOM.OXYGEN, ATOM.SULFUR, ATOM.OXYGEN }));

            this.ChemistryMatchesInstance.Add(new ChemistryMatch(MOLECULE.HYDROPEROXYL,
               new List<ATOM>() { ATOM.OXYGEN, ATOM.HYDROGEN, ATOM.OXYGEN }));
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

        private void CreateNameToMoleculeDictionary()
        {
            this.MoleculeToNameDictionary = new Dictionary<MOLECULE, string>();

            this.MoleculeToNameDictionary.Add(MOLECULE.CARBON_DIOXIDE, "CARBON_DIOXIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.SILICON_DIOXIDE, "SILICON_DIOXIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.DICARBON_MONIXIDE, "DICARBON_MONIXIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.HYDROGEN_CYANIDE, "HYDROGEN_CYANIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.HYDROGEN_ISOCYANIDE, "HYDROGEN_ISOCYANIDE");
            //this.MoleculeToNameDictionary.Add(MOLECULE.NITROUS_OXIDE, "NITROUS_OXIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.SODIUM_HYDROXIDE, "SODIUM_HYDROXIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.DIHYDRIDOCARBON, "DIHYDRIDOCARBON");
            this.MoleculeToNameDictionary.Add(MOLECULE.DIHYDROGEN_MONOXIDE, "DIHYDROGEN_MONOXIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.DIHYDROGEN_MONOSULIFIDE, "DIHYDROGEN_MONOSULIFIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.NITROGEN_DIOXIDE, "NITROGEN_DIOXIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.SULFUR_DIOXIDE, "SULFUR_DIOXIDE");
            this.MoleculeToNameDictionary.Add(MOLECULE.HYDROPEROXYL, "HYDROPEROXYL");

        }
    }
}
