using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaCS
{
    internal class PointCounter
    {
          
        public int Radius;    // радиус  
        public float PositionX; // координата X 
        public float PositionY; // соответствующая координата Y 
        public double R;
            
        public PointCounter(float PositionX, float PositionY)  // конструктор частицы
        {  
            this.Radius = 10;
            this.PositionX= PositionX;
            this.PositionY= PositionY;
        }
        
      
        public void IntersectionParticle(Particle particle)
        {
            float gX = this.PositionX - particle.X;
            float gY = this.PositionY - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            R=gX;
            if (r <this.Radius+particle.Radius) // если частица оказалось внутри окружности
            {
                particle.Life=0;
            }
        }

       

        public virtual void Draw(Graphics g, float PositionX, float PositionY, int Radius)  // метод создания частицы
        {            
            
            var a = new Pen(Color.Blue);
            g.DrawEllipse(a, PositionX, PositionY, Radius * 2, Radius * 2);
            g.DrawString(
                $"Я {R}", // надпись, можно перенос строки вставлять (если вы Катя, то может не работать и надо использовать \r\n)
                new Font("Verdana", 10), // шрифт и его размер
                new SolidBrush(Color.Black), // цвет шрифта
                PositionX, // расположение в пространстве
                PositionY
            );
        }

        
       
    }
}
