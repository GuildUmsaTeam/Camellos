using UnityEngine;
using System.Collections;

public class CamelAnimator : MonoBehaviour {
    public GameObject Model;
    public Animator TheAnimator {
        get {
            return _animator;
        }
    }

    private Animator _animator;
    private CamelController _controller;
    private float _randomCounter;

    void Start () {
        _controller = GetComponent<CamelController>();
        _animator = Model.GetComponent<Animator>();
    }

    void Update () {
        _animator.SetBool("IsFlying", _controller.IsFlying());
        _animator.SetBool("IsWalking", _controller.IsWalking);
        if (_controller.IsWalking) {
            _randomCounter = 0;
        } else {
            if (_randomCounter == 0) {
                _animator.SetTrigger("LookBack");
            }
            _randomCounter++;
        }

        int x = 1;
        if (_controller.LookingLeft) {
            x = -1;
        }
        transform.localScale = new Vector3(x,1,1);
    }
}
