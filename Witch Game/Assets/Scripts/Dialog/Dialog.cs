using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "")]

public class Dialog : ScriptableObject
{
    public string characterName;
    [TextArea(3, 10)]
    public string[] sentences;
}
