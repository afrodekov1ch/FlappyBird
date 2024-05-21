using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // ссылка на панель, которую вы хотите отобразить/скрыть
    private bool isPanelActive; // флаг, показывающий, активна ли панель в данный момент
    public Button enableButton; // кнопка для включения панели
    public Button disableButton; // кнопка для выключения панели

    void Start()
    {
        // Подписываемся на события нажатия кнопок
        enableButton.onClick.AddListener(EnablePanel);
        disableButton.onClick.AddListener(DisablePanel);

        // Подписываемся на событие загрузки сцены
        SceneManager.sceneLoaded += OnSceneLoaded;

        // По умолчанию панель скрыта
        panel.SetActive(false);
        isPanelActive = false;
    }

    void OnEnable()
    {
        // Сбросить значение флага при включении скрипта
        isPanelActive = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // При загрузке новой сцены сбрасываем состояние панели и игры
        isPanelActive = false;
        panel.SetActive(false);
    }

    public void EnablePanel()
    {
        if (!isPanelActive)
        {
            isPanelActive = true;
            panel.SetActive(true);
        }
    }

    public void DisablePanel()
    {
        if (isPanelActive)
        {
            isPanelActive = false;
            panel.SetActive(false);
        }
    }

    void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}