using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace SpaceShip4042.Class
{
    public class Sound
    {
        #region Atributes

        AudioEngine aEngine;
        WaveBank wBank;
        SoundBank sBank;
        Cue play;
        
        #endregion

        #region Constructor
        /// <summary>
        /// Construtor com caminho padrão (Sound/Sounds.xgs, Sound/wBank.xwb, Sound/sBank.xsb)
        /// </summary>
        public Sound()
        {
            aEngine = new AudioEngine(@"Sound/NatSound.xgs");
            wBank = new WaveBank(aEngine, @"Sound/wBank.xwb");
            sBank = new SoundBank(aEngine, @"Sound/sBank.xsb");
            play = null;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="AudioEngine">Audio Engine Path</param>
        /// <param name="WaveBank">Wave Bank Path</param>
        /// <param name="SoundBank">Sound Bank Path</param>
        public Sound(string AudioEngine, string WaveBank, string SoundBank)
        {
            aEngine = new AudioEngine(AudioEngine);
            wBank = new WaveBank(aEngine, WaveBank);
            sBank = new SoundBank(aEngine, SoundBank);
        }
        #endregion

        #region Update
        /// <summary>
        /// Atualiza os sons
        /// </summary>
        public void Update()
        {
            /*
             aEngine.Update();
            */
        }
        #endregion

        #region Methods
        /// <summary>
        /// Toca um som de efeito
        /// </summary>
        /// <param name="snd">Nome do som</param>
        public void PlaySound(string snd)
        {
            sBank.GetCue(snd).Play();
        }

        /// <summary>
        /// Toca uma música
        /// </summary>
        /// <param name="music">Nome da música</param>
        public void PlayMusic(string music)
        {
            play = sBank.GetCue(music);
            play.Play();
        }

        /// <summary>
        /// Para a música
        /// </summary>
        public void StopMusic()
        {
            if (play != null)
            {
                play.Stop(AudioStopOptions.Immediate);
                play.Dispose();
                play = null;
            }
        }

        /// <summary>
        /// Pausa música
        /// </summary>
        public void PauseMusic()
        {
            if (play != null)
                play.Pause();
        }

        /// <summary>
        /// Continua de onde parou
        /// </summary>
        public void ResumeMusic()
        {
            if (play != null)
                play.Resume();

        }
        #endregion
    }
}
