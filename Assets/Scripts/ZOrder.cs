using UnityEngine;
using System.Collections;

public class ZOrder : MonoBehaviour {
    private ZOrderController _controller;
    private Abducted _abducted;

    void Start () {
        _controller = GameObject.FindGameObjectWithTag(Tags.GameController)
            .GetComponent<ZOrderController>();
        _controller.Components.Add(this.gameObject);
        _abducted = GetComponent<Abducted>();
    }
    
    void Update () {
    }

    public Vector3 GetZOrderPosition () {
        if (_abducted == null) {
            return transform.position;
        } else {
            return _abducted.GetZOrderPosition();
        }
    }
}
