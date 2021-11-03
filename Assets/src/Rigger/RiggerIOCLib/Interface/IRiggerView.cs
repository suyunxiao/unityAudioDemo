//======================================================================================
/**
 *  suchuan
 *  时间：2021/10/27 19:23:12
 *  功能：作为界面适配接口
 */
//======================================================================================


namespace RiggerIOC
{
    //[DecoratorInterfaceAttribute(typeof(DemoModle))]
    public interface IRiggerView : IRiggerBase
    {
        //public abstract void OnDestroy();

        new void OnStartRigger();

    }
}
