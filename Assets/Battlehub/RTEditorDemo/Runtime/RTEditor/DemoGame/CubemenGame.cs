using UnityEngine.UI;
using UnityEngine;

using System.Collections.Generic;
using System.Collections;
using System.Linq;

using Battlehub.RTCommon;
using System;
using UnityEngine.EventSystems;

namespace Battlehub.Cubeman
{
    public class CubemenGame : MonoBehaviour
    {
        /// <summary>
        /// 分数文本
        /// </summary>
        public Text TxtScore;
        /// <summary>
        /// 完成文本
        /// </summary>
        public Text TxtCompleted;
        /// <summary>
        /// 提示文本
        /// </summary>
        public Text TxtTip;
        public Button BtnReplay;
        public GameObject GameUI;
        /// <summary>
        /// 得分
        /// </summary>
        private int m_score;
        /// <summary>
        /// 角色数
        /// </summary>
        private int m_total;
        /// <summary>
        /// 是否游戏结束
        /// </summary>
        private bool m_gameOver;

        [SerializeField]
        private GameCharacter[] m_storedCharacters;
        /// <summary>
        /// 当前角色
        /// </summary>
        private GameCharacter m_current;
        private int m_currentIndex = -1;
        /// <summary>
        /// 当前角色索引
        /// </summary>
        public int CurrentIndex
        {
            get { return m_currentIndex; }
            set { m_currentIndex = value; }
        }

        private List<GameCharacter> m_activeCharacters;
        private GameCameraFollow m_playerCamera;

        [SerializeField]
        private bool m_cameraFollow = true;
        public bool CameraFollow
        {
            get { return m_cameraFollow; }
            set { m_cameraFollow = value; }
        }
        
        private bool m_isGameRunning;
        /// <summary>
        /// 是否运行中
        /// </summary>
        public bool IsGameRunning
        {
            get { return m_isGameRunning; }
        }

        private static CubemenGame m_instance;
        private void RuntimeAwake()
        {
            if(m_instance != null)
            {
                Debug.LogWarning("Another instance of Cubemen game exist");
                Destroy(m_instance);
                return;
            }
            m_instance = this;
        }

        private void RuntimeStart()
        {
            m_isGameRunning = true;

            StartCoroutine(StartGame());
        }

        private void OnRuntimeDestroy()
        {
            if(m_instance == this)
            {
                m_instance = null;
            }
        }

        private void OnRuntimeActivate()
        {
            m_isGameRunning = true;

            if(m_current != null)
            {
                m_current.HandleInput = true;
            }
        }

        private void OnRuntimeDeactivate()
        {
            m_isGameRunning = false;

            if (m_current != null)
            {
                m_current.HandleInput = false;
            }
        }

        private void OnRuntimeEditorOpened()
        {
            StopGame();
            m_isGameRunning = false;
        }

        private void OnRuntimeEditorClosed()
        {
            m_isGameRunning = true;
            StartCoroutine(StartGame());
        }

        private void Start()
        {
            IRTEState rteState = IOC.Resolve<IRTEState>();
            if(rteState == null || !rteState.IsCreated)
            {
                m_isGameRunning = true;
            }

            EventSystem eventSystem = FindObjectOfType<EventSystem>();
            if(eventSystem == null && GameUI != null)
            {
                GameUI.AddComponent<EventSystem>();
                GameUI.AddComponent<StandaloneInputModule>();
            }
            
            if (BtnReplay != null)
            {
                BtnReplay.onClick.AddListener(RestartGame);
            }
            if (GameUI != null)
            {
                GameUI.SetActive(false);
            }

            if (IsGameRunning)
            {
                StartCoroutine(StartGame());
            }
        }

        private void OnDestroy()
        {
            if (m_instance == this)
            {
                m_instance = null;
            }

            if (BtnReplay != null)
            {
                BtnReplay.onClick.RemoveListener(RestartGame);
            }
        }

        private void Update()
        {
            if(!m_isGameRunning)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SwitchPlayer(m_current, 0.0f, true);
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                SwitchPlayer(m_current, 0.0f, false);
            }
        }

        private IEnumerator StartGame()
        {
            DestroyStoredCharacters();

            yield return new WaitForEndOfFrame();

            if (GameUI != null)
            {
                GameUI.SetActive(true);
            }

            GameCharacter[] characters = FindObjectsOfType<GameCharacter>().Where(g => {
                ExposeToEditor obj = g.GetComponent<ExposeToEditor>();
                return obj != null && !obj.MarkAsDestroyed;
            }).OrderBy(c => c.name).ToArray();

            for (int i = 0; i < characters.Length; ++i)
            {
                characters[i].Game = this;
                characters[i].IsActive = true;
            }

            SaveCharactersInInitalState(characters);
            InitializeGame(characters, m_currentIndex);
        }

