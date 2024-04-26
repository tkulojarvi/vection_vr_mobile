//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

//added
using UnityEngine.SceneManagement;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectController : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    //public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    //public Material GazedAtMaterial;

    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    /*
    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;
    */

    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _startingPosition = transform.parent.localPosition;

        _myRenderer = GetComponent<Renderer>();

        // added
        baseScale = transform.localScale; // Store the initial scale of the object

        // Save the original rotation when the object starts
        originalRotation = transform.rotation;

        // Get shadow spinner
        // Find the GameObject with the specified tag
        spinObject = GameObject.FindWithTag("Spinner");
        
        SetMaterial(false);
    }

    /*
    /// <summary>
    /// Teleports this instance randomly when triggered by a pointer click.
    /// </summary>
    public void TeleportRandomly()
    {
        // Picks a random sibling, activates it and deactivates itself.
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
        GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

        // Computes new object's location.
        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        float distance = Random.Range(_minObjectDistance, _maxObjectDistance);
        float height = Random.Range(_minObjectHeight, _maxObjectHeight);
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * distance, height,
                                     Mathf.Sin(angle) * distance);

        // Moves the parent to the new position (siblings relative distance from their parent is 0).
        transform.parent.localPosition = newPos;

        randomSib.SetActive(true);
        gameObject.SetActive(false);
        SetMaterial(false);
    }
    */

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        //timer
        StartTimer();
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        // stop timer
        StopTimer();
        
    }

    /*
    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        TeleportRandomly();
    }
    */

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        /*
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
        */

        /*
        if (gazedAt)
        {
            _myRenderer.material.color = GazedAtColor; // Set the material's color to GazedAtColor
        }
        else
        {
            _myRenderer.material.color = InactiveColor; // Set the material's color to InactiveColor
        }
        */
        
        
        if (gazedAt)
        {
            emissionOn = !emissionOn; // Set the material's color to GazedAtColor
            ToggleEmission(true);
        }
        else
        {
            emissionOn = !emissionOn; // Set the material's color to InactiveColor
            ToggleEmission(false);
        }
        
    }


    // custom 

    public float timeRemaining = 30f;
    public float originalTimeRemaining = 30f;
    private bool timerIsRunning = false;


    public Color emissionColor = Color.blue; // Set the color you want for emission
    public float emissionIntensity = 1f; // Set the intensity of emission when it's turned on
    private bool emissionOn = false;


    public float pulseSpeed = 1.0f; // Adjust the speed of the pulse
    public float minScale = 0.95f; // Minimum scale of the object
    public float maxScale = 1.05f; // Maximum scale of the object
    private Vector3 baseScale;


    private Quaternion originalRotation;
    

    public GameObject spinObject;


    // custom function
    // used for switching between main scene and vection scenes (tapes)

    public void SwitchScene()
    {
        // check the tag of the GameObject this script is attached 
        /*
        if (gameObject.tag == "MAIN")
        {
            // Load the scene by its name
            SceneManager.LoadScene("Main");
        }
        */

        if (gameObject.tag == "TAPE_1")
        {
            // Load the scene by its name
            SceneManager.LoadScene("TAPE_1");
        }

        else if (gameObject.tag == "TAPE_2")
        {
            // Load the scene by its name
            SceneManager.LoadScene("TAPE_2");
        }

        else if (gameObject.tag == "TAPE_3")
        {
            // Load the scene by its name
            SceneManager.LoadScene("TAPE_3");
        }

        else if (gameObject.tag == "TAPE_4")
        {
            // Load the scene by its name
            SceneManager.LoadScene("TAPE_4");
        }

        else if (gameObject.tag == "TAPE_5")
        {
            // Load the scene by its name
            SceneManager.LoadScene("TAPE_5");
        }

        else if (gameObject.tag == "TAPE_6")
        {
            // Load the scene by its name
            SceneManager.LoadScene("TAPE_6");
        }

        else if (gameObject.tag == "TAPE_7")
        {
            // Load the scene by its name
            SceneManager.LoadScene("TAPE_7");
        }

        else if (gameObject.tag == "TAPE_8")
        {
            // Load the scene by its name
            SceneManager.LoadScene("TAPE_8");
        }
    }

    void FixedUpdate()
    {
        // ANIMATION
        if (gameObject.tag != "MAIN" && timerIsRunning == false)
        {
            // Rotation
            transform.Rotate(-Vector3.forward, 45f * Time.deltaTime);
        }

        // PULSE
        if(timerIsRunning)
        {
            // Calculate the new scale using a sine wave to create the pulsing effect
            float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(Time.time * pulseSpeed, 1.0f));

            transform.localScale = baseScale * scale; // Apply the new scale to the object
        }
    }

    
    void Update()
    {
        /*
        //test
        // Check for keyboard input to load the scene
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode.Space to any key you want
        {
            SceneManager.LoadScene("TAPE_7");
        }
        */
        
        // TIMER
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //Debug.Log(timeRemaining);
            }

            else
            {
                // timer complete
                // stop timer
                timerIsRunning = false;

                // switch scene
                SwitchScene();
            }
        }
    }

    public void StartTimer()
    {
        // start timer
        timerIsRunning = true;

        // Reset the rotation to the original rotation
        transform.rotation = originalRotation;

        //colorchange
        SetMaterial(true);
    }

    public void StopTimer()
    {
        // stop timer
        timerIsRunning = false;

        // reset timer
        timeRemaining = originalTimeRemaining;

        // Reset the rotation to the shadow spin rotation
        transform.rotation = ShadowSpinValues();

        // reset size
        transform.localScale = baseScale;

        // color change back
        SetMaterial(false);
    }

    

    void ToggleEmission(bool enable)
    {
        if (enable)
        {
             _myRenderer.material.EnableKeyword("_EMISSION");
             _myRenderer.material.SetColor("_EmissionColor", emissionColor * emissionIntensity);
        }
        else
        {
             _myRenderer.material.DisableKeyword("_EMISSION");
        }
    }

    public Quaternion ShadowSpinValues()
    {
        // Get the Spin script attached to the found GameObject
        Spin spinScript = spinObject.GetComponent<Spin>();

        // Retrieve the value of shadowSpinner
        Quaternion shadowSpinnerValue = spinScript.GetShadowSpinner();

        return shadowSpinnerValue;
    }
}

