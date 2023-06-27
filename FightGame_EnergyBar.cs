using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightGame_EnergyBar : MonoBehaviour
{
    FightGame_GameProcess fightGame_GameProcess; // Скрипт игры

    public TextMeshProUGUI energyText; // Текст времени
    public Image energyBar_fill; // Изображение полосы времени

    public float time = 10f; // Переменная времени
    public float timeLeft = 10f; // Остаток времени

    Animator heroAnim; // Аниматор героя
    Animator enemyAnim; // Аниматор врага 

    public GameObject ui_Game;

    public GameObject heroFirstLife; // Изображение первой жизни
    public GameObject heroSecondLife; // Изображение второй жизни
    public GameObject heroThirdLife;  // Изображение третьей жизни

    public GameObject[] lifes; // Массив изображений жизней

    bool invoke = false; // Ограничитель действия условия

    public bool button_Clicked = false; // Переменная следит за тем нажата ли кнопка

    private void Start()
    {
        lifes = new[] { heroThirdLife, heroSecondLife, heroFirstLife }; // Массив с иконками здоровья игрока

        energyText.text = "10"; // Начальное значения таймера

        heroAnim = GameObject.Find("Hero").GetComponent<Animator>(); // Аниматор героя

        fightGame_GameProcess = GameObject.Find("Canvas").GetComponent<FightGame_GameProcess>(); // Скрипт FightGame_GameProcess
        energyBar_fill.GetComponent<Image>(); // Содержит компонент Image объекта energyBar_fill
    }
    void Update()
    {
        if (timeLeft > 0) // Действует пока не вышло время
        {
            invoke = false; // В случае, если время вышло, необходимо задержать скрипт для проигрывания анимаций,
                            // но если оставить else, условие будет работать бесконечно, т.к. верхнее условие не
                            // выполняется, а значит вечно будет происходить else.
                            // Пока время не вышло переменной invoke постоянно присваивается значение false,
                            // чтобы сработал else if, в котором invoke становится true, именно для того,
                            // чтобы условие сработало один раз, но в этой же части кода мы обновляем время,
                            // что позволяет зайти в верхнюю часть кода и повторить цикл

            if (button_Clicked == false) // После нажатия кнопки ответа переменная button_Clicked становится true, 
                                         // а процесс движения полосы времени останавливается
            {
                timeLeft -= Time.deltaTime; // Таймер
                energyBar_fill.fillAmount = timeLeft / time; // Движение полосы времени
            }
            energyText.text = Mathf.RoundToInt(timeLeft).ToString(); //Вывод времени на экран
        }
        else if(!invoke)
        {
            enemyAnim = fightGame_GameProcess.enemies[fightGame_GameProcess.currentEnemy].GetComponent<Animator>(); // Берет аниматор активного врага из массива
            invoke = true; // Переменная является ограничителем для того, чтобы условие сработало один раз
            enemyAnim.SetTrigger("wrongAnswer"); // Активируется анимация неверного ответа у аниматора врага
            heroAnim.SetTrigger("wrongAnswer"); // Активируется анимация неверного ответа у аниматора геро

            lifes[fightGame_GameProcess.lifesCount - 1].gameObject.SetActive(false); // Если закончится время выключается объект массива,
                                                                                     // номер которого равен количеству оставшихся жизней                
            fightGame_GameProcess.lifesCount -= 1; // Если закончится время вычитается одна из жизней

            Invoke("afterAnimation", 1f); // Метод вызывается с задержкой в секунду,
                                          // чтобы анимация атаки успела сработать
        }
    }
    void afterAnimation() // В случае если у игрока закончились жизни происходит ивент поражения,
                          // в ином случае обновляется время
    {
        if (fightGame_GameProcess.lifesCount == 0) // В случае если у игрока закончились жизни происходит ивент поражения
        {
            ui_Game.gameObject.SetActive(false);
        }
        else // В ином случае обновляется время
        {
            timeLeft = 10f;
            fightGame_GameProcess.Game();
        }
    }
}