        private void DestroyStoredCharacters()
        {
            if (m_storedCharacters != null)
            {
                for (int i = 0; i < m_storedCharacters.Length; ++i)
                {
                    GameCharacter storedCharacter = m_storedCharacters[i];
                    if (storedCharacter != null)
                    {
                        Destroy(storedCharacter.gameObject);
                    }
                }
            }
        }

        private void StopGame()
        {
            RestartGame();

            for(int i = 0; i < m_activeCharacters.Count; ++i)
            {
                GameCharacter character = m_activeCharacters[i];
                character.IsActive = false;
            }

            if(m_playerCamera != null)
            {
                m_playerCamera.target = null;
            }

            if(GameUI != null)
            {
                GameUI.SetActive(false);
            }
        }
        /// <summary>
        /// 重置游戏
        /// </summary>
        private void RestartGame()
        {
            if (m_activeCharacters != null)
            {
                for (int i = 0; i < m_activeCharacters.Count; ++i)
                {
                    GameCharacter activeCharacter = m_activeCharacters[i];
                    Destroy(activeCharacter.gameObject);
                }
            }
            
            GameCharacter[] characters = m_storedCharacters;
            SaveCharactersInInitalState(characters);
            InitializeGame(characters, -1);
        }

        private void InitializeGame(GameCharacter[] characters, int activeCharacterIndex)
        {
            m_gameOver = false;
            if(m_cameraFollow)//摄像机跟随
            {
                m_playerCamera = FindObjectOfType<GameCameraFollow>();
                if (m_playerCamera == null)
                {
                    if (Camera.main != null)
                    {
                        m_playerCamera = Camera.main.gameObject.AddComponent<GameCameraFollow>();
                    }
                }
                //基于摄像机屏幕的UI
                if (m_playerCamera != null)
                {
                    Canvas canvas = GetComponentInChildren<Canvas>();
                    canvas.renderMode = RenderMode.ScreenSpaceCamera;
                    Camera cam = m_playerCamera.GetComponent<Camera>();
                    canvas.worldCamera = cam;
                    canvas.planeDistance = cam.nearClipPlane + 0.05f;
                }
            }
            

            m_activeCharacters = new List<GameCharacter>();
            for (int i = 0; i < characters.Length; ++i)
            {
                GameCharacter character = characters[i];
                character.transform.SetParent(null);
                character.gameObject.SetActive(true);
                character.HandleInput = false;

                ExposeToEditor exposeToEditor = character.GetComponent<ExposeToEditor>();
                if (!exposeToEditor)
                {
                    character.gameObject.AddComponent<ExposeToEditor>();
                }
                else
                {
                    //标记为销毁
                    ExposeToEditor[] children = character.GetComponentsInChildren<ExposeToEditor>(true);
                    for (int j = 0; j < children.Length; ++j)
                    {
                        ExposeToEditor child = children[j];
                        child.MarkAsDestroyed = false;
                    }
                }
                m_activeCharacters.Add(character);
            }

            m_total = m_activeCharacters.Count;
            m_score = 0;

            if (m_total == 0)//可控制角色数为零，代表游戏结束
            {
                TxtCompleted.gameObject.SetActive(true);
                TxtScore.gameObject.SetActive(false);
                TxtTip.gameObject.SetActive(false);

                TxtCompleted.text = "Game Over!";
                m_gameOver = true;
            }
            else
            {
                TxtCompleted.gameObject.SetActive(false);
                TxtScore.gameObject.SetActive(true);
                TxtTip.gameObject.SetActive(true);
                UpdateScore();

                if(activeCharacterIndex >= 0)//当前激活的角色索引
                {
                    m_current = m_activeCharacters[activeCharacterIndex];
                    if (m_current != null)//若当前显示角色不为空
                    {
                        ActivatePlayer();
                    }
                    else
                    {
                        SwitchPlayer(null, 0.0f, true);
                    }
                }
                else
                {
                    SwitchPlayer(null, 0.0f, true);
                }
            }
        }
        /// <summary>
        /// 保存游戏角色到实例
        /// </summary>
        /// <param name="characters"></param>
        private void SaveCharactersInInitalState(GameCharacter[] characters)
        {
            GameCharacter[] storedCharacters = new GameCharacter[characters.Length];
            for (int i = 0; i < characters.Length; ++i)
            {
                GameCharacter character = characters[i];
                bool isActive = character.gameObject.activeSelf;
                character.gameObject.SetActive(false);
                //再创建一个实例
                GameCharacter stored = Instantiate(character, character.transform.position, character.transform.rotation);
                stored.name = character.name;
                character.gameObject.SetActive(isActive);

                ExposeToEditor[] exposeToEditor = stored.GetComponentsInChildren<ExposeToEditor>();
                foreach(ExposeToEditor obj in exposeToEditor)
                {
                    //标记为销毁
                    obj.MarkAsDestroyed = true;
                }

                stored.transform.SetParent(transform);
                storedCharacters[i] = stored;
            }

            m_storedCharacters = storedCharacters;
        }
        /// <summary>
        /// 更新得分
        /// </summary>
        private void UpdateScore()
        {
            TxtScore.text = "Saved : " + m_score + " / " + m_total;
        }
        /// <summary>
        /// 判断是否完成游戏
        /// </summary>
        /// <returns></returns>
        private bool IsGameCompleted()
        {
            return m_activeCharacters.Count == 0;
        }
        /// <summary>
        /// 当玩家完成
        /// </summary>
        /// <param name="gameCharacter"></param>
        public void OnPlayerFinish(GameCharacter gameCharacter)
        {
            m_score++;
            UpdateScore();

            SwitchPlayer(gameCharacter, 1.0f, true);//切换角色
            m_activeCharacters.Remove(gameCharacter);//将完成的角色从角色列表中移除

            if (IsGameCompleted())//如果游戏完成
            {
                m_gameOver = true;
                TxtTip.gameObject.SetActive(false);
                StartCoroutine(ShowText("Congratulation! \n You have completed a great game "));
            }
        }

