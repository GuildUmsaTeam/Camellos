using UnityEngine;
using System.Collections;

public class ZOrder : MonoBehaviour {
    private ZOrderController _controller;

    void Start () {
        _controller = GameObject.FindGameObjectWithTag(Tags.GameController)
            .GetComponent<ZOrderController>();
        _controller.Components.Add(this.gameObject);
    }
    
    void Update () {
    }
}
