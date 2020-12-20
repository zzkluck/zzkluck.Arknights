namespace Zzkluck.Arknights.Library.AkdataObject
{
    /// <summary>
    /// 用于标志继承它的类是某一个Json文件的抽象
    /// </summary>
    public interface IJsonFileObject{}

    public interface IJsonFileObjectDictionaryExt : IJsonFileObject 
    {
        System.Collections.IDictionary GetDictionary();
        System.Type GetSubType();
    }

    public interface ITestJsonObject : IJsonFileObject { }
}
