using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour
{
    public Vector2 positionSalle;

    public string type;

    public bool porteNord, porteSud, porteOuest, porteEst;

    public Salle(Vector2 _positionSalle, string _type)
    {
        positionSalle = _positionSalle;
        type = _type;
    }

}
