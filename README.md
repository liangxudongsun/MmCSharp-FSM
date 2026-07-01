# MiMieFSM

UpdateFsm + ChainedFsm 跨引擎状态机库

## 结构

```
src/MieMieFSM.Core/     netstandard2.1 运行时核心
unity/                  Unity UPM 包 com.hakisheep.mm-fsm
```

## Unity 安装

Package Manager 添加 Git URL

```
git@github.com:Haki-sheep/MmCSharp-FSM.git?path=unity
```

## 构建核心 DLL

```bash
dotnet build src/MieMieFSM.Core/MieMieFSM.Core.csproj -c Release
copy src/MieMieFSM.Core/bin/Release/netstandard2.1/MiMieFSM.dll unity/Runtime/Plugins/
```

## 编辑器工具

- Tools/MieMieFrameWork/FSM/FSM枚举生成器
- Tools/MieMieFrameWork/FSM/链式FSM生成器

未安装 MiMieFSM 库时编辑器会提示无法使用
