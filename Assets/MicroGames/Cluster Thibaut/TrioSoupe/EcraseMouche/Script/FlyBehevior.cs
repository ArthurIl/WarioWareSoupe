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
        public class FlyBehevior : TimedBehaviour
        {
            [SerializeField]
            private GameObject gameManager;
            [SerializeField]
            private List<GameObject> jamToGoPoints = new List<GameObject>();
            private int countOfJam;
            private bool flyCanMove;
            private float tempVelocity;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                flyCanMove = false;
                countOfJam = 0;

                jamToGoPoints = MiniGameManager.jam; //copie of the jam list for the movement

                for (int i = 0; i < jamToGoPoints.Count; i++) //remove from the list the jam under the fly
                {
                    if(jamToGoPoints[i].tag == "Enemy1")
                    {
                        jamToGoPoints.Remove(jamToGoPoints[i]);
                    }
                }

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
            }

            public void Update()
            {
                if (flyCanMove)
                {
                    transform.position = Vector3.MoveTowards(transform.position, jamToGoPoints[countOfJam].transform.position, tempVelocity*Time.deltaTime);
                }
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                //every 2 tic the fly move to another location during 1 tic 

                if (Tick == 2)
                {
                    tempVelocity = Vector3.Distance(transform.position, jamToGoPoints[countOfJam].transform.position) / (60 / bpm); //calcul the speed of the fly by dividing the distance between the fly and the next point by the time with the bpm
                    flyCanMove = true;
                }
                if (Tick == 3)
                {
                    countOfJam++;
                    flyCanMove = false;
                }

                if (Tick == 5)
                {
                    tempVelocity = Vector3.Distance(transform.position, jamToGoPoints[countOfJam].transform.position) / (60/bpm);
                    flyCanMove = true;
                }
                if (Tick == 6)
                {
                    countOfJam++;
                    flyCanMove = false;
                }

                //maybe I can create a function with the tick and make something much more efficient
            }
        }
    }
}