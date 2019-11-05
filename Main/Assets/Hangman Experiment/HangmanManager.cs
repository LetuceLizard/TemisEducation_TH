﻿using UnityEngine;
using UnityEngine.UI;

public class HangmanManager : MonoBehaviour
{
    public GameObject letter;
    private GameObject cen;
    public GameObject head;
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

    void initLetters()
    {
        int nbletters = lengthOfWordToGuess;
 
        for (int i = 0; i < nbletters; i++) 
        {
            Vector3 newPosition;
            newPosition = new Vector3 (cen.transform.position.x + (50+((i-nbletters/2.0f) *100)), cen.transform.position.y, cen.transform.position.z);
            GameObject l = (GameObject)Instantiate (letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.transform.SetParent(GameObject.Find ("Canvas").transform);
        }
    }

    void initGame()
    {
        wordToGuess = "Treasure";
        lengthOfWordToGuess = wordToGuess.Length;
        wordToGuess = wordToGuess.ToUpper ();
        lettersToGuess = new char [lengthOfWordToGuess];
        lettersGuessed = new bool [lengthOfWordToGuess];
        lettersToGuess = wordToGuess.ToCharArray ();
    }

    char T = System.Convert.ToChar("T");
    char R = System.Convert.ToChar("R");
    char E = System.Convert.ToChar("E");
    char A = System.Convert.ToChar("A");
    char S = System.Convert.ToChar("S");
    char U = System.Convert.ToChar("U");
    int n = 0;
    private GameObject obj;
    string objName;
    public void Input(int letterPressedAsInt)
    {
        PlayerPrefs.SetInt("buttonIndex", letterPressedAsInt);
        char letterPressed = System.Convert.ToChar(letterPressedAsInt);
        FindObjectOfType<ButtonHiding>().HideButton();

        if (letterPressedAsInt >= 97 && letterPressed <= 122)
        {
            if (letterPressedAsInt != 116 && letterPressedAsInt != 114 && letterPressedAsInt != 101 && letterPressedAsInt != 97 && letterPressedAsInt != 115 && letterPressedAsInt != 117)
            {
                objName = "Hangman" + n;
                obj = GameObject.Find(objName);
                obj.SetActive(false);
                n++;
            }
            
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