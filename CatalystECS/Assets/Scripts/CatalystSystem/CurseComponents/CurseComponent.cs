using System;
using CatalystSystem.Interfaces;
using Interfaces;
using UnityEngine;

/*	
*	Dennis Foose
* 	Crimson Council Studentbedrift
*	Copyright © 2017 All Rights Reserved
*	
*	<summary>  
*   	Description Here
*   </summary>
*/

namespace CatalystSystem.CurseComponents
{
    [CreateAssetMenu(fileName = "Curse Component", menuName = "Catalyst System/Curses/Basic")]
    public class CurseComponent : ScriptableObject, ICurseComponent, IWeighted, IValued
    {
        [SerializeField] private int _weight;
        [SerializeField] private int _value;

        public void Curse()
        {
            Debug.Log("Curse");
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}