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
    class Stage9 : MapBase
    {

        private bool Button1Pressed = false;
        private bool Button2Pressed = false;
        private List<GameObject> actionObjList = new List<GameObject>();
        public Stage9(Room room) : base(room)
        {
            _skin = 2;
        }

        protected override void SetSpawnLocation()
        {
            List<int> list = new List<int>() {0,1,2 };
            var rnd = new Random();
            var randomized = list.OrderBy(item => rnd.Next());

            
            int a = 0;
            foreach (var value in randomized)
            {
                list[value] = a++;
            }

            SpawnLocation[list[0]] = new Point(332, 67);
            SpawnLocation[list[1]] = new Point(570, 740);
            SpawnLocation[list[2]] = new Point(810, 740);
        }

        protected override void DesignMap()
        {
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
            Lava lava = new Lava(room, tempKey, new Point(0, 850), new Size(1440, 50));
            objectManager.AddObject(lava);

            // 땅
            tempKey = room.NextObjKey;
            Floor Floor = new Floor(room, tempKey, new Point(400, 800), new Point(1040, 865));
            Floor.SkinNum = 2;
            objectManager.AddObject(Floor);

            // 포탈
            tempKey = room.NextObjKey;
            Portal portal1 = new Portal(room, tempKey, new Point(1320, 93), new Size(120, 120));
            portal1.TargetLocation = new Point(690, 650);
            objectManager.AddObject(portal1);





            // 왼쪽위 벽
            tempKey = room.NextObjKey;
            Floor floor8 = new Floor(room, tempKey, new Point(0, 150), new Size(400, 100));
            floor8.SkinNum = 2;
            objectManager.AddObject(floor8);

            // 열쇠
            tempKey = room.NextObjKey;
            KeyObject KeyObject = new KeyObject(room, tempKey, new Point(1250, 150), new Size(35, 50));
            objectManager.AddObject(KeyObject);

            // 천장
            tempKey = room.NextObjKey;
            Floor Floor13 = new Floor(room, tempKey, new Point(0, -35), new Size(1440, 30));
            objectManager.AddObject(Floor13);

            // 벽6
            tempKey = room.NextObjKey;
            Platform platform11 = new Platform(room, tempKey, new Point(610, 236), new Size(125, 30));
            objectManager.AddObject(platform11);

            // 벽7
            tempKey = room.NextObjKey;
            Platform platform12 = new Platform(room, tempKey, new Point(905, 236), new Size(125, 30));
            objectManager.AddObject(platform12);

            // 열쇠 발판
            tempKey = room.NextObjKey;
            Floor floor13 = new Floor(room, tempKey, new Point(1195, 210), new Size(235, 50));
            floor13.SkinNum = 2;
            objectManager.AddObject(floor13);

            tempKey = room.NextObjKey;
            PressingButton button1 = new PressingButton(room, tempKey, new Point(450, 790), new Size(20, 10));
            button1.SetAction(delegate (bool bPressed) {
                Button1Pressed = bPressed;
                MapAction();
            });
            objectManager.AddObject(button1);

            tempKey = room.NextObjKey;
            PressingButton button2 = new PressingButton(room, tempKey, new Point(970, 790), new Size(20, 10));
            button2.SetAction(delegate (bool bPressed) {
                Button2Pressed = bPressed;
                MapAction();
            });
            objectManager.AddObject(button2);


            
            // 긴 용암
            tempKey = room.NextObjKey;
            Lava lava1 = new Lava(room, tempKey, new Point(0, 335), new Size(1440, 65));
            objectManager.AddObject(lava1);

            
            // 떨어지는 용암
            tempKey = room.NextObjKey;
            Lava lava2 = new Lava(room, tempKey, new Point(800, 0), new Size(35, 350));
            lava2.SkinNum = 1;
            objectManager.AddObject(lava2);
            

            // 벽14
            tempKey = room.NextObjKey;
            Floor floor14 = new Floor(room, tempKey, new Point(0, 370), new Size(1440, 40));
            floor14.SkinNum = 2;
            objectManager.AddObject(floor14);

            // 문
            tempKey = room.NextObjKey;
            Door door = new Door(room, tempKey, new Point(685, 710), new Size(70, 90));
            objectManager.AddObject(door);


            actionObjList.Add(platform11);
            actionObjList.Add(platform12);
            actionObjList.Add(lava2);
        }

        // 두개의 버튼을 동시에 누를때만 사라짐
        public void MapAction()
        {
            if (Button1Pressed && Button2Pressed)
            {
                foreach (var obj in actionObjList)
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
            else if(!Button1Pressed && !Button2Pressed)
            {
                foreach (var obj in actionObjList)
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
        }


    }
}
