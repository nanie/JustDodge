using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCustomizationManager : MonoBehaviour
{
    public InputField inputName;
    public CharacterVisualManager character;

    void Start()
    {
        character = FindObjectOfType<CharacterVisualManager>();
        //Get last name saved and set the Input Field
        inputName.text = PlayerPrefs.GetString("playerName", "Player 1");
    }

    //Save player name on player prefs
    public void SaveName()
    {
        PlayerPrefs.SetString("playerName", inputName.text);
    }

    public void PlayGame()
    {
        DataHolder.Instance.currentPlayerName = inputName.text == "" ? "Player 1" : inputName.text;
        SceneController.Instance.GoToMainGame();
    }

    public void ChangeBodyPart(int index)
    {
        character.ChangeSpritePartNextSprite(index);
    }

    public void ChangeAllToRandom()
    {
        character.ChangeAllToRandom();
    }
}
