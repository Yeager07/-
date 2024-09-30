# Работа #6 - Основы разработки интерфейса пользователя
Отчет по лабораторной работе #6 выполнил(а):
- Есипенко Игорь Ярославович
- РИ-320936
- АТ-09
# Цель: научиться создавать интерфейс пользователя в Unity, управлять объектами на сцене через UI и получать обратную связь

![image](https://github.com/user-attachments/assets/0fe75a4f-361f-457a-a865-675d97ef679c)

Рекомендуемые источники для изучения:
1.	User interface in Unity Documentation
2.	Theme in lecture materials

# Задание 1. Установим фон
1.1 В этой работе мы создадим простой интерфейс для управления игровым объектом на сцене. Интерфейс пользователя создаётся внутри объекта Canvas. Кликните правой кнопкой мыши в окне Hiararchy и выберите -> UI -> Image. Так в окне иерархии будет создан холст Canvas с изображением на этом холсте. Позднее созданный элемент изображения мы преобразуем в фон игры.

![image](https://github.com/user-attachments/assets/a58f3de1-2258-46a4-81fd-47f0baf2ac1f)

## Создал холст

![image](https://github.com/user-attachments/assets/55fa65dc-5e8d-45f4-bdc0-d0bf668b6987)

1.2 С настройками по умолчанию хост растягивается на всю ширину экрана и адаптирован под размер окна пользователя.
1.3 Чтобы растянуть созданное изображение на всю ширину экрана, выберите его в окне Hierarchy и далее в окне Inspector откройте настройку якорей Anchor, нажмите Alt+Shift и выберите внизу справа элемент растягивания изображения по всей ширине холста:

![image](https://github.com/user-attachments/assets/25f9f96e-6b58-4a9d-ac6f-b70bf2b5ec3c)

1.4 Теперь вместо белого фона изображения мы можем поместить любое изображение. Скачайте любой понравившийся фон, например, с сайта freepik.com. И перенесите фон в папку Project Unity.
1.5 Чтобы изображение можно было использовать в качестве фона, нужно изменить его Texture Type на вид Sprite (2D and UI). После этого спрайт можно будет установить вместо белого изображения в качестве фона:

![image](https://github.com/user-attachments/assets/a9c72855-9cc9-4bcf-8ec9-8412399447fd)

## Скачал изображение с сайта freepik.com, после чего поменял ему Texture Type и назначил в качестве текстуры для заднего фона экрана

![image](https://github.com/user-attachments/assets/5930e382-6a59-4c21-be66-64ed41bc2614)

1.6 Чтобы созданный фон выступал в качестве подложки, то есть находился на заднем плане всех создаваемых игровых объектов: установите настройки Renderer Mode - Screen Space Camera и поместите камеру в поле render Camera. После этого попробуйте создать новый объект, он должен создаваться на переднем фоне. Если этого не происходит, возможно создаваемый объект находится за пределами области видимости камеры (нажмите Reset position, чтобы установить положение по умолчанию):

![image](https://github.com/user-attachments/assets/8c673493-56c2-443d-bfa9-65cb7b56f076)

## В параметрах фона сделал так, чтобы он всё время был на заднем плане, после чего добавил куб, который отображается перед фоном.

![image](https://github.com/user-attachments/assets/02c6bda8-beaa-4af2-9917-d13d88e417a4)

# Задание 2. Создание элементов управления в интерфейсе
2.1 По примеру создания Image в предыдущем пункте создайте три кнопки управления: клик правой кнопкой мыши - Create - UI - Button TextMeshPro. Настройка расположения кнопок происходит с помощью якорей. Нужно стремиться так подбирать настройку якорей, чтобы элементы интерфейса корректно работали для большинства разрешений экрана. Создайте такую настройку якорей для кнопок, чтобы кнопки гарантированной находились в нижней центральной части экрана. Интерфейс адаптируется под горизонтальную ориентацию:

![image](https://github.com/user-attachments/assets/bacc6270-e86c-4c52-84b9-68b3dcdd8a94)

## Создал 3 кнопки и разместил их нужным образом

![image](https://github.com/user-attachments/assets/66c617b4-0d34-4055-8c4b-0dbcab63aeb4)

2.2 Если развернуть настройки кнопки в окне Hierarchy, вы увидите вложенный элемент Text. В настройках инспектора этого элемента вы можете изменить текст кнопки. А если кликнуть по Button, - то в настройках Inspector можно изменить вид кнопки. В настройках можно указывать спрайты (изображения) кнопок. Поэкспериментируйте с оформлением кнопок и измените их название на START, STOP и COLOR:

![image](https://github.com/user-attachments/assets/03c12aeb-85b3-4205-bbb3-2ace9f75bbe5)

## Поэкспериментировал с оформлением кнопок, применил к ним спрайт, поменял цвет надписи, а также изменил содержание каждой кнопки.

![image](https://github.com/user-attachments/assets/72141fdd-cd71-4a28-ad9b-1cc1268c66e1)

2.3 Создайте объект куб на сцене и поместите его в центре экрана. Назначьте на куб компонент Rigidbody, отключите у куба гравитацию. Теперь научимся управлять свойствами куба с помощью кнопок. Создайте скрипт файл с названием CubeControl. Подключите скрипт файл к объекту куб. Скрипт будет содержит три метода StartButton() - включает гравитацию куба. StopButton() - выключает гравитацию куба, ChangeColorButton() - изменяет цвет куба на красный:

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void StartButton(){
        _rb.useGravity= true;
    }

    public void StopButton(){
        _rb.useGravity= false;
    }

    public void ChangeColorButton(){
        _rb.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
```

2.4 Чтобы методы в скрипте запускались при нажатии на кнопку, нужно поместить объект куб в событие методы OnClick и выбрать соответствующий метод, который должен запускаться по нажатию. Пример настройки кнопки Color показан ниже:

![image](https://github.com/user-attachments/assets/35c26122-8eac-4a1b-80ec-968d877b119e)

2.5 Настройте работу двух других кнопок, которые будут включать и отключать гравитацию куба.
## Настроил работу кнопок.

### Кнопка Color

![image](https://github.com/user-attachments/assets/ac62a127-b4f7-493c-b683-10bf031acca3)

### Кнопка Stop

![image](https://github.com/user-attachments/assets/6664052c-9ad2-428e-9482-1627395408e8)

### Кнопка Start

![image](https://github.com/user-attachments/assets/2cca4259-782f-48a7-931d-63aa557ae2f7)

2.6 Также вы можете включать или отключать элементы интерфейса на сцене. Создайте элемент текста в окне с надписью “You Win” и отключите его отображение (мы будем показывать его автоматически позднее):

![image](https://github.com/user-attachments/assets/788c63fb-8407-47e2-b87e-e50eb6021d10)

2.7 В скрипт файл CubeControl.cs добавьте строки кода, которые будут делать видимым тот объект, который помещен в качестве переменной. В нашем примере мы будем делать видимым сообщение с надписью “YOU WIN” при нажатии на кнопку START:

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public GameObject _go; // NEW LINE
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void StartButton(){
        _rb.useGravity= true;
        _go.SetActive(true); // NEW LINE
    }

    public void StopButton(){
        _rb.useGravity= true;
    }

    public void ChangeColorButton(){
        _rb.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
```

2.8 Подключите переменную с полем, который нужно показывать к скрипт-фалу, назначенному на куб

![image](https://github.com/user-attachments/assets/0b7c7fd2-b270-4fdd-8892-d51105a61536)

## Дописал код и назначил в переменную поле, которое нужно будет показывать.

![image](https://github.com/user-attachments/assets/b806cf30-aae5-4003-a3be-23ed9581b3df)

# Задание 3. Самостоятельная работа
3.1 На основе полученных знаний создайте игровой процесс, который будет удовлетворять следующим условиям:
●	На сцене находится три куба и три кнопки под каждым кубом с надписью Куб 1, Куб 2 и Куб 3. Надпись по центру экрана - “Guess the Cube” 
●	Нужно создать игровой процесс, в котором пользователь должен угадать какой кубик не упадет при нажатии на кнопку.
●	Пример работы: пользователь нажимает на кнопку “Куб” 1. После этого кубы 2 и 3 падает, куб 1 остается висеть в воздухе. В этом случае появляется надпись - “YOU WIN”. 
●	Вы можете создать свою версию игрового процесса. 
●	Опишите реализацию в виде короткого технического решения:

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
1)	Создал задний фон; назначил на него спрайт; установил настройки Renderer Mode - Screen Space Camera и поместил камеру в поле render Camera.
2)	Написал скрипт для работы кнопок: при нажатии на кнопку, соответствующий куб остаётся висеть (отмечается зелёным цветом), а два других начинают падать (отмечаются красный цветом); в скрипте 3 метода (для каждой кнопки).
3)	Добавил на сцену 3 куба; каждому добавил компонент Rigidbody, в котором отключил параметр Use Gravity; добавил написанный скрипт.
4)	Добавил три кнопки с надписями “Куб 1”, “Куб 2” и “Куб 3”; в событии “On click” назначил соответствующий куб для каждой кнопки; применил в качестве материала созданную текстуру, поменял цвет надписи.
5)	Добавил надпись “Change the Cube”, которая видна с самого начала сцены; добавил скрытую надпись “YOU WIN!!!!”, которая появляется после нажатия на кнопку, первая надпись, соответственно, пропадает.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Скрипт для задания 3

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptChangeCube : MonoBehaviour
{
    private Rigidbody rb1;
    private Rigidbody rb2;
    private Rigidbody rb3;
    public GameObject win;
    public GameObject task;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = cube1.GetComponent<Rigidbody>();
        rb2 = cube2.GetComponent<Rigidbody>();
        rb3 = cube3.GetComponent<Rigidbody>();
    }

    public void Button1()
    {
        rb1.useGravity = false;
        rb2.useGravity = true;
        rb3.useGravity = true;
        win.SetActive(true);
        task.SetActive(false);
        cube1.GetComponent<Renderer>().material.color = Color.green;
        cube2.GetComponent<Renderer>().material.color = Color.red;
        cube3.GetComponent<Renderer>().material.color = Color.red;
    }

    public void Button2()
    {
        rb1.useGravity = true;
        rb2.useGravity = false;
        rb3.useGravity = true;
        win.SetActive(true);
        task.SetActive(false);
        cube1.GetComponent<Renderer>().material.color = Color.red;
        cube2.GetComponent<Renderer>().material.color = Color.green;
        cube3.GetComponent<Renderer>().material.color = Color.red;
    }

    public void Button3()
    {
        rb1.useGravity = true;
        rb2.useGravity = true;
        rb3.useGravity = false;
        win.SetActive(true);
        task.SetActive(false);
        cube1.GetComponent<Renderer>().material.color = Color.red;
        cube2.GetComponent<Renderer>().material.color = Color.red;
        cube3.GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```

# Ссылка на Package файл работы:
https://disk.yandex.ru/d/QjNnWLR1btQDlg
