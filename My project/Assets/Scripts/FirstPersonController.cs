using TreeEditor;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	
	public class FirstPersonController : MonoBehaviour
	{
        public Vector3[] foodStations;
        public int currentStation = 2;
        Ray ray;
        RaycastHit hit;
        StarterAssetsInputs starterAssetsInputs;
        bool turnedAround = false;
        private void Awake()
        {
            //foodStation[0] = Register
            //foodStation[1] = Toppings
            //foodStation[2] = Ordering
            transform.position = foodStations[currentStation];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D) && currentStation < 2 && !turnedAround) 
            {
                currentStation += 1;
                transform.position = foodStations[currentStation];
            }
            if (Input.GetKeyDown(KeyCode.A) && currentStation > 0 && !turnedAround) 
            {
                currentStation -= 1;
                transform.position = foodStations[currentStation];
            }
            if (Input.GetKeyDown(KeyCode.S) && currentStation == 1) 
            {
                turnedAround = !turnedAround;
                transform.Rotate(new Vector3(0, 180, 0), Space.Self);
            }
            

        }

    }
}