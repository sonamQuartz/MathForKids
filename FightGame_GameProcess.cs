using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightGame_GameProcess : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //Текст количества очков
    public float score = 0f; //Количество очков

    int lastNumberOne;  // Переменные, в которых хранится результат прошлого примера
    int lastNumberTwo;  // В случае, если совпадет прошлый и новый пример, переменные numberOne numberTwo
    int lastNumberThree;  // будут перезаполняться во избежание повтора

    int numberOne; //Первая переменная в задаче
    int numberTwo; //Вторая переменная в задаче
    int numberThree; //Третье число в сложной игре

    public TextMeshProUGUI taskText; //Текст задачи

    public int result;  //Результат

    int numberOfRightAnswer; // Переменная со значением позиции правильного ответа 

    int var;    //Хранит случайное знаничение, которое будет
                //создавать разницу между правильным и случайным ответом

    int[] answers = new int[4]; //Массив ответов

    public TextMeshProUGUI blueButtonText;   //Текст кнопок
    public TextMeshProUGUI redButtonText;    //Текст кнопок
    public TextMeshProUGUI purpleButtonText; //Текст кнопок
    public TextMeshProUGUI greenButtonText;  //Текст кнопок

    public float damage; // Урон

    public float health = 100; // Здоровье врага

    public int lifesCount = 3; // Жизни героя

    public GameObject energyBar; // Полоса времени

    public GameObject skeleton;
    public GameObject ogre;
    public GameObject stone;

    public GameObject skeletonIcon;
    public GameObject ogreIcon;
    public GameObject stoneIcon;

    public GameObject[] enemies; // Массив врагов
    public GameObject[] enemiesIcons;

    public int currentEnemy; // Сравнение прошлого и текущего номера врага из массива позволит избежать повтора
    public int lastEnemy; // Сравнение прошлого и текущего номера врага из массива позволит избежать повтора

    public void Game() //Основной метод игрового процесса
    {
        if (PlayerPrefs.GetString("MathMode") == "+" && PlayerPrefs.GetString("Difficulty") == "Easy")
        {

            taskText.fontSize = 200;

            numberOne = Random.Range(1, 10);    // Случайные значения двух слогаемых
            numberTwo = Random.Range(1, 10);    // Случайные значения двух слогаемых
                                                // 
            taskText.text = $"{numberOne} + {numberTwo}";   // Вывод задачи на экран

            result = numberOne + numberTwo; // Расчет результата

            numberOfRightAnswer = Random.Range(0, 3); //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";      // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;     // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";    //
            greenButtonText.text = $"{answers[3]}";     //

        }
        if (PlayerPrefs.GetString("MathMode") == "+" && PlayerPrefs.GetString("Difficulty") == "Middle")
        {

            taskText.fontSize = 170;

            numberOne = Random.Range(10, 100);    // Случайные значения двух слогаемых
            numberTwo = Random.Range(10, 100);    // Случайные значения двух слогаемых
                                                  // 
            taskText.text = $"{numberOne} + {numberTwo}";   // Вывод задачи на экран

            result = numberOne + numberTwo; // Расчет результата

            numberOfRightAnswer = Random.Range(0, 3); //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-5, 5);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-5, 5);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";      // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;     // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";    //
            greenButtonText.text = $"{answers[3]}";     //

        }
        if (PlayerPrefs.GetString("MathMode") == "+" && PlayerPrefs.GetString("Difficulty") == "Hard")
        {

            taskText.fontSize = 120;

            numberOne = Random.Range(10, 100);    // Случайные значения двух слогаемых
            numberTwo = Random.Range(10, 100);    // Случайные значения двух слогаемых
            numberThree = Random.Range(10, 100);    // Случайные значения двух слогаемых
                                                    // 
            taskText.text = $"{numberOne} + {numberTwo} + {numberThree}";   // Вывод задачи на экран

            result = numberOne + numberTwo + numberThree; // Расчет результата

            numberOfRightAnswer = Random.Range(0, 3); //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";      // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;     // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";    //
            greenButtonText.text = $"{answers[3]}";     //

        }

        if (PlayerPrefs.GetString("MathMode") == "-" && PlayerPrefs.GetString("Difficulty") == "Easy")
        {

            taskText.fontSize = 200;

            numberOne = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого
            numberTwo = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого                                             

            if (numberOne > numberTwo || numberOne == numberTwo)  // Уменьшаемое должно быть больше вычитаемого
            {
                taskText.text = $"{numberOne} - {numberTwo}";   // Вывод задачи на экран
                result = numberOne - numberTwo; // Расчет результата
            }
            if (numberTwo > numberOne)  // Уменьшаемое должно быть больше вычитаемого
            {
                taskText.text = $"{numberTwo} - {numberOne}";   // Вывод задачи на экран
                result = numberTwo - numberOne; // Расчет результата
            }

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //
        }
        if (PlayerPrefs.GetString("MathMode") == "-" && PlayerPrefs.GetString("Difficulty") == "Middle")
        {

            taskText.fontSize = 170;

            numberOne = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого
            numberTwo = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого                                             

            while (!(numberOne > numberTwo && (numberOne - numberTwo > 0)))
            {
                numberOne = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого
                numberTwo = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого                                             
            }

            taskText.text = $"{numberOne} - {numberTwo}";   // Вывод задачи на экран
            result = numberOne - numberTwo; // Расчет результата

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //
        }
        if (PlayerPrefs.GetString("MathMode") == "-" && PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            taskText.fontSize = 120;

            numberOne = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого
            numberTwo = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого                                             
            numberThree = Random.Range(10, 100);

            while (!(numberOne > numberTwo && numberOne > numberThree && numberTwo > numberThree && (numberOne - numberTwo - numberThree > 0)))
            {
                numberOne = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого
                numberTwo = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого                                             
                numberThree = Random.Range(10, 100);
            }

            taskText.text = $"{numberOne} - {numberTwo} - {numberThree}";   // Вывод задачи на экран
            result = numberOne - numberTwo - numberThree; // Расчет результата

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //
        }

        if (PlayerPrefs.GetString("MathMode") == "*" && PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            taskText.fontSize = 200;

            numberOne = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого
            numberTwo = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого                                             

            while (numberOne == lastNumberOne || numberTwo == lastNumberTwo) //Действие, избегающее повторных примеров
            {
                numberOne = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого
                numberTwo = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого   
            }

            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;

            taskText.text = $"{numberOne} * {numberTwo}";   // Вывод задачи на экран

            result = numberOne * numberTwo; // Расчет результата

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
        if (PlayerPrefs.GetString("MathMode") == "*" && PlayerPrefs.GetString("Difficulty") == "Middle")
        {
            taskText.fontSize = 170;

            numberOne = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого
            numberTwo = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого                                             
            numberTwo = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого                                             

            while (numberOne == lastNumberOne || numberTwo == lastNumberTwo || numberThree == lastNumberThree) //Действие, избегающее повторных примеров
            {
                numberOne = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого
                numberTwo = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого    
                numberThree = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого    
            }

            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;
            lastNumberThree = numberThree;

            taskText.text = $"{numberOne} * {numberTwo} * {numberThree}";   // Вывод задачи на экран

            result = numberOne * numberTwo * numberThree; // Расчет результата

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
        if (PlayerPrefs.GetString("MathMode") == "*" && PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            taskText.fontSize = 120;

            numberOne = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого
            numberTwo = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого                                             

            while (numberOne == lastNumberOne || numberTwo == lastNumberTwo) //Действие, избегающее повторных примеров
            {
                numberOne = Random.Range(10, 100);    // Случайные значения уменьшаемого/вычитаемого
                numberTwo = Random.Range(1, 10);    // Случайные значения уменьшаемого/вычитаемого   
            }

            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;

            taskText.text = $"{numberOne} * {numberTwo}";   // Вывод задачи на экран

            result = numberOne * numberTwo; // Расчет результата

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }

        if (PlayerPrefs.GetString("MathMode") == "/" && PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            taskText.fontSize = 200;

            numberOne = Random.Range(1, 10);    //Заполнение переменных случайными значениями 
            numberTwo = Random.Range(1, 10);    // 

            while (numberOne % numberTwo != 0 || numberOne == lastNumberOne || numberTwo == lastNumberTwo || numberOne == numberTwo || numberTwo == 1)
            //Вехняя строчка предназначена для образования корректного примера
            {
                numberOne = Random.Range(1, 10);    //Заполнение переменных случайными значениями 
                numberTwo = Random.Range(1, 10);    // 
            }
            taskText.text = $"{numberOne} / {numberTwo}";   // Вывод задачи на экран
            result = numberOne / numberTwo;    // Расчет результата
            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
        if (PlayerPrefs.GetString("MathMode") == "/" && PlayerPrefs.GetString("Difficulty") == "Middle")
        {
            taskText.fontSize = 170;

            numberOne = Random.Range(10, 100);    //Заполнение переменных случайными значениями 
            numberTwo = Random.Range(1, 10);

            while (numberOne % numberTwo != 0 || numberOne == lastNumberOne || numberTwo == lastNumberTwo || numberOne == numberTwo || numberTwo == 1)
            //Вехняя строчка предназначена для образования корректного примера
            {
                numberOne = Random.Range(10, 100);    //Заполнение переменных случайными значениями 
                numberTwo = Random.Range(1, 10);    // 
            }
            taskText.text = $"{numberOne} / {numberTwo}";   // Вывод задачи на экран
            result = numberOne / numberTwo;    // Расчет результата
            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var <= 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var <= 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var <= 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var <= 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
        if (PlayerPrefs.GetString("MathMode") == "/" && PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            taskText.fontSize = 120;

            numberOne = Random.Range(10, 100);    //Заполнение переменных случайными значениями 
            numberTwo = Random.Range(1, 10);
            numberThree = Random.Range(1, 10);

            while (numberOne % numberTwo != 0 || numberOne / numberTwo % numberThree != 0 || numberOne == lastNumberOne || numberTwo == lastNumberTwo || numberOne == numberTwo || numberTwo == 1 || numberThree == 1)
            //Вехняя строчка предназначена для образования корректного примера
            {
                numberOne = Random.Range(10, 100);    //Заполнение переменных случайными значениями 
                numberTwo = Random.Range(1, 10);    // 
                numberThree = Random.Range(1, 10);    // 
            }
            taskText.text = $"{numberOne} / {numberTwo} / {numberThree}";   // Вывод задачи на экран

            result = numberOne / numberTwo / numberThree;    // Расчет результата

            lastNumberOne = numberOne;
            lastNumberTwo = numberTwo;
            lastNumberThree = numberThree;

            numberOfRightAnswer = Random.Range(0, 3);   //Случайный выбор позиции верного ответа

            for (int i = 0; i < answers.Length; i++) //Цикл, заполняющий массив ответов значениями
            {

                var = Random.Range(-3, 3);    //Хранит случайное знаничение, которое будет
                                              //создавать разницу между правильным и случайным ответом
                answers[i] = result;

                if (answers[i] + var < 0) answers[i] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                else answers[i] += var;                                     //отрицательное число, берется модуль var                  

                while (answers[0] == answers[1])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[1] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[1] + var < 0) answers[1] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[1] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[2] || answers[1] == answers[2])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[2] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[2] + var < 0) answers[2] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[2] += var;                                     //отрицательное число, берется модуль var
                }

                while (answers[0] == answers[3] || answers[1] == answers[3] || answers[2] == answers[3])
                {
                    var = Random.Range(-3, 3);  //Хранит случайное знаничение, которое будет
                                                //создавать разницу между правильным и случайным ответом

                    answers[3] = result;    //Чтобы неверные ответы находились в близком диапазоне
                                            // приравниваем каждый из них к результату

                    if (answers[3] + var < 0) answers[3] += Mathf.Abs(var);     //В случае, если переменная var в сумме с  
                    else answers[3] += var;                                     //отрицательное число, берется модуль var
                }

                if (i == numberOfRightAnswer) answers[i] = result;      // Если круг цикла совпадает с позицией верного ответа
            }                                                           // ячейке массива присваивается верный ответ

            blueButtonText.text = $"{answers[0]}";    // Присваивание текстовым переменным
            redButtonText.text = $"{answers[1]}"; ;   // значения ответов массива
            purpleButtonText.text = $"{answers[2]}";  //
            greenButtonText.text = $"{answers[3]}";   //

        }
    }
    public void Start()
    {
        scoreText.text = "0"; //Обнуление очков при запуске
        Game(); // Создание примера и ответов
        Invoke("GameStart", 1);

        enemies = new[] { skeleton, ogre, stone }; // Массив врагов
        enemiesIcons = new[] { skeletonIcon, ogreIcon, stoneIcon }; // Массив иконок у полосы здоровья

        currentEnemy = Random.Range(0, 3); // Выбирается случайный враг
        lastEnemy = currentEnemy;

        enemies[currentEnemy].SetActive(true); // Активируется враг
        enemiesIcons[currentEnemy].SetActive(true); // и его иконка
    }

    void GameStart()
    {
        energyBar.GetComponent<FightGame_EnergyBar>().enabled = true;
    }
}