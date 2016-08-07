using UnityEngine;
using System.Collections;

public class Abducted : MonoBehaviour {
    private const int IDLE = 0;
    private const int BEING_ABDUCTED = 1;
    private const int BEING_DROPPED = 2;

    public float AbductionTime;

    private int _currentState = 0;
    private Abducter _abducter;
    private float _timeOnState = 0;
    private Vector3 _cachedPosition;
    private CamelController _controller;

    void Start () {
        _abducter = GameObject.FindGameObjectWithTag(Tags.Abducter)
            .GetComponent<Abducter>();
        _abducter.Camels.Add(this.gameObject);
        _controller = GetComponent<CamelController>();
    }
    
    void Update () {
        _timeOnState += Time.deltaTime;
        switch (_currentState) {
            case BEING_DROPPED:
                _UpdateDropping();
                break;
            case BEING_ABDUCTED:
                _UpdateAbduction();
                break;
        }
    }

    private void _UpdateAbduction () {
        if (_timeOnState < AbductionTime) {
            float t = Mathf.Pow(_timeOnState/AbductionTime, 2);
            transform.position = Vector3.Lerp(_cachedPosition, _abducter.gameObject.transform.position, t);
        } else {
            Destroy(this);
        }
    }

    private void _UpdateDropping () {
        if (_timeOnState < AbductionTime) {
            float t = Mathf.Pow(_timeOnState/AbductionTime, 2);
            transform.position = Vector3.Lerp(_cachedPosition, _controller.TargetSpot, t);
        } else {
            GetComponent<RandomMovement>().enabled = true;
        }
    }

    public void GetAbducted () {
        GetComponent<RandomMovement>().enabled = false;
        _cachedPosition = transform.position;
        _timeOnState = 0;
        _currentState = BEING_ABDUCTED;
    }

    public void GetDropped () {
        GetComponent<RandomMovement>().enabled = false;
        _cachedPosition = transform.position;
        _timeOnState = 0;
        _currentState = BEING_DROPPED;
    }
}


