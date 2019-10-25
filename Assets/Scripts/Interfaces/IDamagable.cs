using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IKillable
{
    void Kill();
}

public interface IAnimatable
{
    void PlayAnimation();
}

public interface IDamageable<T>
{
    void Damage(T damageTaken);
}

//https://learn.unity.com/tutorial/interfaces#5c893ef9edbc2a141035529f
