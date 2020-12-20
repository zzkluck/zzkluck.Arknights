/// <summary>
/// 这一命名空间/文件夹下存放了Json文件‘选择性粘贴'来的实体类模型
/// 以及类JsonFileObjectParser包装了解析文件的方法
/// </summary>
/// <remarks>
/// 所有Json文件根类型都以Object为后缀，并有对应名称对.cs文件。其中包含的子类型一般与根类型在同一.cs文件下。
/// 有两种例外：
/// 1. 该子类型亦被其他根类型使用，这种情况子类型存放在SharedObject.cs文件中；
/// 2. 大量定义了该子类型上的方法，这时子类型有单独的.cs文件。
/// 所有*Object类继承了公共接口IJsonFileObject
/// 然而这个接口除了为静态泛型方法JsonFileObjectParser.Parser指引类型之外没啥用
/// 说起来这个Parser的类型直接用dynamic就好的，不过我想要一点编译器的强类型支持
/// </remarks>
namespace Zzkluck.Arknights.Library.AkdataObject
{
    //TODO: 为所有的*Object实现序列化特性
    //TODO: 为所有类型的属性添加注释，更充分地利用IntelliSence
}
