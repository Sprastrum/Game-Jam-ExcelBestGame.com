using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Character", menuName = "Bar Population/Unique Character")]
public class Character_Object : ScriptableObject
{
    public Sprite char_face;
    public string char_name;
    public string race;
    [TextArea(10, 30)]
    public string bio;
    public int day;
}
