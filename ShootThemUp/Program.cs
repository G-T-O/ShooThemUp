using System;
using System.Windows.Forms;

namespace ShootThemUp
{
    /*
     * The main class who call the form and refresh it
     */
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Boolean hasLost;
            DateTime currentUpdateTime;
            DateTime lastUpdateTime;
            TimeSpan frameTime;
            currentUpdateTime = DateTime.Now;
            lastUpdateTime = DateTime.Now;
            Form1 form = new Form1();
            GameOver gameOver = new GameOver();
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.Show();

            while (form.Created == true)
            {
                currentUpdateTime = DateTime.Now;
                frameTime = currentUpdateTime - lastUpdateTime;
                if (frameTime.TotalMilliseconds > 25)
                {
                    Application.DoEvents();
                    hasLost = form.updateWorld();
                    if (!hasLost)
                    {
                        form.Refresh();
                        lastUpdateTime = DateTime.Now;
                    }
                    else
                    {
                        form.Close();
                    }
                }
            }
        }
    }
 }