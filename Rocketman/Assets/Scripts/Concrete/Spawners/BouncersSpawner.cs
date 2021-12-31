using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncersSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _bouncers;
    [SerializeField] int _xEdgeBouncersCount;
    [SerializeField] int _zEdgeBouncersCount;

    float _zPointOfBouncers;
    float _xPointOfBouncers;
    int _randomBouncerIndex;
    

    void Start()
    {
        _xPointOfBouncers = transform.position.x;

        for (int i = 0; i < _xEdgeBouncersCount; i+=Random.Range(10,50))
        {
            for (int y = 0; y < _zEdgeBouncersCount; y+= Random.Range(10, 60))
            {
                _randomBouncerIndex = Random.Range(0, _bouncers.Length);
                GameObject bouncer=Instantiate(_bouncers[_randomBouncerIndex], new Vector3(_xPointOfBouncers,transform.position.y,_zPointOfBouncers), Quaternion.identity);
                bouncer.transform.parent = this.transform;
                _zPointOfBouncers += Random.Range(10,20);
            }
            _zPointOfBouncers = 0;
            _xPointOfBouncers += Random.Range(10,15);
        }
    }

    
}
