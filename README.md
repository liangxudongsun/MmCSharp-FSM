# MiMieFSM

UpdateFsm + ChainedFsm 跨引擎状态机运行时库

## 结构

```
src/MieMieFSM.Core/          netstandard2.1 核心源码 Godot 等可直接引用 DLL
unity/                       Unity UPM 运行时包 com.hakisheep.mm-fsm
```

编辑器生成器在 HakiSheep 框架内

```
Assets/MieMieFrameTools/Editor/FsmForEditor/
```

## Unity 安装

Package Manager 添加 Git URL

```
git@github.com:Haki-sheep/MmCSharp-FSM.git?path=unity
```

## 编辑器菜单

框架自带 无需 UPM 包也能打开窗口

```
Tools/MieMieFrameWork/FSM/FSM枚举生成器
Tools/MieMieFrameWork/FSM/链式FSM生成器
```

窗口内会检测 MiMieFSM 运行时是否已安装

## 构建核心 DLL

```bash
dotnet build src/MieMieFSM.Core/MieMieFSM.Core.csproj -c Release
```
