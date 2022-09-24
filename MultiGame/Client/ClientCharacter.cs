﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace MultiGame
{

    // Client 정보를 갖는 클래스
    public class ClientCharacter
    {
        // 각 클라이언트를 구별하기 위한 킷값
        public int key { get; set; }

        // 좌표
        public Point Location { get; set; }

        // 크기
        public Size size { get; set; }

        // 캐릭터 이미지
        private Image _image;
        public Image image { get { return _image; } }
        public bool bLookRight { get; set; }
        private bool FlipImage;

        public bool isVisible { get; set; }
        public bool isReady { get; set; }

        ~ClientCharacter()
        {
        }

        public ClientCharacter(int key, Point Location, int skinNum)
        {
            // 멤버변수 초기
            this.key = key;

            this.Location = Location;
            size = new Size(60, 50);
            isVisible = false;
            isReady = false;
             
            // 이미지 관련
            bLookRight = true;
            FlipImage = false;
            SetSkin(skinNum);
        }

        public void SetSkin(int skinNum)
        {
            switch (skinNum % 8)
            {
                case 0:
                    _image = MultiGame.Properties.Resources.red.Clone() as Image;
                    break;
                case 1:
                    _image = MultiGame.Properties.Resources.orange.Clone() as Image;
                    break;
                case 2:
                    _image = MultiGame.Properties.Resources.yellow.Clone() as Image;
                    break;
                case 3:
                    _image = MultiGame.Properties.Resources.green.Clone() as Image;
                    break;
                case 4:
                    _image = MultiGame.Properties.Resources.blue.Clone() as Image;
                    break;
                case 5:
                    _image = MultiGame.Properties.Resources.purple.Clone() as Image;
                    break;
                case 6:
                    _image = MultiGame.Properties.Resources.pink.Clone() as Image;
                    break;
                case 7:
                    _image = MultiGame.Properties.Resources.gray.Clone() as Image;
                    break;
            }
        }
        public void GameStart()
        {
        }


        public void OnPaint(Object obj, PaintEventArgs pe)
        {
            if (isVisible == false) return;

             var e = pe.Graphics;
            if(FlipImage)
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                FlipImage = false;
            }
            e.DrawImage(image,new Rectangle(Location, size ));
            
        }

        public void SetLookDirection(bool bRight)
        {
            if (bRight != this.bLookRight)
            {
                FlipImage = true;
                this.bLookRight = bRight;
            }
        }


    }
}
