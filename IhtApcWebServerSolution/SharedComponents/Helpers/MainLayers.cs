using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharedComponents.Helpers
{
    class MainLayers : BaseLayers
    {
        static public double layerManuallyOriginPos_Y { get; set; }

        static MainLayers()
        {
            layerManuallyOriginPos_Y = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public MainLayers(MainWndHelper _mainWndHlp) : base(_mainWndHlp)
        {
            transXmultiplier = -1.0; // -1.0 -> nach rechts Collapsed, nach links  Visible
        }

        override public void Init() { }

        /// <summary>
        /// Die Breite fuer die Layer, die ueber die MainCommands gesteuert werden, setzen
        /// </summary>
        //private double GetMainCommandsLayerWidth()
        //{
        //    Thickness borderThickness = mainWnd.FindResource("IhtBorderThickness") != null ? (Thickness)mainWnd.FindResource("IhtBorderThickness") : new Thickness();
        //    double width = mainWnd.uniformGridMainControl.ActualWidth
        //                  - (mainWnd.MarginLayers.Left + mainWnd.MarginLayers.Right)
        //                  + borderThickness.Left + borderThickness.Right;
        //    return width;
        //}

        /// <summary>
        /// Die Breite fuer die Layer, die ueber die MainCommands gesteuert werden, setzen
        /// </summary>
        //private void SetMainCommandsLayerWidth(double width)
        //{
        //    mainWnd.manuallySetupButtonsControl.Width = width;

        //    mainWnd.layerSetting.Width = width;
        //    mainWnd.layerTemper.Width = width;
        //    mainWnd.layerData.Width = width;
        //    mainWnd.layerManually.Width = width;
        //    mainWnd.layerCutting.Width = width;
        //}

        /// <summary>
        /// Die X-Koordinate fuer die Layer, die ueber die MainCommands gesteuert werden, setzen
        /// </summary>
        //private void SetMainCommandsLayerX(double x)
        //{
        //    mainWnd.layerSettingTrans.X = x;
        //    mainWnd.layerTemperTrans.X = x;
        //    mainWnd.layerDataTrans.X = x;
        //    mainWnd.layerManuallyTrans.X = x;
        //    mainWnd.layerCuttingTrans.X = x;
        //}

        /// <summary>
        /// Die Breite und X-Koordinate fuer die Layer, die ueber die MainCommands gesteuert werden, setzen
        /// </summary>
        //public void SetMainCommandsLayerWidthAndPos()
        //{
        //    // Die Breite fuer die Layer, die ueber die MainCommands gesteuert werden, bestimmen
        //    double width = GetMainCommandsLayerWidth();
        //    if (width <= 0)
        //    {
        //        return;
        //    }
        //    SetMainCommandsLayerWidth(width);
        //    // Die X-Koordinate fuer die Layer, die ueber die MainCommands gesteuert werden, bestimmen
        //    double x = -width;
        //    SetMainCommandsLayerX(x);

        //    // Für manuallySetupButtonsControl die Breite bestimmen
        //    mainWnd.manuallySetupButtonsControl.Width = width - (mainWnd.MarginLayers.Left + mainWnd.MarginLayers.Right);

        //    // Für layerOverlayed die Breite und X-Position bestimmen
        //    Thickness borderThickness = mainWnd.FindResource("IhtBorderThickness") != null ? (Thickness)mainWnd.FindResource("IhtBorderThickness") : new Thickness();
        //    mainWnd.layerOverlayed.Width = width - mainWnd.layerOverlayed.Margin.Left + borderThickness.Right;
        //    mainWnd.layerOverlayedTrans.X = mainWnd.layerMainControlTrans.X
        //                                   + mainWnd.MarginLayers.Left
        //                                   + mainWnd.layerOverlayed.Margin.Left;
        //}

        /// <summary>
        /// 
        /// </summary>
        //override public void Init()
        //{

        //    // Die Breite und X-Koordinate fuer die Layer, die ueber die MainCommands gesteuert werden, setzen
        //    SetMainCommandsLayerWidthAndPos();

        //    // Die Y-Koordinate fuer die Layer, die ueber die MainCommands gesteuert werden, bestimmen,
        //    // dass diese unterhalb der Brenner-Nummerierung-Buttons erscheint 
        //    Point relativePoint = new Point();
        //    relativePoint = mainWnd.mainCtrl_1.radioBut_Torch.TranslatePoint(new Point(0, 5), mainWnd.layerSetting);
        //    double Y = relativePoint.Y + mainWnd.mainCtrl_1.radioBut_Torch.ActualHeight;
        //    mainWnd.layerSettingTrans.Y = Y;
        //    mainWnd.layerTemperTrans.Y = Y;
        //    mainWnd.layerCuttingTrans.Y = Y;

        //    // Dieses Layer verändert die Y-Position
        //    mainWnd.layerManuallyTrans.Y = Y;
        //    layerManuallyOriginPos_Y = mainWnd.layerManuallyTrans.Y;

        //    // Das StackPanelCommonPanel ist genaus so hoch wie die MainControls
        //    mainWnd.borderCommonPanel.Height = mainWnd.uniformGridMainControl.ActualHeight;
        //    // Diese Layer sind genauso so hoch wie die MainControls
        //    mainWnd.layerData.Height = mainWnd.uniformGridMainControl.ActualHeight;
        //    mainWnd.layerOverlayed.Height = mainWnd.uniformGridMainControl.ActualHeight;

        //    // Y-Position vom uniformGridMainControl
        //    double yPosMainControls = mainWnd.uniformGridMainControl.TranslatePoint(new Point(0, 0), mainWnd.layerData).Y;

        //    // Diese Layer liegen nicht unterhalb der Torch-Buttons sondern sind genauso so hoch wie die MainControls
        //    mainWnd.layerDataTrans.Y = yPosMainControls;
        //    mainWnd.layerOverlayedTrans.Y = yPosMainControls;
        //}

        /// <summary>
        /// 
        /// </summary>
        override protected double GetToValue()
        {
            return 0; // mainWnd.borderMain.Margin.Left + mainWnd.borderMain.Margin.Right;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool firstMainManuallyClick = false;
#if false
    public void MainCmd_Executed(ExecutedRoutedEventArgs e, Grid grid, TranslateTransform trans, DoAnimation doAnimation = DoAnimation.Default)
    {
      ToggleButton togbut;// = e.Source as ToggleButton;
      
      if (   (   doAnimation == DoAnimation.Default
              && (togbut = (togbut = e.Source as ToggleButton)) != null
              && togbut.IsChecked == true
             )
          || doAnimation == DoAnimation.Open
         )
      {
        // Lambda
        EventHandler eventHandler = (a, b) =>  {};
        // Für das layerManually erstmalig eine loadAnimation für die Ladedauer anzeigen
        if (!firstMainManuallyClick)
        {
          var element1 = grid as FrameworkElement;
          var element2 = mainWnd.layerManually as FrameworkElement;
          if (element1.Name.Equals(element2.Name))
          {
            firstMainManuallyClick = true;
            mainWnd.loadAnimationMain.Visibility = Visibility.Visible;
            mainWnd.UpdateLayout();
            Task.Delay(500);
            // Lambda
            eventHandler = (a, b) => 
            {
              mainWnd.loadAnimationMain.Visibility = Visibility.Collapsed;
            };
          }
        }
        
        if (doAnimation == DoAnimation.FastAnimation)
        {
          grid.Visibility = Visibility.Visible;
        }
        OpenAnimation(grid, trans, eventHandler);
      }
      else
      {
        if (doAnimation == DoAnimation.FastAnimation)
        {
          grid.Visibility = Visibility.Hidden;
        }
        // Lambda
        EventHandler eventHandler = (a, b) => { grid.Visibility = Visibility.Collapsed; };
        CloseAnimation(grid, trans, eventHandler);
      }
    }
#else
        //public async Task MainCmd_ExecutedAsync(ExecutedRoutedEventArgs e, Grid grid, TranslateTransform trans, DoAnimation doAnimation = DoAnimation.Default)
        //{
        //    ToggleButton togbut;// = e.Source as ToggleButton;

        //    if ((doAnimation == DoAnimation.Default
        //            && (togbut = (togbut = e.Source as ToggleButton)) != null
        //            && togbut.IsChecked == true
        //           )
        //        || doAnimation == DoAnimation.Open
        //       )
        //    {
        //        // Lambda
        //        EventHandler eventHandler = (a, b) => { };
        //        // Für das layerManually erstmalig eine loadAnimation für die Ladedauer anzeigen
        //        if (!firstMainManuallyClick)
        //        {
        //            var element1 = grid as FrameworkElement;
        //            var element2 = mainWnd.layerManually as FrameworkElement;
        //            if (element1 != null && element2 != null)
        //            {
        //                if (element1.Name.Equals(element2.Name))
        //                {
        //                    firstMainManuallyClick = true;
        //                    mainWnd.loadAnimationMain.Visibility = Visibility.Visible;
        //                    //            mainWnd.UpdateLayout();
        //                    await Task.Delay(1000);
        //                    grid.Visibility = Visibility.Visible;
        //                    await Task.Delay(500);
        //                    // Lambda
        //                    eventHandler = (a, b) =>
        //                    {
        //                        mainWnd.loadAnimationMain.Visibility = Visibility.Collapsed;
        //                    };
        //                }
        //            }
        //        }

        //        if (doAnimation == DoAnimation.FastAnimation)
        //        {
        //            grid.Visibility = Visibility.Visible;
        //        }
        //        OpenAnimation(grid, trans, eventHandler);
        //    }
        //    else
        //    {
        //        if (doAnimation == DoAnimation.FastAnimation)
        //        {
        //            grid.Visibility = Visibility.Hidden;
        //        }

        //        var element1 = grid as FrameworkElement;
        //        var element2 = mainWnd.layerManually as FrameworkElement;
        //        if (element1 != null && element2 != null)
        //        {
        //            if (mainWnd.loadAnimationMain.Visibility == Visibility.Visible)
        //            {
        //                mainWnd.loadAnimationMain.Visibility = Visibility.Collapsed;
        //            }
        //        }

        //        // Lambda
        //        EventHandler eventHandler = (a, b) => { grid.Visibility = Visibility.Collapsed; };
        //        CloseAnimation(grid, trans, eventHandler);
        //    }
        //}
#endif
        /// <summary>
        /// 
        /// </summary>
        //public void OpenLayer(Grid grid, TranslateTransform trans)
        //{
        //    // Lambda
        //    EventHandler eventHandler = (a, b) => { };
        //    OpenAnimation(grid, trans, eventHandler);
        //}

        /// <summary>
        /// 
        /// </summary>
        //public void CloseLayer(Grid grid, TranslateTransform trans)
        //{
        //    // Lambda
        //    EventHandler eventHandler = (a, b) => { grid.Visibility = Visibility.Collapsed; };
        //    CloseAnimation(grid, trans, eventHandler);
        //}

    }
}
