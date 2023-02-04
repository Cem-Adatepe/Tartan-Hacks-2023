using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Toggle _toggler;
    [SerializeField] private GameObject _canvas;
    // Start is called before the first frame update
    void Start()
    {
        _toggler.onValueChanged.AddListener((v) => {
        StartCoroutine(waiter());
        });
        
    }

    // Update is called once per frame
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        _canvas.SetActive(true);
    }
}