        private IEnumerator ShowText(string text)
        {
            yield return new WaitForSeconds(1.5f);
            if (m_gameOver)
            {
                TxtScore.gameObject.SetActive(false);
                TxtCompleted.gameObject.SetActive(true);
                TxtCompleted.text = text;
            }
        }
        /// <summary>
        /// 当角色死亡
        /// </summary>
        /// <param name="gameCharacter"></param>
        public void OnPlayerDie(GameCharacter gameCharacter)
        {
            m_gameOver = true;
            m_activeCharacters.Remove(gameCharacter);
            TxtTip.gameObject.SetActive(false);

            StartCoroutine(ShowText("Game Over!"));
            for (int i = 0; i < m_activeCharacters.Count; ++i)
            {
                m_activeCharacters[i].HandleInput = false;
            }
        }
        /// <summary>
        /// 切换玩家
        /// </summary>
        /// <param name="current"></param>
        /// <param name="delay">延迟</param>
        /// <param name="next"></param>
        public void SwitchPlayer(GameCharacter current, float delay, bool next)
        {
            if (m_gameOver)
            {
                return;
            }

            if (current != null)
            {
                current.HandleInput = false;
                m_currentIndex = m_activeCharacters.IndexOf(current);
                if (next)//切换到下一个
                {
                    m_currentIndex++;
                    if (m_currentIndex >= m_activeCharacters.Count)
                    {
                        m_currentIndex = 0;
                    }
                }
                else//切换到上一个
                {
                    m_currentIndex--;
                    if (m_currentIndex < 0)
                    {
                        m_currentIndex = m_activeCharacters.Count - 1;
                    }
                } 
            }

            if(m_currentIndex < 0)
            {
                m_currentIndex = 0;
            }

            m_current = m_activeCharacters[m_currentIndex];

            if (current == null)
            {
                ActivatePlayer();
            }
            else
            {
                StartCoroutine(ActivateNextPlayer(delay));
            } 
        }
        /// <summary>
        /// 延迟显示下一个角色
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        IEnumerator ActivateNextPlayer(float delay)
        {
            yield return new WaitForSeconds(delay);

            if (m_gameOver)
            {
                yield break;
            }

            ActivatePlayer();
        }
        /// <summary>
        /// 显示角色
        /// </summary>
        private void ActivatePlayer()
        {
            if (m_current != null)
            {
                if(IsGameRunning)
                {
                    m_current.HandleInput = true;
                }
            }
            if (m_playerCamera != null)//摄像机跟随
            {
                m_playerCamera.target = m_current.transform;
                m_playerCamera.Follow();
                m_current.Camera = m_playerCamera.transform; 
            }
           
        }
    }
}
