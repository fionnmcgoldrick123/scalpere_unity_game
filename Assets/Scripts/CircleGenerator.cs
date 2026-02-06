using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
public class CircleGenerator : MonoBehaviour
{

    [SerializeField] private ICircle[] circles; 
    public ICircle getRandomCircle()
    {
        //TODO:  Method that handles luck weights

        int index = UnityEngine.Random.Range(0, circles.Length);
        ICircle circle = circles[index];
        return circle;
    }
}
