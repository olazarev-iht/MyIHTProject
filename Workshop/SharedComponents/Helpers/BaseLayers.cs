using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SharedComponents.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class BaseLayers
    {
        public enum DoAnimation
        {
            Default,
            Open,
            Close,
            FastAnimation
        }

        //protected MainWindow mainWnd = null;
        protected MainWndHelper mainWndHlp = null;
        protected double transXmultiplier = 1.0; //  1.0 -> nach links  Collapsed, nach rechts Visible
                                                 // -1.0 -> nach rechts Collapsed, nach links  Visible
        protected double accelerationRatio = 0;
        protected double decelerationRatio = 0;
        protected double animationTime_ms = 500;

        /// <summary>
        /// 
        /// </summary>
        public BaseLayers(MainWndHelper _mainWndHlp)
        {
            mainWndHlp = _mainWndHlp;
            //mainWnd = mainWndHlp.mainWnd;
        }

        abstract public void Init();
        abstract protected double GetToValue();

        /// <summary>
        /// 
        /// </summary>
        //public void OpenAnimation(Grid grid, TranslateTransform trans, EventHandler eventHandler)
        //{
        //    // Das Layer um die Breite nach links verschieben
        //    trans.X = grid.Width * transXmultiplier;
        //    // Das Layer sichtbar machen
        //    grid.Visibility = Visibility.Visible;
        //    // Hin zum Wert X anmieren
        //    //Point relativePoint = mainWnd.stckpanelMain.TranslatePoint(new Point(0, 0), mainWnd);
        //    DoubleAnimation ani = new DoubleAnimation(GetToValue(), new Duration(TimeSpan.FromMilliseconds(animationTime_ms)));
        //    ani.AccelerationRatio = accelerationRatio;
        //    ani.DecelerationRatio = decelerationRatio;
        //    ani.Completed += new EventHandler(eventHandler);
        //    trans.BeginAnimation(TranslateTransform.XProperty, ani);
        //}
        /// <summary>
        /// 
        /// </summary>
        //public void CloseAnimation(Grid grid, TranslateTransform trans, EventHandler eventHandler)
        //{
        //    // 1. Zielwert fuer die Animation setzen
        //    double to = grid.ActualWidth * transXmultiplier;
        //    // Layer zum ermittelten wert animieren und EventHandler fuer Completed-Event installieren
        //    DoubleAnimation ani = new DoubleAnimation(to, new Duration(TimeSpan.FromMilliseconds(animationTime_ms)));
        //    ani.AccelerationRatio = accelerationRatio;
        //    ani.DecelerationRatio = decelerationRatio;
        //    ani.Completed += new EventHandler(eventHandler);
        //    trans.BeginAnimation(TranslateTransform.XProperty, ani);
        //}

    }
}
