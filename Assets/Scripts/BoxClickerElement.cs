using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BounceApplication.cs

// Base class for all elements in this application.
public class BoxClickerElement : MonoBehaviour
{
    // Gives access to the application and all instances.
    public BoxClickerApplication app { get { return GameObject.FindObjectOfType<BoxClickerApplication>(); } }
}
