using UnityEngine;
using System.Collections;

public class Abducted : MonoBehaviour {
    private const int IDLE = 0;
    private const int BEING_ABDUCTED = 1;

    public float AbductionTime;

    private int _currentState = 0;
    private Abducter _abducter;
    private float _timeOnState = 0;
    private Vector3 _cachedPosition;

    void Start () {
        _abducter = GameObject.FindGameObjectWithTag(Tags.Abducter)
            .GetComponent<Abducter>();
        _abducter.Camels.Add(this.gameObject);
    }
    
    void Update () {
        _timeOnState += Time.deltaTime;
        if (_currentState == BEING_ABDUCTED) {
            _UpdateAbduction();
        }
    }

    private void _UpdateAbduction () {
        if (_timeOnState < AbductionTime) {
            float t = Mathf.Pow(_timeOnState/AbductionTime, 2);
            transform.position = Vector3.Lerp(_cachedPosition, _abducter.gameObject.transform.position, t);
        }
    }

    public void GetAbducted () {
        GetComponent<RandomMovement>().enabled = false;
        _cachedPosition = transform.position;
        _timeOnState = 0;
        _currentState = BEING_ABDUCTED;
    }
}


