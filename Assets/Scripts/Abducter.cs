using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Abducter : MonoBehaviour {
    private List<GameObject> _camels;

    public List<GameObject> Camels {
        get {
            if (_camels == null) {
                _camels = new List<GameObject>();
            }

            return _camels;
        }
    }

    void Update () {
	if (Input.GetKeyDown(KeyCode.A)) {
            Abduct(Random.Range(1, Camels.Count));
        }
    }

    public void Abduct (int quantity) {
        int[] toAbduct = new int[quantity];

        for (int i=0; i<quantity; i++) {
            toAbduct[i] = Random.Range(0, Camels.Count - 1 - i);
            // Camels[i].transform.localScale = new Vector3(1,-1,1);
            Camels[i].GetComponent<Abducted>().GetAbducted();
        }

    }
}
