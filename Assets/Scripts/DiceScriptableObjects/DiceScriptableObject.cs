using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(menuName = "Dices", order = 1)]
public class DiceScriptableObject : ScriptableObject
{

    public GameObject AbilityScript;
    public Sprite sprite;
    public string description;
    public string name;
    public string path;

}
