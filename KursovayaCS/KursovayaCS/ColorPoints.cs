using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaCS
{
    internal class ColorPoints
    {
        public int Radius;    // радиус  
        public int PositionFirst; // координата X центра эмиттера
        public int PositionSecond; // соответствующая координата Y 
         
        public ColorPoints()  // конструктор частицы
        {     
            this.Radius = 20;          
        }
        
        public  void Rendering(Graphics g,int PositionFirst, int PositionSecond )  // метод создания частицы
        {        
            g.DrawEllipse(new Pen(Color.Green),  PositionFirst , PositionSecond , Radius * 2, Radius * 2);
        }
    }
}
