using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public float sante = 10;
    public GameObject deathEffect;

    private void Update()
    {
        if (sante <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            effect.transform.localScale = transform.localScale;
            Destroy(effect, 10f);
            Destroy(gameObject);
        }
    }

    public void PrendreDegats(float degats)
    {
        sante -= degats;
        Debug.Log("degats pris");
    }
}
