using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

Console.WriteLine($"NullReferenceException message is: {new NullReferenceException().Message}");
Console.WriteLine($"The runtime type of int is named: {typeof(int)}");
Console.WriteLine($"Type of boxed integer is{(123.GetType() == typeof(int) ? "" : " not")} equal to typeof(int)");
Console.WriteLine($"Type of boxed integer is{(123.GetType() == typeof(byte) ? "" : " not")} equal to typeof(byte)");
Console.WriteLine($"Upper case of 'Вторник' is '{"Вторник".ToUpper()}'");
Console.WriteLine($"Current stack frame is {new StackTrace().GetFrame(0)}");

Console.WriteLine($"await start ");



bool isStop = false;
List<String> list = new List<string>();
new Thread(() => {
    int i = 0;

    while (!isStop) {
        Thread.Sleep(300);
        list.Add($"${i}");
        Console.WriteLine($"[{Thread.CurrentThread.Name}] :{i}");
        i++;
    }
}) { Name = "Thread-2" }.Start();



for (int i = 3; i > 0; i--) {
    await Task.Delay(1000);
    Console.WriteLine($"await delay {i} s");
}



isStop = true;
Console.WriteLine($"exit:{list.Count}");


// 要执行的 shell 命令
string command = "su -c ls -l";

// 创建一个 ProcessStartInfo 对象，用于设置进程启动的相关信息
ProcessStartInfo psi = new ProcessStartInfo("sh", $"-c \"{command}\"")
{
    RedirectStandardOutput = true,
    RedirectStandardError = true,
    UseShellExecute = false,
    CreateNoWindow = true
};

// 创建一个 Process 对象
Process process = new Process { StartInfo = psi };

try
{
    // 启动进程
    process.Start();

    // 读取标准输出和标准错误流
    string output = process.StandardOutput.ReadToEnd();
    string error = process.StandardError.ReadToEnd();

    // 等待进程退出
    process.WaitForExit();

    // 输出结果
    Console.WriteLine("Standard Output:");
    Console.WriteLine(output);

    Console.WriteLine("Standard Error:");
    Console.WriteLine(error);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}