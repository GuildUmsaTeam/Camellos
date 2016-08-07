using UnityEngine;
using System.Collections;

public class CamelController : MonoBehaviour {
    public bool IsWalking;
    public bool LookingLeft;
    public Vector2 TargetSpot {
        get {
            return GetComponent<RandomMovement>().TargetSpot;
        }
    }

    void Start () {
        
    }
    
    void Update () {
	
    }
}
