using Snake.Objects;
using Snake.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Renderers {

    /// <summary> Interfejs obiektu renderer. </summary>
    public interface Renderer {
        

        #region Functions
        // ######################################################################
        /// <summary> Funkcja renderująca obraz. </summary>
        /// <param name="apple"> Obiekt jabłka. </param>
        /// <param name="map"> Mapa. </param>
        /// <param name="snake"> Obiekt węża. </param>
        void RenderGame( Apple apple, Map map, SnakeBlock snake );


        /// <summary> Funkcja aktualizująca interfejs graficzny. </summary>
        /// <param name="points"> Aktualne punkty. </param>
        void RenderInterface( int points );


        /// <summary> Funkcja renderująca scenę końca gry. </summary>
        /// <param name="isWin"> Informacja o wygranej. </param>
        /// <param name="points"> Aktualne punkty. </param>
        void RenderGameOverScreen( bool isWin, int points );


        #endregion Functions
        // ######################################################################
    }

}
