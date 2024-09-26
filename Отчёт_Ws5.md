# Работа 5 - Разработка простой игровой механики
Отчет по лабораторной работе #5 выполнил(а):
- Есипенко Игорь Ярославович
- РИ-320936
- АТ-09
# Цель работы: создать простую игровую механику на движке Unity, изучить принципы создания интерактива и подключения игровых объектов к сценариям, написанным на языке C#

# Задания к работе
# Задание 1 Создание игрового объекта и управление им с помощью мыши и клавиатуры
1.1 Создайте сцену, которая состоит из игрового объекта в виде примитива, символизирующего летающий шатл. Элементы шатла сделайте вложенными в один основной объект в окне иерархии. Игровая поверхность будет иметь размеры 50х50 метров. Внешний вид шатла можете придумать самостоятельно, он может отличаться от того, который изображен в качестве примера ниже:

![image](https://github.com/user-attachments/assets/4ae785ee-d7e7-414b-8a9e-ec0c35ab0ff2)

## Создал подобие летающего шатла из примитива

![image](https://github.com/user-attachments/assets/af02116b-c4a6-40b5-892b-a1d8aa64cd68)

1.2 Создайте не менее трёх дополнительных визуальных элементов на сцене. Например, вы можете создать сцены на границе локации и/или skybox - материал текстур внешнего окружения. Можете добавить и настроить дополнительные объекты на сцене со свойства материала коллайдера. Например, на стены можно назначить материал с большим значением Bounce и т.д. Опишите, какие объекты вы создали дополнительно:

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Дополнительно на сцене создал стены лабиринта и добавил на них материал коллайдера (со следующими параметрами: Dynamic Friction = 0, Static Friction = 0, Bounciness = 1, Friction Combine = Average, Bounce Combine = Maximum); добавил корабль, приведённый в качестве примера выше; а также сделал космонавтика, который стоит на одной из стен лабиринта.

## Стены лабиринта и настройки их материала

![image](https://github.com/user-attachments/assets/b18488f8-6125-4e14-b70c-7107bef2ca24)
![image](https://github.com/user-attachments/assets/4b305f2a-8ef3-4239-9d9e-739055fbfa9e)

## Кораблик из самого начала лабораторной работы

![image](https://github.com/user-attachments/assets/4931d62d-d8f0-4312-8b32-e910cb1f584b)

## Космонавт

![image](https://github.com/user-attachments/assets/b7e58f83-c2ef-4ad2-80d6-ccfbe20fb2ae)

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

1.3 Создайте скрипт-файл Moveaircraft.cs для управления шатлом:

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAircraft : MonoBehaviour
{
    private Rigidbody Rigidbodyrb;
    public float Speed = 5.0f; // Aircraft speed
    public float RotationSpeed = 1.0f; // Aircraft rotation speed

    void Start()
    {
        Rigidbodyrb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * RotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * Speed;

        Rigidbodyrb.AddRelativeForce(0f, 0f, forwardForce);
        Rigidbodyrb.AddRelativeTorque(0f, sideForce, 0f);
    }
}

```

1.4 Подключите скрипт-файл к шатлу и сделайте камеру дочерней для объекта шатл так, чтобы при движении камера следовала за ним. При необходимости настройте положение камеры так, чтобы игрок мог комфортно воспринимать окружение:

![image](https://github.com/user-attachments/assets/f17d9c54-f3bf-40fe-9826-3cdd20f42500)

1.4 Скрипт для управления MoveAircraft.cs достаточно прост, но не обеспечивает должной стабильности. Попробуйте решить эту проблему одним из предложенных способов или придумайте свой способ решения проблемы:
●	Попробуйте в скрипт управления добавить условие, не позволяющее шатлу взлетать вверх.
●	Также вы можете включить гравитацию объекта и создать материал с высоким трением земли, тогда можно создать эффект скольжения по поверхности земли.
●	В качестве примера попробуйте подключить скрипт из Приложения А, AircraftController.cs, который обеспечивает более стабильную работу и учитывает множество факторов управления. Ниже приведен вариант корректно настроенных переменных. Гравитация объекта управления должна быть включена в свойствах компонента Rigidbody. Управление происходит стрелками либо WSAD и мышью:

![image](https://github.com/user-attachments/assets/c1122771-0c76-4d11-8125-d0e3d8de93ed)

## Подключил скрипт Moveaircraft и избавил шаттл от взлёта с помощью фиксации позиции по координате Y, правда, это не даёт возможности включить гравитацию у объекта (потому что раз позиция по высоте фиксируется, то не играет роли, включена гравитация или нет – объект всё равно не падает), поэтому приходится ручками отключать фиксацию положения, чтобы шаттл упал, а потом снова включать фиксацию положения по высоте. На коллайдер платформы земли добавил материал, чтобы была возможность скользить по ней.

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveaircraft : MonoBehaviour
{
    private Rigidbody Rigidbody;
    public float Speed = 5.0f; // Aircraft speed
    public float RotationSpeed = 1.0f; //Aircraft rotation
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * RotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * Speed;

        Rigidbody.AddRelativeForce(0f, 0f, forwardForce);
        Rigidbody.AddRelativeTorque(0f, sideForce, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```

# Задание 2 Реализация стрельбы объекта
2.1 Создайте префаб пули. Префаб - это шаблон объекта, который неоднократно используется на сцене. Например, многократно создаётся на сцене при нажатии на кнопку мыши:
●	Создайте сферу. Операция Create Sphere в окне иерархии. Установите Scale: 0.2, переименуйте сферу в Bullet, назначьте материал, например, жёлтого цвета
●	Добавьте Bullet компонент Rigidbody, отключите для пули значение UseGravity
●	Создадим из пули префаб, перетаскиванием из окна Hierarchy в окно Project

![image](https://github.com/user-attachments/assets/7633cdd9-fd8d-49f5-92c0-d341f09b924b)

## Создал сферу, а также добавил пустые объекты и разместил их в тех местах, откуда будут вылетать снаряды.

![image](https://github.com/user-attachments/assets/3c403888-144a-4af6-892a-6a5948d8cf09)

2.2 В точке предположительного места вылета пули из шатла создайте пустой игровой объект Empty GameObject, который позднее будет играть роль точки спауна пуль. Назовите объект SpownPoint. Сделайте его дочерним для объекта Aircraft. Подключите к объекту скрипт-файл BulletSpawner.cs (на следующем шаге мы напишем в этот скрипт файл условия генерации префабов с пулями).
2.3 Добавьте условие генерации пуль при нажатии на левую кнопку мыши в содержимое скрипт-файла BulletSpawner.cs

```C#
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletVelocity = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(
                BulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity =
                transform.forward * BulletVelocity;
        }
    }
}
```
2.4 Подключите скрипт-файл, как показано в примере ниже:

![image](https://github.com/user-attachments/assets/4283f30e-5868-47f6-b564-a45c18b4255c)

## Создал скрипт и подключил его к двум пустым объектам.

![image](https://github.com/user-attachments/assets/be816705-3e63-40fa-a86d-1a3690095efb)
![image](https://github.com/user-attachments/assets/20c5c12d-d49d-4b57-a44a-72313784d86e)

# Задание 3 Самостоятельная работа
3.1 Создайте на сцене больше интерактивных элементов, платформ и разрушаемых элементов из примитивов. Текстуры используются на ваше усмотрение. См. примеры дизайна уровней в приложении Б:

![image](https://github.com/user-attachments/assets/bda6b883-37fd-4572-82ac-265d80116bc2)

## Создал больше интерактивных элементов на сцене по примерам выше. Во всех элементах используется компонент Rigidbody, но к сфере на 2 изображении был применён материал коллайдера, с помощью которого сфера может отскакивать от куба (небольшой интерактив – сбить сферу, пока она отскакивает от куба, куб и цилиндр зафиксированы в пространстве и не будут изменять положение от попадания в них).

## Стена из кубов

![image](https://github.com/user-attachments/assets/82f2dede-16f4-45c9-81a2-bfa746de52c2)

## Дженга и прыгающая сфера с настройками материала коллайдера

![image](https://github.com/user-attachments/assets/fab05b30-63ca-49b9-abb5-bf61077cec2c)
![image](https://github.com/user-attachments/assets/57f44d5a-2eb4-4383-951a-b51850e04d45)

3.2 Чтобы закрепить понимание того, как объекты и C#-скрипты на сцене взаимодействуют между собой создайте UML-диаграммы описывающие взаимодействие между игровыми объектами на сцене и скрипт-файлами, которые вы создали в этой работе:

-----------------------------------------------------------------------------------------
## UML-диаграмма скрипта BulletSpawn для появления сфер-снарядов.

![image](https://github.com/user-attachments/assets/d7aea6c1-f93b-49fe-92d6-c067858f166b)

## UML-диагрмма скрипта MoveAircraft для передвижения шаттла.

![image](https://github.com/user-attachments/assets/e7609b9d-7125-4ad7-83ed-f818eab38d41)

## UML-диаграмма скрипта AircraftController для лучшего передвижения шаттла.

![image](https://github.com/user-attachments/assets/cf4d0c44-4be3-426d-a6b5-b0ec1d51392b)

-----------------------------------------------------------------------------------------

# Ссылка на Package файл работы:
https://disk.yandex.ru/d/59OastlZe3OYeQ

# ПРИЛОЖЕНИЕ А
## скрипт AircraftController.cs

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftController : MonoBehaviour
{
    private bool canJump = true;
    public float jumpCooldown = 2.0f;

    public float speed = 3.0f;
    public float maxSpeed = 6.0f;
    public float rotationSpeed = 360.0f;
    public float jumpForce = 1.0f;
    public float gravity = 9.8f;
    public float hoverHeight = 2.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // Получаем ввод от клавиатуры
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Получаем ввод от мыши
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);

        // Применяем силу для перемещения в горизонтальной и вертикальной плоскостях
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddRelativeForce(movement * speed);

        // Ограничение скорости
        Vector3 clampedVelocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        rb.velocity = clampedVelocity;

        // Подпрыгивание при нажатии клавиши пробел
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(EnableJump());
        }


        float distanceToGround = hoverHeight;
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit, hoverHeight))
        {
            distanceToGround = hit.distance;
        }

        float verticalVelocity = rb.velocity.y;


        float adjustment = Mathf.Clamp((hoverHeight - distanceToGround) * 0.3f, 0, 1) * jumpForce;
        rb.AddRelativeForce(Vector3.up * adjustment, ForceMode.Impulse);
    }

    IEnumerator EnableJump()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}
```

# ПРИЛОЖЕНИЕ Б

![image](https://github.com/user-attachments/assets/018d93b6-8403-420e-b09c-18f5f6894da7)

![image](https://github.com/user-attachments/assets/0bceed7b-1887-43f8-80b7-faf26dafeab0)

![image](https://github.com/user-attachments/assets/21e9b9d4-cdbc-4fc5-84a5-797a54fb2a18)
