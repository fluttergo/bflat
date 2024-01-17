# Minimal size sample

This demonstrates how to build a minimal size executable with bflat.

```console
$ bflat build minimalsize.cs --no-reflection --no-stacktrace-data --no-globalization --no-exception-messages -Os --no-pie --separate-symbols
```

This will produce a minimalsize(.exe) file that is native compiled. You can launch it. Observe the difference in runtime behavior and size of the output when you omit some of the arguments from the `bflat build` command line above.


```shell
#编译成android可执行文件
bflat build minimalsize.cs --no-reflection --no-stacktrace-data --no-globalization --no-exception-messages -Os  --separate-symbols --libc bionic  --arch arm64  --os linux
````

```shell
#安装此程序到android设备
adb push D:\workSpace\bflat\samples\MinimalSize\minimalsize /data/local/tmp/
```



```shell
#运行此程序
chmod +x minimalsize

./minimalsize



```

输出如下内容:

```

NullReferenceException message is: Arg_NullReferenceException
The runtime type of int is named: MT399534553776
Type of boxed integer is equal to typeof(int)
Type of boxed integer is not equal to typeof(byte)
Upper case of 'Вторник' is 'ВТОРНИК'
Current stack frame is minimalsize!<BaseAddress>+0x17c1c4 at offset 644 in file:line:column <filename unknown>:0:0

await start
[Thread-2] :0
[Thread-2] :1
[Thread-2] :2
await delay 3 s
[Thread-2] :3
[Thread-2] :4
[Thread-2] :5
await delay 2 s
[Thread-2] :6
[Thread-2] :7
[Thread-2] :8
await delay 1 s
exit:9
[Thread-2] :9
Standard Output:
total 18590
-rwxrwxrwx 1 shell shell  1797504 2024-01-17 15:36 minimalsize
```