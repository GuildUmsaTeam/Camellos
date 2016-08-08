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
            Vector3 lerp = Vector3.Lerp(_cachedPosition,
                                        _abducter.gameObject.transform.position, t);
            Set2DPos(lerp.x, lerp.y);
        } else {
            _currentState = IDLE;
            Destroy(this);
        }
    }

    private void _UpdateDropping () {
        if (_timeOnState < AbductionTime) {
            float t = Mathf.Pow(_timeOnState/AbductionTime, 2);
            Vector3 lerp = Vector3.Lerp(_cachedPosition, _controller.TargetSpot, t);
            Set2DPos(lerp.x, lerp.y);
        } else {
            GetComponent<RandomMovement>().enabled = true;
            _currentState = IDLE;
        }
    }

    public void GetAbducted () {
        GetComponent<RandomMovement>().TargetSpot = transform.position;
        GetComponent<RandomMovement>().enabled = false;
        _cachedPosition = transform.position;
        _timeOnState = 0;
        _currentState = BEING_ABDUCTED;
        GetComponent<CamelAnimator>().TheAnimator.SetTrigger("Abducted");
    }

    public void GetDropped () {
        GetComponent<RandomMovement>().enabled = false;
        _cachedPosition = transform.position;
        _timeOnState = 0;
        _currentState = BEING_DROPPED;
    }

    public bool IsFlying () {
        return _currentState == BEING_DROPPED || _currentState == BEING_ABDUCTED;
    }

    public Vector3 GetZOrderPosition () {
        if (IsFlying()) {
            return _controller.TargetSpot;
        }
        return transform.position;
    }

    public void Set2DPos (float x, float y) {
        float oldZ = transform.position.z;
        transform.position = new Vector3(x,y, oldZ);
    }
}


