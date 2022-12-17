using System.Linq.Expressions;

namespace KursovayaCS
{
    public partial class Form1 : Form
    {
        Emitter emitter = new Emitter();
        PointCounter pointCounter=new PointCounter(200, 150);
        List<Emitter> emitters = new List<Emitter>();
        List<PointCounter> pointCounters = new List<PointCounter>();
        

        public Form1()
        {
            InitializeComponent();
            pict.Image = new Bitmap(pict.Width, pict.Height);
            ColorPoints colorPoints = new ColorPoints();
        
           
            pointCounters.Add(this.pointCounter);
           
            
            
            

        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            //emitter.UpdateState();

            using (var g = Graphics.FromImage(pict.Image))
            {
                
                g.Clear(Color.White);
                foreach (Emitter emitter in emitters)
                {
                    emitter.UpdateState();
                    emitter.Render(g);                    
                    amountPart.Text=$"Количество частиц {emitter.particles.Count}";
                }
                foreach (PointCounter pointCounter in pointCounters)
                {
                   
                   // particle.IntersectionParticle(pointCounter);//--------------------------------------------------------------------------------------
                    pointCounter.Draw(g, pointCounter.PositionX, pointCounter.PositionY, 15);
                }
            }
            pict.Invalidate();
        }
        
        private void pict_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }

        //--------------------------------------------------------------------------------------
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            foreach (Emitter emitter in emitters)
            {
                emitter.SpeedMin=trackBar1.Value;
                l1.Text = $"{trackBar1.Value}";
            }            
        }
        private void tb2_Scroll(object sender, EventArgs e)
        {
            foreach (Emitter emitter in emitters)
            {
                emitter.SpeedMax= tb2.Value;
                l2.Text = $"{ tb2.Value}";
            }           
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            foreach (Emitter emitter in emitters)
            {
                emitter.ParticlesPerTick= trackBar3.Value;
                l3.Text = $"{ trackBar3.Value}";
            }            
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            foreach (Emitter emitter in emitters)
            {
                emitter.RadiusMax= trackBar4.Value;
                l4.Text = $"{ trackBar4.Value}";
            }            
        }
        //--------------------------------------------------------------------------------------

        private void pict_MouseClick(object sender, MouseEventArgs e)
        {       
            if (e.Button == MouseButtons.Left) {
               Emitter emitter = new Emitter();
               emitter.MousePositionX = e.X;
               emitter.MousePositionY = e.Y;
               emitters.Add(emitter);
            } 
            
            else if (e.Button == MouseButtons.Right) {
                using var g = Graphics.FromImage(pict.Image);
                PointCounter pointCounter = new PointCounter(e.X, e.Y);
                pointCounter.PositionX = e.X;
                pointCounter.PositionY = e.Y;
                pointCounters.Add(pointCounter);
                          
            }        
        }

        private void tbLife_Scroll(object sender, EventArgs e)
        {
            foreach (Emitter emitter in emitters)
            {
                emitter.LifeMax= tbLife.Value;               
                lLife.Text = $"{ tbLife.Value}";
            } 
        }

        private void tbDegrees_Scroll(object sender, EventArgs e)
        {
            foreach (Emitter emitter in emitters)
            {
                emitter.Direction= tbDegrees.Value;  
                emitter.Spreading= 0; 
                lDegree.Text = $"{ tbDegrees.Value}";
            } 
        }
        
       
        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }
        
    }
}