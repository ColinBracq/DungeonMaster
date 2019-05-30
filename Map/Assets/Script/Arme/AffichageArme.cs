using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageArme : MonoBehaviour
{
    public Arme arme;

    public Image visuel;

    private void Start()
    {
        visuel.sprite = arme.imageArme;
        visuel.material.color = arme.couleurArme;
    }
}
