using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public int sante = 10;

    private void Update()
    {
        if(sante <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PrendreDegats(int degats)
    {
        sante -= degats;
        Debug.Log("degats pris");
    }
}
