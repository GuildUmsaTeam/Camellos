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
    public SpriteRenderer Renderer;

    private Abducted _abducted;

    void Start () {
        _abducted = GetComponent<Abducted>();
    }
    
    void Update () {
	
    }

    public bool IsFlying () {
        return _abducted.IsFlying();
    }
}
