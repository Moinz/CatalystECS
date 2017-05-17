using System.Collections;
using System.Collections.Generic;
using CatalystSystem;
using CatalystSystem.EffectComponents;
using UnityEngine;
using CatalystSystem.MeleeComponents;
using CatalystSystem.PathComponents;
using CatalystSystem.UltimateComponents;
using CatalystSystem.Projectiles;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Seed Manager that handles all randomisation
*   </summary>
*/

public class SeedManager : MonoBehaviourSingleton<SeedManager>
{
    [SerializeField] private ComponentFactoryCatalyst _componentFactoryCatalyst;
    [SerializeField] private ComponentFactorySpellbook _componentFactorySpellbook;
    [SerializeField] private ComponentFactoryEffect _componentFactoryEffect;

    public MeleeComponent GetMeleeComponent(int points)
    {
        var r = Random.value;
        return _componentFactoryCatalyst.GetMeleeComponent(r, points);
    }

    public EffectComponent GetEffectComponent(int points)
    {
        var r = Random.value;
        return _componentFactoryEffect.GetEffectComponent(r, points);
    }

    public PathComponent GetPathComponent (int points)
    {
        // Returns a random spell component from a list of all spell components
        var r = Random.value;
        return _componentFactorySpellbook.GetPathComponent(r, points);
    }

    public UltimateComponent GetUltimateComponent (int points)
    {
        var r = Random.value;
        return _componentFactorySpellbook.GetUltimateComponent(r, points);
    }

    public Projectile GetProjectileComponent(int points)
    {
        var r = Random.value;
        return _componentFactorySpellbook.GetProjectile(r, points);
    }


    
}
