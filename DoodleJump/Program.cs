using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace SFMLtest
{
    struct point
    {
        public float x, y;
    };

    class Program
    {
        static void Main()
        {
            RenderWindow app = new RenderWindow(new VideoMode(400, 533), "Doodle Jump");
            app.SetFramerateLimit(60);

            Texture t1, t2, t3;
            t1 = new Texture("C:/Users/Gejmer/Documents/Visual Studio 2017/Projects/DoodleJump/DoodleJump/images/background.png");
            t2 = new Texture("C:/Users/Gejmer/Documents/Visual Studio 2017/Projects/DoodleJump/DoodleJump/images/platform.png");
            t3 = new Texture("C:/Users/Gejmer/Documents/Visual Studio 2017/Projects/DoodleJump/DoodleJump/images/doodle.png");

            Sprite sBackground = new Sprite(t1), sPlat = new Sprite(t2), sPers = new Sprite(t3);

            point[] plat = new point[20];
            Random random = new Random();

            for(int i = 0; i < plat.Length; i++)
            {
                plat[i] = new point();
            }

            for (int i = 0; i < 10; i++)
            {
                plat[i].x = random.Next() % 400;
                plat[i].y = random.Next() % 533;
            }

            float x = 100, y = 100, h = 200;
            float dx = 0, dy = 0;

            while (app.IsOpen)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    x += 3;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    x -= 3;
                }

                dy += 0.2f;
                y += dy;
                if (y > 500) dy = -10;

                if (y < h)
                    for (int i = 0; i < 10; i++)
                    {
                        y = h;
                        plat[i].y = plat[i].y - dy;
                        if (plat[i].y > 533) { plat[i].y = 0; plat[i].x = random.Next() % 400; }
                    }

                for (int i = 0; i < 10; i++)
                    if ((x + 50 > plat[i].x) && (x + 20 < plat[i].x + 68)
                        && (y + 70 > plat[i].y) && (y + 70 < plat[i].y + 14) && (dy > 0)) dy = -10;

                sPers.Position = new Vector2f(x, y);

                app.Clear();
                app.Draw(sBackground);
                app.Draw(sPers);
                for (int i = 0; i < 10; i++)
                {
                    sPlat.Position = new Vector2f(plat[i].x, plat[i].y);
                    app.Draw(sPlat);
                }

                app.Display();
            }
        }
    }
}
