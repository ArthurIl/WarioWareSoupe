﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioSoupe
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

            bool memorizationOver;

            bool playerChosedMeat;
            bool playerChosedBread;
            bool playerChosedVegetable;

            bool loose;
            bool win;
            bool launchPlaceRandomIngredient;

            public float timeBetweenSteps;

            bool canChoose;

            GameObject[] ingredientChosingPhase;

            void Start()
            {
                canChoose = true;
                loose = false;
                ingredientChosingPhase = new GameObject[4];
                launchPlaceRandomIngredient = true;
                memorizationOver = false;
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
                if (memorizationOver == false)
                {
                    StartCoroutine("MemorizationPhase");
                    memorizationOver = true;
                }
                if (playerChosedBread == false && memorizationOver != false)
                {
                    PlayerChose(chefBreadInt, ref playerChosedBread);
                }
                if (playerChosedMeat == false && playerChosedBread == true)
                {
                    RandomPlaceIngredient(meat);
                    PlayerChose(chefMeatInt, ref playerChosedMeat);
                }
                if (playerChosedVegetable == false && playerChosedMeat == true)
                {
                    RandomPlaceIngredient(vegetable);
                    PlayerChose(chefVegetableInt, ref playerChosedVegetable);
                }

            }
            IEnumerator MemorizationPhase()
            {
                yield return new WaitForSeconds(memorizationTime);
                Destroy(chefBread);
                Destroy(chefMeat);
                Destroy(chefVegetable);
                RandomPlaceIngredient(bread);
            }

            void RandomPlaceIngredient(GameObject[] ingredient)
            {
                if(launchPlaceRandomIngredient == true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        bool isIngredientAlreadyIn;
                        int randomIngredient;
                        if (i == 0)
                        {
                            randomIngredient = Random.Range(0, 4);
                            ingredientChosingPhase[i] = Instantiate(ingredient[randomIngredient], ingredientScreenPositions[i], Quaternion.identity);
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

                            ingredientChosingPhase[i] =  Instantiate(ingredient[randomIngredient], ingredientScreenPositions[i], Quaternion.identity);
                            ingredientChosedPerPos.Add(randomIngredient);
                            
                        }
                    }
                }
                launchPlaceRandomIngredient = false;
                
            }

            void PlayerChose(int checkedChefIngredient, ref bool checkedPlayerIngredient)
            {

                if (canChoose == true)
                {
                    if (Input.GetButtonDown("A_Button"))
                    {
                        StartCoroutine(StartChooseCD());
                        if (ingredientChosedPerPos[0] == checkedChefIngredient)
                        {
                            checkedPlayerIngredient = true;
                            ingredientChosedPerPos.Clear();
                            DestroyChosedIngredients();
                            launchPlaceRandomIngredient = true;
                        }
                        else
                        {
                            loose = true;
                            Debug.Log("loose A" + loose);
                        }
                        ingredientChosedPerPos.Clear();
                    }
                    if (Input.GetButtonDown("B_Button"))
                    {
                        StartCoroutine(StartChooseCD());
                        if (ingredientChosedPerPos[1] == checkedChefIngredient)
                        {
                            checkedPlayerIngredient = true;
                            ingredientChosedPerPos.Clear();
                            DestroyChosedIngredients();
                            launchPlaceRandomIngredient = true;
                        }
                        else
                        {
                            loose = true;
                            Debug.Log("loose B" + loose);
                        }

                    }
                    if (Input.GetButtonDown("Y_Button"))
                    {
                        StartCoroutine(StartChooseCD());
                        if (ingredientChosedPerPos[2] == checkedChefIngredient)
                        {
                            checkedPlayerIngredient = true;
                            ingredientChosedPerPos.Clear();
                            DestroyChosedIngredients();
                            launchPlaceRandomIngredient = true;
                        }
                        else
                        {
                            loose = true;
                            Debug.Log("loose Y" + loose);
                        }

                    }
                    if (Input.GetButtonDown("X_Button"))
                    {
                        StartCoroutine(StartChooseCD());
                        if (ingredientChosedPerPos[3] == checkedChefIngredient)
                        {
                            checkedPlayerIngredient = true;
                            ingredientChosedPerPos.Clear();
                            DestroyChosedIngredients();
                            launchPlaceRandomIngredient = true;
                        }
                        else
                        {
                            loose = true;
                            Debug.Log("loose X" + loose);
                        }

                    }
                }
            }
            void DestroyChosedIngredients()
            {
                foreach (GameObject ingredients in ingredientChosingPhase)
                {
                    Destroy(ingredients);
                }
            }

            IEnumerator StartChooseCD()
            {
                canChoose = false;
                yield return new WaitForSeconds(timeBetweenSteps);
                canChoose = true;
            }
        }

    }
}


