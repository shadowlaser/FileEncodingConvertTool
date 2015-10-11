# FileEncodingConvertTool
一个文件编码相互转换的小工具

## 命令行
    -e : 扩展名集合（.txt,.cpp,.c）
    -f ： 文件集合(1.txt,2,txt,3.txt,4.cpp)
    -dir ： 目录集合(d:\,d:\files\)
    -s : 需要处理的文件的编码格式
    -d : 转换后的编码格式
    -b : 备份标记
例子1：有一个文件夹,让所有指定的文件后缀的转换为utf8，不需要关心源文件编码格式，那么如下命令：
```
c:\>fcte.exe -dir d:\testfiles -e .txt,.cpp -d utf8
```
如果不想指定文件类型的话，只要去掉-e选项 就可以了

例子2：转换指定编码格式的文件为utf8编码，如下命令：
```
c:\>fcte.exe -dir d:\testfiles1,c:\testfiles2 -s utf8nb,utf16le,utf16be -d utf8
```
`utf8nb` 是utf8 with bom

## GUI 版
gui 版可以选择文件夹


## 待改进
	1. ui线程和worker 线程
	2. ...