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

        for (int i = 0; i < _xEdgeBouncersCount; i+=20)
        {
            for (int y = 0; y < _zEdgeBouncersCount; y+=20)
            {
                _randomBouncerIndex = Random.Range(0, _bouncers.Length);
                Instantiate(_bouncers[_randomBouncerIndex], new Vector3(_xPointOfBouncers,transform.position.y,_zPointOfBouncers), Quaternion.identity);
                _zPointOfBouncers += 15;
            }
            _zPointOfBouncers = 0;
            _xPointOfBouncers += 10;
        }
    }

    
}
