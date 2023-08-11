using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rig;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;
    public float waterDrag = 0.9f;
    public float waterAngularDrag = 0.5f;

    private void FixedUpdate()
    {
        rig.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.Instance.GetWaveHeight(transform.position.x);

        if (transform.position.y < waveHeight)
        {
            // 0 ~ 1 : x
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            // Abs 절대값으로 gravity Y Default value를 가져와서 해당 데이터를 곱해준다. 
            rig.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rig.AddForce(displacementMultiplier * -rig.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rig.AddTorque(displacementMultiplier * -rig.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
