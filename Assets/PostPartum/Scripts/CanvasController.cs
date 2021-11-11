using UnityEngine;

namespace PostPartum.Scripts
{
    public class CanvasController : MonoBehaviour
    {
        public void HideAllCanvasImages()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
