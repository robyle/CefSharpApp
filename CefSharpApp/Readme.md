# 使用说明
默认安装CefSharp后修改为X86编译生成就可以了，如果需要任何平台运行需要进行如下操作:
1.安装的时候修改项目
2.修改APP.config
3.在new对象的时候添加设置

## 内存回收办法

GC.Collect();
GC.WaitForPendingFinalizers();
Process[] processes = Process.GetProcesses();
foreach (Process process in processes)
{
    try
    {
        EmptyWorkingSet(process.Handle);
    }
    catch
    {
    }
}

时间:2017年12月28日10:50