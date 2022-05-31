#本项目为Memobus通信工具

>v1.1.0.2
将所有读取plc数据长度的参数换为int

>v1.1.0.1
添加了32数据读取后根据是否成功来判断要不要处理16位数据
(由于本代码的32位数据读写是基于对16位数据的批量操作实现的)

>v1.1.0.0
本代码经过了安川PLC的实机测试，测试通过。
修复了报文头指令不正确的问题
修复了起始地址转byte数组的偏移错误
修复了批量读取时缓冲区长度不对的错误

>v1.0.0.2
新增了plc地址偏移设置，以应对某些品牌plc配置后写入地址和实际地址有偏移的问题。
比如plc内将m1000地址设置为写入的起始地址，那么实际写入m0时会自动偏移至m1000，若写入m1000则会写在m2000的位置。

>v1.0.0.1
新增了批量写入和读取上限的限制

>v1.0.0.0版本
基本功能：
目前支持单字、双字、有无符号的读写。批量个单个都支持
基于memobus的批量读写协议实现