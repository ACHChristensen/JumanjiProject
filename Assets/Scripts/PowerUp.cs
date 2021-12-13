using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : Object
{

    public abstract void Ability(GameObject player);

    public abstract void AfterAbility();

}
