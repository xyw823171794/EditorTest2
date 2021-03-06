//#define USE_CROSS_PLATFORM_INPUT

using UnityEngine;

#if USE_CROSS_PLATFORM_INPUT && CROSS_PLATFORM_INPUT
using UnityStandardAssets.CrossPlatformInput;
#endif

namespace Battlehub.Cubeman
{
    /// <summary>
    /// 方块人角色控制器
    /// </summary>
    public class CubemanUserControl : MonoBehaviour
    {
        /// <summary>
        /// 场景变换中对主相机的引用 
        /// A reference to the main camera in the scene transform
        /// </summary>
        public Transform Cam;                    
        private CubemanCharacter m_Character;
        /// <summary>
        /// 当前摄像头的前进方向 
        /// </summary>
        private Vector3 m_CamForward;             // The current forward direction of the camera
        /// <summary>
        /// 
        /// </summary>
        private Vector3 m_Move;
        /// <summary>
        /// 根据 camForward 和用户输入计算出的世界相关的所需移动方向。 
        /// </summary>
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        /// <summary>
        /// 是否可操控
        /// </summary>
        public bool HandleInput;

        private void Start()
        {
            // get the transform of the main camera
            //获取主相机的变换 
            if (Cam == null)
            {
                if(Camera.main != null)
                {
                    Cam = Camera.main.transform;
                }
                
                if(Cam == null)
                {
                    //Debug.LogWarning("No Camera found");
                }
            }

            // get the third person character ( this should never be null due to require component )
            // 获取第三人称字符（由于需要组件，这不应该为空） 
            m_Character = GetComponent<CubemanCharacter>();
            
        }


        private void Update()
        {
            if (!m_Jump)//跳跃
            {

                #if USE_CROSS_PLATFORM_INPUT && CROSS_PLATFORM_INPUT
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump") && HandleInput;
                #else
                m_Jump = Input.GetKey(KeyCode.Space) && HandleInput;
                #endif
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            #if USE_CROSS_PLATFORM_INPUT && CROSS_PLATFORM_INPUT
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            #else
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            #endif
            bool crouch = Input.GetKey(KeyCode.C);

            crouch = false; //No crouching

            if(!HandleInput)
            {
                h = v = 0;
                crouch = false;
            }

            // calculate move direction to pass to character
            //计算传递给角色的移动方向 
            if (Cam != null)
            {
                // calculate camera relative direction to move:
                //计算相机相对移动方向： 
                m_CamForward = Vector3.Scale(Cam.forward, new Vector3(1, 0, 1)).normalized;//结果为Vector3(Cam.forward.x,0,Cam.forward.z).normalized;
                m_Move = v * m_CamForward + h * Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                //在没有主摄像头的情况下，我们使用世界相对方向 
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
            #if !MOBILE_INPUT
            // walk speed multiplier
            //
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            //将所有参数传递给角色控制脚本 
            if (m_Character.enabled)
            {
                m_Character.Move(m_Move, crouch, m_Jump);
            }
            
            m_Jump = false;
        }
    }
}
