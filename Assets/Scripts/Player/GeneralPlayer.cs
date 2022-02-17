using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

public class GeneralPlayer : MonoBehaviour, IReactionToHit
{
    public GeneralPlayer()
    {
        HP = 100;
    }

    public int HP { get; set; }

    public void ReactToHit(RaycastHit hit, int damage)
    {
        HP -= damage;
        if (HP <= 0)
            Destroy(gameObject);
    }
}
