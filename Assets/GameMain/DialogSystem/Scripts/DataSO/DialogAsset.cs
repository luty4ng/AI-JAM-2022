using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogAsset", menuName = "GameMain/DialogAsset", order = 0)]
public class DialogAsset : ScriptableObject
{
    public string title;
    [TextArea(1000,5000)]public string contents;
}
