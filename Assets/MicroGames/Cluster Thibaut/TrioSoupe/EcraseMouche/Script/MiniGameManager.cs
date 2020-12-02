using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sauce
{
    namespace EcraseMouche
    {
        /// <summary>
        /// Arthur Galland
        /// </summary>
        public class MiniGameManager : TimedBehaviour
        {
            [SerializeField]
            private List<GameObject> jam = new List<GameObject>();
            [SerializeField]
            private List<GameObject> spawnPoint = new List<GameObject>();
            [SerializeField]
            private GameObject jamStain;

            private int tempIndJam;
           // private int numberOfJam;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                //place jam
                placeJam();
                //place fly on the left jam
                placeFly();
                //place swatter on a jam but not the one with the fly

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

            public void placeJam()
            {
                //foreach (GameObject spawnpoint in spawnPoint)
                //{
                //    int randomNumber = Random.Range(0, 2);

                //    if (randomNumber == 0 && jam.Count <4)
                //    {
                //        GameObject newStain = Instantiate(jamStain, spawnpoint.transform);
                //        jam.Add(newStain);

                //    }
                //}

                List <GameObject> jamBis = new List<GameObject>(spawnPoint);
                for(int i=0; i<4; i++)
                {
                    tempIndJam = Random.Range(0, jamBis.Count);
                    Instantiate(jamStain, jamBis[tempIndJam].transform);
                    jamBis.Remove(jamBis[tempIndJam]);
                }
            }

            public void placeFly()
            {

            }
        }
    }
}