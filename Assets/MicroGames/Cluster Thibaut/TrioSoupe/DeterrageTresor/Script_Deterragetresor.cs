using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Soupe
{
    namespace DeterrageTresor
    {
        public class Script_Deterragetresor : TimedBehaviour
        {
            public Transform LeftShovel;
            public Transform TopShovel;
            public Transform RightShovel;
            public Transform BottomShovel;

            public Transform Chest;

            public int difficulty;

            string[] inputCurrent;
            int inputToPush;

            int currentInputNumber;
            public int inputNumberToReach;


            /// <summary>
            /// Alex LEPINE
            /// </summary>
            /// 
            public override void Start()
            {
                base.Start(); //Do not erase this line!

                inputToPush = 0;
                SetDifficulty();

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {

            }

            private void Update()
            {
                if (Input.GetButtonDown("A_Button") && inputCurrent[inputToPush] == "A")
                {
                    StartCoroutine(BottomShovelAnim());
                    NextInput();
                }
                if (Input.GetButtonDown("B_Button") && inputCurrent[inputToPush] == "B")
                {
                    StartCoroutine(RightShovelAnim());
                    NextInput();
                }
                if (Input.GetButtonDown("X_Button") && inputCurrent[inputToPush] == "X")
                {
                    StartCoroutine(LeftShovelAnim());
                    NextInput();
                }
                if (Input.GetButtonDown("Y_Button") && inputCurrent[inputToPush] == "Y")
                {
                    StartCoroutine(TopShovelAnim());
                    NextInput();
                }

            }
            void NextInput()
            {
                if (inputToPush == inputCurrent.Length - 1)
                {
                    inputToPush = 0;
                }
                else
                {
                    inputToPush += 1;
                }

                Chest.DOMoveY((Chest.position.y + 0.1f), 0.1f);

                currentInputNumber += 1;

                if (currentInputNumber == inputNumberToReach)
                {
                    //la game est gagnée
                }
            }

            void SetDifficulty()
            {
                if (difficulty == 1)
                {
                    TopShovel.gameObject.SetActive(false);
                    LeftShovel.gameObject.SetActive(false);

                    inputCurrent = new string[2] { "B", "A" };
                }
                else if (difficulty == 2)
                {
                    TopShovel.gameObject.SetActive(false);

                    inputCurrent = new string[3] { "B", "A", "X" };
                }
                else if (difficulty == 3)
                {
                    inputCurrent = new string[4] { "B", "A", "X", "Y"};
                }
            }


            IEnumerator BottomShovelAnim()
            {
                BottomShovel.DOMoveY(-5f, 0.2f);
                BottomShovel.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.1f);
                yield return new WaitForSeconds(0.2f);
                BottomShovel.DOMoveY(-6.98f, 0.2f);
                BottomShovel.DOScale(new Vector3(1, 1, 1), 0.1f);
            }

            IEnumerator TopShovelAnim()
            {
                
                TopShovel.DOMoveY(3f, 0.2f);
                TopShovel.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 0.1f);
                yield return new WaitForSeconds(0.2f);
                TopShovel.DOMoveY(6.56f, 0.2f);
                TopShovel.DOScale(new Vector3(1, 1, 1), 0.1f);
            }

            IEnumerator RightShovelAnim()
            {
                RightShovel.DORotate(new Vector3(0f, 0f, 200f), 0.1f);
                RightShovel.DOMoveX(8f, 0.2f);
                RightShovel.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.1f);
                yield return new WaitForSeconds(0.1f);
                RightShovel.DORotate(new Vector3(0f, 0f, 170f), 0.1f);
                yield return new WaitForSeconds(0.1f);
                RightShovel.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
                RightShovel.DORotate(new Vector3(0, 0, 180), 0.1f);
                RightShovel.DOMoveX(10.22f, 0.2f);
            }
            IEnumerator LeftShovelAnim()
            {
                LeftShovel.DORotate(new Vector3(0f, 0f, -20f), 0.1f);
                LeftShovel.DOMoveX(-8f, 0.2f);
                LeftShovel.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.1f);
                yield return new WaitForSeconds(0.1f);
                LeftShovel.DORotate(new Vector3(0f, 0f, 10f), 0.1f);
                yield return new WaitForSeconds(0.1f);
                LeftShovel.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
                LeftShovel.DORotate(new Vector3(0, 0, 0), 0.1f);
                LeftShovel.DOMoveX(-10.24f, 0.2f);
            }
        }
    }
}