using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveNum : MonoBehaviour
{
    public Spawner spawner;
    public TMP_Text waveText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "WAVE " + spawner.waveNum;
    }
}
