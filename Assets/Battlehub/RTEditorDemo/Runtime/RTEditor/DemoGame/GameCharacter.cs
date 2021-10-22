using UnityEngine;
using Battlehub.Cubeman;
using Battlehub.RTCommon;
namespace Battlehub.Cubeman
{ 
    /// <summary>
    /// 游戏角色
    /// </summary>
    [DisallowMultipleComponent]
    public class GameCharacter : MonoBehaviour
    {
        /// <summary>
        /// 方块人游戏管理器实例
        /// </summary>
        public CubemenGame Game;
        /// <summary>
        /// 刚体
        /// </summary>
        private Rigidbody m_rigidBody;
        /// <summary>
        /// 控制器
        /// </summary>
        private CubemanUserControl m_userControl; 
        /// <summary>
        /// 灵魂
        /// </summary>
        private Transform m_soul;
        /// <summary>
        /// 渲染组件
        /// </summary>
        private SkinnedMeshRenderer m_skinnedMeshRenderer;
        /// <summary>
        /// 
        /// </summary>
        public Transform Camera
        {
            get { return m_userControl.Cam; }
            set { m_userControl.Cam = value; }
        }

        public bool HandleInput
        {
            get { return m_userControl.HandleInput; }
            set
            {
                m_userControl.HandleInput = value;
            }
        }
        /// <summary>
        /// 是否激活
        /// </summary>
        private bool m_isActive;
        public bool IsActive
        {
            get { return m_isActive; }
            set
            {
                m_isActive = value;
                //激活重力
                Rigidbody rig = gameObject.GetComponent<Rigidbody>();
                if (rig)
                {
                    rig.isKinematic = !m_isActive;
                }
                //激活角色
                CubemanCharacter cubemanCharacter = gameObject.GetComponent<CubemanCharacter>();
                if (cubemanCharacter)
                {
                    cubemanCharacter.Enabled = m_isActive;
                }
            }
        }

        private void Awake()
        {
            m_userControl = GetComponent<CubemanUserControl>();//获取控制器
        }

        private void Start()
        {
            m_soul = transform.Find("Soul");//获取角色灵魂
            m_skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();//获取渲染组件
            m_rigidBody = GetComponent<Rigidbody>();//获取刚体

            if (Game == null)
            {
                Game = FindObjectOfType<CubemenGame>();
            }
        }

        private void Update()
        {
            if (Game == null)
            {
                return;
            }

            if (!Game.IsGameRunning)
            {
                return;
            }

            if (transform.position.y < -25.0f)//所在高度小于-25，就判定死亡
            {
                Die();
            }

            if(Input.GetKeyDown(KeyCode.K))//按下K键自杀
            {
                Die();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!Game.IsGameRunning)
            {
                return;
            }

            if(other.tag == "Finish")//是否完成
            {
                Game.OnPlayerFinish(this);
                if (m_skinnedMeshRenderer != null)
                {
                    m_skinnedMeshRenderer.enabled = false;
                }
                if (m_soul != null)
                {
                    m_soul.gameObject.SetActive(true);
                }
                Destroy(gameObject, 2);
            }
        }
        /// <summary>
        /// 杀死
        /// </summary>
        private void Die()
        {
            enabled = false;
            Game.OnPlayerDie(this);
            if(m_skinnedMeshRenderer != null)
            {
                m_skinnedMeshRenderer.enabled = false;
            }
            if(m_rigidBody != null)
            {
                m_rigidBody.isKinematic = true;
            }
            if(m_userControl != null)
            {
                m_userControl.HandleInput = false;
            }
            if(m_soul != null)
            {
                m_soul.gameObject.SetActive(true);
            }
            Destroy(gameObject, 2);
        }
    }
}

