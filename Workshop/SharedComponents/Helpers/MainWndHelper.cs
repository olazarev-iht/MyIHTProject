using SharedComponents.Cultures;
using SharedComponents.IhtData;
using SharedComponents.IhtModbus;
using SharedComponents.IhtMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SharedComponents.Helpers
{
    public class MainWndHelper
    {
        private MainLayers mainLayers = null;
        //private CommonLayers commonLayers = null;
        private IhtMsgLogs msgLogs = null;


        //public MainWindow mainWnd = null;

        public ArrayList mainControls = new ArrayList();
        public ArrayList togBtnsOnOff = new ArrayList();
        public ArrayList radioBtns_Torch = new ArrayList();

#if false
    static private MainWndHelper _mainWndHlp_ = null;
    static public MainWndHelper GetMainWndHelper()
    {
      if (_mainWndHlp_ == null)
      {
        _mainWndHlp_ = _mainWndHlp_ = new MainWndHelper();
      }
      return _mainWndHlp_;
    }
#else
        private static readonly Lazy<MainWndHelper> mainWndHlpInstance = new Lazy<MainWndHelper>(() => new MainWndHelper());
        static public MainWndHelper GetMainWndHelper()
        {
            return mainWndHlpInstance.Value;
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        public MainWndHelper()
        {
            //mainWnd = MainWindow.GetMainWindow();
            //this.msgLogs = (IhtMsgLogs)mainWnd.FindResource("msgLogs");

            //// Die MainControl's uebernehmen
            //mainControls.Add(mainWnd.mainCtrl_1);
            //mainControls.Add(mainWnd.mainCtrl_2);
            //mainControls.Add(mainWnd.mainCtrl_3);
            //mainControls.Add(mainWnd.mainCtrl_4);
            //mainControls.Add(mainWnd.mainCtrl_5);
            //mainControls.Add(mainWnd.mainCtrl_6);
            //mainControls.Add(mainWnd.mainCtrl_7);
            //mainControls.Add(mainWnd.mainCtrl_8);
            //mainControls.Add(mainWnd.mainCtrl_9);
            //mainControls.Add(mainWnd.mainCtrl_10);

            //foreach (MainControl mctrl in mainControls)
            //{
            //    // Fuer Zugriff auf die On/Off-Buttons
            //    togBtnsOnOff.Add(mctrl.togbtnOnOff);
            //    // Fuer Zugirff auf die Torch-Buttons
            //    radioBtns_Torch.Add(mctrl.radioBut_Torch);
            //}

            //mainLayers = new MainLayers(this);
            //commonLayers = new CommonLayers(this);
        }

        #region togbtnsOnOff
        /// <summary>
        /// 
        /// </summary>
        //internal void togbtnsOnOff_Checked(object sender, RoutedEventArgs e)
        //{
        //    MainControl mainCtrl = (MainControl)e.Source;
        //    // OnOff-Button der betaetigt wurde
        //    ToggleButton togbtnOnOff = mainCtrl.togbtnOnOff;
        //    // Zugehoeriger Torch-Button
        //    ToggleButton togbtnTorch = null;
        //    // Wird true, wenn mindestens ein OnOff-Button aktiv ist
        //    bool active = false;
        //    int idx = 0;
        //    for (idx = 0; idx < togBtnsOnOff.Count; idx++)
        //    {
        //        // OnOff-Button der betaetigt wurde
        //        if (togBtnsOnOff[idx].Equals(togbtnOnOff))
        //        {
        //            // Zugehoeriger Torch-Button
        //            togbtnTorch = (ToggleButton)radioBtns_Torch[idx];
        //            continue;
        //        }
        //        // Wenn mindestens ein OnOff-Button aktiv ist
        //        else if (((ToggleButton)togBtnsOnOff[idx]).IsChecked == true)
        //        {
        //            active = true;
        //        }
        //    }
        //    // Nur dieser OnOff-Button aktiv
        //    if (active == false && togbtnTorch != null)
        //    {
        //        // Zugehoeriger Torch-Button aktivieren
        //        togbtnTorch.IsChecked = true;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        //internal void togbtnsOnOff_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    MainControl mainCtrl = (MainControl)e.Source;
        //    // OnOff-Button der betaetigt wurde
        //    ToggleButton togbtnOnOff = mainCtrl.togbtnOnOff;
        //    // Zugehoeriger Torch-Button
        //    ToggleButton togbtnTorch = null;
        //    // Wird true, wenn mindestens ein OnOff-Button aktiv ist
        //    bool active = false;
        //    int idx = 0;
        //    for (idx = 0; idx < togBtnsOnOff.Count; idx++)
        //    {
        //        // OnOff-Button der betaetigt wurde
        //        if (togBtnsOnOff[idx].Equals(togbtnOnOff))
        //        {
        //            // Zugehoeriger Torch-Button
        //            togbtnTorch = (ToggleButton)radioBtns_Torch[idx];
        //            bool IsChecked = (togbtnTorch.IsChecked == true);
        //            // Wenn zugehoeriger Torch-Button inaktiv war, dann ist ein anderer Torch-button aktiv, und raus
        //            if (IsChecked == false)
        //            {
        //                return;
        //            }
        //            togbtnTorch.IsChecked = false;
        //            continue;
        //        }
        //        // Wenn mindestens ein OnOff-Button aktiv ist
        //        else if (((ToggleButton)togBtnsOnOff[idx]).IsChecked == true)
        //        {
        //            active = true;
        //        }
        //    }

        //    // Wenn mindestens ein OnOff-Button aktiv ist
        //    if (active == true)
        //    {
        //        for (idx = 0; idx < togBtnsOnOff.Count; idx++)
        //        {
        //            // Fuer den 1. auftretenden aktiven OnOff-Button, den Torch-button aktivieren
        //            if (((ToggleButton)togBtnsOnOff[idx]).IsChecked == true)
        //            {
        //                ((ToggleButton)radioBtns_Torch[idx]).IsChecked = true;
        //                break;
        //            }
        //        }
        //    }
        //}
        #endregion // togbtnsOnOff

        #region togbtnsTorch
        /// <summary>
        /// 
        /// </summary>
        //internal void togbtnsTorch_Checked(object sender, RoutedEventArgs e)
        //{
        //}

        /// <summary>
        /// 
        /// </summary>
        //internal void togbtnsTorch_Unchecked(object sender, RoutedEventArgs e)
        //{
        //}
        #endregion // togbtnsTorch


        /// <summary>
        /// 
        /// </summary>
        public void InitLayers()
        {
            mainLayers.Init();
            //commonLayers.Init();
        }

        /// <summary>
        /// Die Breite und X-Koordinate fuer die Layer, die ueber die MainCommands gesteuert werden, setzen
        /// </summary>
        public void SetMainCommandsLayerWidthAndPos()
        {
            //mainLayers.SetMainCommandsLayerWidthAndPos();
        }

        /// <summary>
        /// 
        /// </summary>
        //public async Task MainCmd_ExecutedAsync(ExecutedRoutedEventArgs e, Grid grid, TranslateTransform trans, BaseLayers.DoAnimation doAnimation = BaseLayers.DoAnimation.Default)
        //{
        //    // Wenn das LayerDataSetDisplay aktiv ist, dieses schliessen
        //    if (mainWnd.butCurrdataSet.IsChecked == true)
        //    {
        //        mainWnd.butCurrdataSet.IsChecked = false;
        //    }
        //    // Wenn Status-Anzeige aktiv ist
        //    if (mainWnd.butShowStatusMessages.IsChecked == true)
        //    {
        //        mainWnd.butShowStatusMessages.IsChecked = false;
        //    }

        //    await mainLayers.MainCmd_ExecutedAsync(e, grid, trans, doAnimation);
        //}

        /// <summary>
        /// 
        /// </summary>
        //public void MainCmdCommonLayers_Executed(ExecutedRoutedEventArgs e, Grid grid, TranslateTransform trans, BaseLayers.DoAnimation doAnimation = BaseLayers.DoAnimation.Default)
        //{
        //    commonLayers.MainCmd_Executed(e, grid, trans, doAnimation);
        //}
        /// <summary>
        /// 
        /// </summary>
        //public void MainCmdCommonLayers_Executed(Grid grid, TranslateTransform trans, BaseLayers.DoAnimation doAnimation)
        //{
        //    commonLayers.MainCmd_Executed(grid, trans, doAnimation);
        //}

        /// <summary>
        /// 
        /// </summary>
        //public void OpenLayer(Grid grid, TranslateTransform trans)
        //{
        //    // Lambda
        //    EventHandler eventHandler = (a, b) => { };
        //    mainLayers.OpenAnimation(grid, trans, eventHandler);
        //}

        /// <summary>
        /// 
        /// </summary>
        //public void CloseLayer(Grid grid, TranslateTransform trans)
        //{
        //    // Lambda
        //    EventHandler eventHandler = (a, b) => { grid.Visibility = Visibility.Collapsed; };
        //    mainLayers.CloseAnimation(grid, trans, eventHandler);
        //}

        /// <summary>
        /// Alle Msg-Logdaten loeschen  
        /// </summary>
        private int NoStatusMsg = 0;
        public void ClrStatusMsgs()
        {
            msgLogs.Clear();
            NoStatusMsg = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private void StatusMsg(IhtMsgLog.Info info, string msg)
        {
            if (NoStatusMsg == 0)
            {
                //this.msgLogs.Add(new IhtMsgLog(IhtMsgLog.Info.Info, CultureResources.GetString("_CultureMsgLogAppStarted"), ++NoStatusMsg));
            }

            //MainWindow.logger.InfoFormat(msg);
            NoStatusMsg += (msg.Length > 0) ? 1 : 0;
            this.msgLogs.Add(new IhtMsgLog(info, msg, NoStatusMsg));
            //ListView lv = this.mainWnd.eventDisplay.listView;
            //if (lv.Items.Count > 0)
            //{
            //    lv.ScrollIntoView(lv.Items[lv.Items.Count - 1]);
            //}
            //App.RefreshListViewColumnWidths(lv.View as GridView);

            //if (info == IhtMsgLog.Info.Error)
            //{
            //    mainWnd.SetImageButStatusMsg_Error();
            //}
            //else if (info == IhtMsgLog.Info.Warning)
            //{
            //    mainWnd.SetImageButStatusMsg_Warning();
            //}
        }
        private static object _lockMsgLog = new object();
        internal void SetStatusMsg(IhtMsgLog.Info info, string msg)
        {
            try
            {
                // TODO: implement ?
                //if (Thread.CurrentThread != null && Application.Current != null)
                //{
                //    if (Thread.CurrentThread.ManagedThreadId != Application.Current.Dispatcher.Thread.ManagedThreadId)
                //    {
                //        BindingOperations.EnableCollectionSynchronization(msgLogs, _lockMsgLog);
                //        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                //        {
                //            StatusMsg(info, msg);
                //        }));
                //    }
                //    else
                //    {
                //        StatusMsg(info, msg);
                //    }
                //}
            }
            catch (Exception)
            {

            }
        }
        internal void SetStatusMsgCultureId(IhtMsg.IhtMsgLog.Info info, string _cultureName)
        {
            SetStatusMsg(info, CultureResources.GetString(_cultureName));
        }

    }

}
