using System.Media;
using System.Windows;
namespace WindowsFormsApp1
    /*
     * Class sound who will play background sound / shoot sound / damage receive
     * the class SoundPlayer can produce 2 songs at the same time even in a thread 
     */
{
    class Sound
    {
        private SoundPlayer player = new SoundPlayer();
        public  Sound()
        {

        }

        public void backGroundSound()
        {
           
            player.SoundLocation = ("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Sounds/onePieceBackground.wav");
            player.Play();
        }
       /* public void soundShoot()
        {
            player.SoundLocation = ("C:/Users/axetel/source/repos/ShootThemUp/ShootThemUp/Sounds/fireballSound.wav");
            player.Play();
        }*/
    }
}
