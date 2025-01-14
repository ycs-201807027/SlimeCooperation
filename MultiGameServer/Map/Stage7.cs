using MultiGameModule;
using MultiGameServer.Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiGameServer
{
    class Stage7 : MapBase
    {
        private List<int> randomSkin;
        private TimerBox timerbox1;

        private List<GameObject> hiddenPlatform = new List<GameObject>();
        public Stage7(Room room) : base(room)
        {
            _skin = 2;
        }

        public override void Start()
        {
            base.Start();

            timerbox1.TimerStart();

            // 발판 숨기기
            foreach (var obj in hiddenPlatform)
            {
                MessageGenerator generator = new MessageGenerator(Protocols.S_OBJECT_EVENT);
                generator.AddInt(obj.key);
                generator.AddByte(ObjectTypes.GAME_OBJECT);
                generator.AddInt(-1);
                generator.AddBool(false);
                generator.AddBool(false).AddBool(false);

                room.SendMessageToAll_InRoom(generator.Generate());
            }

        }

        protected override void SetSpawnLocation() // 플레이어 시작 좌표
        {
            SpawnLocation[0] = new Point(0, 740);
            SpawnLocation[1] = new Point(100, 740);
            SpawnLocation[2] = new Point(200, 740);
        }

        protected override void DesignMap()
        {
            InitRandomSkin();
            int tempKey;

            // 맵 바깥 벽 (왼)
            tempKey = room.NextObjKey;
            Floor leftWall = new Floor(room, tempKey, new Point(-11, 0), new Size(10, 865));
            leftWall.SkinNum = -1;
            objectManager.AddObject(leftWall);

            // 맵 바깥 벽 (우)
            tempKey = room.NextObjKey;
            Floor rightWall = new Floor(room, tempKey, new Point(1424, 0), new Size(10, 865));
            rightWall.SkinNum = -1;
            objectManager.AddObject(rightWall);

            // 맵 바깥 벽(아래) 라바
            tempKey = room.NextObjKey;
            Lava lava1 = new Lava(room, tempKey, new Point(0, 850), new Size(1440, 50));
            objectManager.AddObject(lava1);


            // 땅
            tempKey = room.NextObjKey;
            Floor Floor = new Floor(room, tempKey, new Point(0, 800), new Point(300, 865));
            Floor.SkinNum = 2;
            objectManager.AddObject(Floor);

            // 땅
            tempKey = room.NextObjKey;
            Floor Floor1 = new Floor(room, tempKey, new Point(403, 800), new Point(895, 865));
            Floor1.SkinNum = 2;
            objectManager.AddObject(Floor1);

            // 문을 막는 긴 땅
            tempKey = room.NextObjKey;
            Floor Floor2 = new Floor(room, tempKey, new Point(1285, 230), new Point(1325, 800));
            Floor2.SkinNum = 2;
            objectManager.AddObject(Floor2);

            // 문 땅
            tempKey = room.NextObjKey;
            Floor Floor10 = new Floor(room, tempKey, new Point(1285, 800), new Point(1440, 865));
            Floor10.SkinNum = 2;
            objectManager.AddObject(Floor10);

            // 문
            tempKey = room.NextObjKey;
            Door door = new Door(room, tempKey, new Point(1350, 710), new Size(70, 90));
            objectManager.AddObject(door);


            // 벽
            tempKey = room.NextObjKey;
            Platform platform1 = new Platform(room, tempKey, new Point(70, 690), new Size(30, 30));
            platform1.SkinNum = 5;
            objectManager.AddObject(platform1);

            tempKey = room.NextObjKey;
            Platform platform2 = new Platform(room, tempKey, new Point(165, 622), new Size(30, 30));
            platform2.SkinNum = 5;
            objectManager.AddObject(platform2);

            tempKey = room.NextObjKey;
            Platform platform3 = new Platform(room, tempKey, new Point(70, 554), new Size(30, 30));
            platform3.SkinNum = 5;
            objectManager.AddObject(platform3);

            tempKey = room.NextObjKey;
            Platform platform4 = new Platform(room, tempKey, new Point(165, 486), new Size(30, 30));
            platform4.SkinNum = 5;
            objectManager.AddObject(platform4);

            tempKey = room.NextObjKey;
            Platform platform5 = new Platform(room, tempKey, new Point(70, 418), new Size(30, 30));
            platform5.SkinNum = 5;
            objectManager.AddObject(platform5);

            tempKey = room.NextObjKey;
            Platform platform6 = new Platform(room, tempKey, new Point(165, 350), new Size(30, 30));
            platform6.SkinNum = 5;
            objectManager.AddObject(platform6);

            tempKey = room.NextObjKey;
            Platform platform7 = new Platform(room, tempKey, new Point(70, 282), new Size(30, 30));
            platform7.SkinNum = 5;
            objectManager.AddObject(platform7);

            tempKey = room.NextObjKey;
            Platform platform8 = new Platform(room, tempKey, new Point(165, 214), new Size(30, 30));
            platform8.SkinNum = 5;
            objectManager.AddObject(platform8);


            // 중앙 숨겨진 플랫폼
            tempKey = room.NextObjKey;
            Platform platform10 = new Platform(room, tempKey, new Point(490, 418), new Size(125, 30));
            objectManager.AddObject(platform10);
            hiddenPlatform.Add(platform10);

            // 중앙 숨겨진 플랫폼
            tempKey = room.NextObjKey;
            Platform platform11 = new Platform(room, tempKey, new Point(490, 350), new Size(125, 30));
            objectManager.AddObject(platform11);
            hiddenPlatform.Add(platform11);

            // 맨위 돌 있는 땅
            tempKey = room.NextObjKey;
            Floor Floor3 = new Floor(room, tempKey, new Point(225, 165), new Point(688, 230));
            Floor3.SkinNum = 2;
            objectManager.AddObject(Floor3);

            // 맨위 기둥 옆 땅
            tempKey = room.NextObjKey;
            Floor Floor8 = new Floor(room, tempKey, new Point(760, 165), new Point(895, 230));
            Floor8.SkinNum = 2;
            objectManager.AddObject(Floor8);

            // 중앙 기둥
            tempKey = room.NextObjKey;
            Floor Floor4 = new Floor(room, tempKey, new Point(688, 165), new Point(760, 551));
            Floor4.SkinNum = 2;
            objectManager.AddObject(Floor4);

            // 중앙 돌 있는 땅
            tempKey = room.NextObjKey;
            Floor Floor5 = new Floor(room, tempKey, new Point(370, 486), new Point(688, 551));
            Floor5.SkinNum = 2;
            objectManager.AddObject(Floor5);



            // 버튼 있는 돌 ( 가운데 )
            tempKey = room.NextObjKey;
            Floor Floor6 = new Floor(room, tempKey, new Point(623, 300), new Point(688, 350));
            Floor6.SkinNum = 2;
            objectManager.AddObject(Floor6);

            // 버튼 ( 가운데 )
            tempKey = room.NextObjKey;
            Button button = new Button(room, tempKey, new Point(645,290), new Size(20, 10));
            button.SkinNum = randomSkin[2] + 1;
            button.SetAction(delegate() {

                MessageGenerator generator = new MessageGenerator(Protocols.S_OBJECT_EVENT);
                generator.AddInt(Floor2.key);
                generator.AddByte(ObjectTypes.GAME_OBJECT);
                generator.AddInt(-1);
                generator.AddBool(false);
                generator.AddBool(false).AddBool(false);

                room.SendMessageToAll_InRoom(generator.Generate());
            });
            objectManager.AddObject(button);


            // 돌1   중앙
            tempKey = room.NextObjKey;
            ColorStone stone1 = new ColorStone(room, tempKey, new Point(490, 400), new Size(100, 49));
            stone1.SkinNum = randomSkin[0];
            objectManager.AddObject(stone1);

            // 돌2   맨위
            tempKey = room.NextObjKey;
            ColorStone stone2 = new ColorStone(room, tempKey, new Point(500, 99), new Size(100, 49));
            stone2.SkinNum = randomSkin[1];
            objectManager.AddObject(stone2);

            // 돌3   맨밑
            tempKey = room.NextObjKey;
            ColorStone stone3 = new ColorStone(room, tempKey, new Point(700, 736), new Size(40, 49));
            stone3.SkinNum = randomSkin[2];
            objectManager.AddObject(stone3);


            // 우측 상단 띄어있는땅
            tempKey = room.NextObjKey;
            Floor Floor9 = new Floor(room, tempKey, new Point(998, 165), new Point(1097, 230));
            Floor9.SkinNum = 2;
            objectManager.AddObject(Floor9);

            // 우측 상단 띄어있는 낮은 땅
            tempKey = room.NextObjKey;
            Floor Floor12 = new Floor(room, tempKey, new Point(1097, 190), new Point(1245, 230));
            Floor12.SkinNum = 2;
            objectManager.AddObject(Floor12);

            // 우측 버튼있는 땅
            tempKey = room.NextObjKey;
            Floor Floor11 = new Floor(room, tempKey, new Point(1220, 97), new Point(1440, 230));
            Floor11.SkinNum = 2;
            objectManager.AddObject(Floor11);

            

            // 버튼 ( 오른쪽 )
            tempKey = room.NextObjKey;
            PressingButton button2 = new PressingButton(room, tempKey, new Point(1332, 90), new Size(20, 10));
            button2.SkinNum = randomSkin[1] + 1;
            button2.SetAction(delegate (bool bPressed)
            {
                if (bPressed)
                {
                    foreach (var obj in hiddenPlatform)
                    {
                        MessageGenerator generator = new MessageGenerator(Protocols.S_OBJECT_EVENT);
                        generator.AddInt(obj.key);
                        generator.AddByte(ObjectTypes.GAME_OBJECT);
                        generator.AddInt(-1);
                        generator.AddBool(true);
                        generator.AddBool(true).AddBool(true);

                        room.SendMessageToAll_InRoom(generator.Generate());
                    }
                }
                else
                {
                    foreach (var obj in hiddenPlatform)
                    {
                        MessageGenerator generator = new MessageGenerator(Protocols.S_OBJECT_EVENT);
                        generator.AddInt(obj.key);
                        generator.AddByte(ObjectTypes.GAME_OBJECT);
                        generator.AddInt(-1);
                        generator.AddBool(false);
                        generator.AddBool(false).AddBool(false);

                        room.SendMessageToAll_InRoom(generator.Generate());
                    }
                }
            });
            objectManager.AddObject(button2);


            // 열쇠
            tempKey = room.NextObjKey;
            KeyObject KeyObject = new KeyObject(room, tempKey, new Point(1240, 480), new Size(35, 50));
            objectManager.AddObject(KeyObject);

            //타이머
            tempKey = room.NextObjKey;
            TimerBox timerBox = new TimerBox(room, tempKey, new Point(650, 0), new Size(150, 50));
            timerBox.StartTime = 60000;
            this.timerbox1 = timerBox;
            timerBox.SetTimerStopAction(delegate () { room.AllDie(); });
            objectManager.AddObject(timerBox);



        }

        private void InitRandomSkin()
        {
            randomSkin = new List<int>(new int[] { 0, 0, 0 });

            List<int> skinArr = new List<int>();
            int i = 0;
            foreach (var item in room.roomClientDic)
            {
                skinArr.Add(item.Value.SkinNum);
                i++;
            }

            Random rand = new Random(); //랜덤선언

            for (int j = 0; j < 2; j++)
            {
                //선언 및 초기화 부분//
                int num = rand.Next(skinArr.Count);

                randomSkin[j] = skinArr[num];

                if (skinArr.Count > 1)
                    skinArr.RemoveAt(num);
            }
            randomSkin[2] = skinArr[0];

        }
    }
}