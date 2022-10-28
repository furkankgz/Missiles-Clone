using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private float _maxDistance; // benden ne kadar uzak
    [SerializeField] private Vector2 _newDistance; // ne kadar uzaklýða koymam gerek
    [SerializeField] private Vector2 _rangeScale;

    private void Start()
    {
        UpdateDisplay(); 
    }

    private void LateUpdate()
    {
        var distance = Vector3.Distance(PlayerController.Instance.transform.position, transform.position);

        if (distance > _maxDistance) // distance maxdistance'dan büyükse bulutlarýn yerini deðiþtir.
        {
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        transform.localScale = Vector3.one * Random.Range(_rangeScale.x, _rangeScale.y);
        var extra = (Vector3)(Random.insideUnitCircle.normalized * Random.Range(_newDistance.x, _newDistance.y));
        transform.position = PlayerController.Instance.transform.position + extra;

    }
}
