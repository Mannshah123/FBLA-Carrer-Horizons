using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Symptons", menuName = "ScriptableObjects/Symptons")]
public class Symptons : ScriptableObject
{
    public bool fever;
    public bool dizziness;
    public bool MusclePain;
    public bool cough;

    public string description;

    public Sprite icon;
}
