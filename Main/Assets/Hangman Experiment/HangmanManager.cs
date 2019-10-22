﻿using UnityEngine;
using UnityEngine.UI;

public class HangmanManager : MonoBehaviour
{
    public GameObject letter;
    public GameObject cen;
    private string wordToGuess = "";
    private int lengthOfWordToGuess;
    char [] lettersToGuess;
    bool [] lettersGuessed;
    
    void Start()
    {
        cen = GameObject.Find ("centerOfScreen");
        initGame ();
        initLetters ();
    }

    void Update()
    {
        checkKeyboard ();
    }

    void initLetters()
    {
        int nbletters = lengthOfWordToGuess;
 
        for (int i = 0; i < nbletters; i++) 
        {
            Vector3 newPosition;
            newPosition = new Vector3 (cen.transform.position.x + ((i-nbletters/2.0f) *100), cen.transform.position.y, cen.transform.position.z);
            GameObject l = (GameObject)Instantiate (letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.transform.SetParent(GameObject.Find ("Canvas").transform);
        }
    }

    void initGame()
    {
        wordToGuess = "Elephant";
        lengthOfWordToGuess = wordToGuess.Length;
        wordToGuess = wordToGuess.ToUpper ();
        lettersToGuess = new char[lengthOfWordToGuess];
        lettersGuessed = new bool [lengthOfWordToGuess];
        lettersToGuess = wordToGuess.ToCharArray ();
    }

    void checkKeyboard()
    {
        if (Input.anyKeyDown)
        {
            char letterPressed = Input.inputString.ToCharArray () [0];
            int letterPressedAsInt = System.Convert.ToInt32 (letterPressed);
            if (letterPressedAsInt >= 97 && letterPressed <= 122)
            {
                for (int i=0; i < lengthOfWordToGuess; i++)
                {
                    if (!lettersGuessed [i])
                    {
                        letterPressed = System.Char.ToUpper (letterPressed);
                        if (lettersToGuess [i] == letterPressed)
                        {
                            lettersGuessed [i] = true;
                            GameObject.Find("letter"+(i+1)).GetComponent<Text>().text = letterPressed.ToString();
                        }
                    }
                }
            }
        }
    }
}