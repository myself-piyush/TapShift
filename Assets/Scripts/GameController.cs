using UnityEngine;
using UnityCore.Session;

public class GameController : MonoBehaviour
{
    private SessionController m_Session;
    private int m_progress;

    public PlayerController player;
    public CameraController camera;

    public ObstacleController obstacles;
    //get session with integrity
    private SessionController session
    {
        get
        {
            if(!m_Session)
            {
                m_Session = SessionController.instance;
                return m_Session;
            }
            if(!m_Session)
            {
                Debug.LogWarning("Game is trying to access the session");
                return m_Session;
            }
            return m_Session;
        }
    }

    #region Unity Functions
    private void Start()
    {
        if (!session) return;
        session.InitializeGame(this);
    }
    #endregion

    #region Public Functions
    public void OnInit()
    {
        player.OnInit();
        camera.OnInit();
        obstacles.AddObstacle(m_progress);
    }
    public void OnUpdate()
    {
        player.OnUpdate();
        camera.OnUpdate();
        CheckPlayerProgress();
    }
    #endregion

    #region Private Functions
    private void CheckPlayerProgress()
    {
        if(player.transform.position.y / obstacles.interval > (m_progress +1))
        {
            m_progress++;
            obstacles.AddObstacle(m_progress);
        }
    }
    #endregion
}
