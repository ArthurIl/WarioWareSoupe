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

            public override void Start()
            {
                base.Start(); //Do not erase this line!

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
                if (Input.GetButtonDown("X_Button"))
                {
                    Debug.Log("yes");
                    StartCoroutine(LeftShovelAnim());
                }
            }

            IEnumerator LeftShovelAnim()
            {
                LeftShovel.DOMove(new Vector3(-7.9f, -1.08f, 0f), 0.1f);
                yield return new WaitForSeconds(0.1f);

            }
        }
    }
}