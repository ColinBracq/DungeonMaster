using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvelle arme", menuName = "Arme")]
public class Arme : ScriptableObject
{
    public string nom;
    public Sprite imageArme;
    public Material materialArme;

    public string type;

    public GameObject projectile;
    public float vitesseProj;
    public float porteeExplo;

    public float dommage;
    public float cadence;
    public float portee;

}
