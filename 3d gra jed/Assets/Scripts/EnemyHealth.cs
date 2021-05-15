using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float HealthPoints = 100f;
    public void TakeDamage()
    {
        HealthPoints -= damage;
        if(HealthPoints <=0)
        {
            Destroy(gameObject);
        }
    }
}
