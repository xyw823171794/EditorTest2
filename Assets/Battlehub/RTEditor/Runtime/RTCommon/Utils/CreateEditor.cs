using System;
using UnityEngine;
using UnityEngine.UI;

namespace Battlehub.RTCommon
{
    [DefaultExecutionOrder(-100)]
    public class CreateEditor : MonoBehaviour, IRTEState
    {
        /// <summary>
        /// 创建事件
        /// </summary>
        public event Action<object> Created;
        /// <summary>
        /// 销毁事件
        /// </summary>
        public event Action<object> Destroyed;

        public bool IsCreated
        {
            get { return m_editor != null; }
        }
        /// <summary>
        /// 打开编辑模式的按钮
        /// </summary>
        [SerializeField]
        private Button m_createEditorButton = null;
        /// <summary>
        /// 编辑器预制
        /// </summary>
        [SerializeField]
        private RTEBase m_editorPrefab = null;
        /// <summary>
        /// 加载页面
        /// </summary>
        [SerializeField]
        private Splash m_splashPrefab = null;

        private RTEBase m_editor;

        private void Awake()
        {
            IOC.RegisterFallback<IRTEState>(this);//注册
            m_editor = (RTEBase)FindObjectOfType(m_editorPrefab.GetType());//在场景中查找有RTEBase类型的游戏对象
            if (m_editor != null)
            {
                if (m_editor.IsOpened)
                {
                    m_editor.IsOpenedChanged += OnIsOpenedChanged;
                    gameObject.SetActive(false);
                }
            }
            m_createEditorButton.onClick.AddListener(OnOpen);
        }

        private void OnDestroy()
        {
            IOC.UnregisterFallback<IRTEState>(this);//卸载
            if (m_createEditorButton != null)
            {
                m_createEditorButton.onClick.RemoveListener(OnOpen);
            }
            if (m_editor != null)
            {
                m_editor.IsOpenedChanged -= OnIsOpenedChanged;
            }
        }
        /// <summary>
        /// 打开编辑器页面
        /// </summary>
        private void OnOpen()
        {
            Debug.Log("OnOpen");
            if (m_splashPrefab != null)
            {
                //实例化后直接调用Show方法
                Instantiate(m_splashPrefab).Show(() => InstantiateRuntimeEditor());
            }
            else
            {
                InstantiateRuntimeEditor();
            }
        }
        /// <summary>
        /// 实例化编辑器预制
        /// </summary>
        private void InstantiateRuntimeEditor()
        {
            m_editor = Instantiate(m_editorPrefab);
            m_editor.name = "RuntimeEditor";
            m_editor.IsOpenedChanged += OnIsOpenedChanged;
            m_editor.transform.SetAsFirstSibling();//设置最先渲染，会被后面的挡住
            if (Created != null)
            {
                Created(m_editor);
            }
            gameObject.SetActive(false);
        }
        /// <summary>
        ///  编辑器界面关闭后的回调
        /// </summary>
        private void OnIsOpenedChanged()
        {
            if (m_editor != null)
            {
                if (!m_editor.IsOpened)//
                {
                    m_editor.IsOpenedChanged -= OnIsOpenedChanged;

                    if (this != null)
                    {
                        gameObject.SetActive(true);
                    }

                    Destroy(m_editor);

                    if (Destroyed != null)
                    {
                        Destroyed(m_editor);
                    }
                }
            }
        }
    }
}

