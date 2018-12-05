/*
    File Defines Atom-Molecule Transformation Script
*/

/* Unity Usings */
using UnityEngine;

/* System Usings */
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Chemistry
{
    public class AtomMoleculeTransform : MonoBehaviour
    {
        public void Proceed(List<DistanceMonitor.ActiveWithEnum> matchedAtoms, string moleculeName)
        {
            this.StartCoroutine(TranslateAtomsToCenter(matchedAtoms, moleculeName));
        }

        private IEnumerator TranslateAtomsToCenter(List<DistanceMonitor.ActiveWithEnum> matchedAtoms, string moleculeName)
        {
            string atomName_1 = matchedAtoms[0].Active.name.Split('_')[0];
            string atomName_2 = matchedAtoms[1].Active.name.Split('_')[0];
            string atomName_3 = matchedAtoms[2].Active.name.Split('_')[0];

            Vector3 firstPosition = matchedAtoms[0].Active.transform.Find("GameObject/Atom/" + atomName_1 + "Atom").position;
            Vector3 secondPosition = matchedAtoms[1].Active.transform.Find("GameObject/Atom/" + atomName_2 + "Atom").position;
            Vector3 thirdPosition = matchedAtoms[2].Active.transform.Find("GameObject/Atom/" + atomName_3 + "Atom").position;

            Vector3 firstToSecondDirection = secondPosition - firstPosition;
            Vector3 thirdToSecondDirection = secondPosition - thirdPosition;

            float firstToSecond = Vector3.Distance(firstPosition, secondPosition);
            float secondToThird = Vector3.Distance(thirdPosition, secondPosition);

            float interpolationTime = 0.0f; float animationDuration = 1.5f; /* In Seconds */

            float distanceToCenter = Math.Max(firstToSecond, secondToThird);

            while (distanceToCenter > 0.15f)
            {
                float interpolationValue = interpolationTime / animationDuration;

                Vector3 newFirstPosition = firstPosition + interpolationValue * firstToSecondDirection;
                Vector3 newThirdPosition = thirdPosition + interpolationValue * thirdToSecondDirection;

                matchedAtoms[0].Active.transform.Find("GameObject/Atom/" + atomName_1 + "Atom").position = newFirstPosition;
                matchedAtoms[2].Active.transform.Find("GameObject/Atom/" + atomName_3 + "Atom").position = newThirdPosition;

                firstToSecond = Vector3.Distance(newFirstPosition, secondPosition);
                secondToThird = Vector3.Distance(newThirdPosition, secondPosition);

                distanceToCenter = Math.Max(firstToSecond, secondToThird);

                interpolationTime += Time.deltaTime; yield return null;
            }

            GameObject molecule = matchedAtoms[1].Active.transform.Find("GameObject/" + moleculeName).gameObject;
            

            GameObject effect = GameObject.Find("BondEffect");
            effect.transform.position = molecule.transform.position;
            effect.GetComponent<ParticleSystem>().Play();

            GameObject gameObject_1 = matchedAtoms[0].Active.transform.Find("GameObject").gameObject;

            for (int i = 0; i < gameObject_1.transform.childCount; i++)
                gameObject_1.transform.GetChild(0).gameObject.SetActive(false);

            //matchedAtoms[0].Active.transform.Find("GameObject").gameObject.SetActive(false);
            //matchedAtoms[0].Active.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

            GameObject gameObject_2 = matchedAtoms[2].Active.transform.Find("GameObject").gameObject;

            for (int i = 0; i < gameObject_2.transform.childCount; i++)
                gameObject_2.transform.GetChild(0).gameObject.SetActive(false);

            //matchedAtoms[2].Active.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            //matchedAtoms[2].Active.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

            GameObject gameObject_3 = matchedAtoms[1].Active.transform.Find("GameObject").gameObject;

            for (int i = 0; i < gameObject_3.transform.childCount; i++)
                gameObject_3.transform.GetChild(0).gameObject.SetActive(false);

            molecule.SetActive(true);
            //GameObject.Find("Label").gameObject.SetActive(true);
            matchedAtoms[1].Active.transform.Find("GameObject/" + "Label" + moleculeName).gameObject.SetActive(true);

            //matchedAtoms[1].Active.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            //matchedAtoms[1].Active.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);

            this.GetComponent<DistanceMonitor>().ResetTheAnimation();
        }
    }
}
