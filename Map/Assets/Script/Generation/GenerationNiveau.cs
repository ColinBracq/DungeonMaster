using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationNiveau : MonoBehaviour
{
    float hauteur = 4f; 
    float largeur = 4f;
    Vector3 TailleCarte = new Vector3(4, 4);
    Salle[,] salles;
    private List<Vector2> PositionOccupee = new List<Vector2>();
    public int NbreDeSalles = 20;
   
}
