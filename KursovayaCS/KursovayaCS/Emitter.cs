using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaCS
{
    internal class Emitter
    {
        public List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();


        public List<PointCounter> counters = new List<PointCounter>();



        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах 
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы          --------------------------------- taskBar
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы        --------------------------------- taskBar
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы                            --------------------------------- taskBar


        public int LifeMin = 0; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы              
        
        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 1; 
        
        
        public int ParticlesPerTick = 1;                                                  // --------------------------------- taskBar

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        public int amountParticles=0;
        

        public virtual void ResetParticle(Particle particle)  //создание частицы
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;

            var direction = Direction 
                + (double)Particle.rand.Next(Spreading) 
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }
        

        public virtual Particle CreateParticle()
        {
            var particle = new Particle();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;
            return particle;
        }

        public void UpdateState()
        {   
            amountParticles+=particles.Count();
            int particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик
            
            foreach (var particle in particles)
            { 
        /*
                foreach (var point in impactPoints)//-------------------------------------------------------------------------------------
                {
                    point.ImpactParticle(particle);
                }*/


                foreach (var point in counters)//-------------------------------------------------------------------------------------
                {
                    point.IntersectionParticle(particle);
                }

               



                if (particle.Life <= 0) // если частицы умерла
                {
                    /* 
                     * то проверяем надо ли создать частицу
                     */   
                    if (particlesToCreate > 0) 
                    {
                        /* у нас как сброс частицы равносилен созданию частицы */
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }  
                else
                {     
                    // это не трогаем
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;                    
                }
            }
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1; 
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle); 
                
            }    
            
        }
        
        public virtual void Render(Graphics g) // метод Render
        { 
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }            
        }
        

    }
}
