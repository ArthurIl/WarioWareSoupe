using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            private SpriteRenderer sprite;

            // Start is called before the first frame update
            void Start()
            {
                sprite = GetComponent<SpriteRenderer>();
            }

            // Update is called once per frame
            void Update()
            {
                //if the fly is under the swatter press a button and slam
                if (Input.GetButtonDown("A_Button") && canSmash)
                {

                    StartCoroutine(SwatterAnimation());
                    if (flyIsUnder)
                    {
                        flyIsDead = true; //success condition
                        flyObject.SetActive(false);
                    }
                    else
                    {
                        sprite.sortingOrder = 0; //the fly sprite is above the swatter 
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

            IEnumerator SwatterAnimation()
            {
                transform.DOScale(new Vector3(2, 2, 2), 0.1f);

                if (flyIsUnder)
                {
                    yield return new WaitForSeconds(0.1f);
                    transform.DOScale(new Vector3(2.4f, 2.4f, 2.4f), 0.1f);
                }
                else yield return null;
            }
        }
    }
}

