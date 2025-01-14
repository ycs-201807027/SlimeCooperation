# MultiGame
유한대학교 비즈니스 모델과 설계 프로젝트 Slime Cooperation 팀

# 소개



유한대학교 3학년 Slime Cooperation팀의 졸업 작품입니다. 
<br><br>
본 프로젝트는 Unity나 Unreal Engine등의 게임 엔진에 의존하지 않고 Windows Form만을 이용하여 게임을 만드는것을 목표로 하였습니다.
<br><br>
사용 언어 및 개발 환경은 다음과 같습니다.
* 개발 언어 : C# .NET 5.0
* 개발 환경 : Windows Form, Windows OS


![ezgif com-gif-maker (9)](https://user-images.githubusercontent.com/80028960/201518119-e406304e-2e08-4d38-a194-7bba453ce0a4.gif)

# 게임 구성
게임은 기본적으로 플레이어가 방을만들고 다른플레이어가 들어와 총 3명이서 게임준비를 누르는것으로 시작할 수 있습니다.<br>
각 맵에는 여러 오브젝트가 있어 3명의 플레이어가 협동하여 플레이하여야 합니다. 게임의 기본적인 오브젝트는 다음과 같습니다.
<br>

* **문과 열쇠**<br>
<img src="https://user-images.githubusercontent.com/80028960/206927569-00217ef2-b8c5-45dd-ae16-fd09b5742288.gif" width="70" height="90"/>  <img src="https://user-images.githubusercontent.com/80028960/206927662-55ff7c73-0ead-4fa5-bd12-25802e46120c.gif" width="60" height="100"/>

가장 중요한 오브젝트입니다. 플레이어는 열쇠를 먹어야만 문을 통해 다음스테이지로 나아갈 수 있습니다.
<br><br>

* **Stone**<br>
<img src="https://user-images.githubusercontent.com/80028960/206927057-2e01efbb-6fb6-4384-be1d-fff1aa74c109.png" width="200" height="200">

가장 기본적인 돌입니다. 적혀있는 인원수만큼 돌을 밀어야 움직일 수 있습니다.
<br><br>

* **Portal**<br>
<img src="https://user-images.githubusercontent.com/80028960/206927771-343e4922-28a1-4fdf-bc43-0b6d51069233.gif" width="100" height="100">

포탈입니다. 포탈에서 상호작용키를 이용하여 다른곳으로 이동할 수 있습니다.
<br><br>

* **Timer**<br>
![image](https://user-images.githubusercontent.com/80028960/206927859-7d8e5f9b-ae64-42c8-a9b9-2f53decdd177.png)

타이머입니다. 정해진 시간이 모두 초과시 모든 플레이어는 죽게되어 해당 스테이지를 다시 시작해야합니다.



# Preview
<img src="https://user-images.githubusercontent.com/80028960/206928559-0a92aca1-ca6e-41b9-bb3e-4790495e3cba.png" width="500" height="300">

6번맵은 버튼을 밟으면 바로 위의 타이머가 멈추게 됩니다. 모든 발판을 밟아 각 타이머의 시간 합이 위에 표시된 0초에서 0.8초 미만이여야만 클리어가 가능하도록 설계하였습니다.
<br><br>
<img src="https://user-images.githubusercontent.com/80028960/206928395-4bb2b093-64bb-49ea-9ce1-dc2fc252f399.png" width="500" height="300">
<br>
9번맵은 두명이서 버튼을 밟으면 상단부의 통나무 발판과 용암이 사라집니다. 다시 두명 모두 버튼을 떼면 사라졌던 오브젝트가 다시 등장하게 됩니다.<br>
상단에 위치한 플레이어가 첫번째 나무 발판에서 뜀과 동시에 밑에있는 플레이어는 버튼을 밟아 용암을 없애고, 용암을 지나감과 둥시에 버튼을 떼어 발판을 만들어야합니다.

## Contributors
| 담당자 |git|
| :--- | :---: |
| 이석종 | [ycs-201807006](https://github.com/ycs-201807006) |
| 이선웅 | [leeseanwoong](https://github.com/leeseanwoong) |
| 이태양 | [ycs-201807062](https://github.com/ycs-201807062) |
| 황성진 | [sbssbsissi](https://github.com/sbssbsissi) |
| 정은지 | [ycs-202007071](https://github.com/ycs-202007071) |


