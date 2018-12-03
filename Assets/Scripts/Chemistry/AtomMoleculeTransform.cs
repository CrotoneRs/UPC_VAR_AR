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
        public void Proceed(List<DistanceMonitor.ActiveWithEnum> matchedAtoms)
        {
            this.StartCoroutine(TranslateAtomsToCenter(matchedAtoms));
        }

        private IEnumerator TranslateAtomsToCenter(List<DistanceMonitor.ActiveWithEnum> matchedAtoms)
        {
            Vector3 firstPosition = matchedAtoms[0].Active.transform.GetChild(0).position;
            Vector3 secondPosition = matchedAtoms[1].Active.transform.GetChild(0).position;
            Vector3 thirdPosition = matchedAtoms[2].Active.transform.GetChild(0).position;

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

                matchedAtoms[0].Active.transform.GetChild(0).position = newFirstPosition;
                matchedAtoms[2].Active.transform.GetChild(0).position = newThirdPosition;

                firstToSecond = Vector3.Distance(newFirstPosition, secondPosition);
                secondToThird = Vector3.Distance(newThirdPosition, secondPosition);

                distanceToCenter = Math.Max(firstToSecond, secondToThird);

                interpolationTime += Time.deltaTime; yield return null;
            }

            matchedAtoms[0].Active.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            matchedAtoms[0].Active.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

            matchedAtoms[2].Active.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            matchedAtoms[2].Active.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

            matchedAtoms[1].Active.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            matchedAtoms[1].Active.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);

            this.GetComponent<DistanceMonitor>().ResetTheAnimation();
        }
    }
}
