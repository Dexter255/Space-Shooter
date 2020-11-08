using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    private bool _spawn = true;

    void Start()
    {
        StartCoroutine(SpawnGameObject());
    }

    void Update()
    {

    }

    private IEnumerator SpawnGameObject()
    {
        while (_spawn)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab,
                new Vector3(Random.Range(-12.0f, 12.0f), 5.7f, 0),
                Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void OnPlayerDeath()
    {
        _spawn = false;
    }
}
