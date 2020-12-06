using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    namespace Soupe
{
    namespace EcraseMouche
    {
        /// <summary>
        /// Arthur Galland
        /// </summary>
        public class SwatterBehevior : MonoBehaviour
        {
            public static bool flyIsDead = false;
            private bool flyIsUnder = false;
            private bool canSmash = true;
            private GameObject flyObject;

            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {
                //if the fly is under the swatter press a button and slam
                if (Input.GetButtonDown("A_Button") && canSmash)
                {
                    if (flyIsUnder)
                    {
                        flyIsDead = true; //success condition
                        flyObject.SetActive(false);
                        Debug.Log("dead");
                    }
                    else
                    {
                        canSmash = false; //if the player don't time the smash right he can't smash again
                    }

                }
            }

            void OnTriggerEnter2D(Collider2D col) //the fly is under the swatter
            {
                flyIsUnder = true;
                flyObject = col.gameObject;
            }

            void OnTriggerExit2D(Collider2D collision) //the fly is no longer under the swatter
            {
                flyIsUnder = false;
            }
        }
    }
}

