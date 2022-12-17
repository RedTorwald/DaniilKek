using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaCS
{
    internal class Particle
    {
        public static Random rand = new Random();
        public float Life, X, Y;       
        public int Radius; // радиус частицы             
        public float SpeedX, SpeedY;    
        
        public Color FromColor=Color.Crimson;
        public Color ToColor=Color.DarkSeaGreen;

        

        public Particle()  // конструктор частицы
        {            
            var direction=(double)rand.Next(360);
            var speed=1+rand.Next(10);
    
            //вектор скорости
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed); // скорость по X
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed); // скорость по Y
                      
        
            Radius = 2 + rand.Next(10); //Рандомный радиус
            Life =0+ rand.Next(100); //Рандомная длительность жизни частицы
        }

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }
        
        public virtual void Draw(Graphics g)  // метод создания частицы
        {
            //затухание
            float k = Math.Min(1f, Life / 100);           
            int alpha = (int)(k * 255);            
            var color = MixColor(ToColor, FromColor, k);            
            var b = new SolidBrush(color); 
        
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2); 
            b.Dispose(); //очитска сборщиком мусора
        }

        //------------------------------------------------------------------------------------------------------------------
        /*
        public void IntersectionParticle(PointCounter pointCounter, Particle particle)
        {
            float gX =particle.Radius - pointCounter.PositionX;
            float gY =particle.Radius - pointCounter.PositionY;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы

            if (r < pointCounter.Radius) // если частица оказалось внутри окружности
            {
                particle.Life=0;                
            }
        }*/


    }
}
