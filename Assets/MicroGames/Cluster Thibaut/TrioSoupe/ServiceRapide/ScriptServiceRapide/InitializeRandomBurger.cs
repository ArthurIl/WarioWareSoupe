using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioSauce
{
    namespace ServiceRapide
    {
        /// <summary>
        ///  Manon Ghignoni
        /// </summary>
        public class InitializeRandomBurger : MonoBehaviour
        {
            int chefMeatInt;
            int chefBreadInt;
            int chefVegetableInt;

            GameObject chefBread;
            GameObject chefMeat;
            GameObject chefVegetable;

            public GameObject[] meat;
            public GameObject[] bread;
            public GameObject[] vegetable;
            public Vector3[] ingredientScreenPositions;
            List<int> ingredientChosedPerPos;

            public Vector3 chefBreadPos;
            public Vector3 chefMeatPos;
            public Vector3 chefVegetablePos;

            public int memorizationTime;

            bool isMemorizationOver;

            bool playerChosedMeat;
            bool playerChosedBread;
            bool playerChosedVegetable;

            bool loose;
            bool win;
            void Start()
            {
                isMemorizationOver = false;
                ingredientChosedPerPos = new List<int>();
                chefMeatInt = Random.Range(0, 4);
                chefBreadInt = Random.Range(0, 4);
                chefVegetableInt = Random.Range(0, 4);
                chefBread = Instantiate(bread[chefBreadInt], chefBreadPos, Quaternion.identity);
                chefMeat = Instantiate(meat[chefMeatInt], chefMeatPos, Quaternion.identity);
                chefVegetable = Instantiate(vegetable[chefVegetableInt], chefVegetablePos, Quaternion.identity);
            }

            void Update()
            {
                if (isMemorizationOver == false)
                {
                    StartCoroutine("MemorizationOver");
                    isMemorizationOver = true;
                }
                if (playerChosedMeat == false && isMemorizationOver != false)
                {
                    PlayerChose(chefMeatInt, ref playerChosedMeat);
                }
                if(playerChosedBread == false && playerChosedMeat == true)
                {
                    RandomPlaceIngredient(bread);
                    PlayerChose(chefBreadInt, ref playerChosedBread);
                }
                if (playerChosedVegetable == false && playerChosedBread == true)
                {
                    RandomPlaceIngredient(vegetable);
                    PlayerChose(chefVegetableInt, ref playerChosedVegetable);
                }
            }
            IEnumerator MemorizationOver()
            {
                yield return new WaitForSeconds(memorizationTime);
                Destroy(chefBread);
                Destroy(chefMeat);
                Destroy(chefVegetable);
                RandomPlaceIngredient(meat);

            }

            void RandomPlaceIngredient(GameObject[] ingredient)
            {

                for (int i = 0; i < 4; i++)
                {
                    bool isIngredientAlreadyIn;
                    int randomIngredient;
                    if (i == 0)
                    {
                        randomIngredient = Random.Range(0, 4);
                        Instantiate(ingredient[randomIngredient], ingredientScreenPositions[i], Quaternion.identity);
                        ingredientChosedPerPos.Add(randomIngredient);
                    }
                    else
                    {
                        do
                        {
                            isIngredientAlreadyIn = false;
                            randomIngredient = Random.Range(0, 4);
                            foreach (int ingredientChosed in ingredientChosedPerPos)
                            {
                                if (randomIngredient == ingredientChosed)
                                {
                                    isIngredientAlreadyIn = true;
                                }
                            }

                        } while (isIngredientAlreadyIn == true);

                        Instantiate(ingredient[randomIngredient], ingredientScreenPositions[i], Quaternion.identity);
                        ingredientChosedPerPos.Add(randomIngredient);
                    }


                }
            }

            void PlayerChose(int checkedChefIngredient, ref bool checkedPlayerIngredient)
            {
                if (Input.GetButtonDown("A_Button"))
                {
                    if (ingredientChosedPerPos[0] == checkedChefIngredient)
                    {
                        checkedPlayerIngredient = true;
                        Debug.Log("playerChosedMeat " + playerChosedMeat);
                        ingredientChosedPerPos.Clear();
                    }
                    else
                    {
                        loose = true;
                        Debug.Log("loose " + loose);
                    }
                }
                if (Input.GetButtonDown("B_Button"))
                {
                    if (ingredientChosedPerPos[1] == checkedChefIngredient)
                    {
                        checkedPlayerIngredient = true;
                        Debug.Log("playerChosedMeat " + playerChosedMeat);
                        ingredientChosedPerPos.Clear();
                    }
                    else
                    {
                        loose = true;
                        Debug.Log("loose " + loose);
                    }
                }
                if (Input.GetButtonDown("Y_Button"))
                {
                    if (ingredientChosedPerPos[2] == checkedChefIngredient)
                    {
                        checkedPlayerIngredient = true;
                        Debug.Log("playerChosedMeat " + playerChosedMeat);
                        ingredientChosedPerPos.Clear();
                    }
                    else
                    {
                        loose = true;
                        Debug.Log("loose " + loose);
                    }
                }
                if (Input.GetButtonDown("X_Button"))
                {
                    if (ingredientChosedPerPos[3] == checkedChefIngredient)
                    {
                        checkedPlayerIngredient = true;
                        Debug.Log("playerChosedMeat " + playerChosedMeat);
                        ingredientChosedPerPos.Clear();
                    }
                    else
                    {
                        loose = true;
                        Debug.Log("loose " + loose);
                    }
                }
                
            }
        }

    }
}


