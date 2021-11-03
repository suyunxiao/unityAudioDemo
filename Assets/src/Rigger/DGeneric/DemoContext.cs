//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/14 17:20:30
 *  功能：
 */
//======================================================================================

using ConsoleApp1.Decorator.DGeneric;
using DebugTool;
using Rigger.Modele;
using RiggerIOC;

namespace Rigger.Demo
{
    /// <summary>
    /// 
    /// </summary>
    public class DemoContext : RiggerContext
    {
        [DecoratorAttribute (typeof (DemoModle))]
        public DemoModle modle;

        public override void bindInjections()
        {
            base.bindInjections();
            //base.bindInjections();
            DebugUtils.Log("1 star BindInjections");
            //injector.Bind<DemoModle>().ToSingleton();
            modle.OutIndex();
            modle.AddIndex();
            modle.OutIndex();
            DemoServer server = new DemoServer();
            server.Init();
            DemoView view = new DemoView();
            view.Begin();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public override void bindInjections()
        //{
        //    base.bindInjections();
        //    DebugUtils.Log("star BindInjections");
        //    //injector.Bind<DemoModle>().ToSingleton();
        //    modle.OutIndex ();
        //    modle.AddIndex ();
        //    modle.OutIndex ();
        //    DemoServer server = new DemoServer ();
        //    server.Init ();
        //}

    }
}
