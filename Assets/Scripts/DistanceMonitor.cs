﻿/* Unity Usings */
using UnityEngine;

/* Other Usings */
using Vuforia;

/* System Usings */
using System.Linq;
using System.Collections.Generic;

/* App Usings */
using Assets.Scripts.Chemistry;

namespace Assets.Scripts
{
    public class DistanceMonitor : MonoBehaviour
    {
        private bool IsAnimationActive { get; set; }

        public struct ActiveWithEnum
        {
            public TrackableBehaviour Active { get; private set; }
            public ATOM Atom { get; private set; }

            public bool WasConsider { get; set; }

            public ActiveWithEnum(TrackableBehaviour newActive, ATOM newAtom)
            {
                this.Active = newActive;
                this.Atom = newAtom;

                this.WasConsider = false;
            }
        }

        public void Start()
        {
            this.IsAnimationActive = false;
        }

        public void Update()
        {
            /* Get the Vuforia's StateManager */
            StateManager vuforiaStateManager = TrackerManager.Instance.GetStateManager();

            /* Query the StateManager to Retrieve the List of Currently 'ACTIVE' Markers */
            List<TrackableBehaviour> activeTrackables = vuforiaStateManager.GetActiveTrackableBehaviours().ToList();

            /* Since We Only Use Three Atom Molecules Return If Less Than Three Are Recognized */
            if (activeTrackables.Count < 3) return;

            List<ActiveWithEnum> listWithProjection = activeTrackables.Select(active =>
                   new ActiveWithEnum(active, ChemistryMatches.Instance.NameToAtomDictionary[active.name.Substring(0, active.name.IndexOf('_'))])).ToList();

            /* Get Chemistry Matches Instance */
            List<ChemistryMatches.ChemistryMatch> chemistryMatchesList = ChemistryMatches.Instance.ChemistryMatchesInstance;

            for (int i = 0; i < chemistryMatchesList.Count; i++)
            {
                /* Check If There Is A Match On The Scene */
                List<ActiveWithEnum> matchedAtoms = this.CheckMatch(chemistryMatchesList[i].Elements, listWithProjection);

                /* If No Match Found Do Nothing */
                if (matchedAtoms == null) continue;

                List<bool> isDistansCorrect = new List<bool>();

                /* Check The Distant Between Atoms In The Scene */
                for (int k = 0; k < matchedAtoms.Count - 1; k++)
                    isDistansCorrect.Add(
                        Vector3.Distance(matchedAtoms[k].Active.transform.position, matchedAtoms[k + 1].Active.transform.position) < 1.15f);

                /* Is Any Of The Distant Is InCorrect Then Do Nothing */
                if (isDistansCorrect.Any(distance => distance == false) == true)
                    continue;

                /* Check If Points Are Almost Collinear */
                Vector3 firstToSecondVector = matchedAtoms[1].Active.transform.position - matchedAtoms[0].Active.transform.position;
                Vector3 firstToThirdVector = matchedAtoms[2].Active.transform.position - matchedAtoms[0].Active.transform.position;

                if (Vector3.Angle(firstToSecondVector, firstToThirdVector) > 5.0f)
                    continue;

                /* Start The Merge Animation */
                //if (this.IsAnimationActive == false)
                {
                    if (matchedAtoms[0].Active.transform.GetChild(0).GetChild(0).gameObject.activeSelf == false
                        || matchedAtoms[2].Active.transform.GetChild(0).GetChild(0).gameObject.activeSelf == false) continue;

                    GameObject.Find("SceneMonitor").GetComponent<SceneMonitor>().AddMolecule(matchedAtoms);

                    this.IsAnimationActive = true;
                    this.GetComponent<AtomMoleculeTransform>().Proceed(matchedAtoms,
                        ChemistryMatches.Instance.MoleculeToNameDictionary[chemistryMatchesList[i].SubstanceName]);
                }
            }
        }

        private List<ActiveWithEnum> CheckMatch(List<ATOM> atomsExpected, List<ActiveWithEnum> atomsPresentedOnScene)
        {
            List<bool> wasConsidered = new List<bool>();
            List<ActiveWithEnum> candidatesToMatch = new List<ActiveWithEnum>();

            for (int i = 0; i < atomsPresentedOnScene.Count; i++)
                wasConsidered.Add(false);

            /* For Every Atom Expected Check If There Is One In The Scene */
            for (int i = 0; i < atomsExpected.Count; i++)
                for (int k = 0; k < atomsPresentedOnScene.Count; k++)
                    if (wasConsidered[k] == false && atomsExpected[i] == atomsPresentedOnScene[k].Atom)
                    {
                        candidatesToMatch.Add(atomsPresentedOnScene[k]);
                        wasConsidered[k] = true; break;
                    }

            if (candidatesToMatch.Count != 3) return null;

            return candidatesToMatch;
        }

        public void ResetTheAnimation() { this.IsAnimationActive = false; }
    }
}
