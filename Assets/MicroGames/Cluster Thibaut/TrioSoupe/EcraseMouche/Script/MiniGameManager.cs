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
        public class MiniGameManager : TimedBehaviour
        {
            [SerializeField]
            private List<GameObject> jam = new List<GameObject>();
            [SerializeField]
            private List<GameObject> spawnPoint = new List<GameObject>();
            [SerializeField]
            private GameObject jamStain;
            [SerializeField]
            private GameObject flyBug;
            [SerializeField]
            private GameObject flyHierarchy;
            [SerializeField]
            private GameObject swatter;
            [SerializeField]
            private Transform posFly;

            private int tempIndJam;
            private int numberOfJam;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                numberOfJam = 4;
                //place jam
                PlaceJam();
                //place fly on the left jam
                PlaceFly();
                //place swatter on a jam but not the one with the fly
                PlaceSwatter();

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

            public void PlaceJam()
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
                for(int i=0; i<numberOfJam; i++)
                {
                    tempIndJam = Random.Range(0, jamBis.Count);
                    GameObject newStain = Instantiate(jamStain, jamBis[tempIndJam].transform);
                    jamBis.Remove(jamBis[tempIndJam]);
                    jam.Add(newStain); //add to the jam list the stain
                }
            }

            public void PlaceFly()
            {
                foreach(GameObject jamPoint in spawnPoint)
                {
                    if (jamPoint.transform.childCount > 0) //attention si les points on d'autres enfants update le 0
                    {
                        GameObject temp = Instantiate(flyBug, jamPoint.transform);
                        posFly = jamPoint.transform;
                        temp.transform.parent = flyHierarchy.transform;
                        break;
                    }
                }
            }

            public void PlaceSwatter()
            {
                int temp = Random.Range(0, numberOfJam);

                if (jam[temp].transform.position == posFly.position)
                {
                    Debug.Log("let's go");
                    PlaceSwatter(); //NICO DEBUG
                }
                else
                {
                    Instantiate(swatter, jam[temp].transform);
                }
            }
        }
    }
}