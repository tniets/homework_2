using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _interval;
    [SerializeField] private Transform[] _points;
    [SerializeField] private int _count;

    private int _currentSpawnPointIndex;

    private void Start()
    {
        if (_points.Length > 0)
            StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var interval = new WaitForSeconds(_interval);

        for (int i = 0; i < _count; i++)
        {
            var nextPosition = _points[_currentSpawnPointIndex].position;
            Instantiate(_template, nextPosition, Quaternion.identity);

            _currentSpawnPointIndex++;

            if (_currentSpawnPointIndex >= _points.Length)
                _currentSpawnPointIndex = 0;

            yield return interval;
        }
    }

}
