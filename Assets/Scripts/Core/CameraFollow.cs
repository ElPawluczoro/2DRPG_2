using UnityEngine;

namespace RPG.Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        void Update()
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

/*            float xGap = player.transform.position.x - transform.position.x;
            float yGap = player.transform.position.y - transform.position.y;
            transform.position = new Vector3(transform.position.x + xGap * Time.deltaTime, transform.position.y + yGap * Time.deltaTime, -10);*/
        }
    }
}
