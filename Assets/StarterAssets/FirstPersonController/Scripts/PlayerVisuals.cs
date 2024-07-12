using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerVisuals : MonoBehaviour
{
    private StarterAssetsInputs _input;

    public GameObject cameraTraget;
    public GameObject body;

    public float crotchLength = 0.5f;

    private Vector3 afterCrotchVector;
    private Vector3 beforeCrotchVector;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        beforeCrotchVector = transform.localScale;
        afterCrotchVector = new Vector3(transform.localScale.x, crotchLength, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.crotch) Crotch();
        else CrotchCanseld();
    }

    private void Crotch()
    {
        transform.localScale = afterCrotchVector;
    }
    private void CrotchCanseld()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, beforeCrotchVector, 0.02f);
    }
}
