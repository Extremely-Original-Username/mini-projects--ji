using AutomataVideoGenerator.Automatons;
using System.Drawing;

GameOfLife GOL = new GameOfLife(100, 100);

for(int i = 0;i < 100; i++)
{
    GOL.update();
    Directory.CreateDirectory("results");
    GOL.getImage(1).Save("results/result" + i + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
}