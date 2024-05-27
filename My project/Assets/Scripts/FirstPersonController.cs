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
        public int currentStation = 1;
        Ray ray;
        RaycastHit hit;
        StarterAssetsInputs starterAssetsInputs;
        private void Awake()
        {
            //foodStation[0] = Meat
            //foodStation[1] = Register
            //foodStation[2] = Toppings
            transform.position = foodStations[currentStation];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D) && currentStation < 2) 
            {
                currentStation += 1;
                transform.position = foodStations[currentStation];
            }
            if (Input.GetKeyDown(KeyCode.A) && currentStation > 0) 
            {
                currentStation -= 1;
                transform.position = foodStations[currentStation];
            }

        }

    }
}