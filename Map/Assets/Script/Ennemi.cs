using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float sante = 10;
    public Animator enemyAnim;
    public Rigidbody2D rb;
    private string Mort = "Mort";
    private string Degats = "Degat";
    private void Update()
    {
        if(sante <= 0)
        {
            enemyAnim.SetTrigger(Mort);
            Destroy(gameObject,0.1f);
        }
    }

    public void PrendreDegats(float degats)
    {
        sante -= degats;
        enemyAnim.SetTrigger(Degats);
        Debug.Log("degats pris");
    }

}
