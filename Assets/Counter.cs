using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float secondsBetweenCount;
    private bool _isCounterWorking;
    private int _count = 0;
    private Coroutine _counterCorutine;

    public void Start()
    {
        StartCounter();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ChangeCounterState();
    }

    private IEnumerator Count()
    {
        WaitForSeconds delay = new WaitForSeconds(secondsBetweenCount);

        while (true)
        {
            _count++;
            Debug.Log(_count);
            yield return delay;
        }
    }

    private void StartCounter()
    {
            _isCounterWorking = true;
            _counterCorutine = StartCoroutine(Count());
    }
    
    private void StopCounter()
    {
        _isCounterWorking = false;
        StopCoroutine(_counterCorutine);
    }

    private void ChangeCounterState()
    {
        if (_isCounterWorking)
            StopCounter();
        else
            StartCounter();
    }
}
