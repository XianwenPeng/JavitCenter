using UnityEngine;
using System.Collections;

public class OpenableDoorRight : MonoBehaviour {

	float smooth = 2.0f;
	float DoorOpenAngle = 90.0f;
	float DoorCloseAngle = 0.0f;
	bool enter;

	void Start(){
		DoorOpenAngle += transform.localRotation.eulerAngles.y;
		DoorCloseAngle += transform.localRotation.eulerAngles.y;
	}

	void  OnTriggerEnter ( Collider other  )
	{
		if (other.tag == "MainCamera")
		{
			enter = true;
		}
        if (other.tag == "Zombie")
        {
            enter = true;
        }
    }


	void  OnTriggerExit ( Collider other  )
	{
		if (other.tag == "MainCamera")
		{
			enter = false;
		}
        if (other.tag == "Zombie")
        {
            enter = true;
        }
    }

	void Update()
	{
		if(enter == true)
		{
			var target = Quaternion.Euler (0, DoorOpenAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
		}

		if(enter == false)
		{
			var target1= Quaternion.Euler (0, DoorCloseAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * smooth);
		}  

	}
}
