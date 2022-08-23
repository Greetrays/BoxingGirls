using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAdderer : MonoBehaviour
{
    [SerializeField] private CharacterJoint _originalJoint;
    [SerializeField] private Rigidbody _connectedBody;

    private CharacterJoint _joint;

    public void AddJoint()
    {
        gameObject.AddComponent<CharacterJoint>();
        _joint = GetComponent<CharacterJoint>();
        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        _joint.lowTwistLimit = _originalJoint.lowTwistLimit;
        _joint.swing1Limit = _originalJoint.swing1Limit;
        _joint.swing2Limit = _originalJoint.swing2Limit;
        _joint.connectedBody = _connectedBody;
    }
}
