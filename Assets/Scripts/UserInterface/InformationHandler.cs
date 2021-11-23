using static System.String;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationHandler : MonoBehaviour
{

    private GameManager _gm;

    // Generations Property, Fetches, or sets the generation count, generally to simply increment it by the GameManager.
    public int Generations
    { get; set; } = 0;

    public double UpdateFreq
    { get; set; } = .5;

    public Text generationsText;    // Will display number of generations (AKA loops iterated) the game has generated.

    public Text updateFrequency;    // Will display the update frequency as a float.

    // Start is called before the first frame update
    void Start()
    {
         _gm = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            if((UpdateFreq - 0.1) < 0.1)
            {
                UpdateFreq = 0.1;           // Prevent from going negative.
                _gm.ChangeGameTickInterval((float) UpdateFreq);
                Debug.Log("Update Interval decreased to: " + UpdateFreq);
            }
            else
            {
                UpdateFreq -= 0.1;
                _gm.ChangeGameTickInterval((float) UpdateFreq);
                Debug.Log("Update Interval decreased to: " + UpdateFreq);
            }
           
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            UpdateFreq += 0.1;
            _gm.ChangeGameTickInterval((float) UpdateFreq);
            Debug.Log("Update Interval increased to: " + UpdateFreq);
        }


        generationsText.text = "Generations: " + Generations;

        updateFrequency.text = "Update Frequency: " + System.String.Format("{0:0.00}", UpdateFreq);
    }

 
}
