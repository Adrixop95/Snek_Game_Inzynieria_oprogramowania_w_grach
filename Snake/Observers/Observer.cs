using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Observers {

    /// <summary> Interfejs Obserwatora, Implementacja wzorca projektowego "Observer". </summary>
    public interface Observer {


        #region Functions
        // ######################################################################
        /// <summary> Funkcja aktualizująca. </summary>
        void Update();


        #endregion Functions
        // ######################################################################
    }

}
