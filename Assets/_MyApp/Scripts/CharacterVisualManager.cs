using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CharacterVisualManager : MonoBehaviour
{
    /*
     Controls player visuals in scene and save them
    */
    [Tooltip("Character possible sprite variants")]
    [SerializeField]
    private BodyParts[] bodyParts;

    void Start()
    {
        foreach (var part in bodyParts)
        {
            int partIndex = PlayerPrefs.GetInt(GetBodyPartName(part), 0);
            part.imageRenderer.sprite = part.possibleSprites[partIndex];
        }
    }

    //Get name from Sprite Renderer removing special characters
    private string GetBodyPartName(BodyParts bodyPart)
    {
        string newname = bodyPart.imageRenderer.name;
        newname = Regex.Replace(newname, @"[^a-z]", "", RegexOptions.IgnoreCase);
        return newname;
    }

    //Change SpriteRenderer by index to next sprite
    public void ChangeSpritePartNextSprite(int index)
    {
        var partName = GetBodyPartName(bodyParts[index]);
        int currentIndex = PlayerPrefs.GetInt(partName, 0); 
        currentIndex = (currentIndex + 1) % bodyParts[index].possibleSprites.Length;
        ChangeSpritePartToIndex(bodyParts[index], currentIndex);
    }

    public void ChangeSpritePartToIndex(BodyParts part, int spriteIndex)
    {
        var partName = GetBodyPartName(part);
        PlayerPrefs.SetInt(partName, spriteIndex);
        part.imageRenderer.sprite = part.possibleSprites[spriteIndex];
    }

    public void ChangeAllToRandom()
    {
        foreach (var part in bodyParts)
        {
            var randomIndex = Random.Range(0, part.possibleSprites.Length);
            ChangeSpritePartToIndex(part, randomIndex);
        }
    }
}


[System.Serializable]
public class BodyParts
{
    [Tooltip("Sprite renderer to be changed")]
    public SpriteRenderer imageRenderer;
    public Sprite[] possibleSprites;
}