using UnityEngine;

namespace Battlehub.Cubeman
{ 

    public class GameCameraFollow : MonoBehaviour
	{
        // The target we are following

        private Transform m_target;
        /// <summary>
        /// 跟随目标
        /// </summary>
        [SerializeField]
		public Transform target
        {
            get { return m_target; }
            set
            {
                m_target = value;
                float rdamping = rotationDamping;
                float hdamping = heightDamping;
                rotationDamping = float.MaxValue;
                heightDamping = float.MaxValue;
                heightDamping = hdamping;
                rotationDamping = rdamping;
            }
        }
		// The distance in the x-z plane to the target
		public float distance = 5.0f;
		// the height we want the camera to be above the target
		public float height = 5.0f;

		public float rotationDamping = 12.0f;

        public float heightDamping = 2.0f;

		// Use this for initialization
		void Start()
        {

        }

		// Update is called once per frame
		void LateUpdate()
        {
            // Early out if we don't have a target
            if (!target)
                return;

            Follow();
        }
        /// <summary>
        /// 跟随
        /// </summary>
        public void Follow()
        {
            // Calculate the current rotation angles  计算当前旋转角度 
            var wantedRotationAngle = target.eulerAngles.y;
            var wantedHeight = target.position.y + height;

            var currentRotationAngle = transform.eulerAngles.y;
            var currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            // 将相机在 x-z 平面上的位置设置为：
            // 距离目标后面几米 
            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;

            // Set the height of the camera
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            // Always look at the target
            transform.LookAt(target);
        }
    }
}