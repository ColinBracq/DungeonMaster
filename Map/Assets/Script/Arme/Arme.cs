using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvelle arme", menuName = "Arme")]
public class Arme : ScriptableObject
{
    public string nom;
    public Sprite imageArme;
    public Color couleurArme;

    public string type;
    

    public int dommage;
    public float cadence;
    public float portee;

}
