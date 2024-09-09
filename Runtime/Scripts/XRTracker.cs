using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class XRTracker : MonoBehaviour
{
	[SerializeField] InputActionReference _positionAction;
	[SerializeField] bool _isXForward;

	void Update()
	{
		var position = _positionAction.action.ReadValue<Vector3>();

		if (_isXForward)
			transform.localPosition = new Vector3(position.z, position.y, -position.x);
		else
			transform.localPosition = position;
	}

	void OnEnable()
	{
		_positionAction.action.Enable();
	}

	void OnDisable()
	{
		_positionAction.action.Disable();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, transform.forward);

		// gizmo in z direction
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, transform.up);
	}
}