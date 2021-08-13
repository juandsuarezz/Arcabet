using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;
    public int amountOf;

    public void Awake()
    {
        amountOf = PlayerPrefs.GetInt("ch1");
        amount = amountOf;
    }

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();

        movement.dashSpeed = dashVelocity;
    }
}
