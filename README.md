# Wpf.MVVMLight.Demo
Wpf mvvmlight 基于mvvm设计模式的轻量级框架
MVVM模式和MVC模式一样，主要目的是分离视图（View）和模型（Model），有几大优点
1. 低耦合：视图（View）可以独立于Model变化和修改，一个ViewModel可以绑定到不同的View上，当View变化的时候Model可以不变，当Model变化的时候View也可以不变。
2. 可重用性：可以把一些视图逻辑放在一个ViewModel里面，让很多View重用这段视图逻辑。
3. 独立开发：开发人员可以专注于业务逻辑和数据的开发（ViewModel），设计人员可以专注于页面设计，使用Expression Blend可以很容易设计界面并生成xml代码。
4. 可测试：界面素来是比较难于测试的，而现在测试可以针对ViewModel来写。

具有两大特性： 1.命令机制 2.消息发布订阅机制

.net core nuget引用
Microsoft.Practices.ServiceLocation
CommonServiceLocator
Mvvmlight

MVVMLight的官网：http://www.mvvmlight.net/

