using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Soupe
{
    namespace EcraseMouche
    {
        public class FlyBehevior : TimedBehaviour
        {
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
                //X tic the fly move to another location during 1 tic 
            }
        }
    }
}