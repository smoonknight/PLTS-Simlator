using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Security Camera", menuName = "Security Camera")]
public class SecurityCameraData : ScriptableObject
{
    public new string name;
    public Vector3 location;
    public Vector3 rotation;
}
