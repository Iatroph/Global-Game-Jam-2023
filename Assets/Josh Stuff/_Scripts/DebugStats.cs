using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugStats : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody rb;
    public TMP_Text speedText;
    public TMP_Text groundedText;
    public TMP_Text slopeText;

    private void Awake()
    {
        if(TryGetComponent(out PlayerController pc))
        {
            playerController = pc;
        }

        if (TryGetComponent(out Rigidbody rb))
        {
            this.rb = rb;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController != null)
        {
            speedText.text = "Speed: " + Mathf.Round(rb.velocity.magnitude * 10.0f) * 0.1f;
            groundedText.text = "Grounded: " + playerController.isGrounded;
            slopeText.text = "On Slope: " + playerController.OnSlope();

        }
    }
}
