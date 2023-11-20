using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorFactory : MonoBehaviour
{
    [SerializeField] private int _sectorsCount;

    [SerializeField] private GameObject[] _sectors;
    [SerializeField] private Vector2 _offset;
    

    public void CreateSectors()
    {
        for (int i = 0; i < _sectorsCount; i++)
        {
            var random = Random.Range(0, _sectors.Length);

            var newPosition = transform.position = new Vector3(transform.position.x, transform.position.y + _offset.y, transform.position.z);

            var newSector = Instantiate(_sectors[random], newPosition, Quaternion.identity);
            
        }
    }
}
